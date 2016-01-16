using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Globalization;
using System.Data.Objects;
using MAPS.Classes;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System.IO;

namespace MAPS
{
    public partial class ForestAreaView2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Logout.aspx");
            if (!IsPostBack)
            {
                BindForm();
                BindGrid();
                GenerateKml();
            }
        }

        protected void BindForm()
        {
            string str;
            int num = Convert.ToInt32(base.Server.HtmlEncode(base.Request.QueryString["Code"]));
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.ForestAreas.MergeOption = MergeOption.NoTracking;
                var variable = (
                    from b in defaultC.ForestAreas
                    orderby b.ForestName
                    select new
                    {
                        Block = b.Block.BlockName,
                        BlockId = b.BlockId,
                        Division = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.DIV_ENAME,
                        Circle = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.CIRCLE_ENAME,
                        Zone = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.mWING.DESCRIPTION,
                        VillageId = b.VillageId,
                        VillageName = b.Village.VillageName,
                        ForestName = b.ForestName,
                        ForestType = b.ForestType,
                        Id = b.Id,
                    } into i
                    where i.Id == (long)num
                    select i).First();
                this.ViewState["blockId"] = variable.BlockId.ToString();
                this.ViewState["block"] = variable.Block.ToString();
                this.lblZone.Text = variable.Zone;
                this.lblCircle.Text = variable.Circle;
                this.lblDivision.Text = variable.Division;
                this.lblBlcok.Text = variable.Block;
                this.lblVillage.Text = variable.VillageName;
                Label label = this.lblForestType;
                if (variable.ForestType == "R")
                {
                    str = "Reserved";
                }
                else if (variable.ForestType == "U")
                {
                    str = "Protected";
                }
                else
                {
                    str = (variable.ForestType == "C" ? "Cadastral" : "Other");
                }
                label.Text = str;
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        private void BindGrid()
        {
            int num = Convert.ToInt32(base.Server.HtmlEncode(base.Request.QueryString["Code"]));

            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.CadastralPoints.MergeOption = MergeOption.NoTracking;

                var list = from c in defaultC.CadastralPoints
                           where c.ForestAreaId == num
                           select new { c.Id, c.Latitude, c.Longitude, c.PillarNo };
                this.GridView2.DataSource = list.ToList();
                this.GridView2.DataBind();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void GenerateKml()
        {
            var id = Convert.ToInt32(Server.HtmlEncode(Request.QueryString["Code"]));
            var document = new Document();
            document.Id = "Document";
            document.Name = "Document";

            Description dsc = new Description();
            dsc.Text = @"<h1>Car's Tracking</h1> ";

            CoordinateCollection coordinates = new CoordinateCollection();

            DataTable dt = new DataTable();

            try
            {
                DataSet ds = FieldAreaViewMethof.getfieldAreaValueCadastral(id);
                dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    double lon = double.Parse(ParseDMS(dr["Longitude"].ToString()).ToString());
                    double lat = double.Parse(ParseDMS(dr["Latitude"].ToString()).ToString());
                    coordinates.Add(new Vector(lat, lon, 0));
                }

                OuterBoundary outerBoundary = new OuterBoundary();
                outerBoundary.LinearRing = new LinearRing();
                outerBoundary.LinearRing.Coordinates = coordinates;

                // Polygon Setting:
                Polygon polygon = new Polygon();
                polygon.Extrude = true;
                polygon.AltitudeMode = AltitudeMode.ClampToGround;
                polygon.OuterBoundary = outerBoundary;

                //Color Style Setting:
                byte byte_Color_R = 150, byte_Color_G = 150, byte_Color_B = 150, byte_Color_A = 100; //you may get your own color by other method
                var style = new SharpKml.Dom.Style();

                style.Polygon = new PolygonStyle();
                style.Polygon.ColorMode = SharpKml.Dom.ColorMode.Normal;
                style.Polygon.Color = new Color32(byte_Color_A, byte_Color_B, byte_Color_G, byte_Color_R);

                //Set the polygon and style to the Placemark:
                Placemark placemark = new Placemark();
                placemark.Name = "Kukrail";
                placemark.Geometry = polygon;
                placemark.AddStyle(style);

                //Finally to the document and save it
                document.AddFeature(placemark);

                var kml = new Kml();
                kml.Feature = document;

                KmlFile kmlFile = KmlFile.Create(kml, true);
                if (File.Exists(Server.MapPath("~") + "MAP2.kml"))
                {
                    File.Delete(Server.MapPath("~") + "MAP2.kml");
                }
                using (var stream = System.IO.File.OpenWrite(Server.MapPath("~") + "MAP2.kml"))
                {
                    kmlFile.Save(stream);
                }

            }
            catch (Exception exc)
            {
                Response.Write(exc.Message);
            }
            finally
            {
            }
        }
        protected decimal ParseDMS(string CR)
        {
            string BACKUP = CR;
            string[] arr = { CR };
            if (CR.Contains(" "))
            {
                arr = CR.Split(' ');
            }
            else if (CR.Contains("°"))
            {
                CR = CR.Replace("'N", "");
                CR = CR.Replace("'S", "");
                CR = CR.Replace("'E", "");
                CR = CR.Replace("'W", "");
                arr = CR.Split('°');
            }
            decimal finaloutput = 0;
            if (arr.Length == 3)
            {
                finaloutput = (decimal.Parse(arr[0]) / 1) + (decimal.Parse(arr[1]) / 60) + (decimal.Parse(arr[2]) / 3600);
            }
            else if (arr.Length == 2)
            {
                finaloutput = (decimal.Parse(arr[0]) / 1) + (decimal.Parse(arr[1]) / 60);
            }
            else
            {
                finaloutput = decimal.Parse(arr[0]);
            }
            return Math.Round(finaloutput, 6);
        }
    }
}