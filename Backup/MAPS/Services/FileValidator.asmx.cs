using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;

namespace MAPS.Services
{
    /// <summary>
    /// Summary description for FileValidator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FileValidator : System.Web.Services.WebService
    {

        [WebMethod]
        public string FileValid(Stream stream)
        {
            try
            {
                using (MemoryStream mm = new MemoryStream())
                {

                    Byte[] buffer = new Byte[32 * 1024];
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read > 0)
                    {
                        mm.Write(buffer, 0, read);

                        System.Drawing.Image img = System.Drawing.Image.FromStream(mm);


                        return (JsonConvert.SerializeObject(new { listname = new[] { img.HorizontalResolution } }));

                    }
                    else { return null; }
                }
            }
            catch (Exception ex) { return null; }
        }
    }
}
