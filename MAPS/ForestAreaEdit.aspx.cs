using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS
{
    public partial class ForestAreaEdit : System.Web.UI.Page
    {
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

        public List<ForestCoordinate> queryCo = new List<ForestCoordinate>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Logout.aspx");
            if (!IsPostBack)
            {
                BindZone();
                BindDistrict();
                ddlZone_SelectedIndexChanged(null, null); ddlCircle_SelectedIndexChanged(null, null); ddlDivision_SelectedIndexChanged(null, null);
                ddlSubDivision_SelectedIndexChanged(null, null); ddlRange_SelectedIndexChanged(null, null); ddlSection_SelectedIndexChanged(null, null);
                ddlDistrict_SelectedIndexChanged(null, null); ddlTehsil_SelectedIndexChanged(null, null);

                if (Request.QueryString["Code"] != null)
                {
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
                                 b.Block.SectionId,
                                 b.Block.Section.RangeId,
                                 SubDivisionId = b.Block.Section.mRANGE.SUBDIV_ID,
                                 DivisionId = b.Block.Section.mRANGE.mSUBDIV.DIV_ID,
                                 CircleId = b.Block.Section.mRANGE.mSUBDIV.mDIVISION.CIRCLE_ID,
                                 ZoneId = b.Block.Section.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.WING_ID,
                                 b.VillageId,
                                 b.Village.TehsilId,
                                 b.Village.Tehsil.DistrictId,
                                 b.ForestName,
                                 b.ForestType,
                                 b.Id,
                                 b.NumberOfPillars,
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

                ddlRange.SelectedValue = query.RangeId.ToString();
                ddlRange_SelectedIndexChanged(null, null);

                ddlSection.SelectedValue = query.SectionId.ToString();
                ddlSection_SelectedIndexChanged(null, null);

                ddlBlock.SelectedValue = query.BlockId.ToString();

                ddlDistrict.SelectedValue = query.DistrictId.ToString();
                ddlDistrict_SelectedIndexChanged(null, null);

                ddlTehsil.SelectedValue = query.TehsilId.ToString();
                ddlTehsil_SelectedIndexChanged(null, null);

                ddlVillage.SelectedValue = query.VillageId.ToString();
                ddlForestType.SelectedValue = query.ForestType;

                txtForestName.Text = query.ForestName;
                txtGazetteArea.Text = query.AreaInGazette.ToString();
                if (query.GazetteDate != null)
                    txtGazetteDate.Text = Convert.ToDateTime(query.GazetteDate.ToString()).ToString("dd/MM/yyyy");
                txtGazetteNumber.Text = query.GazetteNo;
                txtNoPillar.Text = (Convert.ToInt32(query.NumberOfPillars) - 1).ToString();

                areaM.Text = query.AreaCalculated.ToString();
                areaH.Text = Math.Round((decimal)(query.AreaCalculated / 10000), 2).ToString();
                areaA.Text = Math.Round((decimal)(query.AreaCalculated / (decimal)4046.86), 2).ToString();

                areaMF.Text = query.AreaInField.ToString();
                areaHF.Text = Math.Round((decimal)(query.AreaInField / 10000), 2).ToString();
                areaAF.Text = Math.Round((decimal)(query.AreaInField / (decimal)4046.86), 2).ToString();

                queryCo = (from c in db.ForestCoordinates where c.ForestAreaId == id select c).ToList();

                GridView1.DataSource = queryCo;
                GridView1.DataBind();
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
                ddlVillage.DataSource = villageMethods.GetAll(Convert.ToInt32(ddlTehsil.SelectedValue));
                ddlVillage.DataTextField = "VillageName";
                ddlVillage.DataValueField = "Id";
                ddlVillage.DataBind();
            }
            ddlVillage.Items.Insert(0, new ListItem("--Select--", ""));
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
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "Id";
                ddlSection.DataBind();
            }
            ddlSection.Items.Insert(0, new ListItem("--Select--", "s"));
        }
        protected void BindBlock()
        {
            ddlBlock.Items.Clear();
            if (ddlSection.SelectedIndex > 0)
            {
                var ds = bMethods.GetAll(Convert.ToInt32(ddlSection.SelectedValue));
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
                var ds = bMethods.GetAllByRange(Convert.ToInt32(ddlRange.SelectedValue));
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
    }
}