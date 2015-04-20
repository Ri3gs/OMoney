(function () {
    'use strict';

    angular.module('oMoney').factory('modalService', ['$http', '$modal', '$route', 'accountsService', 'authService', 'notificationService', function ($http, $modal, $route, accountsService, authService, notificationService) {
        var modalServiceFactory = {};

        var openAccountModal = function (account) {

            var modalInstance = $modal.open({
                templateUrl: 'app/templates/editAccountModal.html',
                controller: 'editAccountModalController',
                size: 'lg',
                resolve: {
                    account: function () {
                        return account;
                    }
                }
            });

            modalInstance.result.then(function (accountResult) {
                if (accountResult.id == undefined || accountResult.id == null) {
                    accountsService.createAccount(accountResult).then(function () {
                        $route.reload();
                    }, function (response) {
                        notificationService.exception(response.data);
                    });
                } else {
                    accountsService.updateAccount(accountResult).then(function() {
                        $route.reload();
                    }, function(response) {
                        notificationService.exception(response.data);
                    });
                }
            }, function() {
                console.log('Modal dissmissed');
            });

        }

        var deleteAccountModal = function (account) {

            var modalInstance = $modal.open({
                templateUrl: 'app/templates/deleteAccountModal.html',
                size: 'lg'
            });

            modalInstance.result.then(function() {
                accountsService.deleteAccount(account).then(function (response) {
                    $route.reload();
                }, function (response) {
                    notificationService.exception(response.data);
                });
            }, function() {
                console.log('Modal dissmissed');
            });

        }

        modalServiceFactory.openAccountModal = openAccountModal;
        modalServiceFactory.deleteAccountModal = deleteAccountModal;

        return modalServiceFactory;
    }]);
}());