#region Using

using System.Web.Mvc;

#endregion

namespace Smart.MFB.ERP.Presentation.WebClient
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}