var app = angular.module('PilatesApp');
 
app.controller('practicerCalendarController', ['$scope', '$mdBottomSheet', '$mdSidenav', '$mdDialog', 'practicerService', 'trainerService', 'loginService', function ($scope, $mdBottomSheet, $mdSidenav, $mdDialog, practicerService, trainerService, loginService) {
    var me = this;
    $scope.initialize = function () {

        if (_.isNil(loginService.getLoggedUser()) ||
            _.lowerCase(loginService.getLoginAs().icon) != 'practicer') {
            practicerService.getPracticers().then(function (r) {
                loginService.performLogin(r[0]);
                loginService.setLoginAs({
                    link: 'views/crudPracticer.html',
                    title: 'Add practicer',
                    icon: 'trainer'
                });
                
            });
        }
        $scope.practicerClasses = [];
        $scope.selectedClass = {};

        
        loadAvailableClasses();
        
    };

    loadAvailableClasses = function () {
        $scope.availableClasses = [];
        trainerService.getTrainers().then(function (trainers) {
            me.trainers = trainers;
            _.forEach(trainers, function (trainer) {
                loadClasses(trainer);
            });
        });
    }

    loadClasses = function (trainer) {
        trainerService.getTrainerSchedule(trainer.id).then(function (trainerSchedule) {
            _.forEach(trainerSchedule, function (trainerDay) {
                _.forEach(trainerDay.timesOfDay, function(time){
                    var trainerClass = {
                        trainerId: trainer.id,
                        trainerName: trainer.name,
                        time: time,
                        dayOfWeek: trainerDay.dayOfWeek
                    };
                    $scope.availableClasses.push(trainerClass);
                })
            });
        });
    }

    $scope.addClass = function () {

    }

    $scope.toggle = function (item, list) {
        var idx = list.indexOf(item);
        if (idx > -1) {
            list.splice(idx, 1);
        }
        else {
            list.push(item);
        }
    };

    $scope.choosingTime = function () {
        $mdDialog.show({
            controller: () => this,
            controllerAs: 'ctrl',
            templateUrl: 'views/chooseTime.html',
            parent: angular.element(document.body),

            clickOutsideToClose: true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })
    }

    $scope.eventCreate = function (day) {
        
    };

    $scope.eventClicked = function (calendarEvent) {
        /*$scope.schedule.dateBegin = moment().toDate();
        $scope.schedule.dateEnd = moment().add(1, 'year').toDate();
        $scope.selectedDaysOfWeek = [];
        $scope.selectedHours = [];
        $mdDialog.show({
            controller: () => this,
            controllerAs: 'ctrl',
            templateUrl: 'views/crudPracticerClass.html',
            parent: angular.element(document.body),

            clickOutsideToClose: true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })*/
    };

    createCalendarEvent = function (title, startDate, endDate, allDay) {
        var calendarEvent = {
            title: title,
            start: startDate,
            end: endDate,
            allDay: allDay
        }
        return calendarEvent;
    }


    $scope.cancel = function () {
        $mdDialog.hide();
    }

    $scope.savePracticerClass = function () {
        if (_.lowerCase(loginService.getLoginAs().icon) == 'practicer' &&
            _.isNil(loginService.getLoggedUser()) == false) {
            _.forEach($scope.selectedDaysOfWeek, function (day) {
                var data = {
                    practicerId: loginService.getLoggedUser().id,
                    dayOfWeek: day,
                    timesOfDay: $scope.selectedHours,
                    timeMinutesToBegin: 0,
                    maxNumberOfTrainers: 2,
                    dayBegin: $scope.schedule.dateBegin,
                    dayEnd: $scope.schedule.dateEnd,
                }
                trainerService.addTrainerSchedule(data);
            });
            $scope.showTrainerSchedule();
            $mdDialog.hide();
        }
    }

    $scope.showTrainerSchedule = function () {
        trainerService.getTrainerSchedule(loginService.getLoggedUser().id).then(function (trainerSchedule) {
            $scope.trainerClasses = [];
            _.forEach(trainerSchedule, function (daySchedule) {

                var firstDay = findFirstAfter(daySchedule.dayBegin, daySchedule.dayOfWeek);
                while (firstDay < daySchedule.dayEnd || firstDay < moment().add(1, 'years')) {
                    for (var j = 0; j < daySchedule.timesOfDay.length; j++) {
                        var start = moment(firstDay);
                        start.set({ hour: daySchedule.timesOfDay[j], minute: 0 });
                        var end = moment(firstDay);
                        end.set({ hour: daySchedule.timesOfDay[j] + 1, minute: 0 });

                        $scope.trainerClasses.push(createCalendarEvent(
                            loginService.getLoggedUser().name,
                            start.toDate(),
                            end.toDate(),
                            false
                        ));


                    }
                    firstDay = moment(firstDay).add(7, 'days');
                }
            });
        });
    }

    findFirstAfter = function (afterThis, thisWeekDay) {
        var result = moment(afterThis);

        for (var i = 0; i < 7; i++) {
            afterThis = moment(afterThis).add(1, 'days');
            if (afterThis.isoWeekday() == $scope.daysOfWeek.indexOf(thisWeekDay)) {
                result = moment(afterThis);
                break;
            }
        }

        return result;
    }

    $scope.initialize();

}]);
