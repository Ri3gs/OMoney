(function () {
    "use strict";
    angular.module("oMoney").controller("profileController", ["$state", "userResource", profileController]);

    function profileController($state, userResource) {
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