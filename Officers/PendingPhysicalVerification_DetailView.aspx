<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="PendingPhysicalVerification_DetailView.aspx.cs" Inherits="CEIHaryana.Officers.PendingPhysicalVerification_DetailView" %>
<%@ Register Src="~/UserCPages/LicenceHeaderDetails.ascx" TagPrefix="uc" TagName="LicenceDetails" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>

    <!-- Bootstrap JavaScript Bundle -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>

     <%--<script type="text/javascript">
         function alertWithRedirectdata() {
             if (confirm('Details Added Sucessfully')) {
                 window.location.href = "/Officers/PhysicalVerification_Letter_Request.aspx";
             } else {
             }
         }
     </script>--%>
     <script type="text/javascript">
         function alertWithRedirectdata() {
             if (confirm('Details Added Sucessfully')) {
                 window.location.href = "/Officers/PendingPhysicalVerification_Gridview.aspx";
             } else {
             }
         }
     </script>
    <style>
        .card {
            padding-left: 30px !important;
            padding-right: 30px !important;
        }

        th.headercolor {
            color: white !important;
        }

        .multiselect {
            width: 100%;
        }

        .selectBox {
            position: relative;
        }

            .selectBox select {
                width: 100%;
                width: 100%;
            }

        .overSelect {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

        #mySelectOptions {
            display: none;
            border: 0.5px #7c7c7c solid;
            background-color: #ffffff;
            max-height: 150px;
            overflow-y: scroll;
        }

            #mySelectOptions label {
                display: block;
                font-weight: normal;
                display: block;
                white-space: nowrap;
                min-height: 1.2em;
                background-color: #ffffff00;
                padding: 0 2.25rem 0 .75rem;
                /* padding: .375rem 2.25rem .375rem .75rem; */
            }

                #mySelectOptions label:hover {
                    background-color: #1e90ff;
                }

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

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        select#ContentPlaceHolder1_ddlSuggestion {
            display: block;
            width: 90%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px !important;
        }

        textarea#ContentPlaceHolder1_txtSuggestion {
            display: block;
            width: 100%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 100px !important;
        }

        .modal1 {
            display: none; /* Hidden by default */
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0, 0, 0);
            background-color: rgba(0, 0, 0, 0.4);
        }

        .modal-content {
            background-color: #fefefe;
            margin: 15% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }

        input#ContentPlaceHolder1_BtnAddSuggestion {
            padding-top: 2px;
            padding-bottom: 2px;
        }

        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }

        th {
            width: 1%;
        }
        input#ContentPlaceHolder1_RadioButtonList1_0 {
    margin-right: 10px;
}
        input#ContentPlaceHolder1_RadioButtonList1_1 {
    margin-left: 10px;
    margin-right: 10px;
}
        th {
    color: white !important;
    background:#9292cc !important;
}
        select#ContentPlaceHolder1_ddlvenue {
    height: 30px !important;
    padding: 2px 0px 5px 10px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    margin-left: 0px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="card-title" style="margin-top: -15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Pending Final Recommendations Detail 

            </div>
             <uc:LicenceDetails ID="ucLicenceDetails" runat="server" />
            <div class="card-title" style="margin-top: 15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Applications Status
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-12">
                   <asp:GridView ID="GridView1" CssClass="table table-responsive table-bordered table-striped" runat="server" AutoGenerateColumns="False" EmptyDataText="No data to display.">
                            <Columns>
                                <asp:BoundField DataField="ActionTakenBy" HeaderText="Action Taken By" />
                                <asp:BoundField DataField="ApplicationStatus" HeaderText="Action Taken" />
                                <asp:BoundField DataField="remarks" HeaderText="Remarks" />

                                <%-- Hardcoded 'Comments' column --%>
                              

                                <asp:BoundField DataField="ActionDate" HeaderText="Action Date" DataFormatString="{0:dd-MMM-yy}" />
                            </Columns>
                       <FooterStyle BackColor="White" ForeColor="#000066" />
                       <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                       <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                       <RowStyle ForeColor="#000066" />
                       <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#007DBB" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#00547E" />
                   </asp:GridView>
                    </div>

                </div>
            </div>

            <div class="card-title" style="margin-top: 15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Action
            </div>

            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">

                <div class="row">
                    <div class="col-md-4">
                        <label>
                            Action
                        </label>

                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="Accept" Selected="True">Accept</asp:ListItem>
                            <asp:ListItem Value="Reject">Not Recommend</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-9" runat="server" id="RejectionRemarks" visible="false">
                        <label>
                            Rejection Remarks
                        </label>

                        <asp:TextBox class="form-control" ID="txtRemarks" TabIndex="5" MaxLength="500" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                    <div class="col-md-4" style="margin-top: 15px;" id="VerificationDate" runat="server">
                        <label>
                            Physical Verification Date 
                        </label>
                        <asp:TextBox class="form-control" ID="txtDate" TabIndex="1" TextMode="Date" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-4" style="margin-top: 15px;" id="Div1" runat="server">
                        <label>
                            Time 
                        </label>
                        <asp:TextBox class="form-control" ID="txtTime" Type="time" min="09:00" max="18:00" TabIndex="1" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTime" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-4" style="margin-top: 15px;" id="Div2" runat="server">
                        <label>
                            Venue
                        </label>
                        <asp:DropDownList ID="ddlvenue" runat="server" CssClass="form-select"></asp:DropDownList>
                            
                    </div>
                    <div class="col-md-4" style="margin-top: 15px;" id="NeedCorrection" runat="server">
                        <label>
                            Correction Needed?
                        </label>
                        <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlcorrection" runat="server" TabIndex="2"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlcorrection_SelectedIndexChanged">
                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                            <asp:ListItem Value="2" Text="No" Selected="True"></asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-4" runat="server" id="Correction" visible="false" style="margin-top: 15px;">
                        <label>
                            Correction Remarks
                        </label>
                        <asp:TextBox class="form-control" ID="txtCorrectionRemarks" MaxLength="500" TabIndex="3" TextMode="MultiLine" utocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCorrectionRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>

                    </div>



                </div>
                    </div>
            <div class="row" style="margin-top: 25px;">
                <div class="col-md-4"></div>
                <div class="col-md-4" style="text-align: center;">

                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                </div>
            </div>
           
            <div class="row" id="AcceptedLabel" runat="server">
                <div class="col-md-12" style="text-align: center;">
                        
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="false" />
                    
                </div>
            </div>
        </div>

    </div>

    <div class="modal fade" id="modal1" tabindex="-1" role="dialog" aria-labelledby="updatePasswordModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="updatePasswordModalLabel">Suggestion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

            </div>
        </div>
    </div>


    <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>

     <script>
         document.getElementById("<%= txtTime.ClientID %>").addEventListener("change", function () {
             if (this.value < "09:00" || this.value > "18:00") {
                 alert("Please select a time between 9:00 AM and 6:00 PM.");
                 this.value = "";
             }
         });
     </script>

    <script type="text/javascript">
        window.onload = (event) => {
            initMultiselect();
        };

        function initMultiselect() {
            checkboxStatusChange();

            document.addEventListener("click", function (evt) {
                var flyoutElement = document.getElementById('myMultiselect'),
                    targetElement = evt.target; // clicked element

                do {
                    if (targetElement == flyoutElement) {
                        // This is a click inside. Do nothing, just return.
                        //console.log('click inside');
                        return;
                    }

                    // Go up the DOM
                    targetElement = targetElement.parentNode;
                } while (targetElement);

                // This is a click outside.
                toggleCheckboxArea(true);
                //console.log('click outside');
            });
        }


        function toggleCheckboxArea(onlyHide = false) {
            var checkboxes = document.getElementById("mySelectOptions");
            var displayValue = checkboxes.style.display;

            if (displayValue != "block") {
                if (onlyHide == false) {
                    checkboxes.style.display = "block";
                }
            } else {
                checkboxes.style.display = "none";
            }
        }
    </script>

</asp:Content>
