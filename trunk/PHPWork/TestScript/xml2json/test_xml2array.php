<?php 
$testXmlFile = "test1.xml";
include 'xml2ary.php';
$xml=xml2ary(file_get_contents('test1.xml'));
echo json_encode($xml);
?>