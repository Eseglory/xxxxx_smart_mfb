using System.Web;
using System.Web.Mvc;

namespace Smart.MFB.ERP.Host.WService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
