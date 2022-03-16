using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reload.Web
{
    [ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
    public class Grid : DataBoundControl
    {
        DataTable DataTable;

        HtmlGenericControl Table;
        UpdatePanel UpdatePanel;

        public Grid() : base()
        {
            DataTable = new DataTable();
        }

        protected override void PerformSelect()
        {
            if (!this.IsBoundUsingDataSourceID)
            {
                this.OnDataBinding(EventArgs.Empty);
            }
            var view = this.GetData();
            view.Select(CreateDataSourceSelectArguments(),
               new DataSourceViewSelectCallback((IEnumerable retrievedData) =>
               {
                   if (this.IsBoundUsingDataSourceID)
                   {
                       this.OnDataBinding(EventArgs.Empty);
                   }
                   this.PerformDataBinding(retrievedData);
               })
            );
        }

        protected override void PerformDataBinding(IEnumerable data)
        {
            base.PerformDataBinding(data);
            UpdatePanel = new UpdatePanel();
            Table = new HtmlGenericControl("table");
            Table.Attributes["class"] = "GridView";
            if (data != null)
            {
                DataTable = ((DataView)data).ToTable();

                HtmlGenericControl trow = new HtmlGenericControl("tr");
                foreach (DataColumn col in DataTable.Columns)
                {
                    {
                        HtmlGenericControl tcol = new HtmlGenericControl("th");
                        tcol.InnerHtml = col.ColumnName;
                        trow.Controls.Add(tcol);
                    }
                }
                Table.Controls.Add(trow);
                bool altRow = false;
                foreach (DataRow row in ((DataView)data).ToTable().Rows)
                {
                    trow = new HtmlGenericControl("tr");
                    if (altRow) trow.Attributes["class"] = "GridViewAltRow";
                    foreach (string value in row.ItemArray)
                    {
                        HtmlGenericControl tcol = new HtmlGenericControl("td");
                        tcol.InnerHtml = value;
                        trow.Controls.Add(tcol);
                    }
                    Table.Controls.Add(trow);
                    altRow = !altRow;
                }
            }
            UpdatePanel.ContentTemplateContainer.Controls.Add(Table);
            this.Parent.Controls.Add(UpdatePanel); 
            this.RequiresDataBinding = false;
            this.MarkAsDataBound();
            this.OnDataBound(EventArgs.Empty);
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (output == null) return;
            if (this.DataTable.Rows.Count <= 0) return;
            if (this.Page != null) this.Page.VerifyRenderingInServerForm(this);
        }
    }
}