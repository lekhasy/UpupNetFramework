'use strict'
$(document).ready(function () {
    var $allCategoryLevel1 = $("dl.category-list-caption dd");
    $allCategoryLevel1.hover(function () {
        $allCategoryLevel1.removeClass("on");
        $(this).addClass("on");
    }, function () {
        $(this).removeClass("on");
        });

    $(function () {
        $(".category-link").hover(function () {
            var currentCatetoryImage = $(this).attr("imgUrl");
            var rootCategoryImage = $(this).closest(".root-category").find('.image.category-image').css('background-image', 'url(/Images/Categories/' + currentCatetoryImage + ')');
        });
    });

});