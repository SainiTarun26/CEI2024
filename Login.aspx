<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="CEIHaryana.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CEI</title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link rel="stylesheet" href="/Assets/css/feather/feather.css" />
    <link rel="stylesheet" href="/Assets/css/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="/Assets/css/css/vendor.bundle.base.css" />
    <link rel="shortcut icon" href="images/favicon.png" />
    <style type="text/css">
        .pt-3 {
            padding-top: 0px !important;
        }

        h4 {
            font-size: 1.1rem !important;
        }

        p {
            color: #504b8e;
            font-weight: 600;
        }

        .col-2 {
            font-size: 18px;
            padding-left: 11px !important;
            padding-right: 0px !important;
            margin-right: -14px;
        }

        h6.font-weight-light {
            margin-bottom: 30px;
        }

        input#exampleInputEmail1 {
            font-size: 15px;
        }

        input#exampleInputPassword1 {
            font-size: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     
            <div class="container-scroller" style="padding: 50px 0px 60px 0px !important; background-color: #f5f7ff;">
                <div class="page-body-wrapper full-page-wrapper">
                    <div class="d-flex align-items-center auth px-0">
                        <div class="row w-100 mx-0">
                            <div class="col-lg-4 mx-auto" style="background-color: white; border-radius: 10px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 30px; padding-bottom: 30px; padding-right: 0px; padding-left: 0px;">
                                <div class="auth-form-light text-left py-5 px-4 px-sm-5" style="margin-top: -45px;">
                                    <div class="row" style="display: flex; align-items: center; margin-left: -35px; justify-content: center; margin-bottom: 30px;">
                                        <div class="col-2">
                                            <img src="Assets/Emblem_of_Haryana.svg.png" style="width: 35px;" />
                                        </div>
                                        <div class="col-2" style="font-size: 23px;">
                                            <p style="margin-top: 27px;">CEI -</p>
                                        </div>
                                        <div class="col-6" style="font-size: 13px; padding-left: 10px !important; margin-top: 7px;">
                                            <p style="margin-top: 7px; margin-left: 5px; margin-top: 23px;">Chief Electrical Inspector</p>
                                        </div>
                                        <div class="col-2"></div>
                                    </div>
                                    <h4>Hello! let's get started</h4>
                                    <h6 class="font-weight-light">Sign in to continue.</h6>
                                    <div class="pt-3">
                                        <div style="text-align:center;">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-11" style="padding-left:40px;">
                                                    <asp:TextBox ID="txtUserID" class="form-control form-control-lg" runat="server" autocomplete="off" placeholder="Enter your User Id" TabIndex="1"
                                                        Style="font-size: 13px; border-color: white; border: #d9dee3 1px solid;"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1" style="margin-left: -20px; font-size: 20px; margin-top: auto; margin-bottom: auto;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="txtUserID" Display="Dynamic"
                                                        ErrorMessage="UserId is Required." ForeColor="Red"
                                                        SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                    <%-- <input type="email" class="form-control form-control-lg" id="exampleInputEmail1" placeholder="Username" />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-11"  style="padding-left:40px;">
                                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" autocomplete="off" TextMode="Password"
                                                        placeholder="Enter Your Password" TabIndex="2" Style="font-size: 13px; border-color: white; border: #d9dee3 1px solid;"></asp:TextBox>
                                                    <%-- <span class="input-group-text cursor-pointer"><i class="bx bx-hide"></i></span>--%>
                                                    </div>
                                                <div class="col-md-1"  style="margin-left: -20px; font-size: 20px; margin-top: auto; margin-bottom: auto;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txtPassword" Display="Dynamic"
                                                        ErrorMessage="Password is Required." ForeColor="Red"
                                                        SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                                    <%--<input type="password" class="form-control form-control-lg" id="exampleInputPassword1" placeholder="Password" />--%>
                                                </div>
                                                </div>
                                        <div class="mt-3">
                                            <label id="WrongCredentials" runat="server" visible="false" style="color: red;">
                                                Your UserName or Password is Invalid.
                                            </label>
                                            <asp:Button class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" ID="BtnLogin" runat="server" Text="Sign in" style="width:84% !important;margin-left:24px;"
                                                OnClick="BtnLogin_Click" ValidationGroup="Submit" ></asp:Button>
                                            <%-- <a class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" href="../../index.html">SIGN IN</a>--%>
                                        </div>
                                        <div class="my-2 d-flex justify-content-between align-items-center">
                                            <div class="form-check">
                                                <label class="form-check-label text-muted">
                                                    <asp:CheckBox ID="chkSignedin" runat="server" class="form-check-input" />
                                                    Keep me signed in
                                                </label>
                                            </div>
                                            <a href="#" class="auth-link text-black">Forgot password?</a>
                                        </div>
                                        <div class="text-center mt-4 font-weight-light">
                                            Don't have an account? <a href="/UserPages/Registration.aspx" class="text-primary">Create</a>
                                        </div>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="False" ShowSummary="False" ValidationGroup="Submit"/>
                                    </div>
                                            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- content-wrapper ends -->
            </div>
            <!-- page-body-wrapper ends -->
        </div>
    </form>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
    <script src="/Assets/js/chart.js/Chart.min.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
    </form>
</body>
</html>
