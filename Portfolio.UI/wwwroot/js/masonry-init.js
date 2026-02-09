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

window.initializeStarRating = function () {
    if (typeof $.fn.rating !== 'undefined') {
        $('[data-plugin-star-rating]').each(function () {
            var $this = $(this);
            var options = $this.data('plugin-options') || {};

            // Parse options if it's a string
            if (typeof options === 'string') {
                try {
                    options = JSON.parse(options.replace(/'/g, '"'));
                } catch (e) {
                    options = {};
                }
            }

            // Initialize the rating plugin
            $this.rating(options);
        });
    }
};

window.initializeAllPlugins = function () {
    // Initialize star ratings
    window.initializeStarRating();

    // Initialize any other plugins that use data-plugin-* attributes
    if (typeof theme !== 'undefined' && typeof theme.PluginStarRating !== 'undefined') {
        theme.PluginStarRating.initialize();
    }
};