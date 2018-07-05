
var profileModule = angular.module('profile', ['schoolERPCommon'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when(schoolERP.rootPath + 'core/profile', { templateUrl: schoolERP.rootPath + 'app/core/views/profile.html', controller: 'ProfileFormViewModel' });
        
        $routeProvider.otherwise({ redirectTo: schoolERP.rootPath + 'core/profile' });

		$locationProvider.html5Mode({
		  enabled: true,
		  requireBase: false
		});
    });

profileModule.controller("ProfileFormViewModel", function ($scope, $http,$window, $location, viewModelHelper) {

    viewModelHelper.modelIsValid = true;
    viewModelHelper.modelErrors = [];

    $scope.viewMode = 'profileForm'; // profileForm, success
    $scope.profile = [];
   
    $scope.init = false; // used so view doesn't sit on "no profile found" while load takes place

    $scope.loadProfile = function () {
        viewModelHelper.apiGet('api/account/getprofile', null,
                function (result) {
                    $scope.profile = result.data;
					if ($scope.init === false)
						initializeView();
                    $scope.init = true;
                });
    }

	 $scope.previous = function () {
        $window.history.back();
    }

	var initializeView = function(){

	setTimeout(function () {

            }, 50);
	}
    $scope.today = new Date();
    $scope.loadProfile();
});
