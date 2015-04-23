(function () {
    'use strict';
    angular.module('oMoney').controller('plansController', ['$scope', '$route', 'modalService', 'plansService', 'categoryService', 'itemService', 'plans', function ($scope, $route, modalService, plansService, categoryService, itemService, plans) {

        $scope.currentDate = new Date();
        $scope.currentPlan = {};
        $scope.currentIndex = 0;

        $scope.plans = plans.$values;

        $scope.plans.forEach(function (plan) {
            var date = new Date(plan.month);
            if ($scope.currentDate.getMonth() === date.getMonth()) {
                $scope.currentPlan = plan;
            }
        });
        $scope.plans.sort(function(a, b) {
            return new Date(a.month) - new Date(b.month);
        });
        $scope.currentIndex = $scope.plans.indexOf($scope.currentPlan);

        //console.log($scope.plans);
        //console.log($scope.currentIndex);
        
        $scope.createPlan = function() {
            modalService.openPlanModal();
        }

        $scope.next = function() {
            //for (var i = 0; i < $scope.plans.length; i++) {
            //    var currentDate = new Date($scope.currentPlan.month);
            //    var date = new Date($scope.plans[i].month);
            //    if ((currentDate.getMonth() + 1) === date.getMonth()) {
            //        $scope.currentPlan = $scope.plans[i];
            //        break;
            //    }
            //}
            if ($scope.plans[$scope.currentIndex + 1] != undefined) {
                $scope.currentPlan = $scope.plans[$scope.currentIndex + 1];
                $scope.currentIndex += 1;
                //console.log($scope.currentPlan);
                //console.log($scope.currentIndex);
            }
        }

        $scope.prev = function() {
            //for (var i = 0; i < $scope.plans.length; i++) {
            //    var currentDate = new Date($scope.currentPlan.month);
            //    var date = new Date($scope.plans[i].month);
            //    if ((currentDate.getMonth() - 1) === date.getMonth()) {
            //        $scope.currentPlan = $scope.plans[i];
            //        break;
            //    }
            //}
            if ($scope.plans[$scope.currentIndex - 1] != undefined) {
                $scope.currentPlan = $scope.plans[$scope.currentIndex - 1];
                $scope.currentIndex -= 1;
                //console.log($scope.currentPlan);
                //console.log($scope.currentIndex);
            }
        }

        $scope.createCategory = function() {
            modalService.createCategoryModal($scope.currentPlan.id);
        }

        $scope.createItem = function(id) {
            modalService.createItemModal(id);
        }

        $scope.deletePlan = function(plan) {
            plansService.deletePlan(plan).then(function() {
                $route.reload();
            }, function() {
                alert('DELETING PLAN WENT COMPLETELY WRONG');
            });
        }

        $scope.deleteCategory = function(category) {
            categoryService.deleteCategory(category).then(function() {
                $route.reload();
            }, function() {
                alert('DELETING CATEGORY WENT COMPLETELY WRONG');
            });
        }

        $scope.deleteItem = function(item) {
            itemService.deleteItem(item).then(function() {
                $route.reload();
            }, function() {
                alert('DELETING ITEM WEN COMPLETELY WROGN');
            });
        }

        $scope.editCategory = function(category) {
            modalService.editCategoryModal(category);
        }

        $scope.editItem = function(item) {
            modalService.editItemModal(item);
        }

    }]);
}());