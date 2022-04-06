using System;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;
namespace Reload.Web
{
    [ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
    public class GridJS : DataBoundControl
    {
        DataTable DataTable;
        HtmlGenericControl Div;
        UpdatePanel UpdatePanel;

        public delegate void RowBoundEventHandler(Dictionary<string, object> row);
        public event RowBoundEventHandler RowBound;

        public GridJS() : base()
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
            Div = new HtmlGenericControl("div");
            Div.ID = ID + "_div";
            //Table.Attributes["class"] = "GridView";
            if (data != null)
            {
                DataTable = ((DataView)data).ToTable();
                string javascript = @"
                                    <script id='demo' type='text/javascript'>
                                        var arr = " + DataTableToJSON(DataTable) 
                                    + @";
                                        var currentPage = 0;
                                        var pageSize=2;

                                        function assembleTable()
                                        {
                                            var maxRow = arr.length;
                                            currentPage = (currentPage<0)?0:currentPage;
                                            currentPage = (currentPage>maxRow/pageSize)?(maxRow/pageSize)-1:currentPage;
                                            var startRow = (currentPage*pageSize>maxRow-pageSize)?maxRow-pageSize:currentPage*pageSize;
                                            var endRow = (startRow+pageSize>maxRow)?maxRow:startRow+pageSize;
                                            var str = '<table class=\'GridView\'>';
                                            str = str + '<thead><tr><th>UserId</th><th>UserName</th><th>Education</th><th>Location</th></tr></thead><tbody>'
                                            for (var i=startRow; i<endRow; i++)
                                            {
                                                str = str + '<tr'
                                                if (i % 2) str = str + ' class=\'GridViewAltRow\' ';
                                                str = str + '><td>' + arr[i].UserId + '</td>'
                                                            + '<td>' + arr[i].UserName + '</td>'
                                                            + '<td>' + arr[i].Education + '</td>'
                                                            + '<td>' + arr[i].Location + '</td>'
                                                            + '</tr>';
                                            };
                                            str = str + '</tbody></table>';
			                                return str;
                                        }

                                        function drawTable()
                                        {
                                            var str = assembleTable();                                            
                                            str += '<input type=\'button\' value=\'<\' onClick=\'currentPage--; drawTable(); return false;\' />'                                            
                                            str += '<input type=\'button\' value=\'>\' onClick=\'currentPage++; drawTable(); return false;\' />'
                                            $('#" + Div.ID + @"').html(str);
                                        }

                                        window.addEventListener('load', function() 
                                        {
                                            drawTable();
                                        });
                                    </script >
                ";
                Div.InnerHtml = javascript;
            }
            UpdatePanel.ContentTemplateContainer.Controls.Add(Div);
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

        string DataTableToJSON(DataTable dt)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                RowBound?.Invoke(childRow);
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
    }
}