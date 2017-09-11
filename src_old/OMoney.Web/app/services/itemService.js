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

        var editBuyedItem = function (item) {
            return $http.post(serviceBaseUrl + 'editbuyed', item).then(function (response) {
                return response;
            });
        };

        var editItem = function (item) {
            return $http.post(serviceBaseUrl + 'edit', item).then(function (response) {
                return response;
            });
        };

        var editAndBuyItem = function (item) {
            return $http.post(serviceBaseUrl + 'editandbuy', item).then(function (response) {
                return response;
            });
        };

        var buyItem = function (item) {
            return $http.post(serviceBaseUrl + 'buy', item).then(function (response) {
                return response;
            });
        };

        var sellItem = function (item) {
            return $http.post(serviceBaseUrl + 'sell', item).then(function (response) {
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
        itemServiceFactory.editBuyedItem = editBuyedItem;
        itemServiceFactory.editItem = editItem;
        itemServiceFactory.editAndBuyItem = editAndBuyItem;
        itemServiceFactory.buyItem = buyItem;
        itemServiceFactory.sellItem = sellItem;

        return itemServiceFactory;
    }]);
}());