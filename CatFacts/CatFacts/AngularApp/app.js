var catApp = angular.module('cats', []);

catApp.controller("catController", function ($scope) {
    $scope.itemInAngularScope = "This is from scope.";
});