(function (module) {
    'use strict';
    module.controller('accountController', ['accountsService', 'accountsResource', 'currencyService', function (accountsService, accountsResource, currencyService) {

        var vm = this;

        vm.accountTypes = [{id : 1, text: 'Credit Card'}, {id: 2, text: 'Bank account'}, {id: 3, text: 'Cash'}];

        accountsService.get().$promise.then(function(data) {
            vm.accounts = data;
        });

        currencyService.get().$promise.then(function (data) {
            vm.currencies = data;
        });

        vm.showCurrency = function(id) {
            for (var i = 0; i < vm.currencies.length; i++) {
                if (vm.currencies[i].id === id) {
                    return vm.currencies[i].code;
                }
            }
            return "";
        }

        vm.deleteAccount = function (index) {
            vm.accounts[index].$delete({ id: vm.accounts[index].id }, function () {
                vm.accounts.splice(index, 1);
            });
        };

        vm.addAccount = function () {
            vm.inserted = new accountsResource({
                name: '',
                comments: '',
                amount: 0,
                currencyId: 0,
                accountType: 1
            });
            vm.accounts.push(vm.inserted);
        };

        vm.cancel = function (index) {
            if (vm.accounts[index].id != undefined) {
                // old one and cancel
            } else {
                vm.accounts.splice(index, 1);
            }
        }

        vm.saveAccount = function(data, index) {
            if (vm.accounts[index].id != undefined) {
                vm.accounts[index].$update();
            } else {
                vm.accounts[index].$save();
            }
        }

    }]);
}(angular.module('oMoney')));