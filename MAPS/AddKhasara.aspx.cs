using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using System.Globalization;

namespace MAPS
{
    public partial class AddKhasara : System.Web.UI.Page
    {
        BlockMethods bMethods = new BlockMethods();
        VillageMethods vMethods = new VillageMethods();
        KhasaraMethods kMethods = new KhasaraMethods();

        public AddKhasara()
        {
        }

        protected void BindGrid()
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                int num = Convert.ToInt32(base.Request["vCode"]);
                defaultC.KhasaraDetails.MergeOption = MergeOption.NoTracking;
                var khasaraDetails =
                    from data in defaultC.KhasaraDetails
                    where data.VillageId == (int?)num
                    orderby data.Id
                    select new
                    {
                        Id = data.Id,
                        KhasaraNo = data.KhasaraNo,
                        data.KhatauniNo,
                        BlockId = data.BlockId,
                        VillageId = data.VillageId,
                        OwnerName = data.OwnerName,
                        AreainAcres = data.AreainAcres,
                        data.AmalDaramadNo,
                        data.AmalDaramadDate
                    };
                this.GridView1.DataSource = khasaraDetails.ToList();
                this.GridView1.DataBind();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
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
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow item = this.GridView1.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)item.FindControl("lblId");
            int num = Convert.ToInt32(hiddenField.Value);
            try
            {
                this.kMethods.Delete(num);
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
                    js.ShowAlert(this, "Khasara in use! Can not be  Deleted.");
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
            IFormatProvider cultureInfo = new CultureInfo("en-GB", true);

            int rowIndex = e.RowIndex;
            string text = ((TextBox)this.GridView1.Rows[rowIndex].FindControl("txtKhasaraNo")).Text;
            string str = ((TextBox)this.GridView1.Rows[rowIndex].FindControl("txtOwnerName")).Text;
            string khatauniNo = ((TextBox)this.GridView1.Rows[rowIndex].FindControl("txtKhatauniNo")).Text;
            string text1 = ((TextBox)this.GridView1.Rows[rowIndex].FindControl("txtAreainAcres")).Text;
            GridViewRow item = this.GridView1.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)item.FindControl("lblId");
            int num = Convert.ToInt32(hiddenField.Value);
            int num1 = Convert.ToInt32(base.Request["Code"]);
            int num2 = Convert.ToInt32(base.Request["vCode"]);

            string amalDaramadNo = ((TextBox)GridView1.Rows[rowIndex].FindControl("txtAmalDaramadNo")).Text;
            string amalDaramadDate = ((TextBox)GridView1.Rows[rowIndex].FindControl("txtAmalDaramadDate")).Text;

            KhasaraDetail khasaraDetail = new KhasaraDetail()
            {
                Id = num,
                BlockId = new int?(num1),
                VillageId = new int?(num2),
                KhasaraNo = text,
                KhatauniNo=khatauniNo,
                OwnerName = str,
                AreainAcres = new decimal?(Convert.ToDecimal(text1)),
                AmalDaramadNo = amalDaramadNo
            };
            if (!string.IsNullOrEmpty(amalDaramadDate))
            {
                khasaraDetail.AmalDaramadDate = new DateTime?(DateTime.Parse(amalDaramadDate, cultureInfo));
            }
            try
            {
                this.kMethods.Update(khasaraDetail);
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
                    js.ShowAlert(this, "Khasara already exists! Please try another name.");
                }
            }
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            IFormatProvider cultureInfo = new CultureInfo("en-GB", true);
            GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
            string text = ((TextBox)namingContainer.FindControl("txtKhasaraNoF")).Text;
            string khatauniNo = ((TextBox)namingContainer.FindControl("txtKhatauniNoF")).Text;
            string str = ((TextBox)namingContainer.FindControl("txtOwnerNameF")).Text;
            decimal num = Convert.ToDecimal(((TextBox)namingContainer.FindControl("txtAreainAcresF")).Text);
            int num1 = Convert.ToInt32(base.Request["Code"]);
            int num2 = Convert.ToInt32(base.Request["vCode"]);

            string amalDaramadNo = ((TextBox)namingContainer.FindControl("txtAmalDaramadNoF")).Text;
            string amalDaramadDate = ((TextBox)namingContainer.FindControl("txtAmalDaramadDateF")).Text;

            KhasaraDetail khasaraDetail = new KhasaraDetail()
            {
                BlockId = new int?(num1),
                VillageId = new int?(num2),
                KhasaraNo = text,
                KhatauniNo=khatauniNo,
                OwnerName = str,
                AmalDaramadNo = amalDaramadNo,
                AreainAcres = new decimal?(num)
            };
            if (!string.IsNullOrEmpty(amalDaramadDate))
            {
                khasaraDetail.AmalDaramadDate = new DateTime?(DateTime.Parse(amalDaramadDate, cultureInfo));
            }
            try
            {
                this.kMethods.Add(khasaraDetail);
                this.BindGrid();
                js.ShowAlert(this, "Khasara created succesfully!");
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
                    js.ShowAlert(this, "Khasara already exists! Please try another name.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["User"] == null)
            {
                base.Response.Redirect("../Logout.aspx");
            }
            if (!base.IsPostBack)
            {
                this.BindGrid();
            }
        }
    }
}