<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="RegistrationDetailsSelected.aspx.cs" Inherits="CEIHaryana.Admin.RegistrationDetailsAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        hr {
            margin-top: 2rem;
            margin-bottom: 1rem;
            border: 0;
            border-top: 1px solid rgba(0,0,0,.1);
        }

        .form-control {
            border-bottom: 1px solid black;
            border-top: 0px solid;
            border-left: 1px;
            border-right: 1px;
            border-radius: 0px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
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

        .form-group {
            margin-bottom: 0px;
        }

        .table-responsive {
            border-radius: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="card-title">Personal Details</div>
                <div class="card" style="border-radius: 15px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Applicant Name:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Father's Name:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtFatherNmae" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Gender:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtGender" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Nationality:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Aadhaar No:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtAadhaar" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Date of Birth:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtDOB" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Age:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtyears" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Phone No:</label>
                                            <div class="col-sm-9">
                                                  <asp:TextBox ID="txtphone" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Email Id:</label>
                                            <div class="col-sm-9">
                                             <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-2 col-form-label">Permanent Address:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPermanentAddress" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label for="exampleInputUsername2" class="col-sm-2 col-form-label">Communication Address:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCommunicationAddress" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-title" style="margin-top: 35px; margin-bottom: -7px;">Education/Technical Qualification Details</div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive" style="border: 1px solid #dee2e6 !important; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                            <table class="table table-bordered" style="margin-bottom: 0px;">
                                <thead>
                                    <tr style="text-align: center;">
                                        <th scope="col">Exam Name</th>
                                        <th scope="col">Board/University Name</th>
                                        <th scope="col">Passing Year</th>
                                        <th scope="col">marks Obtained/max</th>
                                        <th scope="col">% </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: center;">10th
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtUniversity" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtPassingyear" min='0000-01-01' max='9999-01-01' type="date" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksObtained" runat="server"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksmax" runat="server"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtprcntg" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:DropDownList class="form-control  select-form select2" ID="ddlQualification" runat="server" TabIndex="16" AutoPostBack="true">
                                                <asp:ListItem Text="12th" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="ITI" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Diploma in Electrical Engineering" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Diploma in Electronics Engineering" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtUniversity1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksObtained1" runat="server"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksmax1" runat="server"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtprcntg1" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:DropDownList class="form-control  select-form select2" ID="ddlQualification1" runat="server" TabIndex="16" AutoPostBack="true">
                                                <asp:ListItem Text="Diploma in Electrical Engineering" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Diploma in Electronics Engineering" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Degree in Electrical Engineering" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Degree in Electronics Engineering" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtUniversity2" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear2" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksObtained2" runat="server"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksmax2" runat="server"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtprcntg2" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:DropDownList class="form-control  select-form select2" ID="ddlQualification2" runat="server" TabIndex="16" AutoPostBack="true">
                                                <asp:ListItem Text="Diploma in Electrical Engineering" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Diploma in Electronics Engineering" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Certificate or Diploma in Wireman,Linemen" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Certificate or Diploma in Electrician" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtUniversity3" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" min='0000-01-01' max='9999-01-01' type="date" ID="txtPassingyear3" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksObtained3" runat="server"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox class="form-control" ID="txtmarksmax3" runat="server"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtprcntg3" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-10">
                            <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency/Wireman Permit issued by any state licincing
                                            board/chief electrical inspector.</h4>
                        </div>
                        <div class="col-md-2">
                            <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive" runat="server" id="competency" style="border: 1px solid #dee2e6 !important; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                            <table class="table table-bordered" style="margin-bottom: 0px;">
                                <thead>
                                    <tr style="text-align: center;">
                                        <th scope="col">Sno.</th>
                                        <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Category &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                        <th scope="col">Permit No.</th>
                                        <th scope="col">Issuing Authority</th>
                                        <th scope="col">Issue Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: center;">1
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtCategory" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtPermitNo" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtIssuingAuthority" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" min='0000-01-01' max='9999-01-01' type="date" ID="txtIssuingDate" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">2
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtCategory1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtPermitNo1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtIssuingAuthority1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" min='0000-01-01' max='9999-01-01' type="date" ID="txtIssuingDate1" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr />
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-5">
                            <h4 class="card-title" style="font-size: 15px;">Are you Employed on Permanent
                                            Basis.</h4>
                        </div>
                        <div class="col-md-2">
                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive" id="PermanentEmployee" runat="server" style="border: 1px solid #dee2e6 !important; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                            <table class="table table-bordered" style="margin-bottom: 0px;">
                                <thead>
                                    <tr style="text-align: center;">

                                        <th scope="col">Sno.</th>
                                        <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                        <th scope="col">Post Description</th>
                                        <th scope="col">From</th>
                                        <th scope="col">To</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: center;">1
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtEmployerName" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtDescription" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" min='0000-01-01' max='9999-01-01' type="date" ID="txtFrom" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" min='0000-01-01' max='9999-01-01' type="date" ID="txtTo" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr />
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-5">
                            <h4 class="card-title" style="font-size: 15px;">Detail of Experience.</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive" style="border: 1px solid #dee2e6 !important; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                            <table class="table table-bordered" style="margin-bottom: 0px;">
                                <thead>
                                    <tr style="text-align: center;">
                                        <th scope="col">Sno.</th>
                                        <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                        <th scope="col">Post Description</th>
                                        <th scope="col">From</th>
                                        <th scope="col">To</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: center;">1
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtEmployerName1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtDescription1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date"  min='0000-01-01' max='9999-01-01' ID="txtFrom1" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo1" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr />
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-5">
                            <h4 class="card-title" style="font-size: 15px;">Are you a Retired Engineer.</h4>
                        </div>
                        <div class="col-md-2">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive" id="RetiredEmployee" runat="server" style="border: 1px solid #dee2e6 !important; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                            <table class="table table-bordered" style="margin-bottom: 0px;">
                                <thead>
                                    <tr style="text-align: center;">
                                        <th scope="col">Sno.</th>
                                        <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                        <th scope="col">Post Description</th>
                                        <th scope="col">From</th>
                                        <th scope="col">To</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: center;">1
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtEmployerName2" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" ID="txtDescription2" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' ID="txtFrom2" runat="server"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo2" runat="server"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-4">
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
     <footer class="footer">
  
 </footer>
    <!-- partial:../../partials/_footer.html -->
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
    <script>
        // Dealing with Input width
        let el = document.querySelector(".input-wrap .input");
        let widthMachine = document.querySelector(".input-wrap .width-machine");
        el.addEventListener("keyup", () => {
            widthMachine.innerHTML = el.value;
        });

        // Dealing with Textarea Height
        function calcHeight(value) {
            let numberOfLineBreaks = (value.match(/\n/g) || []).length;
            // min-height + lines x line-height + padding + border
            let newHeight = 20 + numberOfLineBreaks * 20 + 12 + 2;
            return newHeight;
        }

        let textarea = document.querySelector(".resize-ta");
        textarea.addEventListener("keyup", () => {
            textarea.style.height = calcHeight(textarea.value) + "px";
        });
    </script>
</asp:Content>
