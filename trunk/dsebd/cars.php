<?	session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Cars Search Logs...</title>
</head>

<body>
<?
require_once ("crawler/crawl.cars.class.php");

$mode = $_POST["mode"];

if ($mode != "normal" && $mode != "extended")
	$mode = "normal";

if (isset ($_GET["resume"])) {
	$crawler = new CrawlCars();
	$crawler->updateDatabaseStatus($_GET["resume"]);
	$crawler->resumeCrawl($_GET["resume"], $mode);
} else {

	$criteria = "criteria=K-" . preg_replace('/ /', '%20', $_POST["keywords"]);

	if (isset ($_POST["keyword_modifier"]) && $_POST["keyword_modifier"] != "")
		$criteria .= "|E-" . $_POST["keyword_modifier"];
	if (isset ($_POST["mindate"]) && $_POST["mindate"] != "")
		$criteria .= "|H-" . $_POST["mindate"];
	$criteria .= "|N-N";
	if (isset ($_POST["radius"]) && $_POST["radius"] != "")
		$criteria .= "|R-" . $_POST["radius"];

	if (isset ($_POST["mkid"]) && $_POST["mkid"] != "")
		$criteria .= "|M-_" . $_POST["mkid"] . "_";

	if (isset ($_POST["mdid"]) && $_POST["mdid"] != "")
		$criteria .= "|D-_" . $_POST["mdid"] . "_";
	if (isset ($_POST["minmiles"]) && $_POST["minmiles"] != "")
		$criteria .= "|F-" . $_POST["minmiles"];
	if (isset ($_POST["maxmiles"]) && $_POST["maxmiles"] != "")
		$criteria .= "|G-" . $_POST["maxmiles"];
	if (isset ($_POST["minp"]) && $_POST["minp"] != "")
		$criteria .= "|A-" . $_POST["minp"];
	if (isset ($_POST["maxp"]) && $_POST["maxp"] != "")
		$criteria .= "|B-" . $_POST["maxp"];
	if (isset ($_POST["year"]) && $_POST["year"] != "")
		$criteria .= "|Y-_" . $_POST["year"] . "_";
	if (isset ($_POST["zipcode"]) && $_POST["zipcode"] != "")
		$criteria .= "|Z-" . $_POST["zipcode"];

	$criteria .= "|I-1,7|X-popular|P-PRICE%20descending|Q-descending";
	if (isset ($_POST["vehicleType"]) && $_POST["vehicleType"] != "")
		$criteria .= "|S-_" . $_POST["vehicletype"] . "_";
	$criteria .= "&numResultsPerPage=" . $_POST["numResultsPerPage"];

	if (!isset ($_POST["searchType"]))
		$_POST["searchType"] = "24";

	$url = "http://www.cars.com/go/search/search_results.jsp?" . $criteria . "&searchType=" . $_POST["searchType"];

	echo "<h2>Beginning Fetch operation:</h2>";
	echo "<h2>Logs:</h2>";

	$crawler = new CrawlCars();
	$crawler->processCrawl("cars", $mode, $url);
}
?>
</body>
</html>