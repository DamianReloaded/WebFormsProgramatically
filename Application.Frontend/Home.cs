using System.Web.UI.WebControls;
using System.Data;

namespace Application.Frontend
{
    public class Home : Reload.Web.HtmlPage
    {
        public override void RenderPage()
        {
            Title.InnerText = "Home";
                
            Reload.Web.Grid fgrid = new Reload.Web.Grid();
            Form.Controls.Add(fgrid);

            DataTable dtFirst = new DataTable();
            dtFirst.Columns.Add("column1");
            dtFirst.Columns.Add("column2");
            dtFirst.Columns.Add("column3");

            DataRow newRow = dtFirst.Rows.Add();
            newRow.SetField("column1", "Value1");
            newRow.SetField("column2", 1);
            newRow.SetField("column3", "Value3");
            newRow = dtFirst.Rows.Add();
            newRow.SetField("column1", "Value4");
            newRow.SetField("column2", 5);
            newRow.SetField("column3", "Value6");

            fgrid.DataSource = dtFirst;
            fgrid.DataBind();                
        }
    }
}