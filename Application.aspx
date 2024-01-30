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
                                <asp:TextBox class="form-control" ID="txtmarksDiploma" autocomplete="off" runat="server"> </asp:TextBox>

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

             <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-5">
                                                        <h4 class="card-title" style="font-size: 15px;">Detail of Experience.</h4>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">
                                                                    <%--  <th scope="col">Sno.</th>--%>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Experienced in &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Training Under &nbsp;
&nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
&nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">Post Description</th>
                                                                    <th scope="col">From</th>
                                                                    <th scope="col">To</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
                                                            </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperiene" runat="server" TabIndex="36" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="ddlExperiene" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTraningUnder" runat="server" TabIndex="37" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer" TabIndex="38" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtExperienceEmployer"
                                                                            ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription" TabIndex="39" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPostDescription"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off"  type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtExperienceFrom"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date"  min='0000-01-01' max='9999-01-01' ID="txtExperienceTo" TabIndex="41"  onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExperienceTo"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>--%>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtExperienceFrom" ControlToValidate="txtExperienceTo" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience1" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience1" runat="server" TabIndex="42" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="ddlExperience1" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience1">Please Select Experience1</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder1" runat="server" TabIndex="43" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text=" A class licensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddlTrainingUnder" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under "></asp:RequiredFieldValidator>--%>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer1"  TabIndex="44" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtExperienceEmployer1"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription1"  TabIndex="45" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPostDescription1"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off"  type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom1"  TabIndex="46" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtExperienceFrom1"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" AutoPostBack="true" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo1"  TabIndex="47" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtExperienceTo1"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>--%>
                                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtExperienceFrom1" ControlToValidate="txtExperienceTo1" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience2" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience2" runat="server" TabIndex="48" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="ddlExperience2" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience2">Please Select Experience2</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder2" runat="server" TabIndex="49" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="ddlTrainingUnder2" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer2"  TabIndex="49" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtExperienceEmployer2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription2"  TabIndex="50" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtPostDescription2"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off"  type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2"  TabIndex="51" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExperienceFrom2"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date"  min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2"  TabIndex="52" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtExperienceTo2"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>--%>
                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtExperienceFrom2" ControlToValidate="txtExperienceTo2" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience3" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience3" runat="server" TabIndex="53" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="ddlExperience3" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience3 "></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder3" runat="server" TabIndex="54" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text=" A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="ddlTrainingUnder3" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under3 "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer3"  TabIndex="55" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator163" runat="server" ControlToValidate="txtExperienceEmployer3"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription3"  TabIndex="56" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator173" runat="server" ControlToValidate="txtPostDescription3"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date"  min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom3"  TabIndex="57" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator183" runat="server" ControlToValidate="txtExperienceFrom3"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control"  autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo3"   TabIndex="58" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator193" runat="server" ControlToValidate="txtExperienceTo3"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>--%>
                                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtExperienceFrom3" ControlToValidate="txtExperienceTo3" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience4" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience4" runat="server" TabIndex="59" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="ddlExperience4" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience4 "></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder4" runat="server" TabIndex="60" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="ddlTrainingUnder4" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under4 "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer4"  TabIndex="61" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator204" runat="server" ControlToValidate="txtExperienceEmployer4"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription4"  TabIndex="62" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator241" runat="server" ControlToValidate="txtPostDescription4"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date"  min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom4"  TabIndex="63" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator224" runat="server" ControlToValidate="txtExperienceFrom4"
                                                                            ErrorMessage="Please Add Experience Date" ValidationGroup="Submit" ForeColor="Red">Please Add Experience Date</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date"   min='0000-01-01' max='9999-01-01' ID="txtExperienceTo4"  TabIndex="64" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator234" runat="server" ControlToValidate="txtExperienceTo4"
                                                                            ErrorMessage="Please Add Experience ToDate" ValidationGroup="Submit" ForeColor="Red">Please Add Experience ToDate</asp:RequiredFieldValidator>--%>
                                                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="txtExperienceFrom4" ControlToValidate="txtExperienceTo4" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td colspan="2" style="font-size: 12px;">
                                                                        <p style="font-size: 12px;">Total Experience:</p>
                                                                        <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtTotalExperience" runat="server"> </asp:TextBox>
                                                                    </td>
                                                                </tr>                                                                
                                                            
                                               
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
             <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-5">
                                                        <h4 class="card-title" style="font-size: 15px;">Are you a Retired Engineer.</h4>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" >
                                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="RadioButtonList1" InitialValue="" ForeColor="Red"
                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No ">Please choose yes or no</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

         <%--   <div class="row" >
                <div class="col" >
                    <h4>Details Of Fees</h4>
                </div>
                <div class="table-responsive" >
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                               <th> Amount</th>
                                <th>Challan/GRN Number</th>
                                <th>Date</th>
                                <th>Treasury</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>--%>

            <div class="row">

            </div>
        </div>
    </form>
</body>
</html>
