(function () {
    "use strict";
    angular.module("oMoney").controller("loginController", ["$state", "userResource", loginController]);

    function loginController($state, userResource) {
        var vm = this;
        vm.User = {};

        vm.login = function () {
            var user = new userResource(vm.User);
            user.$save(function (data) {
                $state.go("profile");
            });
        }

        vm.cancel = function () {
            $state.go("home");
        }
    };
}());