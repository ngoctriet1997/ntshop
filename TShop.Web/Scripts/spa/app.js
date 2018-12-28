var myApp = angular.module("myModule", []);

myApp.controller("myController", myController);
myApp.service("ValidatorService", ValidatorService);
myApp.directive("teduShopDirective", teduShopDirective);

myController.$inject = ['$scope','ValidatorService'];
function myController($scope, Validator) {

   
    $scope.CheckNumber = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }
}

function ValidatorService() {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0)
          return 'this is even';
        else
            return 'this is odd';
    }
}
function teduShopDirective() {
    return {
        templateUrl:"/Scripts/spa/HtmlPage1.html"
    }
}