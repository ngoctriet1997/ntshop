﻿(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;

            this.login = function (userName, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + userName + "&password=" + password;
                $http.post('/oauth/token', data, {
                    headers:
                        { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (result) {
                    userInfo = {
                        accessToken: result.data.access_token,
                        userName: userName
                    };
                    authenticationService.setTokenInfo(userInfo);
                
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = userName;
                    deferred.resolve(null);
                },
                    function (error) {
                        authData.authenticationData.IsAuthenticated = false;
                        authData.authenticationData.userName = "";
                        deferred.resolve(error);
                    });
                return deferred.promise;
            }

            this.logOut = function () {
                authenticationService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
            }
        }]);
})(angular.module('tshop.common'));