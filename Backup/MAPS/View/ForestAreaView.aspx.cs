using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAPS.Classes;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;

namespace MAPS.View
{
    public partial class ForestAreaView : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        FieldAreaViewMethof Fm = new FieldAreaViewMethof();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridSecond();
                GenerateKml();
            }
        }

        public void BindGridSecond()
        {
            int ids = Convert.ToInt32(Request.QueryString["Code"]);
            ds = FieldAreaViewMethof.getfieldAreaValue(ids);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            string isreference = ds.Tables[0].Rows[0]["isReferencePoint"].ToString();
            if (isreference == "True")
            {
                GridView2.Rows[0].Visible = false;
            }

            lblAreaGaz.Text = ds.Tables[0].Rows[0]["AreaInGazette"].ToString();
            lblGazNo.Text = ds.Tables[0].Rows[0]["GazetteNo"].ToString();
            lblGazDate.Text = ds.Tables[0].Rows[0]["GazetteDate"].ToString();
            lblComptedArea.Text = ds.Tables[0].Rows[0]["Ac"].ToString();
            lblComptedAreaS.Text = ds.Tables[0].Rows[0]["Af"].ToString();
            lblComutedAreaF.Text = ds.Tables[0].Rows[0]["Cf"].ToString();
            lblComputedAreaHf.Text = ds.Tables[0].Rows[0]["CfA"].ToString();
            lblBlock.Text = ds.Tables[0].Rows[0]["BlockName"].ToString();
            lblVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
            txtNoPillar.Text = ds.Tables[0].Rows[0]["NumberOfPillars"].ToString();

        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.ToString("MM-dd-yyyy");


            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Maps.xls"));
            Response.Charset = "''";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView2.AllowPaging = false;
            GridView2.DataBind();

            GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF");

            GridView2.HeaderRow.Cells[0].Style.Add("width", "5px");
            GridView2.HeaderRow.Cells[0].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[1].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[2].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[3].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[4].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[5].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[6].Style.Add("background-color", "#CCCCCC");
            GridView2.HeaderRow.Cells[7].Style.Add("background-color", "#CCCCCC");

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridViewRow row = GridView2.Rows[i];

                row.BackColor = System.Drawing.Color.White;

                row.Attributes.Add("class", "texmode");

                if (i % 2 != 0)
                {
                    row.Cells[0].Style.Add("width", "10px");
                    row.Cells[0].Style.Add("background-color", "#f0f0f0");
                    row.Cells[1].Style.Add("background-color", "#f0f0f0");
                    row.Cells[2].Style.Add("background-color", "#f0f0f0");
                    row.Cells[3].Style.Add("background-color", "#f0f0f0");
                    row.Cells[4].Style.Add("background-color", "#f0f0f0");
                    row.Cells[5].Style.Add("background-color", "#f0f0f0");
                    row.Cells[6].Style.Add("background-color", "#f0f0f0");
                    row.Cells[7].Style.Add("background-color", "#f0f0f0");
                }
            }

            GridView2.Width = 200;
            PnlView.RenderControl(hw);
            //GridView2.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

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
                DataSet ds = FieldAreaViewMethof.getfieldAreaValue(id);
                dt = ds.Tables[0];

                string isreference = ds.Tables[0].Rows[0]["isReferencePoint"].ToString();
                if (isreference == "True")
                {
                    dt.Rows[0].Delete();
                }

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
                if (File.Exists(Server.MapPath("~") + "MAP.kml"))
                {
                    File.Delete(Server.MapPath("~") + "MAP.kml");
                }
                using (var stream = System.IO.File.OpenWrite(Server.MapPath("~") + "MAP.kml"))
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