const HEADER_HEIGHT = "133px";

function mobileViewUpdate() {
    var height = $(window).height();
    var width = $(window).width();
    var isMobile = window.matchMedia("only screen and (max-device-width: 1024px)").matches;

    if (isMobile) {
        //for mobile device if(portrait) and else(landscape)
        if (height > width) {
            $(".footer-link").addClass("col-xs-12");
            $("#video-frame .col-centered .vid").removeClass("col-xs-4").addClass("col-xs-6");
            $(".content-detail .col-xs-10 .col-xs-4").removeClass("col-xs-4").addClass("col-xs-6");
        } else {
            $(".footer-link").removeClass("col-xs-12");
            $("#video-frame .col-centered .vid").removeClass("col-xs-6").addClass("col-xs-4");
            $(".content-detail .col-xs-10 .col-xs-6").removeClass("col-xs-6").addClass("col-xs-4");
        }
        $(".content-detail .col-xs-10").removeClass("col-xs-10").addClass("col-xs-11");
    } else {
        //for pc device
        $(".footer-link").removeClass("col-xs-12");
        $("#video-frame .col-centered .vid").removeClass("col-xs-6").addClass("col-xs-4");
        $(".content-detail .col-xs-11 .col-xs-6").removeClass("col-xs-6").addClass("col-xs-4");
        $(".content-detail .col-xs-11").removeClass("col-xs-11").addClass("col-xs-10");
    }
}

$(window).load(function () {
    mobileViewUpdate();
    $('#header-wrapper div:first-child + div + div + div').toggleClass('sbar_collapsed');
    $("#sticky-wrapper").css("height", HEADER_HEIGHT);
});

$(window).resize(function () {
    mobileViewUpdate();
    $("#sticky-wrapper").css("height", HEADER_HEIGHT);
});

$('.nav-btn').on('click', function () {
    $('#header-wrapper div:first-child + div + div + div').toggleClass('sbar_collapsed');
    $("#sticky-wrapper").css("height", HEADER_HEIGHT);
});