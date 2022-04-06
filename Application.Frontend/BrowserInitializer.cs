using System;
using System.IO;
using System.Reflection;
namespace Application.Frontend
{
    public class BrowserInitializer : Reload.Web.BrowserInitializer
    {
        public override void AddPages(Reload.Web.SiteBrowser siteBrowser)
        {
            LoadAllPagesFromAssembly("Application.Pages.Home.dll");
        }
    }
}