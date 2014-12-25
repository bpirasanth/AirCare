/**
 * 
 */

var availableAirports = [];
var globalDataArray = [];

function madeAjaxCall(identifier) {
    var filter = $("#" + identifier).val();

    $.ajax({
        url: '/Admin/GetAirportsByFilter',
        cache: false,
        type: 'POST',
        data: JSON.stringify({
            'filter': filter,
        }),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (response) {
            availableAirports = response;
            refreshOriginSearch(identifier);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            // console.log(data);
        }
    });

}

$(function (identifier) {
    $("#" + identifier).autocomplete({
        source: availableAirports
    });
});

function refreshOriginSearch(identifier) {
    $("#" + identifier).autocomplete({
        source: availableAirports
    });
}

function search() {
    var origin = $("#originSearch").val();
    var destination = $("#destinationSearch").val();
    var departureDate = $("#departureDate").val();
    var arrivalDate = $("#arrivalDate").val();

    if (origin != "" || destination != "") {
        $.ajax({
				    url: '/Admin/GetSchedulesByFilter',
				    cache: false,
				    type: 'POST',
				    data: JSON.stringify({
                        'origin' : origin,
                        'destination' : destination,
                        'departureDate': departureDate,
                        'arrivalDate': arrivalDate
				    }),
                    dataType : 'json',
				    success: function (response) {
                        debugger;
				        var obj = response;
				        len = obj.length;
				        $('#result').html("");
				        var html = '<table class="table table-hover"><thead><tr><th>#</th><th>Route</th></tr></thead>';
                        
				        var len = response.length;


				        for (var i = 0; i < len; i++) {
				            
				        }

				        html += '</table>'
				        $('#result').html(html);
				    },
				    error: function (e) {
				        console.log(e);
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
        zoom: 4,
        center: new google.maps.LatLng(37.09024, -95.71289100000001),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    };

    var map = new google.maps.Map(document.getElementById('map-canvas'),
			mapOptions);

    if (dataArray != undefined) {
        var arrayLength = dataArray.length;
        var lineCoordinates = new Array(arrayLength);
        for (var i = 0; i < arrayLength; i++) {
            var s = dataArray[i].split(",");
            lineCoordinates[i] = new google.maps.LatLng(s[0], s[1]);
        }

        // Define the symbol, using one of the predefined paths ('CIRCLE')
        // supplied by the Google Maps JavaScript API.
        var lineSymbol = {
            path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW,
            scale: 3,
            strokeColor: '#FF0000'
        };

        // Create the polyline and add the symbol to it via the 'icons' property.
        line = new google.maps.Polyline({
            path: lineCoordinates,
            icons: [{
                icon: lineSymbol,
                offset: '100%',
            }],
            map: map
        });

        animateCircle();
    }

}

// Use the DOM setInterval() function to change the offset of the symbol
// at fixed intervals.
function animateCircle() {
    var count = 0;
    window.setInterval(function () {
        count = (count + 1) % 200;

        var icons = line.get('icons');
        icons[0].offset = (count / 2) + '%';
        line.set('icons', icons);
    }, 100);
}

google.maps.event.addDomListener(window, 'load', initialize);
