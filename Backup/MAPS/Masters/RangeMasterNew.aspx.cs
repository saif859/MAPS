using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class RangeMasterNew : System.Web.UI.Page
    {
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
                ddlDivision_SelectedIndexChanged(ddlCircle, null);
                if (Request["Code"] != null)
                {
                    var range = rMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtRangeName.Text = range.RANGE_ENAME;
                    txtMobile.Text = range.Mobileno;
                    txtSTD.Text = range.Std;
                    txtPhoneNo.Text = range.Phoneno;
                    txtFaxNo.Text = range.faxno;
                    txtOfficerName.Text = range.officername;

                    //------- Binding DDL's ----------
                    ddlZone.SelectedValue = range.mSUBDIV.mDIVISION.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = range.mSUBDIV.mDIVISION.CIRCLE_ID.ToString();
                    ddlCircle_SelectedIndexChanged(ddlZone, null);
                    ddlDivision.SelectedValue = range.mSUBDIV.DIV_ID.ToString();
                    ddlDivision_SelectedIndexChanged(ddlZone, null);
                    ddlSubDivision.SelectedValue = range.SUBDIV_ID.ToString();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mRANGE range = new mRANGE();
            range.RANGE_ENAME = txtRangeName.Text.Trim();
            range.SUBDIV_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            range.Mobileno = txtMobile.Text.Trim();

            range.officername = txtOfficerName.Text.Trim();
            range.Std = txtSTD.Text.Trim();
            range.Phoneno = txtPhoneNo.Text.Trim();
            range.faxno = txtFaxNo.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    range.RANGE_ID = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;
                    range.Lastupdatedon = DateTime.Now;

                    rMethods.Update(range);
                    js.ShowAlert(this, "Range Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;
                    range.UpdateOn = DateTime.Now;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "R";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        rMethods.Add(range);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Range Created successfully.");

                    Response.Redirect("RangeMaster.aspx", false);
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
    }
}