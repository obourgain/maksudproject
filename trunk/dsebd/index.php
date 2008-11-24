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
    <br />
    <h1>Statistics</h1>
    <h3><a href="index.php?stat=boattrader">boattrader.com</a></h3>
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

if ($web == "boattrader") {
	if ($_GET['r'] == "y") {
		if (isset ($_GET['sid'])) {
			$Obj = new MaxPaging("select * from searchresult where sid=" . $_GET['sid'], "index.php?stat=boattrader&r=y&sid=" . $_GET['sid'], 100, 20, "ASC");
		} else {
			$Obj = new MaxPaging("select * from searchresult", "index.php?stat=boattrader&r=y", 100, 20, "ASC");
		}
		$Obj->setColumnName($_GET['column_name']);
		$Obj->setSortMode($_GET['sort']);
		$Obj->setStart($_GET['start']);
		$Obj->printGrid();
	} else
		if ($_GET['d'] == "y") {
			if (isset ($_GET['sid'])) {
				$database->query("delete from searchresult where sid=" . $_GET['sid']);
				$database->query("delete from searches where sid=" . $_GET['sid']);
				echo "<p>One Search deleted!</p>";
			} else {
				$database->query("delete from searchresult");
				$database->query("delete from searches");
				echo "<p>All Searches deleted!</p>";
			}
		} else
			if ($_GET['p'] != null) {
				if ($_GET['p'] == "y") {
					$database->query("delete from pendingsearch where sid=" . $_GET["sid"]);
					echo "<p>One pending search deleted!</p>";
				} else
					if ($_GET['p'] == "a") {
						$database->query("delete from pendingsearch");
						echo "<p>All pending search deleted!</p>";
					} else
						if ($_GET['p'] == "c") {
							$crBt = new CrawlBoattrader();
							$crBt->cleanup();
							echo "<p>Cleanup Performed!</p>";
						} else
							if ($_GET['p'] == "s") {
								$database->query("update searches set status='stop' where sid=" . $_GET["sid"]);
								echo "<p>One search set to stop!</p>";
							} else {
								if (isset ($_GET['sid'])) {
									$Obj = new MaxPaging("select * from pendingqueue where sid=" . $_GET['sid'], "index.php?stat=boattrader&p=r&sid=" . $_GET['sid'], 100, 20, "ASC");
								} else {
									$Obj = new MaxPaging("select * from pendingqueue", "index.php?stat=boattrader&p=r", 100, 20, "ASC");
								}
								$Obj->setColumnName($_GET['column_name']);
								$Obj->setSortMode($_GET['sort']);
								$Obj->setStart($_GET['start']);
								$Obj->printGrid();
							}
			} else {
				$result = $database->query("select sid, url, mode, status from searches");

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
					$data[$i][0] = "<a href='index.php?stat=boattrader&r=y&sid=" . $tsid . "'>" . $tsid . "</a>";
					$data[$i][2] = "<a href='index.php?stat=boattrader&d=y&sid=" . $tsid . "'>Delete</a>";
					$data[$i][2] .= "<br/><a href='util/export.php?site=boattrader&action=export&sid=" . $tsid . "'>CSV</a>";
					if ($tstat == "run")
						$data[$i][2] .= "<br/><a href='index.php?stat=boattrader&p=s&sid=" . $tsid . "'>Stop</a>";
					$data[$i][2] .= "<br/><a href='boattrader.php?resume=" . $tsid . "&mode=$tmode'>Resume</a>";
					unset ($data[$i][3]);
				}

				echo "<a href='index.php?stat=boattrader&r=y'>Browse All Search Data</a>";
				echo "<br/> <a href='util/export.php?site=boattrader&action=export'>Export All to CSV</a>";
				$caption = "Searches";
				include ("table.inc");

				$result = $database->query("select sid, url from pendingsearch");

				$header = array ();
				while ($raw = mysql_fetch_field($result))
					$header[] = $raw->name;
				$header[] = "action";

				$data = array ();
				while ($raw = mysql_fetch_array($result))
					$data[] = $raw;

				for ($i = 0; $i < count($data); $i++) {
					$tsid = $data[$i][0];
					$data[$i][0] = "<a href='index.php?stat=boattrader&p=r&sid=" . $tsid . "'>" . $tsid . "</a>";
					$data[$i][] = "<a href='index.php?stat=boattrader&p=y&sid=" . $tsid . "'>Delete</a>";
				}
				echo "<br/><a href='index.php?stat=boattrader&p=c'>ClenupAll Pending Jobs</a>";
				echo "<br/><a href='index.php?stat=boattrader&p=a'>Delete All Pending Jobs</a>";
				$caption = "Pending Searches";
				include ("table.inc");
			}
}
?>
  </div>
</div>
</body>
</html>
