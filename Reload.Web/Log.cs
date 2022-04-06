using System;
using System.IO;

namespace Reload.Web
{
    public class Log
    {
        public void Write(Exception ex, string path= "~/Security/Log")
        {
            string fullPath = System.Web.Hosting.HostingEnvironment.MapPath(path);
            Directory.CreateDirectory(fullPath);
            using (var writer = new StreamWriter(fullPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmssmmm") + ".log"))
            {
                writer.Write(ex.ToString());
            }
        }

    }
}
