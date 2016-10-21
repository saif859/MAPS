using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MAPS.handler
{
    public class FileUploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fileName = HttpContext.Current.Request.QueryString["FileName"].ToString();
            try
            {
                using (FileStream fs = File.Create(context.Server.MapPath("~") + "\\MAP\\" + fileName))
                {
                    Byte[] buffer = new Byte[32 * 1024];
                    int read = context.Request.GetBufferlessInputStream().Read(buffer, 0, buffer.Length);
                    while (read > 0)
                    {
                        fs.Write(buffer, 0, read);

                        System.Drawing.Image img = System.Drawing.Image.FromStream(fs);

                        img.HorizontalResolution.ToString();

                        read = context.Request.GetBufferlessInputStream().Read(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception ex) { }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}