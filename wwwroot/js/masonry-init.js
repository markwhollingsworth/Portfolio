window.initializeMasonry = function (element) {
    if (element && typeof $.fn.isotope !== 'undefined') {
        $(element).isotope({
            layoutMode: 'fitRows',
            itemSelector: '.product'
        });
    } else if (element && typeof Masonry !== 'undefined') {
        new Masonry(element, {
            itemSelector: '.product',
            columnWidth: '.col-sm-6',
            percentPosition: true
        });
    }
};