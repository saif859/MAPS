<%@ Page Title="Forest Area" Language="C#" MasterPageFile="~/Masters/Site1.Master"
    AutoEventWireup="true" CodeBehind="ForestArea.aspx.cs" Inherits="MAPS.ForestArea1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main Section-->
    <asp:UpdatePanel ID="upGV" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="updateprogress112" runat="server" AssociatedUpdatePanelID="upGV">
                <ProgressTemplate>
                    <div class="UpdateProgressModalBackground">
                    </div>
                    <div class="UpdateProgressPanel">
                        <img src="images/Loading.gif" /><br />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="mainSection">
                <h1>
                    <span class="heading">वन क्षेत्र (खंभे उपलब्ध)</span></h1>
                <div class="butLink01">
                    <a href="ForestAreaNew.aspx" class="button">वन क्षेत्र जोड़ें</a>
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
                                            ज़ोन चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            वृत्त चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlCircle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            प्रभाग चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            उप-प्रभाग चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlSubDivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            रेंज चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlRange" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRange_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            सेक्शन चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            बीट चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlBeat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBeat_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            ब्लॉक चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlBlock" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            जिला चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            तहसील चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlTehsil" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTehsil_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            ग्राम चुने</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlVillage" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            वन प्रकार चुनें</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlForestType" runat="server">
                                                <asp:ListItem Text="ALL" Value="" />
                                                <asp:ListItem Text="Reserved" Value="R" />
                                                <asp:ListItem Text="Protected" Value="U" />
                                                <asp:ListItem Text="Cadastral" Value="C" />
                                                <asp:ListItem Text="Other" Value="O" />
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td colspan="6" align="right">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="hubData" class="tableContainer">
                            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
                                runat="server" Width="100%" EmptyDataText="No Records to Display." AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="50" ShowFooter="true"
                                OnPageIndexChanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle CssClass="alt" />
                                <SelectedRowStyle CssClass="selected" />
                                <Columns>
                                    <asp:TemplateField HeaderText="क्र० स०">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %><asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("id") %>'>
                                            </asp:HiddenField>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>स०</b></FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="वन प्रकार">
                                        <ItemTemplate>
                                            <%#Eval("ForestType").ToString() == "R" ? "Reserved" : (Eval("ForestType").ToString() == "U" ? "UnReserved" : (Eval("ForestType").ToString() == "C" ? "Cadastral" : "Other"))%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label></b></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BlockName" HeaderText="ब्लॉक"></asp:BoundField>
                                    <asp:BoundField DataField="VillageName" HeaderText="ग्राम"></asp:BoundField>
                                    <asp:BoundField DataField="ForestName" HeaderText="वन नाम"></asp:BoundField>
                                    <asp:BoundField DataField="NumberOfPillars" HeaderText="खम्भों की संख्या" ItemStyle-HorizontalAlign="Right"
                                        FooterText="कुल क्षेत्रफल" FooterStyle-Font-Bold="true"></asp:BoundField>
                                    <asp:TemplateField HeaderText="कैल्क्युलेटेड क्षेत्रफल (एकड़ में)" ItemStyle-HorizontalAlign="Right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <%#Eval("AreaCalculated")%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalArea" runat="server"></asp:Label></b></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AreaInGazette" HeaderText="गैज़ेट में क्षेत्रफल" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:CommandField EditText="&lt;img src='images/btn_iconEdit.gif' alt='Edit' border='0' /&gt;"
                                        HeaderText="संपादित करें" ShowEditButton="True">
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="खम्भे विस्तार से देखें">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgview" ImageUrl="~/images/btn_iconView.gif" OnClick="imgview_click"
                                                Style="border: 0" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="गैज़ेट विस्तार से लिखें">
                                        <ItemTemplate>
                                            <a href='GazetteDetail.aspx?Code=<%#Eval("Id") %>'>Enter</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="गैज़ेट विस्तार से देखें">
                                        <ItemTemplate>
                                            <a href='ViewGazetteDetail.aspx?Code=<%#Eval("Id") %>'>View</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField DeleteText="&lt;img src='images/btn_iconDelete.gif' alt='Delete' border='0' /&gt;"
                                        SelectText="हटाएं" ShowDeleteButton="True" HeaderText="हटाएं">
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
