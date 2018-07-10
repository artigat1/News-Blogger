NewsApp.Editor = (function($, undefined) {
    var settings = {};

    var init = function(editorSelector) {
        settings.editorSelector = editorSelector;

        settings.editorObj = $(settings.editorSelector);
        if (settings.editorObj.length > 0) {
            settings.editorObj.editable({
                inlineMode: false,
                allowScript: false,
                tabSpaces: true,
                toolbarFixed: false,
                height: 300,
                allowedImageTypes: ['jpeg', 'jpg', 'png'],
                buttons: [
                    'bold', 'italic', 'underline', 'strikethrough',
                    'subscript', 'superscript', 'sep',
                    'fontSize', 'color', 'sep',
                    'indent', 'outdent', 'insertOrderedList',
                    'insertUnorderedList', 'sep',
                    'createLink', 'insertVideo', 'html', 'fullscreen'
                ]
            });
        }
    };

    return {
        init: init
    };
})(jQuery);