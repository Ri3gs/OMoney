(function () {
    var app = angular.module("oMoney", ["ngRoute", "ngMessages", "ngCookies", "ngResource", "LocalStorageModule", "ui.bootstrap", "pascalprecht.translate", "tmh.dynamicLocale", "xeditable"]);

    app.config(function($routeProvider) {
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "app/templates/home.html"
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

        $routeProvider.when("/currencies", {
            controller: "currencyController",
            controllerAs: "vm",
            templateUrl: "app/templates/currencies.html"
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

        $routeProvider.when("/accounts", {
            controller: "accountController",
            controllerAs: "vm",
            templateUrl: "app/templates/accounts.html"
        });

        $routeProvider.when("/editaccount", {
            controller: "editAccountController",
            templateUrl: "app/templates/editAccount.html",
            access: {
                requiresLogin: true
            },
            resolve : {
                account: function ($route, accountsService) {
                    return accountsService.getAccount($route.current.params.id).then(function (data) {
                        return data.data;
                    });
                }
            }
        });

        $routeProvider.when("/plans", {
            controller: "plansController",
            templateUrl: "app/templates/plans.html",
            access: {
                requiresLogin: true
            },
            resolve: {
                plans: function(plansService) {
                    return plansService.getAll().then(function(data) {
                        return data.data;
                    });
                }
            }
        });

        $routeProvider.otherwise({ redirectTo: '/home' });

    });

    app.config(function($httpProvider) {
        $httpProvider.interceptors.push("authInterceptorService");
    });

    app.config(function($translateProvider) {
        $translateProvider.useStaticFilesLoader({
            prefix: 'app/localization/locale-', // path to translations files
            suffix: '.json' // suffix, currently- extension of the translations
        });
        $translateProvider.preferredLanguage('en_US'); // is applied on first load
        $translateProvider.useLocalStorage(); // saves selected language to localStorage
    });

    app.config(function(tmhDynamicLocaleProvider) {
        tmhDynamicLocaleProvider.localeLocationPattern('scripts/i18n/angular-locale_{{locale}}.js');
    });

    app.constant('LOCALES', {
        'locales': {
            'ru_RU': 'Русский',
            'en_US': 'English'
        },
        'preferredLocale': 'en_US'
    });

    app.run(["$rootScope", "$location", "$anchorScroll", "authService", "editableOptions",
        function ($rootScope, $location, $anchorScroll, authService, editableOptions) {

            $anchorScroll.yOffset = 50;

            editableOptions.theme = 'bs3';

            authService.authenticate();

            $rootScope.$on("$routeChangeStart", function (event, next) {
                if (next !== undefined && next.access !== undefined) {
                    if (next.access.requiresLogin === true && !authService.authentication.isAuthenticated) {
                        $location.path("/login");
                    }
                }
            });

    }]);
}());