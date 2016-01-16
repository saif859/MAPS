<%@ Page Title="वन क्षेत्र" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ForestAreaEdit.aspx.cs" Inherits="MAPS.ForestAreaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="Content/tooltipster.css" rel="stylesheet" type="text/css" />
    <%: System.Web.Optimization.Styles.Render("~/css/ui") %>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/jqueryui") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upGV" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gra">
                <tbody>
                    <tr class="perp_group_row">
                        <td class="perp_group_cell perp_group_cell_label">
                            <label for="" class=" perp_label sa_text_right">
                                Zone</label>
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
                                Circle</label>
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
                                Division</label>
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
                                Sub Division</label>
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
                                Range</label>
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
                                Section</label>
                        </td>
                        <td class="perp_group_cell">
                            <span class="perp_field perp_field_char">
                                <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" CssClass="ddl"
                                    OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </td>
                        <td class="perp_group_cell perp_group_cell_label" colspan="2">
                            <label for="" class=" perp_label sa_text_right">
                                Block</label>
                        </td>
                        <td class="perp_group_cell" colspan="2">
                            <span class="perp_field perp_field_char">
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="ddl" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtBlock" runat="server" Visible="false" CssClass="inputbox req"></asp:TextBox>
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
                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" CssClass="ddl"
                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </td>
                        <td class="perp_group_cell perp_group_cell_label">
                            <label for="" class=" perp_label sa_text_right">
                                Tehsil</label>
                        </td>
                        <td class="perp_group_cell">
                            <span class="perp_field perp_field_char">
                                <asp:DropDownList ID="ddlTehsil" runat="server" AutoPostBack="true" CssClass="ddl"
                                    OnSelectedIndexChanged="ddlTehsil_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </td>
                        <td class="perp_group_cell perp_group_cell_label" colspan="2">
                            <label for="" class=" perp_label sa_text_right">
                                Village</label>
                        </td>
                        <td class="perp_group_cell" colspan="2">
                            <span class="perp_field perp_field_char">
                                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddl">
                                </asp:DropDownList>
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
                                    <asp:ListItem Text="UnReserved" Value="U" />
                                    <asp:ListItem Text="Cadastral" Value="C" />
                                    <asp:ListItem Text="Other" Value="O" />
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
    <div style="padding: 5px; color: #000; background: #f4f4f4; font-size: 12px;">
        <asp:RadioButton ID="rdFirstPillar" runat="server" Text="First Pillar Co-ordinates"
            class="rd" GroupName="rd" Checked="true" />&nbsp;<asp:RadioButton GroupName="rd"
                ID="rdReference" runat="server" Text="Reference Co-ordinates" class="rd" />
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table" style="display: none;">
        <tr style="color: #446e00;">
            <th>
                Pillar No.
            </th>
            <th>
                Latitude
            </th>
            <th>
                Longitude
            </th>
            <th>
                Forward Bearings
            </th>
            <th>
                Bearings Diff.
            </th>
            <th>
                Back Bearings
            </th>
            <th>
                Back Chains
            </th>
            <th>
                Back Meters
            </th>
        </tr>
        <tr>
            <td align="center" valign="top">
                <input name="txtPillarNo0" id="txtPillarNo0" type="text" style="width: 40px" class="textAlign form-control"
                    onkeypress="return OnlyNumber(event);" value='<%:Request["Code"]!=null?queryCo.First().PillarNo:"" %>' />
            </td>
            <td align="center" valign="top">
                <input type="text" id="txtLatitude0" name="txtLatitude0" class="textAlign form-control"
                    placeholder="Latitude" onkeypress="return isNumberWithDot(this.Id);" onchange="orthoDestMap();"
                    title="Latitude" value='<%:Request["Code"]!=null?queryCo.First().Latitude:"" %>'>
            </td>
            <td align="center" valign="top">
                <input type="text" name="txtLongitude0" id="txtLongitude0" class="textAlign form-control"
                    placeholder="Longitude" onkeypress="return isNumberWithDot(this.Id);" onchange="orthoDestMap();"
                    title="Longitude" value='<%:Request["Code"]!=null?queryCo.First().Longitude:"" %>'>
            </td>
            <td align="center" valign="top">
                <input type="text" name="txtBearing0" id="txtBearing0" class="textAlign bearings form-control brng"
                    onkeypress="return isNumberWithDot(this.Id);" placeholder="Bearings" onchange="orthoDestMap();"
                    title="Bearings" value='<%:Request["Code"]!=null?queryCo.First().ForwardBearings:"" %>'>
            </td>
            <td align="center" valign="top">
                <input name="txtBearingDifference0" id="txtBearingDifference0" type="text" placeholder="Bearings Difference"
                    class="textAlign bearings form-control diff" onkeypress="return isNumberWithDot(this.Id);"
                    readonly="readonly" title="Bearings Difference" />
            </td>
            <td align="center" valign="top">
                <input type="text" name="txtBackBearing0" id="txtBackBearing0" class="textAlign bearings form-control brng"
                    onkeypress="return isNumberWithDot(this.Id);" placeholder="Back Bearings" onchange="orthoDestMap();"
                    title="Back Bearings" value='<%:Request["Code"]!=null?queryCo.First().BackBearings:"" %>'>
            </td>
            <td align="center" valign="top">
                <input type="text" name="txtDistanceC0" id="txtDistanceInChain0" class="textAlign distance form-control"
                    onkeypress="return isNumberWithDot(this.Id);" placeholder="Distance from last Pillar"
                    onchange="orthoDestMap();" title="Distance from last Pillar" value='<%:Request["Code"]!=null?queryCo.First().BackDistanceInChain.ToString():"" %>'>
            </td>
            <td align="center" valign="top">
                <input type="text" name="txtDistance0" id="txtDistance0" class="textAlign distance form-control"
                    onkeypress="return isNumberWithDot(this.Id);" placeholder="Distance from last Pillar"
                    onchange="orthoDestMap();" title="Distance from last Pillar" value='<%:Request["Code"]!=null?queryCo.First().BackDistanceInMeter.ToString():"" %>'>
            </td>
        </tr>
    </table>
    <br />
    <div class="clr">
    </div>
    <div class="NumPillar">
        <table width="45%" border="0" cellpadding="5" cellspacing="5" align="center">
            <tr>
                <td width="26%" valign="middle" align="left">
                    <div>
                        Number of Pillar :</div>
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtNoPillar" runat="server" onkeypress="return OnlyNumber(event);"
                        Style="width: 40px;" class="textAlign form-control" placeholder="No." title="Number of Pillar"></asp:TextBox>
                </td>
                <td width="36%" align="center">
                    <input id="Button1" type="button" value="Calculate Area" onclick="orthoMap();" class="buttonM button-green"
                        style="display: none;" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clr">
    </div>
    <div style="margin-top: 10px;">
        <table>
            <tr>
                <td>
                    Computed Area : &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="areaM" runat="server" Style="width: 100px;" class="textAlign form-control"
                        ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    m²,
                </td>
                <td>
                    <asp:TextBox ID="areaH" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign form-control"></asp:TextBox>
                </td>
                <td>
                    Ha,
                </td>
                <td>
                    <asp:TextBox ID="areaA" runat="server" ReadOnly="true" Style="width: 100px;" class="textAlign form-control"></asp:TextBox>
                </td>
                <td>
                    Acre
                </td>
            </tr>
        </table>
    </div>
    <div class="clr">
    </div>
    <div style="width: 100%; margin-top: 10px;">
        <div style="width: 13%; float: left; padding-top: 10px;">
            Area in Gazette :
        </div>
        <div style="width: 14%; float: left;">
            <asp:TextBox ID="txtGazetteArea" runat="server" class="textAlign form-control" onkeypress="return isNumberWithDot(this.Id);"
                placeholder="Area in Gazette"></asp:TextBox>
        </div>
        <div style="width: 13%; float: left; padding-top: 10px; margin-left: 2%;">
            Gazette Number :
        </div>
        <div style="width: 14%; float: left;">
            <asp:TextBox ID="txtGazetteNumber" runat="server" class="form-control" placeholder="Gazette Number"
                title="Gazette Number"></asp:TextBox>
        </div>
        <div style="width: 11%; float: left; padding-top: 10px; margin-left: 2%;">
            Gazette Date :
        </div>
        <div style="width: 14%; float: left;">
            <asp:TextBox ID="txtGazetteDate" runat="server" Style="width: 90px;" class="form-control jDate"
                placeholder="Gazette Date" title="Gazette Date"></asp:TextBox>
        </div>
    </div>
    <div id="divTable">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%"
            border="0" CellPadding="0" CellSpacing="0" class="table" HeaderStyle-ForeColor="#446e00">
            <Columns>
                <asp:BoundField DataField="PillarNo" HeaderText="Pillar No." />
                <asp:BoundField DataField="BackDistanceInMeter" HeaderText="Meters" />
                <asp:BoundField DataField="BackDistanceInChain" HeaderText="Chains" />
                <asp:BoundField DataField="BackBearings" HeaderText="Back Bearings" />
                <asp:BoundField DataField="BearingDifference" HeaderText="Bearing Diff." />
                <asp:BoundField DataField="ForwardBearings" HeaderText="Forward Bearings" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
            </Columns>
        </asp:GridView>
    </div>
    
    <div id="map_canvas" style="height: 600px; width: 800px; margin: 5px auto;">
    </div>
    <script src="Scripts/latlon.js" type="text/javascript" />
    <script src="Scripts/geo.js" type="text/javascript" />
    <script src="Scripts/main.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=geometry&sensor=false"></script>
    <script type="text/javascript" src="Scripts/infobox.js"></script>
    <script src="Scripts/ptpl.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var labels = [];
        var map;
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

        google.maps.event.addListener(map, "zoom_changed", function () {
            if (map.getZoom() < 11) {
                for (var i = 0; i < labels.length; i++) {
                    labels[i].setMap(null);
                }
            }
        });
        function dibuV(area) {

            //initialize();

            var a = new Array();

            for (var i = 0; i < area.length; i++) {
                var uno = area[i].split(",");
                a[i] = new google.maps.LatLng(uno[0], uno[1]);
                //bounds.extend(a[i]);

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
                strokeColor: "#22B14C",
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: "#22B14C",
                fillOpacity: 0.35
            })

            //poligon.setMap(map);
            var z = google.maps.geometry.spherical.computeArea(poligon.getPath().getArray());

            //            labels.push(new InfoBox({ content: z.toFixed(2) + ' m&sup2;', boxStyle: { border: "1px solid black", textAlign: "center", backgroundColor: "white", fontSize: "10pt", width: "auto" }
            //	                            , disableAutoPan: true
            //	                            , pixelOffset: new google.maps.Size(-45, 0)
            //	                            , position: bounds.getCenter()
            //	                            , closeBoxURL: ""
            //	                            , isHidden: false
            //	                            , enableEventPropagation: true
            //            }
            //                             ));
            //labels[labels.length - 1].open(map);

            //map.setCenter(bounds.getCenter());
            //map.fitBounds(bounds);

            $('#areaM').val(z.toFixed(2)); // Area in Sq. Meter
            $('#areaH').val((z / 10000).toFixed(2)); // Area in Hectare
            $('#areaA').val((z / 4046.86).toFixed(2)); // Area in Acre
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

            $('#<%:txtNoPillar.ClientID%>').change(function () {
                var rows = $('#<%:txtNoPillar.ClientID%>').val();

                for (var i = document.getElementById("tbl").rows.length; i > 0; i--) {
                    document.getElementById("tbl").deleteRow(i - 1);
                }

                var tbody = $("#tbl");
                var number_of_columns = 8;

                if (tbody == null || tbody.length < 1) return;

                var tfirstrow = $("<tr style='color:#446e00;'>");
                $("<th>").text("Pillar No.").appendTo(tfirstrow);
                $("<th>").text("Meters").appendTo(tfirstrow);
                $("<th>").text("Chains").appendTo(tfirstrow);
                $("<th>").text("Back Bearings").appendTo(tfirstrow);
                $("<th>").text("Bearings Diff.").appendTo(tfirstrow);
                $("<th>").text("Forward Bearings").appendTo(tfirstrow);
                $("<th>").text("Latitude").appendTo(tfirstrow);
                $("<th>").text("Longitude").appendTo(tfirstrow);

                tfirstrow.appendTo(tbody);
                <%int j=0; %>
                for (var i = 1; i <= rows; i++) {
                    var trow = $("<tr>");
                    for (var c = 0; c < number_of_columns; c++) {
                    <%j++; %>
                        var td = $("<td>").addClass("tableCell").data("col", c).appendTo(trow);
                        switch (c) {
                            case 0:
                                $('<input name="txtPillarNo' + i + '" id="txtPillarNo' + i + '" value="<%:Request["Code"]!=null?queryCo[j].PillarNo:"" %>" type="text" style="width:40px" class="textAlign form-control" onkeypress="return OnlyNumber(event);" />').appendTo(td);
                                break;
                            case 1:
                                $('<input name="txtDistance' + i + '" id="txtDistance' + i + '" type="text" placeholder="Distance In Meter" class="textAlign distance form-control" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this.Id);" title="Distance from previous pillar" />').appendTo(td);
                                break;
                            case 2:
                                $('<input name="txtDistanceInChain' + i + '" id="txtDistanceInChain' + i + '" type="text" placeholder="Distance In Chain" class="textAlign distance form-control" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this.Id);" title="Distance from previous pillar" />').appendTo(td);
                                break;
                            case 3:
                                $('<input name="txtBackBearing' + i + '" id="txtBackBearing' + i + '" type="text" placeholder="Back Bearings" class="textAlign bearings form-control brng" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this.Id);" title="Back Bearings" />').appendTo(td);
                                break;
                            case 4:
                                $('<input name="txtBearingDifference' + i + '" id="txtBearingDifference' + i + '" type="text" placeholder="Bearings Difference" readonly="readonly" class="textAlign bearings form-control diff" onkeypress="return isNumberWithDot(this.Id);" title="Bearings Difference" />').appendTo(td);
                                break;
                            case 5:
                                $('<input name="txtBearing' + i + '" id="txtBearing' + i + '" type="text" placeholder="Forward Bearings" class="textAlign bearings form-control brng" onchange="orthoDestMap();" onkeypress="return isNumberWithDot(this.Id);" title="Forward Bearings" />').appendTo(td);
                                break;
                            case 6:
                                $('<input name="txtLatitude' + i + '" id="txtLatitude' + i + '" type="text"  placeholder="Latitude" onchange="orthoDistMap();" class="textAlign form-control" onkeypress="return isNumberWithDot(this.Id);" title="Latitude" />').appendTo(td);
                                break;
                            case 7:
                                $('<input name="txtLongitude' + i + '" id="txtLongitude' + i + '" type="text"  placeholder="Longitude" class="textAlign form-control" onchange="orthoDistMap();" onkeypress="return isNumberWithDot(this.Id);"  title="Longitude" />').appendTo(td);
                                break;
                        }                                                                                
                        
                    }
                    trow.appendTo(tbody);
               }
            });
        });

        //---- Function when distance and Forward bearings given ------
        function orthoDestMap() {

            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();

            for (var i = 1; i <= numOfPillar; i++) {

                var lat1 = Geo.parseDMS($('#txtLatitude' + (i - 1)).val());
                var lon1 = Geo.parseDMS($('#txtLongitude' + (i - 1)).val());
                var brng = Geo.parseDMS($('#txtBearing' + (i - 1)).val());

                var dist = 0;

                //--- 1 Chain = 60 foot = 20.1168 meter
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

                //$('#txtLatitude' + i).val(Geo.toLat(p2.lat(), 'dms', 1)); //In DMS
                //$('#txtLongitude' + i).val(Geo.toLon(p2.lon(), 'dms', 1));

                $('#txtLatitude' + i).val(p2.lat().toFixed(7)); //In decimals
                $('#txtLongitude' + i).val(p2.lon().toFixed(7));

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
    </script>
    <script src="Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tooltipster.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        // if you use jQuery, you can load them when dom is read.
        $(document).ready(function () {
            //            var prm = Sys.WebForms.PageRequestManager.getInstance();
            //            prm.add_initializeRequest(InitializeRequest);
            //            prm.add_endRequest(EndRequest);

            //            // Place here the first init of the DatePicker
            jValid();
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
            <%if(Request["Code"]!=null){ %>
            $('#<%:txtNoPillar.ClientID%>').change();
            <%} %>
        });

        function InitializeRequest(sender, args) {
            // make unbind to avoid memory leaks.
            jValid();
            $(".jDate").unbind();
        }

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the DatePicker
            jValid();
            $(".jDate").datepicker({ dateFormat: 'dd/mm/yy' });
        }
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
                $('input[type="text"]').each(function () {
                    $(this).rules("add",
                    {
                        required: true
                    })
                });
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

                    forestArea.forestType = $('#<%:ddlForestType.ClientID%>').val();
                    forestArea.NumberOfPillars = (parseInt($('#<%:txtNoPillar.ClientID%>').val()) + 1);
                    forestArea.isReferencePoint = $('#rdReference').is(':checked');
                    forestArea.AreaCalculated = $('#<%:areaM.ClientID%>').val();

                    forestArea.ForestName = $('#<%:txtForestName.ClientID%>').val();
                    forestArea.AreaInGazette = $('#<%:txtGazetteArea.ClientID%>').val();
                    forestArea.BlockId = $('#<%:ddlBlock.ClientID%>').val();
                    forestArea.VillageId = $('#<%:ddlVillage.ClientID%>').val();

                    forestArea.GazetteDate = $('#<%:txtGazetteDate.ClientID%>').val();
                    forestArea.GazetteNo = $('#<%:txtGazetteNumber.ClientID%>').val();

                    var json = { "forestCoordinates": [] };
                    var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();
                    var i = 0;
                    for (i; i <= numOfPillar; i++) {

                        json.forestCoordinates.push({ pillarNo: $('#txtPillarNo' + i).val(), latitude: $('#txtLatitude' + i).val(), longitude: $('#txtLongitude' + i).val(), forwardBearings: $('#txtBearing' + i).val(), backBearings: $('#txtBackBearing' + i).val(), backDistanceInMeter: $('#txtDistance' + i).val(), backDistanceInChain: $('#txtDistanceInChain' + i).val() });
                    }

                    // Create a data transfer object (DTO) with the proper structure.
                    var DTO = { 'forestArea': forestArea, 'forestCoordinates': json.forestCoordinates };
                    $.ajax({
                        type: "POST",
                        url: "Services/AddArea.asmx/InsertArea",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) {
                            var areaId = response.d;
                            console.log(response);
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    }).done(function () {
                        alert("Data saved successfully.");
                    });

                    console.log("validates");
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
</asp:Content>
