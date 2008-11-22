<table width="800" border="0" cellspacing="1" cellpadding="1">
  <tr>
    <td><h2><? echo $caption; ?></h2></td>
  </tr>
  <tr>
    <td><table class="Result" width="800" border="1" cellspacing="1" cellpadding="1">
        <tr class="ResultHeader">
<?
		for($i=0; $i<count($header); $i++)
		{
			echo '<th scope="col">'.$header[$i].'</th>';
		}
?>
        </tr>
<?
		for($i=0; $i<count($data); $i++)
		{
			if($i%2)
				echo '<tr class="EvenRow">';
			else
				echo '<tr class="OddRow">';
			for($j=0; $j<count($header); $j++)
				echo '<td scope="col">'.$data[$i][$j].'</td>';
			echo '</tr>';
		}		
?>
      </table></td>
  </tr>
</table>