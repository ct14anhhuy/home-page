$(document).ready(function () {
    if ('matchMedia' in window) {
        // Chrome, Firefox, and IE 10 support mediaMatch listeners
        window.matchMedia('print').addListener(function (media) {
            if (media.matches) {
                beforePrint();
            } else {
                $(document).one('mouseover', afterPrint);
            }
        });
    } else {
        $(window).on('beforeprint', beforePrint);
        $(window).on('afterprint', afterPrint);
    }

    function beforePrint() {
        $("#exampleModal").hide();
        $(".PrintMessage").show();
    }

    function afterPrint() {
        $(".PrintMessage").hide();
        $("#exampleModal").show();
    }

    $('#Div2 table').removeAttr("rules");
    $('#Div1 table').removeAttr("rules");

    $(".mv-item").removeClass('border-menu');
    $('.user-support').click(function (event) {
        //  alert("vao day")
        $('.social-button-content').slideToggle();
    });

    $("li").hover(function () {
        if (!$(this).find("a").hasClass("act")) {
            $(this).find("p.showmuiten").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act")) {
            $(this).find("p.showmuiten").css("display", "none");
        }
    });

    $(".Production,.sanphammoi").hover(function () {
        if (!$(this).find("a").hasClass("act_sub")) {
            $(this).find("p.showmuiten1").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act_sub")) {
            $(this).find("p.showmuiten1").css("display", "none");
        }
    });

    $(".300,.400").hover(function () {
        if (!$(this).find("a").hasClass("act_sub_sub")) {
            $(this).find("p.showmuiten2").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act_sub_sub")) {
            $(this).find("p.showmuiten2").css("display", "none");
        }
    });

    if ('matchMedia' in window) {
        window.matchMedia('print').addListener(function (media) {
            if (media.matches) {
                beforePrint();
            } else {
                $(document).one('mouseover', afterPrint);
            }
        });
    } else {
        $(window).on('beforeprint', beforePrint);
        $(window).on('afterprint', afterPrint);
    }

    function beforePrint() {
        $("#exampleModal").hide();
        $(".PrintMessage").show();
    }

    function afterPrint() {
        $(".PrintMessage").hide();
        $("#exampleModal").show();
    }
});

function viewMsgPortletDataReload() {
    alert("reload data");
}

$(document).bind("keyup keydown", function (e) {
    if (e.ctrlKey && e.keyCode == 80) {
        e.preventDefault();
    }
});

$(function () {
    $('.selectpicker').selectpicker();
});