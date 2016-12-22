<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MAPS.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/buttoncss.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="Content/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>UP Forest MAP Digitization</title>
    <script src="<%: ResolveClientUrl("~/Scripts/jquery-2.0.3.min.js") %>" type="text/javascript"></script>
    <style type="text/css">
        .input_text
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            text-transform: uppercase;
            background: url(images/login_input.png) no-repeat;
            height: 260px;
            width: 464px;
            margin: 0px auto;
            padding-top: 50px;
        }
        
        .input_text_box
        {
            background: url(images/User.png) no-repeat #cccccc;
            border-bottom: 1px solid #333;
            border-left: 1px solid #000;
            border-right: 1px solid #333;
            border-top: 1px solid #000;
            color: #000;
            border-radius: 3px 3px 3px 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            font: Arial, Helvetica, sans-serif;
            font-size: 13px;
            padding: 5px 6px 4px 25px;
            width: 380px;
        }
        
        .input_text_box1
        {
            background: url(images/password.png) no-repeat #cccccc;
            border-bottom: 1px solid #333;
            border-left: 1px solid #000;
            border-right: 1px solid #333;
            border-top: 1px solid #000;
            color: #000;
            border-radius: 3px 3px 3px 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            font: Arial, Helvetica, sans-serif;
            font-size: 13px;
            padding: 5px 6px 4px 25px;
            width: 380px;
        }
    </style>
</head>
<body style="background: url(images/back_1.jpg) no-repeat center bottom; padding: 0px;
    margin: 0px; height: 700px; background-attachment: fixed;">
    <form id="frm" runat="server">
    <table width="1000" align="center" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <img src="images/index_01.jpg" />
            </td>
        </tr>
        <tr>
            <td style="border-top-style: solid; border-width: thin; border-color: #333333">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="jqueryslidemenu" style="border: thin none #000000; font-size: xx-large;
                font-family: Calibri; color: #FFFFFF; font-style: italic;">
                Welcome To Forest MAP digitization System..
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Pnlmsg" runat="server" Visible="false">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="View/ForestArea.aspx">Home</a>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <div class="input_text">
                    <table width="90%" align="center" cellpadding="5" cellspacing="2" border="0">
                        <tr>
                            <td>
                                User Name
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <form id="form1" name="form1" method="post" action="">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input_text_box" placeholder="UserName"></asp:TextBox>
                                <%-- <input name="textfield" type="text" class="input_text_box" id="textfield" placeholder="user name" />--%>
                                </form>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                password
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="input_text_box1" placeholder="Password"
                                    TextMode="Password"></asp:TextBox>
                                <%--<input name="textfield2" type="password" class="input_text_box1" id="textfield2" placeholder="password" /></td>--%>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnSubmit" CssClass="buttonnew green" runat="server" Text="Login"
                                    OnClick="btnSubmit_Click" />
                                <%--<input type="submit" name="button" id="button" value="Submit" /></td>--%>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/gritter") %>
    <script type="text/javascript">
        function jQueryAlert(message) {

            $.gritter.add({
                // (string | mandatory) the heading of the notification
                title: 'Message',
                // (string | mandatory) the text inside the notification
                text: message,
                // (string | optional) the image to display on the left
                // (bool | optional) if you want it to fade out on its own or just sit there
                sticky: false,
                // (int | optional) the time you want it to be alive for before fading out
                time: '5000'
            });

            return false;

        };
    </script>
    </form>
</body>
</html>
