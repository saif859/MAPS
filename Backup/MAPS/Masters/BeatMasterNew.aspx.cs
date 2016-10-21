using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class BeatMasterNew : System.Web.UI.Page
    {
        BeatMethods bMethods = new BeatMethods();
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
                if (Request["Code"] != null)
                {
                    var beat = bMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtSectionName.Text = beat.BEAT_ENAME;
                    txtMobile.Text = beat.Mobileno;
                    txtSTD.Text = beat.Std;
                    txtPhoneNo.Text = beat.Phoneno;
                    txtFaxNo.Text = beat.faxno;
                    //txtOfficerName.Text = section.OfficerName;

                    //------- Binding DDL's ----------
                    ddlZone.SelectedValue = beat.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = beat.mRA.mRANGE.mSUBDIV.mDIVISION.CIRCLE_ID.ToString();
                    ddlCircle_SelectedIndexChanged(ddlZone, null);
                    ddlDivision.SelectedValue = beat.mRA.mRANGE.mSUBDIV.DIV_ID.ToString();
                    ddlDivision_SelectedIndexChanged(ddlZone, null);
                    ddlSubDivision.SelectedValue = beat.mRA.mRANGE.SUBDIV_ID.ToString();
                    ddlSubDivision_SelectedIndexChanged(ddlZone, null);
                    ddlRange.SelectedValue = beat.mRA.RANGE_ID.ToString();
                    ddlRange_SelectedIndexChanged(ddlRange, null);
                    ddlSection.SelectedValue = beat.RASST_ID.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mRA section = new mRA();
            section.RANGEASST_ENAME = txtSectionName.Text.Trim();
            section.RANGE_ID = Convert.ToInt32(ddlRange.SelectedValue);
            section.Mobileno = txtMobile.Text.Trim();

            //section.OfficerName = txtOfficerName.Text.Trim();
            section.Std = txtSTD.Text.Trim();
            section.Phoneno = txtPhoneNo.Text.Trim();
            section.faxno = txtFaxNo.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    section.RASST_ID = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;
                    section.UpdateOn = DateTime.Now;

                    sMethods.Update(section);
                    js.ShowAlert(this, "Section Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtLoginId.Text.Trim();
                    u.Type = "E";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        sMethods.Add(section);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Beat Created successfully.");

                    Response.Redirect("BeatMaster.aspx", false);
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
    }
}