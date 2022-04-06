using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Reload.Web
{
    public class Content
    {
        public string ExecutionUUID { get; set; }
        private Page _Page;
        public event EventHandler Init;
        public event EventHandler InitComplete;
        public event EventHandler PreLoad;
        public event EventHandler Load;
        public event EventHandler LoadComplete;
        public event EventHandler PreRender;
        public event EventHandler PreRenderComplete;
        public event EventHandler SaveStateComplete;
        public event EventHandler Unload;

        public Page Page { get { return _Page; } set { _Page = value; Initialize(); } }

        void Initialize()
        {
            Page.InitComplete += (object sender, EventArgs e) => { InitComplete?.Invoke(sender, e); };
            Page.PreLoad += (object sender, EventArgs e) => { PreLoad?.Invoke(sender, e); };
            Page.Load += (object sender, EventArgs e) => { Load?.Invoke(sender, e); };
            Page.LoadComplete += (object sender, EventArgs e) => { LoadComplete?.Invoke(sender, e); };
            Page.PreRender += (object sender, EventArgs e) => { PreRender?.Invoke(sender, e); }; // some events won't get called if Response.End() is used
            Page.PreRenderComplete += (object sender, EventArgs e) => { PreRenderComplete?.Invoke(sender, e); };           
            Page.SaveStateComplete += (object sender, EventArgs e) => { SaveStateComplete?.Invoke(sender, e); };
            Page.Unload += (object sender, EventArgs e) => { Unload?.Invoke(sender, e); };
            Init?.Invoke(Page, new EventArgs());
        }
    }
}