<?
class MaxPaging {
	var $sql;
	var $rs;
	var $numrows;
	var $limit;

	//Column Related
	var $colhead; //Column Header
	var $colnum; //Column Number
	var $colname; //Column Name
	var $page_name; //The Page which instantiate this class

	//Extra Features
	var $column_name; //Sort Columnt Name
	var $sortmode; //ASC or DESC
	var $navlimit; //Navlimit
	var $start; //Starting Address

	var $pageen; //Paging Enable?

	//RecordModifier
	var $modifier = array ();

	function MaxPaging($query, $pagename, $limit = 10, $navlimit = 10, $sortmode = "ASC", $colhead = NULL, $pageen = true) {
		$this->sql = $query;
		$this->colhead = $colhead;
		$this->pageen = $pageen;
		$this->page_name = $pagename;
		$this->rs = mysql_query($this->sql);
		$this->numrows = mysql_num_rows($this->rs);
		$this->limit = $limit;
		$this->navlimit = $navlimit;

		$this->colname = array ();
		if ($colhead == NULL || count($colhead) == 0) {
			$this->colhead = array ();
		}
		while ($field = mysql_fetch_field($this->rs)) {
			$this->colname[] = $field->name;
			if ($colhead == NULL || count($colhead) == 0) {
				$this->colhead[] = $field->name;
			}
		}

		$this->colnum = count($this->colhead);

		//Calculating Navigation Limit...
		if ($this->navlimit * $this->limit > $this->numrows + $this->limit)
			$this->navlimit = (int) (($this->numrows + $this->limit) / $this->limit);
	}

	function setLimit($limit) {
		$this->limit = $limit;
	}

	function setColumnName($colname) {
		$this->column_name = $colname;
	}

	function setStart($start) {
		$this->start = $start;
	}

	function setNavigationLimit($navlimit) {
		$this->navlimit = $navlimit;
	}

	function setSortMode($sortmode) {
		$this->sortmode = $sortmode;
	}

	function setDataModifier($modifier) {
		$this->modifier = $modifier;
	}

	//Main GRID Function
	function printGrid() {
		if (!$this->pageen)
			$this->limit = $this->numrows;
		//Starting Address
		$eu = ($this->start - 0);
		$eu = (int) ($eu / $this->limit) * $this->limit;

		if ($eu > $this->numrows)
			die("Out Of Range");

		$this1 = $eu + $this->limit;
		$back = $eu - $this->limit;
		$next = $eu + $this->limit;

		/////////// Now let us print the table headers ////////////////
		$bgcolor = "#f1f1f1";
?>
<!-- Table Begin -->

<table border="0" cellspacing="1" cellpadding="1">
  <tr>
    <td><h1>Search Result</h1></td>
  </tr>
  <tr>
    <td>
    	<table class="Result" border="1" cellspacing="1" cellpadding="1">
<!-- Print Table Columns -->
<?


		echo '<tr class="ResultHeader">';
		$i = 0;
		for ($i = 0; $i < $this->colnum; $i++) {
			echo '<th scope="col" class="' . $this->colname[$i] . '">';
			if ($this->pageen) {
				echo "<a href='$this->page_name&column_name=" . $this->colname[$i];
				if (isset ($this->column_name) and strlen($this->column_name) > 0 and $this->column_name == $this->colname[$i]) {
					if (!isset ($this->sortmode)) {
						echo "&sort=DESC'>" . $this->colhead[$i] . "</a>";
						echo '<img border="0" src="Desc.gif" alt="Desc"></th>';
					} else {
						echo "'>" . $this->colhead[$i] . "</a>";
						echo '<img border="0" src="Asc.gif" alt="Asc"></th>';
					}
				} else
					echo "'>" . $this->colhead[$i] . "</a></th>";
			} else {
				echo $this->colhead[$i] . "</th>";
			}
		}
		echo '</tr>';
?>
<!-- Print Main Table	-->
<?


		$isOdd = true;
		$query = $this->sql;
		if ($this->pageen) {
			if (isset ($this->column_name) and strlen($this->column_name) > 0) {
				$query = $query . " order by $this->column_name";
			}
			if (isset ($this->sortmode) and $this->sortmode == 'DESC') {
				$query = $query . " DESC";
			}
			$query = $query . " limit $eu, $this->limit ";
		}
		$result = mysql_query($query);
		echo mysql_error();

		if ($result == NULL) {
			return;
		}
		//Now we will display the returned records in side the rows of the table//
		while ($noticia = mysql_fetch_array($result)) {
			if ($isOdd) {
				$isOdd = false;
				echo '<tr class="OddRow">';
			} else {
				$isOdd = true;
				echo '<tr class="EvenRow">';
			}

			foreach ($this->colname as $value) {
				echo '<td>';
				if (array_key_exists($value, $this->modifier)) {
					if (count($this->modifier[$value]) == 5) {
						echo $this->modifier[$value][0];
						echo $noticia[$this->modifier[$value][1]];
						echo $this->modifier[$value][2];
						echo $noticia[$this->modifier[$value][3]];
						echo $this->modifier[$value][4];
					} else
						echo $noticia[$value];
				} else
					echo $noticia[$value];

				echo "</td>";
			}
			echo "</tr>";
		}

		echo "</table>";
		echo "</td>";
?>
<!-- Now Print Paging Information -->
<?


		echo '<tr class="Pagination"><td>';
		if ($back >= 0) {
			echo "<a href='$this->page_name&start=$back&column_name=$this->column_name";
			if (isset ($this->sortmode))
				echo "&sort=DESC";
			echo "'><font face='Verdana' size='2'>PREV</font></a>";
		}

		$startnav = $eu - ((int) ($this->navlimit / 2)) * $this->limit;
		$endnav = $startnav + $this->navlimit * $this->limit - 1;

		if ($startnav < 0) {
			$startnav = 0;
			$endnav = $this->navlimit * $this->limit - 1;
		} else
			if ($endnav > $this->numrows) {
				$startnav = ((int) (($this->numrows - $this->navlimit * $this->limit + $this->limit) / $this->limit)) * $this->limit;
				$endnav = $this->numrows - 1;
			}
		if ($this->numrows < $this->navlimit * $this->limit) {
			$startnav = 0;
			$endnav = $this->numrows - 1;
		}
		$i = $startnav;
		$l = $startnav / $this->limit + 1;
		for ($i = $startnav; $i < $endnav -1; $i = $i + $this->limit) {
			if ($i <> $eu) {
				echo "  <a href='$this->page_name&start=$i&column_name=$this->column_name";
				if (isset ($this->sortmode))
					echo "&sort=DESC";
				echo "'>$l</a>  ";
			} else {
				echo "<strong>$l</strong>";
			} /// Current page is not displayed as link and given font color red
			$l = $l +1;
		}
		if ($this1 < $this->numrows) {
			echo "<a href='$this->page_name&start=$next&column_name=$this->column_name";
			if (isset ($this->sortmode))
				echo "&sort=DESC";
			echo "'><font face='Verdana' size='2'>NEXT</font></a>";
		}
		echo "</td></tr></table>";
	}
}
?>
