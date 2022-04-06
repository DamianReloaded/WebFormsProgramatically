using System;
using System.Data;
namespace Application.Pages.Home
{
    public class Main : Application.Frontend.PageTemplate
    {
        public Main()
        {
            LoadContent += (object sender, EventArgs e) =>
            {
                Title.InnerText = "Home";

                DataTable dt = new Application.Modules.Home.Home().GetDataTable();

                Reload.Web.GridJS grid = new Reload.Web.GridJS();
                Form.Controls.Add(grid);
                grid.DataSource = dt;
                grid.DataBind();

                var button = new System.Web.UI.WebControls.Button();
                button.ID = "boton";
                button.Text = "hola";
                Form.Controls.Add(button);

            };
        }
    }
}
