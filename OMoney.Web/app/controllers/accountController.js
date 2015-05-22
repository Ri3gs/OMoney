(function (module) {
    'use strict';
    module.controller('accountController', ['accountsService', 'accountsResource', function (accountsService, accountsResource) {

        var vm = this;

        accountsService.get(function(data) {
            vm.accounts = data;
        }, function() {
            alert("Bad");
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