(function () {
    'use strict';

    angular.module('oMoney').controller('navigationController', ['$rootScope', '$scope', '$location', '$anchorScroll', 'authService', 'anchorSmoothScrollService', function ($rootScope, $scope, $location, $anchorScroll, authService, anchorSmoothScrollService) {
        $scope.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };

        //$scope.currentRoute = $rootScope.currentPath;
        $scope.currentRoute = $location.path();

        //$scope.$watch(function() {
        //    return $rootScope.currentPath;
        //}, function() {
        //    $scope.currentRoute = $rootScope.currentPath;
        //    console.log("nav: (rootscope) " + $scope.currentRoute);
        //});

        $scope.$watch(function () {
            return $location.path();
        }, function () {
            $scope.currentRoute = $location.path();
            console.log("nav: (location.path) " + $scope.currentRoute);
        });

        $scope.gotoAnchor = function (element) {
            var newHash = element;
            if ($location.hash() !== newHash) {
                // set the $location.hash to `newHash` and
                // $anchorScroll will automatically scroll to it
                $location.hash(element);
            } else {
                // call $anchorScroll() explicitly,
                // since $location.hash hasn't changed
                $anchorScroll();
            }
        };


        $scope.gotoElement = function (eID) {
            // set the location.hash to the id of
            // the element you wish to scroll to.
            $location.hash(eID);

            // call $anchorScroll()
            anchorSmoothScrollService.scrollTo(eID);

        };

        $scope.authentication = authService.authentication;
    }]);
}());