<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="Expires" content="Fri, Jan 01 1900 00:00:00 GMT">
<meta http-equiv="Pragma" content="no-cache">
<meta http-equiv="Cache-Control" content="no-cache">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta http-equiv="content-language" content="en">
<meta name="author" content="">
<meta http-equiv="Reply-to" content="@.com">
<meta name="generator" content="PhpED 5.0">
<meta name="description" content="">
<meta name="keywords" content="">
<meta name="creation-date" content="02/20/2007">
<meta name="revisit-after" content="15 days">
<title>Web Parser in php</title>
<link rel="stylesheet" type="text/css" href="my.css">
</head>
<body>
<?php
    require_once (dirname(__FILE__) . "/regexwebcrawler.class.php");
    echo "Echo";
    $as = "Maksudul Alam";
    $r = new RegexWebCrawler($as);
    $r->addRegexRule("1", "/.(a)./", "<$0 - $1 - >");

    echo $r->parseRule("1");
    $rrr = $r->parseRuleArray("1");

    for($i=0; $i<count($rrr); $i++)
        echo $rrr[$i];

?>
</body>
</html>
