<?php
//Author: Maksud, Maksud's Customized imdb fetcher
require_once ("MacImdb.class.php");

$movie = $_GET["m"];
$id = $_GET["id"];
  
if(isset($movie))
{
	$mi = new MacImdb();
	$titles = $mi->fetchImdbId($movie);
?>
<script type="text/javascript" src="../js/jquery-1.2.6.js"></script>
<script type="text/javascript">
$(document).ready( function() {   
    $('A[rel="external"]').click( function() {
		$.get( "MacImdb.php",
			{ id: $("input:radio[@name=movie]:checked").val() },	
			function (xml) {
				
				//Ajax is Cool!
				$('#title', window.opener.document).val($(xml).find('title').text());
				$('#rating', window.opener.document).val($(xml).find('rating').text());
				$('#year', window.opener.document).val($(xml).find('year').text());
				$('#id', window.opener.document).val($(xml).find('movie').attr("id"));
				$('#cover', window.opener.document).attr("src",$(xml).find('cover').text());
				$('#basic_info', window.opener.document).attr("style","display:block");
				
				$('#b_year', window.opener.document).html($(xml).find('year').text());
				$('#b_rating', window.opener.document).html($(xml).find('rating').text());
				$('#b_title', window.opener.document).html("<a href='http://www.imdb.com/title/"+$(xml).find('movie').attr("id")+"/'>"+$(xml).find('title').text()+"</a>");								
				
				str="";
				$(xml).find('director').each(function(){
					str=str+"\n"+$(this).text();	
				});
				str = str.substring(1, str.length);
				$('#director', window.opener.document).val(str);

				str="";
				$(xml).find('genre').each(function(){
					str=str+"\n"+$(this).text();
				});
				str = str.substring(1, str.length); 
				$('#genre', window.opener.document).val(str);
								
				str="";
				$(xml).find('cast').each(function(){
					str=str+"\n"+$(this).text();
				});
				str = str.substring(1, str.length);
				$('#cast', window.opener.document).val(str);	
				
				window.close();			
			}
		);
        return false;
    });
});
</script>

<form action="" method="get">
<?
	if(count($titles)>0)
		echo "<a rel='external' href='#'>Fetch and Set Parameters</a><br/>";
	else
		echo "<b>Nothing Found</b>";
	for($i=0; $i<count($titles); $i++) {
		echo "<input id='m_$i' type='radio' name='movie' value='".$titles[$i][0]."'";
		if($i==0) echo " checked";
		echo ">".$titles[$i][1]."  ".$titles[$i][2]."<br/>";
	}
?>
</form>

<?
} else if (isset($id)) {
	$mi = new MacImdb();
	$titles = $mi->createXML($id	);
}
?>