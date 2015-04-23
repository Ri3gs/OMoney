(function () {
    'use strict';
    angular.module('oMoney').controller('accountController', ['$scope', '$location', '$modal', '$route', 'accounts', 'modalService', function ($scope, $location, $modal, $route, accounts, modalService) {
        $scope.currencies = ['гривна', 'доллар', 'евро'];
        $scope.accounts = accounts.$values;

        console.log($scope.accounts);

            $scope.editaccount = function (account) {
                modalService.openAccountModal(account);
            }

            $scope.delete = function (account) {
                modalService.deleteAccountModal(account);
            }

            $scope.open = function() {
                modalService.openAccountModal({});
            }

        }]);
}());