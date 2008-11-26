<?
/*
define("DB_SERVER", "72.167.233.76");
define("DB_USER", "mycampusride1");
define("DB_PASS", "Boats1234");
define("DB_NAME", "mycampusride1");
*/

define("DB_SERVER", "localhost");
define("DB_USER", "root");
define("DB_PASS", "");
define("DB_NAME", "webdb");


class MySQLDB {
	var $connection; //The MySQL database connection

	/* Class constructor */
	function MySQLDB() {
		/* Make connection to database */
		$this->connection = mysql_connect(DB_SERVER, DB_USER, DB_PASS) or die(mysql_error());
		mysql_select_db(DB_NAME, $this->connection) or die(mysql_error());
		//For unicode support
		mysql_query('SET CHARACTER SET utf8');
		mysql_query('SET SESSION collation_connection ="utf8_general_ci"');
	}

	function query($query) {
		return mysql_query($query, $this->connection);
	}
};
?>
