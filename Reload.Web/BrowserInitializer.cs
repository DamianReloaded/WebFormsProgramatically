using System;
using System.Reflection;
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
            InitiSystemPages(siteBrowser);
        }

        public virtual void InitiSystemPages(SiteBrowser siteBrowser)
        {
            if (!siteBrowser.Pages.ContainsKey(Constants.SystemPageName.Login)) Browser.Add(Constants.SystemPageName.Login, () => { return new SystemPages.Login(); });
            if (!siteBrowser.Pages.ContainsKey(Constants.SystemPageName.NotFound)) Browser.Add(Constants.SystemPageName.NotFound, () => { return new SystemPages.NotFound(); });
        }

        public Assembly LoadAssembly(string pathToDll)
        {
            Assembly assembly = Assembly.LoadFrom(pathToDll);
            AppDomain.CurrentDomain.Load(assembly.GetName());
            return assembly;
        }

        public Assembly LoadAssemblyFromBin(string dllName)
        {
            return LoadAssembly(System.Web.Hosting.HostingEnvironment.MapPath(Constants.WebsitePath.RelativeBinFolder) + "\\" + dllName);
        }

        public void LoadPageFromAssembly(Assembly assembly, string fullyQualifiedNamespaceAndClassName)
        {
            Type pageType = assembly.GetType(fullyQualifiedNamespaceAndClassName);
            Browser.Add(pageType.FullName, () => { return (Reload.Web.HtmlPage)Activator.CreateInstance(pageType); });
        }

        public void LoadAllPagesFromAssembly(string dllName)
        {
            var assembly = LoadAssemblyFromBin(dllName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.FullName.Contains(assembly.GetName().Name))
                {
                    try
                    {
                        LoadPageFromAssembly(assembly, type.FullName);
                        throw new Exception("test exception");
                    }
                    catch (Exception /*ex*/)
                    {
                        //LoadPageFromAssembly(assembly, errorType);
                        //Log(ex);
                    }
                }
            }
        }

        void Log(Exception ex)
        {
            new Reload.Web.Log().Write(ex);
        }

        public virtual void AddPages(Reload.Web.SiteBrowser siteBrowser) { }
    }
}