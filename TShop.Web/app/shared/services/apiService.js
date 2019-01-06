(function (app) {
    app.service('apiService', apiService);
    apiService.$inject = ['$http','notificationService','authenticationService'];

    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del:del
        }
        function del(url, data, success, failed) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status == '401') {
                    notificationService.displayError('Authenticate is required.');
                }
                failed(error);
            });
        }
        function get(url, params, success, failed) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                
                success(result);
            }, function (error) {
                
                failed(error);
            });
        }
        function post(url, data, success, failed) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status == '401') {
                    notificationService.displayError('Authenticate is required.');
                } 
                failed(error);
            });
        }
        function put(url, data, success, failed) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status == '401') {
                    notificationService.displayError('Authenticate is required.');
                }
                failed(error);
            });
        }
    }
})(angular.module('tshop.common'));