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
                    icon: 'practicer'
                });
                $scope.showPracticerSchedule();
                
            });
        } else
        {
            $scope.showPracticerSchedule();
        }
        $scope.practicerClasses = [];
        $scope.selectedClass = {};

        $scope.daysOfWeek = [];
        $scope.daysOfWeek[0] = 'Sunday'
        $scope.daysOfWeek[1] = 'Monday'
        $scope.daysOfWeek[2] = 'Tuesday'
        $scope.daysOfWeek[3] = 'Wednesday'
        $scope.daysOfWeek[4] = 'Thursday'
        $scope.daysOfWeek[5] = 'Friday'
        $scope.daysOfWeek[6] = 'Saturday'
        
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
        if (_.isNil($scope.selectedClass) === false &&
            _.indexOf($scope.practicerClasses, $scope.selectedClass) < 0)
            $scope.practicerClasses.push($scope.selectedClass);
        $scope.selectedClass = null;
    }

    $scope.removeClass = function (cls) {
        var index = _.indexOf($scope.practicerClasses, cls);
        if (index >= 0)
            _.remove($scope.practicerClasses, function (clsTemp) {
                return cls === clsTemp;
            });
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
            var practicerData = {
                practicerId: loginService.getLoggedUser().id,
                classes: []
            }
            _.forEach($scope.practicerClasses, function (cls) {
                var data = {
                    trainerId: cls.trainerId,
                    dayBegin: moment().toDate(),
                    dayEnd: moment().add(1, 'year').toDate(),
                    dayOfWeek: cls.dayOfWeek,
                    timeOfDay: cls.time
                }
                practicerData.classes.push(data)
                
            });
            practicerService.savePracticerClasses(practicerData).then(function (result) {
                $scope.showPracticerSchedule();
            });
            $mdDialog.hide();
        }
    }

    $scope.showPracticerSchedule = function () {
        practicerService.getPracticerSchedule(loginService.getLoggedUser().id).then(function (practicerSchedule) {
            $scope.practicerCalendarSchedule = [];
            _.forEach(practicerSchedule, function (pSchedule) {
                _.forEach(pSchedule.classes, function (daySchedule) {

                    var firstDay = findFirstAfter(daySchedule.dayBegin, daySchedule.dayOfWeek);
                    while (firstDay < daySchedule.dayEnd || firstDay < moment().add(1, 'years')) {
                        var start = moment(firstDay);
                        start.set({ hour: daySchedule.timeOfDay, minute: 0 });
                        var end = moment(firstDay);
                        end.set({ hour: daySchedule.timeOfDay + 1, minute: 0 });

                        $scope.practicerCalendarSchedule.push(createCalendarEvent(
                            loginService.getLoggedUser().name,
                            start.toDate(),
                            end.toDate(),
                            false
                        ));


                        firstDay = moment(firstDay).add(7, 'days');
                    }
                });
            });
        });
    }

    findFirstAfter = function (afterThis, thisWeekDay) {
        var result = moment(afterThis);

        for (var i = 0; i < 7; i++) {
            afterThis = moment(afterThis).add(1, 'days');
            if (afterThis.isoWeekday() == thisWeekDay) {
                result = moment(afterThis);
                break;
            }
        }

        return result;
    }

    $scope.initialize();

}]);
