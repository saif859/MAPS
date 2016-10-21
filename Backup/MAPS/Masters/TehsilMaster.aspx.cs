using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;

namespace MAPS.Masters
{
    public partial class TehsilMaster : System.Web.UI.Page
    {
        TehsilMethods tMethods = new TehsilMethods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("../Logout.aspx");
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            using (DefaultCS context = new DefaultCS())
            {
                context.Tehsils.MergeOption = MergeOption.NoTracking;

                var query = from data in context.Tehsils
                            orderby data.DistrictId, data.TehsilName
                            select new { data.Id, data.TehsilName, data.District.DistrictName, data.DistrictId };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvr = ((GridViewRow)(((ImageButton)(sender)).NamingContainer));
            string name = ((TextBox)gvr.FindControl("txtName")).Text;
            int districtId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlDistrict")).SelectedValue);

            Tehsil fd = new Tehsil();

            fd.TehsilName = name;
            fd.DistrictId = districtId;

            try
            {
                tMethods.Add(fd);
                BindGrid();
                js.ShowAlert(this, "Tehsil created succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, "Tehsil already exists! Please try another name.");
                }
                else
                {
                    js.ShowAlert(this, ex.Message);
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int gvr = e.RowIndex;

            string name = ((TextBox)GridView1.Rows[gvr].FindControl("txtName")).Text;

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            HiddenField lblid = (HiddenField)row.FindControl("lblId");
            int id = Convert.ToInt32(lblid.Value);
            int districtId = Convert.ToInt32(((DropDownList)row.FindControl("ddlDistrict")).SelectedValue);

            Tehsil fd = new Tehsil();

            fd.Id = id;
            fd.TehsilName = name;
            fd.DistrictId = districtId;

            try
            {
                tMethods.Update(fd);

                GridView1.EditIndex = -1;
                BindGrid();
                js.ShowAlert(this, "Record updated succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, "Tehsil already exists! Please try another name.");
                }
                else
                {
                    js.ShowAlert(this, ex.Message);
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            HiddenField lblid = (HiddenField)row.FindControl("lblId");
            int id = Convert.ToInt32(lblid.Value);
            try
            {
                tMethods.Delete(id);
                BindGrid();
                js.ShowAlert(this, "Record deleted succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    js.ShowAlert(this, "Tehsil in use! Can not be  Deleted.");
                }
                else
                {
                    js.ShowAlert(this, ex.Message);
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindGrid();
        }
    }
}