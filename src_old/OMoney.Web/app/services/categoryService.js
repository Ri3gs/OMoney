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

        var updateCategory = function (category) {
            return $http.post(serviceBaseUrl + 'update', category).then(function (response) {
                return response;
            });
        };

        var deleteCategory = function (category) {
            return $http.get(serviceBaseUrl + 'delete', { params: { id: category.id } }).then(function (response) {
                return response;
            });
        };

        categoryServiceFactory.createCategory = createCategory;
        categoryServiceFactory.deleteCategory = deleteCategory;
        categoryServiceFactory.updateCategory = updateCategory;

        return categoryServiceFactory;
    }]);
}());