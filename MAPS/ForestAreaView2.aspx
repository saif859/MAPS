<%@ Page Title="View" Language="C#" MasterPageFile="~/Masters/Site1.Master" AutoEventWireup="true"
    CodeBehind="ForestAreaView2.aspx.cs" Inherits="MAPS.ForestAreaView2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .gradient
        {
            background: #eeeeee; /* Old browsers */
            background: -moz-linear-gradient(top, #eeeeee 64%, #cccccc 97%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(64%,#eeeeee), color-stop(97%,#cccccc)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #eeeeee 64%,#cccccc 97%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #eeeeee 64%,#cccccc 97%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #eeeeee 64%,#cccccc 97%); /* IE10+ */
            background: linear-gradient(to bottom, #eeeeee 64%,#cccccc 97%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#eeeeee', endColorstr='#cccccc',GradientType=0 ); /* IE6-9 */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainSection">
        <table width="100%">
            <h1>
            </h1>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div class="perp">
        <div class="perp_sheetbg">
            <div class="perp_sheet perp_sheet_width">
                <asp:Panel ID="PnlView" runat="server">
                    <table width="90%" class="newboxPlan">
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
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
                                            <td colspan="6" align="right">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" RowStyle-Height="30px"
                                    Width="90%">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <RowStyle Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle CssClass="selected" />
                                    <HeaderStyle CssClass="gradient" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Pillar No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("PillarNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Latitude">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("Latitude") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Longitude">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("Longitude") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SortedAscendingCellStyle BorderWidth="1px" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <a href="Map2.kml" target="_blank" style="color: Blue;">click to download KML file
                                </a>
                            </td>
                        </tr>
                    </table>
                    <%if (Request["Code"] != null)
                      { %>
                    <img src="MAP/<%:Request["Code"] %>.jpg" />
                    <%} %>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
