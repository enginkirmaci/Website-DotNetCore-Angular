//// header shrink
//$(window).scroll(function () {
//    if ($(document).scrollTop() == 0) {
//        $('.header').removeClass('tiny');
//    } else {
//        $('.header').addClass('tiny');
//    }
//});
//// navigation
//$('.nav').localScroll(6000);
//$('#top').localScroll(6000);

/*****************************************************************************
	SHARE PAGE
******************************************************************************/
$(document).on('click', '[data-action]', function (e) {
    var _self = $(this),
        action = _self.data('action');

    var _openWindow = function (url, h, w) {
        var dualScreenLeft = window.screenLeft !== undefined ? window.screenLeft : screen.left,
            dualScreenTop = window.screenTop !== undefined ? window.screenTop : screen.top,
            left = ((screen.width / 2) - (w / 2)) + dualScreenLeft,
            top = ((screen.height / 2) - (h / 2)) + dualScreenTop;

        var newWindow = window.open(url, '',
            'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no' +
            ', width=' + w +
            ', height=' + h +
            ', top=' + top +
            ', left=' + left);

        // Puts focus on the newWindow
        //if (window.focus) {
        //    newWindow.focus();
        //}
        return newWindow;
    };

    e.preventDefault();

    switch (action) {
        case 'share-linkedin':
            _openWindow(
                'http://www.linkedin.com/shareArticle?mini=true&url=' + encodeURIComponent(location.href) + '&title=' + encodeURIComponent(document.title),
                600, 600);
            break;
        case 'share-facebook':
            _openWindow(
                'https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(location.href),
                436, 626);
            break;
        case 'share-twitter':
            _openWindow(
                'https://twitter.com/share?url=' + encodeURIComponent(location.href) + '&text=' + encodeURIComponent(document.title),
                440, 550);
            break;
    }

    return false;
});