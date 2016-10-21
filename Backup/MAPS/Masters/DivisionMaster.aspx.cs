using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAPS.Masters
{
    public partial class DivisionMaster : System.Web.UI.Page
    {
        DivisionMethods dMethods = new DivisionMethods();

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
                context.mDIVISIONs.MergeOption = System.Data.Objects.MergeOption.NoTracking;

                var query = from data in context.mDIVISIONs
                            orderby data.CIRCLE_ID, data.DIV_ENAME
                            select new { data.DIV_ID, data.Mobileno, data.officername, data.Phoneno, data.Std, data.DIV_ENAME, data.faxno, data.mCIRCLE.CIRCLE_ENAME, data.NoOfInstrument };

                if (((MAPS.LoginMaster)Session["User"]).DistrictId != null)
                {
                    int divId = (int)((MAPS.LoginMaster)Session["User"]).DistrictId;
                    GridView1.DataSource = query.Where(i => i.DIV_ID == divId).ToList();
                }
                else
                {
                    GridView1.DataSource = query.ToList();
                }
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblid = (Label)row.FindControl("lblId");

            int id = Convert.ToInt32(lblid.Text);

            dMethods.Delete(id);

            js.ShowAlert(this, "Record deleted successfully!");
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton ib = (LinkButton)e.Row.Cells[10].Controls[0];
                Label lblid = (Label)e.Row.FindControl("lblId");
                ib.Attributes.Add("href", "DivisionMasterNew.aspx?Code=" + lblid.Text + "");

                LinkButton ibDelete = (LinkButton)e.Row.Cells[11].Controls[0];
                if (((MAPS.LoginMaster)Session["User"]).DistrictId != null)
                { ibDelete.Visible = false; }
                else
                {
                    ibDelete.Visible = true;
                }
            }
        }
    }
}