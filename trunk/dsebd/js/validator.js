$(document).ready( function() {   
    $('#anytype').click( function() {
		$('#Power').css('display', 'none');
		$('#SmallBoats').css('display', 'none');
		$('#Sail').css('display', 'none');
    });
	$('#Powertype').click( function() {
		$('#Power').css('display', 'block');
		$('#SmallBoats').css('display', 'none');
		$('#Sail').css('display', 'none');
    });
	$('#Sailtype').click( function() {
   		$('#Power').css('display', 'none');
		$('#SmallBoats').css('display', 'none');
		$('#Sail').css('display', 'block');
    });
			    
	$('#SmallBoatstype').click( function() {
   		$('#Power').css('display', 'none');
		$('#SmallBoats').css('display', 'block');
		$('#Sail').css('display', 'none');
    });
	
	$('#PWCtype').click( function() {
		$('#Power').css('display', 'none');
		$('#SmallBoats').css('display', 'none');
		$('#Sail').css('display', 'none');        
    });
	
	$('#rbzipCode').click( function() {
		$('#zip').css('display', 'block');
		$('#state').css('display', 'none');
		$('#region').css('display', 'none');        
		$('#country').css('display', 'none');        		
    });
	$('#rbstateCode').click( function() {
		$('#zip').css('display', 'none');
		$('#state').css('display', 'block');
		$('#region').css('display', 'none');        
		$('#country').css('display', 'none');        		
    });	
	$('#rbregionCode').click( function() {
		$('#zip').css('display', 'none');
		$('#state').css('display', 'none');
		$('#region').css('display', 'block');        
		$('#country').css('display', 'none');        		
    });
	$('#rbcountryCode').click( function() {
		$('#zip').css('display', 'none');
		$('#state').css('display', 'none');
		$('#region').css('display', 'none');        
		$('#country').css('display', 'block');        		
    });	
	
	$('#lYear').change( function() {
		var year = $('#lYear').val();
		var strHtml = '';
		if(year!="Any")
		{
			var intYear = parseInt(year);
			for (; intYear <= 2008; intYear++)
				strHtml += '<option value="' + intYear + '">' + intYear + '</option>';
			strHtml += '<option value="2009" selected>2009</option>';
		}
		else
		{
			strHtml = '<option value="Any" selected>Any</option>';
		}
		$("#hYear").html(strHtml);
    });	
	
    $('A[rel="search"]').click( function() {
		var url = "http://www.boattrader.com/search-results";

		//Processing Status
		var typeRadio = $("input:radio[@name=rb_Status]:checked");
		url += typeRadio.attr("url") + typeRadio.val();

		//Processing BoatsType
		typeRadio = $("input:radio[@name=rb_CustomSelectionType]:checked");
		if(typeRadio.attr("id")=="anytype")
		{
			url += typeRadio.attr("url") + typeRadio.val();
		}
		else if(typeRadio.attr("id")=="Powertype")
		{
			url += typeRadio.attr("url") + typeRadio.val();
			url += $("#typepower").attr("url") + $("#typepower").val();
		}
		else if(typeRadio.attr("id")=="Sailtype")
		{
			url += typeRadio.attr("url") + typeRadio.val();
			url += $("#typesail").attr("url") + $("#typesail").val();
		}
		else if(typeRadio.attr("id")=="SmallBoatstype")
		{
			url += typeRadio.attr("url") + typeRadio.val();
			url += $("#typeSmallBoats").attr("url") + $("#typeSmallBoats").val();
		}
		else if(typeRadio.attr("id")=="PWCtype")
		{
			url += typeRadio.attr("url") + typeRadio.val();
		}
		
		//Processing Zip, State, Region, Country
		typeRadio = $("input:radio[@name=rb_ZipButton]:checked");
		if(typeRadio.attr("id")=="rbzipCode")
		{
			url += $("#zipcode").attr("url") + $("#zipcode").val();
			url += $("#zipRadius").attr("url") + $("#zipRadius").val();
		}
		else if(typeRadio.attr("id")=="rbstateCode")
		{
			url += $("#stateCode").attr("url") + $("#stateCode").val();
		}
		else if(typeRadio.attr("id")=="rbregionCode")
		{
			url += $("#regionCode").attr("url") + $("#regionCode").val();
		}
		else if(typeRadio.attr("id")=="rbcountryCode")
		{
			url += $("#countryCode").attr("url") + $("#countryCode").val();
		}
		
		//Processing Make
		if($.trim($("#makesDrop").val())!="")
		{
			url += $("#makesDrop").attr("url") + $("#makesDrop").val();
		}				
		
		//Processing Length
		if($.trim($("#lolength").val())!="")
		{
			url += $("#lolength").attr("url") + $("#lolength").val();
			url += $("#hilength").attr("url") + $("#hilength").val();
		}		
		//Year
		if($.trim($("#lYear").val())!="Any")
		{
			url += $("#lYear").attr("url") + $("#lYear").val();
			url += $("#hYear").attr("url") + $("#hYear").val();
		}				
		//Price
		if($.trim($("#lPrice").val())!="")
		{
			url += $("#lPrice").attr("url") + $("#lPrice").val();
			url += $("#hPrice").attr("url") + $("#hPrice").val();
		}				
		//Search Order
		url+=$("#sortBy").attr("url") +$("#sortBy").val();
		url = url.replace(/\s/g, "%20");
		
		//$('#searchq').val(url);
		//alert("boattrader.php?url="+url+"&mode=normal");
		window.open("boattrader.php?url="+url+"&mode="+$("input:radio[@name=rb_Search]:checked").val());
		
		return false;
    });	

});
