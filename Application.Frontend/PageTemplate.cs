using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Frontend
{
    public class PageTemplate : Reload.Web.HtmlPage
    {
        public PageTemplate()
        {
            Scripts.Add("library/jquery/jquery-1.11.2.min.js");
            Scripts.Add("library/bootstrap/bootstrap.min.js");
            StyleSheets.Add("library/bootstrap/bootstrap.min.css");
        }
    }
}
