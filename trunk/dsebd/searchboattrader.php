<? session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Boattrader-Search</title>
<script type="text/javascript" src="./js/jquery-1.2.6.js"></script>
<script type="text/javascript" src="./js/validator.js"></script>
<link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
<div id="templateContainer">
  <div id="bigLft" style="height: 1000px;">
    <h2 class="srch">SEARCH BOAT <span>LISTINGS</span></h2>
    <div class="dtd"/>
    <span class="bold">Search many new and used boats, yachts, and PWCs</span><br class="clear"/>
    <form class="mainSrch" action="" method="post" name="mainsearch">
      <fieldset class="sRdo sLft">
        <h3>I'm Looking For...</h3>
        <input type="radio" checked="checked" id="newUsed" url="/NewOrUsed-" searchnode="true" value="any" name="rb_Status"/>
        <label>New & Pre-Owned Boats<br/>
        </label>
        <input type="radio" id="newOnly" url="/NewOrUsed-" searchnode="true" value="New" name="rb_Status"/>
        <label>New Boats<br/>
        </label>
      </fieldset>
      <fieldset class="sRdo sRt">
        <h3>Of This Type...</h3>
        <input type="radio"  checked="checked" value="any" id="anytype" class="cLft" url="/Type-" searchnode="true" name="rb_CustomSelectionType"/>
        <label class="sAny">All Boat Types <br/>
        </label>
        <input type="radio"  value="Power" id="Powertype" class="cLft" url="/Type-" searchnode="true" name="rb_CustomSelectionType"/>
        <label class="sPwr">Power Boats <br/>
          (Runabouts, Cruisers, Center Consoles, etc.)</label>
        <br class="clear"/>
        <div id="Power" class="sCt"> Categories<br/>
          <select url="/Category-" searchnode="false" id="typepower" name="Power">
            <option selected="selected" value="all">All Power Boats</option>
            <option value="Aft Cabin">Aft Cabin</option>
            <option value="Airboat">Airboat</option>
            <option value="Angler">Angler</option>
            <option value="Bass Boat">Bass Boat</option>
            <option value="Bay Boat">Bay Boat</option>
            <option value="Bluewater Fishing">Bluewater Fishing</option>
            <option value="Bowrider">Bowrider</option>
            <option value="Catamaran (Power)">Catamaran (Power)</option>
            <option value="Center Console">Center Console</option>
            <option value="Classic (Power)">Classic (Power)</option>
            <option value="Commercial">Commercial</option>
            <option value="Convertible">Convertible</option>
            <option value="Cruiser (Power)">Cruiser (Power)</option>
            <option value="Cuddy Cabin">Cuddy Cabin</option>
            <option value="Deck Boat">Deck Boat</option>
            <option value="Dive Boat">Dive Boat</option>
            <option value="Downeast">Downeast</option>
            <option value="Dual Console">Dual Console</option>
            <option value="Duck Boat">Duck Boat</option>
            <option value="Express Cruiser">Express Cruiser</option>
            <option value="Fish And Ski">Fish And Ski</option>
            <option value="Flats Boat">Flats Boat</option>
            <option value="Flybridge">Flybridge</option>
            <option value="Freshwater Fishing">Freshwater Fishing</option>
            <option value="High Performance">High Performance</option>
            <option value="Houseboat">Houseboat</option>
            <option value="Jet Boat">Jet Boat</option>
            <option value="Jon Boat">Jon Boat</option>
            <option value="Mega Yacht">Mega Yacht</option>
            <option value="Motoryacht">Motoryacht</option>
            <option value="Other">Other</option>
            <option value="Pilothouse">Pilothouse</option>
            <option value="Pontoon">Pontoon</option>
            <option value="Runabout">Runabout</option>
            <option value="Saltwater Fishing">Saltwater Fishing</option>
            <option value="Ski and Wakeboard boat">Ski and Wakeboard boat</option>
            <option value="Skiff">Skiff</option>
            <option value="Sport Fisherman">Sport Fisherman</option>
            <option value="Submersible">Submersible</option>
            <option value="Trawler">Trawler</option>
            <option value="Walkaround">Walkaround</option>
            <option value="Weekender">Weekender</option>
          </select>
        </div>
        <input type="radio"  value="Sail" id="Sailtype" class="cLft" url="/Type-" searchnode="true" name="rb_CustomSelectionType"/>
        <label class="sSal">Sailboats <br/>
          (Racers, Cruisers, Catamarans, etc)</label>
        <br class="clear"/>
        <div id="Sail" class="sCt"> Categories<br/>
          <select url="/Category-" searchnode="false" id="typesail" name="Sail">
            <option selected="selected" value="all">All Sailboats</option>
            <option value="Catamaran (Sail)">Catamaran (Sail)</option>
            <option value="Classic (Sail)">Classic (Sail)</option>
            <option value="Cruiser (Sail)">Cruiser (Sail)</option>
            <option value="Cruiser/Racer">Cruiser/Racer</option>
            <option value="Cutter">Cutter</option>
            <option value="Daysailor/Weekender">Daysailor/Weekender</option>
            <option value="Ketch">Ketch</option>
            <option value="Motorsailer">Motorsailer</option>
            <option value="Multi-Hull">Multi-Hull</option>
            <option value="Other">Other</option>
            <option value="Racer">Racer</option>
            <option value="Sloop">Sloop</option>
            <option value="Yawl">Yawl</option>
          </select>
        </div>
        <input type="radio"  value="Small Boats" id="SmallBoatstype" class="cLft" url="/Type-" searchnode="true" name="rb_CustomSelectionType"/>
        <label class="sSml">Small Boats <br/>
          (Row Boats, Tenders, Dinghies, etc)</label>
        <br class="clear"/>
        <div id="SmallBoats" class="sCt">Categories<br/>
          <select  url="/Category-" searchnode="false" id="typeSmallBoats" name="Small Boats">
            <option selected="selected" value="all">All Small Boats</option>
            <option value="Canoe/Kayak">Canoe/Kayak</option>
            <option value="Inflatables">Inflatables</option>
            <option value="Other">Other</option>
            <option value="Rigid Inflatable">Rigid Inflatable</option>
            <option value="Tenders/Small Boats">Tenders/Small Boats</option>
          </select>
        </div>
        <input type="radio"  value="PWC" id="PWCtype" class="cLft" url="/Type-" searchnode="true" name="rb_CustomSelectionType"/>
        <label class="sPwc">PWC</label>
        <br class="clear"/>
      </fieldset>
      <fieldset class="sSml sLft">
        <h3 id="sArea">In This Area...<span id="rqd"> [Required]</span></h3>
        <div id="zpBtn">
          <input type="radio"  checked="checked" id="rbzipCode" searchnode="true" value="zip" name="rb_ZipButton" class="rdo"/>
          <label>ZIP Code</label>
        </div>
        <div id="zip">
          <input type="text" required="required" message="Please Enter a Valid 5 Digit Zip Code" id="zipcode" pattern="/\d{5}/" error="alert" url="/Zip-" searchnode="true" maxlength="5" name="zipCode"/>
          <span> within </span>
          <select style="width: 120px;" url="/Radius-" searchnode="true" id="zipRadius" name="zipRad">
            <option value="exact">Exact</option>
            <option value="25">25 miles</option>
            <option value="50">50 miles</option>
            <option value="100">100 miles</option>
            <option value="250">250 miles</option>
            <option selected="selected" value="500">500 miles</option>
            <option value="1000">1000 miles</option>
            <option value="any">Any Distance</option>
          </select>
        </div>
        <div id="stBtn">
          <input type="radio"  id="rbstateCode" url="" searchnode="true" value="state" name="rb_ZipButton" class="rdo"/>
          <label>State/Province</label>
        </div>
        <div class="sHid" id="state">
          <select class="sBg" url="/State-" searchnode="false" id="stateCode" name="stateCode">
            <option selected="selected" value="all">All</option>
            <optgroup label="-------------------------------------"/>    
            <optgroup label="US States">
              <option value="AL|Alabama">Alabama</option>
              <option value="AK|Alaska">Alaska</option>
              <option value="AZ|Arizona">Arizona</option>
              <option value="AR|Arkansas">Arkansas</option>
              <option value="CA|California">California</option>
              <option value="CO|Colorado">Colorado</option>
              <option value="CT|Connecticut">Connecticut</option>
              <option value="DE|Delaware">Delaware</option>
              <option value="DC|District of Columbia">District of Columbia</option>
              <option value="FL|Florida">Florida</option>
              <option value="GA|Georgia">Georgia</option>
              <option value="HI|Hawaii">Hawaii</option>
              <option value="ID|Idaho">Idaho</option>
              <option value="IL|Illinois">Illinois</option>
              <option value="IN|Indiana">Indiana</option>
              <option value="IA|Iowa">Iowa</option>
              <option value="KS|Kansas">Kansas</option>
              <option value="KY|Kentucky">Kentucky</option>
              <option value="LA|Louisiana">Louisiana</option>
              <option value="ME|Maine">Maine</option>
              <option value="MD|Maryland">Maryland</option>
              <option value="MA|Massachusetts">Massachusetts</option>
              <option value="MI|Michigan">Michigan</option>
              <option value="MN|Minnesota">Minnesota</option>
              <option value="MS|Mississippi">Mississippi</option>
              <option value="MO|Missouri">Missouri</option>
              <option value="MT|Montana">Montana</option>
              <option value="NE|Nebraska">Nebraska</option>
              <option value="NV|Nevada">Nevada</option>
              <option value="NH|New Hampshire">New Hampshire</option>
              <option value="NJ|New Jersey">New Jersey</option>
              <option value="NM|New Mexico">New Mexico</option>
              <option value="NY|New York">New York</option>
              <option value="NC|North Carolina">North Carolina</option>
              <option value="ND|North Dakota">North Dakota</option>
              <option value="OH|Ohio">Ohio</option>
              <option value="OK|Oklahoma">Oklahoma</option>
              <option value="OR|Oregon">Oregon</option>
              <option value="PA|Pennsylvania">Pennsylvania</option>
              <option value="RI|Rhode Island">Rhode Island</option>
              <option value="SC|South Carolina">South Carolina</option>
              <option value="SD|South Dakota">South Dakota</option>
              <option value="TN|Tennessee">Tennessee</option>
              <option value="TX|Texas">Texas</option>
              <option value="UT|Utah">Utah</option>
              <option value="VT|Vermont">Vermont</option>
              <option value="VA|Virginia">Virginia</option>
              <option value="WA|Washington">Washington</option>
              <option value="WV|West Virginia">West Virginia</option>
              <option value="WI|Wisconsin">Wisconsin</option>
              <option value="WY|Wyoming">Wyoming</option>
            </optgroup>
            <optgroup label="Canadian Provinces">
              <option value="AB|Alberta">Alberta</option>
              <option value="BC|British Columbia">British Columbia</option>
              <option value="MB|Manitoba">Manitoba</option>
              <option value="NB|New Brunswick">New Brunswick</option>
              <option value="NL|Newfoundland">Newfoundland</option>
              <option value="NT|Northwest Territories">Northwest Territories</option>
              <option value="NS|Nova Scotia">Nova Scotia</option>
              <option value="NU|Nunavut">Nunavut</option>
              <option value="ON|Ontario">Ontario</option>
              <option value="PE|Prince Edward Island">Prince Edward Island</option>
              <option value="QC|Quebec">Quebec</option>
              <option value="SK|Saskatchewan">Saskatchewan</option>
              <option value="YT|Yukon Territory">Yukon Territory</option>
            </optgroup>
            <optgroup label="US Territory">
              <option value="PR|Puerto Rico">Puerto Rico</option>
            </optgroup>
          </select>
        </div>
        <div id="rgBtn">
          <input type="radio" id="rbregionCode" class="rdo" url="" searchnode="true" value="region" name="rb_ZipButton"/>
          <label>Region</label>
        </div>
        <div class="sHid" id="region">
          <select class="sBg" url="/Region-" searchnode="false" id="regionCode" name="regionCode">
            <option selected="selected" value="all">All Regions</option>
            <option value="CA|Canada">Canada</option>
            <option value="CB|Caribbean">Caribbean</option>
            <option value="GL|Great Lakes">Great Lakes</option>
            <option value="GC|Gulf Coast">Gulf Coast</option>
            <option value="MA|Mid Atlantic">Mid Atlantic</option>
            <option value="MW|Mid West">Mid West</option>
            <option value="NE|North East">North East</option>
            <option value="NW|North West">North West</option>
            <option value="PA|Pacific">Pacific</option>
            <option value="SE|South East">South East</option>
            <option value="SW|South West">South West</option>
            <option value="WT|Western">Western</option>
          </select>
        </div>
        <div id="otBtn">
          <input type="radio"  id="rbcountryCode" class="rdo" url="" searchnode="true" value="country" name="rb_ZipButton"/>
          <label>Outside U.S. and Canada</label>
        </div>
        <div class="sHid" id="country">
          <select class="sBg" url="/Country-" searchnode="false" id="countryCode" name="countryCode">
            <option selected="selected" value="all">All Countries</option>
            <option value="AL|Albania">Albania</option>
            <option value="DZ|Algeria">Algeria</option>
            <option value="AS|American Samoa">American Samoa</option>
            <option value="AD|Andorra">Andorra</option>
            <option value="AO|Angola">Angola</option>
            <option value="AI|Anguilla">Anguilla</option>
            <option value="AQ|Antarctica">Antarctica</option>
            <option value="AG|Antigua and Barbuda">Antigua and Barbuda</option>
            <option value="AR|Argentina">Argentina</option>
            <option value="AM|Armenia">Armenia</option>
            <option value="AW|Aruba">Aruba</option>
            <option value="AU|Australia">Australia</option>
            <option value="AT|Austria">Austria</option>
            <option value="AZ|Azerbaijan">Azerbaijan</option>
            <option value="V|BVI">BVI</option>
            <option value="BS|Bahamas">Bahamas</option>
            <option value="BH|Bahrain">Bahrain</option>
            <option value="BD|Bangladesh">Bangladesh</option>
            <option value="BB|Barbados">Barbados</option>
            <option value="BY|Belarus">Belarus</option>
            <option value="BE|Belgium">Belgium</option>
            <option value="BZ|Belize">Belize</option>
            <option value="BJ|Benin">Benin</option>
            <option value="BM|Bermuda">Bermuda</option>
            <option value="BT|Bhutan">Bhutan</option>
            <option value="BO|Bolivia">Bolivia</option>
            <option value="BA|Bosnia and Herzegovina">Bosnia and Herzegovina</option>
            <option value="BW|Botswana">Botswana</option>
            <option value="BV|Bouvet Island">Bouvet Island</option>
            <option value="BR|Brazil">Brazil</option>
            <option value="IO|British Indian Ocean Territory">British Indian Ocean Territory</option>
            <option value="VG|British Virgin Islands">British Virgin Islands</option>
            <option value="B|British West Indies">British West Indies</option>
            <option value="BN|Brunei">Brunei</option>
            <option value="BG|Bulgaria">Bulgaria</option>
            <option value="BF|Burkina Faso">Burkina Faso</option>
            <option value="BI|Burundi">Burundi</option>
            <option value="KH|Cambodia">Cambodia</option>
            <option value="CM|Cameroon">Cameroon</option>
            <option value="CV|Cape Verde">Cape Verde</option>
            <option value="KY|Cayman Islands">Cayman Islands</option>
            <option value="CF|Central African Republic">Central African Republic</option>
            <option value="TD|Chad">Chad</option>
            <option value="CL|Chile">Chile</option>
            <option value="CN|China">China</option>
            <option value="CX|Christmas Island">Christmas Island</option>
            <option value="CC|Cocos Islands">Cocos Islands</option>
            <option value="CO|Colombia">Colombia</option>
            <option value="KM|Comoros">Comoros</option>
            <option value="CG|Congo">Congo</option>
            <option value="CK|Cook Islands">Cook Islands</option>
            <option value="CR|Costa Rica">Costa Rica</option>
            <option value="HR|Croatia">Croatia</option>
            <option value="CU|Cuba">Cuba</option>
            <option value="CY|Cyprus">Cyprus</option>
            <option value="CZ|Czech Republic">Czech Republic</option>
            <option value="DK|Denmark">Denmark</option>
            <option value="DJ|Djibouti">Djibouti</option>
            <option value="DM|Dominica">Dominica</option>
            <option value="DO|Dominican Republic">Dominican Republic</option>
            <option value="D|Dutch West Indies">Dutch West Indies</option>
            <option value="TP|East Timor">East Timor</option>
            <option value="EC|Ecuador">Ecuador</option>
            <option value="EG|Egypt">Egypt</option>
            <option value="SV|El Salvador">El Salvador</option>
            <option value="GQ|Equatorial Guinea">Equatorial Guinea</option>
            <option value="ER|Eritrea">Eritrea</option>
            <option value="EE|Estonia">Estonia</option>
            <option value="ET|Ethiopia">Ethiopia</option>
            <option value="FK|Falkland Islands">Falkland Islands</option>
            <option value="FO|Faroe Islands">Faroe Islands</option>
            <option value="FJ|Fiji">Fiji</option>
            <option value="FI|Finland">Finland</option>
            <option value="FR|France">France</option>
            <option value="GF|French Guiana">French Guiana</option>
            <option value="PF|French Polynesia">French Polynesia</option>
            <option value="TF|French Southern Territories">French Southern Territories</option>
            <option value="F|French West Indies">French West Indies</option>
            <option value="GA|Gabon">Gabon</option>
            <option value="GM|Gambia">Gambia</option>
            <option value="GE|Georgia">Georgia</option>
            <option value="DE|Germany">Germany</option>
            <option value="GH|Ghana">Ghana</option>
            <option value="GI|Gibraltar">Gibraltar</option>
            <option value="GR|Greece">Greece</option>
            <option value="GL|Greenland">Greenland</option>
            <option value="GD|Grenada">Grenada</option>
            <option value="GP|Guadeloupe">Guadeloupe</option>
            <option value="GU|Guam">Guam</option>
            <option value="GT|Guatemala">Guatemala</option>
            <option value="GN|Guinea">Guinea</option>
            <option value="GW|Guinea-Bissau">Guinea-Bissau</option>
            <option value="GY|Guyana">Guyana</option>
            <option value="HT|Haiti">Haiti</option>
            <option value="HM|Heard and McDonald Islands">Heard and McDonald Islands</option>
            <option value="HN|Honduras">Honduras</option>
            <option value="HK|Hong Kong">Hong Kong</option>
            <option value="HU|Hungary">Hungary</option>
            <option value="IS|Iceland">Iceland</option>
            <option value="IN|India">India</option>
            <option value="ID|Indonesia">Indonesia</option>
            <option value="IR|Iran">Iran</option>
            <option value="IQ|Iraq">Iraq</option>
            <option value="IE|Ireland">Ireland</option>
            <option value="IL|Israel">Israel</option>
            <option value="IT|Italy">Italy</option>
            <option value="CI|Ivory Coast">Ivory Coast</option>
            <option value="JM|Jamaica">Jamaica</option>
            <option value="JP|Japan">Japan</option>
            <option value="JO|Jordan">Jordan</option>
            <option value="KZ|Kazakhstan">Kazakhstan</option>
            <option value="KE|Kenya">Kenya</option>
            <option value="KI|Kiribati">Kiribati</option>
            <option value="KP|Korea, North">Korea, North</option>
            <option value="KR|Korea, South">Korea, South</option>
            <option value="KW|Kuwait">Kuwait</option>
            <option value="KG|Kyrgyzstan">Kyrgyzstan</option>
            <option value="LA|Laos">Laos</option>
            <option value="LV|Latvia">Latvia</option>
            <option value="LB|Lebanon">Lebanon</option>
            <option value="LS|Lesotho">Lesotho</option>
            <option value="LR|Liberia">Liberia</option>
            <option value="LY|Libya">Libya</option>
            <option value="LI|Liechtenstein">Liechtenstein</option>
            <option value="LT|Lithuania">Lithuania</option>
            <option value="LU|Luxembourg">Luxembourg</option>
            <option value="MO|Macau">Macau</option>
            <option value="MK|Macedonia, Former Yugoslav Republic of">Macedonia, Former Yugoslav Republic of</option>
            <option value="MG|Madagascar">Madagascar</option>
            <option value="MW|Malawi">Malawi</option>
            <option value="MY|Malaysia">Malaysia</option>
            <option value="MV|Maldives">Maldives</option>
            <option value="ML|Mali">Mali</option>
            <option value="MT|Malta">Malta</option>
            <option value="MH|Marshall Islands">Marshall Islands</option>
            <option value="MQ|Martinique">Martinique</option>
            <option value="MR|Mauritania">Mauritania</option>
            <option value="MU|Mauritius">Mauritius</option>
            <option value="YT|Mayotte">Mayotte</option>
            <option value="MX|Mexico">Mexico</option>
            <option value="FM|Micronesia, Federated States of">Micronesia, Federated States of</option>
            <option value="MD|Moldova">Moldova</option>
            <option value="MC|Monaco">Monaco</option>
            <option value="MN|Mongolia">Mongolia</option>
            <option value="MS|Montserrat">Montserrat</option>
            <option value="MA|Morocco">Morocco</option>
            <option value="MZ|Mozambique">Mozambique</option>
            <option value="MM|Myanmar">Myanmar</option>
            <option value="NA|Namibia">Namibia</option>
            <option value="NR|Nauru">Nauru</option>
            <option value="NP|Nepal">Nepal</option>
            <option value="N|Netherland Antilles">Netherland Antilles</option>
            <option value="NL|Netherlands">Netherlands</option>
            <option value="AN|Netherlands Antilles">Netherlands Antilles</option>
            <option value="NC|New Caledonia">New Caledonia</option>
            <option value="NZ|New Zealand">New Zealand</option>
            <option value="NI|Nicaragua">Nicaragua</option>
            <option value="NE|Niger">Niger</option>
            <option value="NG|Nigeria">Nigeria</option>
            <option value="NU|Niue">Niue</option>
            <option value="NF|Norfolk Island">Norfolk Island</option>
            <option value="MP|Northern Mariana Islands">Northern Mariana Islands</option>
            <option value="NO|Norway">Norway</option>
            <option value="OM|Oman">Oman</option>
            <option value="PK|Pakistan">Pakistan</option>
            <option value="PW|Palau">Palau</option>
            <option value="PA|Panama">Panama</option>
            <option value="PG|Papua New Guinea">Papua New Guinea</option>
            <option value="PY|Paraguay">Paraguay</option>
            <option value="PE|Peru">Peru</option>
            <option value="PH|Philippines">Philippines</option>
            <option value="PN|Pitcairn Island">Pitcairn Island</option>
            <option value="PL|Poland">Poland</option>
            <option value="PT|Portugal">Portugal</option>
            <option value="PR|Puerto Rico">Puerto Rico</option>
            <option value="QA|Qatar">Qatar</option>
            <option value="RE|Reunion">Reunion</option>
            <option value="RO|Romania">Romania</option>
            <option value="RU|Russia">Russia</option>
            <option value="RW|Rwanda">Rwanda</option>
            <option value="GS|S. Georgia and S. Sandwich Isls.">S. Georgia and S. Sandwich Isls.</option>
            <option value="KN|Saint Kitts &amp; Nevis">Saint Kitts & Nevis</option>
            <option value="LC|Saint Lucia">Saint Lucia</option>
            <option value="VC|Saint Vincent and The Grenadines">Saint Vincent and The Grenadines</option>
            <option value="WS|Samoa">Samoa</option>
            <option value="SM|San Marino">San Marino</option>
            <option value="ST|Sao Tome and Principe">Sao Tome and Principe</option>
            <option value="SA|Saudi Arabia">Saudi Arabia</option>
            <option value="SN|Senegal">Senegal</option>
            <option value="SC|Seychelles">Seychelles</option>
            <option value="SL|Sierra Leone">Sierra Leone</option>
            <option value="SG|Singapore">Singapore</option>
            <option value="SK|Slovakia">Slovakia</option>
            <option value="SI|Slovenia">Slovenia</option>
            <option value="SO|Somalia">Somalia</option>
            <option value="ZA|South Africa">South Africa</option>
            <option value="ES|Spain">Spain</option>
            <option value="SP|Spanish West Indies">Spanish West Indies</option>
            <option value="LK|Sri Lanka">Sri Lanka</option>
            <option value="SH|St. Helena">St. Helena</option>
            <option value="PM|St. Pierre and Miquelon">St. Pierre and Miquelon</option>
            <option value="SD|Sudan">Sudan</option>
            <option value="SR|Suriname">Suriname</option>
            <option value="SJ|Svalbard and Jan Mayen Islands">Svalbard and Jan Mayen Islands</option>
            <option value="SZ|Swaziland">Swaziland</option>
            <option value="SE|Sweden">Sweden</option>
            <option value="CH|Switzerland">Switzerland</option>
            <option value="SY|Syria">Syria</option>
            <option value="TW|Taiwan">Taiwan</option>
            <option value="TJ|Tajikistan">Tajikistan</option>
            <option value="TZ|Tanzania">Tanzania</option>
            <option value="TH|Thailand">Thailand</option>
            <option value="TG|Togo">Togo</option>
            <option value="TK|Tokelau">Tokelau</option>
            <option value="TO|Tonga">Tonga</option>
            <option value="TT|Trinidad and Tobago">Trinidad and Tobago</option>
            <option value="TN|Tunisia">Tunisia</option>
            <option value="TR|Turkey">Turkey</option>
            <option value="TM|Turkmenistan">Turkmenistan</option>
            <option value="TC|Turks and Caicos Islands">Turks and Caicos Islands</option>
            <option value="TV|Tuvalu">Tuvalu</option>
            <option value="UM|U.S. Minor Outlying Islands">U.S. Minor Outlying Islands</option>
            <option value="s|US Virgin Isles">US Virgin Isles</option>
            <option value="UG|Uganda">Uganda</option>
            <option value="UA|Ukraine">Ukraine</option>
            <option value="AE|United Arab Emirates">United Arab Emirates</option>
            <option value="UK|United Kingdom">United Kingdom</option>
            <option value="UT|United States Territory">United States Territory</option>
            <option value="UY|Uruguay">Uruguay</option>
            <option value="UZ|Uzbekistan">Uzbekistan</option>
            <option value="VU|Vanuatu">Vanuatu</option>
            <option value="VA|Vatican City">Vatican City</option>
            <option value="VE|Venezuela">Venezuela</option>
            <option value="VN|Vietnam">Vietnam</option>
            <option value="VI|Virgin Islands">Virgin Islands</option>
            <option value="WF|Wallis and Futuna Islands">Wallis and Futuna Islands</option>
            <option value="WI|West Indies">West Indies</option>
            <option value="EH|Western Sahara">Western Sahara</option>
            <option value="YE|Yemen">Yemen</option>
            <option value="YU|Yugoslavia (Former)">Yugoslavia (Former)</option>
            <option value="ZR|Zaire">Zaire</option>
            <option value="ZM|Zambia">Zambia</option>
            <option value="ZW|Zimbabwe">Zimbabwe</option>
          </select>
        </div>
      </fieldset>
      
      <fieldset class="sLrg sLft">
        <h3>Of This Manufacturer...</h3>
        <input  pattern="/[a-zA-Z0-9&amp;-/\s]*/g" error="fix" url="/Make-" searchnode="true" id="makesDrop" name="makes"/>
      </fieldset>
      <fieldset class="sSml sRt">
        <h3>Between These Lengths...</h3>
        <input onfocus="javascript: var oTemp = getElementById('hilength'); oTemp.value = ''; oTemp.disabled= false;" pattern="/[0-9]*/g" error="fix" url="/Length-" searchnode="true" id="lolength" name="fromlength"/>
        <span>  to  </span>
        <input disabled="disabled" onfocus="javascript: this.value = '';" pattern="/[0-9]*/g" error="fix" url="," searchnode="true" id="hilength" name="tolength"/>
      </fieldset>
      <br class="clear"/>
      <fieldset class="sYer sLft">
        <h3>From These Years...</h3>
        <select id="lYear" url="/Year-" searchnode="false" name="dm_FromSrcYear">
          <option value="1920">1920</option>
          <option value="1921">1921</option>
          <option value="1922">1922</option>
          <option value="1923">1923</option>
          <option value="1924">1924</option>
          <option value="1925">1925</option>
          <option value="1926">1926</option>
          <option value="1927">1927</option>
          <option value="1928">1928</option>
          <option value="1929">1929</option>
          <option value="1930">1930</option>
          <option value="1931">1931</option>
          <option value="1932">1932</option>
          <option value="1933">1933</option>
          <option value="1934">1934</option>
          <option value="1935">1935</option>
          <option value="1936">1936</option>
          <option value="1937">1937</option>
          <option value="1938">1938</option>
          <option value="1939">1939</option>
          <option value="1940">1940</option>
          <option value="1941">1941</option>
          <option value="1942">1942</option>
          <option value="1943">1943</option>
          <option value="1944">1944</option>
          <option value="1945">1945</option>
          <option value="1946">1946</option>
          <option value="1947">1947</option>
          <option value="1948">1948</option>
          <option value="1949">1949</option>
          <option value="1950">1950</option>
          <option value="1951">1951</option>
          <option value="1952">1952</option>
          <option value="1953">1953</option>
          <option value="1954">1954</option>
          <option value="1955">1955</option>
          <option value="1956">1956</option>
          <option value="1957">1957</option>
          <option value="1958">1958</option>
          <option value="1959">1959</option>
          <option value="1960">1960</option>
          <option value="1961">1961</option>
          <option value="1962">1962</option>
          <option value="1963">1963</option>
          <option value="1964">1964</option>
          <option value="1965">1965</option>
          <option value="1966">1966</option>
          <option value="1967">1967</option>
          <option value="1968">1968</option>
          <option value="1969">1969</option>
          <option value="1970">1970</option>
          <option value="1971">1971</option>
          <option value="1972">1972</option>
          <option value="1973">1973</option>
          <option value="1974">1974</option>
          <option value="1975">1975</option>
          <option value="1976">1976</option>
          <option value="1977">1977</option>
          <option value="1978">1978</option>
          <option value="1979">1979</option>
          <option value="1980">1980</option>
          <option value="1981">1981</option>
          <option value="1982">1982</option>
          <option value="1983">1983</option>
          <option value="1984">1984</option>
          <option value="1985">1985</option>
          <option value="1986">1986</option>
          <option value="1987">1987</option>
          <option value="1988">1988</option>
          <option value="1989">1989</option>
          <option value="1990">1990</option>
          <option value="1991">1991</option>
          <option value="1992">1992</option>
          <option value="1993">1993</option>
          <option value="1994">1994</option>
          <option value="1995">1995</option>
          <option value="1996">1996</option>
          <option value="1997">1997</option>
          <option value="1998">1998</option>
          <option value="1999">1999</option>
          <option value="2000">2000</option>
          <option value="2001">2001</option>
          <option value="2002">2002</option>
          <option value="2003">2003</option>
          <option value="2004">2004</option>
          <option value="2005">2005</option>
          <option value="2006">2006</option>
          <option value="2007">2007</option>
          <option value="2008">2008</option>
          <option value="2009">2009</option>
          <option selected="selected" value="Any">Any</option>
        </select>
        <span>to</span>
        <select id="hYear" url="," searchnode="false"  name="dm_FromDestYear">
          <option value="Any">Any</option>
        </select>
      </fieldset>
      <fieldset class="sSml sRt">
        <h3>Between These Prices...</h3>
        <input type="text" onfocus="javascript: var oTemp = getElementById('hPrice'); oTemp.value = ''; oTemp.disabled= false;" pattern="/[0-9]*/g" error="fix" id="lPrice" url="/Price-" searchnode="true" name="dm_FromSrcPrice"/>
        <span>  to  </span>
        <input type="text" disabled="disabled" onfocus="javascript: this.value = '';" pattern="/[0-9]*/g" error="fix" id="hPrice" url="," searchnode="true" name="dm_FromDestPrice"/>
      </fieldset>
      <fieldset class="sMid sLft">
        <h3>Sort By...</h3>
        <select url="/" searchnode="true" id="sortBy" name="dm_SortBy">
          <option value="Sort-Updated:DESC">Date Updated - New to Old</option>
          <option value="Sort-Updated:ASC">Date Updated - Old to New</option>
          <option selected="selected" value="Sort-Length:DESC">Length - High to Low</option>
          <option value="Sort-Length:ASC">Length - Low to High</option>
          <option value="Sort-Price:DESC">Price - High to Low</option>
          <option value="Sort-Price:ASC">Price - Low to High</option>
          <option value="Sort-Year:DESC">Year - New to Old</option>
          <option value="Sort-Year:ASC">Year - Old to New</option>
        </select>
      </fieldset>
      <fieldset class="sRdo sLft">
        <h3>Search Option...</h3>
        <input type="radio" checked="checked" id="normalsearch" value="normal" name="rb_Search"/>
        <label>Normal<br/>
        </label>
        <input type="radio" id="extendedsearch" value="extended" name="rb_Search"/>
        <label>Extended<br/>
        </label>
        <h3><a rel="search" href="boattrader.php" class="sMid sRt">Search</a></h3>
      </fieldset>
     
    </form>
  </div>
<!--  <textarea id="searchq" name="searchq" cols="70" rows="4"></textarea> -->
</div>
</body>
</html>