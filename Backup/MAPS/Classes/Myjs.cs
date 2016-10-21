using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Drawing.Imaging;
using System.Drawing;

namespace MAPS
{
    public class js
    {
        public static void ShowAlert(Page page, string message)
        {
            string cleanMessage = message.Replace("'", " ");
            string win = string.Format("jQueryAlert('" + cleanMessage + "');", "");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "nothing", win, true);
        }

        public static void ShowAlert(Control page, string message)
        {
            string cleanMessage = message.Replace("'", " ");
            string win = string.Format("jQueryAlert('" + cleanMessage + "');", "");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "nothing", win, true);
        }
    }

    public static class ResizeIamge
    {
        public static void ResizeFromStream(string ImageSavePath, int MaxSideSize, System.IO.Stream Buffer)
        {
            int intNewWidth;
            int intNewHeight;
            System.Drawing.Image imgInput = System.Drawing.Image.FromStream(Buffer);

            //Determine image format
            ImageFormat fmtImageFormat = imgInput.RawFormat;

            //get image original width and height
            int intOldWidth = imgInput.Width;
            int intOldHeight = imgInput.Height;

            //determine if landscape or portrait
            int intMaxSide;

            if (intOldWidth >= intOldHeight)
            {
                intMaxSide = intOldWidth;
            }
            else
            {
                intMaxSide = intOldHeight;
            }


            if (intMaxSide > MaxSideSize)
            {
                //set new width and height
                double dblCoef = MaxSideSize / (double)intMaxSide;
                intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
            }
            else
            {
                intNewWidth = intOldWidth;
                intNewHeight = intOldHeight;
            }
            //create new bitmap
            Bitmap bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);

            //save bitmap to disk
            bmpResized.Save(ImageSavePath, fmtImageFormat);

            //release used resources
            imgInput.Dispose();
            bmpResized.Dispose();
            Buffer.Close();
        }
    }
}
