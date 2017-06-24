var app = angular.module('PilatesApp');
app.controller('trainerScheduleController', ['$scope', '$mdBottomSheet', '$mdSidenav', '$mdDialog', 'trainerService', 'loginService', function ($scope, $mdBottomSheet, $mdSidenav, $mdDialog, trainerService, loginService) {
    var me = this;
    $scope.initialize = function () {
        if (_.isNil(loginService.getLoggedUser()) ||
            _.lowerCase(loginService.getLoginAs().icon) != 'trainer')
        {
            trainerService.getTrainers().then(function (r) {
                loginService.performLogin(r[0]);
                loginService.setLoginAs({
                    link: 'views/crudTrainer.html',
                    title: 'Add trainer',
                    icon: 'trainer'
                });
                $scope.loadTrainerSchedule();
            });
        }
        else {
            $scope.loadTrainerSchedule();
        }

        $scope.trainerClasses = [];
        $scope.hours = [];
        for (var i = 0; i < 24; i++) {
            $scope.hours.push(i);
        }
        $scope.selectedHours = [];

        $scope.daysOfWeek = [];
        $scope.daysOfWeek[0] = 'Sunday'
        $scope.daysOfWeek[1] = 'Monday'
        $scope.daysOfWeek[2] = 'Tuesday'
        $scope.daysOfWeek[3] = 'Wednesday'
        $scope.daysOfWeek[4] = 'Thursday'
        $scope.daysOfWeek[5] = 'Friday'
        $scope.daysOfWeek[6] = 'Saturday'
        $scope.selectedDaysOfWeek = [];

        $scope.schedule = {};
        loginService.subscribeLoginEvent($scope.loginEvent);
        me.loadingTrainerSchedule = false;
        
    };

    $scope.loginEvent = function (user) {
        $scope.loadTrainerSchedule();
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
    
    $scope.eventCreate = function (day) {
        /*$scope.trainerClasses.push(createCalendarEvent(
            "Train" + $scope.trainerClasses.length,
            day,
            null,
            true
        ));*/
        $scope.schedule.dateBegin = moment().toDate();
        $scope.schedule.dateEnd = moment().add(1, 'year').toDate();
        $scope.selectedDaysOfWeek = [];
        $scope.selectedHours = [];
        $mdDialog.show({
            controller: () => this,
            controllerAs: 'ctrl',
            templateUrl: 'views/crudTrainerSchedule.html',
            parent: angular.element(document.body),
            
            clickOutsideToClose: true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })
    };

    $scope.eventClicked = function (calendarEvent) {
        
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
    

    $scope.cancelTrainerSchedule = function () {
        $mdDialog.hide();
    }

    $scope.saveTrainerSchedule = function () {
        if (_.lowerCase(loginService.getLoginAs().icon) == 'trainer' &&
            _.isNil(loginService.getLoggedUser()) == false)
        {
            _.forEach($scope.selectedDaysOfWeek, function (day) {
                var data = {
                    trainerId: loginService.getLoggedUser().id,
                    dayOfWeek: _.indexOf($scope.daysOfWeek, day),
                    timesOfDay: $scope.selectedHours,
                    timeMinutesToBegin: 0,
                    maxNumberOfTrainers: 2,
                    dayBegin: $scope.schedule.dateBegin,
                    dayEnd: $scope.schedule.dateEnd,
                }
                trainerService.addTrainerSchedule(data).then(function (r) {
                    $scope.loadTrainerSchedule();
                });
            });

            $mdDialog.hide();
        }
    }

    $scope.loadTrainerSchedule = function () {
        if (me.loadingTrainerSchedule)
            return;
        me.loadingTrainerSchedule = true;
        trainerService.getTrainerSchedule(loginService.getLoggedUser().id)
            .then(function (trainerSchedule) {
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
                })
                me.loadingTrainerSchedule = false;
            }).then(function (fail) {
                me.loadingTrainerSchedule = false;
            });
    }

    findFirstAfter = function (afterThis, thisWeekDay)
    {
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
