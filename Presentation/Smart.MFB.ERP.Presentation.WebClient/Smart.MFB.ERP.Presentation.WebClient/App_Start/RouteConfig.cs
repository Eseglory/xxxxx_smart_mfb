#region Using

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace Smart.MFB.ERP.Presentation.WebClient
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            RegisterCoreRoute(routes);
            RegisterAcademicPlanRoute(routes);
            RegisterAdmissionRoute(routes);
            RegisterEmployeeDirectoryRoute(routes);
            RegisterStudentDirectoryRoute(routes);
            RegisterTeacherDirectoryRoute(routes);
            RegisterLessonPlanRoute(routes);
            RegisterDocumentRoute(routes);
            RegisterTimeTableRoute(routes);
            //RegisterLeaveRoute(routes);
            RegisterExaminationRoute(routes);
            RegisterResultRoute(routes);
            RegisterMedicalRoute(routes);
            RegisterProjectRoute(routes);
            RegisterLibraryRoute(routes);
            RegisterFinancialRoute(routes);
            RegisterAttendanceRoute(routes);
            RegisterCommunicationRoute(routes);
            RegisterAssessmentRoute(routes);
            RegisterDisciplineRoute(routes);
            RegisterFacilityRoute(routes);
            RegisterHostelRoute(routes);

            routes.MapMvcAttributeRoutes();

            routes.MapRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "account",
                action = "login",
                id = UrlParameter.Optional
            }).RouteHandler = new DashRouteHandler();

        }

        private static void RegisterCoreRoute(RouteCollection routes)
        {
            routes.MapRoute(
              name: "allmodules",
              url: "core/module",
              defaults: new { controller = "Core", action = "Module" }).RouteHandler = new DashRouteHandler();

            routes.MapRoute(
              name: "profile",
              url: "core/profile",
              defaults: new { controller = "Core", action = "MyProfile" }).RouteHandler = new DashRouteHandler();

            routes.MapRoute(
               name: "groupRoot",
               url: "core/group/grouplist",
               defaults: new { controller = "Core", action = "Group" });

            routes.MapRoute(
                name: "group",
                url: "core/group/{*catchall}",
                defaults: new { controller = "Core", action = "Group" });

            routes.MapRoute(
               name: "roles",
               url: "core/role",
               defaults: new { controller = "Core", action = "Role" }).RouteHandler = new DashRouteHandler();

            routes.MapRoute(
              name: "menus",
              url: "core/menu",
              defaults: new { controller = "Core", action = "Menu" }).RouteHandler = new DashRouteHandler();

            routes.MapRoute(
             name: "countryRoot",
             url: "core/country/countrylist",
             defaults: new { controller = "Core", action = "Country" });

            routes.MapRoute(
                name: "country",
                url: "core/country/{*catchall}",
                defaults: new { controller = "Core", action = "Country" });

            routes.MapRoute(
             name: "languageRoot",
             url: "core/language/languagelist",
             defaults: new { controller = "Core", action = "Language" });

            routes.MapRoute(
                name: "language",
                url: "core/language/{*catchall}",
                defaults: new { controller = "Core", action = "Language" });

            routes.MapRoute(
             name: "religionRoot",
             url: "core/religion/religionlist",
             defaults: new { controller = "Core", action = "Religion" });

            routes.MapRoute(
                name: "religion",
                url: "core/religion/{*catchall}",
                defaults: new { controller = "Core", action = "Religion" });

            routes.MapRoute(
             name: "userRoot",
             url: "core/user/userlist",
             defaults: new { controller = "Core", action = "User" });

            routes.MapRoute(
                name: "user",
                url: "core/user/{*catchall}",
                defaults: new { controller = "Core", action = "User" });
        }

        private static void RegisterAcademicPlanRoute(RouteCollection routes)
        {
            //AcademicPlan
            routes.MapRoute(
             name: "academicschoolsettingRoot",
             url: "academicplan/academicschoolsetting/academicschoolsettinglist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSchoolSetting" });

            routes.MapRoute(
                name: "academicschoolsetting",
                url: "academicplan/academicschoolsetting/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSchoolSetting" });

            routes.MapRoute(
             name: "academicschoolRoot",
             url: "academicplan/academicschool/academicschoollist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSchool" });

            routes.MapRoute(
                name: "academicschool",
                url: "academicplan/academicschool/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSchool" });

            routes.MapRoute(
            name: "academicholidayRoot",
            url: "academicplan/academicholiday/academicholidaylist",
            defaults: new { controller = "AcademicPlan", action = "AcademicHoliday" });

            routes.MapRoute(
                name: "academicholiday",
                url: "academicplan/academicholiday/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicHoliday" });

            routes.MapRoute(
             name: "academiccampusRoot",
             url: "academicplan/academiccampus/academiccampuslist",
             defaults: new { controller = "AcademicPlan", action = "AcademicCampus" });

            routes.MapRoute(
                name: "academiccampus",
                url: "academicplan/academiccampus/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicCampus" });

            routes.MapRoute(
            name: "academicsessionRoot",
            url: "academicplan/academicsession/academicsessionlist",
            defaults: new { controller = "AcademicPlan", action = "AcademicSession" });

            routes.MapRoute(
                name: "academicsession",
                url: "academicplan/academicsession/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSession" });

            routes.MapRoute(
             name: "academiclevelRoot",
             url: "academicplan/academiclevel/academiclevellist",
             defaults: new { controller = "AcademicPlan", action = "AcademicLevel" });

            routes.MapRoute(
                name: "academiclevel",
                url: "academicplan/academiclevel/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicLevel" });

            routes.MapRoute(
             name: "academicclassRoot",
             url: "academicplan/academicclass/academicclasslist",
             defaults: new { controller = "AcademicPlan", action = "AcademicClass" });

            routes.MapRoute(
                name: "academicclass",
                url: "academicplan/academicclass/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClass" });

            routes.MapRoute(
            name: "academicsectionRoot",
            url: "academicplan/academicsection/academicsectionlist",
            defaults: new { controller = "AcademicPlan", action = "AcademicSection" });

            routes.MapRoute(
                name: "academicsection",
                url: "academicplan/academicsection/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSection" });

            routes.MapRoute(
           name: "academicstreamRoot",
           url: "academicplan/academicstream/academicstreamlist",
           defaults: new { controller = "AcademicPlan", action = "AcademicStream" });

            routes.MapRoute(
                name: "academicstream",
                url: "academicplan/academicstream/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicStream" });

            routes.MapRoute(
             name: "academicclasssectionmapRoot",
             url: "academicplan/academicclasssectionmap/academicclasssectionmaplist",
             defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionMap" });

            routes.MapRoute(
                name: "academicclasssectionmap",
                url: "academicplan/academicclasssectionmap/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionMap" });

            routes.MapRoute(
            name: "academicclassstreammapRoot",
            url: "academicplan/academicclassstreammap/academicclassstreammaplist",
            defaults: new { controller = "AcademicPlan", action = "AcademicClassStreamMap" });

            routes.MapRoute(
                name: "academicclassstreammap",
                url: "academicplan/academicclassstreammap/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassStreamMap" });

            routes.MapRoute(
             name: "academicstudentsectionstreammapRoot",
             url: "academicplan/academicstudentsectionstreammap/academicstudentsectionstreammaplist",
             defaults: new { controller = "AcademicPlan", action = "AcademicStudentSectionStreamMap" });

            routes.MapRoute(
                name: "academicstudentsectionstreammap",
                url: "academicplan/academicstudentsectionstreammap/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicStudentSectionStreamMap" });

            routes.MapRoute(
             name: "academicclasssectionmovementRoot",
             url: "academicplan/academicclasssectionmovement/academicclasssectionmovementlist",
             defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionMovement" });

            routes.MapRoute(
                name: "academicclasssectionmovement",
                url: "academicplan/academicclasssectionmovement/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionMovement" });

            routes.MapRoute(
             name: "academicclassroomRoot",
             url: "academicplan/academicclassroom/academicclassroomlist",
             defaults: new { controller = "AcademicPlan", action = "AcademicClassroom" });

            routes.MapRoute(
                name: "academicclassroom",
                url: "academicplan/academicclassroom/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassroom" });

            routes.MapRoute(
            name: "academicdepartmentcategoryRoot",
            url: "academicplan/academicdepartmentcategory/academicdepartmentcategoryedit",
            defaults: new { controller = "AcademicPlan", action = "AcademicDepartmentCategory" });

            routes.MapRoute(
                name: "academicdepartmentcategory",
                url: "academicplan/academicdepartmentcategory/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicDepartmentCategory" });

            routes.MapRoute(
            name: "academicdepartmentRoot",
            url: "academicplan/academicdepartmenty/academicdepartmentlist",
            defaults: new { controller = "AcademicPlan", action = "AcademicDepartment" });

            routes.MapRoute(
                name: "academicdepartment",
                url: "academicplan/academicdepartment/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicDepartment" });

            routes.MapRoute(
             name: "academicsubjecttypeRoot",
             url: "academicplan/academicsubjecttype/academicsubjecttypelist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSubjectType" });

            routes.MapRoute(
                name: "academicsubjecttype",
                url: "academicplan/academicsubjecttype/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubjectType" });

            routes.MapRoute(
             name: "academicsubjectcompulsorytypeRoot",
             url: "academicplan/academicsubjectcompulsorytype/academicsubjectcompulsorytypelist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSubjectCompulsoryType" });

            routes.MapRoute(
                name: "academicsubjectcompulsorytype",
                url: "academicplan/academicsubjectcompulsorytype/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubjectCompulsoryType" });


            routes.MapRoute(
             name: "academicsubjectassessmentweightRoot",
             url: "academicplan/academicsubjectassessmentweight/academicsubjectassessmentweightlist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSubjectAssessmentWeight" });

            routes.MapRoute(
                name: "academicsubjectassessmentweight",
                url: "academicplan/academicsubjectassessmentweight/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubjectAssessmentWeight" });

            routes.MapRoute(
             name: "academicsubjectgroupRoot",
             url: "academicplan/academicsubjectgroup/academicsubjectgrouplist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSubjectGroup" });

            routes.MapRoute(
                name: "academicsubjectgroup",
                url: "academicplan/academicsubjectgroup/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubjectGroup" });

            routes.MapRoute(
             name: "academicsubjectRoot",
             url: "academicplan/academicsubject/academicsubjectlist",
             defaults: new { controller = "AcademicPlan", action = "AcademicSubject" });

            routes.MapRoute(
                name: "academicsubject",
                url: "academicplan/academicsubject/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubject" });

            routes.MapRoute(
            name: "academicclassroomassignmentRoot",
            url: "academicplan/academicclassroomassignment/academicclassroomassignmentlist",
            defaults: new { controller = "AcademicPlan", action = "AcademicClassroomAssignment" });

            routes.MapRoute(
                name: "academicclassroomassignment",
                url: "academicplan/academicclassroomassignment/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassroomAssignment" });

            routes.MapRoute(
         name: "academicsubjectlevelRoot",
         url: "academicplan/academicsubjectlevelp/academicsubjectlevellist",
         defaults: new { controller = "AcademicPlan", action = "AcademicSubjectLevel" });

            routes.MapRoute(
                name: "academicsubjectlevel",
                url: "academicplan/academicsubjectlevel/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicSubjectLevel" });

            routes.MapRoute(
           name: "academicclasssectionsubjectgroupRoot",
           url: "academicplan/academicclasssectionsubjectgroup/academicclasssectionsubjectgrouplist",
           defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionSubjectGroup" });

            routes.MapRoute(
                name: "academicclasssectionsubjectgroup",
                url: "academicplan/academicclasssectionsubjectgroup/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionSubjectGroup" });

            routes.MapRoute(
           name: "academicclassstreamsubjectgroupRoot",
           url: "academicplan/academicclassstreamsubjectgroup/academicclassstreamsubjectgrouplist",
           defaults: new { controller = "AcademicPlan", action = "AcademicClassStreamSubjectGroup" });

            routes.MapRoute(
                name: "academicclassstreamsubjectgroup",
                url: "academicplan/academicclassstreamsubjectgroup/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassStreamSubjectGroup" });

            routes.MapRoute(
       name: "academicclasssectionstreamsubjectconfigurationRoot",
       url: "academicplan/academicclasssectionstreamsubjectconfiguration/academicclasssectionstreamsubjectconfigurationlist",
       defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionStreamSubjectConfiguration" });

            routes.MapRoute(
                name: "academicclasssectionstreamsubjectconfiguration",
                url: "academicplan/academicclasssectionstreamsubjectconfiguration/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionStreamSubjectConfiguration" });

            routes.MapRoute(
        name: "academicclasssectionstreamsubjectRoot",
        url: "academicplan/academicclasssectionstreamsubject/academicclasssectionstreamsubjectlist",
        defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionStreamSubject" });

            routes.MapRoute(
                name: "academicclasssectionstreamsubject",
                url: "academicplan/academicclasssectionstreamsubject/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicClassSectionStreamSubject" });

            routes.MapRoute(
        name: "academicconfigurationRoot",
        url: "academicplan/academicconfiguration/academicconfigurationlist",
        defaults: new { controller = "AcademicPlan", action = "AcademicConfiguration" });

            routes.MapRoute(
                name: "academicconfiguration",
                url: "academicplan/academicconfiguration/{*catchall}",
                defaults: new { controller = "AcademicPlan", action = "AcademicConfiguration" });
        }

        private static void RegisterAdmissionRoute(RouteCollection routes)
        {

            routes.MapRoute(
             name: "admissionphaseRoot",
             url: "admission/admissionphase/admissionphaselist",
             defaults: new { controller = "Admission", action = "AdmissionPhase" });

            routes.MapRoute(
                name: "admissionphase",
                url: "admission/admissionphase/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionPhase" });

            routes.MapRoute(
            name: "admissiongroupRoot",
            url: "admission/admissiongroup/admissiongrouplist",
            defaults: new { controller = "Admission", action = "AdmissionGroup" });

            routes.MapRoute(
                name: "admissiongroup",
                url: "admission/admissiongroup/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionGroup" });

            routes.MapRoute(
            name: "admissionstreamdurationRoot",
            url: "admission/admissionstreamduration/admissionstreamdurationlist",
            defaults: new { controller = "Admission", action = "AdmissionStreamDuration" });

            routes.MapRoute(
                name: "admissionstreamduration",
                url: "admission/admissionstreamduration/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionStreamDuration" });

            routes.MapRoute(
            name: "admissiontypeRoot",
            url: "admission/admissiontype/admissiontypelist",
            defaults: new { controller = "Admission", action = "AdmissionType" });

            routes.MapRoute(
                name: "admissiontype",
                url: "admission/admissiontype/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionType" });

            routes.MapRoute(
            name: "admissiontypeclassRoot",
            url: "admission/admissiontypeclass/admissiontypeclasslist",
            defaults: new { controller = "Admission", action = "AdmissionTypeClass" });

            routes.MapRoute(
                name: "admissiontypeclass",
                url: "admission/admissiontypeclass/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionTypeClass" });

            routes.MapRoute(
           name: "admissionawardRoot",
           url: "admission/admissionaward/admissionawardlist",
           defaults: new { controller = "Admission", action = "AdmissionAward" });

            routes.MapRoute(
                name: "admissionaward",
                url: "admission/admissionaward/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionAward" });

            routes.MapRoute(
          name: "admissionstreamawardRoot",
          url: "admission/admissionstreamaward/admissionstreamawardlist",
          defaults: new { controller = "Admission", action = "AdmissionStreamAward" });

            routes.MapRoute(
                name: "admissionstreamaward",
                url: "admission/admissionstreamaward/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionStreamAward" });

            routes.MapRoute(
          name: "admissionstageRoot",
          url: "admission/admissionstage/admissionstagelist",
          defaults: new { controller = "Admission", action = "AdmissionStage" });

            routes.MapRoute(
                name: "admissionstage",
                url: "admission/admissionstage/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionStage" });

            routes.MapRoute(
         name: "admissionformRoot",
         url: "admission/admissionform/admissionformlist",
         defaults: new { controller = "Admission", action = "AdmissionForm" });

            routes.MapRoute(
                name: "admissionform",
                url: "admission/admissionform/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionForm" });

            routes.MapRoute(
         name: "admissiongradeRoot",
         url: "admission/admissiongrade/admissiongradelist",
         defaults: new { controller = "Admission", action = "AdmissionGrade" });

            routes.MapRoute(
                name: "admissiongrade",
                url: "admission/admissiongrade/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionGrade" });

            routes.MapRoute(
         name: "admissionqualificationconfigurationRoot",
         url: "admission/admissionqualificationconfiguration/admissionqualificationconfigurationlist",
         defaults: new { controller = "Admission", action = "AdmissionQualificationConfiguration" });

            routes.MapRoute(
                name: "admissionqualificationconfiguration",
                url: "admission/admissionqualificationconfiguration/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionQualificationConfiguration" });

            routes.MapRoute(
           name: "admissionqualificationparameterequivalentRoot",
           url: "admission/admissionqualificationparameterequivalent/admissionqualificationparameterequivalentlist",
           defaults: new { controller = "Admission", action = "AdmissionQualificationParameterEquivalent" });

            routes.MapRoute(
                name: "admissionqualificationparameterequivalent",
                url: "admission/admissionqualificationparameterequivalent/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionQualificationParameterEquivalent" });

            routes.MapRoute(
         name: "admissionqualificationsubjectconfigurationRoot",
         url: "admission/admissionqualificationsubjectconfiguration/admissionqualificationsubjectconfigurationlist",
         defaults: new { controller = "Admission", action = "AdmissionQualificationSubjectConfiguration" });

            routes.MapRoute(
                name: "admissionqualificationsubjectconfiguration",
                url: "admission/admissionqualificationsubjectconfiguration/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionQualificationSubjectConfiguration" });

            routes.MapRoute(
      name: "admissionaccountRoot",
      url: "admission/admissionaccount/admissionaccountlist",
      defaults: new { controller = "Admission", action = "AdmissionAccount" });

            routes.MapRoute(
                name: "admissionaccount",
                url: "admission/admissionaccount/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionAccount" });

            routes.MapRoute(
             name: "admissionaccountstageRoot",
             url: "admission/admissionaccountstage/admissionaccountstagelist",
             defaults: new { controller = "Admission", action = "AdmissionAccountStage" });

            routes.MapRoute(
                name: "admissionaccountstage",
                url: "admission/admissionaccountstage/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionAccountStage" });

            routes.MapRoute(
             name: "admissionaccountdetailRoot",
             url: "admission/admissionaccountdetail/admissionaccountdetaillist",
             defaults: new { controller = "Admission", action = "AdmissionAccountDetail" });

            routes.MapRoute(
                name: "admissionaccountdetail",
                url: "admission/admissionaccountdetail/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionAccountDetail" });

            routes.MapRoute(
             name: "admissionaccountqualificationRoot",
             url: "admission/admissionaccountqualification/admissionaccountqualificationlist",
             defaults: new { controller = "Admission", action = "AdmissionAccountQualification" });

            routes.MapRoute(
                name: "admissionaccountqualification",
                url: "admission/admissionaccountqualification/{*catchall}",
                defaults: new { controller = "Admission", action = "AdmissionAccountQualification" });

            routes.MapRoute(
           name: "programmandatorysubjectRoot",
           url: "admission/programmandatorysubject/programmandatorysubjectlist",
           defaults: new { controller = "Admission", action = "programMandatorySubject" });

            routes.MapRoute(
                name: "programmandatorysubject",
                url: "admission/programmandatorysubject/{*catchall}",
                defaults: new { controller = "Admission", action = "programMandatorySubject" });

            routes.MapRoute(
           name: "applicantcertificationdetailRoot",
           url: "admission/applicantcertificationdetail/applicantcertificationdetaillist",
           defaults: new { controller = "Admission", action = "ApplicantCertificationDetail" });

            routes.MapRoute(
                name: "applicantcertificationdetail",
                url: "admission/applicantcertificationdetail/{*catchall}",
                defaults: new { controller = "Admission", action = "ApplicantCertificationDetail" });
        }

        private static void RegisterEmployeeDirectoryRoute(RouteCollection routes)
        {

            routes.MapRoute(
             name: "employeetypeRoot",
             url: "employeedirectory/employeetype/employeetypelist",
             defaults: new { controller = "EmployeeDirectory", action = "EmployeeType" });

            routes.MapRoute(
                name: "employeetype",
                url: "employeedirectory/employeetype/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "EmployeeType" });

            routes.MapRoute(
             name: "employeedesignationRoot",
             url: "employeedirectory/employeedesignation/employeedesignationlist",
             defaults: new { controller = "EmployeeDirectory", action = "EmployeeDesignation" });

            routes.MapRoute(
                name: "employeedesignation",
                url: "employeedirectory/employeedesignation/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "EmployeeDesignation" });

            routes.MapRoute(
             name: "departmentRoot",
             url: "employeedirectory/department/departmentlist",
             defaults: new { controller = "EmployeeDirectory", action = "Department" });

            routes.MapRoute(
                name: "department",
                url: "employeedirectory/department/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "Department" });
            

            routes.MapRoute(
            name: "advisorappointmentRoot",
            url: "employeedirectory/advisorappointment/advisorappointmentlist",
            defaults: new { controller = "EmployeeDirectory", action = "AdvisorAppointment" });

            routes.MapRoute(
                name: "advisorappointment",
                url: "employeedirectory/advisorappointment/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "AdvisorAppointment" });


            routes.MapRoute(
            name: "advisorRoot",
            url: "employeedirectory/advisor/advisorlist",
            defaults: new { controller = "EmployeeDirectory", action = "Advisor" });

            routes.MapRoute(
                name: "advisor",
                url: "employeedirectory/advisor/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "Advisor" });


            routes.MapRoute(
             name: "staffRoot",
             url: "employeedirectory/staff/stafflist",
             defaults: new { controller = "EmployeeDirectory", action = "Employee" });

            routes.MapRoute(
                name: "staff",
                url: "employeedirectory/staff/{*catchall}",
                defaults: new { controller = "EmployeeDirectory", action = "Employee" });

        }

        private static void RegisterTeacherDirectoryRoute(RouteCollection routes)
        {
            //TeacherDirectory
            routes.MapRoute(
             name: "teacherlevelRoot",
             url: "teacherdirectory/teacherlevel/teacherlevellist",
             defaults: new { controller = "TeacherDirectory", action = "TeacherLevel" });

            routes.MapRoute(
                name: "teacherlevel",
                url: "teacherdirectory/teacherlevel/{*catchall}",
                defaults: new { controller = "TeacherDirectory", action = "TeacherLevel" });

            routes.MapRoute(
             name: "teacherclassRoot",
             url: "teacherdirectory/teacherclass/teacherclasslist",
             defaults: new { controller = "TeacherDirectory", action = "TeacherClass" });

            routes.MapRoute(
                name: "teacherclass",
                url: "teacherdirectory/teacherclass/{*catchall}",
                defaults: new { controller = "TeacherDirectory", action = "TeacherClass" });

            routes.MapRoute(
             name: "classsupervisorRoot",
             url: "teacherdirectory/classsupervisor/classsupervisorlist",
             defaults: new { controller = "TeacherDirectory", action = "ClassSupervisor" });

            routes.MapRoute(
                name: "classsupervisor",
                url: "teacherdirectory/classsupervisor/{*catchall}",
                defaults: new { controller = "TeacherDirectory", action = "ClassSupervisor" });

            routes.MapRoute(
             name: "subjectteacherRoot",
             url: "teacherdirectory/subjectteacher/subjectteacherlist",
             defaults: new { controller = "TeacherDirectory", action = "SubjectTeacher" });

            routes.MapRoute(
                name: "subjectteacher",
                url: "teacherdirectory/subjectteacher/{*catchall}",
                defaults: new { controller = "TeacherDirectory", action = "SubjectTeacher" });

            routes.MapRoute(
            name: "classsubjectteacherRoot",
            url: "teacherdirectory/classsubjectteacher/classsubjectteacherlist",
            defaults: new { controller = "TeacherDirectory", action = "ClassSubjectTeacher" });

            routes.MapRoute(
                name: "classsubjectteacher",
                url: "teacherdirectory/classsubjectteacher/{*catchall}",
                defaults: new { controller = "TeacherDirectory", action = "ClassSubjectTeacher" });
        }
        private static void RegisterStudentDirectoryRoute(RouteCollection routes)
        {
            //StudentDirectory
            routes.MapRoute(
             name: "studentRoot",
             url: "studentdirectory/student/studentlist",
             defaults: new { controller = "StudentDirectory", action = "Student" });

            routes.MapRoute(
                name: "student",
                url: "studentdirectory/student/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "Student" });

            //Advisor Conversiation
            


            routes.MapRoute(
             name: "studentadvisorcaseRoot",
             url: "studentdirectory/studentadvisorcase/studentadvisorcaselist",
             defaults: new { controller = "StudentDirectory", action = "StudentAdvisorCase" });

            routes.MapRoute(
                name: "studentadvisorcase",
                url: "studentdirectory/studentadvisorcase/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "StudentAdvisorCase" });


            routes.MapRoute(
             name: "studentadvisorconversiationRoot",
             url: "studentdirectory/studentadvisorconversiation/studentadvisorconversiationlist",
             defaults: new { controller = "StudentDirectory", action = "StudentAdvisorConversiation" });

            routes.MapRoute(
                name: "studentadvisorconversiation",
                url: "studentdirectory/studentadvisorconversiation/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "StudentAdvisorConversiation" });

            routes.MapRoute(
         name: "issuelistRoot",
         url: "studentdirectory/issuelist/issuelistlist",
         defaults: new { controller = "StudentDirectory", action = "IssueList" });

            routes.MapRoute(
                name: "issuelist",
                url: "studentdirectory/issuelist/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "IssueList" });

            routes.MapRoute(
      name: "matricprefixRoot",
      url: "studentdirectory/matricprefix/matricprefixlist",
      defaults: new { controller = "StudentDirectory", action = "MatricPrefix" });

            routes.MapRoute(
                name: "matricprefix",
                url: "studentdirectory/matricprefix/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "MatricPrefix" });


            routes.MapRoute(
             name: "studentsessionRoot",
             url: "studentdirectory/studentsession/studentsessionlist",
             defaults: new { controller = "StudentDirectory", action = "StudentSession" });

            routes.MapRoute(
                name: "studentsession",
                url: "studentdirectory/studentsession/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "StudentSession" });

            routes.MapRoute(
          name: "studentsubjectRoot",
          url: "studentdirectory/studentsubject/studentsubjectlist",
          defaults: new { controller = "StudentDirectory", action = "StudentSubject" });

            routes.MapRoute(
                name: "studentsubject",
                url: "studentdirectory/studentsubject/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "StudentSubject" });

            routes.MapRoute(
          name: "studentaccountdetailRoot",
          url: "studentdirectory/studentaccountdetail/studentaccountdetaillist",
          defaults: new { controller = "StudentDirectory", action = "StudentAccountDetail" });

            routes.MapRoute(
                name: "studentaccountdetail",
                url: "studentdirectory/studentaccountdetail/{*catchall}",
                defaults: new { controller = "StudentDirectory", action = "StudentAccountDetail" });
        }

        private static void RegisterDocumentRoute (RouteCollection routes)
        {
            //DocumentManagement
            routes.MapRoute(
             name: "documentcontainerRoot",
             url: "document/documentcontainer/documentcontainerlist",
             defaults: new { controller = "Document", action = "DocumentContainer" });

            routes.MapRoute(
                name: "documentcontainer",
                url: "document/documentcontainer/{*catchall}",
                defaults: new { controller = "Document", action = "DocumentContainer" });

            routes.MapRoute(
             name: "documentcategoryRoot",
             url: "document/documentcategory/documentcategorylist",
             defaults: new { controller = "Document", action = "DocumentCategory" });

            routes.MapRoute(
                name: "documentcategory",
                url: "document/documentcategory/{*catchall}",
                defaults: new { controller = "Document", action = "DocumentCategory" });


            routes.MapRoute(
            name: "documenttypeRoot",
            url: "document/documenttype/documenttypelist",
            defaults: new { controller = "Document", action = "DocumentType" });

            routes.MapRoute(
                name: "documenttype",
                url: "document/documenttype/{*catchall}",
                defaults: new { controller = "Document", action = "DocumentType" });

            routes.MapRoute(
          name: "documentRoot",
          url: "document/document/documentlist",
          defaults: new { controller = "Document", action = "Document" });

            routes.MapRoute(
                name: "document",
                url: "document/document/{*catchall}",
                defaults: new { controller = "Document", action = "Document" });
        }

        private static void RegisterAttendanceRoute(RouteCollection routes)
        {
            //Attendance

            routes.MapRoute(
                name: "attendancecodegenerator",
                url: "attendance/attendancecodegenerator/{*catchall}",
                defaults: new { controller = "Attendance", action = "AttendanceCodeGenerator" });


            routes.MapRoute(
           name: "attendanceabsentRoot",
           url: "attendance/attendanceabsent/attendanceabsentlist",
           defaults: new { controller = "Attendance", action = "AttendanceAbsent" });

            routes.MapRoute(
                name: "attendanceabsent",
                url: "attendance/attendanceabsent/{*catchall}",
                defaults: new { controller = "Attendance", action = "AttendanceAbsent" });


            routes.MapRoute(
             name: "attendanceentryRoot",
             url: "attendance/attendanceentry/attendanceentrylist",
             defaults: new { controller = "Attendance", action = "AttendanceEntry" });

            routes.MapRoute(
                name: "attendanceentry",
                url: "attendance/attendanceentry/{*catchall}",
                defaults: new { controller = "Attendance", action = "AttendanceEntry" });

            routes.MapRoute(
             name: "attendancehistoryRoot",
             url: "attendance/attendancehistory/attendancehistorylist",
             defaults: new { controller = "Attendance", action = "AttendanceHistory" });

            routes.MapRoute(
                name: "attendancehistory",
                url: "attendance/attendancehistory/{*catchall}",
                defaults: new { controller = "Attendance", action = "AttendanceHistory" });
        }

        private static void RegisterLessonPlanRoute(RouteCollection routes)
        {
            //LessonPlan

            routes.MapRoute(
             name: "lessonplantypeRoot",
             url: "employeedirectory/lessonplantype/lessonplantypelist",
             defaults: new { controller = "LessonPlan", action = "lessonPlanType" });

            routes.MapRoute(
                name: "lessonplantype",
                url: "lessonplan/lessonplantype/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "lessonPlanType" });

            routes.MapRoute(
             name: "teachingmethodologyRoot",
             url: "lessonplan/teachingmethodology/teachingmethodologylist",
             defaults: new { controller = "LessonPlan", action = "TeachingMethodology" });

            routes.MapRoute(
                name: "teachingmethodology",
                url: "lessonplan/teachingmethodology/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "TeachingMethodology" });

            routes.MapRoute(
             name: "subjecttopicRoot",
             url: "lessonplan/subjecttopic/subjecttopiclist",
             defaults: new { controller = "LessonPlan", action = "SubjectTopic" });

            routes.MapRoute(
                name: "subjecttopic",
                url: "lessonplan/subjecttopic/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "SubjectTopic" });

            routes.MapRoute(
          name: "subjectsubtopicRoot",
          url: "lessonplan/subjectsubtopic/subjectsubtopiclist",
          defaults: new { controller = "LessonPlan", action = "SubjectSubTopic" });

            routes.MapRoute(
                name: "subjectsubtopic",
                url: "lessonplan/subjectsubtopic/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "SubjectSubTopic" });

            routes.MapRoute(
          name: "lessonplanrelectioncategoryRoot",
          url: "lessonplan/lessonplanrelectioncategory/lessonplanrelectioncategorylist",
          defaults: new { controller = "LessonPlan", action = "LessonPlanRelectionCategory" });

            routes.MapRoute(
                name: "lessonplanrelectioncategory",
                url: "lessonplan/lessonplanrelectioncategory/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "LessonPlanRelectionCategory" });

            routes.MapRoute(
          name: "learningtypeRoot",
          url: "lessonplan/learningtype/learningtypelist",
          defaults: new { controller = "LessonPlan", action = "LearningType" });

            routes.MapRoute(
                name: "learningtype",
                url: "lessonplan/learningtype/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "LearningType" });

            routes.MapRoute(
          name: "curriculumRoot",
          url: "lessonplan/curriculum/curriculumlist",
          defaults: new { controller = "LessonPlan", action = "Curriculum" });

            routes.MapRoute(
                name: "curriculum",
                url: "lessonplan/curriculum/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "Curriculum" });

            routes.MapRoute(
          name: "unitplanRoot",
          url: "lessonplan/unitplan/unitplanlist",
          defaults: new { controller = "LessonPlan", action = "UnitPlan" });

            routes.MapRoute(
                name: "unitplan",
                url: "lessonplan/unitplan/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "UnitPlan" });

            routes.MapRoute(
          name: "unitplantargetRoot",
          url: "lessonplan/unitplantarget/unitplantargetlist",
          defaults: new { controller = "LessonPlan", action = "UnitPlanTarget" });

            routes.MapRoute(
                name: "unitplantarget",
                url: "lessonplan/unitplantarget/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "UnitPlanTarget" });

            routes.MapRoute(
          name: "lessonplanregistryRoot",
          url: "lessonplan/lessonplanregistry/lessonplanregistrylist",
          defaults: new { controller = "LessonPlan", action = "LessonPlanRegistry" });

            routes.MapRoute(
                name: "lessonplanregistry",
                url: "lessonplan/lessonplanregistry/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "LessonPlanRegistry" });

            routes.MapRoute(
          name: "lessonreflectionRoot",
          url: "lessonplan/lessonreflection/lessonreflectionlist",
          defaults: new { controller = "LessonPlan", action = "LessonReflection" });

            routes.MapRoute(
                name: "lessonreflection",
                url: "lessonplan/lessonreflection/{*catchall}",
                defaults: new { controller = "LessonPlan", action = "LessonReflection" });
        }

        private static void RegisterTimeTableRoute(RouteCollection routes)
        {
            //TimeTable

            routes.MapRoute(
             name: "publishtimetableRoot",
             url: "timetable/publishtimetable/publishtimetablelist",
             defaults: new { controller = "TimeTable", action = "publishTimeTable" });

            routes.MapRoute(
                name: "publishtimetable",
                url: "timetable/publishtimetable/{*catchall}",
                defaults: new { controller = "TimeTable", action = "publishTimeTable" });

            routes.MapRoute(
            name: "programtimetableRoot",
            url: "timetable/programtimetable/programtimetablelist",
            defaults: new { controller = "TimeTable", action = "programtimetable" });

            routes.MapRoute(
                name: "programtimetable",
                url: "timetable/programtimetable/{*catchall}",
                defaults: new { controller = "TimeTable", action = "programtimetable" });

            routes.MapRoute(
            name: "simulationRoot",
            url: "timetable/simulation/simulationlist",
            defaults: new { controller = "TimeTable", action = "simulation" });

            routes.MapRoute(
                name: "simulation",
                url: "timetable/simulation/{*catchall}",
                defaults: new { controller = "TimeTable", action = "simulation" });
        }

        //private static void RegisterLeaveRoute(RouteCollection routes)
        //{

        //    routes.MapRoute(
        //     name: "leavetypeRoot",
        //     url: "leave/leavetype/leavetypelist",
        //     defaults: new { controller = "Leave", action = "leaveType" });

        //    routes.MapRoute(
        //        name: "leavetype",
        //        url: "leave/leavetype/{*catchall}",
        //        defaults: new { controller = "Leave", action = "leaveType" });

        //    routes.MapRoute(
        //     name: "leaveallocationRoot",
        //     url: "leave/leaveallocation/leaveallocationlist",
        //     defaults: new { controller = "Leave", action = "leaveAllocation" });

        //    routes.MapRoute(
        //        name: "leaveallocation",
        //        url: "leave/leaveallocation/{*catchall}",
        //        defaults: new { controller = "Leave", action = "leaveAllocation" });

        //    routes.MapRoute(
        //     name: "leaveapprovalRoot",
        //     url: "leave/leaveapproval/leaveapprovallist",
        //     defaults: new { controller = "Leave", action = "leaveApproval" });

        //    routes.MapRoute(
        //        name: "leaveapproval",
        //        url: "leave/leaveapproval/{*catchall}",
        //        defaults: new { controller = "Leave", action = "leaveApproval" });

        //    routes.MapRoute(
        //     name: "leaverequestRoot",
        //     url: "leave/leaverequest/leaverequestlist",
        //     defaults: new { controller = "Leave", action = "leaveRequest" });

        //    routes.MapRoute(
        //        name: "leaverequest",
        //        url: "leave/leaverequest/{*catchall}",
        //        defaults: new { controller = "Leave", action = "leaveRequest" });

        //    //routes.MapRoute(
        //    // name: "leavestatusRoot",
        //    // url: "leave/leavestatus/leavestatuslist",
        //    // defaults: new { controller = "Leave", action = "leaveStatus" });

        //    //routes.MapRoute(
        //    //    name: "leavestatus",
        //    //    url: "leave/leavestatus/{*catchall}",
        //    //    defaults: new { controller = "Leave", action = "leaveStatus" });

        //}

        private static void RegisterExaminationRoute(RouteCollection routes)
        {

            routes.MapRoute(
             name: "examplanRoot",
             url: "examination/examplan/examplanlist",
             defaults: new { controller = "Examination", action = "examPlan" });

            routes.MapRoute(
                name: "examplan",
                url: "examination/examplan/{*catchall}",
                defaults: new { controller = "Examination", action = "examPlan" });

            routes.MapRoute(
             name: "examplancategoryRoot",
             url: "examination/examplancategory/examplancategorylist",
             defaults: new { controller = "Examination", action = "examPlanCategory" });

            routes.MapRoute(
                name: "examplancategory",
                url: "examination/examplancategory/{*catchall}",
                defaults: new { controller = "Examination", action = "examPlanCategory" });

            routes.MapRoute(
             name: "examplancategorymapRoot",
             url: "examination/examplancategorymap/examplancategorymaplist",
             defaults: new { controller = "Examination", action = "examPlanCategoryMap" });

            routes.MapRoute(
                name: "examplancategorymap",
                url: "examination/examplancategorymap/{*catchall}",
                defaults: new { controller = "Examination", action = "examPlanCategoryMap" });

            routes.MapRoute(
             name: "examexaminerRoot",
             url: "examination/examexaminer/examexaminerlist",
             defaults: new { controller = "Examination", action = "examExaminer" });

            routes.MapRoute(
                name: "examexaminer",
                url: "examination/examexaminer/{*catchall}",
                defaults: new { controller = "Examination", action = "examExaminer" });

            routes.MapRoute(
             name: "examsubjectmapRoot",
             url: "examination/examsubjectmap/examsubjectmaplist",
             defaults: new { controller = "Examination", action = "examSubjectMap" });

            routes.MapRoute(
                name: "examsubjectmap",
                url: "examination/examsubjectmap/{*catchall}",
                defaults: new { controller = "Examination", action = "examSubjectMap" });

            routes.MapRoute(
             name: "examstudentregistrationRoot",
             url: "examination/examstudentregistration/examstudentregistrationlist",
             defaults: new { controller = "Examination", action = "examStudentRegistration" });

            routes.MapRoute(
                name: "examstudentregistration",
                url: "examination/examstudentregistration/{*catchall}",
                defaults: new { controller = "Examination", action = "examStudentRegistration" });

            routes.MapRoute(
             name: "examstudentsubjectregistrationRoot",
             url: "examination/examstudentsubjectregistration/examstudentsubjectregistrationlist",
             defaults: new { controller = "Examination", action = "examStudentSubjectRegistration" });

            routes.MapRoute(
                name: "examstudentsubjectregistration",
                url: "examination/examstudentsubjectregistration/{*catchall}",
                defaults: new { controller = "Examination", action = "examStudentSubjectRegistration" });

            routes.MapRoute(
             name: "examsupervisorRoot",
             url: "examination/examsupervisor/examsupervisorlist",
             defaults: new { controller = "Examination", action = "examSupervisor" });

            routes.MapRoute(
                name: "examsupervisor",
                url: "examination/examsupervisor/{*catchall}",
                defaults: new { controller = "Examination", action = "examSupervisor" });

            routes.MapRoute(
             name: "examclassroomRoot",
             url: "examination/examclassroom/examclassroomlist",
             defaults: new { controller = "Examination", action = "examClassRoom" });

            routes.MapRoute(
                name: "examclassroom",
                url: "examination/examclassroom/{*catchall}",
                defaults: new { controller = "Examination", action = "examClassRoom" });

            routes.MapRoute(
                 name: "examsubjectclassroommapRoot",
                 url: "examination/examsubjectclassroommap/examsubjectclassroommaplist",
                 defaults: new { controller = "Examination", action = "examSubjectClassRoomMap" });

            routes.MapRoute(
                name: "examsubjectclassroommap",
                url: "examination/examsubjectclassroommap/{*catchall}",
                defaults: new { controller = "Examination", action = "examSubjectClassRoomMap" });

            routes.MapRoute(
                 name: "examsupervisorclassroomRoot",
                 url: "examination/examsupervisorclassroom/examsupervisorclassroomlist",
                 defaults: new { controller = "Examination", action = "examSupervisorClassRoom" });

            routes.MapRoute(
                name: "examsupervisorclassroom",
                url: "examination/examsupervisorclassroom/{*catchall}",
                defaults: new { controller = "Examination", action = "examSupervisorClassRoom" });

            routes.MapRoute(
                 name: "examstudentclassroomRoot",
                 url: "examination/examstudentclassroom/examstudentclassroomlist",
                 defaults: new { controller = "Examination", action = "examStudentClassRoom" });

            routes.MapRoute(
                name: "examstudentclassroom",
                url: "examination/examstudentclassroom/{*catchall}",
                defaults: new { controller = "Examination", action = "examStudentClassRoom" });

            routes.MapRoute(
             name: "examstudentscoreRoot",
             url: "examination/examstudentscore/examstudentscorelist",
             defaults: new { controller = "Examination", action = "examStudentScore" });

            routes.MapRoute(
                name: "examstudentscore",
                url: "examination/examstudentscore/{*catchall}",
                defaults: new { controller = "Examination", action = "examStudentScore" });
        }

        private static void RegisterResultRoute(RouteCollection routes)
        {


            routes.MapRoute(
             name: "gradesetupRoot",
             url: "result/gradesetup/resultreportlist",
             defaults: new { controller = "Result", action = "gradeSetup" });

            routes.MapRoute(
                name: "gradesetup",
                url: "result/gradesetup/{*catchall}",
                defaults: new { controller = "Result", action = "gradeSetup" });


            routes.MapRoute(
             name: "gradecomputationprocedureRoot",
             url: "result/gradecomputationprocedure/gradecomputationprocesslist",
             defaults: new { controller = "Result", action = "gradeComputationProcedure" });

            routes.MapRoute(
                name: "gradecomputationprocedure",
                url: "result/gradecomputationprocedure/{*catchall}",
                defaults: new { controller = "Result", action = "gradeComputationProcedure" });

            routes.MapRoute(
             name: "resultconfigurationRoot",
             url: "result/resultconfiguration/resultconfigurationlist",
             defaults: new { controller = "Result", action = "resultConfiguration" });

            routes.MapRoute(
                name: "resultconfiguration",
                url: "result/resultconfiguration/{*catchall}",
                defaults: new { controller = "Result", action = "resultConfiguration" });

            routes.MapRoute(
             name: "studentscoreRoot",
             url: "result/studentscore/studentscorelist",
             defaults: new { controller = "Result", action = "studentScore" });

            routes.MapRoute(
                name: "studentscore",
                url: "result/studentscore/{*catchall}",
                defaults: new { controller = "Result", action = "studentScore" });

            routes.MapRoute(
             name: "gradecomputationprocessRoot",
             url: "result/gradecomputationprocess/gradecomputationprocesslist",
             defaults: new { controller = "Result", action = "gradeComputationProcess" });

            routes.MapRoute(
                name: "gradecomputationprocess",
                url: "result/gradecomputationprocess/{*catchall}",
                defaults: new { controller = "Result", action = "gradeComputationProcess" });

            routes.MapRoute(
             name: "gradecomputationprocessuserRoot",
             url: "result/gradecomputationprocessuser/gradecomputationprocessuserlist",
             defaults: new { controller = "Result", action = "gradeComputationProcessUser" });

            routes.MapRoute(
                name: "gradecomputationprocessuser",
                url: "result/gradecomputationprocessuser/{*catchall}",
                defaults: new { controller = "Result", action = "gradeComputationProcessUser" });

            routes.MapRoute(
             name: "studentfinalscoreRoot",
             url: "result/studentfinalscore/studentfinalscorelist",
             defaults: new { controller = "Result", action = "studentFinalScore" });

            routes.MapRoute(
                name: "studentfinalscore",
                url: "result/studentfinalscore/{*catchall}",
                defaults: new { controller = "Result", action = "studentFinalScore" });

            routes.MapRoute(
             name: "studentgpRoot",
             url: "result/studentgp/studentgplist",
             defaults: new { controller = "Result", action = "studentGP" });

            routes.MapRoute(
                name: "studentgp",
                url: "result/studentgp/{*catchall}",
                defaults: new { controller = "Result", action = "studentGP" });

            routes.MapRoute(
             name: "resultreportRoot",
             url: "result/resultreport/resultreportlist",
             defaults: new { controller = "Result", action = "resultReport" });

            routes.MapRoute(
                name: "resultreport",
                url: "result/resultreport/{*catchall}",
                defaults: new { controller = "Result", action = "resultReport" });

        }

        private static void RegisterLibraryRoute(RouteCollection routes)
        {
            //Attendance
            routes.MapRoute(
             name: "locationRoot",
             url: "library/location/locationlist",
             defaults: new { controller = "Library", action = "Location" });

            routes.MapRoute(
                name: "location",
                url: "library/location/{*catchall}",
                defaults: new { controller = "Library", action = "Location" });

            routes.MapRoute(
            name: "memberRoot",
            url: "library/member/memberlist",
            defaults: new { controller = "Library", action = "Member" });

            routes.MapRoute(
                name: "member",
                url: "library/member/{*catchall}",
                defaults: new { controller = "Library", action = "Member" });

            routes.MapRoute(
            name: "resourceRoot",
            url: "library/resource/resourcelist",
            defaults: new { controller = "Library", action = "Resource" });

            routes.MapRoute(
                name: "resource",
                url: "library/resource/{*catchall}",
                defaults: new { controller = "Library", action = "Resource" });

            routes.MapRoute(
            name: "borrowedRoot",
            url: "library/borrowed/borrowedlist",
            defaults: new { controller = "Library", action = "Borrowed" });

            routes.MapRoute(
                name: "borrowed",
                url: "library/borrowed/{*catchall}",
                defaults: new { controller = "Library", action = "Borrowed" });

            routes.MapRoute(
            name: "returnedRoot",
            url: "library/returned/returnedlist",
            defaults: new { controller = "Library", action = "Returned" });

            routes.MapRoute(
                name: "returned",
                url: "library/returned/{*catchall}",
                defaults: new { controller = "Library", action = "Returned" });

            routes.MapRoute(
             name: "membercategoryRoot",
             url: "library/membercategory/membercategorylist",
             defaults: new { controller = "Library", action = "MemberCategory" });

            routes.MapRoute(
                name: "membercategory",
                url: "library/membercategory/{*catchall}",
                defaults: new { controller = "Library", action = "MemberCategory" });

            routes.MapRoute(
             name: "resourcecategoryRoot",
             url: "library/resourcecategory/resourcecategorylist",
             defaults: new { controller = "Library", action = "ResourceCategory" });

            routes.MapRoute(
                name: "resourcecategory",
                url: "library/resourcecategory/{*catchall}",
                defaults: new { controller = "Library", action = "ResourceCategory" });

            routes.MapRoute(
            name: "borroweddetailRoot",
            url: "library/borroweddetail/borroweddetaillist",
            defaults: new { controller = "Library", action = "BorrowedDetail" });

            routes.MapRoute(
                name: "borroweddetail",
                url: "library/borroweddetail/{*catchall}",
                defaults: new { controller = "Library", action = "BorrowedDetail" });

            routes.MapRoute(
             name: "returneddetailRoot",
             url: "library/returneddetail/returneddetaillist",
             defaults: new { controller = "Library", action = "ReturnedDetail" });

            routes.MapRoute(
                name: "returneddetail",
                url: "library/returneddetail/{*catchall}",
                defaults: new { controller = "Library", action = "ReturnedDetail" });

            routes.MapRoute(
             name: "penaltyconfigurationRoot",
             url: "library/penaltyconfiguration/penaltyconfigurationlist",
             defaults: new { controller = "Library", action = "PenaltyConfiguration" });

            routes.MapRoute(
                name: "penaltyconfiguration",
                url: "library/penaltyconfiguration/{*catchall}",
                defaults: new { controller = "Library", action = "PenaltyConfiguration" });
        }

        private static void RegisterMedicalRoute(RouteCollection routes)
        {
            //Medical
            routes.MapRoute(
             name: "illnessRoot",
             url: "medical/illness/illnessedit",
             defaults: new { controller = "Medical", action = "Illness" });

            routes.MapRoute(
                name: "illness",
                url: "medical/illness/{*catchall}",
                defaults: new { controller = "Medical", action = "Illness" });

            routes.MapRoute(
             name: "studentillnessmapRoot",
             url: "medical/studentillnessmap/studentillnessmapedit",
             defaults: new { controller = "Medical", action = "StudentIllnessMap" });

            routes.MapRoute(
                name: "studentillnessmap",
                url: "medical/studentillnessmap/{*catchall}",
                defaults: new { controller = "Medical", action = "StudentIllnessMap" });

            routes.MapRoute(
         name: "personalhealthhistoryRoot",
         url: "medical/personalhealthhistory/personalhealthhistoryedit",
         defaults: new { controller = "Medical", action = "PersonalHealthHistory" });

            routes.MapRoute(
                name: "personalhealthhistory",
                url: "medical/personalhealthhistory/{*catchall}",
                defaults: new { controller = "Medical", action = "PersonalHealthHistory" });

            routes.MapRoute(
      name: "personalhealthhistorymapRoot",
      url: "medical/personalhealthhistorymap/personalhealthhistorymapedit",
      defaults: new { controller = "Medical", action = "PersonalHealthHistoryMap" });

            routes.MapRoute(
                name: "personalhealthhistorymap",
                url: "medical/personalhealthhistorymap/{*catchall}",
                defaults: new { controller = "Medical", action = "PersonalHealthHistoryMap" });




            routes.MapRoute(
          name: "bodymaxindexRoot",
          url: "medical/bodymaxindex/bodymaxindexedit",
          defaults: new { controller = "Medical", action = "BodyMaxIndex" });

            routes.MapRoute(
                name: "bodymaxindex",
                url: "medical/bodymaxindex/{*catchall}",
                defaults: new { controller = "Medical", action = "BodyMaxIndex" });

            routes.MapRoute(
        name: "bloodpressureRoot",
        url: "medical/bloodpressure/bloodpressureedit",
        defaults: new { controller = "Medical", action = "BloodPressure" });

            routes.MapRoute(
                name: "bloodpressure",
                url: "medical/bloodpressure/{*catchall}",
                defaults: new { controller = "Medical", action = "BloodPressure" });



        }

        private static void RegisterCommunicationRoute(RouteCollection routes)
        {
            //Communication
            routes.MapRoute(
             name: "channelRoot",
             url: "communication/channel/channellist",
             defaults: new { controller = "Communication", action = "Channel" });

            routes.MapRoute(
                name: "channel",
                url: "communication/channel/{*catchall}",
                defaults: new { controller = "Communication", action = "Channel" });

            routes.MapRoute(
             name: "smssetupRoot",
             url: "communication/smssetup/smssetuplist",
             defaults: new { controller = "Communication", action = "SMSSetup" });

            routes.MapRoute(
                name: "smssetup",
                url: "communication/smssetup/{*catchall}",
                defaults: new { controller = "Communication", action = "SMSSetup" });

            routes.MapRoute(
            name: "emailsetupRoot",
            url: "communication/emailsetup/emailsetuplist",
            defaults: new { controller = "Communication", action = "EmailSetup" });

            routes.MapRoute(
                name: "emailsetup",
                url: "communication/emailsetup/{*catchall}",
                defaults: new { controller = "Communication", action = "EmailSetup" });

                routes.MapRoute(
                name: "facebooksetupRoot",
                url: "communication/facebooksetup/facebooksetuplist",
                defaults: new { controller = "Communication", action = "FacebookSetup" });

                routes.MapRoute(
                name: "facebooksetup",
                url: "communication/facebooksetup/{*catchall}",
                defaults: new { controller = "Communication", action = "FacebookSetup" });


            routes.MapRoute(
             name: "communicationHistoryRoot",
             url: "communication/communicationHistory/channellist",
             defaults: new { controller = "Communication", action = "CommunicationHistory" });

            routes.MapRoute(
                name: "communicationHistory",
                url: "communication/communicationHistory/{*catchall}",
                defaults: new { controller = "Communication", action = "CommunicationHistory" });
        }

        private static void RegisterFinancialRoute(RouteCollection routes)
        {

            routes.MapRoute(
             name: "feecategoryRoot",
             url: "financial/feecategory/feecategorylist",
             defaults: new { controller = "Financial", action = "feeCategory" });

            routes.MapRoute(
                name: "feecategory",
                url: "financial/feecategory/{*catchall}",
                defaults: new { controller = "Financial", action = "feeCategory" });

            routes.MapRoute(
            name: "feeaccountRoot",
            url: "financial/feeaccount/feeaccountlist",
            defaults: new { controller = "Financial", action = "feeAccount" });

            routes.MapRoute(
                name: "feeaccount",
                url: "financial/feeaccount/{*catchall}",
                defaults: new { controller = "Financial", action = "feeAccount" });



            routes.MapRoute(
            name: "accountsetRoot",
            url: "financial/accountset/accountsetlist",
            defaults: new { controller = "Financial", action = "accountSet" });

            routes.MapRoute(
                name: "accountset",
                url: "financial/accountset/{*catchall}",
                defaults: new { controller = "Financial", action = "accountSet" });


            routes.MapRoute(
            name: "feetrackerRoot",
            url: "financial/feetracker/feetrackerlist",
            defaults: new { controller = "Financial", action = "feeTracker" });

            routes.MapRoute(
                name: "feetracker",
                url: "financial/feetracker/{*catchall}",
                defaults: new { controller = "Financial", action = "feeTracker" });


            routes.MapRoute(
             name: "feeitemRoot",
             url: "financial/feeitem/feeitemlist",
             defaults: new { controller = "Financial", action = "feeItem" });

            routes.MapRoute(
                name: "feeitem",
                url: "financial/feeitem/{*catchall}",
                defaults: new { controller = "Financial", action = "feeItem" });


            routes.MapRoute(
             name: "feeitempostRoot",
             url: "financial/feeitempost/feeitempostlist",
             defaults: new { controller = "Financial", action = "feeItempost" });

            routes.MapRoute(
                name: "feeitempost",
                url: "financial/feeitempost/{*catchall}",
                defaults: new { controller = "Financial", action = "feeItempost" });

            routes.MapRoute(
             name: "feeplanRoot",
             url: "financial/feeplan/feeplanedit",
             defaults: new { controller = "Financial", action = "feePlan" });

            routes.MapRoute(
                name: "feeplan",
                url: "financial/feeplan/{*catchall}",
                defaults: new { controller = "Financial", action = "feePlan" });


            routes.MapRoute(
             name: "feeplanpostRoot",
             url: "financial/feeplanpost/feeplanpostlist",
             defaults: new { controller = "Financial", action = "feePlanPost" });

            routes.MapRoute(
                name: "feeplanpost",
                url: "financial/feeplanpost/{*catchall}",
                defaults: new { controller = "Financial", action = "feePlanPost" });

            routes.MapRoute(
             name: "feeitemmapRoot",
             url: "financial/feeitemmap/feeitemmaplist",
             defaults: new { controller = "Financial", action = "feeItemMap" });

            routes.MapRoute(
                name: "feeitemmap",
                url: "financial/feeitemmap/{*catchall}",
                defaults: new { controller = "Financial", action = "feeItemMap" });

            routes.MapRoute(
             name: "masterdataRoot",
             url: "financial/masterdata/masterdatalist",
             defaults: new { controller = "Financial", action = "masterData" });

            routes.MapRoute(
                name: "masterdata",
                url: "financial/masterdata/{*catchall}",
                defaults: new { controller = "Financial", action = "masterData" });

            routes.MapRoute(
             name: "erpselectionRoot",
             url: "financial/erpselection/erpselectionlist",
             defaults: new { controller = "Financial", action = "eRPSelection" });

            routes.MapRoute(
                name: "erpselection",
                url: "financial/erpselection/{*catchall}",
                defaults: new { controller = "Financial", action = "eRPSelection" });

            routes.MapRoute(
             name: "gatewayconfigRoot",
             url: "financial/gatewayconfig/gatewayconfiglist",
             defaults: new { controller = "Financial", action = "gatewayConfig" });

            routes.MapRoute(
                name: "gatewayconfig",
                url: "financial/gatewayconfig/{*catchall}",
                defaults: new { controller = "Financial", action = "gatewayConfig" });

        }

        private static void RegisterProjectRoute(RouteCollection routes)
        {
            //Project
            routes.MapRoute(
             name: "projectdefinitionRoot",
             url: "project/projectdefinition/projectdefinitionlist",
             defaults: new { controller = "Project", action = "ProjectDefinition" });

            routes.MapRoute(
                name: "projectdefinition",
                url: "project/projectdefinition/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectDefinition" });

            routes.MapRoute(
             name: "projectsupervisorRoot",
             url: "project/projectsupervisor/projectsupervisorlist",
             defaults: new { controller = "Project", action = "ProjectSupervisor" });

            routes.MapRoute(
                name: "projectsupervisor",
                url: "project/projectsupervisor/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectSupervisor" });

            routes.MapRoute(
            name: "projectstudentsupervisorRoot",
            url: "project/projectstudentsupervisor/projectstudentsupervisorlist",
            defaults: new { controller = "Project", action = "ProjectStudentSupervisor" });

            routes.MapRoute(
                name: "projectstudentsupervisor",
                url: "project/projectstudentsupervisor/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectStudentSupervisor" });

            routes.MapRoute(
             name: "projectproposalRoot",
             url: "project/projectproposal/projectproposallist",
             defaults: new { controller = "Project", action = "ProjectProposal" });

            routes.MapRoute(
                name: "projectproposal",
                url: "project/projectproposal/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectProposal" });

            routes.MapRoute(
             name: "projectscoredefinitionRoot",
             url: "project/projectscoredefinition/projectscoredefinitionlist",
             defaults: new { controller = "Project", action = "ProjectScoreDefinition" });

            routes.MapRoute(
                name: "projectscoredefinition",
                url: "project/projectscoredefinition/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectScoreDefinition" });

            routes.MapRoute(
            name: "projecttopicapprovalRoot",
            url: "project/projecttopicapproval/projecttopicapprovallist",
            defaults: new { controller = "Project", action = "ProjectTopicApproval" });

            routes.MapRoute(
                name: "projecttopicapproval",
                url: "project/projecttopicapproval/{*catchall}",
                defaults: new { controller = "Project", action = "ProjectTopicApproval" });
        }

        private static void RegisterAssessmentRoute(RouteCollection routes)
        {
            //LessonPlan

            routes.MapRoute(
             name: "miniprojectdefinitionRoot",
             url: "assessment/miniprojectdefinition/miniprojectdefinitionlist",
             defaults: new { controller = "Assessment", action = "MiniProjectDefinition" });

            routes.MapRoute(
                name: "miniprojectdefinition",
                url: "assessment/miniprojectdefinition/{*catchall}",
                defaults: new { controller = "Assessment", action = "MiniProjectDefinition" });

            routes.MapRoute(
              name: "labdefinitionRoot",
              url: "assessment/labdefinition/labdefinitionlist",
              defaults: new { controller = "Assessment", action = "LabDefinition" });

            routes.MapRoute(
                name: "labdefinition",
                url: "assessment/labdefinition/{*catchall}",
                defaults: new { controller = "Assessment", action = "LabDefinition" });

            routes.MapRoute(
             name: "examdefinitionRoot",
             url: "assessment/examdefinition/examdefinitionlist",
             defaults: new { controller = "Assessment", action = "ExamDefinition" });

            routes.MapRoute(
                name: "examdefinition",
                url: "assessment/examdefinition/{*catchall}",
                defaults: new { controller = "Assessment", action = "ExamDefinition" });

            routes.MapRoute(
             name: "testdefinitionRoot",
             url: "assessment/testdefinition/testdefinitionlist",
             defaults: new { controller = "Assessment", action = "TestDefinition" });

            routes.MapRoute(
                name: "testdefinition",
                url: "assessment/testdefinition/{*catchall}",
                defaults: new { controller = "Assessment", action = "TestDefinition" });

            routes.MapRoute(
             name: "assignmentdefinitionRoot",
             url: "assessment/assignmentdefinition/assignmentdefinitionlist",
             defaults: new { controller = "Assessment", action = "AssignmentDefinition" });

            routes.MapRoute(
                name: "assignmentdefinition",
                url: "assessment/assignmentdefinition/{*catchall}",
                defaults: new { controller = "Assessment", action = "AssignmentDefinition" });


            routes.MapRoute(
            name: "miniprojectRoot",
            url: "assessment/miniproject/miniprojectlist",
            defaults: new { controller = "Assessment", action = "MiniProject" });

            routes.MapRoute(
                name: "miniproject",
                url: "assessment/miniproject/{*catchall}",
                defaults: new { controller = "Assessment", action = "MiniProject" });

            routes.MapRoute(
              name: "labRoot",
              url: "assessment/lab/lablist",
              defaults: new { controller = "Assessment", action = "Lab" });

            routes.MapRoute(
                name: "lab",
                url: "assessment/lab/{*catchall}",
                defaults: new { controller = "Assessment", action = "Lab" });

            routes.MapRoute(
             name: "examRoot",
             url: "assessment/exam/examlist",
             defaults: new { controller = "Assessment", action = "Exam" });

            routes.MapRoute(
                name: "exam",
                url: "assessment/exam/{*catchall}",
                defaults: new { controller = "Assessment", action = "Exam" });

            routes.MapRoute(
             name: "testRoot",
             url: "assessment/test/testlist",
             defaults: new { controller = "Assessment", action = "Test" });

            routes.MapRoute(
                name: "test",
                url: "assessment/test/{*catchall}",
                defaults: new { controller = "Assessment", action = "Test" });

            routes.MapRoute(
             name: "assignmentRoot",
             url: "assessment/assignment/assignmentlist",
             defaults: new { controller = "Assessment", action = "Assignment" });

            routes.MapRoute(
                name: "assignment",
                url: "assessment/assignment/{*catchall}",
                defaults: new { controller = "Assessment", action = "Assignment" });


            routes.MapRoute(
            name: "miniprojectscoreRoot",
            url: "assessment/miniprojectscore/miniprojectscorelist",
            defaults: new { controller = "Assessment", action = "MiniProjectScore" });

            routes.MapRoute(
                name: "projectscore",
                url: "assessment/miniprojectscore/{*catchall}",
                defaults: new { controller = "Assessment", action = "MiniProjectScore" });

            routes.MapRoute(
              name: "labscoreRoot",
              url: "assessment/labscore/labscorelist",
              defaults: new { controller = "Assessment", action = "LabScore" });

            routes.MapRoute(
                name: "labscore",
                url: "assessment/labscore/{*catchall}",
                defaults: new { controller = "Assessment", action = "LabScore" });

            routes.MapRoute(
             name: "examscoreRoot",
             url: "assessment/examscore/examscorelist",
             defaults: new { controller = "Assessment", action = "ExamScore" });

            routes.MapRoute(
                name: "examscore",
                url: "assessment/examscore/{*catchall}",
                defaults: new { controller = "Assessment", action = "ExamScore" });

            routes.MapRoute(
             name: "testscoreRoot",
             url: "assessment/testscore/testscorelist",
             defaults: new { controller = "Assessment", action = "TestScore" });

            routes.MapRoute(
                name: "testscore",
                url: "assessment/testscore/{*catchall}",
                defaults: new { controller = "Assessment", action = "TestScore" });

            routes.MapRoute(
             name: "assignmentscoreRoot",
             url: "assessment/assignmentscore/assignmentscorelist",
             defaults: new { controller = "Assessment", action = "AssignmentScore" });

            routes.MapRoute(
                name: "assignmentscore",
                url: "assessment/assignmentscore/{*catchall}",
                defaults: new { controller = "Assessment", action = "AssignmentScore" });

            routes.MapRoute(
             name: "endprocessRoot",
             url: "assessment/endprocess/endprocesslist",
             defaults: new { controller = "Assessment", action = "EndProcess" });

            routes.MapRoute(
                name: "endprocess",
                url: "assessment/endprocess/{*catchall}",
                defaults: new { controller = "Assessment", action = "EndProcess" });

            routes.MapRoute(
             name: "assignmenthistoryRoot",
             url: "assessment/assignmenthistory/assignmenthistorylist",
             defaults: new { controller = "Assessment", action = "AssignmentHistory" });

            routes.MapRoute(
                name: "assignmenthistory",
                url: "assessment/assignmenthistory/{*catchall}",
                defaults: new { controller = "Assessment", action = "AssignmentHistory" });

            routes.MapRoute(
             name: "labhistoryRoot",
             url: "assessment/labhistory/labhistorylist",
             defaults: new { controller = "Assessment", action = "LabHistory" });

            routes.MapRoute(
                name: "labhistory",
                url: "assessment/labhistory/{*catchall}",
                defaults: new { controller = "Assessment", action = "LabHistory" });

            routes.MapRoute(
             name: "testhistoryRoot",
             url: "assessment/testhistory/testhistorylist",
             defaults: new { controller = "Assessment", action = "TestHistory" });

            routes.MapRoute(
                name: "testhistory",
                url: "assessment/testhistory/{*catchall}",
                defaults: new { controller = "Assessment", action = "TestHistory" });

            routes.MapRoute(
             name: "examhistoryRoot",
             url: "assessment/examhistory/examhistorylist",
             defaults: new { controller = "Assessment", action = "ExamHistory" });

            routes.MapRoute(
                name: "examhistory",
                url: "assessment/examhistory/{*catchall}",
                defaults: new { controller = "Assessment", action = "ExamHistory" });

            routes.MapRoute(
             name: "miniprojecthistoryRoot",
             url: "assessment/miniprojecthistory/miniprojecthistorylist",
             defaults: new { controller = "Assessment", action = "MiniProjectHistory" });

            routes.MapRoute(
                name: "miniprojecthistory",
                url: "assessment/miniprojecthistory/{*catchall}",
                defaults: new { controller = "Assessment", action = "MiniProjectHistory" });
        }

        private static void RegisterDisciplineRoute(RouteCollection routes)
        {
            //Discipline Module

            routes.MapRoute(
             name: "complainRoot",
             url: "discipline/complain/complainlist",
             defaults: new { controller = "Discipline", action = "Complain" });

            routes.MapRoute(
                name: "complain",
                url: "discipline/complain/{*catchall}",
                defaults: new { controller = "Discipline", action = "Complain" });

            routes.MapRoute(
            name: "casecommunicationRoot",
            url: "discipline/casecommunication/casecommunicationlist",
            defaults: new { controller = "Doscipline", action = "CaseCommunication" });

            routes.MapRoute(
                name: "casecommunication",
                url: "discipline/casecommunication/{*catchall}",
                defaults: new { controller = "Discipline", action = "CaseCommunication" });

            routes.MapRoute(
           name: "categorysetupRoot",
           url: "discipline/categorysetup/categorysetuplist",
           defaults: new { controller = "Discipline", action = "CategorySetup" });

            routes.MapRoute(
                name: "categorysetup",
                url: "discipline/categorysetup/{*catchall}",
                defaults: new { controller = "Discipline", action = "CategorySetup" });


            routes.MapRoute(
           name: "penaltysetupRoot",
           url: "discipline/penaltysetup/penaltysetuplist",
           defaults: new { controller = "Doscipline", action = "PenaltySetup" });

            routes.MapRoute(
                name: "penaltysetup",
                url: "discipline/penaltysetup/{*catchall}",
                defaults: new { controller = "Discipline", action = "PenaltySetup" });

            routes.MapRoute(
          name: "disciplinepanelRoot",
          url: "discipline/disciplinepanel/disciplinepanellist",
          defaults: new { controller = "Discipline", action = "DisciplinePanel" });

            routes.MapRoute(
                name: "disciplinepanel",
                url: "discipline/disciplinepanel/{*catchall}",
                defaults: new { controller = "Discipline", action = "DisciplinePanel" });

            routes.MapRoute(
          name: "personnelsetupRoot",
          url: "discipline/personnelsetup/personnelsetuplist",
          defaults: new { controller = "Discipline", action = "PersonnelSetup" });

            routes.MapRoute(
                name: "personnelsetup",
                url: "discipline/personnelsetup/{*catchall}",
                defaults: new { controller = "Discipline", action = "PersonnelSetup" });

            routes.MapRoute(
          name: "incidencesetupRoot",
          url: "discipline/incidencesetup/incidencesetuplist",
          defaults: new { controller = "Discipline", action = "IncidenceSetup" });

            routes.MapRoute(
                name: "incidencesetup",
                url: "discipline/incidencesetup/{*catchall}",
                defaults: new { controller = "Discipline", action = "IncidenceSetup" });

            routes.MapRoute(
         name: "disciplinepanelmembersRoot",
         url: "discipline/disciplinepanelmembers/disciplinepanelmemberslist",
         defaults: new { controller = "Discipline", action = "DisciplinePanelMembers" });

            routes.MapRoute(
                name: "disciplinepanelmembers",
                url: "discipline/disciplinepanelmembers/{*catchall}",
                defaults: new { controller = "Discipline", action = "DisciplinePanelMembers" });

            routes.MapRoute(
      name: "disciplinaryofficerRoot",
      url: "discipline/disciplinaryofficer/disciplinaryofficerlist",
      defaults: new { controller = "Discipline", action = "DisciplinaryOfficer" });

            routes.MapRoute(
                name: "disciplinaryofficer",
                url: "discipline/disciplinaryofficer/{*catchall}",
                defaults: new { controller = "Discipline", action = "DisciplinaryOfficer" });

        }

        private static void RegisterFacilityRoute(RouteCollection routes)
        {
            //Facility Module
            routes.MapRoute(
                        name: "facilitypurposeRoot",
                        url: "facilitymanagement/facilitypurpose/facilitypurposelist",
                        defaults: new { controller = "FacilityManagement", action = "FacilityPurpose" });

            routes.MapRoute(
                name: "facilitypurpose",
                url: "facilitymanagement/facilitypurpose/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FacilityPurpose" });


            routes.MapRoute(
             name: "facilitystatusRoot",
             url: "facilitymanagement/facilitystatus/facilitystatuslist",
             defaults: new { controller = "FacilityManagement", action = "FacilityStatus" });

            routes.MapRoute(
                name: "facilitystatus",
                url: "facilitymanagement/facilitystatus/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FacilityStatus" });

            routes.MapRoute(
             name: "facilitycategoryRoot",
             url: "facilitymanagement/facilitycategory/facilitycategorylist",
             defaults: new { controller = "FacilityManagement", action = "FacilityCategory" });

            routes.MapRoute(
                name: "facilitycategory",
                url: "facilitymanagement/facilitycategory/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FacilityCategory" });

            routes.MapRoute(
             name: "categoryRoot",
             url: "management/category/categorylist",
             defaults: new { controller = "FacilityManagement", action = "Category" });

            routes.MapRoute(
                name: "category",
                url: "management/category/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "Category" });

            routes.MapRoute(
             name: "assetsRoot",
             url: "facilitymanagement/assets/assetslist",
             defaults: new { controller = "FacilityManagement", action = "Assets" });

            routes.MapRoute(
                name: "assets",
                url: "facilitymanagement/assets/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "Assets" });

            routes.MapRoute(
             name: "facilityregisterRoot",
             url: "facilitymanagement/facilityregister/facilityregisterlist",
             defaults: new { controller = "FacilityManagement", action = "FacilityRegister" });

            routes.MapRoute(
                name: "facilityregister",
                url: "facilitymanagement/facilityregister/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FacilityRegister" });

            routes.MapRoute(
             name: "floorregisterRoot",
             url: "facilitymanagement/floorregister/floorregisterlist",
             defaults: new { controller = "FacilityManagement", action = "FloorRegister" });

            routes.MapRoute(
                name: "floorregister",
                url: "facilitymanagement/floorregister/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FloorRegister" });

       



            

            routes.MapRoute(
                name: "unitregister",
                url: "technician/unitregister/{*catchall}",
                defaults: new { controller = "Technician", action = "UnitRegister" });

            routes.MapRoute(
       name: "unitregisterRoot",
       url: "helpdesk/unitregister/unitregisterlist",
       defaults: new { controller = "HelpDesk", action = "UnitRegister" });

      

            routes.MapRoute(
                name: "facilityGroup",
                url: "facilitymanagement/facilitygroup/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "FacilityGroup" });

            routes.MapRoute(
             name: "vendorGroupRoot",
             url: "facilitymanagement/vendorgroup/vendorgrouplist",
             defaults: new { controller = "FacilityManagement", action = "VendorGroup" });

            routes.MapRoute(
                name: "vendorGroup",
                url: "facilitymanagement/vendorgroup/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "VendorGroup" });

            routes.MapRoute(
             name: "vendorRoot",
             url: "facilitymanagement/vendor/vendorlist",
             defaults: new { controller = "FacilityManagement", action = "Vendor" });

            routes.MapRoute(
                name: "vendor",
                url: "facilitymanagement/vendor/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "Vendor" });

            routes.MapRoute(
            name: "unitassetRoot",
            url: "facilitymanagement/unitasset/unitassetlist",
            defaults: new { controller = "FacilityManagement", action = "UnitAsset" });

            routes.MapRoute(
                name: "unitasset",
                url: "facilitymanagement/unitasset/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "UnitAsset" });


            routes.MapRoute(
       name: "techniciancategoryRoot",
       url: "facilitymanagement/techniciancategory/techniciancategorylist",
       defaults: new { controller = "FacilityManagement", action = "TechnicianCategory" });

            routes.MapRoute(
                name: "techniciancategory",
                url: "facilitymanagement/techniciancategory/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "TechnicianCategory" });

            routes.MapRoute(
      name: "technicianRoot",
      url: "facilitymanagement/technician/technicianlist",
      defaults: new { controller = "FacilityManagement", action = "Technician" });

            routes.MapRoute(
                name: "technician",
                url: "facilitymanagement/technician/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "Technician" });

            routes.MapRoute(
      name: "helpdeskRoot",
      url: "facilitymanagement/helpdesk/helpdesklist",
      defaults: new { controller = "FacilityManagement", action = "HelpDesk" });

            routes.MapRoute(
                name: "helpdesk",
                url: "facilitymanagement/helpdesk/{*catchall}",
                defaults: new { controller = "FacilityManagement", action = "HelpDesk" });


        }

        private static void RegisterHostelRoute(RouteCollection routes)
        {
            //Hostel Module
            routes.MapRoute(
                        name: "hostelpurposeRoot",
                        url: "hostel/hostelpurpose/hostelpurposelist",
                        defaults: new { controller = "Hostel", action = "HostelPurpose" });

            routes.MapRoute(
                name: "hostelpurpose",
                url: "hostel/hostelpurpose/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelPurpose" });


           
            routes.MapRoute(
             name: "hostelcategoryRoot",
             url: "hostel/hostelcategory/hostelcategorylist",
             defaults: new { controller = "Hostel", action = "HostelCategory" });

            routes.MapRoute(
                name: "hostelcategory",
                url: "hostel/hostelcategory/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelCategory" });

            routes.MapRoute(
          name: "hostelsupervisorRoot",
          url: "hostel/hostelsupervisor/hostelsupervisorlist",
          defaults: new { controller = "Hostel", action = "HostelSupervisor" });

            routes.MapRoute(
                name: "hostelsupervisor",
                url: "hostel/hostelsupervisor/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelSupervisor" });

            routes.MapRoute(
          name: "roomsetupRoot",
          url: "hostel/roomsetup/roomsetuplist",
          defaults: new { controller = "Hostel", action = "RoomSetup" });

            routes.MapRoute(
                name: "roomsetup",
                url: "hostel/roomsetup/{*catchall}",
                defaults: new { controller = "Hostel", action = "RoomSetup" });

            routes.MapRoute(
          name: "hostelcategorymapRoot",
          url: "hostel/hostelcategorymap/hostelcategorymaplist",
          defaults: new { controller = "Hostel", action = "HostelCategoryMap" });

            routes.MapRoute(
                name: "hostelcategorymap",
                url: "hostel/hostelcategorymap/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelCategoryMap" });


            routes.MapRoute(
             name: "hostelapplicationRoot",
             url: "hostel/hostelapplication/hostelapplicationlist",
             defaults: new { controller = "Hostel", action = "HostelAllocation" });

            routes.MapRoute(
                name: "hostelapplication",
                url: "hostel/hostelapplication/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelAllocation" });

            routes.MapRoute(
          name: "hostelallocationRoot",
          url: "hostel/hostelallocation/hostelallocationlist",
          defaults: new { controller = "Hostel", action = "HostelAllocation" });

            routes.MapRoute(
                name: "hostelallocation",
                url: "hostel/hostelallocation/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelAllocation" });
          

            routes.MapRoute(
              name: "hostellogRoot",
              url: "hostel/hostellog/hostelloglist",
              defaults: new { controller = "Hostel", action = "HostelLog" });

            routes.MapRoute(
                name: "hostellog",
                url: "hostel/hostellog/{*catchall}",
                defaults: new { controller = "Hostel", action = "HostelLog" });

            routes.MapRoute(
              name: "visitorlogRoot",
              url: "hostel/visitorlog/hostelloglist",
              defaults: new { controller = "Hostel", action = "VisitorLog" });

            routes.MapRoute(
                name: "visitorlog",
                url: "hostel/visitorlog/{*catchall}",
                defaults: new { controller = "Hostel", action = "VisitorLog" });


        }

    }

}
