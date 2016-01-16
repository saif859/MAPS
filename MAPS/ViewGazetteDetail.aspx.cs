using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Net;
using System.IO;
using System.Data.Objects;

namespace MAPS
{
    public partial class ViewGazetteDetail : System.Web.UI.Page
    {
        public DataTable dtItems = new DataTable();
        private ForestAreaMethods fMethods = new ForestAreaMethods();
        decimal totalArea = 0, amalDaramadArea = 0;

        protected void BindForm()
        {
            string str;
            int num = Convert.ToInt32(base.Server.HtmlEncode(base.Request.QueryString["Code"]));
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.ForestAreas.MergeOption = MergeOption.NoTracking;
                var variable = (
                    from b in defaultC.ForestAreas
                    orderby b.ForestName
                    select new { Block = b.Block.BlockName, Division = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.DIV_ENAME, Circle = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.CIRCLE_ENAME, Zone = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.mWING.DESCRIPTION, BlockId = b.BlockId, VillageId = b.VillageId, VillageName = b.Village.VillageName, ForestName = b.ForestName, ForestType = b.ForestType, Id = b.Id, NotificationNo = b.NotificationNo, NotificationType = b.NotificationType, GazetteDate = b.GazetteDate, GazetteNo = b.GazetteNo, GazetteAuthority = b.GazetteAuthority, GazetteTitle = b.GazetteTitle, PagesInHindi = b.PagesInHindi, PagesInEnglish = b.PagesInEnglish } into i
                    where i.Id == (long)num
                    select i).First();
                this.lblZone.Text = variable.Zone;
                this.lblCircle.Text = variable.Circle;
                this.lblDivision.Text = variable.Division;
                this.lblBlcok.Text = variable.Block;
                this.lblVillage.Text = variable.VillageName;
                Label label = this.lblForestType;
                if (variable.ForestType == "R")
                {
                    str = "Reserved";
                }
                else if (variable.ForestType == "U")
                {
                    str = "Protected";
                }
                else
                {
                    str = (variable.ForestType == "C" ? "Cadastral" : "Other");
                }
                label.Text = str;
                this.lblNotificationNumber.Text = variable.NotificationNo;
                this.lblNotificationType.Text = variable.NotificationType;
                string str1 = "";
                if (variable.GazetteDate.HasValue)
                {
                    DateTime dateTime = DateTime.Parse(variable.GazetteDate.ToString());
                    str1 = dateTime.ToString("dd/MM/yyyy");
                }
                this.lnkViewGazette.Text = string.Concat(variable.NotificationNo, " on ", str1);
                this.lnkViewGazette.NavigateUrl = string.Concat("ViewGazetteNotificationDetail.aspx?Code=", base.Request["Code"]);
                this.BindVillage(variable.BlockId.Value);
                this.BindKhasara(variable.BlockId.Value);
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void BindKhasara(int blockID)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.KhasaraDetails.MergeOption = MergeOption.NoTracking;
                var khasaraDetails =
                    from data in defaultC.KhasaraDetails
                    orderby data.Id
                    where data.BlockId == (int?)blockID
                    select new
                    {
                        Id = data.Id,
                        KhasaraNo = data.KhasaraNo,
                        data.KhatauniNo,
                        OwnerName = data.OwnerName,
                        AreainAcres = data.AreainAcres,
                        VillageName = data.Village.VillageName,
                        data.AmalDaramadDate,
                        data.AmalDaramadNo
                    };

                totalArea = khasaraDetails.Sum(i => i.AreainAcres) ?? 0;
                amalDaramadArea = khasaraDetails.Where(i => i.AmalDaramadNo != null).Sum(i => i.AreainAcres) ?? 0;

                this.gvKhasara.DataSource = khasaraDetails.ToList();
                this.gvKhasara.DataBind();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        protected void BindVillage(int blockID)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.Villages.MergeOption = MergeOption.NoTracking;
                var villages =
                    from data in defaultC.Villages
                    orderby data.Id
                    where data.BlockId == (int?)blockID
                    select new { Id = data.Id, VillageName = data.VillageName };
                this.gvVillage.DataSource = villages.ToList();
                this.gvVillage.DataBind();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
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
                if (base.Request.QueryString["Code"] != null)
                {
                    this.BindForm();
                }
            }
        }

        protected void gvKhasara_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (!string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "AreainAcres").ToString()))
                //{
                //    totalArea += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AreainAcres"));


                //}
                //if (!string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "AmalDaramadNo").ToString()))
                //{
                //    amalDaramadArea += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AreainAcres"));
                //}
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblAreaAcres = (Label)e.Row.FindControl("lblAreaAcres");
                Label lblAmalDaramadArea = (Label)e.Row.FindControl("lblAmalDaramadArea");

                lblAreaAcres.Text = string.Format("{0:N2}", totalArea);
                lblAmalDaramadArea.Text = string.Format("{0:N2}", amalDaramadArea);
            }
        }
    }
}