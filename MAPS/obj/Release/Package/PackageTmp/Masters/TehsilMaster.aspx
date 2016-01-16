<%@ Page Title="Tehsils" Language="C#" MasterPageFile="~/Masters/Site1.Master" AutoEventWireup="true"
    CodeBehind="TehsilMaster.aspx.cs" Inherits="MAPS.Masters.TehsilMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainSection">
        <h1 style="padding-top: 10px;">
            <span class="heading">तहसील</span></h1>
        <div class="butLink01">
        </div>
        <div class="butLink02">
        </div>
        <div class="butLink03">
        </div>
    </div>
    <div id="hubData">
        <div class="tableContainer">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                        ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                        <AlternatingRowStyle CssClass="alt" />
                        <FooterStyle Font-Bold="true" CssClass="selected" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("Id") %>'></asp:HiddenField>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("TehsilName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("Id") %>'></asp:HiddenField>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("TehsilName") %>' ValidationGroup="U"
                                        MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="U" runat="server"
                                        ControlToValidate="txtName" Display="None" ErrorMessage="Tehsil Name required."
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName" runat="server" ValidationGroup="A" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                        Display="None" ErrorMessage="Tehsil Name required." ValidationGroup="A" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="District">
                                <ItemTemplate>
                                    <%# Eval("DistrictName") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDistrict" runat="server" SelectedValue='<%# Eval("DistrictId") %>'
                                        DataValueField="Id" DataTextField="DistrictName" ValidationGroup="U" DataSourceID="EntityDataSource1">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlDistrict" runat="server" DataValueField="Id" DataTextField="DistrictName"
                                        ValidationGroup="U" DataSourceID="EntityDataSource1">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                        ImageUrl="../images/btn_iconEdit.gif" ToolTip="Edit" />
                                    <asp:ImageButton ID="ibDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                        ImageUrl="../images/btn_iconDelete.gif" ToolTip="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"
                                        ValidationGroup="U" />
                                    <asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel"
                                        Text="Cancel" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="~/images/add.gif" OnClick="ibAdd_Click"
                                        ValidationGroup="A" ToolTip="Add" />
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellspacing="1" cellpadding="2" rules="cols" border="0" style="background-color: White;
                                border-color: #DEDFDE; border-width: 0px; width: 100%;">
                                <tr>
                                    <th scope="col">
                                        <a href="#">Name</a>
                                    </th>
                                    <th scope="col">
                                        <a href="#">District</a>
                                    </th>
                                    <th scope="col">
                                        <a href="#">Action</a>
                                    </th>
                                </tr>
                                <tr class="selected">
                                    <td align="center">
                                        <asp:TextBox ID="txtName" runat="server" ValidationGroup="eA" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                            Display="None" ValidationGroup="eA" ErrorMessage="Tehsil Name required." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="center">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" DataValueField="Id" DataTextField="DistrictName"
                                            ValidationGroup="U" DataSourceID="EntityDataSource1">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="../images/add.gif" OnClick="ibAdd_Click"
                                            ToolTip="Add New Tehsil" ValidationGroup="eA" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=DefaultCS"
        DefaultContainerName="DefaultCS" EnableFlattening="False" EntitySetName="Districts"
        Select="it.[Id], it.[DistrictName]">
    </asp:EntityDataSource>
</asp:Content>
