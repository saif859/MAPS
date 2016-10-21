using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace MAPS.Masters
{
    public partial class ZoneMasterNew : System.Web.UI.Page
    {
        ZoneMethods zMethods = new ZoneMethods();
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("../Logout.aspx");
            if (!IsPostBack)
            {
                if (Request["Code"] != null)
                {
                    var zone = zMethods.Get(Convert.ToInt32(Server.HtmlEncode(Request["Code"]).ToString()));

                    txtZoneName.Text = zone.DESCRIPTION;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var _user = Session["User"] as EmployeeWithTypeBranch;

            mWING zone = new mWING();
            zone.DESCRIPTION = txtZoneName.Text.Trim();

            try
            {
                if (Request["Code"] != null)
                {
                    zone.WING_ID = Convert.ToByte(Server.HtmlEncode(Request["Code"]).ToString());

                    //zone.UpdatedBy = _user.employee.Id;

                    zMethods.Update(zone);
                    js.ShowAlert(this, "Zone Updated successfully.");
                }
                else
                {
                    //zone.CreatedBy = _user.employee.Id;

                    LoginMaster u = new LoginMaster();
                    u.UserId = txtLoginId.Text.Trim();
                    u.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                    u.Name = txtZoneName.Text.Trim();
                    u.Type = "Z";

                    using (TransactionScope scope = new TransactionScope())
                    {
                        zMethods.Add(zone);
                        users.Create(u);
                        scope.Complete();
                    }
                    js.ShowAlert(this, "Zone Created successfully.");

                    Response.Redirect("ZoneMaster.aspx", false);
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