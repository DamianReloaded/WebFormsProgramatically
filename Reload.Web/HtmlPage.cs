using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Collections.Generic;

namespace Reload.Web
{
    public class HtmlPage : Reload.Web.Content
    {
        public HtmlGenericControl Html { get; set; }
        public HtmlGenericControl Header { get; set; }
        public HtmlGenericControl Title { get; set; }
        public HtmlGenericControl Style { get; set; }
        public HtmlGenericControl Body { get; set; }
        public HtmlForm Form { get; set; }
        public ScriptManager ScriptManager { get; set; }
        public List<string> StyleSheets { get; set; } = new List<string> { "~/Default.css" };

        public void AddStyleSheet(string path)
        {
            HtmlLink link = new HtmlLink();
            link.Href = path;
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            Header.Controls.Add(link);
        }

        public HtmlPage()
        {
            Load += (object sender, EventArgs e) =>
            {
                var doctype = new HtmlGenericControl("!doctype html");
                Html = new HtmlGenericControl("html");
                Header = new HtmlGenericControl("head");
                Style = new HtmlGenericControl("style");
                Title = new HtmlGenericControl("title");
                Body = new HtmlGenericControl("body");
                Form = new HtmlForm();
                ScriptManager = new ScriptManager();
                Title.InnerText = "Home";
                foreach (string path in StyleSheets) AddStyleSheet(path);
                Html.Controls.Add(doctype);
                {
                    Html.Controls.Add(Header);
                    {
                        Header.Controls.Add(Title);
                        Header.Controls.Add(Style);
                    }
                    Html.Controls.Add(Body);
                    {
                        Body.Controls.Add(Form);
                        {
                            Form.Controls.Add(ScriptManager);
                        }
                    }
                }
                Page.Controls.Add(Html); // All tags must be added before controls

                RenderPage();
            };
        }

        public virtual void RenderPage() { }
    }
}