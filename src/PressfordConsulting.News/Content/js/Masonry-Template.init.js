/****
 * Initialises the masonry template theme that I'm using
 */
(function ($) {
    $(function () {

        $('.button-collapse').sideNav();


        var $container = $('#masonry-grid');
        // initialize
        $container.masonry({
            columnWidth: '.col',
            itemSelector: '.col',
            percentPosition: true
        });

        // layout Masonry after each image loads
        $container.imagesLoaded().progress(function () {
            $container.masonry('layout');
        });

    }); // end of document ready
})(jQuery); // end of jQuery name space