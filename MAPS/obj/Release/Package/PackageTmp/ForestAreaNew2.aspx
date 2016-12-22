<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ForestAreaNew2.aspx.cs" Inherits="MAPS.ForestAreaNew2" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="printarea">
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
                                    <asp:TextBox ID="txtBlock" runat="server" Visible="false" CssClass="inputbox req"></asp:TextBox>
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
                                        <asp:ListItem Text="Protected" Value="U" />
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
        <div class="clr">
        </div>
        <div class="NumPillar gra">
            <table width="90%" border="0" cellpadding="5" cellspacing="5" align="center">
                <tr class="trhideclass1">
                    <td width="35%" valign="middle" align="left">
                        <div>
                            Total Number of Ground Truthing Point :</div>
                    </td>
                    <td width="20%" align="left">
                        <asp:TextBox ID="txtTotalReference" runat="server" onkeypress="return OnlyNumber(event);"
                            Style="width: 40px;" class="textAlign inputbox req" placeholder="No." title="Number of total refence point"></asp:TextBox>
                    </td>
                    <td width="36%" align="left">
                    </td>
                </tr>
            </table>
        </div>
        <div id="divReference" style="width: 100%; margin-top: 10px;">
            <table width="70%" border="0" cellpadding="0" cellspacing="0" class="table gra" id="tblReference">
                <tbody>
                </tbody>
            </table>
        </div>
        <div class="clr">
        </div>
        <div style="margin-top: 10px; clear: none;">
            <div style="float: left; padding-top: 10px;">
                Area in Gazette/Doc. :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteArea" runat="server" class="textAlign inputbox req" onkeypress="return isNumberWithDot(this);"
                    placeholder="Area in Gazette" Width="100px"></asp:TextBox>Acre
            </div>
            <div style="float: left; padding-top: 10px; margin-left: 2%;">
                Gazette/Doc. Number :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteNumber" runat="server" class="inputbox req" placeholder="Gazette Number"
                    title="Gazette Number"></asp:TextBox>
            </div>
            <div style="float: left; padding-top: 10px; margin-left: 2%;">
                Gazette/Doc. Date :
            </div>
            <div style="float: left;">
                <asp:TextBox ID="txtGazetteDate" runat="server" Style="width: 90px;" class="inputbox jDate req"
                    placeholder="Gazette Date" title="Gazette Date"></asp:TextBox>
            </div>
        </div>
        <div class="clr">
        </div>
        <div style="width: 100%; margin-top: 10px;">
            <div style="width: 13%; float: left; padding-top: 10px;">
                Upload MAP :
            </div>
            <div style="float: left;">
                <input id="fileInput" type="file" onchange="return checkFileExtension();" /><font
                    style="color: Red;"> Image should be in jpg format with 100 dpi resolution and can be 16 bit colours.</font>
            </div>
            <div id="progress">
            </div>
            <div id="dvProgess">
            </div>
        </div>
        <div class="clr">
        </div>
        <table style="float: right; clear: none; width: 100%;">
            <tr>
                <td align="right">
                    <input id="btnSubmit" type="button" value="Submit" class="button button-green pre" /><img
                        id="imgLoader" src="images/loader.gif" style="display: none;" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clr">
    </div>
    <%if (Request["Code"] != null)
      { %>
    <img src="MAP/<%:Request["Code"] %>.jpg" />
    <%} %>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/ptpl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%:txtTotalReference.ClientID%>').change(function () {
                var rows = $('#<%:txtTotalReference.ClientID%>').val();

                for (var i = document.getElementById("tblReference").rows.length; i > 0; i--) {
                    document.getElementById("tblReference").deleteRow(i - 1);
                }

                var tbody = $("#tblReference");
                var number_of_columns = 3;

                if (tbody == null || tbody.length < 1) return;

                var tfirstrow = $("<tr style='color:#000;'>");
                $("<th>").text("Point No.").appendTo(tfirstrow);
                $("<th >").text("Latitude").appendTo(tfirstrow);
                $("<th>").text("Longitude").appendTo(tfirstrow);

                tfirstrow.appendTo(tbody);

                for (var i = 1; i <= rows; i++) {
                    var trow = $("<tr>");
                    for (var c = 0; c < number_of_columns; c++) {
                        var td = $("<td>").addClass("tableCell").data("col", c).appendTo(trow);
                        switch (c) {
                            case 0:
                                $('<input name="txtPointNo' + i + '" id="txtPointNo' + i + '" type="text" style="width:40px" class="textAlign inputbox req"  maxlength="4" />').appendTo(td);
                                break;
                            case 1:
                                $('<input name="txtLatitudeRef' + i + '" id="txtLatitudeRef' + i + '" type="text"  placeholder="Latitude" class="textAlign req inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 2:
                                $('<input name="txtLongitudeRef' + i + '" id="txtLongitudeRef' + i + '" type="text"  placeholder="Longitude" class="textAlign inputbox req" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
                                break;
                        }

                    }
                    trow.appendTo(tbody);
                }
            });

            //-------------------------------------------------------------------------------------------------------------------------

            function replace() { $(this).after($(this).text()).remove() }

        });
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
                        url: "Services/AddArea.asmx/GetCadastral",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) {

                        var rows = $('#<%:txtTotalReference.ClientID%>').val();

                for (var i = document.getElementById("tblReference").rows.length; i > 0; i--) {
                    document.getElementById("tblReference").deleteRow(i - 1);
                }

                var tbody = $("#tblReference");
                var number_of_columns = 3;

                if (tbody == null || tbody.length < 1) return;

                var tfirstrow = $("<tr style='color:#000;'>");
                $("<th>").text("Point No.").appendTo(tfirstrow);
                $("<th >").text("Latitude").appendTo(tfirstrow);
                $("<th>").text("Longitude").appendTo(tfirstrow);

                tfirstrow.appendTo(tbody);

                for (var i = 1; i <= rows; i++) {
                    var trow = $("<tr>");
                    for (var c = 0; c < number_of_columns; c++) {
                        var td = $("<td>").addClass("tableCell").data("col", c).appendTo(trow);
                        switch (c) {
                            case 0:
                                $('<input name="hfIdRef' + i + '" id="hfIdRef' + i + '" value="'+response.d[i-1].Id+'" type="hidden" />').appendTo(td);
                                $('<input name="txtPointNo' + i + '" id="txtPointNo' + i + '" value="'+response.d[i-1].PillarNo+'" type="text" style="width:40px" class="textAlign inputbox req"  maxlength="4" />').appendTo(td);
                                break;
                            case 1:
                                $('<input name="txtLatitudeRef' + i + '" id="txtLatitudeRef' + i + '" value="'+response.d[i-1].Latitude+'" type="text"  placeholder="Latitude" class="textAlign req inputbox" onkeypress="return isNumberWithDot(this);" title="Latitude" />').appendTo(td);
                                break;
                            case 2:
                                $('<input name="txtLongitudeRef' + i + '" id="txtLongitudeRef' + i + '" value="'+response.d[i-1].Longitude+'" type="text"  placeholder="Longitude" class="textAlign inputbox req" onkeypress="return isNumberWithDot(this);"  title="Longitude" />').appendTo(td);
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
                    });
                    
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

                $("#imgLoader").css("display", "block");
                $("#btnSubmit").attr("disabled", true);


                $('#form1 input[type="text"],.ddl').tooltipster({
                    trigger: 'custom', // default is 'hover' which is no good here
                    onlyOne: false,    // allow multiple tips to be open at a time
                    position: 'right'  // display the tips to the right of the element
                });

                // adding rules for inputs
                $('input.req').each(function () {
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

                    <%if(Request["Code"]!=null){ %>
                    forestArea.Id =<%:Request["Code"] %>;
                    forestArea.UpdatedBy='<%:((MAPS.LoginMaster)Session["User"]).UserId %>'
                    <%} %>
                    forestArea.forestType = $('#<%:ddlForestType.ClientID%>').val();
                    forestArea.CadastralPoints = $('#<%:txtTotalReference.ClientID%>').val();

                    forestArea.ForestName = $('#<%:txtForestName.ClientID%>').val();
                    forestArea.AreaInGazette = $('#<%:txtGazetteArea.ClientID%>').val();
                    forestArea.BlockId = $('#<%:ddlBlock.ClientID%>').val();
                    forestArea.VillageId = $('#<%:ddlVillage.ClientID%>').val();


                    forestArea.GazetteDate = $('#<%:txtGazetteDate.ClientID%>').val().split("/").reverse().join("-");;
                    forestArea.GazetteNo = $('#<%:txtGazetteNumber.ClientID%>').val();

                    forestArea.CreatedBy='<%:((MAPS.LoginMaster)Session["User"]).UserId %>'

                    var jsonRef = { "cadastralPoints": [] };

                    var refPoints = $('#<%:txtTotalReference.ClientID%>').val();

                    var i = 0;
                    for (i=1; i <= refPoints; i++) {

                        jsonRef.cadastralPoints.push({<%if(Request["Code"]!=null){ %>id: $('#hfIdRef' + i).val(),<%} %> pillarNo: $('#txtPointNo' + i).val(), latitude: $('#txtLatitudeRef' + i).val(), longitude: $('#txtLongitudeRef' + i).val() });
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
                        dataType: 'json',
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
                            var DTO = { 'forestArea': forestArea, 'cadastralPoints': jsonRef.cadastralPoints };

                    $.ajax({
                        type: "POST",
                        <%if(Request["Code"]!=null){ %>url: "Services/AddArea.asmx/UpdateArea1",<%} %>
                        <%else{ %>url: "Services/AddArea.asmx/InsertArea1",<%} %>
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) {
                            var areaId = response.d;
                            uploadFile(areaId);
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
                            var DTO = { 'forestArea': forestArea, 'cadastralPoints': jsonRef.cadastralPoints };

                    $.ajax({
                        type: "POST",
                        <%if(Request["Code"]!=null){ %>url: "Services/AddArea.asmx/UpdateArea1",<%} %>
                        <%else{ %>url: "Services/AddArea.asmx/InsertArea1",<%} %>
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(DTO),
                        success: function (response) {
                            var areaId = response.d;
                            uploadFile(areaId);
                            console.log(response);
                        },
                        error: function (response) {
                            console.log(response);
                            $("#imgLoader").css("display", "none");
                        $("#btnSubmit").attr("disabled", false);
                        }
                    }).done(function () {
                     <%if(Request["Code"]==null){ %>
                        alert("Data saved successfully.");<%} %>
                        <%else{ %>alert("Data updated successfully.");<%} %>

                        $("#imgLoader").css("display", "none");
                        $("#btnSubmit").attr("disabled", false);
                    });

                    console.log("validates");
                    }
                } else {
                    console.log("does not validate");
                    $("#imgLoader").css("display", "none");
                        $("#btnSubmit").attr("disabled", false);
                }
                // Validate the form and retain the result.
                var isValid = $("#form1").valid();

                // If the form didn't validate, prevent the
                //  form submission.
                if (!isValid)
                    evt.preventDefault();
                    $("#imgLoader").css("display", "none");
                        $("#btnSubmit").attr("disabled", false);
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
                alert('Please select a Image file less than 6 mb.');
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
            if (flag == true) {
            }
            return flag;

        }
        function sendFile(file, sFileName) {
            // debugger;
            $.ajax({
                url: 'handler/FileUploader.ashx?FileName=' + sFileName + ".jpg", //server script to process data
                type: 'POST',
                xhr: function () {
                    myXhr = $.ajaxSettings.xhr();
                    if (myXhr.upload) {
                        myXhr.upload.addEventListener('progress', progressHandlingFunction, false);
                    }
                    return myXhr;
                },
                success: function (result) {
                    //On success if you want to perform some tasks.
                },
                data: file,
                cache: false,
                contentType: false,
                processData: false
            });
            function progressHandlingFunction(e) {
                if (e.lengthComputable) {
                    var s = parseInt((e.loaded / e.total) * 100);
                    $("#progress" + currFile).text(s + "%");
                    $("#progbarWidth" + currFile).width(s + "%");
                    if (s == 100) {
                        triggerNextFileUpload();
                    }
                }
            }
        }

        function uploadFile(sFileName) {
            currFile = 0;
            var aFile = $('#fileInput').val();
            if (aFile != "" && aFile != null) {
                sendFile($("#fileInput")[0].files[0], sFileName);
            }
        }
    </script>
</asp:Content>
