var app = angular.module('PilatesApp');

app.service('loginService', ['$http', '$q', function ($http, $q) {
    var me = this;
    
    me.initialize = function () {
        me.loggedUser = null;
        me.loginAs = {}
        me.loginCallbacks = [];
    };

    me.subscribeLoginEvent = function (callback) {
        if (me.loginCallbacks.indexOf(callback) < 0)
            me.loginCallbacks.push(callback);
    }

    me.notifyLoginEvent = function () {
        _.forEach(me.loginCallbacks, function (callback) {
            callback(me.loggedUser, me.loginAs);
        });
    }


    me.performLogin = function (user) {
        me.loggedUser = user;
        me.notifyLoginEvent();
    };

    me.getLoggedUser = function () {
        return me.loggedUser;
    };

    me.setLoginAs = function (item) {
        me.loginAs = item;
    }

    me.getLoginAs = function () {
        return me.loginAs;
    }


    me.initialize();
}]);