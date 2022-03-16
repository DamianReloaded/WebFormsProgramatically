using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace Reload.Web
{
    public class SiteBrowser
    {
        public delegate void AddPagesEvent(SiteBrowser siteBrowser);
        public Dictionary<string, Func<Reload.Web.Content>> Pages { get; set; } = new Dictionary<string, Func<Reload.Web.Content>>();

        public static SiteBrowser Init(Page page)
        {
            SiteBrowser browser = (SiteBrowser)HttpContext.Current.Session["SiteBrowser"];
            if (browser == null)
            {
                browser = new SiteBrowser();
                HttpContext.Current.Session["SiteBrowser"] = browser;
            }

            string pageName = HttpContext.Current.Request.QueryString["page"] ?? "NotFound";
            if (browser.Pages.ContainsKey(pageName))
            {
                Reload.Web.Content content = ((Func<Reload.Web.Content>)browser.Pages[pageName])();
                content.Page = page;
            }
            
            return browser;
        }

        public SiteBrowser()
        {
        }

        public void Add<T>() where T : Content, new()
        {
            Add(typeof(T).Name, () => { return new T(); });
        }

        public void Add(string name, Func<Reload.Web.Content> creationDelegate)
        {
            Pages.Add(name.ToLower(), creationDelegate);
        }
    }
}