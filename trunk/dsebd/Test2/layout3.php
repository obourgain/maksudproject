<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<style type="text/css">
<!--
body {
	font: 100% Verdana, Arial, Helvetica, sans-serif;
	background: #666666;
	margin: 0; /* it's good practice to zero the margin and padding of the body element to account for differing browser defaults */
	padding: 0;
	text-align: center; /* this centers the container in IE 5* browsers. The text is then set to the left aligned default in the #container selector */
	color: #000000;
}
.thrColLiqHdr #container {
	width: 80%;  /* this will create a container 80% of the browser width */
	background: #FFFFFF;
	margin: 0 auto; /* the auto margins (in conjunction with a width) center the page */
	border: 1px solid #000000;
	text-align: left; /* this overrides the text-align: center on the body element. */
}
.thrColLiqHdr #header {
	background: #DDDDDD;
	padding: 0 10px;  /* this padding matches the left alignment of the elements in the divs that appear beneath it. If an image is used in the #header instead of text, you may want to remove the padding. */
}
.thrColLiqHdr #header h1 {
	margin: 0; /* zeroing the margin of the last element in the #header div will avoid margin collapse - an unexplainable space between divs. If the div has a border around it, this is not necessary as that also avoids the margin collapse */
	padding: 10px 0; /* using padding instead of margin will allow you to keep the element away from the edges of the div */
}
/* Tips for sidebars:
1. Since we are working in percentages, it's best not to use side padding on the sidebars. It will be added to the width for standards compliant browsers creating an unknown actual width. 
2. Space between the side of the div and the elements within it can be created by placing a left and right margin on those elements as seen in the ".thrColLiqHdr #sidebar1 p" rule.
3. Since Explorer calculates widths after the parent element is rendered, you may occasionally run into unexplained bugs with percentage-based columns. If you need more predictable results, you may choose to change to pixel sized columns.
*/
.thrColLiqHdr #sidebar1 {
	float: left; /* this element must precede in the source order any element you would like it be positioned next to */
	width: 22%; /* since this element is floated, a width must be given */
	background: #EBEBEB; /* the background color will be displayed for the length of the content in the column, but no further */
	padding: 15px 0; /* top and bottom padding create visual space within this div  */
}
.thrColLiqHdr #sidebar2 {
	float: right; /* this element must precede in the source order any element you would like it be positioned next to */
	width: 23%; /* since this element is floated, a width must be given */
	background: #EBEBEB; /* the background color will be displayed for the length of the content in the column, but no further */
	padding: 15px 0; /* top and bottom padding create visual space within this div */
}
.thrColLiqHdr #sidebar1 p, .thrColLiqHdr #sidebar1 h3, .thrColLiqHdr #sidebar2 p, .thrColLiqHdr #sidebar2 h3 {
	margin-left: 10px; /* the left and right margin should be given to every element that will be placed in the side columns */
	margin-right: 10px;
}
/* Tips for mainContent:
1. the space between the mainContent and sidebars is created with the left and right margins on the mainContent div.
2. to avoid float drop at a supported minimum 800 x 600 resolution, elements within the mainContent div should be 300px or smaller (this includes images).
3. in the Internet Explorer Conditional Comment below, the zoom property is used to give the mainContent "hasLayout." This avoids several IE-specific bugs.
*/
.thrColLiqHdr #mainContent {
	margin: 0 24% 0 23.5%; /* the right and left margins on this div element creates the two outer columns on the sides of the page. No matter how much content the sidebar divs contain, the column space will remain. You can remove this margin if you want the #mainContent div's text to fill the sidebar spaces when the content in each sidebar ends. */
}
.thrColLiqHdr #footer {
	padding: 0 10px; /* this padding matches the left alignment of the elements in the divs that appear above it. */
	background:#DDDDDD;
}
.thrColLiqHdr #footer p {
	margin: 0; /* zeroing the margins of the first element in the footer will avoid the possibility of margin collapse - a space between divs */
	padding: 10px 0; /* padding on this element will create space, just as the the margin would have, without the margin collapse issue */
}
/* Miscellaneous classes for reuse */
.fltrt { /* this class can be used to float an element right in your page. The floated element must precede the element it should be next to on the page. */
	float: right;
	margin-left: 8px;
}
.fltlft { /* this class can be used to float an element left in your page The floated element must precede the element it should be next to on the page. */
	float: left;
	margin-right: 8px;
}
.clearfloat { /* this class should be placed on a div or break element and should be the final element before the close of a container that should fully contain its child floats */
	clear:both;
	height:0;
	font-size: 1px;
	line-height: 0px;
}
-->
</style>
<!--[if IE]>
<style type="text/css"> 
/* place css fixes for all versions of IE in this conditional comment */
.thrColLiqHdr #sidebar2, .thrColLiqHdr #sidebar1 { padding-top: 30px; }
.thrColLiqHdr #mainContent { zoom: 1; padding-top: 15px; }
/* the above proprietary zoom property gives IE the hasLayout it needs to avoid several bugs */
</style>
<![endif]-->
</head>
<style type="text/css">
/*Credits: Dynamic Drive CSS Library */
/*URL: http://www.dynamicdrive.com/style/ */

.cssform p {
	width: 300px;
	clear: inherit;
	margin: 0;
	padding: 5px 0 8px 0;
	padding-left: 105px; /*width of left column containing the label elements*/
	border-top: 1px dashed gray;
	height: 1%;
}
.cssform label {
	font-weight: bold;
	float: left;
	margin-left: -100px; /*width of left column*/
	width: 50px; /*width of labels. Should be smaller than left column (155px) to create some right margin*/
}
.cssform input[type="text"] { /*width of text boxes. IE6 does not understand this attribute*/
	width: 200px;
}
.cssform textarea {
	width: 150px;
	height: 150px;
}
/*.threepxfix class below:
Targets IE6- ONLY. Adds 3 pixel indent for multi-line form contents.
to account for 3 pixel bug: http://www.positioniseverything.net/explorer/threepxtest.html
*/

* html .threepxfix {
	margin-left: 3px;
}
</style>
<body class="thrColLiqHdr">
<div id="container">
  <div id="header">
    <h1>Header</h1>
    <!-- end #header -->
  </div>
  <div id="sidebar1">
    <h3>Sidebar1 </h3>
    <p>The background color on this div will only show for the length of the content. If you'd like a dividing line instead, place a border on the left side of the #mainContent div if the #mainContent div will always contain more content than the #sidebar1 div. </p>
    <p>Donec eu mi sed turpis feugiat feugiat. Integer turpis arcu, pellentesque  eget, cursus et, fermentum ut, sapien. </p>
    <!-- end #sidebar1 -->
  </div>
  <div id="sidebar2">
    <h3>Sidebar2 </h3>
    <p>The background color on this div will only show for the length of the content. If you'd like a dividing line instead, place a border on the right side of the #mainContent div if the #mainContent div will always contain more content than the #sidebar2 div. </p>
    <p>Donec eu mi sed turpis feugiat feugiat. Integer turpis arcu, pellentesque  eget, cursus et, fermentum ut, sapien. </p>
    <!-- end #sidebar2 -->
  </div>
  <div id="mainContent">
    <form id="myform" class="cssform" action="">
      <p>
        <label for="user">Name</label>
        <input type="text" id="user" value="" />
      </p>
      <p>
        <label for="comments">Option:</label>
        <input type="checkbox" name="hobby" />
        Check1<br />
        <input type="checkbox" name="hobby" class="threepxfix" />
        Check2 <br />
        <input type="checkbox" name="hobby" class="threepxfix" />
        Check3 <br />
        <input type="checkbox" name="hobby" class="threepxfix" />
        Check4 <br />
        <input type="checkbox" name="hobby" class="threepxfix" />
        Check5 <br />
      </p>
      <p>
        <label for="comments">Match:</label>
        <input type="radio" name="sex" />All
        <input type="radio" name="sex" />Any
        <br />
      </p>
      <div style="margin-left: 100px;">
        <input type="submit" value="Search" />
      </div>
    </form>
    <!-- end #mainContent -->
  </div>
  <!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats -->
  <br class="clearfloat" />
  <div id="footer">
    <p>Footer</p>
    <!-- end #footer -->
  </div>
  <!-- end #container -->
</div>
</body>
</html>
