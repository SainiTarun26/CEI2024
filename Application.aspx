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
                                <asp:TextBox class="form-control" autocomplete="off"  ID="txtPassingyear1" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                              <asp:TextBox class="form-control" autocomplete="off" ID="txtmarks12thOrITI" runat="server"> </asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off"  ID="txtprcntg1" runat="server"> </asp:TextBox>

                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: center;">
                               <asp:TextBox class="form-control" autocomplete="off"  ID="txtDiploma" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" ID="txtUniversity2" autocomplete="off" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPassingyear2" runat="server"> </asp:TextBox>
                            </td>
                            <td>
                               <asp:TextBox class="form-control" autocomplete="off"  runat="server"> </asp:TextBox>
                                  
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
                                <asp:TextBox class="form-control" autocomplete="off"  ID="txtPassingyear3" runat="server"> </asp:TextBox>
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
                                <asp:TextBox class="form-control" autocomplete="off"  ID="txtPassingyear4" runat="server"> </asp:TextBox>
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
        </div>
    </form>
</body>
</html>
