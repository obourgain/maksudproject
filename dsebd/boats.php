<?	session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Boats.com Search Logs...</title>
</head>

<body>
<?
require_once ("crawler/crawl.boats.class.php");

if (isset($_GET["resume"])) {
	$crawler = new CrawlBoats();
	$crawler->updateDatabaseStatus($_GET["resume"]);
	$crawler->resumeCrawl($_GET["resume"], $mode);
} else {
    
    $mode = $_POST["mode"];
    if ($mode != "normal" && $mode != "extended")
        $mode = "normal";

    $url = "http://www.boats.com/boats/search/boats_search.html?";
    $url .= "ic=".$_POST["ic"];
    $url .= "&slim=".$_POST["slim"];
    $url .= "&sm=".$_POST["sm"];
    $url .= "&bn=".$_POST["bn"];
    $url .= "&Ntk=".$_POST["Ntk"];
    $url .= "&sfm=".$_POST["sfm"];
    $url .= "&Ntt=".$_POST["Ntt"];
    $url .= "&bcint=".$_POST["bcint"];
    $url .= "&is=".$_POST["is"];
    $url .= "&bclint=".$_POST["bclint"];
    $url .= "&man=".$_POST["man"];
    $url .= "&fromYear=".$_POST["fromYear"];
    $url .= "&toYear=".$_POST["toYear"];
    $url .= "&fromLength=".$_POST["fromLength"];
    $url .= "&toLength=".$_POST["toLength"];
    $url .= "&luom=".$_POST["luom"];
    $url .= "&hmid=".$_POST["hmid"];
    $url .= "&ftid=".$_POST["ftid"];
    $url .= "&enid=".$_POST["enid"];
    $url .= "&currencyid=".$_POST["currencyid"];
    $url .= "&fromPrice=".$_POST["fromPrice"];
    $url .= "&toPrice=".$_POST["toPrice"];
    $url .= "&psdistance=".$_POST["psdistance"];
    $url .= "&pszipcode=".$_POST["pszipcode"];
    $url .= "&city=".$_POST["city"];
    $url .= "&ac=".$_POST["ac"];
    $url .= "&spid=".$_POST["spid"];
    $url .= "&cint=".$_POST["cint"];
    $url .= "&rid=".$_POST["rid"];
    $url .= "&pbsint=".$_POST["pbsint"];
    $url .= "&search=Search";

    echo "<h2>Beginning Fetch operation:</h2>";
    echo "<h2>Logs:</h2>";
    $crawler = new CrawlBoats();
    $crawler->processCrawl("boats", $mode, $url);
}
?>
</body>
</html>