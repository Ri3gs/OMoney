(function () {
    "use strict";
    angular.module('oMoney').controller('createCategoryModalController', ['$scope', '$modalInstance', 'authService', function ($scope, $modalInstance, authService) {

        $scope.newCategory = {};

        $scope.create = function () {
            $modalInstance.close($scope.newCategory);
        }

    }]);
}());