var myApp = angular.module("myModule", []);

myApp.controller("myController", myController);
myApp.service("Validator", Validator)

myController.$inject = ['$scope','Validator'];
function myController($scope, Validator) {

   
    $scope.CheckNumber = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }
}

function Validator() {
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