<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Search Boats</title>
<link rel="stylesheet" type="text/css" href="css/boats.css" />
</head>
<script>
	var pClassID = new Array("0","115","142","116","132","123","138","120","133","108","124","139","113","141","119","122","109","112","114","103","107","106","101","143","100","111","105","104","121","140","102","144","117","110","137","135","118");
	var pClassDesc = new Array("All","Aluminum Fish Boats","Antique and Classics","Bass Boats","Bay Boats","Bluewater Fishing","Bowrider","Center Consoles","Commercial Boats","Convertible Boats","Cruisers","Cuddy Cabin","Deck Boats","Downeast","Flats Boats","Freshwater Fishing","High Performance Boats","House Boats","Inflatables","Jet Boats","Mega Yachts","Motor Yachts","Personal Watercraft","Pilothouse","Pontoon Boats","Power Catamarans","Power Cruisers","Runabouts","Saltwater Fishing","Ski & Fish","Ski/Wakeboard Boats","Small Boats","Sport Fishing Boats","Trawlers","Unspecified","Utility Boats","Walkarounds");

	var fClassID = new Array("0","115","116","132","123","120","119","122","143","100","111","121","140","144","117","118");
	var fClassDesc = new Array("All","Aluminum Fish Boats","Bass Boats","Bay Boats","Bluewater Fishing","Center Consoles","Flats Boats","Freshwater Fishing","Pilothouse","Pontoon Boats","Power Catamarans","Saltwater Fishing","Ski & Fish","Small Boats","Sport Fishing Boats","Walkarounds");

	var sClassID = new Array("0","142","130","136","129","131","128","127","143","126","125","144");
	var sClassDesc = new Array("All","Antique and Classics","Beach Catamarans","Cruisers","Daysailers","Dinghies","Motorsailers","Multi-Hulls","Pilothouse","Racer/Cruisers","Racers","Small Boats");

	var allClassID = new Array("");
	var allClassDesc = new Array("All");
	
	
	function loadDropDowns(id)
	{
		var strHtml = "";
		switch(id)
 		{
 			case 0:
				for(i=0;i<allClassDesc.length;i++)
					strHtml += "<option value='"+allClassID[i]+"'>"+allClassDesc[i]+"</option>";
 				break;
 			case 100:
				for(i=0;i<pClassDesc.length;i++)
					strHtml += "<option value='"+pClassID[i]+"'>"+pClassDesc[i]+"</option>";
 				break;
 			case 101:
				for(i=0;i<fClassDesc.length;i++)
					strHtml += "<option value='"+fClassID[i]+"'>"+fClassDesc[i]+"</option>";
 				break;
 			case 102:
				for(i=0;i<sClassDesc.length;i++)
					strHtml += "<option value='"+sClassID[i]+"'>"+sClassDesc[i]+"</option>";
 				break;
 		}
		document.getElementById("bclint").innerHTML=strHtml;
	}
</script>
<body>
<div id="contentContainer">
  <div id="titleGreyBox">
    <div class="titleGreyBox">Advanced Search</div>
  </div>
  <input height="1" width="1" type="image" border="0" onclick="window.focus();" alt="Search" src="http://images.boats.com/images/b-QAT_213/global/spacer.gif" name="Search" ilo-full-src="http://images.boats.com/images/b-QAT_213/global/spacer.gif"/>
  <table cellspacing="0" cellpadding="0" border="0" class="advancedSearchTable">
    <form method="POST" action="boats.php" name="advSearchForm"/>
    
    <input type="hidden" value="true" name="ic"/>
    <input type="hidden" value="quick" name="slim"/>
    <input type="hidden" value="3" name="sm"/>
    <input type="hidden" value="advancedsearch" name="bn"/>
    <input type="hidden" value="boatsEN" name="Ntk"/>
    <input type="hidden" value="US" name="locale"/>
    <input type="hidden" value="false" name="sfm"/>
    <tbody>
      <tr>
        <td></td>
        <td colspan="5"><input type="submit" value="Search" name="search"/>
          <input type="reset" value="Clear the form" name="reset"/></td>
      </tr>
      <tr>
        <td colspan="6"><hr noshade="" width="610" size="1"/></td>
      </tr>
      <tr>
        <td class="advancedSearchTDText">Keyword</td>
        <td colspan="5"><input type="text" value="" name="Ntt" size="40"/></td>
      </tr>
      <!-- START boat category -->
      <tr>
        <td class="advancedSearchTDText">Boat Category</td>
        <td width="50" class="advancedSearchTDRadio"><input type="radio" onclick="loadDropDowns(0)" checked="checked" value="" name="bcint"/>
          All</td>
        <td width="80" class="advancedSearchTDRadio"><input type="radio" onclick="loadDropDowns(101)" value="2" name="bcint"/>
          Fishing</td>
        <td width="90" class="advancedSearchTDRadio"><input type="radio" onclick="loadDropDowns(100)" value="1" name="bcint"/>
          Power</td>
        <td width="220" class="advancedSearchTDRadio"><input type="radio" onclick="loadDropDowns(102)" value="4" name="bcint"/>
          Sail</td>
        <td width="10" class="advancedSearchTDRadio"></td>
      </tr>
      <!-- END boat category -->
      <!-- START boat type -->
      <tr>
        <td class="advancedSearchTDText">Boat Type</td>
        <td class="advancedSearchTDRadio"><input type="radio" checked="checked" value="" name="is"/>
          All</td>
        <td class="advancedSearchTDRadio"><input type="radio" value="true" name="is"/>
          New</td>
        <td class="advancedSearchTDRadio"><input type="radio" value="false" name="is"/>
          Pre-Owned</td>
        <td class="advancedSearchTDRadio"></td>
        <td class="advancedSearchTDRadio"></td>
      </tr>
      <!-- END boat type -->
      <!-- START boat class -->
      <tr>
        <td class="advancedSearchTDText">Boat Class</td>
        <td colspan="5"><select id="bclint" name="bclint">
            <option value="0">All</option>
            <option value="115">Aluminum Fish Boats</option>
            <option value="116">Bass Boats</option>
            <option value="132">Bay Boats</option>
            <option value="123">Bluewater Fishing</option>
            <option value="120">Center Consoles</option>
            <option value="119">Flats Boats</option>
            <option value="122">Freshwater Fishing</option>
            <option value="143">Pilothouse</option>
            <option value="100">Pontoon Boats</option>
            <option value="111">Power Catamarans</option>
            <option value="121">Saltwater Fishing</option>
            <option value="140">Ski & Fish</option>
            <option value="144">Small Boats</option>
            <option value="117">Sport Fishing Boats</option>
            <option value="118">Walkarounds</option>
          </select></td>
        <td><help:helplink key="boatClass"/></td>
      </tr>
      <!-- END boat class -->
      <tr>
        <td class="advancedSearchTDText">Make/Brand</td>
        <td colspan="5"><input type="text" name="man" maxlength="100" size="40"/></td>
      </tr>
      <!-- END make/brand -->
    </tbody>
  </table>
  <br/>
  <hr noshade="" size="1"/>
  <table cellspacing="0" cellpadding="0" border="0" class="advancedSearchTable">
    <!-- START boat details header -->
    <tbody>
      <tr>
        <td colspan="4"><h2>Boat Details</h2></td>
      </tr>
      <!-- END boat details header -->
      <!-- START year -->
      <tr>
        <td class="advancedSearchTDText">Year</td>
        <td colspan="3"><input type="text" name="fromYear" maxlength="4" size="6"/>
          To
          <input type="text" name="toYear" maxlength="4" size="6"/></td>
      </tr>
      <!-- END year -->
      <!-- START length -->
      <tr>
        <td class="advancedSearchTDText">Length</td>
        <td width="460" colspan="2"><input type="text" name="fromLength" maxlength="8" size="6"/>
          To
          <input type="text" name="toLength" maxlength="8" size="6"/>
          <input type="radio" checked="checked" value="126" name="luom"/>
          ft
          <input type="radio" value="127" name="luom"/>
          m </td>
        <td width="40"><help:helplink key="length"/></td>
      </tr>
      <!-- END length -->
      <!-- START hull material -->
      <tr>
        <td class="advancedSearchTDText">Hull Material</td>
        <td colspan="3"><select name="hmid">
            <option value="0"> All</option>
            <option value="100"> Aluminum</option>
            <option value="101"> Composite</option>
            <option value="108"> Ferro-Cement</option>
            <option value="102"> Fiberglass</option>
            <option value="106"> Hypalon</option>
            <option value="105"> Other</option>
            <option value="107"> PVC</option>
            <option value="109"> Roplene</option>
            <option value="103"> Steel</option>
            <option value="104"> Wood</option>
          </select></td>
      </tr>
      <!-- END hull material -->
      <!-- START engine -->
      <tr>
        <td class="advancedSearchTDText">Engine Fuel</td>
        <td colspan="3"><select name="ftid">
            <option value="0"> All</option>
            <option value="101"> Diesel</option>
            <option value="100"> Gas/Petrol</option>
            <option value="102"> Other</option>
          </select></td>
      </tr>
      <tr>
        <td class="advancedSearchTDText">No. Of Engines</td>
        <td colspan="3"><select name="enid">
            <option value="0"> All</option>
            <option value="100"> 1</option>
            <option value="101"> 2</option>
            <option value="103"> None</option>
            <option value="102"> Other</option>
          </select></td>
      </tr>
      <!-- END engine -->
      <!-- START price -->
      <tr>
        <td class="advancedSearchTDText">Currency</td>
        <td colspan="3"><select name="currencyid">
            <option value="1008"> Australian Dollars</option>
            <option value="1000"> Canadian Dollars</option>
            <option value="1004"> Euros</option>
            <option value="1002"> New Zealand Dollars</option>
            <option value="1005"> Pounds Sterling</option>
            <option value="1009"> Swedish Kronors</option>
            <option selected="" value="100"> US Dollars</option>
          </select></td>
      </tr>
      <tr>
        <td class="advancedSearchTDText">Price</td>
        <td colspan="3"><select name="fromPrice">
            <option selected="" value="">$0</option>
            <option value="5000">$5,000</option>
            <option value="10000">$10,000</option>
            <option value="15000">$15,000</option>
            <option value="20000">$20,000</option>
            <option value="25000">$25,000</option>
            <option value="30000">$30,000</option>
            <option value="40000">$40,000</option>
            <option value="50000">$50,000</option>
            <option value="75000">$75,000</option>
            <option value="100000">$100,000</option>
            <option value="150000">$150,000</option>
            <option value="200000">$200,000</option>
            <option value="300000">$300,000</option>
            <option value="400000">$400,000</option>
            <option value="500000">$500,000</option>
            <option value="1000000">$1,000,000</option>
          </select>
          To
          <select name="toPrice">
            <option selected="" value="">No Max</option>
            <option value="5000">$5,000</option>
            <option value="10000">$10,000</option>
            <option value="15000">$15,000</option>
            <option value="20000">$20,000</option>
            <option value="25000">$25,000</option>
            <option value="30000">$30,000</option>
            <option value="40000">$40,000</option>
            <option value="50000">$50,000</option>
            <option value="75000">$75,000</option>
            <option value="100000">$100,000</option>
            <option value="150000">$150,000</option>
            <option value="200000">$200,000</option>
            <option value="300000">$300,000</option>
            <option value="400000">$400,000</option>
            <option value="500000">$500,000</option>
            <option value="1000000">$1,000,000</option>
          </select></td>
        <!-- END price -->
      </tr>
    </tbody>
  </table>
  <br/>
  <hr noshade="" size="1"/>
  <table cellspacing="0" cellpadding="0" border="0" class="advancedSearchTable">
    <!-- START boat location header -->
    <tbody>
      <tr>
        <td colspan="4"><h2>Boat Location</h2></td>
      </tr>
      <!-- END boat location header -->
      <!-- START location -->
      <tr>
        <td colspan="2" class="advancedSearchTDText">Boats Within</td>
        <td><select name="psdistance">
            <option value="25">25 miles</option>
            <option selected="" value="50">50 miles</option>
            <option value="100">100 miles</option>
            <option value="500">500 miles</option>
            <option value="1">no limit</option>
          </select>
          of Zip/Postal Code
          <input type="text" value="" maxlength="50" name="pszipcode" size="7"/>
          <span>* Required</span></td>
      </tr>
      <tr>
        <td colspan="2" class="advancedSearchTDText">City</td>
        <td><input type="text" value="" maxlength="50" name="city" size="16"/></td>
      </tr>
      <tr>
        <td width="7"><img height="1" width="7" valign="top" src="http://images.boats.com/images/b-QAT_213/global/spacer.gif" ilo-full-src="http://images.boats.com/images/b-QAT_213/global/spacer.gif"/></td>
        <td style="padding-left: 0px;" class="advancedSearchTDText">Area Code(s)</td>
        <td><input type="text" maxlength="3" name="ac" size="5"/>
          <input type="text" maxlength="3" name="ac" size="5"/>
          <input type="text" maxlength="3" name="ac" size="5"/>
          <input type="text" maxlength="3" name="ac" size="5"/></td>
        <td><help:helplink key="areacode"/></td>
      </tr>
      <tr>
        <td colspan="2" class="advancedSearchTDText">State/Province</td>
        <td><select name="spid">
            <option value="">All</option>
            <option value="100"> Alabama </option>
            <option value="101"> Alaska </option>
            <option value="102"> Arizona </option>
            <option value="103"> Arkansas </option>
            <option value="104"> California </option>
            <option value="105"> Colorado </option>
            <option value="106"> Connecticut </option>
            <option value="107"> Delaware </option>
            <option value="147"> District of Columbia </option>
            <option value="108"> Florida </option>
            <option value="109"> Georgia </option>
            <option value="110"> Hawaii </option>
            <option value="111"> Idaho </option>
            <option value="112"> Illinois </option>
            <option value="113"> Indiana </option>
            <option value="114"> Iowa </option>
            <option value="115"> Kansas </option>
            <option value="116"> Kentucky </option>
            <option value="117"> Louisiana </option>
            <option value="118"> Maine </option>
            <option value="119"> Maryland </option>
            <option value="120"> Massachusetts </option>
            <option value="121"> Michigan </option>
            <option value="122"> Minnesota </option>
            <option value="123"> Mississippi </option>
            <option value="124"> Missouri </option>
            <option value="125"> Montana </option>
            <option value="126"> Nebraska </option>
            <option value="127"> Nevada </option>
            <option value="128"> New Hampshire </option>
            <option value="129"> New Jersey </option>
            <option value="130"> New Mexico </option>
            <option value="131"> New York </option>
            <option value="132"> North Carolina </option>
            <option value="133"> North Dakota </option>
            <option value="134"> Ohio </option>
            <option value="135"> Oklahoma </option>
            <option value="136"> Oregon </option>
            <option value="137"> Pennsylvania </option>
            <option value="138"> Rhode Island </option>
            <option value="139"> South Carolina </option>
            <option value="140"> South Dakota </option>
            <option value="141"> Tennessee </option>
            <option value="142"> Texas </option>
            <option value="143"> Utah </option>
            <option value="144"> Vermont </option>
            <option value="145"> Virginia </option>
            <option value="146"> Washington </option>
            <option value="148"> West Virginia </option>
            <option value="149"> Wisconsin </option>
            <option value="150"> Wyoming </option>
            <option value="200"> Alberta </option>
            <option value="201"> British Columbia </option>
            <option value="202"> Manitoba </option>
            <option value="203"> New Brunswick </option>
            <option value="204"> Newfoundland </option>
            <option value="205"> Northwest Territories </option>
            <option value="206"> Nova Scotia </option>
            <option value="207"> Nunavut </option>
            <option value="208"> Ontario </option>
            <option value="209"> Prince Edward Island </option>
            <option value="210"> Quebec </option>
            <option value="211"> Saskatchewan </option>
            <option value="212"> Yukon </option>
            <option value="151"> Puerto Rico </option>
            <option value="152"> US Virgin Islands </option>
            <option value="153"> Guam </option>
          </select></td>
      </tr>
      <tr>
        <td width="7"><img height="1" width="7" valign="top" src="http://images.boats.com/images/b-QAT_213/global/spacer.gif" ilo-full-src="http://images.boats.com/images/b-QAT_213/global/spacer.gif"/></td>
        <td style="padding-left: 0px;" class="advancedSearchTDText">Country</td>
        <td><select multiple="" size="8" name="cint">
            <option value="0"> All </option>
            <option value="102"> Afghanistan </option>
            <option value="103"> Albania </option>
            <option value="104"> Algeria </option>
            <option value="105"> American Samoa </option>
            <option value="106"> Andorra </option>
            <option value="107"> Angola </option>
            <option value="108"> Anguilla </option>
            <option value="109"> Antigua & Barbuda </option>
            <option value="110"> Argentina </option>
            <option value="111"> Armenia </option>
            <option value="112"> Aruba </option>
            <option value="113"> Australia </option>
            <option value="114"> Austria </option>
            <option value="115"> Azerbaijan </option>
            <option value="116"> Bahamas </option>
            <option value="117"> Bahrain </option>
            <option value="118"> Bangladesh </option>
            <option value="119"> Barbados </option>
            <option value="120"> Belarus </option>
            <option value="121"> Belgium </option>
            <option value="122"> Belize </option>
            <option value="123"> Benin </option>
            <option value="124"> Bermuda </option>
            <option value="125"> Bhutan </option>
            <option value="126"> Bolivia </option>
            <option value="325"> BonAire </option>
            <option value="127"> Bosnia and Herzegovina </option>
            <option value="128"> Botswana </option>
            <option value="129"> Brazil </option>
            <option value="312"> British Virgin Islands </option>
            <option value="130"> Brunei </option>
            <option value="131"> Bulgaria </option>
            <option value="132"> Burkina Faso </option>
            <option value="133"> Burundi </option>
            <option value="134"> Cambodia </option>
            <option value="135"> Cameroon </option>
            <option value="101"> Canada </option>
            <option value="136"> Cape Verde </option>
            <option value="313"> Cayman Islands </option>
            <option value="137"> Central African Republic </option>
            <option value="138"> Chad </option>
            <option value="317"> Channel Islands (UK) </option>
            <option value="139"> Chile </option>
            <option value="140"> China </option>
            <option value="141"> Colombia </option>
            <option value="142"> Comoros Islands </option>
            <option value="143"> Congo </option>
            <option value="144"> Cook Islands </option>
            <option value="145"> Costa Rica </option>
            <option value="147"> Croatia </option>
            <option value="148"> Cuba </option>
            <option value="149"> Cyprus </option>
            <option value="150"> Czech Republic </option>
            <option value="151"> Denmark </option>
            <option value="152"> Djibouti </option>
            <option value="153"> Dominica </option>
            <option value="154"> Dominican Republic </option>
            <option value="332"> Dubai </option>
            <option value="155"> East Timor </option>
            <option value="156"> Ecuador </option>
            <option value="157"> Egypt </option>
            <option value="158"> El Salvador </option>
            <option value="159"> Equatorial Guinea </option>
            <option value="160"> Eritrea </option>
            <option value="161"> Estonia </option>
            <option value="162"> Ethiopia </option>
            <option value="163"> Faroe Islands </option>
            <option value="164"> Fiji </option>
            <option value="165"> Finland </option>
            <option value="166"> France </option>
            <option value="319"> French Polynesia </option>
            <option value="326"> French West Indies </option>
            <option value="167"> Gabon </option>
            <option value="168"> Gambia </option>
            <option value="169"> Georgia </option>
            <option value="170"> Germany </option>
            <option value="171"> Ghana </option>
            <option value="314"> Gibraltar (UK) </option>
            <option value="172"> Greece </option>
            <option value="320"> Greenland (DK) </option>
            <option value="173"> Grenada </option>
            <option value="321"> Guadeloupe (FR) </option>
            <option value="311"> Guam (US) </option>
            <option value="174"> Guatemala </option>
            <option value="175"> Guinea </option>
            <option value="176"> Guinea-Bissau </option>
            <option value="177"> Guyana </option>
            <option value="178"> Haiti </option>
            <option value="179"> Honduras </option>
            <option value="180"> Hong Kong </option>
            <option value="181"> Hungary </option>
            <option value="182"> Iceland </option>
            <option value="183"> India </option>
            <option value="184"> Indonesia </option>
            <option value="185"> Iran </option>
            <option value="186"> Iraq </option>
            <option value="187"> Ireland </option>
            <option value="188"> Israel </option>
            <option value="189"> Italy </option>
            <option value="318"> Ivory Coast </option>
            <option value="190"> Jamaica </option>
            <option value="191"> Japan </option>
            <option value="192"> Jordan </option>
            <option value="193"> Kazakhstan </option>
            <option value="194"> Kenya </option>
            <option value="195"> Kiribati </option>
            <option value="196"> Korea, North </option>
            <option value="197"> Korea, Republic of </option>
            <option value="198"> Kuwait </option>
            <option value="199"> Kyrgyzstan </option>
            <option value="200"> Laos </option>
            <option value="201"> Latvia </option>
            <option value="202"> Lebanon </option>
            <option value="327"> Leeward Islands </option>
            <option value="203"> Lesotho </option>
            <option value="204"> Liberia </option>
            <option value="205"> Libya </option>
            <option value="206"> Liechtenstein </option>
            <option value="207"> Lithuania </option>
            <option value="208"> Luxembourg </option>
            <option value="209"> Macedonia </option>
            <option value="210"> Madagascar </option>
            <option value="211"> Malawi </option>
            <option value="212"> Malaysia </option>
            <option value="213"> Maldives </option>
            <option value="214"> Mali </option>
            <option value="215"> Malta </option>
            <option value="216"> Marshall Islands </option>
            <option value="322"> Martinique (FR) </option>
            <option value="217"> Mauritania </option>
            <option value="218"> Mauritius </option>
            <option value="219"> Mayotte </option>
            <option value="220"> Mexico </option>
            <option value="221"> Micronesia </option>
            <option value="222"> Moldova </option>
            <option value="223"> Monaco </option>
            <option value="224"> Mongolia </option>
            <option value="225"> Morocco </option>
            <option value="226"> Mozambique </option>
            <option value="227"> Myanmar </option>
            <option value="228"> Namibia </option>
            <option value="229"> Nauru </option>
            <option value="230"> Nepal </option>
            <option value="231"> Netherlands </option>
            <option value="323"> Netherlands Antilles (NL) </option>
            <option value="315"> New Caledonia (FR) </option>
            <option value="232"> New Zealand </option>
            <option value="233"> Nicaragua </option>
            <option value="234"> Niger </option>
            <option value="235"> Nigeria </option>
            <option value="236"> Niue </option>
            <option value="237"> Norway </option>
            <option value="238"> Oman </option>
            <option value="310"> Other </option>
            <option value="239"> Pakistan </option>
            <option value="240"> Palau </option>
            <option value="241"> Palestine </option>
            <option value="242"> Panama </option>
            <option value="243"> Papua New Guinea </option>
            <option value="244"> Paracel Islands </option>
            <option value="245"> Paraguay </option>
            <option value="246"> Peru </option>
            <option value="247"> Philippines </option>
            <option value="248"> Poland </option>
            <option value="249"> Portugal </option>
            <option value="250"> Puerto Rico (US) </option>
            <option value="251"> Qatar </option>
            <option value="252"> Romania </option>
            <option value="253"> Russia </option>
            <option value="254"> Rwanda </option>
            <option value="324"> Saipan </option>
            <option value="258"> San Marino </option>
            <option value="259"> Sao Tome & Principe </option>
            <option value="260"> Saudi Arabia </option>
            <option value="261"> Senegal </option>
            <option value="262"> Serbia & Montenegro </option>
            <option value="263"> Seychelles </option>
            <option value="264"> Sierra Leone </option>
            <option value="265"> Singapore </option>
            <option value="266"> Slovakia </option>
            <option value="267"> Slovenia </option>
            <option value="268"> Solomon Islands </option>
            <option value="269"> Somalia </option>
            <option value="270"> South Africa </option>
            <option value="271"> Spain </option>
            <option value="272"> Spratly Islands </option>
            <option value="273"> Sri Lanka </option>
            <option value="274"> St. Barthilemy </option>
            <option value="255"> St. Kits & Nevis </option>
            <option value="256"> St. Lucia </option>
            <option value="328"> St. Maarten/St. Martin </option>
            <option value="329"> St. Pierre et Miquelon </option>
            <option value="257"> St. Vincent & the Grenadines </option>
            <option value="275"> Sudan </option>
            <option value="276"> Suriname </option>
            <option value="277"> Swaziland </option>
            <option value="278"> Sweden </option>
            <option value="279"> Switzerland </option>
            <option value="280"> Syria </option>
            <option value="281"> Taiwan </option>
            <option value="282"> Tajikistan </option>
            <option value="283"> Tanzania </option>
            <option value="284"> Thailand </option>
            <option value="285"> Togo </option>
            <option value="286"> Tonga </option>
            <option value="287"> Trinidad & Tobago </option>
            <option value="288"> Tunisia </option>
            <option value="289"> Turkey </option>
            <option value="290"> Turkmenistan </option>
            <option value="316"> Turks and Caicos Islands (UK) </option>
            <option value="291"> Tuvalu </option>
            <option value="292"> Uganda </option>
            <option value="293"> Ukraine </option>
            <option value="294"> United Arab Emirates </option>
            <option value="295"> United Kingdom </option>
            <option selected="" value="100"> United States </option>
            <option value="296"> Uruguay </option>
            <option value="297"> Uzbekistan </option>
            <option value="298"> Vanuatu </option>
            <option value="299"> Vatican City State </option>
            <option value="300"> Venezuela </option>
            <option value="301"> Vietnam </option>
            <option value="302"> Virgin Islands (US) </option>
            <option value="330"> West Indies </option>
            <option value="303"> Western Sahara </option>
            <option value="304"> Western Samoa </option>
            <option value="331"> Windward Islands </option>
            <option value="305"> Yemen </option>
            <option value="307"> Zaire </option>
            <option value="308"> Zambia </option>
            <option value="309"> Zimbabwe </option>
          </select></td>
      </tr>
      <tr>
        <td colspan="2" class="advancedSearchTDText">North American Regions</td>
        <td height="30" width="380"><select multiple="" size="8" name="rid">
            <option value="">All</option>
            <option value="100"> Northeast (CT,MA,ME,NB,NH,NS,NY,PE,QC,RI,VT) </option>
            <option value="101"> Mid-Atlantic (DC,DE,MD,NJ,PA,VA,WV) </option>
            <option value="102"> Great Lakes (IL,IN,MI,MN,OH,ON,PA,QC,WI) </option>
            <option value="103"> Midwest (IA, KS, MO, NE, ND, SD) </option>
            <option value="158"> Heartland (IA,NE,KS,OK,AR,MO,IL,IN,KY,TN,WV) </option>
            <option value="104"> Southeast (FL,GA,KY,NC,PR,SC,TN,VI) </option>
            <option value="105"> Gulf Coast (AL, LA, MS, TX) </option>
            <option value="106"> Southwest (AR, OK, NM, AZ) </option>
            <option value="107"> West (CA,CO,GU,HI,MT,NV,OR,UT,WY) </option>
            <option value="108"> Pacific Northwest (AK,BC,ID,OR,WA) </option>
          </select></td>
      </tr>
      <!-- END location -->
    </tbody>
  </table>
  <br/>
  <hr noshade="" size="1"/>
  <table cellspacing="0" cellpadding="0" border="0" class="advancedSearchTable">
    <!-- START additional criteria header -->
    <tbody>
      <tr>
        <td colspan="2"><h2>Additional Search Criteria</h2></td>
      </tr>
      <!-- END additional criteria header -->
      <!-- START additional criteria -->
      <tr>
        <td class="advancedSearchTDText">Boats Added Recently</td>
        <td width="460"><select name="pbsint">
            <option selected="" value="">All</option>
            <option value="1227880585255">Within 1 day</option>
            <option value="1227707785255">Within 3 days</option>
            <option value="1227362185255">Within 7 days</option>
            <option value="1226757385255">Within 14 days</option>
            <option value="1225374985255">Within 30 days</option>
            <option value="1222782985255">Within 60 days</option>
          </select></td>
      </tr>
      <tr>
        <td  class="advancedSearchTDText">Search Mode</td>
        <td height="30" width="380"><input type="radio" checked=""  id="normalsearch" class="advRadio" value="normal" name="mode"/>
          <label class="radioLabel" for="normalsearch">Normal</label>
          <input type="radio" id="extendedsearch" class="advRadio" value="extended" name="mode"/>
          <label class="radioLabel" for="extendedsearch">Extended</label></td>
      </tr>
      <!-- END additional criteria -->
    </tbody>
  </table>
  <br/>
  <table cellspacing="0" cellpadding="0" border="0" class="advancedSearchTable">
    <tbody>
      <tr>
        <td class="advancedSearchTDText"></td>
        <td width="460"><input type="submit" value="Search" name="search"/>
          <input type="reset" value="Clear the form" name="reset"/></td>
      </tr>
    </tbody>
  </table>
  <!-- END buttons -->
  <help:helptext>
    <!-- END CENTER CONTENT -->
  </help:helptext>
</div>
</body>
</html>
