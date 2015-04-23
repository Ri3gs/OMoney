(function () {
    'use strict';
    angular.module('oMoney').controller('plansController', ['$scope', 'modalService', 'plans', function ($scope, modalService, plans) {

        $scope.currentDate = new Date();
        $scope.currentPlan = {};

        $scope.plans = plans.$values;

        $scope.plans.forEach(function (plan) {
            var date = new Date(plan.month);
            if ($scope.currentDate.getMonth() === date.getMonth()) {
                $scope.currentPlan = plan;
            }
        });

        $scope.categories = plans.$values[0].categories.$values;
        console.log($scope.plans);
        console.log($scope.categories);
        
        $scope.createPlan = function() {
            modalService.openPlanModal();
        }

        $scope.next = function() {
            for (var i = 0; i < $scope.plans.length; i++) {
                var currentDate = new Date($scope.currentPlan.month);
                var date = new Date($scope.plans[i].month);
                if ((currentDate.getMonth() + 1) === date.getMonth()) {
                    $scope.currentPlan = $scope.plans[i];
                    break;
                }
            }
        }

        $scope.prev = function() {
            for (var i = 0; i < $scope.plans.length; i++) {
                var currentDate = new Date($scope.currentPlan.month);
                var date = new Date($scope.plans[i].month);
                if ((currentDate.getMonth() - 1) === date.getMonth()) {
                    $scope.currentPlan = $scope.plans[i];
                    break;
                }
            }
        }

        $scope.createCategory = function() {
            modalService.createCategoryModal($scope.currentPlan.id);
        }

        $scope.createItem = function(id) {
            modalService.createItemModal(id);
        }

    }]);
}());