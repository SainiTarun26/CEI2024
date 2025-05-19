<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="Intimation_Cinema_History.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.Intimation_Cinema_History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function isAlpha(keyCode) {

            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190)

        }

        function alphabetKey(e) {
            var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>
    <style>
        h7.card-title.fw-semibold.mb-4 {
    margin-left: 20px;
}
        .card-body {
    margin-left: 20px;
    margin-right: 20px;
}
        .col-md-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
        }

        .select2-container .select2-selection--single {
            height: 30px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }

        span.select2-selection.select2-selection--single {
            padding: 0px 0px 0px 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            border-radius: 5px !important;
        }

            span.select2-selection.select2-selection--single:focus {
                border: 2px solid #80bdff;
            }

        .card .card-title {
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        select.form-control.select-form.select2 {
            height: 30px !important;
            padding: 2px 0px 5px 10px;
        }

        ul.chosen-choices {
            border-radius: 5px;
        }

        input#customFile {
            padding: 0px 0px 0px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body" style="margin-left: 0px; margin-right: 0px;">
                <h7 class="card-title fw-semibold mb-4" style="margin-left:0px !important;">WORK INTIMATION DETAILS</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-left:0px !important; margin-right:0px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-4">
                                            <label>
                                                Inspection Type
                                               
                                            </label>
                                          <%--  <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" disabled="true" Style="width: 100% !important;" ID="ddlInspectionType" TabIndex="2" runat="server" >
                                                <asp:ListItem Text="New" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Existing" Value="1"></asp:ListItem>
                                            </asp:DropDownList>--%>
                            <asp:TextBox class="form-control" ID="TxtInspectionType" autocomplete="off" ReadOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-8" style="margin-bottom: -20px;">
                            <label for="Address">Address</label>
                            <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-4" id="InstallationFor">
                            <label>State</label>
                            <%-- <asp:DropDownList ID="ddlworktype" runat="server" AutoPostBack="true" disabled class="form-control  select-form select2" Style="width: 100% !important;">
        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
        <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
        <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
    </asp:DropDownList>--%>
                            <asp:TextBox class="form-control" ID="TxtInstallationFor" autocomplete="off" ReadOnly="true" Text="Haryana" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                District                               
                            </label>
                            <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                           <div class="col-md-4" id="pin" runat="server" visible="false">
    <label for="Pin">PinCode</label>
    <asp:TextBox class="form-control" ID="txtPin" MaxLength="6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
    <span id="lblPinError" style="color: red"></span>
</div>
                    </div>
                    
                                    </div>
                    </div>
                            <h7 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important;">Installation Details</h7>

                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;margin-left: 20px;
    margin-right: 20px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                
                        <div class="col-md-12">
                            <div class="table-responsive pt-3" id="Installation" runat="server" visible="false">
                                <table class="table table-bordered table-striped" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                                    <thead class="table-dark">
                                        <tr>
                                            <th style="width: 70%;">Installation Type
                                            </th>
                                            <th style="width: 20%;">No of Installations
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <div id="installationType1" runat="server" visible="False">
                                            <tr>
                                                <td>
                                                    <div class="col-md-12">
                                                        <asp:TextBox class="form-control" ID="txtinstallationType1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-md-12">
                                                        <asp:TextBox class="form-control" ID="txtinstallationNo1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinstallationNo1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                        </div>                                    
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                  
                                </div>
            
                <h7 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important;">Work Schedule</h7>
                
                <div>
                     
                   <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4" style="text-align: center;">
                            <asp:Button type="submit" ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
                            <asp:Button ID="btnOpenWindow" runat="server" Text="Print" class="btn btn-primary mr-2" OnClientClick="openNewWindow(); return false;" />

                        </div>
                        <div class="col-md-4"></div>
                    </div>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />
                    <div>
                    </div>
                </div>

            </div>
       </div>
    <footer class="footer">
    </footer>
    <script>
        $('.select2').select2();
    </script>
    <script>
        $(".chosen-select").chosen({
            no_results_text: "Oops, nothing found!"
        })
    </script>
 
    <script type="text/javascript">
        function showHide() {
            debugger
            let experience = document.getElementById('experience');
            if (experience.value == 1) {
                document.getElementById('hidden-field').style.display = 'block';
            } else {
                document.getElementById('hidden-field').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('hidden-field1').style.display = 'block';
            } else {
                document.getElementById('hidden-field1').style.display = 'none';
            }
        }
    </script>
    <script>
        function openNewWindow() {
            var newWindow = window.open('../UserPages/PrintWorkIntimationNew.aspx', '_blank');
            newWindow.focus();
        }
    </script>
    <script type="text/javascript">
        function showHide1() {
            debugger
            let experience = document.getElementById('ddlworktype');
            if (experience.value == 1) {
                document.getElementById('individual').style.display = 'block';
            } else {
                document.getElementById('individual').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('Agency').style.display = 'block';
            } else {
                document.getElementById('Agency').style.display = 'none';
            }
        }
    </script>

</asp:Content>
