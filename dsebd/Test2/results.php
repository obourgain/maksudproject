<?
require_once ("mysqldb.php");

$db = new MySQLDB();

//url
$url = $_GET["url"];

//opti is 0 if null else 1
$opt1 = $_GET["opt1"] == null ? 0 : 1;
$opt2 = $_GET["opt2"] == null ? 0 : 1;
$opt3 = $_GET["opt3"] == null ? 0 : 1;
$opt4 = $_GET["opt4"] == null ? 0 : 1;
$opt5 = $_GET["opt5"] == null ? 0 : 1;

if($_GET["submit"]=="Submit")
{
    if($url!=null && $url!="")
    {
	    $url = addslashes($url);
	    $timestamp = time();
	    $sql = "INSERT INTO websearch(`url`, `opt1`, `opt2`, `opt3`, `opt4`, `opt5`, `timestamp`) VALUES ('$url', '$opt1', '$opt2', '$opt3', '$opt4', '$opt5', '$timestamp');";
	    $result = $db->query($sql);
	    $success = $result==FALSE ? "f" : "y";
    }
    else
        $success="n";
	
	header( "HTTP/1.1 301 Moved Permanently" );
   	header( "Status: 301 Moved Permanently" );
	header( "Location: index.php?s=$success" );
	exit(0); // This is Optional but suggested, to avoid any accidental output
}
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Results Page</title>

<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="stylesheet" type="text/css" href="table.css" />
</head>

<body class="thrColLiqHdr">
<div id="container">
  <div id="header">
    <h1>Header</h1>
    <!-- end #header -->
  </div>
  <div id="sidebar1">
    <h3>Sidebar1 </h3>
    <p>Here You can add banner</p>
    <p>Here You can add banner</p>
    <p>Here You can add banner</p>
    <p>Here You can add banner</p>
    <p>Here You can add banner</p>
    <!-- end #sidebar1 -->
  </div>
  <div id="sidebar2">
    <h3>Sidebar2 </h3>
    <p>Here Banner will be added. </p>
    <p>Here Banner will be added. </p>
    <p>Here Banner will be added. </p>
    <p>Here Banner will be added. </p>
    <p>Here Banner will be added.</p>
    <!-- end #sidebar2 -->
  </div>
  <div id="mainContent">
  <br/>
<?


//Show the results
if ($_GET["match"] == "all")
	$sql = "SELECT * FROM websearch WHERE url LIKE '%$url%' AND opt1='$opt1' AND opt2='$opt2' AND opt3='$opt3' AND opt4='$opt4' AND opt5='$opt5'";
else
	$sql = "SELECT * FROM websearch WHERE url LIKE '%$url%' AND ( opt1='$opt1' OR opt2='$opt2' OR opt3='$opt3' OR opt4='$opt4' OR opt5='$opt5')";

$result = $db->query($sql);
$numrows = mysql_num_rows($result);

$start = $_GET["start"] ? (int)$_GET["start"] : 0;
$limit = $_GET["limit"] ? (int)$_GET["limit"] : 10;


//$start is discrete value
$start = (int) ($start / $limit) * $limit;

if ($start > $numrows)
	die("Out of Range..");

$back = $start - $limit;
$next = $start + $limit;
?>
<table border="0" cellspacing="1" cellpadding="1">
  <tr>
    <td><h1>Search Result</h1></td>
  </tr>
  <tr>
    <td>
    	<table class="Result" border="1" cellspacing="1" cellpadding="1">
<?


$isOdd = true;
$sql = $sql . " LIMIT $start, $limit";
$result = $db->query($sql);

$index = $start +1;
//Now we will display the returned records in side the rows of the table//
while ($resultArray = mysql_fetch_array($result)) {
	if ($isOdd) {
		$isOdd = false;
		echo '<tr class="OddRow">';
	} else {
		$isOdd = true;
		echo '<tr class="EvenRow">';
	}

	echo "<td>" . $resultArray[1] . "</td>";
	echo "</tr>";
}
echo "</table></td></tr>";

echo '<tr class="Pagination"><td>';
if ($back >= 0) {
	echo "<a href='results.php&url=$url&start=$back'><font face='Verdana' size='2'>PREV</font></a>";
}

$navlimit = 10; //10 navigation links maximum
$startnav = $start - ((int) ($navlimit / 2)) * $limit;
$endnav = $startnav + $navlimit * $limit -1;

if ($startnav < 0) {
	$startnav = 0;
	$endnav = $navlimit * $limit - 1;
}
elseif ($endnav > $numrows) {
	$startnav = ((int) (($numrows - $navlimit * $limit + $limit) / $limit)) * $limit;
	$endnav = $numrows - 1;
}
if ($numrows < $navlimit * $limit) {
	$startnav = 0;
	$endnav = $numrows - 1;
}
$i = $startnav;
$l = $startnav / $limit + 1;
for ($i = $startnav; $i < $endnav -1; $i = $i + $limit) {
	if ($i <> $start) {
		echo "  <a href='results.php?url=$url&start=$i'>$l</a>  ";
	} else {
		echo "<strong>$l</strong>"; /// Current page is not displayed as link
	}
	$l = $l +1;
}
if ($next < $numrows) {
	echo "<a href='results.php?url=$url&start=$next'><font face='Verdana' size='2'>NEXT</font></a>";
}
echo "</td></tr></table>";
?>

    <!-- end #mainContent -->
  </div>
  <!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats -->
  <br class="clearfloat" />
  <div id="footer">
    <p>You can add your info here.</p>
    <!-- end #footer -->
  </div>
  <!-- end #container -->
</div>
</body>
</html>
