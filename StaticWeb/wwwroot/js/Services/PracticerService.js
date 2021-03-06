﻿var app = angular.module('PilatesApp');

app.service('practicerService', ['$http', '$q', function ($http, $q) {
    var accountUrl = 'http://localhost:63998/api';
    var agendaUrl = 'http://localhost:63998/api';
    var me = this;
    me.initialize = function() {
        me.practicer = [];
        me.practicerClasses = [];

        /*me.practicer.push({
            id: '132456',
            name: 'Cris',
            email: 'cris@gmail.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
        me.practicer.push({
            id: '132457',
            name: 'Josue',
            email: 'josue@gmail.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
        me.practicer.push({
            id: '132458',
            name: 'Paulo',
            email: 'paulo@yahoo.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
        */
        me.trainerSchedule = [];
    }

    me.getPracticers = function () {
        var defer = $q.defer()

        $http({
            method: 'GET',
            url: accountUrl + '/practicer'
        }).then(function successCallback(response) {
            if (_.isNil(response.data) === false)
                me.practicer = response.data;
            defer.resolve(me.practicer);
            }, function errorCallback(response) {
                defer.reject(response);
        });
        
        return defer.promise;
    }

    me.addPracticer = function (newPracticer) {
        var defer = $q.defer()

        $http.post(
            accountUrl + '/practicer',
            newPracticer
        ).then(function successCallback(response) {
            if (_.isNil(response) === false)
                me.practicer.push(response.data);
                
            defer.resolve(me.practicer);
        }, function errorCallback(response) {
            defer.reject(response);
        });

        return defer.promise;
    }

    me.getPracticer = function (id) {
        var defer = $q.defer()
        var index = _.findIndex(me.practicer, function (t) { return t.id = id; });
        if (index < 0) {
            $http({
                method: 'GET',
                url: accountUrl + '/practicer/' + id
            }).then(function successCallback(response) {
                if (_.isNil(response.data) === false) {
                    me.practicer.push(data);
                    defer.resolve(response.data);
                }
                defer.reject(me.practicer);
            }, function errorCallback(response) {
                defer.reject(response);
            });
        }
        else {
            defer.resolve(me.practicer[index]);
        }
        defer.resolve(null);

        return defer.promise;
    }

    me.savePracticerClasses = function (data) {
        var defer = $q.defer()

        $http.post(
            agendaUrl + '/PracticerClasses/',
            data
        ).then(function successCallback(response) {
            if (_.isNil(response.data) === false) {
                practicerClasses.push(response.data.classes);
            }

            defer.resolve(data);
        }, function errorCallback(response) {
            defer.reject(response);
        });


        return defer.promise;
    }

    me.getPracticerSchedule = function (practicerId) {
        var defer = $q.defer();

        $http({
            method: 'GET',
            url: agendaUrl + '/PracticerClasses/',
        }).then(function successCallback(response) {
            if (_.isNil(response.data) === false) { 
                me.practicerClasses = response.data;
            }
            defer.resolve(_.filter(me.practicerClasses, function (practicerSchedule) {
                return practicerSchedule.practicerId == practicerId;
            }));
        }, function errorCallback(response) {
            defer.reject(response);
        });
        return defer.promise;
    }
    
    me.initialize();

}])
