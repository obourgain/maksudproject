<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Simple Webpage</title>

<link rel="stylesheet" type="text/css" href="style.css" />
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
	if($_GET["s"]=="y")
	{
		echo "<p>URL addded successfully.</p>";
	}
    elseif($_GET["s"]=="n")
    {
        echo "<p>URL is Empty.</p>";
    }
    elseif($_GET["s"]=="f")
    {
        echo "<p>There is a problem with url.</p>";
    }
?>  
  
  
    <form id="myform" method="GET" class="cssform" action="results.php">
      <p>
        <label for="url">Url</label>
        <input type="text" id="url" name="url" value="" />
      </p>
      <p>
        <label>Option:</label>
        <input type="checkbox" name="opt1" />Check1<br />
        <input type="checkbox" name="opt2" class="threepxfix" />Check2 <br />
        <input type="checkbox" name="opt2" class="threepxfix" />Check3 <br />
        <input type="checkbox" name="opt3" class="threepxfix" />Check4 <br />
        <input type="checkbox" name="opt4" class="threepxfix" />Check5 <br />
      </p>
      <p>
        <label for="match">Match:</label>
        <input type="radio" name="match" value="all" />All
        <input type="radio" name="match" value="any" checked/>Any
        <br />
      </p>
      <div style="margin-left: 105px;">
        <input type="submit" name="submit" value="Search" />
        <input type="submit" name="submit" value="Submit" />
      </div>
    </form>
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
