NewsApp.Like = (function($, undefined) {
    var settings = {};

    var init = function(actionSelector, errorModalSelector) {
        settings.actionSelector = actionSelector;
        settings.errorModalSelector = errorModalSelector;

        $(settings.actionSelector).click(function(event) {
            event.preventDefault();
            var link = this;
            var request = $.ajax({
                url: $(this).attr('href'),
                method: 'GET',
                contentType: 'application/json'
            });

            request.done(function (data) {
                if (data.success) {
                    // Change icon to green/red depending on current state to show action worked
                    $(link).toggleClass(function() {
                        var theLinkObj = $(link);
                        var href = theLinkObj.attr('href');
                        var newHref;

                        if (theLinkObj.hasClass('red')) {
                            newHref = href.replace(/\/Article\/Like/, '\/Article\/Dislike');
                            theLinkObj
                                .attr('href', newHref)
                                .removeClass('red')
                                .attr('data-tooltip', NewsApp.Config.txtArticleDislike);
                            return 'green';
                        } else {
                            newHref = href.replace(/\/Article\/DisLike/, '\/Article\/Like');
                            theLinkObj
                                .attr('href', newHref)
                                .removeClass('green')
                                .attr('data-tooltip', NewsApp.Config.txtArticleLike);
                            return 'red';
                        }
                    });
                } else {
                    // An error occurred
                    $('.modal-content p', settings.errorModalSelector).text(data.error);
                    $(settings.errorModalSelector).openModal();
                }
            });
        });
    };

    return {
        init: init
    };
})(jQuery);