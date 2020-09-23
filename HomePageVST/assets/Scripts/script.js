$(document).ready(function () {
    if ('matchMedia' in window) {
        // Chrome, Firefox, and IE 10 support mediaMatch listeners
        window.matchMedia('print').addListener(function (media) {
            if (media.matches) {
                beforePrint();
            } else {
                // Fires immediately, so wait for the first mouse movement
                $(document).one('mouseover', afterPrint);
            }
        });
    } else {
        // IE and Firefox fire before/after events
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
        //$("a:not(.act) > p").css("display", "yellow");
        if (!$(this).find("a").hasClass("act")) {
            $(this).find("p.showmuiten").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act")) {
            $(this).find("p.showmuiten").css("display", "none");
        }
    });

    $(".Production,.sanphammoi").hover(function () {
        //   alert('3000000000000')
        if (!$(this).find("a").hasClass("act_sub")) {
            $(this).find("p.showmuiten1").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act_sub")) {
            $(this).find("p.showmuiten1").css("display", "none");
        }
    });

    $(".300,.400").hover(function () {
        //   alert('3000000000000')
        if (!$(this).find("a").hasClass("act_sub_sub")) {
            $(this).find("p.showmuiten2").css('display', 'inline');
        }
    }, function () {
        if (!$(this).find("a").hasClass("act_sub_sub")) {
            $(this).find("p.showmuiten2").css("display", "none");
        }
    });

    if ('matchMedia' in window) {
        // Chrome, Firefox, and IE 10 support mediaMatch listeners
        window.matchMedia('print').addListener(function (media) {
            if (media.matches) {
                beforePrint();
            } else {
                // Fires immediately, so wait for the first mouse movement
                $(document).one('mouseover', afterPrint);
            }
        });
    } else {
        // IE and Firefox fire before/after events
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

function isKeyPressed(event) {
    if (event.ctrlKey == 1) {
        //  alert("Please Submit exam form befor printing");
    }
}

$(document).bind("keyup keydown", function (e) {
    if (e.ctrlKey && e.keyCode == 80) {
        e.preventDefault();
    }
});