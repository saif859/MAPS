using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS
{
    public partial class Default : System.Web.UI.Page
    {
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = users.GetUser(txtUserName.Text.Trim(), System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5"));
                if (emp != null)
                {
                    Session.Add("User", emp);
                    Response.Redirect("ForestArea.aspx");
                }
                else
                {
                    js.ShowAlert(this, "Please enter correct username /password.");
                }
            }
            catch (Exception ex)
            {
                js.ShowAlert(this, ex.Message);
            }
        }
    }
}