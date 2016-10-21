<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="ViewGazetteNotificationDetail.aspx.cs" Inherits="MAPS.View.ViewGazetteNotificationDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <span class="heading">राजपत्र विवरण</span></h1>
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
                                    अधिसूचना संख्या</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblNotificationNumber" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    अधिसूचना का प्रकार</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblNotificationType" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    राजपत्र दिनांक</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblGazetteDate" runat="server" CssClass="jDate"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    राजपत्र संख्या</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblGazetteNo" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    राजपत्र प्राधिकरण</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblGazetteAuthority" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    राजपत्र शीर्षक</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblGazetteTitle" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    अंग्रेजी संस्करण में पृष्ठों की संख्या</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblEnglishPage" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    हिंदी संस्करण में पृष्ठों की संख्या</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblHindiPage" runat="server"></asp:Label>
                                </span>
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
                            <asp:TemplateField HeaderText="क्र० स०">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %><asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hfLanguage" runat="server" Value='<%# Eval("Language") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hfPhoto" runat="server" Value='<%# Eval("Photo") %>'></asp:HiddenField>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="राजपत्र पृष्ठ संख्या">
                                <ItemTemplate>
                                    <asp:Label ID="lblPageNumber" runat="server" Text='<%#Eval("PageNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="भाषा">
                                <ItemTemplate>
                                    <%#Eval("Language").ToString()=="H"?"Hindi":"English" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="डाउनलोड">
                                <ItemTemplate>
                                    <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="देखें" HeaderStyle-CssClass="align_center header">
                                <ItemTemplate>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="divMsg" style="text-align: center; height: 550px; width: 750px;">
                    <asp:Image runat="server" ID="img" alt="Gazette is Not Uploaded" />
                </div>
                <div class="butLink03">
                    <a accesskey="D" class="sa_bold perp_button_cancel" href="ForestArea.aspx">Back</a>
                </div>
                <br />
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>