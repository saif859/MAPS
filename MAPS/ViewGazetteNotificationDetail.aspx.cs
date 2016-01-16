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
    public partial class ViewGazetteNotificationDetail : System.Web.UI.Page
    {
        public DataTable dtItems = new DataTable();

        private ForestAreaMethods fMethods = new ForestAreaMethods();

        protected void BindForm()
        {
            int num = Convert.ToInt32(base.Server.HtmlEncode(base.Request.QueryString["Code"]));
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.ForestAreas.MergeOption = MergeOption.NoTracking;
                var variable = (
                    from b in defaultC.ForestAreas
                    orderby b.ForestName
                    select new { VillageId = b.VillageId, VillageName = b.Village.VillageName, ForestName = b.ForestName, ForestType = b.ForestType, Id = b.Id, NotificationNo = b.NotificationNo, NotificationType = b.NotificationType, GazetteDate = b.GazetteDate, GazetteNo = b.GazetteNo, GazetteAuthority = b.GazetteAuthority, GazetteTitle = b.GazetteTitle, PagesInHindi = b.PagesInHindi, PagesInEnglish = b.PagesInEnglish } into i
                    where i.Id == (long)num
                    select i).First();
                this.lblNotificationNumber.Text = variable.NotificationNo;
                this.lblNotificationType.Text = variable.NotificationType;
                if (variable.GazetteDate.HasValue)
                {
                    Label str = this.lblGazetteDate;
                    DateTime dateTime = DateTime.Parse(variable.GazetteDate.ToString());
                    str.Text = dateTime.ToString("dd/MM/yyyy");
                }
                this.lblGazetteNo.Text = variable.GazetteNo;
                this.lblGazetteAuthority.Text = variable.GazetteAuthority;
                this.lblGazetteTitle.Text = variable.GazetteTitle;
                if (variable.PagesInEnglish.HasValue)
                {
                    this.lblEnglishPage.Text = variable.PagesInEnglish.ToString();
                }
                if (variable.PagesInHindi.HasValue)
                {
                    this.lblHindiPage.Text = variable.PagesInHindi.ToString();
                }
                int.Parse(variable.VillageId.ToString());
                this.dtItems = (DataTable)this.ViewState["dtItems"];
                this.dtItems.Rows.Clear();
                List<GazetteDetail> list = (
                    from i in defaultC.GazetteDetails
                    where i.ForestAreaId == (long)num
                    select i).ToList<GazetteDetail>();
                if (list.Count > 0)
                {
                    foreach (GazetteDetail gazetteDetail in list)
                    {
                        DataRow id = this.dtItems.NewRow();
                        id["Id"] = gazetteDetail.Id;
                        id["Language"] = gazetteDetail.Language;
                        id["PageNumber"] = gazetteDetail.PageNo;
                        id["Photo"] = gazetteDetail.Photo;
                        id["Status"] = "U";
                        this.dtItems.Rows.Add(id);
                    }
                    this.dtItems.AcceptChanges();
                    this.ViewState["dtItems"] = this.dtItems;
                    this.BindGrid();
                }
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        private void BindGrid()
        {
            var list = ((DataTable)this.ViewState["dtItems"]).AsEnumerable().Where<DataRow>((DataRow c) => c["Status"].ToString() != "D").Select((DataRow c) => new { Id = c["Id"], PageNumber = c["PageNumber"], Language = c["Language"], Photo = c["Photo"], Status = c["Status"] }).ToList();
            this.gvShow.DataSource = list;
            this.gvShow.DataBind();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            this.dtItems = (DataTable)this.ViewState["dtItems"];
            Button button = (Button)sender;
            GridViewRow namingContainer = (GridViewRow)((Button)sender).NamingContainer;
            HiddenField hiddenField = (HiddenField)namingContainer.FindControl("hfPhoto");
            this.img.ImageUrl = string.Concat("MAP/", hiddenField.Value);
            try
            {
                FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(string.Concat("MAP/", hiddenField.Value)));
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
                HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(string.Concat("MAP/", hiddenField.Value));
                HttpContext.Current.Response.End();
            }
            catch (Exception exception)
            {
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            this.dtItems = (DataTable)this.ViewState["dtItems"];
            Button button = (Button)sender;
            GridViewRow namingContainer = (GridViewRow)((Button)sender).NamingContainer;
            HiddenField hiddenField = (HiddenField)namingContainer.FindControl("hfPhoto");
            this.img.ImageUrl = string.Concat("MAP/", hiddenField.Value);
        }

        protected void CreateTable()
        {
            this.dtItems.Rows.Clear();
            this.dtItems.Columns.Clear();
            this.dtItems.Columns.Add(new DataColumn("Id", Type.GetType("System.Int64")));
            this.dtItems.Columns.Add(new DataColumn("Language", Type.GetType("System.String")));
            this.dtItems.Columns.Add(new DataColumn("PageNumber", Type.GetType("System.String")));
            this.dtItems.Columns.Add(new DataColumn("Photo", Type.GetType("System.String")));
            this.dtItems.Columns.Add(new DataColumn("Status", Type.GetType("System.String")));
            this.dtItems.Columns.Add(new DataColumn("Edit", Type.GetType("System.String")));
            this.ViewState["dtItems"] = this.dtItems;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["User"] == null)
            {
                base.Response.Redirect("Logout.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CreateTable();
                if (base.Request.QueryString["Code"] != null)
                {
                    this.BindForm();
                }
            }
        }
    }
}