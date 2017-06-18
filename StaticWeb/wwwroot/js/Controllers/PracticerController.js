var app = angular.module('PilatesApp');
app.controller('practicerController', ['$scope', '$mdDialog', 'practicerService',
    function ($scope, $mdDialog, trainerService) {
        
        $scope.initialize = function () {
            $scope.newPracticer = {}
        }

        $scope.savePracticer = function () {
            trainerService.addPracticer($scope.newPracticer);
            $mdDialog.hide();

        }

        $scope.cancelPracticer = function () {
            $scope.newPracticer = {};
            $mdDialog.hide();
        }

        $scope.initialize();
    }
]);