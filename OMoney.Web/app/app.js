(function () {
    var app = angular.module("oMoney", ["ngRoute", "ngMessages", "LocalStorageModule"]);

    app.config(function($routeProvider) {
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "app/templates/home.html"
        });

        $routeProvider.when("/signup", {
            controller: "signupController",
            templateUrl: "app/templates/signup.html"
        });

        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "app/templates/login.html"
        });

        $routeProvider.when("/activation", {
            controller: "activationController",
            templateUrl: "app/templates/activation.html"
        });

        $routeProvider.when("/profile", {
            controller: "profileController",
            templateUrl: "app/templates/profile.html",
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when("/emailconfirmation", {
            controller: "emailConfirmationController",
            templateUrl: "app/templates/emailconfirmation.html"
        });

        $routeProvider.when("/changepassword", {
            controller: "changePasswordController",
            templateUrl: "app/templates/changepassword.html",
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when("/restorepassword", {
            controller: "restorePasswordController",
            templateUrl: "app/templates/restorepassword.html"
        });

        $routeProvider.when("/resetpassword", {
            controller: "resetPasswordController",
            templateUrl: "app/templates/resetpassword.html"
        });

    });

    app.config(function($httpProvider) {
        $httpProvider.interceptors.push("authInterceptorService");
    });

    app.run(["$rootScope", "$location", "authService", function ($rootScope, $location, authService) {

        authService.authenticate();

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (next.access !== undefined) {
                if (next.access.requiresLogin === true && !authService.authentication.isAuthenticated) {
                    $location.path("/login");
                }
            }
        });

    }]);
}());