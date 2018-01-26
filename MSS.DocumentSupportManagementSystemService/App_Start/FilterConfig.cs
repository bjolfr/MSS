using System.Web;
using System.Web.Mvc;

namespace MSS.DocumentSupportManagementSystemService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
