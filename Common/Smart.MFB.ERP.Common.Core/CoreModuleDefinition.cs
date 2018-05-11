using Smart.MFB.ERP.Common.PlaceHolder;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Common.Core
{
    public static class CoreModuleDefinitions
    {
        //Module Category definitions
        public const string MODULE_CATEGORY_NAME = "CORE_SE";
        public const string MODULE_CATEGORY_ALIAS = "Core";
        public const string MODULE_CATEGORY_CODE = "MCCRSE";
        public const string MODULE_CATEGORY_IMAGEURL = "";
        public const string MODULE_CATEGORY_COLOR = "";
        public const string MODULE_CATEGORY_DESCRIPTION = "General Setups";

        //Module definitions
        public const string MODULE_NAME = "CORE_SE";
        public const string MODULE_ALIAS = "Core";
        public const string MODULE_CODE = "MCRSE";
        public const string MODULE_DESCRIPTION = "";
        public const string MODULE_IMAGEURL = "";
        public const string MODULE_COLOR = "";
        public const string MODULE_VERSION = "CORE v1.0";

        public const string DEFAULT_LANGUAGE = "English - United States";
        public const string DEFAULT_COUNTRY = "Nigeria";

        public const string GROUP_ADMINISTRATOR = "Administrator";
        public const string GROUP_SERVICEPROVIDER = "Service Provider";
        public const string GROUP_USER = "User";

        public static List<RolePlaceHolder> GetRoleDefinitions()
        {
            var items = new List<RolePlaceHolder>();

            items.Add(new RolePlaceHolder() { Name = GROUP_ADMINISTRATOR, Description = "Core unlimited role" });
            items.Add(new RolePlaceHolder() { Name = GROUP_SERVICEPROVIDER, Description = "Core Service Provider role" });
            items.Add(new RolePlaceHolder() { Name = GROUP_USER, Description = "Core limited role" });

            return items;
        }

        public static List<MenuPlaceHolder> GetMenuDefinitions()
        {
            var items = new List<MenuPlaceHolder>();

            var setups = new MenuPlaceHolder() { Code = "SEP_COR", Name = "SETUP_COR", Alias = "General Setup", Action = "None", Controller = "None", ParentName = "None", Description = "", ImageUrl = "sf-icon-setup2", Image = null };
            items.Add(setups);
            items.Add(new MenuPlaceHolder() { Code = "MOD_COR", Name = "MODULE_COR", Alias = "License", Action = "Module", Controller = "Core", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-liscense2", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "CONT_COR", Name = "COUNTRY_COR", Alias = "Countries", Action = "Country", Controller = "Core", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-country2", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "LANG_COR", Name = "LANGUAGE_COR", Alias = "Languages", Action = "Language", Controller = "Core", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-language1", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "RELG_COR", Name = "RELIGION_COR", Alias = "Religions", Action = "Religion", Controller = "Core", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-religion1", Image = null });
            var security = new MenuPlaceHolder() { Code = "SECR_COR", Name = "SECURITY_COR", Alias = "Security", Action = "None", Controller = "None", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-security1", Image = null };
            items.Add(security);
            var theme = new MenuPlaceHolder() { Code = "THME_COR", Name = "THEME_COR", Alias = "Theme", Action = "Theme", Controller = "Core", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-student6", Image = null };
            items.Add(theme);
            items.Add(new MenuPlaceHolder() { Code = "ROLE_COR", Name = "ROLE_COR", Alias = "Roles", Action = "Role", Controller = "Core", ParentName = security.Name, Description = "", ImageUrl = "fa-tasks", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "GRP_COR", Name = "GROUP_COR", Alias = "Groups", Action = "Group", Controller = "Core", ParentName = security.Name, Description = "", ImageUrl = "sf-icon-group1", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "USER_COR", Name = "USER_COR", Alias = "Users", Action = "User", Controller = "Core", ParentName = security.Name, Description = "", ImageUrl = "sf-icon-user1", Image = null });
            items.Add(new MenuPlaceHolder() { Code = "CHP_COR", Name = "CHANGE_PASSWORD_COR", Alias = "Change Password", Action = "ChangePassword", Controller = "Core", ParentName = security.Name, Description = "", ImageUrl = "security2", Image = null });
            //Other Menu Management
            var communication = new MenuPlaceHolder() { Code = "COM_COR", Name = "COMM_COR", Alias = "Communication", Action = "None", Controller = "None", ParentName = setups.Name, Description = "", ImageUrl = "sf-icon-communication1", Image = null };
            items.Add(communication);
            items.Add(new MenuPlaceHolder() { Code = "CH_COM_C", Name = "CHANNELS_COM_C", Alias = "Channel", Action = "Channel", Controller = "Communication", ParentName = communication.Name, Description = "", ImageUrl = "sf-icon-communication2", Image = null });

            return items;
        }

        public static List<MenuRolePlaceHolder> GetMenuRoleDefinitions()
        {
            var items = new List<MenuRolePlaceHolder>();

            #region Administrator Menu
            items.Add(new MenuRolePlaceHolder() { MenuName = "SETUP_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "PARAM_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "MODULE_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "COUNTRY_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "LANGUAGE_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "RELIGION_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "SECURITY_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "GROUP_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "USER_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "ROLE_COR", RoleName = GROUP_ADMINISTRATOR });
            //items.Add(new MenuRolePlaceHolder() { MenuName = "MENU_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "THEME_COR", RoleName = GROUP_ADMINISTRATOR });

            //Communication
            items.Add(new MenuRolePlaceHolder() { MenuName = "COMM_COR", RoleName = GROUP_ADMINISTRATOR });
            items.Add(new MenuRolePlaceHolder() { MenuName = "CHANNELS_COM_C", RoleName = GROUP_ADMINISTRATOR });
            #endregion



            return items;
        }
    }
}