<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Cars Search engine</title>
</head>
<script type="text/javascript" src="./js/carsvalidator.js"></script>
<body>
<form method="post" action="cars.php" id="searchform" name="advancedSearch">
  <input type="hidden" value="false" id="url" name="url" value="url"/>
  <input type="hidden" value="false" id="mode" name="mode" value="normal"/>
  <input type="hidden" value="false" id="searchtype" name="searchtype" value="22"/>
  <table width="100%" cellspacing="0" cellpadding="0" border="0" id="advSearchtable">
    <thead>
      <tr>
        <th colspan="5"><h2 id="title">Advanced Used-Car Search</h2></th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td align="left" colspan="5"></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span class="spanlabel">Vehicle Type</span></td>
        <td valign="top" align="right"> </td>
        <td valign="top" align="left"><select class="vehicledropdown" onchange="if (this.value != '') {advanced_search('24');} else {advanced_search('22');}" name="vehicleType" id="vehicletype">
            <option selected="selected" value="">All</option>
            <option value="3">Convertibles</option>
            <option value="2">Luxury Cars</option>
            <option value="10">Minivans</option>
            <option value="4">Passenger Cars</option>
            <option value="5">Sport-Utility Vehicles</option>
            <option value="6">Sports Cars</option>
            <option value="1">Trucks</option>
            <option value="8">Vans</option>
            <option value="7">Wagons</option>
          </select></td>
        <td/>
        <td/>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span class="spanlabel">Make</span></td>
        <td align="right"> </td>
        <td valign="top" align="left"><select onchange="fixMakeSelection(this);" class="vehicledropdown" size="5" name="mkid" id="mkid">
            <option value="">All</option>
            <option value="1">Acura</option>
            <option value="2">Alfa Romeo</option>
            <option value="61">Am General</option>
            <option value="60">American Motors</option>
            <option value="3">Aston Martin</option>
            <option value="4">Audi</option>
            <option value="463">Avanti Motors</option>
            <option value="6">Bentley</option>
            <option value="5">BMW</option>
            <option value="7">Buick</option>
            <option value="8">Cadillac</option>
            <option value="9">Chevrolet</option>
            <option value="10">Chrysler</option>
            <option value="62">Daewoo</option>
            <option value="11">Daihatsu</option>
            <option value="66">Delorean</option>
            <option value="80">DeTomaso</option>
            <option value="12">Dodge</option>
            <option value="13">Eagle</option>
            <option value="51">Ferrari</option>
            <option value="56">Fiat</option>
            <option value="14">Ford</option>
            <option value="17">Geo</option>
            <option value="15">GMC</option>
            <option value="18">Honda</option>
            <option value="363">Hummer</option>
            <option value="19">Hyundai</option>
            <option value="20">Infiniti</option>
            <option value="186">International</option>
            <option value="21">Isuzu</option>
            <option value="22">Jaguar</option>
            <option value="23">Jeep</option>
            <option value="24">Kia</option>
            <option value="25">Lamborghini</option>
            <option value="26">Land Rover</option>
            <option value="27">Lexus</option>
            <option value="28">Lincoln</option>
            <option value="29">Lotus</option>
            <option value="72">Maserati</option>
            <option value="403">Maybach</option>
            <option value="30">Mazda</option>
            <option value="31">Mercedes-Benz</option>
            <option value="32">Mercury</option>
            <option value="59">Merkur</option>
            <option value="303">Mini</option>
            <option value="34">Mitsubishi</option>
            <option value="443">Morgan</option>
            <option value="36">Nissan</option>
            <option value="37">Oldsmobile</option>
            <option value="79">Panoz</option>
            <option value="57">Peugeot</option>
            <option value="39">Plymouth</option>
            <option value="40">Pontiac</option>
            <option value="41">Porsche</option>
            <option value="222">Qvale</option>
            <option value="50">Renault</option>
            <option value="52">Rolls-Royce</option>
            <option value="42">Saab</option>
            <option value="483">Saleen</option>
            <option value="43">Saturn</option>
            <option value="423">Scion</option>
            <option value="563">Smart</option>
            <option value="54">Sterling</option>
            <option value="45">Subaru</option>
            <option value="46">Suzuki</option>
            <option value="47">Toyota</option>
            <option value="48">Volkswagen</option>
            <option value="49">Volvo</option>
            <option value="55">Yugo</option>
          </select></td>
        <td valign="top" align="center">&nbsp;</td>
        <td valign="top" align="left"><p class="instruction">&nbsp;</p></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td width="110" valign="top" align="right"><span class="spanlabel">Model</span></td>
        <td width="10" align="right"> </td>
        <td width="210" valign="top" align="left"><select class="vehicledropdown" size="5" name="mdid" id="mdid">
          <option value="">All</option>
          <option value="15">100</option>
          <option value="373">1000</option>
          <option value="615">128</option>
          <option value="9194">135</option>
          <option value="95">1500</option>
          <option value="9">164</option>
          <option value="551">18i</option>
          <option value="1274">190</option>
          <option value="16">200</option>
          <option value="546">2000</option>
          <option value="328">200SX</option>
          <option value="4237">228</option>
          <option value="453">240</option>
          <option value="4141">240D</option>
          <option value="329">240SX</option>
          <option value="96">2500</option>
          <option value="2956">280ZX</option>
          <option value="3594">300</option>
          <option value="307">3000GT</option>
          <option value="4947">300C</option>
          <option value="2739">300M</option>
          <option value="330">300ZX</option>
          <option value="1413">308</option>
          <option value="30">318</option>
          <option value="1293">320</option>
          <option value="1294">323</option>
          <option value="31">325</option>
          <option value="32">328</option>
          <option value="3636">330</option>
          <option value="8491">335</option>
          <option value="1406">348</option>
          <option value="97">3500</option>
          <option value="6068">350Z</option>
          <option value="4196">360 Modena</option>
          <option value="508">400</option>
          <option value="17">4000</option>
          <option value="535">405</option>
          <option value="4238">430</option>
          <option value="1401">456 M</option>
          <option value="6409">456 GT</option>
          <option value="422">4Runner</option>
          <option value="18">5000</option>
          <option value="536">504</option>
          <option value="537">505</option>
          <option value="6408">512 M</option>
          <option value="6390">512 TR</option>
          <option value="33">524</option>
          <option value="34">525</option>
          <option value="35">528</option>
          <option value="36">530</option>
          <option value="1295">533</option>
          <option value="37">535</option>
          <option value="38">540</option>
          <option value="7428">545</option>
          <option value="1400">550 Maranello</option>
          <option value="8051">550</option>
          <option value="5529">550 Barchetta</option>
          <option value="6449">575 M</option>
          <option value="8372">599 GTB Fiorano</option>
          <option value="124">600</option>
          <option value="374">6000</option>
          <option value="538">604</option>
          <option value="7594">612 Scaglietti</option>
          <option value="273">626</option>
          <option value="1296">633</option>
          <option value="39">635</option>
          <option value="3896">645</option>
          <option value="8052">650</option>
          <option value="1297">733</option>
          <option value="40">735</option>
          <option value="41">740</option>
          <option value="3899">745</option>
          <option value="42">750</option>
          <option value="455">760</option>
          <option value="3811">760GT</option>
          <option value="456">780</option>
          <option value="19">80</option>
          <option value="639">825</option>
          <option value="640">827</option>
          <option value="43">840</option>
          <option value="44">850</option>
          <option value="7612">9-2X</option>
          <option value="1502">9-3</option>
          <option value="1305">9-5</option>
          <option value="7662">9-7X</option>
          <option value="20">90</option>
          <option value="392">900</option>
          <option value="393">9000</option>
          <option value="386">911</option>
          <option value="387">924</option>
          <option value="388">928</option>
          <option value="274">929</option>
          <option value="458">940</option>
          <option value="389">944</option>
          <option value="459">960</option>
          <option value="390">968</option>
          <option value="7851">A3</option>
          <option value="21">A4</option>
          <option value="8812">A5</option>
          <option value="22">A6</option>
          <option value="23">A8</option>
          <option value="8512">Acadia</option>
          <option value="218">Accent</option>
          <option value="361">Acclaim</option>
          <option value="212">Accord</option>
          <option value="8571">Accord Hybrid</option>
          <option value="343">Achieva</option>
          <option value="6328">Aerio</option>
          <option value="7228">Aero 8</option>
          <option value="163">Aerostar</option>
          <option value="6108">AIV Roadster</option>
          <option value="2717">Alero</option>
          <option value="65">Allante</option>
          <option value="632">Alliance</option>
          <option value="5249">allroad</option>
          <option value="8911">Alpina B7</option>
          <option value="331">Altima</option>
          <option value="8851">Altima Hybrid</option>
          <option value="7248">Amanti</option>
          <option value="230">Amigo</option>
          <option value="125">Aries</option>
          <option value="7308">Armada</option>
          <option value="2897">Arnage</option>
          <option value="7009">Ascender</option>
          <option value="2718">Aspen</option>
          <option value="9413">Aspen Hybrid</option>
          <option value="164">Aspire</option>
          <option value="8818">Astra</option>
          <option value="74">Astro</option>
          <option value="8377">Aura</option>
          <option value="8932">Aura Green Line</option>
          <option value="9471">Aura Hybrid</option>
          <option value="344">Aurora</option>
          <option value="5567">Avalanche</option>
          <option value="423">Avalon</option>
          <option value="3987">Avanti</option>
          <option value="7268">Avanti II</option>
          <option value="126">Avenger</option>
          <option value="7214">Aveo</option>
          <option value="6348">Aviator</option>
          <option value="5607">Axiom</option>
          <option value="332">Axxess</option>
          <option value="7871">Azera</option>
          <option value="4810">Aztek</option>
          <option value="51">Azure</option>
          <option value="5473">B2000</option>
          <option value="5470">B2200</option>
          <option value="7128">B2300</option>
          <option value="5267">B2500</option>
          <option value="5472">B2600</option>
          <option value="5268">B3000</option>
          <option value="5269">B4000</option>
          <option value="7836">B9 Tribeca</option>
          <option value="6748">Baja</option>
          <option value="1307">Beetle</option>
          <option value="75">Beretta</option>
          <option value="4236">Biturbo</option>
          <option value="5427">Blackwood</option>
          <option value="76">Blazer</option>
          <option value="375">Bonneville</option>
          <option value="9252">Borrego</option>
          <option value="391">Boxster</option>
          <option value="406">Brat</option>
          <option value="345">Bravada</option>
          <option value="362">Breeze</option>
          <option value="165">Bronco</option>
          <option value="166">Bronco II</option>
          <option value="52">Brooklands</option>
          <option value="66">Brougham</option>
          <option value="285">C-Class</option>
          <option value="98">C10/K10</option>
          <option value="99">C20/K20</option>
          <option value="8937">C30</option>
          <option value="100">C30/K30</option>
          <option value="1501">C70</option>
          <option value="189">Caballero</option>
          <option value="440">Cabrio</option>
          <option value="24">Cabriolet</option>
          <option value="3508">Calais</option>
          <option value="8234">Caliber</option>
          <option value="633">Camargue</option>
          <option value="78">Camaro</option>
          <option value="424">Camry</option>
          <option value="8594">Camry Hybrid</option>
          <option value="2898">Camry Solara</option>
          <option value="7221">Canyon</option>
          <option value="294">Capri</option>
          <option value="79">Caprice</option>
          <option value="80">Caprice Classic</option>
          <option value="127">Caravan</option>
          <option value="363">Caravelle</option>
          <option value="7591">Carrera GT</option>
          <option value="67">Catera</option>
          <option value="81">Cavalier</option>
          <option value="7029">Cayenne</option>
          <option value="8551">Cayman</option>
          <option value="9711">CC</option>
          <option value="82">Celebrity</option>
          <option value="425">Celica</option>
          <option value="54">Century</option>
          <option value="7288">Challenge Stradale</option>
          <option value="510">Challenger</option>
          <option value="122">Charade</option>
          <option value="128">Charger</option>
          <option value="244">Cherokee</option>
          <option value="83">Chevette</option>
          <option value="68">Cimarron</option>
          <option value="109">Cirrus</option>
          <option value="84">Citation</option>
          <option value="214">Civic</option>
          <option value="8591">Civic Hybrid</option>
          <option value="243">CJ</option>
          <option value="6471">CJ-7</option>
          <option value="1">CL</option>
          <option value="4587">CL-Class</option>
          <option value="4080">Classic</option>
          <option value="286">CLK-Class</option>
          <option value="7651">CLS-Class</option>
          <option value="167">Club Wagon</option>
          <option value="7634">Cobalt</option>
          <option value="7212">Colorado</option>
          <option value="129">Colt</option>
          <option value="245">Comanche</option>
          <option value="3970">Commander</option>
          <option value="8236">Compass</option>
          <option value="501">Concord</option>
          <option value="110">Concorde</option>
          <option value="111">Conquest</option>
          <option value="53">Continental</option>
          <option value="7811">Continental Flying Spur</option>
          <option value="7269">Continental GT</option>
          <option value="8371">Continental GTC</option>
          <option value="168">Contour</option>
          <option value="5849">Cooper</option>
          <option value="9211">Cooper Clubman</option>
          <option value="6848">Cooper S</option>
          <option value="9212">Cooper S Clubman</option>
          <option value="308">Cordia</option>
          <option value="506">Cordoba</option>
          <option value="634">Corniche</option>
          <option value="426">Corolla</option>
          <option value="442">Corrado</option>
          <option value="85">Corsica</option>
          <option value="86">Corvette</option>
          <option value="295">Cougar</option>
          <option value="4220">Countach</option>
          <option value="460">Coupe</option>
          <option value="213">CR-V</option>
          <option value="427">Cressida</option>
          <option value="7169">Crossfire</option>
          <option value="169">Crown Victoria</option>
          <option value="1309">CRX</option>
          <option value="6128">CTS</option>
          <option value="346">Custom Cruiser</option>
          <option value="347">Cutlass</option>
          <option value="4321">Cutlass Calais</option>
          <option value="4322">Cutlass Ciera</option>
          <option value="4320">Cutlass Cruiser</option>
          <option value="6491">Cutlass Salon</option>
          <option value="4316">Cutlass Supreme</option>
          <option value="8239">CX-7</option>
          <option value="8375">CX-9</option>
          <option value="8751">CXT</option>
          <option value="9314">D100</option>
          <option value="9344">D150</option>
          <option value="9345">D250</option>
          <option value="9346">D350</option>
          <option value="474">Dakota</option>
          <option value="130">Daytona</option>
          <option value="14">DB7</option>
          <option value="4707">DB7 Vantage</option>
          <option value="7571">DB9</option>
          <option value="254">Defender</option>
          <option value="2796">del Sol</option>
          <option value="4318">Delta 88</option>
          <option value="69">DeVille</option>
          <option value="252">Diablo</option>
          <option value="309">Diamante</option>
          <option value="131">Diplomat</option>
          <option value="255">Discovery</option>
          <option value="404">DL</option>
          <option value="4015">DMC-12</option>
          <option value="7832">DTS</option>
          <option value="132">Durango</option>
          <option value="9412">Durango Hybrid</option>
          <option value="133">Dynasty</option>
          <option value="3600">E Class</option>
          <option value="287">E-Class</option>
          <option value="9613">E100</option>
          <option value="171">E150</option>
          <option value="9614">E250</option>
          <option value="9615">E350</option>
          <option value="9616">E350 Super Duty</option>
          <option value="502">Eagle</option>
          <option value="5227">ECHO</option>
          <option value="310">Eclipse</option>
          <option value="8311">Edge</option>
          <option value="3849">Eight</option>
          <option value="350">Eighty-Eight</option>
          <option value="87">El Camino</option>
          <option value="219">Elantra</option>
          <option value="70">Eldorado</option>
          <option value="55">Electra</option>
          <option value="6828">Element</option>
          <option value="7592">Elise</option>
          <option value="8771">Enclave</option>
          <option value="503">Encore</option>
          <option value="7088">Endeavor</option>
          <option value="8313">Entourage</option>
          <option value="1301">Envoy</option>
          <option value="8031">Envoy XL</option>
          <option value="7329">Envoy XUV</option>
          <option value="7231">Enzo</option>
          <option value="8243">Eos</option>
          <option value="7223">Equinox</option>
          <option value="257">ES 250</option>
          <option value="258">ES 300</option>
          <option value="7448">ES 330</option>
          <option value="8315">ES 350</option>
          <option value="2776">Escalade</option>
          <option value="7048">Escalade ESV</option>
          <option value="6548">Escalade EXT</option>
          <option value="9131">Escalade Hybrid</option>
          <option value="4767">Escape</option>
          <option value="8592">Escape Hybrid</option>
          <option value="172">Escort</option>
          <option value="4807">Esperante</option>
          <option value="271">Esprit</option>
          <option value="4708">Esprit V8</option>
          <option value="3472">Estate Wagon</option>
          <option value="416">Esteem</option>
          <option value="443">Eurovan</option>
          <option value="9092">EX35</option>
          <option value="220">Excel</option>
          <option value="4386">Excursion</option>
          <option value="4378">Executive</option>
          <option value="8191">Exige</option>
          <option value="8611">Exige S</option>
          <option value="3097">EXP</option>
          <option value="174">Expedition</option>
          <option value="8531">Expedition EL</option>
          <option value="175">Explorer</option>
          <option value="5947">Explorer Sport</option>
          <option value="5287">Explorer Sport Trac</option>
          <option value="311">Expo</option>
          <option value="3399">Express 1500</option>
          <option value="9617">Express 2500</option>
          <option value="9618">Express 3500</option>
          <option value="1512">F100</option>
          <option value="180">F150</option>
          <option value="181">F250</option>
          <option value="182">F350</option>
          <option value="1402">F355</option>
          <option value="1407">F40</option>
          <option value="7771">F430</option>
          <option value="8671">F450</option>
          <option value="1403">F50</option>
          <option value="521">Fairmont</option>
          <option value="176">Festiva</option>
          <option value="376">Fiero</option>
          <option value="112">Fifth Avenue</option>
          <option value="377">Firebird</option>
          <option value="352">Firenza</option>
          <option value="8235">Fit</option>
          <option value="7655">Five Hundred</option>
          <option value="7838">FJ Cruiser</option>
          <option value="71">Fleetwood</option>
          <option value="9291">Flex</option>
          <option value="3277">Focus</option>
          <option value="7215">Forenza</option>
          <option value="1306">Forester</option>
          <option value="8791">ForTwo</option>
          <option value="444">Fox</option>
          <option value="5847">Freelander</option>
          <option value="7222">Freestar</option>
          <option value="7611">Freestyle</option>
          <option value="1304">Frontier</option>
          <option value="552">Fuego</option>
          <option value="7831">Fusion</option>
          <option value="7091">FX35</option>
          <option value="7090">FX45</option>
          <option value="9351">FX50</option>
          <option value="5848">G-Class</option>
          <option value="224">G20</option>
          <option value="9751">G3</option>
          <option value="6228">G35</option>
          <option value="8831">G37</option>
          <option value="8431">G5</option>
          <option value="7652">G6</option>
          <option value="8816">G8</option>
          <option value="312">Galant</option>
          <option value="7348">Gallardo</option>
          <option value="9251">Genesis</option>
          <option value="405">GL</option>
          <option value="407">GL-10</option>
          <option value="8240">GL-Class</option>
          <option value="275">GLC</option>
          <option value="566">GLT</option>
          <option value="445">Golf</option>
          <option value="11">Graduate</option>
          <option value="365">Gran Fury</option>
          <option value="378">Grand Am</option>
          <option value="2999">Grand Caravan</option>
          <option value="246">Grand Cherokee</option>
          <option value="296">Grand Marquis</option>
          <option value="379">Grand Prix</option>
          <option value="2876">Grand Vitara</option>
          <option value="3036">Grand Voyager</option>
          <option value="526">Grand Wagoneer</option>
          <option value="3469">GranSport</option>
          <option value="8391">GranSport Spyder</option>
          <option value="8815">GranTurismo</option>
          <option value="260">GS 300</option>
          <option value="3467">GS 350</option>
          <option value="567">GS 400</option>
          <option value="5167">GS 430</option>
          <option value="7874">GS 450h</option>
          <option value="8991">GS 460</option>
          <option value="25">GT</option>
          <option value="9171">GT-R</option>
          <option value="1408">GTB</option>
          <option value="1254">GTI</option>
          <option value="4377">GTO</option>
          <option value="10">GTV-6</option>
          <option value="647">GV</option>
          <option value="6869">GX 470</option>
          <option value="6148">H1</option>
          <option value="8011">H1 Alpha</option>
          <option value="6149">H2</option>
          <option value="7911">H3</option>
          <option value="9571">H3T</option>
          <option value="7813">HHR</option>
          <option value="3592">Highlander</option>
          <option value="8931">Highlander Hybrid</option>
          <option value="231">Hombre</option>
          <option value="366">Horizon</option>
          <option value="601">Hummer</option>
          <option value="7872">i-280</option>
          <option value="8471">i-290</option>
          <option value="7873">i-350</option>
          <option value="8472">i-370</option>
          <option value="232">I-Mark</option>
          <option value="225">I30</option>
          <option value="5968">I35</option>
          <option value="89">Impala</option>
          <option value="113">Imperial</option>
          <option value="408">Impreza</option>
          <option value="233">Impulse</option>
          <option value="4487">Insight</option>
          <option value="2">Integra</option>
          <option value="134">Intrepid</option>
          <option value="353">Intrigue</option>
          <option value="6768">Ion</option>
          <option value="7875">IS 250</option>
          <option value="4847">IS 300</option>
          <option value="7839">IS 350</option>
          <option value="8814">IS-F</option>
          <option value="247">J10</option>
          <option value="248">J20</option>
          <option value="226">J30</option>
          <option value="4221">Jalpa</option>
          <option value="447">Jetta</option>
          <option value="190">Jimmy</option>
          <option value="9191">Journey</option>
          <option value="409">Justy</option>
          <option value="5169">L</option>
          <option value="45">L6</option>
          <option value="46">L7</option>
          <option value="7631">LaCrosse</option>
          <option value="3219">Lagonda</option>
          <option value="135">Lancer</option>
          <option value="7211">Lancer Evolution</option>
          <option value="7408">Lancer Sportback</option>
          <option value="428">Land Cruiser</option>
          <option value="9791">Landaulet</option>
          <option value="2736">Lanos</option>
          <option value="116">Laser</option>
          <option value="117">LeBaron</option>
          <option value="410">Legacy</option>
          <option value="2738">Leganza</option>
          <option value="3">Legend</option>
          <option value="380">LeMans</option>
          <option value="56">LeSabre</option>
          <option value="115">LHS</option>
          <option value="540">Liberte</option>
          <option value="5767">Liberty</option>
          <option value="530">LN7</option>
          <option value="411">Loyale</option>
          <option value="8511">LR2</option>
          <option value="7660">LR3</option>
          <option value="3377">LS</option>
          <option value="261">LS 400</option>
          <option value="5168">LS 430</option>
          <option value="8237">LS 460</option>
          <option value="8374">LS 600h L</option>
          <option value="354">LSS</option>
          <option value="178">LTD</option>
          <option value="7812">Lucerne</option>
          <option value="91">Lumina</option>
          <option value="3397">Lumina APV</option>
          <option value="505">Luv</option>
          <option value="3379">LW</option>
          <option value="262">LX 450</option>
          <option value="1303">LX 470</option>
          <option value="8871">LX 570</option>
          <option value="297">Lynx</option>
          <option value="5732">M</option>
          <option value="288">M-Class</option>
          <option value="47">M3</option>
          <option value="227">M30</option>
          <option value="7711">M35</option>
          <option value="6888">M45</option>
          <option value="48">M5</option>
          <option value="49">M6</option>
          <option value="3662">Magnum</option>
          <option value="92">Malibu</option>
          <option value="3556">Malibu Classic</option>
          <option value="7330">Malibu Maxx</option>
          <option value="4809">Mangusta</option>
          <option value="3758">Marauder</option>
          <option value="7659">Mariner</option>
          <option value="8593">Mariner Hybrid</option>
          <option value="7731">Mark LT</option>
          <option value="268">Mark VII</option>
          <option value="269">Mark VIII</option>
          <option value="298">Marquis</option>
          <option value="5851">Matrix</option>
          <option value="333">Maxima</option>
          <option value="7491">Mazda3</option>
          <option value="7951">Mazda5</option>
          <option value="6988">Mazda6</option>
          <option value="7691">MazdaSpeed Miata MX-5</option>
          <option value="6788">MazdaSpeed Protege</option>
          <option value="8376">MazdaSpeed3</option>
          <option value="7751">MazdaSpeed6</option>
          <option value="5127">MDX</option>
          <option value="157">Medallion</option>
          <option value="3221">Metro</option>
          <option value="278">Miata MX-5</option>
          <option value="7834">Milan</option>
          <option value="12">Milano</option>
          <option value="280">Millenia</option>
          <option value="136">Mini Ram</option>
          <option value="320">Minivan</option>
          <option value="511">Mirada</option>
          <option value="313">Mirage</option>
          <option value="9192">MKS</option>
          <option value="8238">MKX</option>
          <option value="8316">MKZ</option>
          <option value="137">Monaco</option>
          <option value="1415">Mondial</option>
          <option value="6389">Mondial t</option>
          <option value="3157">Montana</option>
          <option value="7661">Montana SV6</option>
          <option value="93">Monte Carlo</option>
          <option value="3757">Montego</option>
          <option value="3742">Monterey</option>
          <option value="314">Montero</option>
          <option value="3137">Montero Sport</option>
          <option value="299">Mountaineer</option>
          <option value="276">MPV</option>
          <option value="429">MR2</option>
          <option value="3237">Mulsanne</option>
          <option value="6028">Mulsanne S</option>
          <option value="6029">Mulsanne Turbo</option>
          <option value="6868">Murano</option>
          <option value="6448">Murcielago</option>
          <option value="179">Mustang</option>
          <option value="277">MX-3</option>
          <option value="279">MX-6</option>
          <option value="8314">MXT</option>
          <option value="300">Mystique</option>
          <option value="281">Navajo</option>
          <option value="266">Navigator</option>
          <option value="512">Neon</option>
          <option value="8971">New Cabrio</option>
          <option value="118">New Yorker</option>
          <option value="355">Ninety-Eight</option>
          <option value="8271">Nitro</option>
          <option value="94">Nova</option>
          <option value="4">NSX</option>
          <option value="2737">Nubira</option>
          <option value="334">NX</option>
          <option value="234">Oasis</option>
          <option value="215">Odyssey</option>
          <option value="534">Omega</option>
          <option value="138">Omni</option>
          <option value="5448">Optima</option>
          <option value="2996">Outback</option>
          <option value="6708">Outlander</option>
          <option value="8378">Outlook</option>
          <option value="6628">Pacifica</option>
          <option value="7108">Pantera</option>
          <option value="381">Parisienne</option>
          <option value="57">Park Avenue</option>
          <option value="5528">Park Ward</option>
          <option value="430">Paseo</option>
          <option value="449">Passat</option>
          <option value="216">Passport</option>
          <option value="335">Pathfinder</option>
          <option value="8373">Patriot</option>
          <option value="6968">Phaeton</option>
          <option value="7219">Phantom</option>
          <option value="8817">Phantom Drophead Coupe</option>
          <option value="548">Phoenix</option>
          <option value="525">Pickup</option>
          <option value="6528">Pilot</option>
          <option value="6188">Pininfarina</option>
          <option value="7230">Plus 8</option>
          <option value="316">Precis</option>
          <option value="217">Prelude</option>
          <option value="158">Premier</option>
          <option value="434">Previa</option>
          <option value="2916">Prius</option>
          <option value="1300">Prizm</option>
          <option value="184">Probe</option>
          <option value="283">Protege</option>
          <option value="5827">Protege5</option>
          <option value="368">Prowler</option>
          <option value="4667">PT Cruiser</option>
          <option value="337">Pulsar</option>
          <option value="228">Q45</option>
          <option value="8232">Q7</option>
          <option value="6489">Quadrifoglio</option>
          <option value="450">Quantum</option>
          <option value="3402">Quattro</option>
          <option value="4227">Quattroporte</option>
          <option value="338">Quest</option>
          <option value="229">QX4</option>
          <option value="7511">QX56</option>
          <option value="7891">R-Class</option>
          <option value="7468">R32</option>
          <option value="4170">R8</option>
          <option value="562">Rabbit</option>
          <option value="148">Raider</option>
          <option value="7213">Rainier</option>
          <option value="199">Rally</option>
          <option value="1292">Ram 1500</option>
          <option value="9347">Ram 2500</option>
          <option value="9348">Ram 3500</option>
          <option value="9315">Ram 50</option>
          <option value="149">Ram Van</option>
          <option value="150">Ram Wagon</option>
          <option value="151">Ramcharger</option>
          <option value="513">Rampage</option>
          <option value="256">Range Rover</option>
          <option value="7991">Range Rover Sport</option>
          <option value="183">Ranger</option>
          <option value="435">RAV4</option>
          <option value="8231">RDX</option>
          <option value="58">Reatta</option>
          <option value="59">Regal</option>
          <option value="356">Regency</option>
          <option value="7657">Relay</option>
          <option value="369">Reliant</option>
          <option value="5407">Rendezvous</option>
          <option value="7663">Reno</option>
          <option value="7791">Ridgeline</option>
          <option value="5048">Rio</option>
          <option value="8131">Rio5</option>
          <option value="60">Riviera</option>
          <option value="5">RL</option>
          <option value="61">Roadmaster</option>
          <option value="4808">Roadster</option>
          <option value="123">Rocky</option>
          <option value="235">Rodeo</option>
          <option value="5327">Rodeo Sport</option>
          <option value="4082">Rogue</option>
          <option value="8651">Rondo</option>
          <option value="9274">Routan</option>
          <option value="8233">RS 4</option>
          <option value="7028">RS6</option>
          <option value="5787">RSX</option>
          <option value="412">RX</option>
          <option value="1291">RX 300</option>
          <option value="7209">RX 330</option>
          <option value="8351">RX 350</option>
          <option value="7658">RX 400h</option>
          <option value="284">RX-7</option>
          <option value="6388">RX-8</option>
          <option value="7814">RXT</option>
          <option value="5067">S-10</option>
          <option value="77">S-10 Blazer</option>
          <option value="191">S-15 Jimmy</option>
          <option value="195">S-15 Pickup</option>
          <option value="289">S-Class</option>
          <option value="3217">S-Type</option>
          <option value="4387">S2000</option>
          <option value="28">S4</option>
          <option value="4388">S40</option>
          <option value="8813">S5</option>
          <option value="29">S6</option>
          <option value="5207">S60</option>
          <option value="7531">S7</option>
          <option value="327">S70</option>
          <option value="5248">S8</option>
          <option value="2756">S80</option>
          <option value="463">S90</option>
          <option value="301">Sable</option>
          <option value="200">Safari</option>
          <option value="417">Samurai</option>
          <option value="5148">Santa Fe</option>
          <option value="543">Sapporo</option>
          <option value="201">Savana 1500</option>
          <option value="9619">Savana 2500</option>
          <option value="9620">Savana 3500</option>
          <option value="394">SC</option>
          <option value="263">SC 300</option>
          <option value="264">SC 400</option>
          <option value="5447">SC 430</option>
          <option value="544">Scamp</option>
          <option value="451">Scirocco</option>
          <option value="623">Scorpio</option>
          <option value="221">Scoupe</option>
          <option value="6168">Scrambler</option>
          <option value="119">Sebring</option>
          <option value="5469">Sedona</option>
          <option value="339">Sentra</option>
          <option value="250">Sephia</option>
          <option value="5307">Sequoia</option>
          <option value="72">Seville</option>
          <option value="152">Shadow</option>
          <option value="418">Sidekick</option>
          <option value="436">Sienna</option>
          <option value="196">Sierra 1500</option>
          <option value="9433">Sierra 2500</option>
          <option value="9434">Sierra 3500</option>
          <option value="9451">Sierra1500 Hybrid</option>
          <option value="317">Sigma</option>
          <option value="357">Silhouette</option>
          <option value="2896">Silver Seraph</option>
          <option value="637">Silver Spirit</option>
          <option value="638">Silver Spur</option>
          <option value="2757">Silverado 1500</option>
          <option value="9394">Silverado 2500</option>
          <option value="9395">Silverado 3500</option>
          <option value="9411">Silverado1500 Hybrid</option>
          <option value="73">Sixty Special</option>
          <option value="7837">Sky</option>
          <option value="62">Skyhawk</option>
          <option value="63">Skylark</option>
          <option value="397">SL</option>
          <option value="292">SL-Class</option>
          <option value="293">SLK-Class</option>
          <option value="7593">SLR McLaren</option>
          <option value="6">SLX</option>
          <option value="7664">Solstice</option>
          <option value="64">Somerset</option>
          <option value="222">Sonata</option>
          <option value="197">Sonoma</option>
          <option value="6908">Sorento</option>
          <option value="4827">Spectra</option>
          <option value="7671">Spectra5</option>
          <option value="102">Spectrum</option>
          <option value="13">Spider</option>
          <option value="4910">Spider 2000</option>
          <option value="153">Spirit</option>
          <option value="554">Sport Wagon</option>
          <option value="251">Sportage</option>
          <option value="103">Sportvan</option>
          <option value="104">Sprint</option>
          <option value="7148">Sprinter</option>
          <option value="6208">Spyder</option>
          <option value="6608">SRX</option>
          <option value="7168">SSR</option>
          <option value="340">Stanza</option>
          <option value="318">Starion</option>
          <option value="558">Starlet</option>
          <option value="414">STD</option>
          <option value="154">Stealth</option>
          <option value="210">Storm</option>
          <option value="155">Stratus</option>
          <option value="7654">STS</option>
          <option value="236">Stylus</option>
          <option value="105">Suburban</option>
          <option value="159">Summit</option>
          <option value="383">Sunbird</option>
          <option value="370">Sundance</option>
          <option value="384">Sunfire</option>
          <option value="5988">Super V8</option>
          <option value="8151">Super V8 Portfolio</option>
          <option value="437">Supra</option>
          <option value="413">SVX</option>
          <option value="5170">SW</option>
          <option value="420">Swift</option>
          <option value="8379">SX4</option>
          <option value="432">T100</option>
          <option value="433">Tacoma</option>
          <option value="106">Tahoe</option>
          <option value="8934">Tahoe Hybrid</option>
          <option value="161">Talon</option>
          <option value="185">Taurus</option>
          <option value="8811">Taurus X</option>
          <option value="7656">tC</option>
          <option value="120">TC</option>
          <option value="186">Tempo</option>
          <option value="438">Tercel</option>
          <option value="7632">Terraza</option>
          <option value="1416">Testarossa</option>
          <option value="187">Thunderbird</option>
          <option value="223">Tiburon</option>
          <option value="9193">Tiguan</option>
          <option value="7220">Titan</option>
          <option value="7">TL</option>
          <option value="302">Topaz</option>
          <option value="358">Toronado</option>
          <option value="7835">Torrent</option>
          <option value="7008">Touareg</option>
          <option value="8832">Touareg 2</option>
          <option value="121">Town & Country</option>
          <option value="270">Town Car</option>
          <option value="303">Tracer</option>
          <option value="2936">Tracker</option>
          <option value="5487">TrailBlazer</option>
          <option value="7208">TrailBlazer EXT</option>
          <option value="385">Trans Sport</option>
          <option value="9271">Traverse</option>
          <option value="319">Tredia</option>
          <option value="8891">Tribeca</option>
          <option value="5027">Tribute</option>
          <option value="8936">Tribute Hybrid</option>
          <option value="237">Trooper</option>
          <option value="7070">TSX</option>
          <option value="3218">TT</option>
          <option value="9771">TTS</option>
          <option value="7633">Tucson</option>
          <option value="3238">Tundra</option>
          <option value="3337">Turbo R</option>
          <option value="6368">Turbo RL</option>
          <option value="3339">Turbo RT</option>
          <option value="3338">Turbo S</option>
          <option value="371">Turismo</option>
          <option value="3482">Type 57</option>
          <option value="7072">Type 62</option>
          <option value="7635">Uplander</option>
          <option value="5527">V12 Vanquish</option>
          <option value="6511">V20</option>
          <option value="6512">V30</option>
          <option value="4389">V40</option>
          <option value="7653">V50</option>
          <option value="1308">V70</option>
          <option value="8211">V8 Vantage</option>
          <option value="464">V90</option>
          <option value="107">Van</option>
          <option value="452">Vanagon</option>
          <option value="1302">Vanden Plas</option>
          <option value="204">Vandura</option>
          <option value="3220">Vantage</option>
          <option value="2976">VehiCROSS</option>
          <option value="108">Venture</option>
          <option value="9273">Venza</option>
          <option value="8691">Veracruz</option>
          <option value="7216">Verona</option>
          <option value="8241">Versa</option>
          <option value="5850">Vibe</option>
          <option value="8">Vigor</option>
          <option value="304">Villager</option>
          <option value="156">Viper</option>
          <option value="6688">Virage</option>
          <option value="162">Vision</option>
          <option value="3357">Vitara</option>
          <option value="372">Voyager</option>
          <option value="5764">Vue</option>
          <option value="8933">Vue Green Line</option>
          <option value="9472">Vue Hybrid</option>
          <option value="9316">W100</option>
          <option value="9317">W150</option>
          <option value="9318">W250</option>
          <option value="9319">W350</option>
          <option value="528">Wagoneer</option>
          <option value="188">Windstar</option>
          <option value="249">Wrangler</option>
          <option value="9591">Wrangler Unlimited</option>
          <option value="421">X-90</option>
          <option value="5828">X-Type</option>
          <option value="519">X1/9</option>
          <option value="7368">X3</option>
          <option value="3197">X5</option>
          <option value="9231">X6</option>
          <option value="7217">xA</option>
          <option value="7218">xB</option>
          <option value="6928">XC70</option>
          <option value="6308">XC90</option>
          <option value="8819">xD</option>
          <option value="9151">XF</option>
          <option value="5149">XG300</option>
          <option value="6048">XG350</option>
          <option value="4041">XJ</option>
          <option value="238">XJ12</option>
          <option value="239">XJ6</option>
          <option value="473">XJ8</option>
          <option value="240">XJR</option>
          <option value="8171">XJR-S</option>
          <option value="241">XJS</option>
          <option value="8251">XK</option>
          <option value="242">XK8</option>
          <option value="4569">XKR</option>
          <option value="5467">XL7</option>
          <option value="7030">XLR</option>
          <option value="622">XR4Ti</option>
          <option value="415">XT</option>
          <option value="3318">Xterra</option>
          <option value="8242">Yaris</option>
          <option value="461">Yukon</option>
          <option value="8935">Yukon Hybrid</option>
          <option value="5087">Yukon XL</option>
          <option value="50">Z3</option>
          <option value="6808">Z4</option>
          <option value="9011">Z4 M</option>
          <option value="4787">Z8</option>
          <option value="7328">Zagato</option>
          <option value="532">Zephyr</option>
          <option value="5887">ZX2</option>
        </select></td>
        <td width="22"> </td>
        <td width="225" id="rightSearchCol"> </td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span class="spanlabel">Year</span></td>
        <td valign="top" align="right"> </td>
        <td valign="top"><select class="vehicledropdown" name="year" id="year" size="5" >
            <option value="">All</option>
            <option value="2010">2010</option>
            <option value="2009">2009</option>
            <option value="2008">2008</option>
            <option value="2007">2007</option>
            <option value="2006">2006</option>
            <option value="2005">2005</option>
            <option value="2004">2004</option>
            <option value="2003">2003</option>
            <option value="2002">2002</option>
            <option value="2001">2001</option>
            <option value="2000">2000</option>
            <option value="1999">1999</option>
            <option value="1998">1998</option>
            <option value="1997">1997</option>
            <option value="1996">1996</option>
            <option value="1995">1995</option>
            <option value="1994">1994</option>
            <option value="1993">1993</option>
            <option value="1992">1992</option>
            <option value="1991">1991</option>
            <option value="1990">1990</option>
            <option value="1989">1989</option>
            <option value="1988">1988</option>
            <option value="1987">1987</option>
            <option value="1986">1986</option>
            <option value="1985">1985</option>
            <option value="1984">1984</option>
            <option value="1983">1983</option>
          </select></td>
        <td valign="top" align="center"></td>
        <td valign="top" align="left"></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td align="right"><span class="spanlabel">Price Range</span></td>
        <td align="right"> </td>
        <td valign="top" colspan="3"><select class="rangemin" id="minp" name="minp">
            <option selected="selected" value="">$0</option>
            <option value="1000">$1,000</option>
            <option value="2000">$2,000</option>
            <option value="3000">$3,000</option>
            <option value="4000">$4,000</option>
            <option value="5000">$5,000</option>
            <option value="6000">$6,000</option>
            <option value="7000">$7,000</option>
            <option value="8000">$8,000</option>
            <option value="9000">$9,000</option>
            <option value="10000">$10,000</option>
            <option value="11000">$11,000</option>
            <option value="12000">$12,000</option>
            <option value="13000">$13,000</option>
            <option value="14000">$14,000</option>
            <option value="15000">$15,000</option>
            <option value="16000">$16,000</option>
            <option value="17000">$17,000</option>
            <option value="18000">$18,000</option>
            <option value="19000">$19,000</option>
            <option value="20000">$20,000</option>
            <option value="21000">$21,000</option>
            <option value="22000">$22,000</option>
            <option value="23000">$23,000</option>
            <option value="24000">$24,000</option>
            <option value="25000">$25,000</option>
            <option value="30000">$30,000</option>
            <option value="35000">$35,000</option>
            <option value="40000">$40,000</option>
            <option value="45000">$45,000</option>
            <option value="50000">$50,000</option>
            <option value="55000">$55,000</option>
            <option value="60000">$60,000</option>
            <option value="65000">$65,000</option>
            <option value="70000">$70,000</option>
            <option value="75000">$75,000</option>
            <option value="80000">$80,000</option>
            <option value="85000">$85,000</option>
            <option value="90000">$90,000</option>
            <option value="95000">$95,000</option>
            <option value="100000">$100,000</option>
          </select>
          <span id="to2">to</span>
          <select class="rangemax" id="maxp" name="maxp">
            <option selected="selected" value="">No Maximum</option>
            <option value="1000">$1,000</option>
            <option value="2000">$2,000</option>
            <option value="3000">$3,000</option>
            <option value="4000">$4,000</option>
            <option value="5000">$5,000</option>
            <option value="6000">$6,000</option>
            <option value="7000">$7,000</option>
            <option value="8000">$8,000</option>
            <option value="9000">$9,000</option>
            <option value="10000">$10,000</option>
            <option value="11000">$11,000</option>
            <option value="12000">$12,000</option>
            <option value="13000">$13,000</option>
            <option value="14000">$14,000</option>
            <option value="15000">$15,000</option>
            <option value="16000">$16,000</option>
            <option value="17000">$17,000</option>
            <option value="18000">$18,000</option>
            <option value="19000">$19,000</option>
            <option value="20000">$20,000</option>
            <option value="21000">$21,000</option>
            <option value="22000">$22,000</option>
            <option value="23000">$23,000</option>
            <option value="24000">$24,000</option>
            <option value="25000">$25,000</option>
            <option value="30000">$30,000</option>
            <option value="35000">$35,000</option>
            <option value="40000">$40,000</option>
            <option value="45000">$45,000</option>
            <option value="50000">$50,000</option>
            <option value="55000">$55,000</option>
            <option value="60000">$60,000</option>
            <option value="65000">$65,000</option>
            <option value="70000">$70,000</option>
            <option value="75000">$75,000</option>
            <option value="80000">$80,000</option>
            <option value="85000">$85,000</option>
            <option value="90000">$90,000</option>
            <option value="95000">$95,000</option>
            <option value="100000">$100,000</option>
            <option value="100000000">$100,000 +</option>
          </select></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td align="right"><span class="spanlabel">Mileage Range</span></td>
        <td align="right"> </td>
        <td valign="top" colspan="3"><select class="rangemin" id="minmiles" name="minmiles">
            <option selected="selected" value="">0</option>
            <option value="10000">10,000</option>
            <option value="20000">20,000</option>
            <option value="30000">30,000</option>
            <option value="40000">40,000</option>
            <option value="50000">50,000</option>
            <option value="60000">60,000</option>
            <option value="70000">70,000</option>
            <option value="80000">80,000</option>
            <option value="90000">90,000</option>
            <option value="100000">100,000</option>
          </select>
          to
          <select class="rangemax" id="maxmiles" name="maxmiles">
            <option selected="selected" value="">No Maximum</option>
            <option value="10000">10,000</option>
            <option value="20000">20,000</option>
            <option value="30000">30,000</option>
            <option value="40000">40,000</option>
            <option value="50000">50,000</option>
            <option value="60000">60,000</option>
            <option value="70000">70,000</option>
            <option value="80000">80,000</option>
            <option value="90000">90,000</option>
            <option value="100000">100,000</option>
            <option value="10000000">100,000 +</option>
          </select></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span class="spanlabel">Search within</span></td>
        <td> </td>
        <td valign="top" colspan="3" class="controllabel"><select class="controltext" id="radius" name="radius">
            <option value="10">10</option>
            <option value="20">20</option>
            <option selected="selected" value="30">30</option>
            <option value="40">40</option>
            <option value="50">50</option>
            <option value="75">75</option>
            <option value="100">100</option>
            <option value="150">150</option>
            <option value="250">250</option>
            <option value="500">500</option>
            <option value="10000">All</option>
          </select>
          miles of ZIP Code  <span id="zipcodeFieldContainer">
          <input type="text" value="78757" class="controltext" maxlength="5" size="8" id="zipcode" name="zipcode"/>
          </span>
          <p id="orText">— OR — </p>
          <select onchange="updateZip()" class="controltext" name="citylist">
            <option value="">Choose a City</option>
            <option value="60606|All">National Search</option>
            <option value="57401|50">Aberdeen, South Dakota</option>
            <option value="44308|50">Akron, Ohio</option>
            <option value="88310|150">Alamogordo, New Mexico</option>
            <option value="12202|30">Albany, New York</option>
            <option value="87101|30">Albuquerque, New Mexico</option>
            <option value="18102|50">Allentown, Pennsylvania</option>
            <option value="99501|500">Anchorage, Alaska</option>
            <option value="54911|50">Appleton, Wisconsin</option>
            <option value="28801|50">Asheville, North Carolina</option>
            <option value="30303|30">Atlanta, Georgia</option>
            <option value="30901|30">Augusta, Georgia</option>
            <option value="78757|30">Austin, Texas</option>
            <option value="93302|45">Bakersfield, California</option>
            <option value="21204|40">Baltimore, Maryland</option>
            <option value="70801|30">Baton Rogue, Louisiana</option>
            <option value="49017|20">Battle Creek, Michigan</option>
            <option value="29901|100">Beaufort, South Carolina</option>
            <option value="62220|40">Belleville, Illinois</option>
            <option value="98225|30">Bellingham, Washington</option>
            <option value="39507|50">Biloxi, Mississippi</option>
            <option value="13850|50">Binghamton, New York</option>
            <option value="35203|30">Birmingham, Alabama</option>
            <option value="83706|100">Boise, Idaho</option>
            <option value="02118|30">Boston, Massachusetts</option>
            <option value="34205|40">Brandenton, Florida</option>
            <option value="44820|50">Bucyrus, Ohio</option>
            <option value="14202|30">Buffalo, New York</option>
            <option value="05403|100">Burlington, Vermont</option>
            <option value="44702|30">Canton, Ohio</option>
            <option value="88221|150">Carlsbad, New Mexico</option>
            <option value="17201|30">Chambersburg, Pennsylvania</option>
            <option value="61820|30">Champaign, Illinois</option>
            <option value="29401|30">Charleston, South Carolina</option>
            <option value="28212|50">Charlotte, North Carolina</option>
            <option value="37402|30">Chattanooga, Tennessee</option>
            <option value="60606|40">Chicago, Illinois</option>
            <option value="45601|50">Chillicothe, Ohio</option>
            <option value="45202|20">Cincinnati, Ohio</option>
            <option value="37040|30">Clarksville, Tennessee</option>
            <option value="44114|30">Cleveland, Ohio</option>
            <option value="29201|50">Columbia, South Carolina</option>
            <option value="31906|20">Columbus, Georgia</option>
            <option value="43215|30">Columbus, Ohio</option>
            <option value="78401|30">Corpus Christi, Texas</option>
            <option value="94598|50">Contra Costa Co., California</option>
            <option value="43812|50">Coshocton, Ohio</option>
            <option value="75202|30">Dallas, Texas</option>
            <option value="45402|30">Dayton, Ohio</option>
            <option value="88030|150">Deming, New Mexico</option>
            <option value="80202|30">Denver, Colorado</option>
            <option value="50310|100">Des Moines, Iowa</option>
            <option value="48009|50">Detroit, Michigan</option>
            <option value="55802|20">Duluth, Minnesota</option>
            <option value="79901|75">El Paso, Texas</option>
            <option value="14902|50">Elmira, New York</option>
            <option value="47708|30">Evansville, Indiana</option>
            <option value="94533|30">Fairfield, California</option>
            <option value="87499|150">Farmington, New Mexico</option>
            <option value="48502|30">Flint, Michigan</option>
            <option value="54936|50">Fond du Lac, Wisconsin</option>
            <option value="80526|50">Ft. Collins, Colorado</option>
            <option value="33304|20">Ft. Lauderdale/Palm Beach, Fla.</option>
            <option value="33901|30">Ft. Myers, Florida</option>
            <option value="46802|40">Ft. Wayne, Indiana</option>
            <option value="76011|50">Ft. Worth, Texas</option>
            <option value="43420|50">Fremont, Ohio</option>
            <option value="93786|50">Fresno, California</option>
            <option value="30501|50">Gainesville, Georgia</option>
            <option value="58201|50">Grand Forks, North Dakota</option>
            <option value="49503|30">Grand Rapids, Michigan</option>
            <option value="59401|50">Great Falls, Montana</option>
            <option value="54301|50">Green Bay, Wisconsin</option>
            <option value="27407|50">Greensboro, North Carolina</option>
            <option value="29607|50">Greenville, South Carolina</option>
            <option value="23501|50">Hampton Roads, Virginia</option>
            <option value="17102|30">Harrisburg, Pennsylvania</option>
            <option value="06115|50">Hartford, Connecticut</option>
            <option value="39401|30">Hattiesburg, Mississippi</option>
            <option value="29928|20">Hilton Head, South Carolina</option>
            <option value="96816|250">Honolulu, Hawaii</option>
            <option value="77036|30">Houston, Texas</option>
            <option value="25701|30">Huntington, West Virginia</option>
            <option value="02601|30">Hyannis (Cape Cod), MA</option>
            <option value="46202|30">Indianapolis, Indiana</option>
            <option value="52245|50">Iowa City, Iowa</option>
            <option value="14850|30">Ithaca, New York</option>
            <option value="38392|50">Jackson, Louisiana</option>
            <option value="39201|50">Jackson, Mississippi</option>
            <option value="32202|30">Jacksonville, Florida</option>
            <option value="49007|30">Kalamazoo, Michigan</option>
            <option value="64108|75">Kansas City, Missouri</option>
            <option value="37902|30">Knoxville, Tennessee</option>
            <option value="47905|40">Lafayette, Indiana</option>
            <option value="70502|30">Lafayette, Louisiana</option>
            <option value="43130|50">Lancaster, Ohio</option>
            <option value="48910|30">Lansing, Michigan</option>
            <option value="88004|150">Las Cruces, New Mexico</option>
            <option value="89109|30">Las Vegas, Nevada</option>
            <option value="40508|50">Lexington, Kentucky</option>
            <option value="72209|30">Little Rock, Arkansas</option>
            <option value="90053|50">Los Angeles, California</option>
            <option value="40202|50">Louisville, Kentucky</option>
            <option value="31210|50">Macon, Georgia</option>
            <option value="53703|30">Madison, Wisconsin</option>
            <option value="54220|50">Manitowoc, Wisconsin</option>
            <option value="44901|50">Mansfield, Ohio</option>
            <option value="45750|30">Marieta, Ohio</option>
            <option value="94948|30">Marin, California</option>
            <option value="46952|50">Marion, Indiana</option>
            <option value="43302|50">Marion, Ohio</option>
            <option value="54449|50">Marshfield, Wisconsin</option>
            <option value="32940|30">Melbourne, Florida</option>
            <option value="38103|30">Memphis, Tennessee</option>
            <option value="33132|50">Miami, Florida</option>
            <option value="53201|30">Milwaukee, Wisconsin</option>
            <option value="55488|50">Minneapolis, Minnesota</option>
            <option value="95352|30">Modesto, California</option>
            <option value="71201|50">Monroe, Louisiana</option>
            <option value="36117|75">Montgomery, Alabama</option>
            <option value="72654|20">Mountain Home, Arkansas</option>
            <option value="47305|30">Muncie, Indiana</option>
            <option value="49440|30">Muskegon, Michigan</option>
            <option value="29577|75">Myrtle Beach, South Carolina</option>
            <option value="37201|50">Nashville, Tennessee</option>
            <option value="43055|50">Newark, Ohio</option>
            <option value="70116|30">New Orleans, Louisiana</option>
            <option value="10118|20">New York City, New York</option>
            <option value="06360|50">Norwich, Connecticut</option>
            <option value="73102|30">Oklahoma City, Oklahoma</option>
            <option value="98506|30">Olympia, Washington</option>
            <option value="68102|30">Omaha, Nebraska</option>
            <option value="32801|50">Orlando, Florida</option>
            <option value="54901|50">Oshkosh, Wisconsin</option>
            <option value="42001|30">Paducah, Kentucky</option>
            <option value="92260|30">Palm Springs, California</option>
            <option value="32504|50">Pensacola, Florida</option>
            <option value="23806|30">Petersburg, Virginia</option>
            <option value="19130|40">Philadelphia, Pennsylvania</option>
            <option value="85004|50">Phoenix, Arizona</option>
            <option value="15219|30">Pittsburgh, Pennsylvania</option>
            <option value="48060|50">Port Huron, Michigan</option>
            <option value="97201|30">Portland, Oregon</option>
            <option value="12602|50">Poughkeepsie, New York</option>
            <option value="36006|50">Prattville, Alabama</option>
            <option value="02902|30">Providence, Rhode Island</option>
            <option value="27609|50">Raleigh/Durham/Chapel Hill, N.C.</option>
            <option value="89509|50">Reno, Nevada</option>
            <option value="47374|50">Richmond, Indiana</option>
            <option value="23173|30">Richmond, Virginia</option>
            <option value="92501|30">Riverside, California</option>
            <option value="24011|30">Roanoke, Virginia</option>
            <option value="14614|50">Rochester, New York</option>
            <option value="29730|50">Rock Hill, South Carolina</option>
            <option value="61104|30">Rockford, Illinois</option>
            <option value="95814|50">Sacramento, California</option>
            <option value="97301|30">Salem, Oregon</option>
            <option value="93901|30">Salinas, California</option>
            <option value="21801|30">Salisbury, Maryland</option>
            <option value="84111|30">Salt Lake City, Utah</option>
            <option value="56301|30">St. Cloud, Minnesota</option>
            <option value="84770|50">St. George, Utah</option>
            <option value="63102|30">St. Louis, Missouri</option>
            <option value="55101|50">St. Paul, Minnesota</option>
            <option value="78205|30">San Antonio, Texas</option>
            <option value="92108|30">San Diego, California</option>
            <option value="94102|30">San Francisco, California</option>
            <option value="95113|50">San Jose, California</option>
            <option value="93401|50">San Luis Obispo, California</option>
            <option value="95401|30">Santa Rosa, California</option>
            <option value="34236|40">Sarasota, Florida</option>
            <option value="31401|30">Savannah, Georgia</option>
            <option value="98109|30">Seattle, Washington</option>
            <option value="98405|50">Seattle-Tacoma, Washington</option>
            <option value="53082|50">Sheboygan, Wisconsin</option>
            <option value="71106|75">Shreveport, Louisiana</option>
            <option value="88061|150">Silver City, New Mexico</option>
            <option value="57106|75">Sioux Falls, South Dakota</option>
            <option value="46601|50">South Bend, Indiana</option>
            <option value="33067|50">South Florida</option>
            <option value="08009|30">Southern New Jersey</option>
            <option value="99203|30">Spokane, Washington</option>
            <option value="65806|50">Springfield, Missouri</option>
            <option value="24401|50">Staunton, Virginia</option>
            <option value="54481|50">Stevens Point, Wisconsin</option>
            <option value="13202|30">Syracuse, New York</option>
            <option value="32302|50">Tallahassee, Florida</option>
            <option value="33602|30">Tampa, Florida</option>
            <option value="47801|30">Terre Haute, Indiana</option>
            <option value="43601|30">Toledo, Ohio</option>
            <option value="07728|40">Toms River, New Jersey</option>
            <option value="85711|50">Tucson, Arizona</option>
            <option value="74103|30">Tulsa, Oklahoma</option>
            <option value="13501|30">Utica, New York</option>
            <option value="76701|30">Waco, Texas</option>
            <option value="94595|30">Walnut Creek, California</option>
            <option value="20006|30">Washington, D.C.</option>
            <option value="54401|75">Wausau, Wisconsin</option>
            <option value="67201|50">Wichita, Kansas</option>
            <option value="18711|50">Wilkes Barre, Pennsylvania</option>
            <option value="19720|40">Wilmington, Delaware</option>
            <option value="54495|50">Wisconsin Rapids, Wisconsin</option>
            <option value="01615|50">Worcester, Massachusetts</option>
            <option value="43701|50">Zanesville, Ohio</option>
          </select></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span id="optSearch" class="spanlabel">Optional<br/>
          Search Words</span></td>
        <td valign="center" align="right"> </td>
        <td valign="top" colspan="3"><input type="text" value="" maxlength="50" class="controltext" name="keywords"/>
          <select name="keyword_modifier" class="controltext">
            <option value="ANY">Match Any Words</option>
            <option selected="selected" value="ALL">Match All Words</option>
            <option value="EXACT">Match Exact Phrase</option>
          </select>
          <div id="egNote" class="note">e.g. manual diesel (do not include commas)</div></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span id="findAct" class="spanlabel">Find active listings<br/>
          placed within</span></td>
        <td valign="center" align="right"> </td>
        <td valign="top" colspan="3"><select id="listingdate" name="mindate" class="controltext">
            <option selected="selected" value="">All Dates </option>
            <option value="1">Last 1 Day </option>
            <option value="3">Last 3 Days </option>
            <option value="7">Last 7 Days </option>
            <option value="14">Last 2 Weeks </option>
            <option value="30">Last Month </option>
          </select></td>
      </tr>
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span id="ppFilter" class="spanlabel">Include</span></td>
        <td valign="center" align="right"> </td>
        <td colspan="3"><input type="radio" checked=""  id="radio1" class="advRadio" value="" name="privatePartyFilter"/>
          <label class="radioLabel" for="radio1">All Listing Types</label>
          <input type="radio" id="radio2" class="advRadio" value="true" name="privatePartyFilter"/>
          <label class="radioLabel" for="radio2">Private Seller + Classified</label>
          <div style="display: none;" id="listingTypeInputs">
            <input type="hidden" value="" name="ppFilterOn"/>
          </div></td>
      </tr>

      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span class="spanlabel">Display</span></td>
        <td valign="center" align="right"> </td>
        <td valign="top" colspan="3"><select class="controltext" name="numResultsPerPage">
            <option value="10">10</option>
            <option value="20">20</option>
            <option value="30">30</option>
            <option selected="selected" value="50">50</option>
            <option value="100">100</option>
            <option value="250">250</option>
          </select>
          <span id="perPage" class="spanlabel">listings per page</span>
          <div id="noteDisplay" class="note">Note: Displaying all available listings on a page could require a large download.</div></td>
      </tr>
      
      <tr>
        <td colspan="5"><div class="spacer"> </div></td>
      </tr>
      <tr>
        <td valign="top" align="right"><span id="srcFilter" class="spanlabel">Search Option</span></td>
        <td valign="center" align="right"> </td>
        <td colspan="3"><input type="radio" checked=""  id="normalsearch" class="advRadio" value="normal" name="mode"/>
          <label class="radioLabel" for="normalsearch">Normal</label>
          <input type="radio" id="extendedsearch" class="advRadio" value="extended" name="mode"/>
          <label class="radioLabel" for="extendedsearch">Extended</label>
		</td>
      </tr>
      
      <tr>
        <td valign="top"> </td>
        <td valign="top"> </td>
        <td valign="middle" colspan="3"><br/>
          <div id="action">
            <div class="BttnPill"><span class="bttntxt">
              <input name="Search" type="submit" value="submit" />
            </span><span class="bttncap"/></div>
          </div>
          </td>
      </tr>
    </tbody>
    
  </table>
</form>
</body>
</html>
