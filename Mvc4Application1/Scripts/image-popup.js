(function($) {
    $(function() {
        // on page load
        var $popup = $('<div><img alt="no image"></div>');
        var $popupImage = $popup.find('img');

        $popup.dialog({
            autoOpen: false,
            modal: true
        });

        $('img.thumbnail-popup').click(function () {
            $popupImage.attr('src', $(this).attr('src'));
            $popup.dialog('open');
            $popup.dialog({
                height: $popupImage.height() + 80,
                width: $popupImage.width() + 50
            });
        });
    });
})(jQuery);