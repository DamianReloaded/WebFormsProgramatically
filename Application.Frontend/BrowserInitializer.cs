using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application.Frontend
{
    public class BrowserInitializer : Reload.Web.BrowserInitializer
    {
        public override void AddPages(Reload.Web.SiteBrowser siteBrowser)
        {
            siteBrowser.Add<Home>();
        }
    }
}