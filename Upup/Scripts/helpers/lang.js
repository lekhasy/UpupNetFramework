'use strict';

var $uuLang =
    (function () {

        var viLang = {
            required_field: "trường này là bắt buộc",
            username_min_length_validation: "độ dài tối thiểu của ID đăng nhập là 4",
            password_min_length_validation: "độ dài tối thiểu của mật khẩu là 8",
            password_confirm_match_validation: "mật khẩu xác nhận không khớp",
            email_format_validation: "vui lòng điền email chính xác",
            email_confirm_match_validation: "email xác nhận không khớp",
            phone_format_validation: "vui lòng điền số điện thoại chính xác",
            register_fail: "Đăng ký thất bại",
            register_fail_username_existed: "Id đăng nhập đã tồn tại, vui lòng chọn một tên khác",
            register_fail_email_existed: "Email đã tồn tại, vui lòng chọn một email khác"
        };

        var engLang = {
            required_field: "this field is required",
            username_min_length_validation: "minumum length of Login UserID is 4",
            password_min_length_validation: "minumum length of password is 8",
            password_confirm_match_validation: "confirmation password doesn't match",
            email_format_validation: "please provide your valid email address",
            email_confirm_match_validation: "confirmation email doesn't match",
            phone_format_validation: "please provide your valid phone number",
            register_fail: "Registration fail",
            register_fail_email_existed: "Email already existed, please use another one"
        };

        var langPack = null;
        var l = {
            getText(key) {
                return langPack[key];
            }
        };
        if (Cookies.get($UpupConfigs.Cookie.Culture) === 'en') {
            langPack = engLang;
        }
        else {
            Cookies.set($UpupConfigs.Cookie.Culture, 'vi');
            langPack = viLang;
        }
        return l;
    })();
