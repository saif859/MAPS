<%@ Page Title="Forest Area" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ForestAreaNew.aspx.cs" Inherits="MAPS.ForestAreaNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="Content/tooltipster.css" rel="stylesheet" type="text/css" />
    <%: System.Web.Optimization.Styles.Render("~/css/ui") %>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/jqueryui") %>
    <style type="text/css">
        @media print
        {
            .pre
            {
                display: none;
            }
        }
        .UpdateProgressPanel
        {
            z-index: 99999999;
            color: Black;
            width: 250px;
            text-align: center;
            vertical-align: middle;
            position: fixed;
            bottom: 50%;
            left: 40%;
            padding: 10px;
        }
        
        .UpdateProgressModalBackground
        {
            z-index: 99999998;
            background-color: #FFF;
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            filter: alpha(opacity=50);
            opacity: 0.8;
            -moz-opacity: 0.8;
            -webkit-opacity: 0.8;
        }
    </style>
    <link href="Content/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function photoRebind() {
            document.getElementById('<%: btnPhoto.ClientID %>').click();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("a[rel=example_group]").fancybox({ 'transitionIn': 'none', 'transitionOut': 'none', 'titlePosition': 'over' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr style="width: 100%;" />
    <div id="printarea" style="padding-top: 20px;">
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
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gra">
                    <tbody>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Zone</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Circle</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlCircle" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Division</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Sub Division</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlSubDivision" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlSubDivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Range</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlRange" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlRange_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Section</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Beat</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlBeat" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlBeat_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Block</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlBlock" runat="server" CssClass="ddl" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtBlock" runat="server" Visible="false" MaxLength="150" CssClass="inputbox req"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose District</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Tehsil</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlTehsil" runat="server" AutoPostBack="true" CssClass="ddl"
                                        OnSelectedIndexChanged="ddlTehsil_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Choose Village</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddl" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlVillage_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtVillage" runat="server" Visible="false" MaxLength="150" CssClass="inputbox req"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr class="perp_group_row">
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Forest Type</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:DropDownList ID="ddlForestType" runat="server" CssClass="ddl">
                                        <asp:ListItem Text="Reserved" Value="R" />
                                        <%--                                    <asp:ListItem Text="UnReserved" Value="U" />
                                    <asp:ListItem Text="Cadastral" Value="C" />
                                    <asp:ListItem Text="Other" Value="O" />
                                        --%>
                                    </asp:DropDownList>
                                </span>
                            </td>
                            <td class="perp_group_cell perp_group_cell_label">
                                <label for="" class=" perp_label sa_text_right">
                                    Forest Name</label>
                            </td>
                            <td class="perp_group_cell">
                                <span class="perp_field perp_field_char">
                                    <asp:TextBox ID="txtForestName" runat="server" class="inputbox req" placeholder="Forest Name"
                                        title="Forest Name"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr style="width: 100%; margin-bottom: 10px; margin-top: 5px; border-top: 1px solid #000;" />
        <font style="color: Red;">Fill gps co ordinates of the reference point and the bearing and chainage of next pillar. Then GPS coordinates of other pillars will be calculated by Software on filling their chain and bearing.</font>
        <div style="padding: 5px; color: #000; background: #f4f4f4; font-size: 12px;">
            <asp:RadioButton ID="rdFirstPillar" runat="server" Text="Reference Pillar Co-ordinates"
                class="rd" GroupName="rd" Checked="true" />&nbsp;<asp:RadioButton GroupName="rd"
                    ID="rdReference" runat="server" Text="Reference Point Co-ordinates" class="rd" />
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table gra">
            <tr style="color: #000;">
                <th rowspan="2">
                    Pillar No.
                </th>
                <th colspan="2">
                    GPS
                </th>
                <th rowspan="2">
                    Forward Bearings (in Degree)
                </th>
                <th rowspan="2" style="display: none;">
                    Bearings Diff. (in Degree)
                </th>
                <th rowspan="2" style="display: none;">
                    Back Bearings (in Degree)
                </th>
                <th rowspan="2" style="display: none;">
                    Distance from Previous Pillar (in Chains)
                </th>
                <th rowspan="2" style="display: none;">
                    Distance from Previous Pillar (in Meters)
                </th>
            </tr>
            <tr style="color: #000;">
                <th>
                    Latitude
                </th>
                <th>
                    Longitude
                </th>
            </tr>
            <tr style="color: #000;">
                <td align="center" valign="top">
                    <input name="hfId0" id="hfId0" value='<%:Request["Code"]!=null?queryCo.First().Id.ToString():"" %>'
                        type="hidden" />
                    <input name="txtPillarNo0" id="txtPillarNo0" type="text" style="width: 40px" class="textAlign inputbox req"
                        onkeypress="return OnlyNumber(event);" value='<%:Request["Code"]!=null?queryCo.First().PillarNo:"" %>' />
                </td>
                <td align="center" valign="top">
                    <input type="text" id="txtLatitude0" name="txtLatitude0" class="textAlign inputbox req"
                        placeholder="Latitude" onkeypress="return isNumberWithDot(this);" onchange="orthoDestMap();"
                        title="Latitude" value='<%:Request["Code"]!=null?queryCo.First().Latitude:"" %>'>
                </td>
                <td align="center" valign="top">
                    <input type="text" name="txtLongitude0" id="txtLongitude0" class="textAlign inputbox req"
                        placeholder="Longitude" onkeypress="return isNumberWithDot(this);" onchange="orthoDestMap();"
                        title="Longitude" value='<%:Request["Code"]!=null?queryCo.First().Longitude:"" %>'>
                </td>
                <td align="center" valign="top">
                    <input type="text" name="txtBearing0" id="txtBearing0" class="textAlign bearings inputbox brng req"
                        onkeypress="return isNumberWithDot(this);" placeholder="Bearings" onchange="orthoDestMap();"
                        title="Bearings" value='<%:Request["Code"]!=null?queryCo.First().ForwardBearings:"" %>'>
                </td>
                <td align="center" valign="top" style="display: none;">
                    <input name="txtBearingDifference0" id="txtBearingDifference0" type="text" placeholder="Bearings Difference"
                        class="textAlign bearings inputbox diff" onkeypress="return isNumberWithDot(this);"
                        readonly="readonly" title="Bearings Difference" value='<%:Request["Code"]!=null?queryCo.First().BearingDifference.ToString():"" %>' />
                </td>
                <td align="center" valign="top" style="display: none;">
                    <input type="text" name="txtBackBearing0" id="txtBackBearing0" class="textAlign bearings inputbox brng req"
                        onkeypress="return isNumberWithDot(this);" placeholder="Back Bearings" onchange="orthoDestMap();"
                        title="Back Bearings" value='<%:Request["Code"]!=null?queryCo.First().BackBearings:"" %>'>
                </td>
                <td align="center" valign="top" style="display: none;">
                    <input type="text" name="txtDistanceInChain0" id="txtDistanceInChain0" class="textAlign distance inputbox req"
                        onkeypress="return isNumberWithDot(this);" placeholder="Distance from last Pillar"
                        onchange="chainToMeter();" title="Distance from last Pillar" value='<%:Request["Code"]!=null?queryCo.First().BackDistanceInChain.ToString():"" %>'>
                </td>
                <td align="center" valign="top" style="display: none;">
                    <input type="text" name="txtDistance0" id="txtDistance0" class="textAlign distance inputbox req"
                        readonly="readonly" onkeypress="return isNumberWithDot(this);" placeholder="Distance from last Pillar"
                        onchange="orthoDestMap();" title="Distance from last Pillar" value='<%:Request["Code"]!=null?queryCo.First().BackDistanceInMeter.ToString():"" %>'>
                </td>
            </tr>
        </table>
        <br />
        <div class="clr">
        </div>
        <div class="NumPillar gra">
            <table width="90%" border="0" cellpadding="5" cellspacing="5" align="center">
                <tr>
                    <td width="35%" valign="middle" align="left">
                        <div>
                            Total Number of Pillar (Excluding first one) :</div>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="txtNoPillar" runat="server" onkeypress="return OnlyNumber(event);"
                            Style="width: 40px;" class="textAlign inputbox req" placeholder="No." title="Number of Pillar"></asp:TextBox>
                    </td>
                    <td width="36%" align="left">
                    </td>
                </tr>
            </table>
        </div>
        <div class="clr">
        </div>
        <div style="margin-top: 10px; clear: none;">
            <div style="float: left; padding-top: 10px;">
                Area in Gazette :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteArea" runat="server" class="textAlign inputbox req" onkeypress="return isNumberWithDot(this);"
                    placeholder="Area in Gazette" Width="100px"></asp:TextBox>Acre
            </div>
            <div style="float: left; padding-top: 10px; margin-left: 2%;">
                Gazette Number :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteNumber" runat="server" class="inputbox req" placeholder="Gazette Number"
                    title="Gazette Number"></asp:TextBox>
            </div>
            <div style="float: left; padding-top: 10px; margin-left: 2%;">
                Gazette Date :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteDate" runat="server" Style="width: 90px;" class="inputbox jDate req"
                    placeholder="Gazette Date" title="Gazette Date"></asp:TextBox>
            </div>
        </div>
        <div class="clr">
        </div>
        <div id="divTable" style="width: 100%; margin-top: 10px;">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table gra"
                id="tbl">
                <tbody>
                </tbody>
            </table>
        </div>
        <div class="clr">
        </div>
        <div style="margin-top: 10px;">
            <table>
                <tr>
                    <td>
                        Area in Gazette : &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtGazetteArea2" runat="server" Style="width: 100px;" class="textAlign inputbox"
                            ReadOnly="true" placeholder="Area in Gazette"></asp:TextBox>
                    </td>
                    <td>
                        Acre
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top: 10px;">
            <table>
                <tr>
                    <td>
                        Area computed based on chainage and bearings : &nbsp;&nbsp;
                    </td>
                    <td style="display: none;">
                        <asp:TextBox ID="areaM" runat="server" Style="width: 100px; display: none;" class="textAlign inputbox req"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                    <td style="display: none;">
                        m²,
                    </td>
                    <td align="left">
                        <asp:TextBox ID="areaH" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign inputbox req"></asp:TextBox>
                    </td>
                    <td>
                        Ha,
                    </td>
                    <td align="left">
                        <asp:TextBox ID="areaA" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign inputbox req"></asp:TextBox>
                    </td>
                    <td>
                        Acre
                    </td>
                    <td>
                        <input id="Button1" type="button" value="Calculate Area" onclick="orthoMap();" class="button button-green pre" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top: 10px;">
            <table>
                <tr>
                    <td>
                        Area computed based on field entry of GPS coordinates : &nbsp;&nbsp;
                    </td>
                    <td style="display: none;">
                        <asp:TextBox ID="areaMF" runat="server" Style="width: 100px; display: none;" class="textAlign inputbox"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                    <td style="display: none;">
                        m²,
                    </td>
                    <td align="left">
                        <asp:TextBox ID="areaHF" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign inputbox"></asp:TextBox>
                    </td>
                    <td>
                        Ha,
                    </td>
                    <td align="left">
                        <asp:TextBox ID="areaAF" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign inputbox"></asp:TextBox>
                    </td>
                    <td>
                        Acre
                    </td>
                    <td>
                        <input id="Button2" type="button" value="Calculate Field Area" onclick="orthoMapField();"
                            class="button button-green pre" />
                    </td>
                </tr>
            </table>
        </div>
        <hr style="width: 100%; margin-bottom: 10px; margin-top: 5px; border-top: 1px solid #000;" />
        <div style="width: 100%; margin-top: 10px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="updateprogress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <div class="UpdateProgressModalBackground">
                            </div>
                            <div class="UpdateProgressPanel">
                                <img src="images/Loading.gif" /><br />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <label class=" perp_label sa_text_right" for="">
                        Upload MAPs :</label>
                    <asp:Button ID="btnPhoto" runat="server" Text="Button" Style="display: none;" CausesValidation="false"
                        OnClick="btnPhoto_Click" />
                    <table border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td>
                                <asp:AsyncFileUpload ID="fuImage" runat="server" OnUploadedComplete="fuImage_UploadedComplete"
                                    OnClientUploadComplete="photoRebind" ClientIDMode="AutoID" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" valign="top">
                                <asp:Panel ID="Panel4" runat="server" ScrollBars="Vertical" Width="100%" Height="260px"
                                    BorderWidth="1px">
                                    <asp:Repeater ID="rptImages" runat="server">
                                        <HeaderTemplate>
                                            <div id="gallery">
                                                <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a rel="example_group" target="_blank" href='<%# Container.DataItem %>'>
                                                <img alt="" src='<%# Container.DataItem %>' height="180px" alt="" />
                                            </a>
                                                <br />
                                                <%# Container.DataItem.ToString().Substring(0,Container.DataItem.ToString().LastIndexOf('.')).Substring(Container.DataItem.ToString().IndexOf('_') + 1).Substring(Container.DataItem.ToString().Substring(Container.DataItem.ToString().IndexOf('_') + 1).IndexOf('_') + 1)  %>
                                                <br />
                                                <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:if(confirm('Do you want to delete?')){ return true; } else { return false; }"
                                                    CommandName="<%# Container.DataItem %>" OnClick="lnkDelete_Click" runat="server">Delete</asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul></div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="float: left;">
                <font style="color: Red;"> Image should be in jpg format with 100 dpi resolution and can be 16 bit colours.</font>
            </div>
        </div>
        <table style="float: right; clear: none; width: 100%;">
            <tr>
                <td>
                    <input id="btnPrint" type="button" value="Print proforma for recording entries of GPS co ordinates in field"
                        class="button button-green pre" />
                </td>
                <td align="right">
                    <input id="btnSubmit" type="button" value="Submit" class="button button-green pre" /><img
                        id="imgLoader" src="images/loader.gif" />
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 50%; clear: right; float: left;">
            Map generated on the chainage and bearings filled above
            <div id="map_canvas" style="height: 400px; width: 500px; clear: right;">
            </div>
        </div>
        <div style="width: 50%; float: right;">
            Map generated on the field entry filled above
            <div id="map_canvas1" style="height: 400px; width: 500px; clear: right;">
            </div>
        </div>
    </div>
    <div class="clr">
    </div>
    <script src="Scripts/latlon.js" type="text/javascript" />
    <script src="Scripts/geo.js" type="text/javascript" />
    <script src="Scripts/main.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=geometry&sensor=false"></script>
    <script type="text/javascript" src="Scripts/infobox.js"></script>
    <script src="Scripts/ptpl.js" type="text/javascript"></script>
    <script type="text/javascript">
        function chainToMeter() {
            var chain = $('#txtDistanceInChain0').val();
            var met = chain * 20.1168;
            $('#txtDistance0').val(met);
        };
        //-------------------------------------------------------------------------------------------------------------------------

        function replace() { $(this).after($(this).text()).remove() }

        $('#btnPrint').click(function () {
            var divToPrint = document.getElementById('printarea');
            var popupWin = window.open('', '_blank', 'width=900,height=600,location=no,left=50px');
            popupWin.document.open();
            popupWin.document.write('<html><head><link href="content/map2.css" rel="stylesheet" /><style type="text/css">@media print{ .pre{display: none;}}</style></head><body class="billText" onload="window.print()">' + divToPrint.innerHTML + '</html>');
            popupWin.document.close();

        });
    </script>
    <script type="text/javascript">
        var labels = [];
        var map;
        var map2;
        var bounds = new google.maps.LatLngBounds();

        function initialize() {
            var myLatlng = new google.maps.LatLng(26.869444, 80.974246);

            var myOptions = {
                zoom: 19,
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.HYBRID
            };
            map = new google.maps.Map(document.getElementById('map_canvas'), myOptions);
        }
        function initialize2() {
            var myLatlng = new google.maps.LatLng(26.869444, 80.974246);

            var myOptions = {
                zoom: 19,
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.HYBRID
            };
            map2 = new google.maps.Map(document.getElementById('map_canvas1'), myOptions);
        }

        google.maps.event.addListener(map, "zoom_changed", function () {
            if (map.getZoom() < 11) {
                for (var i = 0; i < labels.length; i++) {
                    labels[i].setMap(null);
                }
            }
        });
        function dibuV(area) {
            initialize();
            var a = new Array();

            for (var i = 0; i < area.length; i++) {
                var uno = area[i].split(",");
                a[i] = new google.maps.LatLng(uno[0], uno[1]);
                bounds.extend(a[i]);

                //                var marker = new google.maps.Marker({
                //                    position: new google.maps.LatLng(uno[0], uno[1]),
                //                    map: map,
                //                    title: (uno[0] + ', ' + uno[1])
                //                });
            }
            if ($('#rdReference').is(':checked')) {
                var marker = new google.maps.Marker({ position: new google.maps.LatLng(Geo.parseDMS($('#txtLatitude0').val()), Geo.parseDMS($('#txtLongitude0').val())), map: map, title: 'Reference Point ' + ($('#txtLatitude0').val() + ', ' + $('#txtLongitude0').val()) });
            }
            poligon = new google.maps.Polygon({
                paths: a,
                strokeColor: "#FFFF00",
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: "#FFFF00",
                fillOpacity: 0.0
            })

            poligon.setMap(map);
            var z = google.maps.geometry.spherical.computeArea(poligon.getPath().getArray());

            map.setCenter(bounds.getCenter());
            map.fitBounds(bounds);

            $('#<%:areaM.ClientID%>').val(z.toFixed(2)); // Area in Sq. Meter
            $('#<%:areaH.ClientID%>').val((z / 10000).toFixed(2)); // Area in Hectare
            $('#<%:areaA.ClientID%>').val((z / 4046.86).toFixed(2)); // Area in Acre
        }
        function dibuVF(area) {
            initialize2();
            var a = new Array();

            for (var i = 0; i < area.length; i++) {
                var uno = area[i].split(",");
                a[i] = new google.maps.LatLng(uno[0], uno[1]);
                bounds.extend(a[i]);
            }
            if ($('#rdReference').is(':checked')) {
                var marker = new google.maps.Marker({ position: new google.maps.LatLng(Geo.parseDMS($('#txtLatitude0').val()), Geo.parseDMS($('#txtLongitude0').val())), map: map, title: 'Reference Point ' + ($('#txtLatitude0').val() + ', ' + $('#txtLongitude0').val()) });
            }
            poligon = new google.maps.Polygon({
                paths: a,
                strokeColor: "#FFFF00",
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: "#FFFF00",
                fillOpacity: 0.0
            })

            poligon.setMap(map2);
            var z = google.maps.geometry.spherical.computeArea(poligon.getPath().getArray());

            map2.setCenter(bounds.getCenter());
            map2.fitBounds(bounds);

            $('#<%:areaMF.ClientID%>').val(z.toFixed(2)); // Area in Sq. Meter
            $('#<%:areaHF.ClientID%>').val((z / 10000).toFixed(2)); // Area in Hectare
            $('#<%:areaAF.ClientID%>').val((z / 4046.86).toFixed(2)); // Area in Acre
        }
    </script>
    <script type="text/javascript">
        var degFmt = 'd';
        $(document).ready(function () {


            $('.rd').click(function () {
                if ($('#rdReference').is(':checked')) { }
                if ($('#rdFirstPillar').is(':checked')) { }
            });

            $.get('Scripts/latlon.js', function (data) {
                var src = data.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
                $('#latlon-src').html(src);
            });
            $.get('Scripts/geo.js', function (data) {
                var src = data.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
                $('#geo-src').html(src);
            });

            $('#<%:txtGazetteArea.ClientID%>').change(function () {
                $('#<%:txtGazetteArea2.ClientID%>').val($('#<%:txtGazetteArea.ClientID%>').val());
            });

            $('#<%:txtNoPillar.ClientID%>').change(function () {
                var rows = $('#<%:txtNoPillar.ClientID%>').val();

                for (var i = document.getElementById("tbl").rows.length; i > 0; i--) {
                    document.getElementById("tbl").deleteRow(i - 1);
                }

                var tbody = $("#tbl");
                var number_of_columns = 10;

                if (tbody == null || tbody.length < 1) return;

                var tfirstrow = $("<tr style='color:#000;'>");
                $("<th rowspan=\"2\">").text("Pillar No.").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Distance from Previous Pillar (in Chains)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Distance from Previous Pillar (in Meters)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Back Bearings (in Degree)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").html("Bearings Diff. (in Degree)<br/>(as calculated from data)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Forward Bearings (in Degree)").appendTo(tfirstrow);
                $("<th colspan=\"2\">").html("GPS<br/>(as calculated from data)").appendTo(tfirstrow);
                $("<th colspan=\"2\">").text("Field Recorded GPS").appendTo(tfirstrow);

                tfirstrow.appendTo(tbody);
                var tSecondRow = $("<tr style='color:#000;'>");
                $("<th>").text("Latitude").appendTo(tSecondRow);
                $("<th>").text("Longitude").appendTo(tSecondRow);
                $("<th>").text("Latitude").appendTo(tSecondRow);
                $("<th>").text("Longitude").appendTo(tSecondRow);

                tSecondRow.appendTo(tbody);

                var tThirdRow = $("<tr style='color:#000;'>");
                $("<th>").text("1").appendTo(tThirdRow);
                $("<th>").text("2").appendTo(tThirdRow);
                $("<th>").text("3").appendTo(tThirdRow);
                $("<th>").text("4").appendTo(tThirdRow);
                $("<th>").text("5").appendTo(tThirdRow);
                $("<th>").text("6").appendTo(tThirdRow);
                $("<th>").text("7").appendTo(tThirdRow);
                $("<th>").text("8").appendTo(tThirdRow);
                $("<th>").text("9").appendTo(tThirdRow);
                $("<th>").text("10").appendTo(tThirdRow);

                tThirdRow.appendTo(tbody);

                for (var i = 1; i <= rows; i++) {
                    var trow = $("<tr>");
                    for (var c = 0; c < number_of_columns; c++) {
                        var td = $("<td>").addClass("tableCell").data("col", c).appendTo(trow);
                        switch (c) {
                            case 0:
                                $('<input name="txtPillarNo' + i + '" id="txtPillarNo' + i + '" type="text" style="width:40px" class="textAlign inputbox req" onkeypress="return OnlyNumber(event);" />').appendTo(td);
                                break;
                            case 1:
                                $('<input name="txtDistanceInChain' + i + '" id="txtDistanceInChain' + i + '" type="text" placeholder="Distance In Chain" class="textAlign req distance inputbox" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Distance from previous pillar" />').appendTo(td);
                                break;
                            case 2:
                                $('<input name="txtDistance' + i + '" id="txtDistance' + i + '" type="text" readonly="readonly" placeholder="Distance In Meter" class="textAlign req distance inputbox" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Distance from previous pillar" />').appendTo(td);
                                break;
                            case 3:
                                $('<input name="txtBackBearing' + i + '" id="txtBackBearing' + i + '" type="text" placeholder="Back Bearings" class="textAlign bearings inputbox brng req" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Back Bearings" />').appendTo(td);
                                break;
                            case 4:
                                $('<input name="txtBearingDifference' + i + '" id="txtBearingDifference' + i + '" type="text" placeholder="Bearings Difference" readonly="readonly" class="textAlign req bearings inputbox diff" onkeypress="return isNumberWithDot(this);" title="Bearings Difference" />').appendTo(td);
                                break;
                            case 5:
                                $('<input name="txtBearing' + i + '" id="txtBearing' + i + '" type="text" placeholder="Forward Bearings" class="textAlign bearings req inputbox brng" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Forward Bearings" />').appendTo(td);
                                break;
                            case 6:
                                $('<input name="txtLatitude' + i + '" id="txtLatitude' + i + '" type="text"  placeholder="Latitude" onchange="orthoDistMap();" class="textAlign req inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 7:
                                $('<input name="txtLongitude' + i + '" id="txtLongitude' + i + '" type="text"  placeholder="Longitude" class="textAlign inputbox req" onchange="orthoDistMap();" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
                                break;
                            case 8:
                                $('<input name="txtLatitudeField' + i + '" id="txtLatitudeField' + i + '" type="text"  placeholder="Latitude" class="textAlign inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 9:
                                $('<input name="txtLongitudeField' + i + '" id="txtLongitudeField' + i + '" type="text"  placeholder="Longitude" class="textAlign inputbox" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
                                break;
                        }

                    }
                    trow.appendTo(tbody);
                }
            });
        });

        function ConvertDDToDMD(dd) {
            var deg = dd | 0; // truncate dd to get degrees
            var frac = Math.abs(dd - deg); // get fractional part
            var min = (frac * 60).toFixed(4); // multiply fraction by 60 and truncate
            //var sec = frac * 3600 - min * 60;
            return deg + " " + min;
        }

        //---- Function when distance and Forward bearings given ------
        function orthoDestMap() {

            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();

            for (var i = 1; i <= numOfPillar; i++) {

                var lat1 = Geo.parseDMS($('#txtLatitude' + (i - 1)).val());
                var lon1 = Geo.parseDMS($('#txtLongitude' + (i - 1)).val());
                var brng = Geo.parseDMS($('#txtBearing' + (i - 1)).val());

                var dist = 0;

                //--- 1 Chain = 66 foot = 20.1168 meter
                if ($('#txtDistanceInChain' + i).val() != '') {
                    dist = $('#txtDistanceInChain' + i).val() * 20.1168 / 1000;
                    $('#txtDistance' + i).val(($('#txtDistanceInChain' + i).val() * 20.1168).toFixed(4));
                } else if ($('#txtDistance' + i).val() != '') {
                    dist = $('#txtDistance' + i).val() / 1000;
                    $('#txtDistanceInChain' + i).val(($('#txtDistance' + i).val() / 20.1168).toFixed(4));
                }

                var p1 = new LatLon(lat1, lon1);
                var p2 = p1.destinationPoint(brng, dist);
                var brngFinal = p1.bearingTo(p2);
                var brngBack = p2.finalBearingTo(p1);

                $('#txtLatitude' + i).val(Geo.toLat(p2.lat(), 'dm', 4)); //In DMS
                $('#txtLongitude' + i).val(Geo.toLon(p2.lon(), 'dm', 4));

                //                $('#txtLatitude' + i).val(ConvertDDToDMD(p2.lat().toFixed(7))); //In decimals
                //                $('#txtLongitude' + i).val(ConvertDDToDMD(p2.lon().toFixed(7)));

                //$('#txtBearing' + i).val(Geo.toBrng(brngFinal, degFmt));
                //-- $('#txtBackBearing' + i).val(Geo.toBrng(brngBack, degFmt));

                //------ Bearing Difference -------
                $('#txtBearingDifference' + i).val(Math.abs((parseFloat($('#txtBearing' + (i - 1)).val()) - parseFloat($('#txtBackBearing' + i).val()))).toFixed(3));
                //----------------------------

                if (i == numOfPillar) {
                    var lat0 = Geo.parseDMS($('#txtLatitude0').val());
                    var lon0 = Geo.parseDMS($('#txtLongitude0').val());

                    var p0 = new LatLon(lat0, lon0);
                    //-- $('#txtBackBearing0').val(Geo.toBrng(p0.finalBearingTo(p2), degFmt));

                    //-- $('#txtDistance0').val((p0.distanceTo(p2) * 1000).toFixed(4));
                    //-- $('#txtDistanceInChain0').val((p0.distanceTo(p2) * 1000 / 20.1168).toFixed(4));

                    //--  $('#txtBearing' + i).val(Geo.toBrng(p2.finalBearingTo(p0), degFmt));

                    //-- $('#txtBearingDifference0').val((parseFloat(Geo.toBrng(p2.bearingTo(p0), degFmt)) - parseFloat(Geo.toBrng(p0.bearingTo(p2), degFmt))).toFixed(3));
                    $('#txtBearingDifference0').val(Math.abs((parseFloat($('#txtBearing' + i).val()) - parseFloat($('#txtBackBearing0').val()))).toFixed(3));

                }

            }
        }

        //----- Function when points given ----
        function orthoDistMap() {

            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();

            for (var i = 1; i <= numOfPillar; i++) {

                var lat1 = Geo.parseDMS($('#txtLatitude' + (i - 1)).val());
                var lon1 = Geo.parseDMS($('#txtLongitude' + (i - 1)).val());

                var lat2 = Geo.parseDMS($('#txtLatitude' + i).val());
                var lon2 = Geo.parseDMS($('#txtLongitude' + i).val());

                var p1 = new LatLon(lat1, lon1);
                var p2 = new LatLon(lat2, lon2);

                $('#txtDistance' + i).val((p1.distanceTo(p2) * 1000).toFixed(4)); //Distance in Meters
                $('#txtDistanceInChain' + i).val(((p1.distanceTo(p2) * 1000) / 20.1168).toFixed(4)); //Distance in Chain; 1 Chain=20.1168 Meters


                $('#txtBearing' + (i - 1)).val(Geo.toBrng(p1.bearingTo(p2), degFmt));
                $('#txtBearing' + i).val(Geo.toBrng(p1.finalBearingTo(p2), degFmt));
                $('#txtBackBearing' + i).val(Geo.toBrng(p2.bearingTo(p1), degFmt));

                //------ Bearing Difference -------
                $('#txtBearingDifference' + i).val(Math.abs((parseFloat(Geo.toBrng(p1.bearingTo(p2), degFmt)) - parseFloat(Geo.toBrng(p2.bearingTo(p1), degFmt)))).toFixed(3));
                //----------------------------

                if (i == numOfPillar) {
                    var lat0 = Geo.parseDMS($('#txtLatitude0').val());
                    var lon0 = Geo.parseDMS($('#txtLongitude0').val());

                    var p0 = new LatLon(lat0, lon0);
                    $('#txtBackBearing0').val(Geo.toBrng(p0.bearingTo(p2), degFmt));
                    $('#txtBearing' + i).val(Geo.toBrng(p2.bearingTo(p0), degFmt));

                    $('#txtDistance0').val((p0.distanceTo(p2) * 1000).toFixed(4));
                    $('#txtDistanceInChain0').val((p0.distanceTo(p2) * 1000 / 20.1168).toFixed(4));
                    $('#txtBearingDifference0').val(Math.abs((parseFloat(Geo.toBrng(p2.bearingTo(p0), degFmt)) - parseFloat(Geo.toBrng(p0.bearingTo(p2), degFmt)))).toFixed(3));
                }
            }
        }

        //---- Function to calculate area and show map---
        function orthoMap() {
            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();
            var arr = new Array();
            var peri = 0;

            var i = 1;
            if ($('#<%:rdReference.ClientID%>').is(':checked')) { i = 2; }

            for (i; i <= numOfPillar; i++) {

                var lat1 = Geo.parseDMS($('#txtLatitude' + (i - 1)).val());
                var lon1 = Geo.parseDMS($('#txtLongitude' + (i - 1)).val());

                var lat2 = Geo.parseDMS($('#txtLatitude' + i).val());
                var lon2 = Geo.parseDMS($('#txtLongitude' + i).val());

                var dist = $('#txtDistance' + i).val();

                peri = parseFloat(peri) + parseFloat(dist);

                if (!isNaN(lat1 + lon1))
                    arr.push(lat1 + ',' + lon1);
                if (i == numOfPillar) {
                    if (!isNaN(lat2 + lon2))
                        arr.push(lat2 + ',' + lon2);
                }
            }
            //$('#perimeter').html(peri.toFixed(2));
            dibuV(arr);
        }

        function orthoMapField() {
            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();
            var arr = new Array();
            var peri = 0;

            var i = 1;
            if ($('#<%:rdReference.ClientID%>').is(':checked')) { i = 2; }

            for (i; i <= numOfPillar; i++) {
                var lat1 = 0;
                var lon1 = 0;
                if (i - 1 == 0) {
                    lat1 = Geo.parseDMS($('#txtLatitude' + (i - 1)).val());
                    lon1 = Geo.parseDMS($('#txtLongitude' + (i - 1)).val());
                }
                else {
                    lat1 = Geo.parseDMS($('#txtLatitudeField' + (i - 1)).val());
                    lon1 = Geo.parseDMS($('#txtLongitudeField' + (i - 1)).val());
                }

                var lat2 = Geo.parseDMS($('#txtLatitudeField' + i).val());
                var lon2 = Geo.parseDMS($('#txtLongitudeField' + i).val());

                if (!isNaN(lat1 + lon1))
                    arr.push(lat1 + ',' + lon1);
                if (i == numOfPillar) {
                    if (!isNaN(lat2 + lon2))
                        arr.push(lat2 + ',' + lon2);
                }
            }
            //$('#perimeter').html(peri.toFixed(2));
            dibuVF(arr);
        }
    </script>
    <script src="Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tooltipster.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        // if you use jQuery, you can load them when dom is read.
        $(document).ready(function () {
            jValid();
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
            <%if(Request["Code"]!=null){ %>

            var DTO = { 'id': <%:Request["Code"]%>};
                    $.ajax({
                        type: "POST",
                        url: "Services/AddArea.asmx/GetCoordinates",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) {

                        var rows = $('#<%:txtNoPillar.ClientID%>').val();

                for (var i = document.getElementById("tbl").rows.length; i > 0; i--) {
                    document.getElementById("tbl").deleteRow(i - 1);
                }

                var tbody = $("#tbl");
                var number_of_columns = 10;

                if (tbody == null || tbody.length < 1) return;

                var tfirstrow = $("<tr style='color:#000;'>");
                 $("<th rowspan=\"2\">").text("Pillar No.").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Distance from Previous Pillar (in Chains)").appendTo(tfirstrow);
                 $("<th rowspan=\"2\">").text("Distance from Previous Pillar (in Meters)").appendTo(tfirstrow);
               $("<th rowspan=\"2\">").text("Back Bearings (in Degree)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").html("Bearings Diff. (in Degree)<br/>(as calculated from data)").appendTo(tfirstrow);
                $("<th rowspan=\"2\">").text("Forward Bearings (in Degree)").appendTo(tfirstrow);
                $("<th colspan=\"2\">").html("GPS<br/>(as calculated from data)").appendTo(tfirstrow);
                $("<th colspan=\"2\">").text("Field Recorded GPS").appendTo(tfirstrow);

                tfirstrow.appendTo(tbody);
                var tSecondRow = $("<tr style='color:#000;'>");
                $("<th>").text("Latitude").appendTo(tSecondRow);
                $("<th>").text("Longitude").appendTo(tSecondRow);
                $("<th>").text("Latitude").appendTo(tSecondRow);
                $("<th>").text("Longitude").appendTo(tSecondRow);


                tSecondRow.appendTo(tbody);
                tSecondRow.appendTo(tbody);

                var tThirdRow = $("<tr style='color:#000;'>");
                $("<th>").text("1").appendTo(tThirdRow);
                $("<th>").text("2").appendTo(tThirdRow);
                $("<th>").text("3").appendTo(tThirdRow);
                $("<th>").text("4").appendTo(tThirdRow);
                $("<th>").text("5").appendTo(tThirdRow);
                $("<th>").text("6").appendTo(tThirdRow);
                $("<th>").text("7").appendTo(tThirdRow);
                $("<th>").text("8").appendTo(tThirdRow);
                $("<th>").text("9").appendTo(tThirdRow);
                $("<th>").text("10").appendTo(tThirdRow);

                tThirdRow.appendTo(tbody);
                for (var i = 1; i <= rows; i++) {
                    var trow = $("<tr>");
                    for (var c = 0; c < number_of_columns; c++) {
                        var td = $("<td>").addClass("tableCell").data("col", c).appendTo(trow);
                        switch (c) {
                            case 0:
                                $('<input name="hfId' + i + '" id="hfId' + i + '" value="'+response.d[i].Id+'" type="hidden" />').appendTo(td);
                                $('<input name="txtPillarNo' + i + '" id="txtPillarNo' + i + '" value="'+response.d[i].PillarNo+'" type="text" style="width:40px" class="textAlign inputbox req" onkeypress="return OnlyNumber(event);" />').appendTo(td);
                                break;
                            case 1:
                                 $('<input name="txtDistanceInChain' + i + '" id="txtDistanceInChain' + i + '" value="'+response.d[i].BackDistanceInChain+'" type="text" placeholder="Distance In Chain" class="textAlign req distance inputbox" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Distance from previous pillar" />').appendTo(td);
                               break;
                            case 2:
                                $('<input name="txtDistance' + i + '" id="txtDistance' + i + '" readonly="readonly" value="'+response.d[i].BackDistanceInMeter+'" type="text" placeholder="Distance In Meter" class="textAlign distance inputbox req" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Distance from previous pillar" />').appendTo(td);
                                break;
                            case 3:
                                $('<input name="txtBackBearing' + i + '" id="txtBackBearing' + i + '" value="'+response.d[i].BackBearings+'" type="text" placeholder="Back Bearings" class="textAlign bearings inputbox brng req" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Back Bearings" />').appendTo(td);
                                break;
                            case 4:
                                $('<input name="txtBearingDifference' + i + '" id="txtBearingDifference' + i + '" value="'+response.d[i].BearingDifference+'" type="text" placeholder="Bearings Difference" readonly="readonly" class="textAlign req bearings inputbox diff" onkeypress="return isNumberWithDot(this);" title="Bearings Difference" />').appendTo(td);
                                break;
                            case 5:
                                $('<input name="txtBearing' + i + '" id="txtBearing' + i + '" type="text" placeholder="Forward Bearings" value="'+response.d[i].ForwardBearings+'" class="textAlign bearings req inputbox brng" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this);" title="Forward Bearings" />').appendTo(td);
                                break;
                            case 6:
                                $('<input name="txtLatitude' + i + '" id="txtLatitude' + i + '" value="'+response.d[i].Latitude+'" type="text"  placeholder="Latitude" onchange="orthoDistMap();" class="textAlign req inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 7:
                                $('<input name="txtLongitude' + i + '" id="txtLongitude' + i + '" value="'+response.d[i].Longitude+'" type="text"  placeholder="Longitude" class="textAlign inputbox req" onchange="orthoDistMap();" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
                                break;
                            case 8:
                                $('<input name="txtLatitudeField' + i + '" id="txtLatitudeField' + i + '" value="'+response.d[i].LatitudeField+'" type="text"  placeholder="Latitude" class="textAlign inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 9:
                                $('<input name="txtLongitudeField' + i + '" id="txtLongitudeField' + i + '" value="'+response.d[i].LongitudeField+'" type="text"  placeholder="Longitude" class="textAlign inputbox" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
                                break;

                        }                                                                                
                        
                    }
                    trow.appendTo(tbody);
               }
           },
           error: function (response) {
                 console.log(response);
           }
        }).done(function () {

             orthoMap();
             orthoMapField();
        });
    <%} %>
});

        function jValid() {

            $(document).ajaxStart(function () {
                $("#imgLoader").css("display", "block");
                $("#btnSubmit").attr("disabled", true);
            });
            $(document).ajaxComplete(function () {
                $("#imgLoader").css("display", "none");
                $("#btnSubmit").attr("disabled", false);
            });


            $("#form1").validate({
                highlight: function (element) {
                    $(element).addClass('error');
                }, unhighlight: function (element) {
                    $(element).removeClass('error');
                }, errorPlacement: function (error, element) {
                    $(element).tooltipster('update', $(error).text());
                    $(element).tooltipster('show');
                },
                success: function (label, element) {
                    $(element).tooltipster('hide');
                }
            });

            $("#btnSubmit").click(function (evt) {

                $('#form1 input[type="text"],.ddl').tooltipster({
                    trigger: 'custom', // default is 'hover' which is no good here
                    onlyOne: false,    // allow multiple tips to be open at a time
                    position: 'right'  // display the tips to the right of the element
                });

                // adding rules for inputs
//                $('input.req').each(function () {
//                    $(this).rules("add",
//                    {
//                        required: true
//                    })
//                });
                $('.ddl').each(function () {
                    $(this).rules("add",
                    {
                        required: true
                    })
                });
                $('input.diff').each(function () {
                    $(this).rules("add",
                    {
                        range: [179.9, 180.1],
                        messages: {
                            range: "Please correct your bearings! Difference should be 180."
                        }
                    })
                });
                $('input.brng').each(function () {
                    $(this).rules("add",
                    {
                        range: [0, 360],
                        messages: {
                            range: "Please enter correct bearings! Bearings should be 0 to 360."
                        }
                    })
                });
                // prevent default submit action         
                event.preventDefault();

                // test if form is valid 
                if ($('#form1').validate().form()) {

                    var forestArea = {};

                    <%if(Request["Code"]!=null){ %>
                    forestArea.Id =<%:Request["Code"] %>;
                    forestArea.UpdatedBy='<%:((MAPS.LoginMaster)Session["User"]).UserId %>'
                    <%} %>
                    forestArea.forestType = $('#<%:ddlForestType.ClientID%>').val();
                    forestArea.NumberOfPillars = (parseInt($('#<%:txtNoPillar.ClientID%>').val()) + 1);

                    forestArea.isReferencePoint = $('#rdReference').is(':checked');
                    forestArea.AreaCalculated = $('#<%:areaM.ClientID%>').val();
                    forestArea.AreaInField = $('#<%:areaMF.ClientID%>').val();

                    forestArea.ForestName = $('#<%:txtForestName.ClientID%>').val();
                    forestArea.AreaInGazette = $('#<%:txtGazetteArea.ClientID%>').val();
                    forestArea.BlockId = $('#<%:ddlBlock.ClientID%>').val();
                    forestArea.VillageId = $('#<%:ddlVillage.ClientID%>').val();

                    forestArea.GazetteDate = $('#<%:txtGazetteDate.ClientID%>').val().split("/").reverse().join("-");;
                    forestArea.GazetteNo = $('#<%:txtGazetteNumber.ClientID%>').val();

                    forestArea.CreatedBy='<%:((MAPS.LoginMaster)Session["User"]).UserId %>'

                    var json = { "forestCoordinates": [] };

                    var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();

                    var i = 0;
                    for (i; i <= numOfPillar; i++) {

                        json.forestCoordinates.push({<%if(Request["Code"]!=null){ %>id: $('#hfId' + i).val(),<%} %> pillarNo: $('#txtPillarNo' + i).val(), latitude: $('#txtLatitude' + i).val(), longitude: $('#txtLongitude' + i).val(), forwardBearings: $('#txtBearing' + i).val(), backBearings: $('#txtBackBearing' + i).val(), backDistanceInMeter: $('#txtDistance' + i).val(), backDistanceInChain: $('#txtDistanceInChain' + i).val(),bearingDifference:$('#txtBearingDifference' + i).val(), latitudeField: $('#txtLatitudeField' + i).val(), longitudeField: $('#txtLongitudeField' + i).val() });
                    }
                    //--------- If block is other insert it first-----------------
                    if($('#<%:ddlBlock.ClientID%>').val()=='OT'){
                        var block = {};
                        if($('#<%:ddlBeat.ClientID%>').val()!="s"){
                            block.sectionId=$('#<%:ddlBeat.ClientID%>').val();
                        }
                        block.rangeId=$('#<%:ddlRange.ClientID%>').val();
                        block.blockName=$('#<%:txtBlock.ClientID%>').val();

                        var dtoBlock={'block': block };

                        $.ajax({
                        type: "POST",
                        url: "Services/AddArea.asmx/InsertBlock",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',async: false,
                        data: JSON.stringify(dtoBlock),
                        success: function (response) {
                            forestArea.BlockId = response.d;// Assign added blockId to forest Area.

                            //----------- Insert Village if Other -------------
                    if($('#<%:ddlVillage.ClientID%>').val()=='OT'){
                        var village = {};
                        
                        village.tehsilId=$('#<%:ddlTehsil.ClientID%>').val();
                        village.VillageName=$('#<%:txtVillage.ClientID%>').val();
                        village.BlockId=forestArea.BlockId;

                        var dtoVillage={'village': village };

                        $.ajax({
                        type: "POST",
                        url: "Services/AddArea.asmx/InsertVillage",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',async: false,
                        data: JSON.stringify(dtoVillage),
                        success: function (response) {
                            forestArea.VillageId = response.d;// Assign added villageId to forest Area.
                            },
                        error: function (response) {
                            console.log(response);
                        }
                        }).done(function () {});
                        }
                    //---------------------------------------------------------------//

                            var DTO = { 'forestArea': forestArea, 'forestCoordinates': json.forestCoordinates };
                    $.ajax({
                        type: "POST",
                        <%if(Request["Code"]!=null){ %>url: "Services/AddArea.asmx/UpdateArea",<%} %>
                        <%else{ %>url: "Services/AddArea.asmx/InsertArea",<%} %>
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',async: false,
                        data: JSON.stringify(DTO),
                        success: function (response) {
                            var areaId = response.d;
                            <%if(Request["Code"]==null){ %>
                            uploadFile(areaId);<%} %>
                            console.log(response);
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    }).done(function () {
                     <%if(Request["Code"]!=null){ %>
                        alert("Data saved successfully.");<%} %>
                        <%else{ %>alert("Data updated successfully.");<%} %>
                    });
                            console.log(response);
                        },
                        error: function (response) {
                            console.log(response);
                        }
                        }).done(function () {

                    });
                    }
                    //------------------------------------------------------------
                    else{
                    //----------- Insert Village if Other -------------
                    if($('#<%:ddlVillage.ClientID%>').val()=='OT'){
                        var village = {};
                        
                        village.tehsilId=$('#<%:ddlTehsil.ClientID%>').val();
                        village.VillageName=$('#<%:txtVillage.ClientID%>').val();
                        village.BlockId=forestArea.BlockId;

                        var dtoVillage={'village': village };

                        $.ajax({
                        type: "POST",
                        url: "Services/AddArea.asmx/InsertVillage",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',async: false,
                        data: JSON.stringify(dtoVillage),
                        success: function (response) {
                            forestArea.VillageId = response.d;// Assign added villageId to forest Area.
                            },
                        error: function (response) {
                            console.log(response);
                        }
                        }).done(function () {});
                        }
                    //---------------------------------------------------------------//
                    var DTO = { 'forestArea': forestArea, 'forestCoordinates': json.forestCoordinates};
                    $.ajax({
                        type: "POST",
                        <%if(Request["Code"]!=null){ %>url: "Services/AddArea.asmx/UpdateArea",<%} %>
                        <%else{ %>url: "Services/AddArea.asmx/InsertArea",<%} %>
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',async: false,
                        data: JSON.stringify(DTO),
                        success: function (response) {
                            var areaId = response.d;
                            <%if(Request["Code"]==null){ %>
                            uploadFile(areaId);<%} %>
                            console.log(response);
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    }).done(function () {
                     <%if(Request["Code"]==null){ %>
                        alert("Data saved successfully.");<%} %>
                        <%else{ %>alert("Data updated successfully.");<%} %>
                    });

                    console.log("validates");
                    }
                } else {
                    console.log("does not validate");
                }
                // Validate the form and retain the result.
                var isValid = $("#form1").valid();

                // If the form didn't validate, prevent the
                //  form submission.
                if (!isValid)
                    evt.preventDefault();
            });
        }
    </script>
    <script type="text/javascript">
        var currFile = 0;
        var totalFileCount = 0;
        // check extension of file to be upload
        function checkFileExtension() {
            var flag = true;
            var file = $("#fileInput")[0].files[0];
            var extension = file.name.substr((file.name.lastIndexOf('.') + 1));
            var size = (file.size) / 1048576;

            if (size > 6) {
                alert('Please select an Image file less than 6 mb.');
                $("#fileInput").replaceWith($("#fileInput").clone());
                return false;
            }

            switch (extension) {
                case 'jpg':
                case 'jpeg':

                case 'JPG':
                case 'JPEG':
                    flag = true;
                    break;
                default:
                    flag = false;
            }
            if (flag == false) {
                alert('Please select a jpg file.');
                $("#fileInput").replaceWith($("#fileInput").clone());
            }
            
            return flag;

        }
        function uploadFile(sFileName) {
            //            currFile = 0;
            //            var aFile = $('#fileInput').val();
            //            if (aFile != "" && aFile != null) {
            //                sendFile($("#fileInput")[0].files[0], sFileName);
            //            }
            var DTO = { 'name': sFileName,'strCode':<%:strCode %> };
            $.ajax({
                type: "post",
                url: "Services/AddArea.asmx/RenameImage",
                contentType: "application/json; charset=utf-8",
                dataType: "json",async: false,
                //data: '{"name":"' + sFileName + '"}',
                data: JSON.stringify(DTO),
                success: function (result) {
                    //OnSuccess(result.d);
                },
                error: function (xhr, status, error) {
                    OnFailure(error);
                }
            });

        } function OnFailure(error) {
            alert(error);
        }
    </script>
    <script src="Scripts/jquery.fancybox-1.3.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        // if you use jQuery, you can load them when dom is read.
        $(document).ready(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            $("a[rel=example_group]").fancybox({ 'transitionIn': 'none', 'transitionOut': 'none', 'titlePosition': 'over' });
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
        });

        function InitializeRequest(sender, args) {
            $("a[rel=example_group]").fancybox({ 'transitionIn': 'none', 'transitionOut': 'none', 'titlePosition': 'over' });
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
        }

        function EndRequest(sender, args) {
            $("a[rel=example_group]").fancybox({ 'transitionIn': 'none', 'transitionOut': 'none', 'titlePosition': 'over' });
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
        }
        
    </script>
</asp:Content>
