'use strict'
$(document).ready(function () {
    var $allCategoryLevel1 = $("dl.category-list-caption dd");
    $allCategoryLevel1.hover(function () {
        $allCategoryLevel1.removeClass("on");
        $(this).addClass("on");
    }, function () {
        $(this).removeClass("on");
    });
});