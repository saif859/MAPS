using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Logout.aspx");
            if (!IsPostBack)
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text.Trim(), "MD5");
                LoginMaster loginMaster = (LoginMaster)(Session["User"]);
                if (oldPassword == loginMaster.Password)
                {
                    users.UpdateUser(loginMaster.UserId, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5"));

                    js.ShowAlert(this, "Password changed successfully.");
                }
                else
                {
                    js.ShowAlert(this, "Please enter correct old password.");
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