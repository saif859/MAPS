<%@ Page Title="ब्लाक" Language="C#" MasterPageFile="~/Masters/Site1.Master" AutoEventWireup="true"
    CodeBehind="BlockMasterNew.aspx.cs" Inherits="MAPS.Masters.BlockMasterNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%: System.Web.Optimization.Scripts.Render("~/bundles/jqueryval") %>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/jquerytip") %><script src="../Scripts/ptpl.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        // if you use jQuery, you can load them when dom is read.
        $(document).ready(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            // Place here the first init of the DatePicker
            jValid();
        });

        function InitializeRequest(sender, args) {
            // make unbind to avoid memory leaks.
            jValid();
        }

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the DatePicker
            jValid();
        }
        function jValid()
        {
            // initialize tooltipster on form input elements
            $('#form1 input').tooltipster({ 
                trigger: 'custom', // default is 'hover' which is no good here
                onlyOne: false,    // allow multiple tips to be open at a time
                position: 'right'  // display the tips to the right of the element
            });
            
            $("#form1").validate({
                onsubmit: false,
                rules: {
                    <%=txtBlockName.UniqueID %>: {
                        required: true
                    },
                    <%=txtLoginId.UniqueID %>: {
                        required: true
                    },
                    <%=txtPassword.UniqueID %>: {
                        required: true
                    },
                    <%=txtConfirmPassword.UniqueID %>: {
                        equalTo : "#<%=txtPassword.ClientID %>"
                    }
                },
                messages: {
                    <%=txtBlockName.UniqueID %>: {
                        required: "Please enter Block Name."
                    },
                    <%=txtLoginId.UniqueID %>: {
                        required: "Please enter Login Id."
                    },
                    <%=txtPassword.UniqueID %>: {
                        required: "Please enter Password."
                    },
                    <%=txtConfirmPassword.UniqueID %>: {
                        equalTo : "Confirm Password does not match Password."
                    }
                },
                highlight: function(element) {
                    $(element).addClass('error');
                }, unhighlight: function(element) {
                    $(element).removeClass('error');
                },errorPlacement: function (error, element) {
                    $(element).tooltipster('update', $(error).text());
                    $(element).tooltipster('show');
                },
                success: function (label, element) {
                    $(element).tooltipster('hide');
                }
            });

            $("#<%=Button1.ClientID%>").click(function(evt) {
                // Validate the form and retain the result.
                var isValid = $("#form1").valid();
 
                if (!isValid){
                    event.preventDefault();
                    return false;}
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="perp">
        <div class="perp_sheetbg">
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div class="perp_sheet perp_sheet_width">
                        <h1>
                            <span style="color: #06F;">ब्लाक</span><span class="sa_fade">/ </span><span class="sa_breadcrumb_item">
                                <%if (Request["Code"] == null)
                                  { %>New<%}
                                  else
                                  { %><%=txtBlockName.Text%><%} %></span></h1>
                        <hr />
                        <table border="0" class="perp_group" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Name*
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtBlockName" runat="server" MaxLength="250" Width="150px"></asp:TextBox>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Zone
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Circle
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlCircle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Division
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label class=" perp_label sa_text_right" for="">
                                            Range
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlRange" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlRange_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label class=" perp_label sa_text_right" for="">
                                            Section
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:DropDownList ID="ddlSection" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Officer Name
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtOfficerName" runat="server" MaxLength="250" Width="120px"></asp:TextBox>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label class=" perp_label sa_text_right" for="">
                                            Mobile
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Phone No.
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtSTD" runat="server" MaxLength="6" Width="30px" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                            <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="7" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Fax
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="13" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                                <%if (Request["Code"] == null)
                                  { %><tr class="perp_group_row">
                                      <td class="perp_group_cell perp_group_cell_label">
                                          <label class=" perp_label sa_text_right" for="">
                                              Login Id*
                                          </label>
                                      </td>
                                      <td class="perp_group_cell">
                                          <span class="perp_field perp_field_char">
                                              <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                                          </span>
                                      </td>
                                      <td class="perp_group_cell perp_group_cell_label">
                                          <label class=" perp_label sa_text_right" for="">
                                              Password*
                                          </label>
                                      </td>
                                      <td class="perp_group_cell">
                                          <span class="perp_field perp_field_char">
                                              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                          </span>
                                      </td>
                                  </tr>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Confirm Password*
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                        <hr />
                        <div class="butLink03">
                            <asp:Button ID="Button1" CssClass="sa_highlight" runat="server" Text="Save" OnClick="btnSave_Click"
                                OnClientClick="$('#form1').valid();" />
                            <span class="sa_fade">or</span> <a accesskey="D" class="sa_bold perp_button_cancel"
                                href="BlockMaster.aspx">Discard</a>
                        </div>
                        <br />
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
