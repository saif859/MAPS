using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Globalization;
using System.Data.Objects;

namespace MAPS
{
    public partial class DocumentDetail : System.Web.UI.Page
    {
        public DataTable dtItems = new DataTable();
        private ForestAreaMethods fMethods = new ForestAreaMethods();

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
                    select new { Block = b.Block.BlockName, BlockId = b.BlockId, Division = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.DIV_ENAME, Circle = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.CIRCLE_ENAME, Zone = b.Block.mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE.mWING.DESCRIPTION, VillageId = b.VillageId, VillageName = b.Village.VillageName, ForestName = b.ForestName, ForestType = b.ForestType, Id = b.Id, NotificationNo = b.NotificationNo, NotificationType = b.NotificationType, GazetteDate = b.GazetteDate, GazetteNo = b.GazetteNo, GazetteAuthority = b.GazetteAuthority, GazetteTitle = b.GazetteTitle, PagesInHindi = b.PagesInHindi, PagesInEnglish = b.PagesInEnglish } into i
                    where i.Id == (long)num
                    select i).First();
                this.ViewState["blockId"] = variable.BlockId.ToString();
                this.ViewState["block"] = variable.Block.ToString();
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
                this.txtNotificationNumber.Text = variable.NotificationNo;
                this.txtNotificationType.Text = variable.NotificationType;
                if (variable.GazetteDate.HasValue)
                {
                    TextBox textBox = this.txtGazetteDate;
                    DateTime dateTime = DateTime.Parse(variable.GazetteDate.ToString());
                    textBox.Text = dateTime.ToString("dd/MM/yyyy");
                }
                this.txtGazetteNo.Text = variable.GazetteNo;
                this.txtGazetteAuthority.Text = variable.GazetteAuthority;
                this.txtGazetteTitle.Text = variable.GazetteTitle;
                if (variable.PagesInEnglish.HasValue)
                {
                    this.txtEnglishPage.Text = variable.PagesInEnglish.ToString();
                }
                if (variable.PagesInHindi.HasValue)
                {
                    this.txtHindiPage.Text = variable.PagesInHindi.ToString();
                }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            DataRow dataRow;
            this.dtItems = (DataTable)this.ViewState["dtItems"];
            this.dtItems.Rows.Clear();
            if ((this.txtEnglishPage.Text.Trim() != "" ? false : !(this.txtHindiPage.Text.Trim() != "")))
            {
                js.ShowAlert(this, "Please enter english or hindi page numbers!");
            }
            else
            {
                int num = 0;
                if (this.txtHindiPage.Text.Trim() != "")
                {
                    num = Convert.ToInt32(this.txtHindiPage.Text.Trim());
                    for (i = 1; i <= num; i++)
                    {
                        dataRow = this.dtItems.NewRow();
                        dataRow["Id"] = i;
                        dataRow["Language"] = "H";
                        dataRow["Status"] = "C";
                        this.dtItems.Rows.Add(dataRow);
                    }
                    this.dtItems.AcceptChanges();
                }
                if (this.txtEnglishPage.Text.Trim() != "")
                {
                    num = Convert.ToInt32(this.txtEnglishPage.Text.Trim());
                    for (i = 1; i <= num; i++)
                    {
                        dataRow = this.dtItems.NewRow();
                        dataRow["Id"] = i;
                        dataRow["Language"] = "E";
                        dataRow["Status"] = "C";
                        this.dtItems.Rows.Add(dataRow);
                    }
                    this.dtItems.AcceptChanges();
                }
                this.ViewState["dtItems"] = this.dtItems;
                this.BindGrid();
            }
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] item = new object[] { "AddNewVillage.aspx?Code=", this.ViewState["blockId"], "&vCode=", this.ViewState["block"] };
            response.Redirect(string.Concat(item));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IFormatProvider cultureInfo = new CultureInfo("en-GB", true);
            long num = Convert.ToInt64(base.Server.HtmlEncode(base.Request.QueryString["Code"]));
            ForestArea forestArea = new ForestArea()
            {
                Id = num,
                NotificationNo = this.txtNotificationNumber.Text.Trim(),
                NotificationType = this.txtNotificationType.Text.Trim()
            };
            if (this.txtGazetteDate.Text.Trim() != "")
            {
                forestArea.GazetteDate = new DateTime?(DateTime.Parse(this.txtGazetteDate.Text.Trim(), cultureInfo));
            }
            forestArea.GazetteNo = this.txtGazetteNo.Text.Trim();
            forestArea.GazetteAuthority = this.txtGazetteAuthority.Text.Trim();
            forestArea.GazetteTitle = this.txtGazetteTitle.Text.Trim();
            if (this.txtEnglishPage.Text.Trim() != "")
            {
                forestArea.PagesInEnglish = new int?(Convert.ToInt32(this.txtEnglishPage.Text.Trim()));
            }
            if (this.txtHindiPage.Text.Trim() != "")
            {
                forestArea.PagesInHindi = new int?(Convert.ToInt32(this.txtHindiPage.Text.Trim()));
            }
            EntityCollection<GazetteDetail> gazetteDetails = new EntityCollection<GazetteDetail>();
            foreach (GridViewRow row in this.gvShow.Rows)
            {
                HiddenField hiddenField = (HiddenField)row.FindControl("hfLanguage");
                HiddenField hiddenField1 = (HiddenField)row.FindControl("hfPhoto");
                TextBox textBox = (TextBox)row.FindControl("txtPageNumber");
                FileUpload fileUpload = (FileUpload)row.FindControl("fuImage");
                GazetteDetail gazetteDetail = new GazetteDetail()
                {
                    ForestAreaId = num,
                    Language = hiddenField.Value
                };
                if (textBox.Text.Trim() != "")
                {
                    gazetteDetail.PageNo = new int?(Convert.ToInt32(textBox.Text.Trim()));
                }
                if (hiddenField1.Value != "")
                {
                    gazetteDetail.Photo = hiddenField1.Value;
                }
                if (fileUpload.HasFile)
                {
                    gazetteDetail.Photo = fileUpload.PostedFile.FileName;
                    string str = string.Concat(base.Server.MapPath("~"), "\\MAP\\", fileUpload.FileName);
                    HttpPostedFile postedFile = fileUpload.PostedFile;
                    if (postedFile.ContentLength > 0)
                    {
                        ResizeIamge.ResizeFromStream(str, 800, postedFile.InputStream);
                    }
                }
                gazetteDetails.Add(gazetteDetail);
            }
            this.fMethods.Update(forestArea, gazetteDetails);
            js.ShowAlert(this, "Gazette details updated sucessfully!");
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

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.dtItems = (DataTable)this.ViewState["dtItems"];
            ImageButton imageButton = (ImageButton)sender;
            GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
            HiddenField hiddenField = (HiddenField)namingContainer.FindControl("hfId");
            HiddenField hiddenField1 = (HiddenField)namingContainer.FindControl("hfLanguage");
            foreach (DataRow row in this.dtItems.Rows)
            {
                if ((row["Id"].ToString() != hiddenField.Value ? false : row["Language"].ToString() == hiddenField1.Value))
                {
                    row["Status"] = "D";
                    break;
                }
            }
            this.dtItems.AcceptChanges();
            this.ViewState["dtItems"] = this.dtItems;
            this.BindGrid();
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