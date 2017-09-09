(function (module) {
    'use strict';
    module.factory('currencyResource', ['$resource', 'appSettings', currencyResource]);

    function currencyResource($resource, appSettings) {
        return $resource(appSettings.serverUrl + "/currency", null, {
            'update': { method: 'PUT' }
        });
    }
}(angular.module('oMoney')));