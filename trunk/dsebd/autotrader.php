<?	session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Autotrader.com Search Logs...</title>
</head>

<body>
<?
require_once ("crawler/crawl.autotrader.class.php");

if (isset($_GET["resume"])) {
	$crawler = new CrawlAutotrader();
	$crawler->updateDatabaseStatus($_GET["resume"]);
	$crawler->resumeCrawl($_GET["resume"], $mode);
} else {

    $mode = $_POST["mode"];
    if ($mode != "normal" && $mode != "extended")
        $mode = "normal";

    $url = $_POST["url"];

    echo "<h2>Beginning Fetch operation:</h2>";
    echo "<h2>Logs:</h2>";
    $crawler = new CrawlAutotrader();
    $crawler->processCrawl("autotrader", $mode, $url);
}
?>
</body>
</html>