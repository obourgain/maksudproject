<?php
/*
 * Created on Nov 26, 2008
 *
 * To change the template for this generated file go to
 * Window - Preferences - PHPeclipse - PHP - Code Templates
 */
require_once (dirname(__FILE__) . "/util/webutility.class.php");


$html = WebUtility::getHttpContent("www.google.com");

echo $html;


?>
