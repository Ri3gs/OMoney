(function (module) {
    'use strict';
    module.controller('currencyController', ['currencyService', 'currencyResource', function (currencyService, currencyResource) {

        var vm = this;

        currencyService.get().$promise.then(function(data) {
            vm.currencies = data;
        });

        vm.deleteCurrency = function (index) {
            vm.currencies[index].$delete({ id: vm.currencies[index].id }, function () {
                vm.currencies.splice(index, 1);
            });
        };

        vm.addCurrency = function () {
            vm.inserted = new currencyResource({
                code: '',
                name: ''
            });
            vm.currencies.push(vm.inserted);
        };

        vm.cancel = function(index) {
            if (vm.currencies[index].id != undefined) {
                // old one and cancel
            } else {
                vm.currencies.splice(index, 1);
            }
        }

        vm.saveCurrency = function(data, index) {
            if (vm.currencies[index].id != undefined && vm.currencies[index].userId != undefined) {
                vm.currencies[index].$update();
            } else {
                vm.currencies[index].$save();
            }
        }



    }]);
}(angular.module('oMoney')));