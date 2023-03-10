var jsInterop = jsInterop || {};

jsInterop.loadZoomify = function(mapUrl) {
    Z.showImage("mapContainer", mapUrl);
}

jsInterop.loadCarousel = function() {
    $('.carousel').carousel();
}