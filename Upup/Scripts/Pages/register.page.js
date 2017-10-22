'use strict';

// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form[name='registration']").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Password: {
                required: true,
                minlength: 8
            },
            PasswordConfirm: {
                required: true,
                equalTo: "[name='Password']"
            },
            FullName: "required",
            OrgName: "required",
            // DepartmentName
            Email: {
                required: true,
                // Specify that email should be validated
                // by the built-in "email" rule
                email: true
            },
            EmailConfirm: {
                required: true,
                // Specify that email should be validated
                // by the built-in "email" rule
                equalTo: "[name='Email']"
            },
            Address1: "required",
            //Address2, 3,4
            //PostalCode
            PhoneNumber: {
                digits: true
            }
            // Fax
        },
        // Specify validation error messages
        messages: {
            Password: {
                required: $uuLang.getText("required_field"),
                minlength: $uuLang.getText("password_min_length_validation")
            },
            PasswordConfirm: {
                required: $uuLang.getText("required_field"),
                equalTo: $uuLang.getText("password_confirm_match_validation")
            },
            FullName: $uuLang.getText("required_field"),
            OrgName: $uuLang.getText("required_field"),
            Email: {
                required: $uuLang.getText("required_field"),
                email: $uuLang.getText("email_format_validation")
            },
            EmailConfirm: {
                required: $uuLang.getText("required_field"),
                equalTo: $uuLang.getText("email_confirm_match_validation")
            },
            Address1: $uuLang.getText("required_field"),
            PhoneNumber: $uuLang.getText("phone_format_validation")
        },
        submitHandler: function (form) {
            // check for user name and email are available
            $uuHttpHelper.get("account", "CheckEmailAvailable", { email: $("[name='Email']").val() }, function (emailAvailable) {
                if (emailAvailable) {
                    form.submit();
                }
                else {
                    $("#registerFailModal").find('.modal-title').text($uuLang.getText("register_fail"));
                    $("#registerFailModal").find('.registerFailTextContent').text($uuLang.getText("register_fail_email_existed"));
                    $('[data-target="#registerFailModal"]').click();
                }
            });
        }
    });
});