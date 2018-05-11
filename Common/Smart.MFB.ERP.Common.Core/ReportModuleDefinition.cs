using Smart.MFB.ERP.Common.PlaceHolder;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Common.Core
{
    public static class ReportModuleDefinitions
    {
        //Module Category definitions
        public const string MODULE_CATEGORY_NAME = "REPORT_SE";
        public const string MODULE_CATEGORY_ALIAS = "Report";
        public const string MODULE_CATEGORY_CODE = "MCRRSE";
        public const string MODULE_CATEGORY_IMAGEURL = "";
        public const string MODULE_CATEGORY_COLOR = "";
        public const string MODULE_CATEGORY_DESCRIPTION = "";

        //Module definitions
        public const string MODULE_NAME = "REPORT_SE";
        public const string MODULE_ALIAS = "Core";
        public const string MODULE_CODE = "MRCRSE";
        public const string MODULE_DESCRIPTION = "";
        public const string MODULE_IMAGEURL = "";
        public const string MODULE_COLOR = "";
        public const string MODULE_VERSION = "REPORT v1.0";

        public const string DEFAULT_LANGUAGE = "English - United States";
        public const string DEFAULT_COUNTRY = "Nigeria";

        public const string GROUP_ADMINISTRATOR = "Administrator";
        public const string GROUP_SERVICEPROVIDER = "Service Provider";
        public const string GROUP_USER = "User";

        public static List<RolePlaceHolder> GetRoleDefinitions()
        {
            var items = new List<RolePlaceHolder>();

            items.Add(new RolePlaceHolder() { Name = GROUP_ADMINISTRATOR ,Description="Report unlimited role"});
            items.Add(new RolePlaceHolder() { Name = GROUP_SERVICEPROVIDER, Description = "Core Service Provider role" });
            items.Add(new RolePlaceHolder() { Name = GROUP_USER, Description = "Report limited role" });

            return items;
        }

        public static List<MenuPlaceHolder> GetMenuDefinitions()
        {
            var items = new List<MenuPlaceHolder>();

            var setups = new MenuPlaceHolder() { Code = "REM_REP", Name = "REM_REP", Alias = "Report", Action = "None", Controller = "None", ParentName = "None", Description = "", ImageUrl = "", Image = null };
            items.Add(setups);

            //Communication
            var communication = new MenuPlaceHolder() { Code = "COM_REP", Name = "COMM_REP", Alias = "Communication", Action = "None", Controller = "None", ParentName = setups.Name, Description = "", ImageUrl = "fa-phone-square", Image = null };
            items.Add(communication);
            //items.Add(new MenuPlaceHolder() { Code = "CH_COM_C", Name = "CHANNELS_COM_C", Alias = "Channel", Action = "Channel", Controller = "Communication", ParentName = communication.Name, Description = "", ImageUrl = "fa-cog", Image = null });
            return items;
        }

        public static List<MenuRolePlaceHolder> GetMenuRoleDefinitions()
        {
            var items = new List<MenuRolePlaceHolder>();
            //Administrator
            items.Add(new MenuRolePlaceHolder() { MenuName = "REM_REP", RoleName = GROUP_ADMINISTRATOR });
            //Communication
            items.Add(new MenuRolePlaceHolder() { MenuName = "COMM_REP", RoleName = GROUP_ADMINISTRATOR });
            return items;
        }
    }
}