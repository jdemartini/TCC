var app = angular.module('PilatesApp');
app.controller('trainerController', ['$scope', '$mdDialog', 'trainerService',
    function ($scope, $mdDialog, trainerService) {
        
        $scope.initialize = function () {
            $scope.newTrainer = {}
        }

        $scope.saveTrainer = function () {
            trainerService.addTrainer($scope.newTrainer);
            $mdDialog.hide();

        }

        $scope.cancelTrainer = function () {
            $scope.newTrainer = {};
            $mdDialog.hide();
        }

        $scope.initialize();
    }
]);