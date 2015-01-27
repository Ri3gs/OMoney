(function () {

    "use strict";

    angular.module("oMoney")
        .controller("SignUpCtrl", ["$state", "userResource", SignUpCtrl]);

    function SignUpCtrl($state, userResource) {
        var vm = this;
        vm.User = {};

        vm.submit = function () {
                var user = new userResource(vm.User);
                user.$save(function(data) {
                    toastr.success("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации.");
                });
            $state.go("home");
        }

        vm.cancel = function () {
            $state.go("home");
        }
    };
}());