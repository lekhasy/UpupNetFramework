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

accounting.settings = {
    currency: {
        symbol: "VNĐ",   // default currency symbol is '$'
        format: "%v%s", // controls output: %s = symbol, %v = value/number (can be object: see below)
        decimal: ",",  // decimal point separator
        thousand: ".",  // thousands separator
        precision: 0   // decimal places
    },
    number: {
        precision: 0,  // default precision on numbers is 0
        thousand: ",",
        decimal: "."
    }
}

var poState = {
    1: { Name: "Đơn hàng tạm" },
    2: { Name: "Đã đặt hàng" },
    3: { Name: "Đã thanh toán" },
    4: { Name: "Đã hoàn thành" },
    5: { Name: "Đã hủy bỏ" },
};

function GetPoStateByCode(code) {
    return poState[code].Name;
}