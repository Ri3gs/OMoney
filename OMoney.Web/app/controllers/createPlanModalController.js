(function () {
    "use strict";
    angular.module('oMoney').controller('createPlanModalController', ['$scope', '$modalInstance', 'authService', function ($scope, $modalInstance, authService) {

        $scope.newPlan = {
            Month: new Date(),
            Email: authService.authentication.userName
    };

        $scope.create = function () {
            $modalInstance.close($scope.newPlan);
        }

    }]);
}());