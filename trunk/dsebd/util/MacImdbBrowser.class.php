<?php
require_once ("browseremulator.class.php");

class MacImdbBrowser extends BrowserEmulator {
	var $maxsize = 100000; //100 KB
	function MacImdbRequest($url) {
		$this->BrowserEmulator();
		$this->urltoopen = $url;
	}

	function sendRequest() {
		$this->fpopened = $this->fopen($this->urltoopen);
	}

	function getResponseBody() {
		$page = "";
		while (!feof($this->fpopened)) {
			$page .= fread($this->fpopened, 1024);
		}
		return $page;
	}

	function setURL($url) {
		$this->urltoopen = $url;
	}

	function getResponseHeader($header = false) {
		$headers = $this->getLastResponseHeaders();
		foreach ($headers as $head) {
			if (is_integer(strpos($head, $header))) {
				$hstart = strpos($head, ": ");
				$head = trim(substr($head, $hstart +2, 100));
				return $head;
			}
		}
	}
}
?>
