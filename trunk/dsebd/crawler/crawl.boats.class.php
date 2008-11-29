<?php
session_start();

require_once (dirname(__FILE__) . "/../util/regexwebcrawler.class.php");
require_once (dirname(__FILE__) . "/../util/webutility.class.php");
require_once (dirname(__FILE__) . "/../db/database.class.php");

class CrawlBoats {
	var $regexWeb;
	var $database;
	var $si;

	public function CrawlBoats() {
		$this->regexWeb = new RegexWebCrawler("");
		$this->database = new MySQLDB();

		$this->regexWeb->addRegexRule("Search", '%<a href=".+(entityid=([0-9]+)).+" class="financeitButton">Details</a>%', "$1");
		$this->regexWeb->addRegexRule("Next", '/<a class="navNext" href="(.+?)">Next/', "$1");
		$this->regexWeb->addRegexRule("InfoClass", '%Boat Class</b></td>\s+<td class="searchResultsDetailsDataTable">(.+?)</td>%', "$1");

		$this->regexWeb->addRegexRule("Title", '/<title>(.+?) - Boats\.com/', "$1");
		$this->regexWeb->addRegexRule("Engine", '%<B>Engine Type&nbsp;</B></TD><TD width=116 valign=top style=\'padding-right:50px;\'><span class=boatspecs_values>(.+?)</span>%', "$1");
		$this->regexWeb->addRegexRule("Hull", '%<B>Hull Material&nbsp;</B></TD><TD width=116 valign=top style=\'padding-right:50px;\'><span class=boatspecs_values>(.+?)</span>%', "$1");
		$this->regexWeb->addRegexRule("Year", '%<b>Year:</b>(\s+)([0-9]+)%', "$2");
		$this->regexWeb->addRegexRule("Make", '%<B>Engine Make&nbsp;</B></TD><TD width=116 valign=top style=\'padding-right:50px;\'><span class=boatspecs_values>(.+?)</span>%', "$1");
		$this->regexWeb->addRegexRule("Length", '%<b>Length:</b>(\s+)([0-9]+)%', "$2");
		$this->regexWeb->addRegexRule("Fuel", '%<B>Fuel&nbsp;</B></TD><TD width=116 valign=top style=\'padding-right:50px;\'><span class=boatspecs_values>(.+?)</span>%', "$1");
		$this->regexWeb->addRegexRule("Price", '%<b>Price:</b>(.+)(US\$.+?)\)?&nbsp;&nbsp;%s', "$2");
		$this->regexWeb->addRegexRule("Phone", '%Call:&nbsp;([0-9]{3})-([0-9]{3})-([0-9]{4})%', "($1) $2-$3");
		$this->regexWeb->addRegexRule("Photo", '%<a class="bodylink" href="(.+?)"><img src="(.+?)"(.+?)></a>%', "$2");
	}

	function processAnElementInfo($aid, $sid, $url) {
		$itemUrl = "http://www.boats.com/listing/boat_details.jsp?" . $url;
		$result = WebUtility :: getHttpContent($itemUrl);
		$this->regexWeb->setParseData($result);

		////////////UPDATE///////////////
		$title = addslashes($this->regexWeb->parseRule("Title"));
		$class = addslashes($this->boatclass);
		$engine = addslashes($this->regexWeb->parseRule("Engine"));
		$hull = addslashes($this->regexWeb->parseRule("Hull"));
		$year = addslashes($this->regexWeb->parseRule("Year"));
		$make = addslashes($this->regexWeb->parseRule("Make"));
		$length = addslashes($this->regexWeb->parseRule("Length"));
		$fuel = addslashes($this->regexWeb->parseRule("Fuel"));
		$zip = addslashes($this->zip);
		$phone = addslashes($this->regexWeb->parseRule("Phone"));
		$price = addslashes($this->regexWeb->parseRule("Price"));
		$imageurl = addslashes($this->regexWeb->parseRule("Photo"));

		//Insert into MySQL database...
		$sql = "INSERT INTO searchresult (`sid`, `url`, `title`, `class`, `engine`, `hull`, `year`, `make`, `length`, `fuel`, `zip`, `phone`, `price`, `imageurl` ) " .
		"VALUES ( '$sid',  '$itemUrl',  '$title',  '$class',  '$engine',  '$hull', '$year',  '$make',  '$length',  '$fuel',  '$zip',  '$phone', '$price','$imageurl');";
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
			$url = "http://www.boats.com" . $next;
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







