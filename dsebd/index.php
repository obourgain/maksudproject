<? session_start(); ?>
<!--Force IE6 into quirks mode with this comment tag-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="css/table.css" rel="stylesheet" type="text/css">
<title>PHP Website Spider</title>
<style type="text/css">
body {
	margin: 0;
	padding: 0;
	border: 0;
	overflow: hidden;
	height: 100%;
	max-height: 100%;
}
#framecontent {
	position: absolute;
	top: 0;
	bottom: 0;
	left: 0;
	width: 200px; /*Width of frame div*/
	height: 100%;
	overflow: hidden; /*Disable scrollbars. Set to "scroll" to enable*/
	background: #FCF;
	color: #309;
}
#maincontent {
	position: fixed;
	top: 0;
	left: 200px; /*Set left value to WidthOfFrameDiv*/
	right: 0;
	bottom: 0;
	overflow: auto;
	background: #fff;
}
.innertube {
	margin: 15px; /*Margins for inner DIV inside each DIV (to provide padding)*/
}
* html body { /*IE6 hack*/
	padding: 0 0 0 200px; /*Set value to (0 0 0 WidthOfFrameDiv)*/
}
* html #maincontent { /*IE6 hack*/
	height: 100%;
	width: 100%;
}
</style>
</head>
<body>
<div id="framecontent">
  <div class="innertube">
    <h1><a href="index.php">Home</a></h1>
    <h1>Search</h1>
    <h3><a href="searchboattrader.php">boattrader.com</a></h3>
    <h3><a href="searchcars.php">cars.com</a></h3>
    <h3><a href="searchboats.php">boats.com</a></h3>
    <h3><a href="searchautotrader.php">autotrader.com</a></h3>
    <br />
    <h1>Statistics</h1>
    <h3><a href="index.php?stat=boattrader">boattrader.com</a></h3>
    <h3><a href="index.php?stat=cars">cars.com</a></h3>
    <h3><a href="index.php?stat=boats">boats.com</a></h3>
    <h3><a href="index.php?stat=autotrader">autotrader.com</a></h3>
  </div>
</div>
<div id="maincontent">
  <div class="innertube">
    <h1>Welcome to PHP Website Spider</h1>
    <?
require_once (dirname(__FILE__) . "/util/maxpaging.class.php");
require_once (dirname(__FILE__) . "/db/database.class.php");
require_once (dirname(__FILE__) . "/crawler/crawl.boattrader.class.php");
//	require_once ();
$web = $_GET["stat"];
$database = new MySQLDB();

function printStat($web) {
	global $database;

	echo "<a href='index.php?stat=$web&opt=result'>Browse All Search Data</a>";
	echo "<br/> <a href='util/export.php?site=$web&action=export'>Export All to CSV</a>";

	$result = $database->query("SELECT sid, url, mode, status FROM searches WHERE site='$web'");

	$header = array ();
	while ($raw = mysql_fetch_field($result))
		$header[] = $raw->name;
	$header[2] = "action";
	unset ($header[3]);

	$data = array ();
	while ($raw = mysql_fetch_array($result))
		$data[] = $raw;

	for ($i = 0; $i < count($data); $i++) {
		$tsid = $data[$i][0];
		$tmode = $data[$i][2];
		$tstat = $data[$i][3];
		$data[$i][0] = "<a href='index.php?stat=$web&opt=result&sid=" . $tsid . "'>" . $tsid . "</a>";
		$data[$i][2] = "<a href='index.php?stat=$web&opt=delete&sid=" . $tsid . "'>Delete</a>";
		$data[$i][2] .= "<br/><a href='util/export.php?site=$web&action=export&sid=" . $tsid . "'>CSV</a>";
		if ($tstat == "run")
			$data[$i][2] .= "<br/><a href='index.php?stat=$web&opt=stop&sid=" . $tsid . "'>Stop</a>";
		$data[$i][2] .= "<br/><a href='$web.php?resume=" . $tsid . "&mode=$tmode'>Resume</a>";
		unset ($data[$i][3]);
	}
	$caption = "Searches";
	include ("table.inc");

	$result = $database->query("SELECT sid, url FROM pendingsearch");
	$header = array ();
	while ($raw = mysql_fetch_field($result))
		$header[] = $raw->name;
	$header[] = "action";

	$data = array ();
	while ($raw = mysql_fetch_array($result))
		$data[] = $raw;

	for ($i = 0; $i < count($data); $i++) {
		$tsid = $data[$i][0];
		$data[$i][0] = "<a href='index.php?stat=$web&opt=queue&sid=" . $tsid . "'>" . $tsid . "</a>";
		$data[$i][] = "<a href='index.php?stat=$web&opt=pending&sid=" . $tsid . "'>Delete</a>";
	}
	echo "<br/><a href='index.php?stat=$web&opt=clean'>ClenupAll Pending Jobs</a>";
	echo "<br/><a href='index.php?stat=$web&opt=pending'>Delete All Pending Jobs</a>";
	$caption = "Pending Searches";
	include ("table.inc");
}

function printDBGrid($query, $pagename, $limit = 10, $navlimit = 10, $sortmode = "ASC") {
	$Obj = new MaxPaging($query, $pagename, $limit, $navlimit, $sortmode);
	$Obj->setColumnName($_GET['column_name']);
	$Obj->setSortMode($_GET['sort']);
	$Obj->setStart($_GET['start']);
	$Obj->printGrid();
}

switch ($web) {
	case "boattrader" :
		switch ($_GET['opt']) {
			case "result" : //Show Results
				if (isset ($_GET['sid'])) {
					printDBGrid("SELECT `sid`, `url`, `class`, `category`, `year`, `make`, `model`, `length`, `fuel`, `phone`, `zip`, `price`, `imageurl` FROM searchresult WHERE sid='" . $_GET['sid'] . "'", "index.php?stat=$web&opt=result&sid=" . $_GET['sid'], 20, 20, "ASC");
				} else {
					printDBGrid("SELECT `sid`, `url`, `class`, `category`, `year`, `make`, `model`, `length`, `fuel`, `phone`, `zip`, `price`, `imageurl` FROM searchresult WHERE sid IN (SELECT sid FROM searches WHERE site='$web')", "index.php?stat=$web&opt=result", 20, 20, "ASC");
				}
				break;
			case "delete" : //Delete result
				if (isset ($_GET['sid'])) {
					$database->query("DELETE FROM searchresult WHERE sid='" . $_GET['sid'] . "'");
					$database->query("DELETE FROM pendingsearch WHERE sid='" . $_GET['sid'] . "'");
					$database->query("DELETE FROM searches WHERE sid='" . $_GET['sid'] . "'");
					echo "<p>One Search deleted!</p>";
				} else {
					$database->query("DELETE FROM searchresult WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					$database->query("DELETE FROM pendingsearch WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					$database->query("DELETE FROM searches WHERE site='$web'");
					echo "<p>All Searches deleted!</p>";
				}
				printStat($web);
				break;
			case "pending" : //delete pending
				if (isset ($_GET['sid'])) {
					$database->query("DELETE FROM pendingsearch WHERE sid='" . $_GET["sid"] . "'");
					echo "<p>One pending search deleted!</p>";
				} else {
					$database->query("DELETE FROM pendingsearch WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					echo "<p>All pending search deleted!</p>";
				}
				printStat($web);
				break;
			case "clean" : //cleanup
				$crBt = new CrawlBoattrader();
				$crBt->cleanup();
				echo "<p>Cleanup Performed!</p>";
				printStat($web);
				break;
			case "stop" : //Stop
				if (isset ($_GET['sid'])) {
					$database->query("UPDATE searches SET status='stop' WHERE sid='" . $_GET["sid"] . "'");
					echo "<p>One search set to stop!</p>";
				}
				printStat($web);
				break;
			case "queue" :
				if (isset ($_GET['sid'])) {
					printDBGrid("SELECT * FROM pendingqueue WHERE sid='" . $_GET['sid'] . "'", "index.php?stat=$web&opt=queue&sid=" . $_GET['sid'], 10, 20, "ASC");
				} else {
					printDBGrid("SELECT * FROM pendingqueue", "index.php?stat=$web&opt=queue", 10, 20, "ASC");
				}
				break;
			default :
				printStat($web);
				break;
		}
		break;
	case "cars" :
		switch ($_GET['opt']) {
			case "result" : //Show Results
				if (isset ($_GET['sid'])) {
					printDBGrid("SELECT `sid`, `url`, `mileage`, `body`, `interiorcolor`, `exteriorcolor`, `stock`, `engine`, `transmission`, `doors`, `zip`, `phone`, `wheelbase`, `price`, `imageurl` FROM searchresult WHERE sid='" . $_GET['sid'] . "'", "index.php?stat=$web&opt=result&sid=" . $_GET['sid'], 20, 20, "ASC");
				} else {
					printDBGrid("SELECT `sid`, `url`, `class`, `category`, `year`, `make`, `model`, `length`, `fuel`, `phone`, `zip`, `price`, `imageurl` FROM searchresult WHERE sid IN (SELECT sid FROM searches WHERE site='$web')", "index.php?stat=$web&opt=result", 20, 20, "ASC");
				}
				break;
			case "delete" : //Delete result
				if (isset ($_GET['sid'])) {
					$database->query("DELETE FROM searchresult WHERE sid='" . $_GET['sid'] . "'");
					$database->query("DELETE FROM pendingsearch WHERE sid='" . $_GET['sid'] . "'");
					$database->query("DELETE FROM searches WHERE sid='" . $_GET['sid'] . "'");
					echo "<p>One Search deleted!</p>";
				} else {
					$database->query("DELETE FROM searchresult WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					$database->query("DELETE FROM pendingsearch WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					$database->query("DELETE FROM searches WHERE site='$web'");
					echo "<p>All Searches deleted!</p>";
				}
				printStat($web);
				break;
			case "pending" : //delete pending
				if (isset ($_GET['sid'])) {
					$database->query("DELETE FROM pendingsearch WHERE sid='" . $_GET["sid"] . "'");
					echo "<p>One pending search deleted!</p>";
				} else {
					$database->query("DELETE FROM pendingsearch WHERE sid IN (SELECT sid FROM searches WHERE site='$web')");
					echo "<p>All pending search deleted!</p>";
				}
				printStat($web);
				break;
			case "clean" : //cleanup
				$crBt = new CrawlBoattrader();
				$crBt->cleanup();
				echo "<p>Cleanup Performed!</p>";
				printStat($web);
				break;
			case "stop" : //Stop
				if (isset ($_GET['sid'])) {
					$database->query("UPDATE searches SET status='stop' WHERE sid='" . $_GET["sid"] . "'");
					echo "<p>One search set to stop!</p>";
				}
				printStat($web);
				break;
			case "queue" :
				if (isset ($_GET['sid'])) {
					printDBGrid("SELECT * FROM pendingqueue WHERE sid='" . $_GET['sid'] . "'", "index.php?stat=$web&opt=queue&sid=" . $_GET['sid'], 10, 20, "ASC");
				} else {
					printDBGrid("SELECT * FROM pendingqueue", "index.php?stat=$web&opt=queue", 10, 20, "ASC");
				}
				break;
			default :
				printStat($web);
				break;
		}
		break;
	case "autotrader" :
		break;
	case "boats" :
		break;
}
?>
  </div>
</div>
</body>
</html>