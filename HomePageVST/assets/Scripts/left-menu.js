function testclick300() {
    if ($(".300").css('display') == 'block') {
        $(".300").css('display', 'none');
        // $(".series").css('display', 'none');
        //  series();
    } else {
        $(".300").css('display', 'block');
        // $(".series").css('display', 'block');
        //series();
    }
}

function testclick400() {
    if ($(".400").css('display') == 'block') {
        $(".400").css('display', 'none');
    } else {
        $(".400").css('display', 'block');
    }
}

function sanphammoimenu() {
    if ($(".sanphammoi").css('display') == 'block') {
        $(".sanphammoi").css('display', 'none');
    } else {
        $(".sanphammoi").css('display', 'block');
    }
}
function series() {
    if ($(".series").css('display') == 'block') {
        $(".series").css('display', 'none');
        //if ($(".300").css('display', 'none')) {
        $(".300").css('display', 'none');
        $(".400").css('display', 'none');
        $(".mv-item").removeClass('border-menu');
    } else {
        $(".mv-item").addClass('border-menu');
        $(".series").css('display', 'block');
        $(".300").css('display', 'block');
        $(".400").css('display', 'block');
    }
}
function ProductionProcess() {
    if ($(".Production").css('display') == 'block') {
        $(".Production").css('display', 'none');
    } else {
        $(".Production").css('display', 'block');
    }
}
var slideIndex = 1;
//showDivs(slideIndex);
function plusDivs(n) {
    showDivs(slideIndex += n);
}
function currentDiv(n) {
    showDivs(slideIndex = n);
}
function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("demo");
    if (n > x.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = x.length }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" w3-white", "");
    }
    x[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " w3-white";
}
var myIndex = 0;
//carousel();

function carousel() {
    var i;
    var dots = document.getElementsByClassName("demo");
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
        dots[i].className = "w3-badge demo w3-border w3-transparent w3-hover-white";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    dots[myIndex - 1].className += "w3-white ct-trang";
    setTimeout(carousel, 5000);
}