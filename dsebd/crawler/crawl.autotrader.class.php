<?php
session_start();

require_once (dirname(__FILE__) . "/../util/regexwebcrawler.class.php");
require_once (dirname(__FILE__) . "/../util/webutility.class.php");
require_once (dirname(__FILE__) . "/../db/database.class.php");

class CrawlAutotrader {
	var $regexWeb;
	var $database;
	var $si;

	public function CrawlAutotrader() {
		$this->regexWeb = new RegexWebCrawler("");
		$this->database = new MySQLDB();

		$this->regexWeb->addRegexRule("Search", '/<p class="car-details-link">(<strong>)?<a name="([0-9]+)"/', "$2");
		$this->regexWeb->addRegexRule("Next", '%<a href="(.+?)">Next &gt;</a>%', "$1");

		$this->regexWeb->addRegexRule("Title", '%<h2>\s*(.+?)\s*</h2>%s', "$1");
		$this->regexWeb->addRegexRule("Body", '%<td class="car-attribute-label">Body Style</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Price", '%<td class="car-attribute-label">MSRP</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Mileage", '%<td class="car-attribute-label">Mileage</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Engine", '%<td class="car-attribute-label">Engine</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Transmission", '%<td class="car-attribute-label">Transmission</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Fuel", '%<td class="car-attribute-label">Fuel Type</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Doors", '%<td class="car-attribute-label">Doors</td>\s*<td>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Wheelbase", '%<td class="car-attribute-label">Drive Type</td>\s*<td\s?>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Exterior", '%<td class="car-attribute-label">Exterior Color</td>\s*<td\s?>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Interior", '%<td class="car-attribute-label">Interior Color</td>\s*<td\s?>\s*(.+?)\s*</td>%s', "$1");
		$this->regexWeb->addRegexRule("Photo", '%<img src="([^\s]+?)" alt="Click to enlarge this photo\."%s', "$1");
		$this->regexWeb->addRegexRule("Phone", '%<h3>([0-9]{3}-[0-9]{3}-[0-9]{4})</h3>%s', "$1");



	}

	function processAnElementInfo($aid, $sid, $url) {
		$itemUrl = "http://www.autotrader.com/fyc/vdp.jsp?car_id=" . $url;
		$result = WebUtility :: getHttpContent($itemUrl);
		$this->regexWeb->setParseData($result);

		////////////UPDATE///////////////
		$title = addslashes($this->regexWeb->parseRule("Title"));
		$body = addslashes($this->regexWeb->parseRule("Body"));
		$price = addslashes($this->regexWeb->parseRule("Price"));
		$mileager = addslashes($this->regexWeb->parseRule("Mileage"));
		$engine = addslashes($this->regexWeb->parseRule("Engine"));
		$transmission = addslashes($this->regexWeb->parseRule("Transmission"));
		$fuel = addslashes($this->regexWeb->parseRule("Fuel"));
		$doors = addslashes($this->regexWeb->parseRule("Doors"));
		$wheelbase = addslashes($this->regexWeb->parseRule("Wheelbase"));
		$exterior = addslashes($this->regexWeb->parseRule("Exterior"));
		$interior = addslashes($this->regexWeb->parseRule("Interior"));
		$phone = addslashes($this->regexWeb->parseRule("Phone"));
		$imageurl = addslashes($this->regexWeb->parseRule("Photo"));

		//Insert into MySQL database...

		$sql = "INSERT INTO searchresult (`sid`, `url`, `title`, `fuel`, `phone`, `price`, `engine`, `mileage`, `body`, `interiorcolor`, `exteriorcolor`, `doors`, `wheelbase`, `transmission`, `imageurl`) " .
		"VALUES ( '$sid',  '$itemUrl',  '$title',  '$fuel',  '$phone',  '$price', '$engine',  '$mileage',  '$body',  '$interior',  '$exterior',  '$doors', '$wheelbase', '$transmission', '$imageurl');";
		$result = $this->database->query($sql);
		$sql = "DELETE FROM pendingqueue WHERE aid='$aid'";
		$result = $this->database->query($sql);

		//usleep(500000); //0.5 Second...
		//sleep(1);//1 Second...
	}

	function getPendingLinks($sid) {
		$result = $this->database->query("SELECT * FROM pendingqueue WHERE sid='$sid' limit 5;");
		$links = array ();
		while ($row = mysql_fetch_array($result)) {
			$links[0][] = $row["url"];
			$links[1][] = $row["aid"];
			$links[2][] = $row["info"];
		}
		return $links;
	}

	function willCancel($sid) {
		$sql = "SELECT status FROM searches WHERE sid='$sid';";
		$result = mysql_fetch_array($this->database->query($sql));
		if ($result != FALSE && $result['status'] != 'run') {
			return true;
		}
		return false;
	}

	function processPendingQueue($sid) {
		while (count($result = $this->getPendingLinks($sid)) > 1) {
			for ($i = 0; $i < count($result[0]); $i++) {
				echo "<p>Collecting # " . ($this->si++ +1) . " :" . $result[0][$i] . "</p>\n";
				$this->boatclass = $result[2][$i];
				$this->processAnElementInfo($result[1][$i], $sid, $result[0][$i]);
			}
			if ($this->willCancel($sid))
				return;
		}
	}

	function getPendingSearch($sid) {
		$result = $this->database->query("SELECT * FROM pendingsearch WHERE sid='$sid';");
		return mysql_fetch_array($result);
	}

	function processLinks($sid, $url) {
		$result = WebUtility :: getHttpContent($url);
		if ($result == null)
			return;
		$this->regexWeb->setParseData($result);
		$mc = $this->regexWeb->parseRuleArray("Search");
		$next = $this->regexWeb->parseRule("Next");
		$next = str_replace("&amp;", "&", $next);
		$classes = $this->regexWeb->parseRuleArray("InfoClass");
		echo "<p><i>No of results found in this page: " . count($mc) . "</i></p>\n";
		if (count($mc) < 10 || $url == $next)
			$next = null;

		if ($next == null || $next == "") {
			//Search is finished
			$sql = "DELETE FROM pendingsearch WHERE sid='$sid';"; //Delete Entry
			$result = $this->database->query($sql);
			echo "Finished Collecting URL!";
		} else {
			$url = "http://www.autotrader.com" . $next;
			$newtime = time();
			$sql = "UPDATE pendingsearch SET url='$url', timestamp='$newtime' WHERE sid='$sid';"; //Update Next Field
			$result = $this->database->query($sql);
		}

		for ($i = 0; $i < count($mc); $i++) {
			$mm = $mc[$i];
			$class = $classes[$i];
			$sql = "INSERT INTO pendingqueue (sid, url, info) VALUES ('$sid', '$mm', '$class');";
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

			if ($mode == "normal") {
				$result = $this->processPendingQueue($sid);
			}

			$search = $this->getPendingSearch($sid);
			if ($search == FALSE || $this->willCancel($sid))
				$url = null;
			else
				$url = $search["url"];
		}

		//Traverse for extended mode...
		if ($mode == "extended") {
			$this->processPendingQueue($sid);
		}
		echo "<h1>Finished!!!</h1>";
	}

	function updateDatabaseStatus($sid) {
		$this->database->query("update searches set status='run' where sid='$sid'");
	}

	function cleanup() {
		$currentTime = time() - 600; //10 minute
		$sql = "SELECT sid FROM pendingsearch WHERE timestamp < '$currentTime';";
		$result = $this->database->query($sql);

		while ($row = mysql_fetch_array($result)) {
			$tmp = $this->database->query("SELECT mode FROM searches WHERE sid='" . $row['sid'] . "';");
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

		if (preg_match('/zipcode=([0-9]{5})/', $baseUrl, $regs)) {
			$this->zip = $regs[1];
		} else {
			$this->zip = "";
		}

		$currentTime = time() - 600; //10 minute
		$sql = "SELECT sid FROM searches WHERE url='$baseUrl' AND sid < '$currentTime';";
		$result = $this->database->query($sql);
		if (mysql_num_rows($result) >= 0) {
			$sid = time();
			$this->insertSearch($sid, $baseUrl, $site, $mode);
			$this->insertPendingSearch($sid, $baseUrl);
			$this->resumeCrawl($sid, $mode);
		} else {
			echo '<h4>You cannot search this too fast! A search may be already pending.</h4>';
		}
	}
}
?>







