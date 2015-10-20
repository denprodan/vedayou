$(document).ready(function () {
    $(".nav-about-us").on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#about_us").offset().top-100
        }, 500);
    });

    $(".nav-services").on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#services").offset().top - 100
        }, 500);
    });


    $(".nav-contacts").on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#contacts").offset().top - 100
        }, 500);
    });
});