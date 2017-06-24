var app = angular.module('PilatesApp');

app.service('trainerService', ['$http', '$q', function ($http, $q) {
    var me = this;
    var accountUrl = 'http://localhost:51014/api/Trainer';
    var agendaUrl = 'http://localhost:54250/api/TrainerSchedule';
    me.initialize = function() {
        me.trainers = [];
        /*
        me.trainers.push({
            id: '132456',
            name: 'Eduardo',
            email: 'eduardo@studio.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
       
        */
        me.trainerSchedule = [];
    }

    me.getTrainers = function () {
        var defer = $q.defer()

        $http({
            method: 'GET',
            url: accountUrl
        }).then(function successCallback(response) {
            if (_.isNil(response.data) === false)
                me.trainers = response.data;
            defer.resolve(me.trainers);
        }, function errorCallback(response) {
            defer.reject(response);
        });

        return defer.promise;
    }

    me.addTrainer = function (newTrainer) {
        var defer = $q.defer()

        $http.post(
            accountUrl,
            newTrainer
        ).then(function successCallback(response) {
            if (_.isNil(response.data) === false)
                me.trainers.push(response.data);

            defer.resolve(me.practicer);
        }, function errorCallback(response) {
            defer.reject(response);
        });


        return defer.promise;
    }

    me.getTrainer = function (id) {
        var defer = $q.defer()

        var index = _.findIndex(me.trainers, function (t) { return t.id = id; });
        if (index < 0) {
            $http({
                method: 'GET',
                url: accountUrl + '/' + id
            }).then(function successCallback(response) {
                if (_.isNil(response.data) === false) {
                    me.trainers.push(data);
                    defer.resolve(response.data);
                }
                defer.reject(me.practicer);
            }, function errorCallback(response) {
                defer.reject(response);
            });
        }
        else {
            defer.resolve(me.trainers[index]);
        }
        defer.resolve(null);

        return defer.promise;
    }

    me.getTrainerSchedule = function (trainerId) {
        var defer = $q.defer();

        $http({
            method: 'GET',
            url: agendaUrl
        }).then(function successCallback(response) {
            if (_.isNil(response.data) === false)
                me.trainerSchedule = response.data;
            defer.resolve(_.filter(me.trainerSchedule, function (trainerSchedule) {
                return trainerSchedule.trainerId == trainerId;
            }));
        }, function errorCallback(response) {
            defer.reject(response);
        });
        return defer.promise;
    }

    me.addTrainerSchedule = function (trainerSchedule) {
        var defer = $q.defer()

        $http.post(
            agendaUrl,
            trainerSchedule
        ).then(function successCallback(response) {
            if (_.isNil(response.data) === false)
                me.trainerSchedule.push(trainerSchedule);

            defer.resolve(trainerSchedule);
        }, function errorCallback(response) {
            defer.reject(response);
        });


        return defer.promise;

    }

    
    me.initialize();

}])
