<?
require_once (dirname(__FILE__) . "/../db/database.class.php");

$site = $_GET['site'];
$action = $_GET['action'];

if ($site == 'boattrader' && $action == 'export') {
	header("Content-type: text/x-csv");
	header("Content-Disposition: attachment; filename=search_results.csv");
	$sid = $_GET['sid'];
	$sql = "select * from searchresult";
	if ($sid != null)
		$sql .= " where sid=" . $sid;

	$db = new MySQLDB();
	$res = $db->query($sql);
	$fields = array ();

	while ($raw = mysql_fetch_field($res))
		$fields[] = $raw->name;

	// Put the name of all fields

	for ($i = 0; $i < count($fields); $i++) {
		$out .= '"' . $fields[$i] . '",';
	}
	$out .= "\n";

	// Add all values in the table
	while ($l = mysql_fetch_array($res)) {
		for ($i = 0; $i < count($fields); $i++) {
			$out .= '"' . $l[$i] . '",';
		}
		$out .= "\n";
	}

	echo $out;
} else {
}
?>