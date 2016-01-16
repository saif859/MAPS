<%@ Page Title="वन क्षेत्र" Language="C#" MasterPageFile="~/Masters/Site1.Master"
    AutoEventWireup="true" CodeBehind="ForestArea.aspx.cs" Inherits="MAPS.ForestArea1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main Section-->
    <asp:UpdatePanel ID="upGV" runat="server">
        <ContentTemplate>
            <div class="mainSection">
                <h1>
                    <span class="heading">वन क्षेत्र</span></h1>
                <div class="butLink01">
                    <a href="ForestAreaNew.aspx" class="button">Create </a>
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
                                            <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Circle</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlCircle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Division</label>
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
                                            Range</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlRange" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRange_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Section</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Block</label>
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
                                            District</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Tehsil</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlTehsil" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTehsil_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Village</label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlVillage" runat="server">
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
                            <asp:GridView ID="GridView1" BackColor="White" BorderColor="#DEDFDE" OnRowDataBound="GridView1_RowDataBound"
                                BorderWidth="0px" CellPadding="2" CellSpacing="1" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting"
                                runat="server" Width="100%" EmptyDataText="No Records to Display." AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle CssClass="alt" />
                                <SelectedRowStyle CssClass="selected" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %><asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("id") %>'>
                                            </asp:HiddenField>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <%#Eval("ForestType").ToString() == "R" ? "Reserved" : (Eval("ForestType").ToString() == "U" ? "UnReserved" : (Eval("ForestType").ToString() == "C" ? "Cadastral" : "Other"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BlockName" HeaderText="Block"></asp:BoundField>
                                    <asp:BoundField DataField="VillageName" HeaderText="Village"></asp:BoundField>
                                    <asp:BoundField DataField="ForestName" HeaderText="Forest Name"></asp:BoundField>
                                    <asp:BoundField DataField="NumberOfPillars" HeaderText="Pillars" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AreaCalculated" HeaderText="Computed Area" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AreaInGazette" HeaderText="Area In Gazette" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:CommandField EditText="&lt;img src='../images/btn_iconEdit.gif' alt='Edit' border='0' /&gt;"
                                        HeaderText="Edit" ShowEditButton="True">
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:CommandField DeleteText="&lt;img src='../images/btn_iconDelete.gif' alt='Delete' border='0' /&gt;"
                                        SelectText="Delete" ShowDeleteButton="True" HeaderText="Delete">
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
