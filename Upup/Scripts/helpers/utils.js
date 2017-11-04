'use strict'


var $utils = {
    throwIfStringIsNullOrEmpty: function (str, paramName) {
        if (!str) throw paramName + " can not be " + (method === '' ? "empty" : method);
    },
    buildApiUrl: function (controller, action) {
        this.throwIfStringIsNullOrEmpty(controller, "controller");
        this.throwIfStringIsNullOrEmpty(action, "Action");
        return "/" + controller + "/" + action;
    },
    buildWebViewUrl: function (controller, action) {
        this.throwIfStringIsNullOrEmpty(controller, "controller");
        this.throwIfStringIsNullOrEmpty(action, "Action");
        return controller + "/" + action;
    }
};