/**
 * 
 */

var availableAirports = [];
var globalDataArray = []; 

function madeAjaxCall(identifier) {
	var filter = $("#" + identifier).val()
	var baseurl = $("#baseurl").val();
	$.ajax({
		url : baseurl + "/getFilteredAirports",
		type : "post",
		cache : false,
		data : 'filter=' + filter,
		success : function(response) {
			availableAirports = response;
			refreshOriginSearch(identifier);
		},
		error : function(e) {
			alert('Error while request..');
		}
	});
}

$(function(identifier) {
	$("#" + identifier).autocomplete({
		source : availableAirports
	});
});

function refreshOriginSearch(identifier) {
	$("#" + identifier).autocomplete({
		source : availableAirports
	});
}

function search() {
	var origin = $("#originSearch").val();
	var destination = $("#destinationSearch").val();
	var departureDate = $("#departureDate").val();
	var baseurl = $("#scheduleurl").val();

	if (origin != "" || destination != "") {
		$
				.ajax({
					url : baseurl + "/getFilteredSchedules",
					type : "post",
					cache : false,
					data : 'origin=' + origin + "&destination=" + destination
							+ "&departureDate=" + $("#departureDate").val(),
					success : function(response) {
						var obj = response; // JSON.parse(response);
						console.log(obj);
						len = obj.length;
						$('#result').html("");
						var html = '<table class="table table-hover"><thead><tr><th>#</th><th>Route</th></tr></thead>';

						var len = response.length;
						for (var i = 0; i < len; i++) {
							globalDataArray[i] = obj[i].latLngs.split('|');
							html += '<tbody><tr onclick=initializeData(' + i + ');><td>' + (i + 1) + '</td><td>'
									+ obj[i].path + '</td></tr></tbody>';
						}

						html += '</table>'
						$('#result').html(html);
					},
					error : function(e) {
						console.log(e);
						alert("Invalid origin and/or destination");
					}
				});
	} else {
		alert("Please enter origin and/or destination");
	}
		
}


//


var line;
function initialize() {
	initializeData()
}

function initializeData(index) {
	
	dataArray = globalDataArray[index];

	var mapOptions = {
		zoom : 5,
		center : new google.maps.LatLng(37.09024, -95.71289100000001),
		mapTypeId : google.maps.MapTypeId.TERRAIN
	};

	var map = new google.maps.Map(document.getElementById('map-canvas'),
			mapOptions);

	var arrayLength = dataArray.length;
	var lineCoordinates = new Array(arrayLength);
	for (var i = 0; i < arrayLength; i++) {
		var s = dataArray[i].split(",");
		lineCoordinates[i] = new google.maps.LatLng(s[0], s[1]);
	}

	/*var lineCoordinates = [
			new google.maps.LatLng(41.974162, -87.90732100000002),
			new google.maps.LatLng(41.534133, -93.658796),
			new google.maps.LatLng(41.991943, -93.62194799999997),
			new google.maps.LatLng(33.640728, -84.42770000000002) ];*/

	// Define the symbol, using one of the predefined paths ('CIRCLE')
	// supplied by the Google Maps JavaScript API.
	var lineSymbol = {
		path : google.maps.SymbolPath.FORWARD_CLOSED_ARROW,
		scale : 3,
		strokeColor : '#FF0000'
	};

	// Create the polyline and add the symbol to it via the 'icons' property.
	line = new google.maps.Polyline({
		path : lineCoordinates,
		icons : [ {
			icon : lineSymbol,
			offset : '100%',
		} ],
		map : map
	});

	animateCircle();

}

// Use the DOM setInterval() function to change the offset of the symbol
// at fixed intervals.
function animateCircle() {
	var count = 0;
	window.setInterval(function() {
		count = (count + 1) % 200;

		var icons = line.get('icons');
		icons[0].offset = (count / 2) + '%';
		line.set('icons', icons);
	}, 100);
}

google.maps.event.addDomListener(window, 'load', initialize);
