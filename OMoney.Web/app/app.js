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
    });

    app.run(['authService', function(authService) {
        authService.authenticate();
    }]);
}());