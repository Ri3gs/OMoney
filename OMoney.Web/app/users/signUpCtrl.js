(function () {

    "use strict";

    angular.module("oMoney")
        .controller("SignUpCtrl", ["$state", "userResource", SignUpCtrl]);

    function SignUpCtrl($state, userResource) {
        var vm = this;
        vm.User = {};

        vm.submit = function (isValid) {
            if (isValid) {
                var user = new userResource(vm.User);
                user.$save();
                alert("Success!");
            } else {
                alert("Make sure each input is correct");
            }
        }

        vm.cancel = function () {
            $state.go("home");
        }
    };
}());