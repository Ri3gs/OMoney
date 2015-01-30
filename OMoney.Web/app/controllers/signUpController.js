(function () {

    "use strict";

    angular.module("oMoney")
        .controller("signupController", ["$state", "userResource", signupController]);

    function signupController($state, userResource) {
        var vm = this;
        vm.User = {};

        vm.submit = function () {
                var user = new userResource(vm.User);
                user.$save(function(data) {
                    toastr.success("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации.");
                });
            $state.go("success");
        }

        vm.cancel = function () {
            $state.go("home");
        }
    };
}());