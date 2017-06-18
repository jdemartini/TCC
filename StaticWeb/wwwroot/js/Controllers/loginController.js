var app = angular.module('PilatesApp');
app.controller('loginController', ['$scope', '$mdDialog', 'loginService', 'trainerService', 'practicerService',
    function ($scope, $mdDialog, loginService, trainerService, practicerService) {
        $scope.initialize = function () {
            var promise;
            if (_.lowerCase(loginService.getLoginAs().icon) == 'trainer') {
                promise = trainerService.getTrainers();
            } else {
                promise = practicerService.getPracticers();
            }

            promise.then(function (r) {
                $scope.users = r;
            });
        }

        $scope.performLogin = function (user){
            loginService.performLogin(user);

            $mdDialog.hide();
        }

        $scope.initialize();
    }
]);
