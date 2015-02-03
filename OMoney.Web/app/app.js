(function () {
    var app = angular.module("oMoney", ['ngRoute', 'LocalStorageModule']);

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
            templateUrl: "app/templates/profile.html"
        });

        $routeProvider.when("/emailconfirmed", {
            templateUrl: "app/templates/emailconfirmed.html"
        });

        $routeProvider.when("/changepassword", {
            controller: "changePasswordController",
            templateUrl: "app/templates/changepassword.html"
        });

        $routeProvider.when("/passwordchanged", {
            templateUrl: "app/templates/passwordchanged.html"
        });

        $routeProvider.when("/restorepassword", {
            controller: "restorePasswordController",
            templateUrl: "app/templates/restorepassword.html"
        });

        $routeProvider.when("/restoreemailsent", {
            templateUrl: "app/templates/restoreemailsent.html"
        });

        $routeProvider.when("/resetpassword", {
            controller: "resetPasswordController",
            templateUrl: "app/templates/resetpassword.html"
        });

        $routeProvider.when("/passwordrestored", {
            templateUrl: "app/templates/passwordrestored.html"
        });
    });

    app.run(['authService', function(authService) {
        authService.authenticate();
    }]);
}());