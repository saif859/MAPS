using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SharpKml.Dom;
using System.Data;
using MAPS.Classes;
using SharpKml.Base;
using SharpKml.Engine;
using System.Text.RegularExpressions;

namespace MAPS
{
    public partial class ForestAreaNew : System.Web.UI.Page
    {
        BeatMethods btMethods = new BeatMethods();
        BlockMethods bMethods = new BlockMethods();
        SectionMethods sMethods = new SectionMethods();
        RangeMethods rMethods = new RangeMethods();
        DivisionMethods dMethods = new DivisionMethods();
        SubDivisionMethods sdMethods = new SubDivisionMethods();
        CircleMethods cMethods = new CircleMethods();
        ZoneMethods zMethods = new ZoneMethods();

        DistrictMethods districtMethods = new DistrictMethods();
        TehsilMethods tehsilMethods = new TehsilMethods();
        VillageMethods villageMethods = new VillageMethods();
        FieldAreaViewMethof Fm = new FieldAreaViewMethof();

        public static List<ForestCoordinate> queryCo = new List<ForestCoordinate>();
        public static string strCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Logout.aspx");
            if (!IsPostBack)
            {
                BindZone();
                BindDistrict();
                if (Request.QueryString["Code"] == null)
                {
                    strCode = new Random().Next(99999).ToString();


                    ddlZone_SelectedIndexChanged(null, null); ddlCircle_SelectedIndexChanged(null, null); ddlDivision_SelectedIndexChanged(null, null);
                    ddlSubDivision_SelectedIndexChanged(null, null); ddlRange_SelectedIndexChanged(null, null); ddlSection_SelectedIndexChanged(null, null);
                    ddlBeat_SelectedIndexChanged(null, null); ddlDistrict_SelectedIndexChanged(null, null); ddlTehsil_SelectedIndexChanged(null, null);
                }
                if (Request.QueryString["Code"] != null)
                {
                    strCode = Server.HtmlEncode(Request.QueryString["Code"]);
                    BindForm();
                }
            }
        }
        protected void BindForm()
        {
            var id = Convert.ToInt32(Server.HtmlEncode(Request.QueryString["Code"]));

            using (var db = new DefaultCS())
            {
                db.ForestAreas.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                var query = (from b in db.ForestAreas
                             orderby b.ForestName
                             select new
                             {
                                 b.BlockId,
                                 BeatId = b.Block.SectionId,
                                 SectionId = b.Block.mBEAT.RASST_ID,
                                 RangeId = b.Block.mBEAT.mRA.RANGE_ID,
                                 SubDivisionId = b.Block.mBEAT.mRA.mRANGE.SUBDIV_ID,
                                 DivisionId = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.DIV_ID,
                                 CircleId = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.CIRCLE_ID,
                                 ZoneId = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.WING_ID,
                                 b.VillageId,
                                 b.Village.TehsilId,
                                 b.Village.Tehsil.DistrictId,
                                 b.ForestName,
                                 b.ForestType,
                                 b.Id,
                                 b.NumberOfPillars,
                                 b.CadastralPoints,
                                 b.Village.VillageName,
                                 b.AreaCalculated,
                                 b.AreaInGazette,
                                 b.Block.BlockName,
                                 b.GazetteDate,
                                 b.GazetteNo,
                                 b.isReferencePoint,
                                 b.AreaInField,
                             }).Where(i => i.Id == id).First();

                ddlZone.SelectedValue = query.ZoneId.ToString();
                ddlZone_SelectedIndexChanged(null, null);

                ddlCircle.SelectedValue = query.CircleId.ToString();
                ddlCircle_SelectedIndexChanged(null, null);

                ddlDivision.SelectedValue = query.DivisionId.ToString();
                ddlDivision_SelectedIndexChanged(null, null);

                ddlSubDivision.SelectedValue = query.SubDivisionId.ToString();
                ddlSubDivision_SelectedIndexChanged(null, null);

                ddlRange.SelectedValue = query.RangeId.ToString();
                ddlRange_SelectedIndexChanged(null, null);

                ddlSection.SelectedValue = query.SectionId.ToString();
                ddlSection_SelectedIndexChanged(null, null);

                ddlBeat.SelectedValue = query.BeatId.ToString();
                ddlBeat_SelectedIndexChanged(null, null);

                ddlBlock.SelectedValue = query.BlockId.ToString();

                ddlDistrict.SelectedValue = query.DistrictId.ToString();
                ddlDistrict_SelectedIndexChanged(null, null);

                ddlTehsil.SelectedValue = query.TehsilId.ToString();
                ddlTehsil_SelectedIndexChanged(null, null);

                ddlVillage.SelectedValue = query.VillageId.ToString();
                ddlForestType.SelectedValue = query.ForestType;

                txtForestName.Text = query.ForestName;
                txtGazetteArea.Text = txtGazetteArea2.Text = query.AreaInGazette.ToString();
                if (query.GazetteDate != null)
                    txtGazetteDate.Text = Convert.ToDateTime(query.GazetteDate.ToString()).ToString("dd/MM/yyyy");
                txtGazetteNumber.Text = query.GazetteNo;
                txtNoPillar.Text = (Convert.ToInt32(query.NumberOfPillars) - 1).ToString();

                //txtTotalReference.Text = query.CadastralPoints.ToString();
                rdReference.Checked = (bool)query.isReferencePoint;

                areaM.Text = query.AreaCalculated.ToString();
                areaH.Text = Math.Round((decimal)(query.AreaCalculated ?? 0 / 10000), 2).ToString();
                areaA.Text = Math.Round((decimal)(query.AreaCalculated ?? 0 / (decimal)4046.86), 2).ToString();

                if (!string.IsNullOrEmpty(query.AreaInField.ToString()))
                {
                    areaMF.Text = query.AreaInField.ToString();
                } if (!string.IsNullOrEmpty(query.AreaInField.ToString()))
                {
                    areaHF.Text = Math.Round((decimal)(query.AreaInField / 10000), 2).ToString();
                }
                if (!string.IsNullOrEmpty(query.AreaInField.ToString()))
                {
                    areaAF.Text = Math.Round((decimal)(query.AreaInField / (decimal)4046.86), 2).ToString();
                }
                queryCo = (from c in db.ForestCoordinates where c.ForestAreaId == id select c).ToList();

                //------------- Images -----------------------
                #region Binding Images
                rptImages.DataSource = GetPhotos();
                rptImages.DataBind();

                #endregion
            }
        }

        protected void BindDistrict()
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.DataSource = districtMethods.GetAll();
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();

            ddlDistrict.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindTehsil()
        {
            ddlTehsil.Items.Clear();
            if (ddlDistrict.SelectedIndex > 0)
            {
                ddlTehsil.DataSource = tehsilMethods.GetAll(Convert.ToInt32(ddlDistrict.SelectedValue));
                ddlTehsil.DataTextField = "TehsilName";
                ddlTehsil.DataValueField = "Id";
                ddlTehsil.DataBind();
            }
            ddlTehsil.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindVillage()
        {
            ddlVillage.Items.Clear();
            if (ddlTehsil.SelectedIndex > 0)
            {
                try
                {
                    ddlVillage.DataSource = villageMethods.GetAll(Convert.ToInt32(ddlTehsil.SelectedValue));
                    ddlVillage.DataTextField = "VillageName";
                    ddlVillage.DataValueField = "Id";
                    ddlVillage.DataBind();
                }
                catch (Exception ex) { }
            }
            ddlVillage.Items.Insert(0, new ListItem("--Select--", "")); ddlVillage.Items.Insert(1, new ListItem("--Other--", "OT"));
        }
        protected void BindZone()
        {
            ddlZone.Items.Clear();
            ddlZone.DataSource = zMethods.GetAll();
            ddlZone.DataTextField = "Description";
            ddlZone.DataValueField = "WING_Id";
            ddlZone.DataBind();
            ddlZone.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindCircle()
        {
            ddlCircle.Items.Clear();
            if (ddlZone.SelectedIndex > 0)
            {
                ddlCircle.DataSource = cMethods.GetAll(Convert.ToInt32(ddlZone.SelectedValue));
                ddlCircle.DataTextField = "Circle_EName";
                ddlCircle.DataValueField = "Circle_Id";
                ddlCircle.DataBind();
            }
            ddlCircle.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindDivision()
        {
            ddlDivision.Items.Clear();
            if (ddlCircle.SelectedIndex > 0)
            {
                ddlDivision.DataSource = dMethods.GetAll(Convert.ToInt32(ddlCircle.SelectedValue));
                ddlDivision.DataTextField = "Div_EName";
                ddlDivision.DataValueField = "Div_Id";
                ddlDivision.DataBind();
            }
            ddlDivision.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindSubDivision()
        {
            ddlSubDivision.Items.Clear();
            if (ddlDivision.SelectedIndex > 0)
            {
                ddlSubDivision.DataSource = sdMethods.GetAll(Convert.ToInt32(ddlDivision.SelectedValue));
                ddlSubDivision.DataTextField = "SubDiv_EName";
                ddlSubDivision.DataValueField = "SubDiv_Id";
                ddlSubDivision.DataBind();
            }
            ddlSubDivision.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindRange()
        {
            ddlRange.Items.Clear();
            if (ddlSubDivision.SelectedIndex > 0)
            {
                ddlRange.DataSource = rMethods.GetAll(Convert.ToInt32(ddlSubDivision.SelectedValue));
                ddlRange.DataTextField = "Range_EName";
                ddlRange.DataValueField = "Range_Id";
                ddlRange.DataBind();
            }
            ddlRange.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void BindSection()
        {
            ddlSection.Items.Clear();
            if (ddlRange.SelectedIndex > 0)
            {
                ddlSection.DataSource = sMethods.GetAll(Convert.ToInt32(ddlRange.SelectedValue));
                ddlSection.DataTextField = "RANGEASST_ENAME";
                ddlSection.DataValueField = "RASST_ID";
                ddlSection.DataBind();
            }
            ddlSection.Items.Insert(0, new ListItem("--Select--", "s"));
        }
        protected void BindBeat()
        {
            ddlBeat.Items.Clear();
            if (ddlSection.SelectedIndex > 0)
            {
                ddlBeat.DataSource = btMethods.GetAll(Convert.ToInt64(ddlSection.SelectedValue));
                ddlBeat.DataTextField = "BEAT_ENAME";
                ddlBeat.DataValueField = "BEAT_ID";
                ddlBeat.DataBind();
            }
            ddlBeat.Items.Insert(0, new ListItem("--Select--", "s"));
        }
        protected void BindBlock()
        {
            ddlBlock.Items.Clear();
            if (ddlBeat.SelectedIndex > 0)
            {
                var ds = bMethods.GetAll(Convert.ToInt64(ddlBeat.SelectedValue));
                ddlBlock.DataSource = ds;
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataValueField = "Id";
                ddlBlock.DataBind();
                //if (ds.Count > 0)

            }
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "")); ddlBlock.Items.Insert(1, new ListItem("--Other--", "OT"));
        }
        protected void BindBlockByRange()
        {
            ddlBlock.Items.Clear();
            if (ddlRange.SelectedIndex > 0)
            {
                var ds = bMethods.GetAllByRange(Convert.ToInt64(ddlRange.SelectedValue));
                ddlBlock.DataSource = ds;
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataValueField = "Id";
                ddlBlock.DataBind();
                if (ds.Count > 0)
                    ddlBlock.Items.Insert(1, new ListItem("--Other--", "OT"));
            }
            ddlBlock.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCircle();
        }
        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDivision();
        }
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubDivision();
        }
        protected void ddlSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRange();
        }
        protected void ddlRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSection();
            BindBlockByRange();
        }
        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBeat();
        }
        protected void ddlBeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBlock();
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTehsil();
        }
        protected void ddlTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBlock.SelectedIndex == 1)
            {
                txtBlock.Visible = true;
            }
            else { txtBlock.Visible = false; }
        }

        protected void ddlVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVillage.SelectedIndex == 1)
            {
                txtVillage.Visible = true;
            }
            else { txtVillage.Visible = false; }
        }

        #region Image Handling

        public List<String> GetPhotos()
        {
            List<string> photos = new List<string>();
            string photoPath = MapPath("~/MAP");
            string[] files = Directory.GetFiles(photoPath, strCode + "_*");
            foreach (string photo in files)
            {
                photos.Add("MAP/" + Path.GetFileName(photo));
            }
            return photos;
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = ((LinkButton)(sender));
            string s = lb.CommandName;

            s = s.Substring(s.LastIndexOf('/') + 1);
            if (File.Exists(Server.MapPath("~") + "\\MAP\\" + s))
            {
                File.Delete(Server.MapPath("~") + "\\MAP\\" + s);
            }

            rptImages.DataSource = GetPhotos();
            rptImages.DataBind();
        }

        protected void fuImage_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            int max = AddImage();
            if (fuImage.HasFile)
            {
                string savePath = Server.MapPath("~") + "\\MAP\\" + strCode + "_" + String.Format("{0:00}", max.ToString("00")) + "_" + fuImage.FileName;
                System.Web.HttpPostedFile myFile = fuImage.PostedFile;
                if (myFile.ContentType.Contains("image"))
                {
                    //-------------- Image resolution check ---------------------- 
                    using (MemoryStream mm = new MemoryStream())
                    {
                        Byte[] buffer = new Byte[32 * 1024];
                        int read = fuImage.FileContent.Read(buffer, 0, buffer.Length);
                        if (read > 0)
                        {
                            mm.Write(buffer, 0, read);

                            System.Drawing.Image img = System.Drawing.Image.FromStream(mm);

                            if (img.HorizontalResolution > 100)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please upload image 100 dpi or less!');", true);
                                return;
                            }
                        }
                    }
                    //--------------------------------------------------------------

                    int nFileLen = myFile.ContentLength;
                    if (nFileLen > 0)
                    {
                        ResizeIamge.ResizeFromStream(savePath, 800, myFile.InputStream);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select a file more than 0kb!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select an image file!');", true);
                }
            }
            UpdatePanel1.Update();
        }

        protected void btnPhoto_Click(object sender, EventArgs e)
        {
            rptImages.DataSource = GetPhotos();
            rptImages.DataBind();

            UpdatePanel1.Update();
        }

        int AddImage()
        {
            string[] fils = Directory.GetFiles(Server.MapPath("~") + "\\MAP\\", strCode + "_*.jpg");

            int[] v_fileno = new int[100];
            int max = 0;
            int i = 0;
            foreach (string fil in fils)
            {
                string s = fil.Substring(fil.IndexOf('_') + 1, 2);
                v_fileno[i] = Convert.ToInt32(s);
                i++;
            }

            for (int j = 0; j < i; j++)
            {
                if (v_fileno[j] > v_fileno[j + 1])
                {
                    max = v_fileno[j];
                }
            }

            max = max + 1;
            return max;
        }

        protected void deleteRecords()
        {
            #region Delete Images if Uploaded

            string fromFile = "";
            string photoPath = MapPath("~/MAP");
            string[] files = Directory.GetFiles(photoPath, strCode + "_*");
            if (files.Length > 0)
            {
                foreach (string photo in files)
                {
                    fromFile = MapPath("~/MAP/") + Path.GetFileName(photo);
                    File.Delete(fromFile);
                }
            }

            #endregion
        }
        #endregion

        protected void btnKml_Click(object sender, EventArgs e)
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