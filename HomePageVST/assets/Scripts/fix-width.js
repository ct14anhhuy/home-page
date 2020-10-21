function mobileViewUpdate() {
    var height = $(window).height();
    var width = $(window).width();
    var viewportWidth = $(window).width();
    if (viewportWidth <= 1024) {
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

function updateHeaderHeightOnViewChange() {
    var headerHeight = "133px";
    $("#sticky-wrapper").css("height", headerHeight);
}

$(window).load(mobileViewUpdate);
$(window).resize(function () {
    mobileViewUpdate();
    updateHeaderHeightOnViewChange();
});