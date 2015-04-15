(function () {
    'use strict';
    angular.module('oMoney').controller('accountController', ['$scope', '$location', '$modal', '$route', 'accounts', 'accountsService', 'notificationService', function($scope, $location, $modal, $route, accounts, accountsService, notificationService) {
            $scope.accounts = accounts;
            $scope.deleteAccountViewModel = {};

            $scope.delete = function(id) {
                
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