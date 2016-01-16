<%@ Page Title="View Gazette Details" Language="C#" MasterPageFile="~/Masters/Site1.Master"
    AutoEventWireup="true" CodeBehind="ViewGazetteDetail.aspx.cs" Inherits="MAPS.ViewGazetteDetail" %>

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
                                    ज़ोन</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblZone" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    वृत्त</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblCircle" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    प्रभाग</label>
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
                                    ब्लॉक</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblBlcok" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    ग्राम</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblVillage" runat="server" Text="Label"></asp:Label>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    वन प्रकार</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:Label ID="lblForestType" runat="server" Text="Label"></asp:Label>
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
                    <table cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <th>
                                क्र० स०
                            </th>
                            <th>
                                अधिसूचना संख्या
                            </th>
                            <th>
                                अधिसूचना का प्रकार
                            </th>
                            <th>
                                राजपत्र देखें
                            </th>
                        </tr>
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                <asp:Label ID="lblNotificationNumber" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNotificationType" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="lnkViewGazette" runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr />
                <div id="hubData" class="tableContainer">
                    <div>
                        <h3>
                            इस वन ब्लॉक के साथ संबद्ध ग्राम</h3>
                    </div>
                    <br />
                    <asp:GridView ID="gvVillage" runat="server" Width="100%" EmptyDataText="No Records to Display."
                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                        <AlternatingRowStyle CssClass="alt" />
                        <SelectedRowStyle CssClass="selected" />
                        <Columns>
                            <asp:TemplateField HeaderText="क्र० स०">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ग्राम">
                                <ItemTemplate>
                                    <asp:Label ID="lblVillageName" runat="server" Text='<%#Eval("VillageName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
                <div id="hubData" class="tableContainer">
                    <div>
                        <h3>
                            इस वन ब्लॉक के साथ संबद्ध खसरा</h3>
                    </div>
                    <br />
                    <asp:GridView ID="gvKhasara" runat="server" Width="100%" EmptyDataText="No Records to Display."
                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" ShowFooter="true" OnRowDataBound="gvKhasara_RowDataBound">
                        <AlternatingRowStyle CssClass="alt" />
                        <SelectedRowStyle CssClass="selected" />
                        <Columns>
                            <asp:TemplateField HeaderText="क्र० स०">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ग्राम">
                                <ItemTemplate>
                                    <asp:Label ID="lblVillageName" runat="server" Text='<%#Eval("VillageName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="खसरा संख्या">
                                <ItemTemplate>
                                    <asp:Label ID="lblKhasaraNo" runat="server" Text='<%#Eval("KhasaraNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="खतौनी संख्या">
                                <ItemTemplate>
                                    <asp:Label ID="lblKhatauniNo" runat="server" Text='<%#Eval("KhatauniNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="मालिक का नाम" FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblOwnerName" runat="server" Text='<%#Eval("OwnerName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>कुल क्षेत्रफल</b></FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="क्षेत्रफल (एकड़ में)">
                                <ItemTemplate>
                                    <%#Eval("AreainAcres") %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblAreaAcres" runat="server"></asp:Label>
                                    </b>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="अमल दरामद आदेश संख्या" FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%# Eval("AmalDaramadNo")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>अमल दरामद क्षेत्रफल</b>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="अमल दरामद तिथि">
                                <ItemTemplate>
                                    <%# Eval("AmalDaramadDate","{0:dd/MM/yyyy}")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblAmalDaramadArea" runat="server"></asp:Label></b>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
