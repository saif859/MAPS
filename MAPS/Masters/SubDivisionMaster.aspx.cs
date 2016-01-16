using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS.Masters
{
    public partial class SubDivisionMaster : System.Web.UI.Page
    {
        SubDivisionMethods sdMethods = new SubDivisionMethods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("../Logout.aspx");
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            using (DefaultCS context = new DefaultCS())
            {
                context.mSUBDIVs.MergeOption = System.Data.Objects.MergeOption.NoTracking;

                var query = from data in context.mSUBDIVs
                            orderby data.DIV_ID, data.SUBDIV_ENAME
                            select new { data.SUBDIV_ID, data.Mobileno, data.officername, data.Phoneno, data.Std, data.SUBDIV_ENAME, data.faxno, data.mDIVISION.DIV_ENAME };

                //Bind Data to Gridview
                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblid = (Label)row.FindControl("lblId");

            int id = Convert.ToInt32(lblid.Text);

            sdMethods.Delete(id);

            js.ShowAlert(this, "Record deleted successfully!");
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton ib = (LinkButton)e.Row.Cells[9].Controls[0];
                Label lblid = (Label)e.Row.FindControl("lblId");
                ib.Attributes.Add("href", "DivisionMasterNew.aspx?Code=" + lblid.Text + "");
            }
        }
    }
}