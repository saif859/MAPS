using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class SectionMasterNew : System.Web.UI.Page
    {
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
                if (Request["Code"] != null)
                {
                    var section = sMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtSectionName.Text = section.RANGEASST_ENAME;
                    txtMobile.Text = section.Mobileno;
                    txtSTD.Text = section.Std;
                    txtPhoneNo.Text = section.Phoneno;
                    txtFaxNo.Text = section.faxno;
                    //txtOfficerName.Text = section.OfficerName;

                    //------- Binding DDL's ----------
                    ddlZone.SelectedValue = section.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = section.mRANGE.mSUBDIV.mDIVISION.CIRCLE_ID.ToString();
                    ddlCircle_SelectedIndexChanged(ddlZone, null);
                    ddlDivision.SelectedValue = section.mRANGE.mSUBDIV.DIV_ID.ToString();
                    ddlDivision_SelectedIndexChanged(ddlZone, null);
                    ddlSubDivision.SelectedValue = section.mRANGE.SUBDIV_ID.ToString();
                    ddlSubDivision_SelectedIndexChanged(ddlZone, null);
                    ddlRange.SelectedValue = section.RANGE_ID.ToString();
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
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "S";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        sMethods.Add(section);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Section Created successfully.");

                    Response.Redirect("SectionMaster.aspx", false);
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
    }
}