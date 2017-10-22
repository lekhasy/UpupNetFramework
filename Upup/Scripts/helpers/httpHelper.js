'use strict';

var $uuHttpHelper =
    (function () {
        var helper = {
            get(controller, action, requestData, onSuccess) {
                sendRequestWithAuthHeader("GET", controller, action, requestData, onSuccess);
            },
            post(controller, action, requestData, onSuccess) {
                sendRequestWithAuthHeader("POST", controller, action, requestData, onSuccess);
            },
            put(controller, action, requestData, onSuccess) {
                sendRequestWithAuthHeader("PUT", controller, action, requestData, onSuccess);
            },
            delete(controller, action, requestData, onSuccess) {
                sendRequestWithAuthHeader("DELETE", controller, action, requestData, onSuccess);
            }
        };

        var sendRequestWithAuthHeader = function (method, controller, action, requestData, onSuccess) {
            $utils.throwIfStringIsNullOrEmpty(controller, "Controller");
            $utils.throwIfStringIsNullOrEmpty(action, "Action");
            // get auth token from cookie and attach it to HTTP Authorization header
            var token = Cookies.get($UpupConfigs.Cookie.TokenKey);
            $.ajax({
                url: $utils.buildApiUrl(controller, action),
                method: method,
                data: method === "POST" ? JSON.stringify(requestData) : requestData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //beforeSend: function (xhr) {
                //    if (token) {
                //        xhr.setRequestHeader("Authorization", 'Bearer ' + token);
                //    }
                //},
                success: onSuccess
            });
        };
        return helper;
    })();

