<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Dynamic Drive: CSS Liquid Layout #3.1- (Fixed-Fluid-Fixed)</title>
<style type="text/css">
body {
	margin:0;
	padding:0;
	line-height: 1.5em;
}
b {
	font-size: 110%;
}
em {
	color: red;
}
#topsection {
	background: #EAEAEA;
	height: 90px; /*Height of top section*/
}
#topsection h1 {
	margin: 0;
	padding-top: 15px;
}
#contentwrapper {
	float: left;
	width: 100%;
}
#contentcolumn {
	margin: 0 200px 0 230px; /*Margins for content column. Should be "0 RightColumnWidth 0 LeftColumnWidth*/
}
#leftcolumn {
	float: left;
	width: 230px; /*Width of left column*/
	margin-left: -100%;
	background: #C8FC98;
}
#rightcolumn {
	float: left;
	width: 200px; /*Width of right column*/
	margin-left: -200px; /*Set left marginto -(RightColumnWidth)*/
	background: #FDE95E;
}
#footer {
	clear: left;
	width: 100%;
	background: black;
	color: #FFF;
	text-align: center;
	padding: 4px 0;
}
#footer a {
	color: #FFFF80;
}
.innertube {
	margin: 10px; /*Margins for inner DIV inside each column (to provide padding)*/
	margin-top: 0;
}
</style>

</head>
<body>
<div id="maincontainer">
  <div id="topsection">
    <div class="innertube">
      <h1>The Top Banner...</h1>
    </div>
  </div>
  <div id="contentwrapper">
    <div id="contentcolumn">
      <div class="innertube"><b>Content Column: <em>Fluid</em></b>
        This is the content column
      </div>
    </div>
  </div>
  <div id="leftcolumn">
    <div class="innertube"><b>Left Column: <em>230px</em></b> For Some advert...</div>
  </div>
  <div id="rightcolumn">
    <div class="innertube"><b>Right Column: <em>200px</em></b> For Some advert...</div>
  </div>
  <div id="footer"><a href="http://www.dynamicdrive.com/style/">Dynamic Drive CSS Library</a></div>
</div>
</body>
</html>
