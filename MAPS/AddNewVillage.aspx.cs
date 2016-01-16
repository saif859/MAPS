using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
namespace MAPS
{
    public partial class AddNewVillage : System.Web.UI.Page
    {
        BlockMethods bMethods = new BlockMethods();
        DistrictMethods districtMethods = new DistrictMethods();
        VillageMethods vMethods = new VillageMethods();

        public AddNewVillage()
        {
        }

        protected void BindDistrict(DropDownList ddl)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                ddl.Items.Clear();
                ddl.DataSource = this.districtMethods.GetAll();
                ddl.DataTextField = "DistrictName";
                ddl.DataValueField = "Id";
                ddl.DataBind();
                ddl.Items.Insert(0, "--Select--");
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void BindGrid()
        {
            int num = int.Parse(base.Request["Code"]);
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.Tehsils.MergeOption = MergeOption.NoTracking;
                var villages =
                    from data in defaultC.Villages
                    orderby data.VillageName
                    where data.BlockId == (int?)num
                    select new { Id = data.Id, BlockId = (data.BlockId == null ? (int?)0 : data.BlockId), BlockName = data.Block.BlockName, VillageName = data.VillageName, TehsilName = data.Tehsil.TehsilName, DistrictId = data.Tehsil.DistrictId, TehsilId = data.TehsilId, DistrictName = data.Tehsil.District.DistrictName };
                this.GridView1.DataSource = villages.ToList();
                this.GridView1.DataBind();

                DropDownList dropDownList;
                if (villages.Count() > 0)
                {
                    dropDownList = (DropDownList)this.GridView1.FooterRow.FindControl("ddlDistrict");
                }
                else
                {
                    Table tbl = (Table)GridView1.Controls[0];
                    GridViewRow gvr = (GridViewRow)tbl.Controls[0];
                    TableCell cell = gvr.Cells[0];
                    dropDownList = (DropDownList)cell.FindControl("ddlDistrict");
                }
                this.BindDistrict(dropDownList);

            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void BindTehsil(int id, DropDownList ddl)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                ddl.DataSource = (
                    from i in defaultC.Tehsils
                    where i.DistrictId == id
                    select i).ToList<Tehsil>();
                ddl.DataBind();
                //ddl.Items.Insert(0, "--Select--");
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("AddKhasara.aspx");
        }

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = ((DropDownList)sender).NamingContainer as GridViewRow;
            this.BindDistrict(namingContainer.FindControl("ddlDistrict") as DropDownList);
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            DropDownList dropDownList1 = (dropDownList.NamingContainer as GridViewRow).FindControl("ddlTehsil") as DropDownList;
            this.BindTehsil(Convert.ToInt32(dropDownList.SelectedValue), dropDownList1);
        }

        protected void ddlDistrictt_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            DropDownList dropDownList1 = (dropDownList.NamingContainer as GridViewRow).FindControl("ddlTehsill") as DropDownList;
            this.BindTehsil(Convert.ToInt32(dropDownList.SelectedValue), dropDownList1);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType != DataControlRowType.DataRow ? false : e.Row.RowState == DataControlRowState.Edit))
            {
                HiddenField hiddenField = (HiddenField)e.Row.FindControl("lblTehsilId");
                DropDownList dropDownList = e.Row.FindControl("ddlDistrictt") as DropDownList;
                DropDownList dropDownList1 = e.Row.FindControl("ddlTehsil") as DropDownList;
                DropDownList dropDownList2 = e.Row.FindControl("ddlBlock") as DropDownList;
                DropDownList value = e.Row.FindControl("ddlTehsill") as DropDownList;
                this.BindTehsil(Convert.ToInt32(dropDownList.SelectedValue), value);
                value.SelectedValue = hiddenField.Value;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow item = this.GridView1.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)item.FindControl("lblId");
            int num = Convert.ToInt32(hiddenField.Value);
            try
            {
                this.vMethods.Delete(num);
                this.BindGrid();
                js.ShowAlert(this, "Record deleted succesfully!");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (!exception.InnerException.Message.Contains("REFERENCE"))
                {
                    js.ShowAlert(this, exception.Message);
                }
                else
                {
                    js.ShowAlert(this, "Record in use! Can not be  Deleted.");
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string text = ((TextBox)this.GridView1.Rows[rowIndex].FindControl("txtName")).Text;
            GridViewRow item = this.GridView1.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)item.FindControl("lblId");
            int num = Convert.ToInt32(hiddenField.Value);
            DropDownList dropDownList = item.FindControl("ddlTehsill") as DropDownList;
            int num1 = Convert.ToInt32(base.Request["Code"]);
            int num2 = Convert.ToInt32(dropDownList.SelectedValue);
            Village village = new Village()
            {
                Id = num,
                VillageName = text,
                BlockId = new int?(num1),
                TehsilId = num2
            };
            try
            {
                this.vMethods.Update(village);
                this.GridView1.EditIndex = -1;
                this.BindGrid();
                js.ShowAlert(this, "Record updated succesfully!");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (!exception.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, exception.Message);
                }
                else
                {
                    js.ShowAlert(this, "Record already exists! Please try another name.");
                }
            }
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
            string text = ((TextBox)namingContainer.FindControl("txtName")).Text;
            Convert.ToInt32(((DropDownList)namingContainer.FindControl("ddlDistrict")).SelectedValue);
            int num = Convert.ToInt32(((DropDownList)namingContainer.FindControl("ddlTehsil")).SelectedValue);
            Village village = new Village()
            {
                VillageName = text,
                TehsilId = num,
                BlockId = new int?(int.Parse(base.Request["Code"]))
            };
            try
            {
                this.vMethods.Add(village);
                this.BindGrid();
                js.ShowAlert(this, "Village created succesfully!");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (!exception.InnerException.InnerException.Message.Contains("UNIQUE"))
                {
                    js.ShowAlert(this, exception.Message);
                }
                else
                {
                    js.ShowAlert(this, "Village already exists! Please try another name.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["User"] == null)
            {
                base.Response.Redirect("Logout.aspx");
            }
            if (!base.IsPostBack)
            {
                this.BindGrid();
            }
        }
    }
}