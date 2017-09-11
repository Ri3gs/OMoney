(function (module) {
    'use strict';

    module.factory('currencyService', ['$http', 'appSettings', 'currencyResource', function ($http, appSettings, currencyResource) {

        var currencyServiceFactory = {};

        var get = function () {
            return currencyResource.query();
        };

        currencyServiceFactory.get = get;

        return currencyServiceFactory;
    }]);
}(angular.module('oMoney')));