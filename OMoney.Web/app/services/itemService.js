(function () {
    'use strict';

    angular.module('oMoney').factory('itemService', ['$http', 'authService', function ($http, authService) {
        var serviceBaseUrl = 'http://localhost:4586/api/catitems/';
        var itemServiceFactory = {};

        var createItem = function (item) {
            return $http.post(serviceBaseUrl + 'create', item).then(function (response) {
                return response;
            });
        };

        var updateItem = function (item) {
            return $http.post(serviceBaseUrl + 'update', item).then(function (response) {
                return response;
            });
        };

        var deleteItem = function (item) {
            return $http.get(serviceBaseUrl + 'delete', { params: { id: item.id } }).then(function (response) {
                return response;
            });
        };

        itemServiceFactory.createItem = createItem;
        itemServiceFactory.deleteItem = deleteItem;
        itemServiceFactory.updateItem = updateItem;

        return itemServiceFactory;
    }]);
}());