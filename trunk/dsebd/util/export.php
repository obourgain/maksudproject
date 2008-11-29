<?
require_once (dirname(__FILE__) . "/../db/database.class.php");

$site = $_GET['site'];
$action = $_GET['action'];

if ($action == 'export') {
	//header("Content-Disposition: attachment; filename=\"" . basename($file) . "\"");
	//header("Content-Length: " . filesize($file));
	//header("Content-Type: application/octet-stream;");
	//header("Content-type: text/x-csv");
	//header("Content-Disposition: attachment; filename=search_results.csv");

	$sid = $_GET['sid'];
	$sql = "";
	if ($site == "boattrader") {
		$sql = "SELECT `sid`, `url`, `class`, `category`, `year`, `make`, `model`, `length`, `fuel`, `phone`, `zip`, `price`, `imageurl` FROM searchresult";
	}
	elseif ($site == "cars") {
		$sql = "SELECT `sid`, `url`, `mileage`, `body`, `interiorcolor`, `exteriorcolor`, `stock`, `engine`, `transmission`, `doors`, `zip`, `phone`, `wheelbase`, `price`, `imageurl` FROM searchresult";
	}
	elseif ($site == "boats") {
		$sql = "SELECT `sid`, `url`, `title`, `class`, `engine`, `hull`, `year`, `make`, `length`, `fuel`, `zip`, `phone`, `price`, `imageurl` FROM searchresult";
	}
	elseif ($site == "autotrader") {
		$sql = "SELECT * FROM searchresult";
	} else
		$sql = "SELECT * FROM searchresult";

	if ($sid != null) {
		$sql .= " WHERE sid='$sid'";
	} else {
		$sql .= " WHERE sid IN (SELECT sid FROM searches WHERE site='$site')";
	}

	$db = new MySQLDB();
	$res = $db->query($sql);
	$fields = array ();

	while ($raw = mysql_fetch_field($res))
		$fields[] = $raw->name;

	// Put the name of all fields

	$out = '"Serial",';
	for ($i = 0; $i < count($fields); $i++) {
		$out .= '"' . $fields[$i] . '",';
	}
	$out .= "\n";

	// Add all values in the table
	$ind=1;
	while ($l = mysql_fetch_array($res)) {
		$out .= '"'. $ind . '",';
		for ($i = 0; $i < count($fields); $i++) {
			$out .= '"' . $l[$i] . '",';
		}
		$out .= "\n";
		$ind++;
	}

	$ourFileName = $sid . ".csv";
	$fp = fopen($ourFileName, 'w') or die("can't open file");
	fwrite($fp, $out);
	fclose($fp);

	// Force the download
	header("Content-Disposition: attachment; filename=\"" . basename($ourFileName) . "\"");
	header("Content-Length: " . filesize($ourFileName));
	header("Content-Type: application/octet-stream;");
	readfile($ourFileName);

	//echo "<a href='".$ourFileName."'>Download CSV File</a>";

	//echo $out;
} else {
}
?>