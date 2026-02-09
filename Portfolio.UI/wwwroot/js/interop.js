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

window.initializeGallery = function () {
    // Initialize Magnific Popup for lightbox
    if (typeof $.fn.magnificPopup !== 'undefined') {
        $('.thumb-gallery-wrapper.lightbox').magnificPopup({
            delegate: 'a.shop-gallery',
            type: 'image',
            gallery: {
                enabled: true
            },
            mainClass: 'mfp-with-zoom',
            zoom: {
                enabled: true,
                duration: 300
            }
        });
    }

    // Initialize Owl Carousel for gallery detail
    if (typeof $.fn.owlCarousel !== 'undefined') {
        $('.thumb-gallery-detail').owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: false,
            navText: ['','']
        });

        // Initialize Owl Carousel for thumbnails
        $('.thumb-gallery-thumbs').owlCarousel({
            items: 4,
            margin: 10,
            nav: false,
            dots: false,
            loop: false,
            responsive: {
                0: { items: 3 },
                576: { items: 4 },
                768: { items: 5 }
            }
        });

        // Sync thumbnails with main gallery
        $('.thumb-gallery-thumbs .cur-pointer').click(function () {
            var index = $(this).parent().index();
            $('.thumb-gallery-detail').trigger('to.owl.carousel', [index, 300]);
        });
    }
};