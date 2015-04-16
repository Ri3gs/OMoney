(function () {
    'use strict';
    angular.module('oMoney').controller('accountController', ['$scope', '$location', '$modal', '$route', 'accounts', 'accountsService', 'notificationService', function($scope, $location, $modal, $route, accounts, accountsService, notificationService) {
            $scope.accounts = accounts;
            $scope.deleteAccountViewModel = {};
            $scope.editAccountViewModel = {};

            $scope.editaccount = function (account) {

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
            }

            $scope.delete = function (id) {
                
                var modalInstance = $modal.open({
                    templateUrl: 'app/templates/deleteAccountModal.html',
                    controller: 'deleteAccountModalController',
                    size: 'lg',
                    resolve: {
                         id: function () {
                             return id;
                         }
                    }
                });
            }


            $scope.open = function() {

                var modalInstance = $modal.open({
                    templateUrl: 'app/templates/createAccountModal.html',
                    controller: 'createAccountModalController',
                    size: 'lg'
                });
            }

        }
    ]);
}());