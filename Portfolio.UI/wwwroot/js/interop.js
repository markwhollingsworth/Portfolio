var interop = interop || {};

interop.loadZoomify = function(mapUrl) {
    Z.showImage("mapContainer", mapUrl);
}

interop.loadCarousel = function() {
    $('.carousel').carousel();
}

interop.isNumber = function (event) {
    return (event.charCode != 8 && event.charCode == 0 || (event.charCode >= 48 && event.charCode <= 57))
}

interop.initDatepicker = function(format, minimumDate, maximumDate) {
	$(() => {
		$(".datepicker").datepicker({
			format: format,
			minDate: minimumDate,
			maxDate: maximumDate
		});
	});
}