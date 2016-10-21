using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace MAPS.handler
{
    /// <summary>
    /// Summary description for FileValidator
    /// </summary>
    public class FileValidator : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                using (MemoryStream mm = new MemoryStream())
                {
                    context.Response.ContentType = "application/json";

                    Byte[] buffer = new Byte[32 * 1024];
                    int read = context.Request.GetBufferlessInputStream().Read(buffer, 0, buffer.Length);
                    if (read > 0)
                    {
                        mm.Write(buffer, 0, read);

                        System.Drawing.Image img = System.Drawing.Image.FromStream(mm);


                        context.Response.Write(JsonConvert.SerializeObject(new { listname = new[] { img.HorizontalResolution } }));

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