<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="CEIHaryana.Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <meta content="" name="keywords" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@4.0.0/dist/css/bootstrap.min.css" />
    <style>
        .form-control {
            margin-left: 0px !important;
            font-size: 18px !important;
            height: 30px;
            border-bottom: 2px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-12">
                    <label for="Name">
                        Name of Applications
                    </label>
                    <asp:TextBox class="form-control" ID="txtApplication" ReadOnly="true" runat="server" autocomplete="off"
                        Style="margin-left: 18px;">
                    </asp:TextBox>

                </div>

            </div>
            <div class="row">
                <div class="col-12">
                    <label>Father's Name</label>

                    <asp:TextBox class="form-control" ID="txtFatherName" ReadOnly="true" runat="server" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Gender</label>

                    <asp:TextBox class="form-control" ID="txtGender" ReadOnly="true" runat="server" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Nationality</label>

                    <asp:TextBox class="form-control" ID="txtNationality" ReadOnly="true" runat="server" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
                <div class="col-6">
                    <label>Adhaar No</label>

                    <asp:TextBox class="form-control" ID="txtAdhaar" runat="server" ReadOnly="true" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Date Of Birth</label>

                    <asp:TextBox class="form-control" ID="txtDOB" ReadOnly="true" runat="server" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
                <div class="col-6">
                    <label>Age</label>

                    <asp:TextBox class="form-control" ID="txtCalculatedAge" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Permanent Address</label>

                    <asp:TextBox class="form-control" ID="txtPermanentAddress" ReadOnly="true" autocomplete="off" runat="server"
                        Style="margin-left: 18px">
                    </asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <label>Address For Communication</label>

                    <asp:TextBox class="form-control" ID="txtCommunicationAddress" ReadOnly="true" runat="server"
                        Style="margin-left: 18px">
                    </asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <label>Mobile No.</label>

                    <asp:TextBox class="form-control" ID="txtContact" ReadOnly="true" runat="server"
                        Style="margin-left: 18px">
                    </asp:TextBox>

                </div>
                <div class="col-6">
                    <label>E-mailId</label>

                    <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" runat="server"
                        Style="margin-left: 18px">
                    </asp:TextBox>

                </div>
            </div>
            <div class="row">
                <table class="table table-bordered">
                    <thead>
                        <tr style="text-align: center;">

                            <th scope="col" style="width: 20% !important;">Exam Name</th>
                            <th scope="col">Board/University Name</th>
                            <th scope="col" style="width: 0% !important;">Passing Year</th>
                            <th scope="col" style="width: 0% !important;">Obtained Marks&nbsp;/&nbsp;Max Marks
                                                        
                            </th>
                            <th scope="col" style="width: 10% !important;">% </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="text-align: center; font-size: 15px !important;">10th
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtUniversity" runat="server" autocomplete="off"> </asp:TextBox>
                            </td>
                            <td>

                                <asp:TextBox class="form-control" ID="txtPassingyear" runat="server" autocomplete="off"> </asp:TextBox>
                                <div>
                                </div>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtmarks" autocomplete="off" runat="server"> </asp:TextBox>


                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtprcntg" autocomplete="off" runat="server"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:TextBox class="form-control" autocomplete="off" ID="txt12thorITI" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity1" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPassingyear1" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtmarks12thOrITI" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg1" runat="server"> </asp:TextBox>

                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: center;">
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDiploma" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtUniversity2" autocomplete="off" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPassingyear2" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg2" runat="server"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Degree" runat="server">

                            <td style="text-align: center;">
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDegree" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity3" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPassingyear3" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtmarksObtained3" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg3" runat="server"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Masters" visible="false" runat="server">

                            <td style="text-align: center;">
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtMasters" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity4" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPassingyear4" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtmarksObtained4" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg4" runat="server"> </asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <hr />
            <div class="row" style="margin-top: 15px;">
                <div class="col-md-10">
                    <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency/Wireman Permit issued by any state licincing
                                            board/chief electrical inspector.</h4>
                </div>
                <div class="col-md-2">
                    <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" InitialValue="" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No">Please Choose Yes Or No</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" id="competency" runat="server" visible="true">
                <div class="table-responsive" runat="server">
                    <table class="table table-bordered">
                        <thead>
                            <tr style="text-align: center;">
                                <th scope="col">Sno.</th>
                                <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Category &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                <th scope="col">Permit No.</th>
                                <th scope="col">Issuing Authority</th>
                                <th scope="col">Issue Date</th>
                                <th scope="col">Expiry Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center; font-size: 13px;">1
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtCategory" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" InitialValue="" ControlToValidate="txtCategory" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Category">Please Enter Category</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPermitNo" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" InitialValue="" ControlToValidate="txtPermitNo" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Permit No.">Please Enter Permit No.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtIssuingAuthority" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" InitialValue="" ControlToValidate="txtIssuingAuthority" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter IssuingAuthority">Please Enter IssuingAuthority</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtIssuingDate" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" InitialValue="" ControlToValidate="txtIssuingDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Issuing Date">Please Select Issuing Date</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtExpiryDate" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" InitialValue="" ControlToValidate="txtExpiryDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Expiry Date">Please Select Expiry Date</asp:RequiredFieldValidator>
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
                        <asp:ListItem Text="Yes" Value="0" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                     </div>
            </div>
            <div class="row" id="PermanentEmployee" runat="server">
                <div class="table-responsive">
                    <table class="table table-bordered">
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
                                <td style="text-align: center; font-size: 13px;">1
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentEmployerName" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtPermanentEmployerName" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Employer Name">Please Enter Employer Name</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentDescription" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtPermanentDescription" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Employer Name">Please Enter Employer Name</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPermanentFrom" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtPermanentFrom" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter From Date">Please Enter From Date</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPermanentTo" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtPermanentTo" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter TO Date">Please Enter TO Date</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="row">

            </div>
        </div>
    </form>
</body>
</html>
