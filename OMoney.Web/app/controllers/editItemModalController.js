(function () {
    "use strict";
    angular.module('oMoney').controller('editItemModalController', ['$scope', '$modalInstance', 'item', function ($scope, $modalInstance, item) {

        $scope.item = {
            name: item.name,
            id: item.id
        };

        $scope.create = function () {
            $modalInstance.close($scope.item);
        }

    }]);
}());