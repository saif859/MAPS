<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Masters/Site1.Master"
    AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MAPS.ChangePassword" %>

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
                    <%=txtOldPassword.UniqueID %>: {
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
                    <%=txtOldPassword.UniqueID %>: {
                        required: "Please enter Old Password."
                    },
                    <%=txtPassword.UniqueID %>: {
                        required: "Please enter New Password."
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
                            <span style="color: #06F;">Change Password</span></h1>
                        <hr />
                        <table border="0" class="perp_group" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr class="perp_group_row">
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label class=" perp_label sa_text_right" for="">
                                            Old Password*
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox><asp:HiddenField
                                                ID="hfPassword" runat="server" />
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label class=" perp_label sa_text_right" for="">
                                            New Password*
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                        </span>
                                    </td>
                                    <td class="perp_group_cell perp_group_cell_label">
                                        <label for="" class=" perp_label sa_text_right">
                                            Confirm Password*
                                        </label>
                                    </td>
                                    <td class="perp_group_cell">
                                        <span class="perp_field perp_field_char">
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <hr />
                        <div class="butLink03">
                            <asp:Button ID="Button1" CssClass="sa_highlight" runat="server" Text="Save" OnClick="btnSave_Click"
                                OnClientClick="$('#form1').valid();" />
                        </div>
                        <br />
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
