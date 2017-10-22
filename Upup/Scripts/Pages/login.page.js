'use strict';

// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form[name='login-form']").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            UserName: {
                required: true,
                minlength: 4
            },
            Password: {
                required: true,
                minlength: 8
            }
        },
        // Specify validation error messages
        messages: {
            UserName: {
                required: $uuLang.getText("required_field"),
                minlength: $uuLang.getText("username_min_length_validation")
            },
            Password: {
                required: $uuLang.getText("required_field"),
                minlength: $uuLang.getText("password_min_length_validation")
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});