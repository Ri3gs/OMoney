(function () {
    "use strict";
    angular.module('oMoney').controller('createItemModalController', ['$scope', '$modalInstance', 'authService', function ($scope, $modalInstance, authService) {

        $scope.newItem = {};

        $scope.create = function () {
            $modalInstance.close($scope.newItem);
        }

    }]);
}());