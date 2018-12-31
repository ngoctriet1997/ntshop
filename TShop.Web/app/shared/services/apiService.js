(function (app) {
    app.service('apiService', apiService);
    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get:get
        }
        function get(url, params, success, faillure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failed(error);
            });
        }
    }
})(angular.module('tshop.common'));