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
            $scope.catFacts = response.data;
        });
    }
    $scope.ConfirmDelete = function () {

    }

    constructor();

}]);


