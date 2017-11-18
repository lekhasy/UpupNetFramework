'use strict'
$(document).ready(function () {
    var $allCategoryLevel1 = $("dl.category-list-caption dd");
    $allCategoryLevel1.hover(function () {
        $allCategoryLevel1.removeClass("on");
        $(this).addClass("on");
    }, function () {
        $(this).removeClass("on");
    });

    var rootImage;
    var $categoryImageControl;

    $(".category-link").hover(function () {
        var currentCatetoryImage = $(this).attr("imgUrl");
        var rootImage = "/Images/Categories/" + currentCatetoryImage;
        $categoryImageControl = $(this).closest(".root-category").find('.image.category-image');
        var rootCategoryImage = $categoryImageControl.css('background-image', 'url(' + rootImage + ')');
    });

    $(".category-list-box li a").hover(function () {
        $categoryImageControl.css('background-image', 'url(' + $(this).attr('data-img') + ')');
    }, function () {
        $categoryImageControl.css('background-image', 'url(' + rootImage + ')');
    });

    $(".category-list-box > ul > li a").hover(function () {
        $(this).removeClass('collapsed');
        $(this).next().removeClass('collapse').addClass('in');
    }, function () {
        $(this).addClass('collapsed');
        $(this).next().removeClass('in').addClass('collapse');
    });
});