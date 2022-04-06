using System;
namespace Application.Pages.Home
{
    public class Test : Application.Frontend.PageTemplate
    {
        public Test()
        {
            LoadContent += (object sender, EventArgs e) =>
            {
                Title.InnerText = "Test";

                var button = new System.Web.UI.WebControls.Button();
                button.ID = "boton";
                button.Text = Page.Session.Timeout.ToString();
                Form.Controls.Add(button);

            };
        }
    }
}
