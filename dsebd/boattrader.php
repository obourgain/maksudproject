<?	session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Boattrader Search Logs...</title>
</head>

<body>
<?
require_once ("crawler/crawl.boattrader.class.php");

$url = $_GET["url"];
$mode = $_GET["mode"];
$force = $_GET["force"];
if ($mode != "normal" && $mode != "extended")
	$mode = "normal";

if ($url != null && $url != "") {
	echo "<h2>Beginning Fetch operation:</h2>";
	echo "<h2>Logs:</h2>";

	$crawler = new CrawlBoattrader();
	$crawler->processCrawl("boattrader", $mode, $url);
}
elseif ($_GET["resume"] != null) {
	$crawler = new CrawlBoattrader();
	$crawler->updateDatabaseStatus($_GET["resume"]);
	$crawler->resumeCrawl($_GET["resume"], $mode);
} else {
	echo "<b><em>Nothing to do.</em></b>";
}
?>
</body>
</html>