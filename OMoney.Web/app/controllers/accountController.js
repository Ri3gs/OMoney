(function (module) {
    'use strict';
    module.controller('accountController', ['accountsService', function (accountsService) {

        var vm = this;

        accountsService.get(function(data) {
            vm.accounts = data;
        });

        //$scope.currencies = ['гривна', 'доллар', 'евро'];
        //$scope.accounts = accounts.$values;

        //console.log($scope.accounts);

        //    $scope.editaccount = function (account) {
        //        modalService.openAccountModal(account);
        //    }

        //    $scope.delete = function (account) {
        //        modalService.deleteAccountModal(account);
        //    }

        //    $scope.open = function() {
        //        modalService.openAccountModal({});
        //    }

    }]);
}(angular.module('oMoney')));