<?php
require_once ("mysqldb.php"); 

$db = new MySQLDB();

$cLat = doubleval($_GET["lat"]);
$cLong = doubleval($_GET["lng"]);
	
$latmin = $cLat - 1;
$latmax = $cLat + 1;

$longmin = $cLong - 1;
$longmax = $cLong + 1;


$sql = "SELECT * from `geodatatable` where (`latitude` BETWEEN $latmin AND $latmax) AND (`longitude` BETWEEN $longmin AND $longmax);";

$result = $db->query($sql);
while ($row = mysql_fetch_array($result)) { 
	
	echo '<a onmouseover="centerMap('.$row['ID'].','.$row['latitude'].','.$row['longitude'].');return false;" href="#">'.$row['name'].'</a><br/>';
	echo $row['content'];
	
	echo '<br/><br/>';
}
?>
