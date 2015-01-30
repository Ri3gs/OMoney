
(function () {
    var app = angular.module("oMoney", ["common.services", "ui.router", "ngMessages"]);


    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider.state("home", {
                url: "/",
                templateUrl: "app/welcome.html"
            })
            .state("signUp", {
                url: "/signup",
                templateUrl: "app/users/signup.html",
                controller: "SignUpCtrl as suCtrl"
            })
            .state("success", {
                url: "/success",
                templateUrl: "app/users/success.html"
            })
            .state("login", {
                url: "login",
                templateUrl: "app/templates/login.html",
                controller: "loginController as loginController"
            })
            .state("profile", {
                url: "profile",
                templateUrl: "app/templates/profile.html",
                controller: "profileController as profileController"
            });
    }]);


    var pwCheck = function () {
        return {
            require: 'ngModel',
            link: function(scope, elem, attrs, ctrl) {
                var firstPassword = '#' + attrs.pwCheck;
                elem.add(firstPassword).on('keyup', function() {
                    scope.$apply(function() {
                        // console.info(elem.val() === $(firstPassword).val());
                        ctrl.$setValidity('pwmatch', elem.val() === $(firstPassword).val());
                    });
                });
            }
        }
    };

    app.directive("pwCheck", pwCheck);
}());