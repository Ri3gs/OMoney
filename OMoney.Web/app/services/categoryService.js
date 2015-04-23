(function () {
    'use strict';

    angular.module('oMoney').factory('categoryService', ['$http', 'authService', function ($http, authService) {
        var serviceBaseUrl = 'http://localhost:4586/api/category/';
        var categoryServiceFactory = {};

        var createCategory = function (category) {
            return $http.post(serviceBaseUrl + 'create', category).then(function (response) {
                return response;
            });
        };

        categoryServiceFactory.createCategory = createCategory;

        return categoryServiceFactory;
    }]);
}());