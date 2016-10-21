<%@ Page Title="Add Khasara" Language="C#" MasterPageFile="~/Masters/Site1.Master"
    AutoEventWireup="true" CodeBehind="AddKhasara.aspx.cs" Inherits="MAPS.AddKhasara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%: System.Web.Optimization.Styles.Render("~/css/ui") %>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/jqueryui") %>
    <script src="Scripts/ptpl.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainSection">
        <h1>
            <span class="heading">Khasara Details of
                <%:Request["v"] %>,
                <%:Request["b"] %></span></h1>
        <div class="butLink01">
        </div>
        <div class="butLink02">
        </div>
        <div class="butLink03">
        </div>
    </div>
    <div id="hubData">
        <div class="tableContainer">
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound"
                AllowPaging="true" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowUpdating="GridView1_RowUpdating">
                <AlternatingRowStyle CssClass="alt" />
                <FooterStyle Font-Bold="true" CssClass="selected" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Khasara No.">
                        <ItemTemplate>
                            <asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("Id") %>'></asp:HiddenField>
                            <asp:Label ID="lblKhasaraNo" runat="server" Text='<%# Eval("KhasaraNo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="lblId" runat="server" Value='<%# Eval("Id") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtKhasaraNo" runat="server" Text='<%# Eval("KhasaraNo") %>' ValidationGroup="U"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="U" runat="server"
                                ForeColor="red" ControlToValidate="txtKhasaraNo" Display="None" ErrorMessage="khasara No. required."
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKhasaraNoF" runat="server" ValidationGroup="A" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKhasaraNoF"
                                Display="None" ErrorMessage="Khasara No. required." ValidationGroup="A" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Khatauni No" SortExpression="KhatauniNo">
                        <ItemTemplate>
                            <asp:Label ID="lblKhatauniNo" runat="server" Text='<%# Eval("KhatauniNo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtKhatauniNo" runat="server" Text='<%# Eval("KhatauniNo") %>' ValidationGroup="U"
                                MaxLength="100"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKhatauniNoF" runat="server" ValidationGroup="A" MaxLength="100"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner Name" SortExpression="OwnerName">
                        <ItemTemplate>
                            <asp:Label ID="lblOwnerName" runat="server" Text='<%# Eval("OwnerName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOwnerName" runat="server" Text='<%# Eval("OwnerName") %>' ValidationGroup="U"
                                MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="U" runat="server"
                                ControlToValidate="txtOwnerName" Display="None" ErrorMessage="Owner Name required."
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtOwnerNameF" runat="server" ValidationGroup="A" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtOwnerNameF"
                                Display="None" ErrorMessage="Owner Name required." ValidationGroup="A" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area(in Acres)">
                        <ItemTemplate>
                            <%# Eval("AreainAcres")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAreainAcres" runat="server" Text='<%# Eval("AreainAcres") %>'
                                ValidationGroup="U" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="U" runat="server"
                                ControlToValidate="txtOwnerName" Display="None" ErrorMessage="Area(in Acres) is required."
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAreainAcresF" runat="server" ValidationGroup="A" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="A" runat="server"
                                ControlToValidate="txtAreainAcresF" Display="None" ErrorMessage="Area(in Acres) is required."
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="अमल दरामद आदेश संख्या">
                        <ItemTemplate>
                            <%# Eval("AmalDaramadNo")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAmalDaramadNo" runat="server" Text='<%# Eval("AmalDaramadNo") %>'
                                ValidationGroup="U" MaxLength="100"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAmalDaramadNoF" runat="server" ValidationGroup="A" MaxLength="100"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="अमल दरामद तिथि">
                        <ItemTemplate>
                            <%# Eval("AmalDaramadDate","{0:dd/MM/yyyy}")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAmalDaramadDate" runat="server" Text='<%# Eval("AmalDaramadDate") %>'
                                ValidationGroup="U" MaxLength="100" CssClass="jDate"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAmalDaramadDateF" runat="server" ValidationGroup="A" MaxLength="100"
                                CssClass="jDate"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                ImageUrl="images/btn_iconEdit.gif" ToolTip="Edit" />
                            <asp:ImageButton ID="ibDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                ImageUrl="images/btn_iconDelete.gif" ToolTip="Delete" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"
                                ValidationGroup="U" />
                            <asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel"
                                Text="Cancel" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="images/add.gif" OnClick="ibAdd_Click"
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
                                <a href="#">Khasara Number</a>
                            </th>
                            <th scope="col">
                                <a href="#">Khatauni Number</a>
                            </th>
                            <th scope="col">
                                <a href="#">Owner Name</a>
                            </th>
                            <th scope="col">
                                <a href="#">Area(in Acres)</a>
                            </th>
                            <th scope="col">
                                <a href="#">अमल दरामद आदेश संख्या</a>
                            </th>
                            <th scope="col">
                                <a href="#">अमल दरामद तिथि</a>
                            </th>
                            <th scope="col">
                                <a href="#">Action</a>
                            </th>
                        </tr>
                        <tr class="selected">
                            <td align="center">
                                <asp:TextBox ID="txtKhasaraNoF" runat="server" Text='<%# Eval("KhasaraNo") %>' ValidationGroup="A"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="B" runat="server"
                                    ControlToValidate="txtKhasaraNoF" Display="None" ErrorMessage="khasara No. required."
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtKhatauniNoF" runat="server" Text='<%# Eval("KhatauniNo") %>'
                                    ValidationGroup="A" MaxLength="100"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtOwnerNameF" runat="server" Text='<%# Eval("OwnerName") %>' ValidationGroup="A"
                                    MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="B" runat="server"
                                    ControlToValidate="txtOwnerNameF" Display="None" ErrorMessage="Owner Name required."
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtAreainAcresF" runat="server" Text='<%# Eval("AreainAcres") %>'
                                    ValidationGroup="B" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="B" runat="server"
                                    ControlToValidate="txtAreainAcresF" Display="None" ErrorMessage="Area(in Acres) is required."
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmalDaramadNoF" runat="server" Text='<%# Eval("AmalDaramadNo") %>'
                                    ValidationGroup="A" MaxLength="100"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmalDaramadDateF" runat="server" Text='<%# Eval("AmalDaramadDate") %>'
                                    ValidationGroup="A" MaxLength="100" CssClass="jDate"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="images/add.gif" OnClick="ibAdd_Click"
                                    ToolTip="Add New Village" ValidationGroup="B" />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
