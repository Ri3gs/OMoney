(function (module) {
    'use strict';
    module.factory('accountsResource', ['$resource', 'appSettings', accountsResource]);

    function accountsResource($resource, appSettings) {
        return $resource(appSettings.serverUrl + "/account", null, {
            'update': { method: 'PUT' }
        });
    }
}(angular.module('oMoney')));