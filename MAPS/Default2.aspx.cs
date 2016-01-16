using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace MAPS
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Int64 InsertArea(ForestArea forestArea)
        {
            using (var db = new DefaultCS())
            {
                db.ForestAreas.AddObject(forestArea);
                db.SaveChanges();
            }
            return forestArea.Id;
        }

        [WebMethod]
        public static string InsertCoordinates(ForestCoordinate forestCoordinates)
        {
            using (var db = new DefaultCS())
            {
                db.ForestCoordinates.AddObject(forestCoordinates);
                db.SaveChanges();
            }
            return "true";
        }
    }
}