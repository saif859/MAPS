<%@ Page Title="Zone" Language="C#" MasterPageFile="~/Masters/Site1.Master" AutoEventWireup="true"
    CodeBehind="ZoneMaster.aspx.cs" Inherits="MAPS.Masters.ZoneMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main Section-->
    <div class="mainSection">
        <h1>
            <span class="heading">Zone</span></h1>
        <div class="butLink01">
            <a href="ZoneMasterNew.aspx" class="button">Create </a>
        </div>
        <div class="butLink02">
        </div>
        <div class="butLink03">
        </div>
    </div>
    <!--End Main Section--->
    <div id="hubData">
        <div class="tableContainer">
            <asp:UpdatePanel ID="upGV" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" BackColor="White" BorderColor="#DEDFDE" OnRowDataBound="GridView1_RowDataBound"
                        BorderWidth="0px" CellPadding="2" CellSpacing="1" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting"
                        runat="server" Width="100%" EmptyDataText="No Records to Display." AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="alt" />
                        <SelectedRowStyle CssClass="selected" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Wing_Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Description" HeaderText="Name"></asp:BoundField>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
