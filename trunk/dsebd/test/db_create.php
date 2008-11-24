<?php

define("DB_SERVER", "localhost");
define("DB_USER", "root");
define("DB_PASS", "");
define("DB_NAME", "webdb");
 
$connection = mysql_connect(DB_SERVER, DB_USER, DB_PASS) or die(mysql_error());
mysql_select_db(DB_NAME, $connection) or die(mysql_error());
//For unicode support

$table_pendingqueue = "CREATE TABLE `pendingqueue` ( `aid` int(11) NOT NULL auto_increment, `sid` varchar(20) collate utf8_unicode_ci NOT NULL, `url` text collate utf8_unicode_ci NOT NULL, PRIMARY KEY (`aid`) );"; 

$table_pendingsearch = "CREATE TABLE `pendingsearch` ( `sid` varchar(20) collate utf8_unicode_ci NOT NULL, `url` text collate utf8_unicode_ci, `mode` varchar(20) collate utf8_unicode_ci default NULL, `timestamp` varchar(20) collate utf8_unicode_ci default NULL, PRIMARY KEY (`sid`) );";

$table_searches = "CREATE TABLE `searches` ( `sid` varchar(20) collate utf8_unicode_ci NOT NULL, `url` text collate utf8_unicode_ci NOT NULL, `site` varchar(255) collate utf8_unicode_ci NOT NULL, PRIMARY KEY (`sid`) );";

$table_searchresult = "CREATE TABLE
`searchresult` ( `aid` int(11) NOT NULL auto_increment, `sid` varchar(20)
collate utf8_unicode_ci NOT NULL, `url` varchar(255) collate utf8_unicode_ci
NOT NULL, `class` varchar(255) collate utf8_unicode_ci default NULL,
`category` varchar(255) collate utf8_unicode_ci default NULL, `year`
varchar(255) collate utf8_unicode_ci default NULL, `make` varchar(255)
collate utf8_unicode_ci default NULL, `model` varchar(255) collate
utf8_unicode_ci default NULL, `length` varchar(255) collate utf8_unicode_ci
default NULL, `fuel` varchar(255) collate utf8_unicode_ci default NULL,
`phone` varchar(255) collate utf8_unicode_ci default NULL, `zip`
varchar(255) collate utf8_unicode_ci default NULL, `price` varchar(255)
collate utf8_unicode_ci default NULL, `imageurl` text collate
utf8_unicode_ci, PRIMARY KEY (`aid`) ) ENGINE=MyISAM DEFAULT CHARSET=utf8
COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";

$result = mysql_query($table_pendingqueue, $connection);
if($result)
	echo "Success\n";
else
	echo "Fail\n";
mysql_query($table_pendingsearch, $connection);
mysql_query($table_searches, $connection);
mysql_query($table_searchresult, $connection);

?>