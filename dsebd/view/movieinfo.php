<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Organic Beauty</title>
<link rel="stylesheet" type="text/css" href="style.css" />

<script type="text/javascript" src="../js/jquery-1.2.6.js"></script>
<script type="text/javascript">
$(document).ready( function() {   
    $('A[rel="external"]').click( function() {
		window.open('../imdb/MacImdb.php?m='+$("#title").val()+'','Fetch Movie Information', 'menubar=no,width=430,height=360,toolbar=no,scrollbars=yes')
        return false;
    });
	/var/www/html/dse/var/www/html/dse/var/www/html/dse/var/www/html/dse/var/www/html/dse
    $('A[rel="commit"]').click( function() {
		$.post( "../imdb/insertdb.php",
				{
					id: $("#id").val(),
					title: $("#title").val(),
					year: $("#year").val(),
					rating: $("#rating").val(),
					cover: $('#cover').attr("src"),
					director: $("#director").val(),
					cast: $("#cast").val(),
					genre: $("#genre").val(),
				},
				function (xml) {
					alert(xml);
				});
        return false;
    });	
	
	$('#title').keydown(function(event) {
   		if(event.keyCode==13) {
			window.open('../imdb/MacImdb.php?m='+$("#title").val()+'','Fetch Movie Information', 'menubar=no,width=430,height=360,toolbar=no,scrollbars=yes')
        	return false;
		}
	});
});
</script>
</head>
<body>
<div id="header">
    <div id="menu_tab">
        <ul class="menu">
            <li><a href="index.html" class="nav"> home </a></li>
            <li><a href="search.php" class="nav"> search</a></li>
            <li><a href="movieinfo.php" class="nav"> movie info</a></li>
            <li><a href="signin.php" class="nav"> sign in </a></li>
            <li><a href="register.php" class="nav_selected"> register </a></li>
        </ul>
    </div>
</div>
<div id="main_container">
    <div id="main_content">
        <div id="logo"><a href="index.html"><img src="images/logo.gif" width="164" height="49" alt="" title="" border="0" /></a></div>
        <div class="center_content">
            <div class="left_content">
                <div id="basic_info" class="movie_basic" style="display:none">
                    <div class="movie_cover"><img id="cover" src="" /></div>
                    <div class="movie_title"><p id="b_title"><a href='#'></a></p></div>
                    <div class="movie_year" id="b_year"></div>
                    <div class="movie_rating" id="b_rating"></div>
                </div>
                <form>
                    <div class="movie_info_label">Title</div>
                    <input name="title" type="text" class="movie_info" id="title" value="" size="30" maxlength="255" /><br />
                    <div class="movie_info_label">Id</div>
                    <input name="id" type="text" class="movie_info" id="id" value="" size="16" maxlength="255" readonly="true"/>
                    <div class="movie_info_label">Rating</div>
                    <input name="rating" type="text" class="movie_info" id="rating" value="" size="10" maxlength="255" />
                    <div class="movie_info_label">Year</div>
                    <input name="year" type="text" class="movie_info" id="year" value="" size="10" maxlength="255"  />
                    <div class="movie_info_label">Genre</div>
                    <textarea name="genre" class="movie_info" id="genre"></textarea>
                    <div class="movie_info_label">Directors</div>
                    <textarea name="director" cols="40"  wrap="virtual" class="movie_info" id="director"></textarea>
                    <div class="movie_info_label">Cast</div>
                    <textarea name="cast" cols="40"  class="movie_info" id="cast"></textarea>
                </form>
                <a style="float:right;padding:0 20px 0 0;" id="fetch" href="#" rel="commit">Commit</a>
                <a style="float:right;padding:0 20px 0 0;" id="fetch" href="#" rel="external">Search</a>
            </div>
            <!-- end of left_content -->
            <div class="right_content">
                <h1>Reviews</h1>
                <div class="right_box">
                    <div class="box_title"><a href="#">Maksud</a> @ 10-Dec-2008</div>
                    <p class="right_box">Boaring...</p>
                </div>
                <div class="right_box">
                    <div class="box_title"><a href="#">Max</a> @ 10-Dec-2008</div>
                    <p class="right_box">Pocha...</p>
                </div>
                <div class="right_box">

				
                </div>
                <div class="right_bottom"><p>Write a comment:</p>
                	<form>	                
                    <textarea name="comment" rows="4"></textarea>
                    </form>
                    <br />
                <a href="#">Commit</a></div>
            </div>
            <!-- end of right_content -->
        </div>
        <!-- end of center_content -->
    </div>
 
    <!-- end of main_content -->
    <div id="footer">
        <div id="copyright">
            <div style="float:left; padding:3px;"><a href="#"><img src="images/footer_logo.gif" width="38" height="36" alt="" title="" border="0" /></a></div>
            <div style="float:left; padding:14px 10px 10px 10px;"> Company name.&copy; All Rights Reserved 2008 - By <a href="http://csscreme.com" style="color:#772c17;">csscreme</a></div>
        </div>
        <ul class="footer_menu">
            <li><a href="index.html" class="nav_footer"> home </a></li>
            <li><a href="products.html" class="nav_footer"> about </a></li>
            <li><a href="products.html" class="nav_footer"> sitemap </a></li>
            <li><a href="contact.html" class="nav_footer"> contact </a></li>
        </ul>
    </div>
</div>
<!-- end of main_container -->
</body>
</html>
