<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="InspectionDetailsCinema.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.InspectionDetailsCinema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        //Allow Only Aplhabet, Delete and Backspace

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

    <script type="text/javascript">
        function alertWithRedirectdata1() {
            alert('Successfully submitted to contractor.');
            window.location.href = 'InspectionHistory.aspx';
        }

    </script>
    <style>
        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 10px;
            background: left 3px top 5px no-repeat #563d7c;
        }

            .submit:hover {
                border: 1px solid #563d7c;
                border-radius: 5px;
                color: white;
                padding: 5px 10px 5px 10px;
                background: left 3px top 5px no-repeat #26005f;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        .col-4 {
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
            height: 30px;
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

        input#ContentPlaceHolder1_txtName {
            font-size: 12.5px !important;
        }


        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        span {
            font-weight: 400;
            font-size: 12px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
            width:1% !important;
        }

        .card {
            margin-bottom: 20px;
        }

        .card-title {
            margin-bottom: 8px !important;
        }
        th.headercolor.thwidth {
    width: 4% !important;
}ggt
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                Inspection Details (<asp:Label ID="lblInspectionType" runat="server"  Text="Label" style="font-size: 17px;"></asp:Label>)
            </div>
            <div class="card" style="padding-top: 10px; padding-left: 15px; padding-right: 15px;">
                <div class="row">
              
                    <div class="col-4" runat="server">
                        <label for="Pin">Application No.</label>
                        <asp:TextBox class="form-control" ID="txtApplicationNo" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Installation
                        </label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                 
                   
                    <div class="col-4" runat="server">
                        <label for="Pin">Total Amount</label>
                        <asp:TextBox class="form-control" ID="txtAmount" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div id="DocumentDiv" runat="server" visible="true">

                <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                    Inspection Documents
                </div>
             <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
                <HeaderStyle BackColor="#B7E2F0" />
                <Columns>
                    <asp:TemplateField HeaderText="SNo">
                        <HeaderStyle Width="5%" CssClass="headercolor" />
                        <ItemStyle Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                        <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                    </asp:TemplateField>
                </Columns>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>
    <asp:Label ID="Lblgrd_Documemnts" runat="server"></asp:Label>
</div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 18px !important; margin-bottom: 10px !important;">Inspection Details</h6>
                </div>
            </div>
            <div class="card" style="padding-top: 10px;">
                <div class="col-12">

                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-striped table-responsive" runat="server"  AutoGenerateColumns="false" >
                        <HeaderStyle BackColor="#B7E2F0" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle CssClass="headercolor" />
                                <ItemStyle />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ActionTaken" HeaderText="ActionTaken">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>                           
                            <asp:BoundField DataField="ActionDate" HeaderText="ActionDate">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AssignTo" HeaderText="AssignTo">
                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor width" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </div>
            <div id="TestReport" runat="server" visible="False">
                <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                    Screen Details
                </div>
                 <div class="card" id="New" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;" runat="server" visible="false">
      <div class="col-12" style="padding: 0px;">
          <asp:GridView ID="GridView3" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
              <HeaderStyle BackColor="#B7E2F0" />
              <Columns>
                  <asp:TemplateField HeaderText="SNo">
                      <HeaderStyle CssClass="headercolor" />
                      <ItemStyle />
                      <ItemTemplate>
                          <%# Container.DataItemIndex + 1 %>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="NameOfScreen" HeaderText="Name Of Screen">
                      <HeaderStyle HorizontalAlign="Left" CssClass="headercolor thwidth" />
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="TestReportId" HeaderText="TestReportId" Visible="false">
                      <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="SerialNo" HeaderText="Serial No.">
                      <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="SizeOfScreen" HeaderText="Size Of Screen">
                      <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
              </Columns>
          </asp:GridView>

      </div>
  </div> 
            </div>
          
            <div class="row">
                <div class="col-4"></div>
                <div class="col-4" style="text-align: center;">
                 
                    <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click"/>
                 
                </div>
                 <asp:HiddenField ID="hdnOwnerId" runat="server" />
            </div>

        </div>
    </div>


</asp:Content>
