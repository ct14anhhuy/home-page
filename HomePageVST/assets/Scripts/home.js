$('.carousel[data-type="multi"] .item').each(function () {
    var next = $(this).next();
    if (!next.length) {
        next = $(this).siblings(':first');
    }
    next.children(':first-child').clone().appendTo($(this));

    for (var i = 0; i < 2; i++) {
        next = next.next();
        if (!next.length) {
            next = $(this).siblings(':first');
        }
        next.children(':first-child').clone().appendTo($(this));
    }
});

var videos = document.querySelectorAll('video');
for (var i = 0; i < videos.length; i++) {
    videos[i].addEventListener('play', function () { pauseAllAndRemoveBorder(this) }, true);
}

function pauseAllAndRemoveBorder(elem) {
    for (var i = 0; i < videos.length; i++) {
        if (videos[i] == elem) continue;
        if (videos[i].played.length > 0 && !videos[i].paused) {
            videos[i].style.border = 'none';
            videos[i].style.borderRadius = 0;
            videos[i].pause();
        }
    }
}

$(document).ready(function () {
    $('video').bind('contextmenu', function () { return false; });
    $('video').attr('controlsList', 'nodownload');
});