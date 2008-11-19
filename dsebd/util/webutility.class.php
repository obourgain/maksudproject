<?php
require_once ("regexwebcrawler.class.php");

class WebUtility {
	public static function getHttpContent($url) {
		preg_match("~([a-z]*://)?([^:^/]*)(:([0-9]{1,5}))?(/.*)?~i", $url, $matches);

		$protocol = $matches[1];
		$server = $matches[2];
		$port = 80;
		$path = $matches[5] == "" ? "/" : $matches[5];
		// Timeout in seconds
		$timeout = 30;

		set_time_limit(35); //Allow Few Extra Seconds
		try {
			$fp = fsockopen($server, $port, $errno, $errstr, $timeout);

			if ($fp) {
				fwrite($fp, "GET $path HTTP/1.0\r\n");
				fwrite($fp, "Host: $server\r\n");
				fwrite($fp, "Connection: Close\r\n\r\n");

				stream_set_blocking($fp, TRUE);
				stream_set_timeout($fp, $timeout);

				set_time_limit(35); //Allow Few Seconds
				$info = stream_get_meta_data($fp);
				$line = fgets($fp, 1000);
				$status = substr($line, 9, 3);
				while (trim($line = fgets($fp, 1000)) != "") {
					if ($status == "401" AND strpos($line, "WWW-Authenticate: Basic realm=\"") === 0) {
						fclose($fp);
						return FALSE;
					}
				}

				$data = "";

				while ((!feof($fp)) && (!$info['timed_out'])) {
					set_time_limit(35); //Allow Few Extra Seconds
					$data .= fgets($fp, 4096);
					$info = stream_get_meta_data($fp);
					ob_flush;
					flush();
				}

				if ($info['timed_out']) {
					echo "Connection Timed Out!";
				} else {
					//echo $data;
				}
				return $data;
			}
		} catch (Exception $e) {
			echo $e;
		}
	}
}
/**
 * Usage:
 *
 * $data = WebUtility :: getHttpContent("http://www.dsebd.org/displayCompany.php?name=KEYACOSMET");
 * $regWeb = new RegexWebCrawler($data);
 * $regWeb->addRegexRule("Price", "/KEYACOSMET&nbsp;([0-9\.]+?)&nbsp;/", "Price: = $1 Match: = $0");
 * echo $regWeb->parseRule("Price"); 
 */
?>

