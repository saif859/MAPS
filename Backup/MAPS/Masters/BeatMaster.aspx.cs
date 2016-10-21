using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS.Masters
{
    public partial class BeatMaster : System.Web.UI.Page
    {
        BeatMethods bMethods = new BeatMethods();

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
                context.mBEATs.MergeOption = System.Data.Objects.MergeOption.NoTracking;

                var query = from data in context.mBEATs
                            orderby data.RASST_ID,data.BEAT_ENAME
                            select new { data.BEAT_ID, data.Mobileno,  data.Phoneno, data.Std, data.BEAT_ENAME , data.faxno, data.mRA.RANGEASST_ENAME };
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

            bMethods.Delete(id);

            js.ShowAlert(this, "Record deleted successfully!");
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton ib = (LinkButton)e.Row.Cells[8].Controls[0];
                Label lblid = (Label)e.Row.FindControl("lblId");
                ib.Attributes.Add("href", "BeatMasterNew.aspx?Code=" + lblid.Text + "");
            }
        }
    }
}