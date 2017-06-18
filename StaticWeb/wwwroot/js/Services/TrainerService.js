var app = angular.module('PilatesApp');

app.service('trainerService', ['$http', '$q', function ($http, $q) {
    var me = this;
    me.initialize = function() {
        me.trainers = [];

        me.trainers.push({
            id: '132456',
            name: 'Eduardo',
            email: 'eduardo@studio.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
        me.trainers.push({
            id: '132457',
            name: 'Renata',
            email: 'renata@studio.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });
        me.trainers.push({
            id: '132458',
            name: 'Iza',
            email: 'iza@studio.com',
            phone: '5199999999',
            studioName: 'Zenfit'
        });

        me.trainerSchedule = [];
        me.populateTrainerSchedule();
    }

    me.getTrainers = function () {
        var defer = $q.defer()

        setTimeout(function () {
            if (me.trainers.length > 0)
                defer.resolve(me.trainers);
            else {
                defer.reject(me.trainers);
            }
        }, 1000);
        
        return defer.promise;
    }

    me.addTrainer = function (newTrainer) {
        var defer = $q.defer()

        setTimeout(function () {
            if (_.isNil(me.trainers)) {
                me.trainers = []
                defer.resolve(me.trainers);
            }

            newTrainer.id = _.random(100000, 999999);
            me.trainers.push(newTrainer);

        }, 500);

        return defer.promise;
    }

    me.getTrainer = function (id) {
        var defer = $q.defer()

        setTimeout(function () {
            if (_.isNil(me.trainers)) {
                defer.resolve(null);
            }
            var index = _.findIndex(me.trainers, function (t) { return t.id = id; });
            if (index >= 0) {
                defer.resolve(me.trainers[index]);
            }
            defer.resolve(null);

        }, 500);

        return defer.promise;
    }

    me.getTrainerSchedule = function (trainerId) {
        var defer = $q.defer();
        setTimeout(function () {
            defer.resolve(_.filter(me.trainerSchedule, function (trainerSchedule) {
                return trainerSchedule.trainerId == trainerId;
            }));

        }, 500);
        return defer.promise;
    }

    me.addTrainerSchedule = function (trainerSchedule) {
        me.trainerSchedule.push(trainerSchedule);
        return me.getTrainerSchedule(trainerSchedule.trainerId); 
    }


    me.populateTrainerSchedule = function () {

    }

    me.initialize();

}])
