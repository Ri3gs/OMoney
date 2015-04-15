(function () {
    'use strict';
    angular.module('oMoney').controller('accountController', ['$scope', '$location', '$modal', 'accounts', 'accountsService', 'notificationService', function($scope, $location, $modal, accounts, accountsService, notificationService) {
            $scope.accounts = accounts;
            $scope.deleteAccountViewModel = {};

            $scope.delete = function(id) {
                $scope.deleteAccountViewModel.id = id;
                accountsService.deleteAccount($scope.deleteAccountViewModel).then(function(response) {
                    $location.path("/accounts");
                }, function(response) {
                    notificationService.exception(response.data);
                });
            }


            $scope.open = function() {

                var modalInstance = $modal.open({
                    templateUrl: 'app/templates/createAccountModal.html',
                    controller: 'createAccountModalController',
                    size: 'lg'
                });

                modalInstance.result.then(function() {
                    console.log("OK");
                }, function() {
                    console.log("CLOSED");
                });
            }

        }
    ]);
}());