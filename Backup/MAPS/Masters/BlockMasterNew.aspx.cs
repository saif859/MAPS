using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class BlockMasterNew : System.Web.UI.Page
    {
        BeatMethods btMethods = new BeatMethods();
        BlockMethods bMethods = new BlockMethods();
        SectionMethods sMethods = new SectionMethods();
        RangeMethods rMethods = new RangeMethods();
        SubDivisionMethods sdMethods = new SubDivisionMethods();
        DivisionMethods dMethods = new DivisionMethods();
        CircleMethods cMethods = new CircleMethods();
        ZoneMethods zMethods = new ZoneMethods();
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("../Logout.aspx");
            if (!IsPostBack)
            {
                BindZone();
                ddlZone_SelectedIndexChanged(ddlZone, null);
                ddlCircle_SelectedIndexChanged(ddlCircle, null);
                ddlDivision_SelectedIndexChanged(ddlDivision, null);
                ddlSubDivision_SelectedIndexChanged(ddlDivision, null);
                ddlRange_SelectedIndexChanged(ddlRange, null);
                ddlSection_SelectedIndexChanged(ddlSection, null);
                if (Request["Code"] != null)
                {
                    var block = bMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtBlockName.Text = block.BlockName;
                    txtMobile.Text = block.MobileNo;
                    txtSTD.Text = block.STD;
                    txtPhoneNo.Text = block.PhoneNo;
                    txtFaxNo.Text = block.FaxNo;
                    txtOfficerName.Text = block.OfficerName;

                    //------- Binding DDL's ----------
                    ddlZone.SelectedValue = block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.CIRCLE_ID.ToString();
                    ddlCircle_SelectedIndexChanged(ddlZone, null);
                    ddlDivision.SelectedValue = block.mBEAT.mRA.mRANGE.mSUBDIV.DIV_ID.ToString();
                    ddlDivision_SelectedIndexChanged(ddlZone, null);
                    ddlSubDivision.SelectedValue = block.mBEAT.mRA.mRANGE.SUBDIV_ID.ToString();
                    ddlSubDivision_SelectedIndexChanged(ddlZone, null);
                    ddlRange.SelectedValue = block.mBEAT.mRA.RANGE_ID.ToString();
                    ddlRange_SelectedIndexChanged(ddlRange, null);
                    ddlSection.SelectedValue = block.mBEAT.RASST_ID.ToString();
                    ddlSection_SelectedIndexChanged(ddlSection, null);

                    ddlBeat.SelectedValue = block.SectionId.ToString();
                }
            }
        }

        protected void BindZone()
        {
            ddlZone.DataSource = zMethods.GetAll();
            ddlZone.DataTextField = "Description";
            ddlZone.DataValueField = "Wing_Id";
            ddlZone.DataBind();
        }

        protected void BindCircle(int id)
        {
            ddlCircle.DataSource = cMethods.GetAll(id);
            ddlCircle.DataTextField = "Circle_EName";
            ddlCircle.DataValueField = "Circle_Id";
            ddlCircle.DataBind();
        }

        protected void BindDivision(int id)
        {
            ddlDivision.DataSource = dMethods.GetAll(id);
            ddlDivision.DataTextField = "DIV_EName";
            ddlDivision.DataValueField = "DIV_Id";
            ddlDivision.DataBind();
        }

        protected void BindSubDivision(int id)
        {
            ddlSubDivision.DataSource = sdMethods.GetAll(id);
            ddlSubDivision.DataTextField = "SUBDIV_ENAME";
            ddlSubDivision.DataValueField = "SUBDIV_Id";
            ddlSubDivision.DataBind();
        }

        protected void BindRange(int id)
        {
            ddlRange.DataSource = rMethods.GetAll(id);
            ddlRange.DataTextField = "Range_EName";
            ddlRange.DataValueField = "Range_Id";
            ddlRange.DataBind();
        }
        protected void BindSection(int id)
        {
            ddlSection.DataSource = sMethods.GetAll(id);
            ddlSection.DataTextField = "RANGEASST_ENAME";
            ddlSection.DataValueField = "RASST_ID";
            ddlSection.DataBind();
        }

        protected void BindBeat(long id)
        {
            ddlBeat.DataSource = btMethods.GetAll(id);
            ddlBeat.DataTextField = "BEAT_ENAME";
            ddlBeat.DataValueField = "BEAT_ID";
            ddlBeat.DataBind();

            ddlBeat.Items.Insert(0, new ListItem("", ""));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            Block block = new Block();
            block.BlockName = txtBlockName.Text.Trim();
            block.RangeId = Convert.ToInt32(ddlRange.SelectedValue);
            if (ddlBeat.SelectedIndex > 0)
                block.SectionId = Convert.ToInt32(ddlSection.SelectedValue);
            block.MobileNo = txtMobile.Text.Trim();

            block.OfficerName = txtOfficerName.Text.Trim();
            block.STD = txtSTD.Text.Trim();
            block.PhoneNo = txtPhoneNo.Text.Trim();
            block.FaxNo = txtFaxNo.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    block.Id = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;
                    block.UpdatedDate = DateTime.Now;

                    bMethods.Update(block);
                    js.ShowAlert(this, "Block Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;
                    block.CreatedDate = DateTime.Now;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "B";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        bMethods.Add(block);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Block Created successfully.");

                    Response.Redirect("BlockMaster.aspx", false);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, "Login already exists! Please try another one.");
                }
                else
                {
                    js.ShowAlert(this, ex.Message);
                }
            }
        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlZone.SelectedValue))
                BindCircle(Convert.ToInt32(ddlZone.SelectedValue));
        }

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCircle.SelectedValue))
                BindDivision(Convert.ToInt32(ddlCircle.SelectedValue));
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
                BindSubDivision(Convert.ToInt32(ddlDivision.SelectedValue));
        }

        protected void ddlSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSubDivision.SelectedValue))
                BindRange(Convert.ToInt32(ddlSubDivision.SelectedValue));
        }

        protected void ddlRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlRange.SelectedValue))
                BindSection(Convert.ToInt32(ddlRange.SelectedValue));
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSection.SelectedValue))
                BindBeat(Convert.ToInt32(ddlSection.SelectedValue));
        }
    }
}