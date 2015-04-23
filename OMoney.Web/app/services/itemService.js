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

        itemServiceFactory.createItem = createItem;

        return itemServiceFactory;
    }]);
}());