using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS
{
    public partial class ForestArea2 : System.Web.UI.Page
    {
        BeatMethods btMethods = new BeatMethods();
        ForestAreaMethods faMethods = new ForestAreaMethods();
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

        decimal totalArea = 0;
        int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Logout.aspx");
            if (!IsPostBack)
            {
                BindZone();
                BindDistrict();
                ddlZone_SelectedIndexChanged(null, null); ddlCircle_SelectedIndexChanged(null, null); ddlDivision_SelectedIndexChanged(null, null);
                ddlSubDivision_SelectedIndexChanged(null, null); ddlRange_SelectedIndexChanged(null, null); ddlSection_SelectedIndexChanged(null, null);
                ddlBeat_SelectedIndexChanged(null, null); ddlDistrict_SelectedIndexChanged(null, null); ddlTehsil_SelectedIndexChanged(null, null);
                BindGrid();

                if (((MAPS.LoginMaster)Session["User"]).DistrictId == null)
                {
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[10].Visible = false;
                }
            }
        }

        public void BindGrid()
        {
            using (DefaultCS db = new DefaultCS())
            {
                string forestType = null;
                long? zoneId = null, circleId = null, divisionId = null, subDivisionId = null, rangeId = null, sectionId = null, beatId = null, blockId = null, districtId = null, tehsilId = null, villageId = null;
                if (ddlZone.SelectedIndex > 0)
                    zoneId = Convert.ToInt64(ddlZone.SelectedValue);
                if (ddlCircle.SelectedIndex > 0)
                    circleId = Convert.ToInt64(ddlCircle.SelectedValue);
                if (ddlDivision.SelectedIndex > 0)
                    divisionId = Convert.ToInt64(ddlDivision.SelectedValue);
                if (ddlSubDivision.SelectedIndex > 0)
                    subDivisionId = Convert.ToInt64(ddlSubDivision.SelectedValue);
                if (ddlRange.SelectedIndex > 0)
                    rangeId = Convert.ToInt64(ddlRange.SelectedValue);
                if (ddlSection.SelectedIndex > 0)
                    sectionId = Convert.ToInt64(ddlSection.SelectedValue);
                if (ddlBeat.SelectedIndex > 0)
                    beatId = Convert.ToInt64(ddlBeat.SelectedValue);
                if (ddlBlock.SelectedIndex > 0)
                    blockId = Convert.ToInt64(ddlBlock.SelectedValue);

                if (ddlDistrict.SelectedIndex > 0)
                    districtId = Convert.ToInt64(ddlDistrict.SelectedValue);
                if (ddlTehsil.SelectedIndex > 0)
                    tehsilId = Convert.ToInt64(ddlTehsil.SelectedValue);
                if (ddlVillage.SelectedIndex > 0)
                    villageId = Convert.ToInt64(ddlVillage.SelectedValue);

                if (ddlForestType.SelectedIndex > 0)
                    forestType = ddlForestType.SelectedValue;

                db.ForestAreas.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                var query = (from b in db.ForestAreas
                             where b.ForestType != "R"
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
                                 b.Village.VillageName,
                                 //AreaCalculated = (b.AreaCalculated ?? 0) / (decimal)4046.86,//--- Convert to acre from sq. metere
                                 b.AreaInGazette,
                                 b.Block.BlockName
                             }).ToList().Select(i => new
                             {
                                 i.BlockId,
                                 i.BeatId,
                                 i.SectionId,
                                 i.RangeId,
                                 i.DivisionId,
                                 i.SubDivisionId,
                                 i.CircleId,
                                 i.ZoneId,
                                 i.VillageId,
                                 i.TehsilId,
                                 i.DistrictId,
                                 //AreaCalculated = Math.Round(i.AreaCalculated, 2),
                                 i.AreaInGazette,
                                 i.BlockName,
                                 i.ForestName,
                                 i.ForestType,
                                 i.Id,
                                 i.NumberOfPillars,
                                 i.VillageName
                             });

                if (zoneId != null)
                {
                    query = query.Where(i => i.ZoneId == zoneId);
                }
                if (circleId != null)
                {
                    query = query.Where(i => i.CircleId == circleId);
                }
                if (divisionId != null)
                {
                    query = query.Where(i => i.DivisionId == divisionId);
                }
                if (subDivisionId != null)
                {
                    query = query.Where(i => i.SubDivisionId == subDivisionId);
                }
                if (rangeId != null)
                {
                    query = query.Where(i => i.RangeId == rangeId);
                }
                if (sectionId != null)
                {
                    query = query.Where(i => i.SectionId == sectionId);
                }
                if (beatId != null)
                {
                    query = query.Where(i => i.BeatId == beatId);
                }
                if (blockId != null)
                {
                    query = query.Where(i => i.BlockId == blockId);
                }

                if (districtId != null)
                {
                    query = query.Where(i => i.DistrictId == districtId);
                }
                if (tehsilId != null)
                {
                    query = query.Where(i => i.TehsilId == tehsilId);
                }
                if (villageId != null)
                {
                    query = query.Where(i => i.VillageId == villageId);
                }
                if (forestType != null)
                {
                    query = query.Where(i => i.ForestType == forestType);
                }

                //totalArea = (decimal)query.Sum(i => i.AreaCalculated);
                total = query.Count();

                //Bind Data to Gridview
                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            HiddenField lblid = (HiddenField)row.FindControl("lblId");

            try
            {
                faMethods.Delete(Convert.ToInt32(lblid.Value));
                BindGrid();
                js.ShowAlert(this, "Record deleted successfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    js.ShowAlert(this, "Record in use!");
                }
                else
                {
                    js.ShowAlert(this, ex.Message);
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton ib = (LinkButton)e.Row.Cells[6].Controls[0];
                HiddenField lblid = (HiddenField)e.Row.FindControl("lblId");
                ib.Attributes.Add("href", "ForestAreaNew2.aspx?Code=" + lblid.Value + "");
            }
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            //    Label lblTotalArea = (Label)e.Row.FindControl("lblTotalArea");

            //    lblTotal.Text = total.ToString();
            //    lblTotalArea.Text = string.Format("{0:N2}", totalArea);
            //}
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindGrid();
        }


        protected void BindDistrict()
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.DataSource = districtMethods.GetAll();
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();

            ddlDistrict.Items.Insert(0, "ALL");
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
            ddlTehsil.Items.Insert(0, "ALL");
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
            ddlVillage.Items.Insert(0, "ALL");
        }
        protected void BindZone()
        {
            ddlZone.Items.Clear();
            ddlZone.DataSource = zMethods.GetAll();
            ddlZone.DataTextField = "Description";
            ddlZone.DataValueField = "WING_Id";
            ddlZone.DataBind();
            ddlZone.Items.Insert(0, "ALL");
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
            ddlCircle.Items.Insert(0, "ALL");
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
            ddlDivision.Items.Insert(0, "ALL");
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
            ddlSubDivision.Items.Insert(0, "ALL");
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
            ddlRange.Items.Insert(0, "ALL");
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
            ddlSection.Items.Insert(0, "ALL");
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
            ddlBeat.Items.Insert(0, "ALL");
        }
        protected void BindBlock()
        {
            ddlBlock.Items.Clear();
            if (ddlBeat.SelectedIndex > 0)
            {
                ddlBlock.DataSource = bMethods.GetAll(Convert.ToInt64(ddlBeat.SelectedValue));
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataValueField = "Id";
                ddlBlock.DataBind();
            }
            ddlBlock.Items.Insert(0, "ALL");
        }
        protected void BindBlockByRange()
        {
            ddlBlock.Items.Clear();
            if (ddlRange.SelectedIndex > 0)
            {
                ddlBlock.DataSource = bMethods.GetAllByRange(Convert.ToInt64(ddlRange.SelectedValue));
                ddlBlock.DataTextField = "BlockName";
                ddlBlock.DataValueField = "Id";
                ddlBlock.DataBind();
            }
            ddlBlock.Items.Insert(0, "ALL");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void imgview_click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (ImageButton)sender;
            GridViewRow gr = (GridViewRow)img.NamingContainer;
            HiddenField hf = (HiddenField)gr.FindControl("lblId");
            Response.Redirect("ForestAreaView2.aspx?Code=" + hf.Value + "");
        }
    }
}