(function () {
    "use strict";
    angular.module('oMoney').controller('editCategoryModalController', ['$scope', '$modalInstance', 'category', function ($scope, $modalInstance, category) {

        $scope.category = {
            id: category.id,
            planned: category.planned,
            spent: category.spent,
            currency: category.currency,
            name: category.name
        };

        $scope.create = function () {
            $modalInstance.close($scope.category);
        }

    }]);
}());