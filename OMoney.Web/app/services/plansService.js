(function () {
    'use strict';

    angular.module('oMoney').factory('plansService', ['$http', 'authService', function ($http, authService) {
        var serviceBaseUrl = 'http://localhost:4586/api/plan/';
        var plansServiceFactory = {};

        var createPlan = function(plan) {
            return $http.post(serviceBaseUrl + 'create', plan).then(function(response) {
                return response;
            });
        };

        var getAll = function() {
            return $http.get(serviceBaseUrl + 'getall', { params: { email: authService.authentication.userName } }).then(function(response) {
                return response;
            });
        }

        plansServiceFactory.createPlan = createPlan;
        plansServiceFactory.getAll = getAll;

        return plansServiceFactory;
    }]);
}());