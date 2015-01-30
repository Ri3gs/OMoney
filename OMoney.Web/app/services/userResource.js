(function () {

    angular.module("common.services")
        .factory("userResource", ["$resource", userResource]);

    function userResource($resource) {
        return $resource("http://localhost:4586/api/account/register/");
    }

}());