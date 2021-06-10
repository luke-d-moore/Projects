function DisplayFrontEnd() {

    $('#FrontEndExperience').toggleClass('hide');

    var backEnd = $('#BackEndExperience');
    if (!backEnd.hasClass('hide')) {
        backEnd.addClass('hide');
    }

    var database = $('#DatabaseExperience');
    if (!database.hasClass('hide')) {
        database.addClass('hide');
    }
}

function DisplayBackEnd() {

    $('#BackEndExperience').toggleClass('hide');

    var frontEnd = $('#FrontEndExperience');
    if (!frontEnd.hasClass('hide')) {
        frontEnd.addClass('hide');
    }

    var database = $('#DatabaseExperience');
    if (!database.hasClass('hide')) {
        database.addClass('hide');
    }
}

function DisplayDatabase() {

    $('#DatabaseExperience').toggleClass('hide');

    var backEnd = $('#BackEndExperience');
    if (!backEnd.hasClass('hide')) {
        backEnd.addClass('hide');
    }

    var frontEnd = $('#FrontEndExperience');
    if (!frontEnd.hasClass('hide')) {
        frontEnd.addClass('hide');
    }
}