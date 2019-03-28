/*==============================================================*/
// Promedi Map JS
/*==============================================================*/
(function($) {
    "use strict"; // Start of use strict
    var marker;

	window.initMap = function () {
		var coord = $("#map").data();
		var Latlng = new google.maps.LatLng(coord.lat, coord.lng);
		var map = new google.maps.Map(document.getElementById('map'), {
			zoom: 13,
			center: Latlng
		});

		marker = new google.maps.Marker({
			map: map,
			draggable: true,
			animation: google.maps.Animation.DROP,
			position: Latlng
		});
        marker.addListener('click', toggleBounce);
    }

    function toggleBounce() {
        if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
        } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
        }
    }
}(jQuery)); // End of use strict