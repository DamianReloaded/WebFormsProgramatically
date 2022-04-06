using System;
namespace Reload.Web.SystemPages
{
    public class NotFound : HtmlPage
    {
        public NotFound()
        {
            LoadContent += (object sender, EventArgs e) =>
            {
                Title.InnerText = "Not Found";
                var button = new System.Web.UI.WebControls.Button();
                button.ID = "Not Found";
                button.Text = "Not Found";
                Form.Controls.Add(button);
            };
        }
    }
}
