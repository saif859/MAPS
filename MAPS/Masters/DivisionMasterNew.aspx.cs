using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class DivisionMasterNew : System.Web.UI.Page
    {
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
                if (Request["Code"] != null)
                {
                    int divId;
                    if (((MAPS.LoginMaster)Session["User"]).DistrictId != null)
                    {
                        divId = (int)((MAPS.LoginMaster)Session["User"]).DistrictId;
                    }
                    else
                    {
                        divId = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());
                    }

                    var division = dMethods.Get(divId);

                    txtDivisionName.Text = division.DIV_ENAME;
                    txtMobile.Text = division.Mobileno;
                    txtSTD.Text = division.Std;
                    txtPhoneNo.Text = division.Phoneno;
                    txtFaxNo.Text = division.faxno;
                    txtOfficerName.Text = division.officername;
                    txtInstrument.Text = division.NoOfInstrument.ToString();
                    txtModel.Text = division.InstrumentModel;

                    ddlZone.SelectedValue = division.mCIRCLE.WING_ID.ToString();
                    ddlZone_SelectedIndexChanged(ddlZone, null);
                    ddlCircle.SelectedValue = division.CIRCLE_ID.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mDIVISION division = new mDIVISION();
            division.DIV_ENAME = txtDivisionName.Text.Trim();
            division.CIRCLE_ID = Convert.ToInt32(ddlCircle.SelectedValue);
            division.Mobileno = txtMobile.Text.Trim();

            division.officername = txtOfficerName.Text.Trim();
            division.Std = txtSTD.Text.Trim();
            division.Phoneno = txtPhoneNo.Text.Trim();
            division.faxno = txtFaxNo.Text.Trim();

            division.NoOfInstrument = Convert.ToInt32(txtInstrument.Text.Trim());
            division.InstrumentModel = txtModel.Text.Trim();

            try
            {
                if (Request["Code"] != null || ((MAPS.LoginMaster)Session["User"]).DistrictId != null)
                {
                    if (((MAPS.LoginMaster)Session["User"]).DistrictId != null)
                    {
                        division.DIV_ID = (int)((MAPS.LoginMaster)Session["User"]).DistrictId;
                    }
                    else
                    {
                        division.DIV_ID = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());
                    }

                    division.Lastupdatedon = DateTime.Now;

                    dMethods.Update(division);
                    js.ShowAlert(this, "Divsion Updated successfully.");
                }
                else
                {
                    division.UpdateOn = DateTime.Now;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "D";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        dMethods.Add(division);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Division Created successfully.");

                    Response.Redirect("DivisionMaster.aspx", false);
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
    }
}