(function() {
    'use strict';

    var passwordCheck = function () {
        return {
            require: 'ngModel',
            link: function (scope, elem, attrs, ctrl) {
                var firstPassword = '#' + attrs.passwordCheck;
                elem.add(firstPassword).on('keyup', function () {
                    scope.$apply(function () {
                        // console.info(elem.val() === $(firstPassword).val());
                        ctrl.$setValidity('passwordMatch', elem.val() === $(firstPassword).val());
                    });
                });
            }
        }
    };

    angular.module('oMoney').directive("passwordCheck", passwordCheck);
}());