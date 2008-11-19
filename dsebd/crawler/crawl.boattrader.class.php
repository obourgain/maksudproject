<?php
require_once (dirname(__FILE__) . "/regexwebcrawler.class.php");
require_once (dirname(__FILE__) . "/webutility.class.php");

class CrawlBoattrader
{
    var $regexWeb;

    public function CrawlBoattrader()
    {
        $this->regexWeb = new RegexWebCrawler("");

        $this->regexWeb->addRegexRule("Search", '/<div class="sBar.?"><a(\s*?)href="(.+?)"(.*?)class/', "$2");
        $this->regexWeb->addRegexRule("Next", '/<a href="([^\s]+?)" title="Next Page">/', "$1");
        $this->regexWeb->addRegexRule("Photo", '%<img src="(.+?)"(.+?)id="largePhoto"/>%', "$1");
        $this->regexWeb->addRegexRule("Class", '%<span class="label(Left|Right)">Class:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Category", '%<span class="label(Left|Right)">Category:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Year", '%<span class="label(Left|Right)">Year:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Make", '%<span class="label(Left|Right)">Make:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Model", '%<span class="label(Left|Right)">Model:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Length", '%<span class="label(Left|Right)">Length:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Fuel", '%<span class="label(Left|Right)">Fuel Type:</span>(.+?)</li>%', "$2");
        $this->regexWeb->addRegexRule("Phone", '/<li class="slrPhn(.+?)">(.*?)\(([0-9]+)\) ([0-9]+?)-([0-9]+)/', "($3) $4-$5");
        $this->regexWeb->addRegexRule("Zip", "/zip=([0-9]+)/", "$1");
    }

    function processABoatInfo($url, $result, $index)
    {
    	/**
    	 * Insert into Searches Database
    	 */

        $this->regexWeb->setParseData($result);

        echo $this->regexWeb->parseRule("Class").", ";
        echo $this->regexWeb->parseRule("Category").", ";
        echo $this->regexWeb->parseRule("Year").", ";
        echo $this->regexWeb->parseRule("Make").", ";
        echo $this->regexWeb->parseRule("Model").", ";
        echo $this->regexWeb->parseRule("Length").", ";
        echo $this->regexWeb->parseRule("Fuel").", ";
        echo $this->regexWeb->parseRule("Zip").", ";
        echo $this->regexWeb->parseRule("Phone").", ";
        echo $this->regexWeb->parseRule("Photo").", ";
        echo $url.", ";
        echo "\n";
    }

    function processCrawl($baseUrl)
    {
    	$this->cleanup();

    	$id = $_SESSION["id"];
    	$mode = $_SESSION["mode"];
        $j = 0;
        $url = $baseUrl;
        while ($url != "")
        {
            echo "Collecting Search Results... Page #" . (++$j) . "...\n";

            $result = WebUtility::getHttpContent($url);
            if($result==null)
                return;
            $this->regexWeb->setParseData($result);

            $mc = $this->regexWeb->parseRuleArray("Search");
            $url = "http://www.boattrader.com" . $this->regexWeb->parseRule("Next");
            for ($i = 0; $i < count($mc)-24; $i++)
            {
                echo "Collecting #".($i+1)." :" . $mc[$i]."\n";
                $itemUrl = "http://www.boattrader.com" . $mc[$i];
                $dataResult = WebUtility::getHttpContent($itemUrl);
                $this->processABoatInfo($itemUrl, $dataResult, ($j-1)*25+$i);
            }
        }
        echo "Finished Processing...\n";
    }

    function collectAllLinks($baseUrl)
    {
        $j = 0;
        $url = $baseUrl;
        while ($url != "")
        {
            echo "Collecting Search Results... Page #" . (++$j) . "...\n";

            $result = WebUtility::getHttpContent($url);
            if($result==null)
                return;
            $this->regexWeb->setParseData($result);

            $mc = $this->regexWeb->parseRuleArray("Search");

            $url = "http://www.boattrader.com" . $this->regexWeb->parseRule("Next");
            /**
             * Insert into PendingSearches
             */

            for ($i = 0; $i < count($mc)-24; $i++)
            {
            	/**
            	 * Insert into PendingUrls
            	 */
                echo "Collecting #".($i+1)." :" . $mc[$i]."\n";
                $itemUrl = "http://www.boattrader.com" . $mc[$i];
                //$dataResult = WebUtility::getHttpContent($itemUrl);
                //$this->processABoatInfo($itemUrl, $dataResult, ($j-1)*25+$i);
            }
        }
        echo "Finished Processing...\n";
    }

    function willCancel($id)
    {
    	$time = 0;	//get time for the id in database
   		if($time < (time()-600))
    	{
    		return true;
    	}
    	return false;
    }

    function cleanup()
    {

    }

    function getSearchId()
    {
    	if(isset($_SESSION["sid"]))
    	{

    	}
    }
}

$crawler = new CrawlBoattrader();
$crawler->processCrawl("http://www.boattrader.com/search-results/NewOrUsed-any/Type-any/State-all/Price-2500,100000/Sort-Length:DESC/");

?>
