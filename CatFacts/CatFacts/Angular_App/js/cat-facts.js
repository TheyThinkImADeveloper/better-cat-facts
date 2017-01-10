var catApp = angular.module("catApp", []);

catApp.controller("CatAppCtrl", ["$scope", "$http", function ($scope, $http) {

    function constructor() {
        $scope.GetCatFacts();
    }

    $scope.title = "Hallo";
    $scope.GetCatFacts = function () {
        $http({
            method: 'GET',
            url: '/api/catfact'
        }).then(function (response) {
            console.log(response);
            $scope.catFacts = response.data;
        });
    };

    $scope.InitializeDelete = function ($index) {
        $http({
            method: 'GET',
            url: '/api/catfact/' + $index
        }).then(function (response) {
            console.log(response);
            $scope.catFactToDelete = {
                fact: response.data,
                index: $index
            };
            $scope.showDeletePrompt = true;
            $scope.showMessageWasDeleted = false;
        });
    }

    $scope.ConfirmDelete = function ($index) {
        $http({
            method: 'DELETE',
            url: '/api/catfact/' + $index
        }).then(function () {
            $scope.showMessageWasDeleted = true;
            $scope.GetCatFacts();
            $scope.showDeletePrompt = false;
        });
    }

    $scope.CancelDelete = function() {
        $scope.showDeletePrompt = false;
    }

    $scope.AddCatFact = function(newFact) {
        $http({
            data: newFact,
            method: 'POST',
            url: '/api/catfact/'
    }).then(function () {
            console.log();
            $scope.GetCatFacts();
        });
    }

    constructor();

}]);


