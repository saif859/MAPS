using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class CircleMasterNew : System.Web.UI.Page
    {
        CircleMethods cMethods = new CircleMethods();
        ZoneMethods zMethods = new ZoneMethods();
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("../Logout.aspx");
            if (!IsPostBack)
            {
                BindZone();
                if (Request["Code"] != null)
                {
                    var circle = cMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtCircleName.Text = circle.CIRCLE_ENAME;
                    txtMobile.Text = circle.Mobileno;
                    txtSTD.Text = circle.Std;
                    txtPhoneNo.Text = circle.Phoneno;
                    txtFaxNo.Text = circle.faxno;
                    txtOfficerName.Text = circle.officername;

                    ddlZone.SelectedValue = circle.WING_ID.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mCIRCLE circle = new mCIRCLE();
            circle.CIRCLE_ENAME = txtCircleName.Text.Trim();
            circle.WING_ID = Convert.ToByte(ddlZone.SelectedValue);
            circle.Mobileno = txtMobile.Text.Trim();

            circle.officername = txtOfficerName.Text.Trim();
            circle.Std = txtSTD.Text.Trim();
            circle.Phoneno = txtPhoneNo.Text.Trim();
            circle.faxno = txtFaxNo.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    circle.CIRCLE_ID = Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;
                    circle.Lastupdatedon = DateTime.Now;

                    cMethods.Update(circle);
                    js.ShowAlert(this, "Circle Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;
                    circle.UpdateOn = DateTime.Now;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtOfficerName.Text.Trim();
                    u.Type = "C";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        cMethods.Add(circle);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Circle Created successfully.");

                    Response.Redirect("CircleMaster.aspx", false);
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
    }
}