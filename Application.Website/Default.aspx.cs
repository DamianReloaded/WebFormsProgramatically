using Application.Frontend;
using System;
using System.Web.UI;

namespace Application.WebSite
{
    public partial class Default : BrowserInitializer
    {
        protected Default()
        {
            Init += InitPages;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            lbltimeonmodal.Text = (System.DateTime.Now.Ticks).ToString();
            lbltime.Text = (System.DateTime.Now.Ticks).ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$(function () {");
            sb.Append(" $('#modaltime').modal('show');});");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ModelScript", sb.ToString(), false);
            */
        }
    }
}