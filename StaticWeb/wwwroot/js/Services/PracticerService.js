var app = angular.module('PilatesApp');

app.service('practicerService', ['$http', '$q', function ($http, $q) {
    var me = this;
    me.initialize = function() {
        me.practicer = [];

        me.practicer.push({
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

        me.trainerSchedule = [];
        me.populatePracticerSchedule();
    }

    me.getPracticers = function () {
        var defer = $q.defer()

        setTimeout(function () {
            if (me.practicer.length > 0)
                defer.resolve(me.practicer);
            else {
                defer.reject(me.practicer);
            }
        }, 500);
        
        return defer.promise;
    }

    me.addPracticer = function (newPracticer) {
        var defer = $q.defer()

        setTimeout(function () {
            if (_.isNil(me.practicer)) {
                me.practicer = []
                defer.resolve(me.practicer);
            }

            newPracticer.id = _.random(100000, 999999);
            me.practicer.push(newPracticer);

        }, 500);

        return defer.promise;
    }

    me.getPracticer = function (id) {
        var defer = $q.defer()

        setTimeout(function () {
            if (_.isNil(me.practicer)) {
                defer.resolve(null);
            }
            var index = _.findIndex(me.practicer, function (t) { return t.id = id; });
            if (index >= 0) {
                defer.resolve(me.practicer[index]);
            }
            defer.resolve(null);

        }, 500);

        return defer.promise;
    }

    me.getPracticerSchedule = function (practicer) {

    }

    me.populatePracticerSchedule = function () {

    }

    me.initialize();

}])
