/**
 * Created by Deb on 8/20/2014.
 */
//(function () {
//    "use strict";
//    angular
//        .module("schoolERP")
//        .controller("ModuleCategoryListController",['$scope', '$http',
//                        ModuleCategoryListController]);

//    function ModuleCategoryListController($scope, $http) {
//        alert('OK');
//    }
//}());

var App = angular.module("schoolERP");
App.controller('ModuleCategoryListController', function ($scope, $http) {

    $scope.test = 'Module Category';
    $scope.moduleCategories = [];

    var initialize = function () {
        var uri = 'api/modulecategory/availablemodulecategories';
        $http.get(schoolERP.rootPath + uri, null)
               .then(function (result) {
                   $scope.moduleCategories = result.data;
               }, function (result) {
                   alert(result.data);
               });
    }
    
    initialize();
});
