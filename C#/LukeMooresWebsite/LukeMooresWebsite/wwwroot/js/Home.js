function ShowMoreLess(button) {
    var html = $(button).html();
    if (html.indexOf('More') > -1) {
        html = html.replace('More', 'Less');
    }
    else {
        html = html.replace('Less', 'More');
    }
    $(button).html(html);
    $('#AboutSite').toggleClass('hide');
}