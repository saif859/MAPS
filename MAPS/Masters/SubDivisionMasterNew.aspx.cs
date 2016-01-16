using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class SubDivisionMasterNew : System.Web.UI.Page
    {
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
                if (Request["Code"] != null)
                {
                    var subDivision = sdMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtDivisionName.Text = subDivision.SUBDIV_ENAME;
                    txtMobile.Text = subDivision.Mobileno;
                    txtSTD.Text = subDivision.Std;
                    txtPhoneNo.Text = subDivision.Phoneno;
                    txtFaxNo.Text = subDivision.faxno;
                    txtOfficerName.Text = subDivision.officername;

                    ddlZone.SelectedValue = subDivision.mDIVISION.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = subDivision.mDIVISION.CIRCLE_ID.ToString();
                    ddlCircle_SelectedIndexChanged(ddlZone, null);
                    ddlDivision.SelectedValue = subDivision.DIV_ID.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mSUBDIV division = new mSUBDIV();
            division.SUBDIV_ENAME = txtDivisionName.Text.Trim();
            division.DIV_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            division.Mobileno = txtMobile.Text.Trim();

            division.officername = txtOfficerName.Text.Trim();
            division.Std = txtSTD.Text.Trim();
            division.Phoneno = txtPhoneNo.Text.Trim();
            division.faxno = txtFaxNo.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    division.SUBDIV_ID = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;
                    division.Lastupdatedon = DateTime.Now;

                    sdMethods.Update(division);
                    js.ShowAlert(this, "Sub Divsion Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;
                    division.UpdateOn = DateTime.Now;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "V";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        sdMethods.Add(division);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Sub Division Created successfully.");

                    Response.Redirect("SubDivisionMaster.aspx", false);
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
    }
}