﻿
var auditTrailModule = angular.module('auditTrail', ['schoolERPCommon'])
	.config(function ($routeProvider, $locationProvider) {

		$routeProvider.when(schoolERP.rootPath + 'core/audittrail', { templateUrl: schoolERP.rootPath + 'app/core/views/audittraillist.html', controller: 'AuditTrailListViewModel' });
		$routeProvider.when(schoolERP.rootPath + 'core/audittrail/audittrailedit/:auditTrailId', { templateUrl: schoolERP.rootPath + 'app/core/views/audittrailedit.html', controller: 'AuditTrailEditViewModel' });

		$routeProvider.otherwise({ redirectTo: schoolERP.rootPath + 'core/audittrail' });

		$locationProvider.html5Mode({
		  enabled: true,
		  requireBase: false
		});
	});

auditTrailModule.controller("AuditTrailViewModel", function ($scope, $window, viewModelHelper) {

	$scope.viewModelHelper = viewModelHelper;

	$scope.previous = function () {
		$window.history.back();
	}
});

auditTrailModule.controller("AuditTrailListViewModel", function ($scope,$window, $location, viewModelHelper) {

	$scope.previous = function () {
		$window.history.back();
	}

	$scope.title = 'Audit Trail';
	$scope.viewMode = 'audittraillist';
	$scope.modules = [];

	$scope.init = false; // used so view doesn't sit on "no available auditTrails" while load takes place

	$scope.loadAuditTrails = function () {
		viewModelHelper.apiGet('api/audittrail/availablemodulecategories', null,
				function (result) {
					$scope.auditTrails = result.data;
					if ($scope.init === false)
						initializeView();
					$scope.init = true;
				});
	}

	var initializeView = function(){

	setTimeout(function () {

				var responsiveHelper_datatable_tabletools = undefined;

	var breakpointDefinition = {
			tablet: 1024,
			phone: 480
		};

	/* TABLETOOLS */
		var otable = $('#auditTrailTable').DataTable({

			// Tabletools options:
			//   https://datatables.net/extensions/tabletools/button_options
			"sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'l><'col-sm-6 col-xs-6 hidden-xs'T>r>" +
					"t" +
					"<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-sm-6 col-xs-12'p>>",
			"oTableTools": {
				"aButtons": [
				"copy",
				"csv",
				"xls",
				   {
					   "sExtends": "pdf",
					   "sTitle": "All Modules",
					   "sPdfMessage": "Eglobalicthub ERP PDF Export",
					   "sPdfSize": "letter"
				   },
				   {
					   "sExtends": "print",
					   "sMessage": "Generated by Eglobalicthub <i>(press Esc to close)</i>"
				   }
				],
				"sSwfPath": "/Scripts/plugin/datatables/swf/copy_csv_xls_pdf.swf"
			},
			"autoWidth": true,
			"preDrawCallback": function () {
				// Initialize the responsive datatables helper once.
				if (!responsiveHelper_datatable_tabletools) {
					responsiveHelper_datatable_tabletools = new ResponsiveDatatablesHelper($('#auditTrailTable'), breakpointDefinition);
				}
			},
			"rowCallback": function (nRow) {
				responsiveHelper_datatable_tabletools.createExpandIcon(nRow);
			},
			"drawCallback": function (oSettings) {
				responsiveHelper_datatable_tabletools.respond();
			}
		});

		// custom toolbar
		//$("div.toolbar").html('<div class="text-right"><img src="/Content/img/logo.png" alt="SmartAdmin" style="width: 111px; margin-top: 3px; margin-right: 10px;"></div>');

		// Apply the filter
		$("#auditTrailTable thead th input[type=text]").on('keyup change', function () {

			otable
				.column($(this).parent().index() + ':visible')
				.search(this.value)
				.draw();

		});

		/* END TABLETOOLS */

			}, 50);
	}

	$scope.createAuditTrail = function(){
	 $scope.viewMode = 'auditTrailedit';
		$location.path(schoolERP.rootPath + 'core/audittrail/audittrailedit/0');
	}

	$scope.viewAuditTrail = function(auditTrailId){
	 $scope.viewMode = 'auditTrailedit';
	 $location.path(schoolERP.rootPath + 'core/audittrail/audittrailedit/' + auditTrailId);
	}

	$scope.deleteAuditTrail = function(auditTrailId){
		var deleteFlag = $window.confirm('Are you sure you want to delete this item.');

		if (deleteFlag) {
			viewModelHelper.apiPost('api/audittrail/deleteAuditTrail', auditTrailId,
		  function (result) {
			  alert('Item deleted successfully.');
			  $location.path(schoolERP.rootPath + 'core/audittrail/audittraillist');
		  },
		  function (result) {
			  alert('Fail to delete item. ' + result.data);
		  }, null);
		}
	}

	$scope.auditTrailStatus = function(state){
		if (state === true)
		return 'Active';
		return 'Not Active';
	}

	$scope.loadAuditTrails();
});