﻿(function () {
    'use strict';

    angular.module('oMoney').controller('navigationController', ['$scope', '$location', 'authService', function($scope, $location, authService) {
        $scope.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };

        $scope.authentication = authService.authentication;
    }]);
}());