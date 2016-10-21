<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site1.Master" AutoEventWireup="true" CodeBehind="GazetteDetailEntry.aspx.cs" Inherits="MAPS.GazetteDetailEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ptpl.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main Section-->
    <%--<asp:UpdatePanel ID="upGV" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="updateprogress112" runat="server" AssociatedUpdatePanelID="upGV">
                <ProgressTemplate>
                    <div class="UpdateProgressModalBackground">
                    </div>
                    <div class="UpdateProgressPanel">
                        <img src="images/Loading.gif" /><br />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
    <div class="mainSection">
        <h1>
            <span class="heading">Gazette Details</span></h1>
        <div class="butLink01">
            <asp:Button ID="btnClick" CssClass="button" runat="server" Text="Add Village Associated with this Block"
                OnClick="btnClick_Click" />
            <%--<a href="ForestAreaNew.aspx" class="button">Add forest Area</a>--%>
        </div>
        <div class="butLink02">
        </div>
        <div class="butLink03">
        </div>
    </div>
    <!--End Main Section--->
    <div class="perp">
        <div class="perp_sheetbg">
            <div class="perp_sheet perp_sheet_width">
                <table border="0" class="perp_group" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Zone</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblZone" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Circle</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblCircle" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Division</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblDivision" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Block</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblBlcok" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Village</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblVillage" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Forest Type</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblForestType" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Notification Number</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtNotificationNumber" MaxLength="50" runat="server"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Type of Notification</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtNotificationType" MaxLength="20" runat="server"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Gazette Date</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtGazetteDate" MaxLength="10" runat="server" CssClass="jDate" placeholde="dd/MM/yyyy"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Gazette Number</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtGazetteNo" MaxLength="25" runat="server"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Gazette Authority</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtGazetteAuthority" MaxLength="50" runat="server"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Gazette Title</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtGazetteTitle" MaxLength="50" runat="server"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Pages in English Edition</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtEnglishPage" MaxLength="2" runat="server" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Pages in Hindi Edition</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtHindiPage" MaxLength="2" runat="server" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Add Photos" OnClick="btnAdd_Click" /></label>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td colspan="6" align="right">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div id="hubData" class="tableContainer">
                    <asp:GridView ID="gvShow" runat="server" Width="100%" EmptyDataText="No Records to Display."
                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                        <AlternatingRowStyle CssClass="alt" />
                        <SelectedRowStyle CssClass="selected" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %><asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hfLanguage" runat="server" Value='<%# Eval("Language") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hfPhoto" runat="server" Value='<%# Eval("Photo") %>'></asp:HiddenField>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gazette Page Number">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPageNumber" runat="server" onkeypress="return OnlyNumber(event);"
                                        Text='<%#Eval("PageNumber") %>' MaxLength="6"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Language">
                                <ItemTemplate>
                                    <%#Eval("Language").ToString()=="H"?"Hindi":"English" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload Gazette Copy">
                                <ItemTemplate>
                                    <asp:FileUpload ID="fuImage" runat="server" />
                                    <a href='MAP/<%#Eval("Photo") %>' target="_blank">
                                        <%#Eval("Photo") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="align_center header">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibDelete" runat="server" CausesValidation="false" OnClick="ImageButton1_Click"
                                        ImageUrl="images/btn_iconDelete.gif" ToolTip="Delete" OnClientClick="return Confirm('Are you sure you want to delete this record?');" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
                <div class="butLink03">
                    <asp:Button ID="btnSave" CssClass="sa_highlight" runat="server" Text="Save" OnClientClick="$('#form1').valid();"
                        OnClick="btnSave_Click" />
                    <span class="sa_fade">or</span> <a accesskey="D" class="sa_bold perp_button_cancel"
                        href="ForestArea.aspx">Discard</a>
                </div>
                <br />
                <br />
                <%--<a accesskey="D" class="sa_bold perp_button_cancel"
                        href="AddNewVillage.aspx">Villages Associated with&nbsp; this Block</a>--%>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>