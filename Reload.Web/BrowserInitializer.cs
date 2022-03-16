using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reload.Web
{
    public abstract class BrowserInitializer : Page
    {
        Reload.Web.SiteBrowser Browser;

        public Reload.Web.SiteBrowser InitSiteBrowser()
        {
            Browser = Reload.Web.SiteBrowser.Init(this);
            return Browser;
        }

        public void InitPages(object ds, EventArgs de)
        {
            Reload.Web.SiteBrowser siteBrowser = InitSiteBrowser();
            if (siteBrowser.Pages.Count > 0) return;
            AddPages(siteBrowser);
        }

        public virtual void AddPages(Reload.Web.SiteBrowser siteBrowser) { }
    }
}