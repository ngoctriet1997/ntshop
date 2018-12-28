var myApp = angular.module("myModule", []);

myApp.controller("myController", myController);

myController.$inject = ['$scope'];
function myController($rootscope,$scope) {

    $rootscope.message = "this is my message from controller";
}