(function () {
    "use strict";
    angular.module('oMoney').controller('editItemModalController', ['$scope', '$modalInstance', 'item', function ($scope, $modalInstance, item) {

        $scope.item = {
            Name: item.name,
            Id: item.id,
            Price: item.price,
            CategoryId: item.categoryId,
            buyed: item.buyed
    };

        $scope.create = function() {
            $modalInstance.close($scope.item);
        }

        $scope.editAndBuy = function () {
            $scope.item.Buyed = true;
            $modalInstance.close($scope.item);
        }

        $scope.sell = function() {
            $scope.item.sold = true;
            $modalInstance.close($scope.item);
        }

    }]);
}());