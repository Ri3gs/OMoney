(function (module) {
    'use strict';

    module.factory('accountsService', ['$http', 'appSettings', 'accountsResource', function ($http, appSettings, accountsResource) {
        
        var accountServiceFactory = {};

        var get = function() {
            return accountsResource.query();
        };

        var getById = function(id) {
            return accountsResource.get({ id: id });
        };

        //var createAccount = function (createAccountViewModel) {
        //    createAccountViewModel.email = authService.authentication.userName;
        //    return $http.post(serviceBaseUrl + 'create', createAccountViewModel).then(function (response) {
        //        return response;
        //    });
        //}

        //var getAccounts = function() {
        //    return $http.post(serviceBaseUrl + 'list', { email: authService.authentication.userName }).then(function (response) {
        //        return response;
        //    });
        //}

        //var deleteAccount = function (deleteAccountViewModel) {
        //    deleteAccountViewModel.email = authService.authentication.userName;
        //    return $http.post(serviceBaseUrl + 'delete', deleteAccountViewModel).then(function (response) {
        //        return response;
        //    });
        //}

        //var updateAccount = function(updateAccountViewModel) {
        //    return $http.post(serviceBaseUrl + 'update', updateAccountViewModel).then(function (response) {
        //        return response;
        //    });
        //}

        //var getAccount = function(Id) {
        //    return $http.post(serviceBaseUrl + 'getaccount', { id: Id }).then(function (response) {
        //        return response;
        //    });
        //}

        //accountServiceFactory.updateAccount = updateAccount;
        //accountServiceFactory.createAccount = createAccount;
        //accountServiceFactory.deleteAccount = deleteAccount;
        //accountServiceFactory.getAccounts = getAccounts;
        //accountServiceFactory.getAccount = getAccount;

        accountServiceFactory.get = get;
        accountServiceFactory.getById = getById;

        return accountServiceFactory;
    }]);
}(angular.module('oMoney')));