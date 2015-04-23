(function () {
    'use strict';

    angular.module('oMoney').factory('modalService', ['$http', '$modal', '$route', 'accountsService', 'authService', 'notificationService', 'plansService', 'categoryService', 'itemService', function ($http, $modal, $route, accountsService, authService, notificationService, plansService, categoryService, itemService) {
        var modalServiceFactory = {};

        var openAccountModal = function (account) {

            var modalInstance = $modal.open({
                templateUrl: 'app/templates/editAccountModal.html',
                controller: 'editAccountModalController',
                size: 'lg',
                resolve: {
                    account: function () {
                        return account;
                    }
                }
            });

            modalInstance.result.then(function (accountResult) {
                if (accountResult.id == undefined || accountResult.id == null) {
                    accountsService.createAccount(accountResult).then(function () {
                        $route.reload();
                    }, function (response) {
                        notificationService.exception(response.data);
                    });
                } else {
                    accountsService.updateAccount(accountResult).then(function() {
                        $route.reload();
                    }, function(response) {
                        notificationService.exception(response.data);
                    });
                }
            }, function() {
                console.log('Modal dissmissed');
            });

        }

        var deleteAccountModal = function (account) {

            var modalInstance = $modal.open({
                templateUrl: 'app/templates/deleteAccountModal.html',
                size: 'lg'
            });

            modalInstance.result.then(function() {
                accountsService.deleteAccount(account).then(function (response) {
                    $route.reload();
                }, function (response) {
                    notificationService.exception(response.data);
                });
            }, function() {
                console.log('Modal dissmissed');
            });

        }

        var openPlanModal = function() {
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/createPlanModal.html',
                controller: 'createPlanModalController'
            });

            modalInstance.result.then(function(plan) {
                plansService.createPlan(plan).then(function() {
                    $route.reload();
                }, function(response) {
                    notificationService.exception(response.data);
                });
            }, function() {
                console.log("Modal plan dissmised");
            });
        };

        var createCategoryModal = function(id) {
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/createCategoryModal.html',
                controller: 'createCategoryModalController'
            });

            modalInstance.result.then(function (category) {
                category.PlanId = id;
                categoryService.createCategory(category).then(function() {
                    $route.reload();
                }, function(response) {
                    notificationService.exception(response);
                });
            }, function() {
                console.log("Category modal dismissed.");
            });
        }

        var createItemModal = function(id) {
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/createItemModal.html',
                controller: 'createItemModalController'
            });

            modalInstance.result.then(function (item) {
                item.CategoryId = id;
                itemService.createItem(item).then(function () {
                    $route.reload();
                }, function (response) {
                    notificationService.exception(response);
                });
            }, function () {
                console.log("Item modal dismissed.");
            });
        }

        var editCategoryModal = function (category) {
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/editCategoryModal.html',
                controller: 'editCategoryModalController',
                resolve: {
                    category: function() {
                        return category;
                    }
                }
            });

            modalInstance.result.then(function (category) {
                categoryService.updateCategory(category).then(function () {
                    $route.reload();
                }, function (response) {
                    notificationService.exception(response);
                });
            }, function () {
                console.log("Edit cat modal dismissed.");
            });
        }

        var editItemModal = function (item) {
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/editItemModal.html',
                controller: 'editItemModalController',
                resolve: {
                    item: function() {
                        return item;
                    }
                }
            });

            modalInstance.result.then(function (item) {
                itemService.updateItem(item).then(function () {
                    $route.reload();
                }, function (response) {
                    notificationService.exception(response);
                });
            }, function () {
                console.log("Edit item modal dismissed.");
            });
        }

        modalServiceFactory.openAccountModal = openAccountModal;
        modalServiceFactory.deleteAccountModal = deleteAccountModal;
        modalServiceFactory.openPlanModal = openPlanModal;
        modalServiceFactory.createCategoryModal = createCategoryModal;
        modalServiceFactory.createItemModal = createItemModal;
        modalServiceFactory.editCategoryModal = editCategoryModal;
        modalServiceFactory.editItemModal = editItemModal;

        return modalServiceFactory;
    }]);
}());