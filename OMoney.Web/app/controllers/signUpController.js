(function () {

    "use strict";

    angular.module("oMoney")
        .controller("signupController", ["$state", "userResource", signupController]);

    function signupController($state, userResource) {
        var vm = this;
        vm.User = {};
        vm.unavailableemail = false;
        vm.submit = function () {

            var resource = new userResource();
            resource.$query({ email: vm.User.Email }, function () {
                var user = new userResource(vm.User);
                user.$save(function (data) {
                    $state.go("activation");
                }, function() {
                    toastr.error("Ошибка на стороне сервера");
                });
            }, function () {
                vm.unavailableemail = true;
            });
        }

        vm.cancel = function () {
            $state.go("home");
        }
    };
}());