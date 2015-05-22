(function (module) {
    'use strict';
    module.controller('accountController', ['accountsService', 'accountsResource', function (accountsService, accountsResource) {

        var vm = this;

        accountsService.get(function(data) {
            vm.accounts = data;
        }, function() {
            alert("Bad");
        });


        accountsResource.query(function(data) {
            vm.accounts = data;
        });

        vm.print = function() {
            console.log(vm.accounts);
        }

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