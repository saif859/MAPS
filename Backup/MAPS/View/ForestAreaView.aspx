<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true"
    CodeBehind="ForestAreaView.aspx.cs" Inherits="MAPS.View.ForestAreaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/StyleSheet.css" rel="Stylesheet" type="text/css" />
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
    </div>
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
                            <table class="perp_group" width="100%">
                                <tr>
                                    <td align="right" width="20%">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr class="perp_group_cell">
                                    <td class="perp_group_cell perp_group_cell_label" align="left" width="20%">
                                        <asp:Label ID="Label1" class=" perp_label sa_text_right" runat="server" Text=" Block :"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblBlock" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" width="20%">
                                        Village :
                                    </td>
                                    <td align="left" width="20%">
                                        <asp:Label ID="lblVillage" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="left" width="27%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="20%">
                                        Area computed based on chainage and bearings :
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblComptedArea" runat="server" Text="0"></asp:Label>
                                        (Ha) ,
                                        <asp:Label ID="lblComptedAreaS" runat="server" Text="0"></asp:Label>
                                        (Acres)
                                    </td>
                                    <td align="left" colspan="2">
                                        Area computed based on field entry of GPS coordinates :
                                    </td>
                                    <td align="left" width="27%">
                                        <asp:Label ID="lblComutedAreaF" runat="server" Text="0"></asp:Label>
                                        (Ha) ,
                                        <asp:Label ID="lblComputedAreaHf" runat="server" Text="0"></asp:Label>
                                        (Acres)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" width="20%">
                                        &nbsp;
                                    </td>
                                    <td colspan="2" width="30%">
                                        &nbsp;
                                    </td>
                                    <td colspan="2" width="60%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Area in Gazette :
                                    </td>
                                    <td align="left" width="15%">
                                        <asp:Label ID="lblAreaGaz" runat="server" Text="0"></asp:Label>
                                        (Acres)
                                    </td>
                                    <td align="right" width="15%">
                                        Gazette Number :
                                    </td>
                                    <td align="left" width="5%">
                                        <asp:Label ID="lblGazNo" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="left" width="15%">
                                        Gazette Date :
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblGazDate" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" class="tableContainer">
                            <asp:GridView ID="GridView1" Visible="false" Width="90%" AutoGenerateColumns="False"
                                runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" CellSpacing="2">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Pillar">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPillar" runat="server" Text='<%#Eval("PillarNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GPS(Latitude)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLattitude" runat="server" Text='<%#Eval("Latitude") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GPS(Longitude)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLongitude" runat="server" Text='<%#Eval("Longitude") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forward Bearings (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfwdbearing" runat="server" Text='<%#Eval("ForwardBearings") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bearings Diff. (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbearingdiff" runat="server" Text='<%#Eval("BearingDifference") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Back Bearings (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbackbearing" runat="server" Text='<%#Eval("BackBearings") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distance">
                                        <ItemTemplate>
                                            <asp:Label ID="DistPrevPillar" runat="server" Text='<%#Eval("BackDistanceInChain") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distance from Previous Pillar (in Meters)">
                                        <ItemTemplate>
                                            <asp:Label ID="DistPrevPillarM" runat="server" Text='<%#Eval("BackDistanceInMeter") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="40px"
                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="30px" HorizontalAlign="Center"
                                    VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
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
                                    <asp:TemplateField HeaderText="Back Bearings (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label13" runat="server" Text='<%#Eval("BackBearings") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bearing Diff. (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label14" runat="server" Text='<%#Eval("BearingDifference") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forward Bearing (in Degree)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label15" runat="server" Text='<%#Eval("ForwardBearings") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GPS(Lattitude)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label16" runat="server" Text='<%#Eval("Latitude") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GPS(Longitude)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label17" runat="server" Text='<%#Eval("Longitude") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distance from Previous Pillar (in Chains)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("BackDistanceInChain") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distance from Previous Pillar (in Meters)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("BackDistanceInMeter") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <SortedAscendingCellStyle BorderWidth="1px" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:TextBox ID="txtNoPillar" runat="server" Style="width: 40px; display: none;"></asp:TextBox>
            </asp:Panel>
            Map generated on the chainage and bearings filled above<a href="../Map.kml" target="_blank"
                style="color: Blue;"> click to download KML file </a>
            <div id="map_canvas" style="height: 400px; width: 500px; margin: 5px auto;">
            </div>
            <script src="../Scripts/latlon.js" type="text/javascript" />
            <script src="../Scripts/geo.js" type="text/javascript" />
            <script src="../Scripts/main.js" type="text/javascript"></script>
            <script src="../Scripts/json2.js" type="text/javascript"></script>
            <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=geometry&sensor=false"></script>
            <script type="text/javascript" src="../Scripts/infobox.js"></script>
            <script src="../Scripts/ptpl.js" type="text/javascript"></script>
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
                    initialize();
                    var a = new Array();

                    for (var i = 0; i < area.length; i++) {
                        var uno = area[i].split(",");
                        a[i] = new google.maps.LatLng(uno[0], uno[1]);
                        bounds.extend(a[i]);
                    }

                    poligon = new google.maps.Polygon({
                        paths: a,
                        strokeColor: "#FFFF00",
                        strokeOpacity: 0.8,
                        strokeWeight: 2,
                        fillColor: "#22B14C",
                        fillOpacity: 0.0
                    })

                    poligon.setMap(map);
                    var z = google.maps.geometry.spherical.computeArea(poligon.getPath().getArray());

                    map.setCenter(bounds.getCenter());
                    map.fitBounds(bounds);
                }
               
            </script>
            <script type="text/javascript">
                var degFmt = 'd';
                $(document).ready(function () {
                    $.get('../Scripts/latlon.js', function (data) {
                        var src = data.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
                        $('#latlon-src').html(src);
                    });
                    $.get('../Scripts/geo.js', function (data) {
                        var src = data.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
                        $('#geo-src').html(src);
                    });
                });
            </script>
            <script type="text/javascript">
        // if you use jQuery, you can load them when dom is read.
        $(document).ready(function () {
            <%if(Request["Code"]!=null){ %>

            var DTO = { 'id': <%:Request["Code"]%>};

                    $.ajax({
                        type: "POST",
                        url: "../Services/AddArea.asmx/GetCoordinates",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) 
                        {
                            var numOfPillar = $('#<%:txtNoPillar.ClientID%>').val();
                            var arr = new Array();

                            var i = 0;

                            for (i; i < numOfPillar; i++) {
                                var lat1 = Geo.parseDMS(response.d[i].Latitude);
                                var lon1 = Geo.parseDMS(response.d[i].Longitude);

                                if (!isNaN(lat1 + lon1))
                                    arr.push(lat1 + ',' + lon1);
                            }
                            dibuV(arr);
           },
           error: function (response) {
                 console.log(response);
           }
        })
    <%} %>
});
            </script>
        </div>
    </div>
</asp:Content>
