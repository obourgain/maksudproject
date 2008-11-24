<?php
session_start();

require_once (dirname(__FILE__) . "/../util/regexwebcrawler.class.php");
require_once (dirname(__FILE__) . "/../util/webutility.class.php");
require_once (dirname(__FILE__) . "/../db/database.class.php");

class CrawlCars {
	var $regexWeb;
	var $database;
	var $si;

	public function CrawlCars() {
		$this->regexWeb = new RegexWebCrawler("");
		$this->database = new MySQLDB();

		$this->regexWeb->addRegexRule("Search", '/<div class="YmmHeader"><a href="([^\s]+?)"/si', "$1");
		$this->regexWeb->addRegexRule("Next", '/<div class="next" id="nxtLower"><a href="([^\s]+?)"/si', "$1");



		$this->regexWeb->addRegexRule("Mileage", '%Mileage:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Body", '%Body Style:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("InteriorColor", '%Interior Color:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("ExteriorColor", '%Exterior Color:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Stock", '%Stock #:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Engine", '%Engine:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Transmission", '%Transmission:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Doors", '%Doors:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Zip", '%Z-([0-9]{5})%', "$1");
		$this->regexWeb->addRegexRule("Phone", '/Call: ((&#[0-9]{2};){3})&#45;((&#[0-9]{2};){3})&#45;((&#[0-9]{2};){4})/', "($1) $3-$5");
		$this->regexWeb->addRegexRule("Wheelbase", '%Wheelbase:</span>(\s*)<span class="data">(.+?)</span>%', "$2");
		$this->regexWeb->addRegexRule("Photo", '%src="(http://images\.cars\.com/(.+?))" name="chosenPhotoIMG"%', "$1");
	}

	function processABoatInfo($aid, $sid, $url) {
		$itemUrl = "http://www.cars.com/go/search/" . $url;
		$result = WebUtility :: getHttpContent($itemUrl);

		$this->regexWeb->setParseData($result);

//		$class = addslashes($this->regexWeb->parseRule("Class"));
//		$category = addslashes($this->regexWeb->parseRule("Category"));
//		$year = addslashes($this->regexWeb->parseRule("Year"));
//		$make = addslashes($this->regexWeb->parseRule("Make"));
//		$model = addslashes($this->regexWeb->parseRule("Model"));
//		$length = addslashes($this->regexWeb->parseRule("Length"));
//		$fuel = addslashes($this->regexWeb->parseRule("Fuel"));
		$zip = addslashes($this->regexWeb->parseRule("Zip"));
		$phone = addslashes($this->regexWeb->parseRule("Phone"));
		$imageurl = addslashes($this->regexWeb->parseRule("Photo"));

		//Insert into MySQL database...
		$sql = "INSERT INTO searchresult (`sid`, `url`, `class`, `category`, `year`, `make`, `model`, `length`, `fuel`, `phone`, `zip`, `price`, `imageurl` ) " .
		"VALUES ( '$sid',  '$itemUrl',  '$class',  '$category',  '$year',  '$make',  '$model',  '$length',  '$fuel',  '$phone',  '$zip',  '$price',  '$imageurl');";
		$result = $this->database->query($sql);
		$sql = "DELETE FROM pendingqueue WHERE aid=$aid";
		$result = $this->database->query($sql);
	}

	function getPendingLinks($sid) {
		$result = $this->database->query("SELECT * FROM pendingqueue WHERE sid=$sid limit 5;");
		$links = array ();
		while ($row = mysql_fetch_array($result)) {
			$links[0][] = $row["url"];
			$links[1][] = $row["aid"];
		}
		return $links;
	}

	function willCancel($sid) {
		//If Session is cancelled stop the search
		if (!isset ($_SESSION["sid"]) || $_SESSION["sid"] != $sid) //a check...
			return true;

		$sql = "SELECT status FROM searches WHERE sid='$sid';";
		$result = mysql_fetch_array($this->database->query($sql));
		if ($result != FALSE && $result['status'] != 'run') {
			unset ($_SESSION["sid"]);
			return true;
		}
		return false;
	}

	function processPendingQueue($sid) {
		while (count($result = $this->getPendingLinks($sid)) == 2) {
			for ($i = 0; $i < count($result[0]); $i++) {
				echo "<p>Collecting # " . ($this->si++ +1) . " :" . $result[0][$i] . "</p>\n";
				$this->processABoatInfo($result[1][$i], $sid, $result[0][$i]);
			}
			if ($this->willCancel($sid))
				return;
		}
	}

	function getPendingSearch($sid) {
		$result = $this->database->query("SELECT * FROM pendingsearch WHERE sid=$sid;");
		return mysql_fetch_array($result);
	}

	function processLinks($sid, $url) {
		$result = WebUtility :: getHttpContent($url);
		if ($result == null)
			return;
		echo $result;
		$this->regexWeb->setParseData($result);
		$mc = $this->regexWeb->parseRuleArray("Search");
		$next = $this->regexWeb->parseRule("Next");
		echo "<p><i>No of results found in this page: " . count($mc) . "</i></p>\n";
		if ($next == null || $next == "") {
			//Search is finished
			$sql = "DELETE FROM pendingsearch WHERE sid=$sid;"; //Delete Entry
			$result = $this->database->query($sql);
			echo "Finished Collecting URL!";
		} else {
			$url = "http://www.cars.com/go/search/" . $next;
			$newtime = time();
			$sql = "UPDATE pendingsearch SET url='$url', timestamp=$newtime WHERE sid=$sid;"; //Update Next Field
			$result = $this->database->query($sql);
		}

		for ($i = 0; $i < count($mc); $i++) {
			$mm = $mc[$i];
			$sql = "INSERT INTO pendingqueue (sid, url) VALUES ('$sid', '$mm');";
			$result = $this->database->query($sql);
		}
		return $mc;
	}

	function resumeCrawl($sid, $mode) {
		$this->cleanup();
		$this->si = 0;
		$_SESSION["sid"] = $sid;
		$search = $this->getPendingSearch($sid);

		if ($mode == "normal") {
			$this->processPendingQueue($sid);
		}
		$url = $search["url"];

		while ($url != null && $url != "") {
			echo "<h3>Collecting Search Results... </h3><p><i>" . $url . "</i></p>\n";
			$this->processLinks($sid, $url);

			// Traverse for normal mode... No Graceful Exit
			if ($mode == "normal") {
				$result = $this->processPendingQueue($sid);
			}

			$search = $this->getPendingSearch($sid);
			if ($search == FALSE)
				$url = null;
			else
				$url = $search["url"];
		}

		//Traverse for extended mode...
		if ($mode == "extended") {
			//$this->processPendingQueue($sid);
		}
		unset ($_SESSION["sid"]);
		echo "<h1>Finished!!!</h1>";
	}

	function updateDatabaseStatus($sid) {
		$this->database->query("update searches set status='run' where sid=$sid");
	}

	function cleanup() {
		$currentTime = time() - 600; //10 minute
		$sql = "SELECT sid FROM pendingsearch WHERE timestamp < $currentTime;";
		$result = $this->database->query($sql);

		while ($row = mysql_fetch_array($result)) {
			$tmp = $this->database->query("SELECT mode FROM searches WHERE sid=" . $row['sid'] . ";");
			$tmp = mysql_fetch_array($tmp);
			if ($tmp["mode"] == "normal")
				$this->database->query("DELETE FROM pendingqueue WHERE sid='" . $row['sid'] . "';");
			$this->database->query("DELETE FROM pendingsearch WHERE sid='" . $row['sid'] . "';");
		}
	}

	function insertSearch($sid, $url, $site, $mode) {
		$url = addslashes($url);
		$sqlSearches = "INSERT INTO  searches (`sid` , `url` , `site`, `mode`, `status` ) VALUES ( '$sid',  '$url',  '$site', '$mode', 'run' );";
		$result = $this->database->query($sqlSearches);
	}

	function insertPendingSearch($sid, $url) {
		$id = time();
		$url = addslashes($url);
		$sqlpendingsearch = "INSERT INTO pendingsearch ( `sid`, `url`, `timestamp` ) VALUES ( '$sid',  '$url',  '$id');";
		$result = $this->database->query($sqlpendingsearch);
	}

	function processCrawl($site, $mode, $baseUrl) {
		if (isset ($_SESSION["sid"])) {
			unset($_SESSION["sid"]);
			//$this->resumeCrawl($_SESSION["sid"]);// Already in session... Do nothing...
		} else {
			$sid = time();
			$this->insertSearch($sid, $baseUrl, $site, $mode);
			$this->insertPendingSearch($sid, $baseUrl);
			$this->resumeCrawl($sid, $mode);
		}
	}
}


$ws = new CrawlCars();
$ws->processCrawl("cars", "extended", "http://www.cars.com/go/search/search_results.jsp?criteria=K-|E-|M-_9_|N-N|R-30|I-1,7|P-PRICE%20descending|Q-descending|Z-78757&aff=national");

?>
