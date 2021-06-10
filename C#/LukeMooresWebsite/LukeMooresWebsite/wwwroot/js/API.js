function SendRequest() {

    var obj = { RequestMessage: $('#RequestMessage').val() };

    $.ajax({
        url: "/api/api/",
        type: "POST",
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(obj)
    })
        .done(function (data) {
            $('#Response').html(JSON.stringify(data));
        })
        .fail(function (error) {
            console.log(error);
        })
}

function ShowJavascript(button) {
    var html = $(button).html();
    if (html.indexOf('Show') > -1) {
        html = html.replace('Show', 'Hide');
    }
    else {
        html = html.replace('Hide', 'Show');
    }
    $(button).html(html);
    $('#javascriptDisplay').toggleClass('hide');
}