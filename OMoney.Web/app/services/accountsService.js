(function () {
    'use strict';

    angular.module('oMoney').factory('accountsService', ['$http', 'authService', function ($http, authService) {
        var serviceBaseUrl = 'http://localhost:4586/api/account/';
        var accountServiceFactory = {};

        var createAccount = function (createAccountViewModel) {
            createAccountViewModel.email = authService.authentication.userName;
            return $http.post(serviceBaseUrl + 'create', createAccountViewModel).then(function (response) {
                return response;
            });
        }

        var getAccounts = function() {
            return $http.post(serviceBaseUrl + 'list', { email: authService.authentication.userName }).then(function (response) {
                return response;
            });
        }

        var deleteAccount = function (deleteAccountViewModel) {
            deleteAccountViewModel.email = authService.authentication.userName;
            return $http.post(serviceBaseUrl + 'delete', deleteAccountViewModel).then(function (response) {
                return response;
            });
        }

        var updateAccount = function(updateAccountViewModel) {
            return $http.post(serviceBaseUrl + 'update', updateAccountViewModel).then(function (response) {
                return response;
            });
        }

        var getAccount = function(Id) {
            return $http.post(serviceBaseUrl + 'getaccount', { id: Id }).then(function (response) {
                return response;
            });
        }

        accountServiceFactory.updateAccount = updateAccount;
        accountServiceFactory.createAccount = createAccount;
        accountServiceFactory.deleteAccount = deleteAccount;
        accountServiceFactory.getAccounts = getAccounts;
        accountServiceFactory.getAccount = getAccount;

        return accountServiceFactory;
    }]);
}());