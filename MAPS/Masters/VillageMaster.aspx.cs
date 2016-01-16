using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;

namespace MAPS.Masters
{
    public partial class VillageMaster : System.Web.UI.Page
    {
        VillageMethods vMethods = new VillageMethods();

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

                var query = from data in context.Villages
                            orderby data.VillageName
                            select new { data.Id, data.VillageName, data.Tehsil.TehsilName, data.Tehsil.DistrictId, data.TehsilId, data.Tehsil.District.DistrictName };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void BindTehsil(int id, DropDownList ddl)
        {
            using (DefaultCS db = new DefaultCS())
            {
                ddl.DataSource = db.Tehsils.Where(i => i.DistrictId == id).ToList();
                ddl.DataBind();
            }
        }
        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvr = ((GridViewRow)(((ImageButton)(sender)).NamingContainer));
            string name = ((TextBox)gvr.FindControl("txtName")).Text;
            int districtId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlDistrict")).SelectedValue);
            int tehsilId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlTehsil")).SelectedValue);

            Village fd = new Village();

            fd.VillageName = name;
            fd.TehsilId = tehsilId;

            try
            {
                vMethods.Add(fd);
                BindGrid();
                js.ShowAlert(this, "Village created succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, "Village already exists! Please try another name.");
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

            DropDownList ddlTehsil = row.FindControl("ddlTehsil") as DropDownList;


            int tehsilId = Convert.ToInt32(ddlTehsil.SelectedValue);

            Village fd = new Village();

            fd.Id = id;
            fd.VillageName = name;
            fd.TehsilId = tehsilId;

            try
            {
                vMethods.Update(fd);

                GridView1.EditIndex = -1;
                BindGrid();
                js.ShowAlert(this, "Record updated succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, "Village already exists! Please try another name.");
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
                vMethods.Delete(id);
                BindGrid();
                js.ShowAlert(this, "Record deleted succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    js.ShowAlert(this, "Village in use! Can not be  Deleted.");
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDistrict = (DropDownList)sender;
            GridViewRow gvr = ddlDistrict.NamingContainer as GridViewRow;

            DropDownList ddlTehsil = gvr.FindControl("ddlTehsil") as DropDownList;

            BindTehsil(Convert.ToInt32(ddlDistrict.SelectedValue), ddlTehsil);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
            {
                HiddenField lblTehsilId = (HiddenField)e.Row.FindControl("lblTehsilId");

                DropDownList ddlDistrict = e.Row.FindControl("ddlDistrict") as DropDownList;
                DropDownList ddlTehsil = e.Row.FindControl("ddlTehsil") as DropDownList;

                BindTehsil(Convert.ToInt32(ddlDistrict.SelectedValue), ddlTehsil);

                ddlTehsil.SelectedValue = lblTehsilId.Value;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindGrid();
        }
    }
}