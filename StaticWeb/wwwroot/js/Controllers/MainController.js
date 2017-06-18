var app = angular.module('PilatesApp');
app.controller('PilatesCtrl', ['$scope', '$mdBottomSheet', '$mdSidenav', '$mdDialog', '$location', 'loginService', 'trainerService', 'practicerService',
    function ($scope, $mdBottomSheet, $mdSidenav, $mdDialog, $location, loginService, trainerService, practicerService) {
    $scope.initialize = function () {
        $scope.user = {};

        $scope.users = [];

        $scope.selectedLogin = {};

        loginService.subscribeLoginEvent($scope.loginEvent);

        $scope.menu = [
            {
                link: 'trainerSchedule',
                title: 'Trainer',
                icon: 'trainer'
            },
            {
                link: 'practicerCalendar',
                title: 'Practicer',
                icon: 'practicer'
            },
            {
                
                link: '',
                title: 'Studio',
                icon: 'Studio'
            }
        ];

        $scope.admin = [
            {
                link: 'views/crudTrainer.html',
                title: 'Add trainer',
                icon: 'trainer'
            },
            {
                link: 'views/crudPracticer.html',
                title: 'Add Practicer',
                icon: 'practicer'
            }
        ];
    };

    $scope.toggleSidenav = function (menuId) {
        $mdSidenav(menuId).toggle();
    };

    $scope.showLogin = function (item, ev) {
        $scope.selectedLogin = item;
        loginService.setLoginAs(item);
        $mdDialog.show({
            controller: DialogController,
            templateUrl: 'views/login.html',
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose: true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })
    }

    $scope.loginEvent = function (user, logedAs)
    {
        $scope.user = user;
        $mdDialog.hide();

        $location.path(loginService.getLoginAs().link);
    }
    
    $scope.showForm = function (item, ev) {

        $mdDialog.show({
            controller: DialogController,
            templateUrl: item.link,
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose: true,
            fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.
        })
    }

    function DialogController($scope, $mdDialog) {
        $scope.hide = function () {
            $mdDialog.hide();
        };

        $scope.cancel = function () {
            $mdDialog.cancel();
        };

        $scope.answer = function (answer) {
            $mdDialog.hide(answer);
        };
    }

    $scope.initialize();
}]);