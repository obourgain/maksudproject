<?php
class RegexWebCrawler {
    private $dictRegex;
    private $dictReplacement;
    private $parseData;
    private $regexReplacement;

    public function RegexWebCrawler($data) {
        $this->parseData = $data;
        $this->dictRegex = array ();
        $this->dictReplacement = array ();
    }

    public function addRegexRule($rule, $regex, $replacement) {
        $this->dictRegex[$rule] = $regex;
        $this->dictReplacement[$rule] = $replacement;
    }

    public function removeRegexRule($rule) {
        unset ($this->dictRegex[$rule]);
        unset ($this->dictReplacement[$rule]);
    }

    public function setParseData($data) {
        $this->parseData = $data;
    }

    //is a rule is matched
    public function isRule($rule) {
        if (array_key_exists($rule, $this->dictRegex))
            return preg_match($this->dictRegex[$rule], $this->parseData);
        else
            return false;
    }

    //A Single Match
    public function parseRule($rule) {
        if (array_key_exists($rule, $this->dictRegex)) {
            if (preg_match($this->dictRegex[$rule], $this->parseData, $match)) {
                return preg_replace($this->dictRegex[$rule], $this->dictReplacement[$rule], $match[0]);               
            }
        }
        return "";
    }

    //Multiple Matches
    public function parseRuleArray($rule) {
        if (array_key_exists($rule, $this->dictRegex)) {
            preg_match_all($this->dictRegex[$rule], $this->parseData, $matches, PREG_PATTERN_ORDER);
            $retStr = array ();
            for ($j = 0; $j < count($matches[0]); $j++) {
                $retStr[$j] = preg_replace($this->dictRegex[$rule], $this->dictReplacement[$rule], $matches[0][$j]);
            }
            return $retStr;
        }
        return "";
    }
}


//$as = "Maksudul Alam";
//$r = new RegexWebCrawler($as);
//$r->addRegexRule("1", "/.(a)./", "<$0 - $1 - >");

//echo $r->parseRule("1");
//$rrr = $r->parseRuleArray("1");

//for($i=0; $i<count($rrr); $i++)
//    echo $rrr[$i];

?>
