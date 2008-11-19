<?php
require_once ("../util/regexwebcrawler.class.php");
require_once ("../util/webutility.class.php");

class MacImdb {
	var $imdbsite;
	var $coverdir;
	var $information;
	var $page;
	var $regWeb;

	function MacImdb() {
		$this->imdbsite = "www.imdb.com";
		$this->coverdir = "./covers/";
		$this->page = "";
		$this->information = array ();

		$this->regWeb = new RegexWebCrawler("");

		$this->regWeb->addRegexRule("Titles", '%<a href="/title/(tt[0-9]+?)/">(.*?)</a>(.*?)</td>%', "$1");
		$this->regWeb->addRegexRule("TitlesExtra", '%<a href="/title/(tt[0-9]+?)/">(.*?)</a>(.*?)</td>%', "$2 $3");
		$this->regWeb->addRegexRule("Title", '/<h1>(.*?) <span>/', "$1");
		$this->regWeb->addRegexRule("Year", '%<a href=\"/Sections/Years/([0-9]+?)/\">%i', "$1");
		$this->regWeb->addRegexRule("Cover", '%<a name="poster"(.*?)><img(.*?)src="(.*?)" /></a>%', "$3");
		$this->regWeb->addRegexRule("Rating", '%<div class="meta">\n<b>([0-9.]+)/([0-9.]+)%', "$1");
		$this->regWeb->addRegexRule("Directors", '%<h5>Directors?:</h5>(.*?)<br/>\n</div>%s', "$1");
		$this->regWeb->addRegexRule("Genre", '%<a href=\"/Sections/Genres/([a-zA-Z]*?)/\">(.*?)</a>%s', "$2");
		$this->regWeb->addRegexRule("Casts", '%<td class=\"nm\">(.*?)</td>%si', "$1");
		$this->regWeb->addRegexRule("Name", '%<a href=\"/name/nm([0-9]*?)/\">(.*?)</a>%s', "$2");
	}

	function getDirectors() {
		$tmp = $this->regWeb->parseData("Directors");
		$this->regWeb->setParseData($tmp);
		return $this->regWeb->parseRuleArray("Name");
	}

	function getCast() {
		$tmp = $this->regWeb->parseData("Casts");
		$this->regWeb->setParseData($tmp);
		return $this->regWeb->parseRuleArray("Name");
	}

	function fetchImdbId($moviename) {
		$moviename = str_replace(" ", "+", $moviename);
		$url = $this->search_url($moviename);

		$httptext = WebUtility :: getHttpContent($url);

		$titles = $this->regWeb->parseRuleArray("Titles");
		$titlesExtra = $this->regWeb->parseRuleArray("TitlesExtra");

		$titlesArray = array ();
		$titlesArray[0] = $titles;
		$titlesArray[1] = $titlesExtra;

		return $titles;
	}

	function fetchInformation($imdbid) {
		$url = $this->main_url($imdbid);
		$this->page = WebUtility :: getHttpContent($url);
	}

	function main_url($imdbid) {
		return "http://" . $this->imdbsite . "/title/" . $imdbid . "/";
	}

	function search_url($movie) {
		return "http://" . $this->imdbsite . "/find?s=all&q=" . $movie . "&x=0&y=0";
	}

	function createXML($imdbid) {
		header('Content-type: text/xml');
		header("Cache-Control: no-cache");
		$this->fetchInformation($imdbid);
		$this->regWeb->setParseData($this->page);

		$this->information = array ();

		$this->information["title"][0] = $this->regWeb->parseRule('Title');
		$this->information["year"][0] = $this->regWeb->parseRule('Year');
		$this->information["cover"][0] = $this->regWeb->parseRule('Cover');
		$this->information["rating"][0] = $this->regWeb->parseRule('Rating');
		$this->information["genre"] = $this->regWeb->parseRule('Genre');

		$this->information["directors"] = $this->getDirectors();
		$this->regWeb->setParseData($this->page);
		$this->information["cast"] = $this->getCast();

		echo "<?xml version=\"1.0\"?>\n";
		echo "<movie id='" . $imdbid . "'>\n";
		$keys = array_keys($this->information);

		foreach ($keys as $key)
			for ($i = 0; $i < count($this->information[$key]); $i++)
				echo "\t<" . $key . ">" . $this->information[$key][$i] . "</" . $key . ">\n";
		echo "</movie>";
	}
}

$mi = new MacImdb();
//$mi->page = "</div>\r\n<div class=\"meta\">\r\n<b>8.6/10</b>";
$mi->createXML("tt0133093");
//$mi->fetchImdbId("the matrix");
?>
