<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="CompetencyRenewalCertificate.aspx.cs" Inherits="CEIHaryana.Wiremen.CompetencyRenewalCertificate" %>
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
    <link href="https://cdnjs.cloudflare.com/aja
        x/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>


    

    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
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
        input#ContentPlaceHolder1_txtName {
    border: none;
    border-bottom: 1px solid #ccc;
    width: 13%;
    text-align: end;
     font-weight: 500;
}
        input#ContentPlaceHolder1_TextBox1 {
            border: none;
            border-bottom: 1px solid #ccc;
            width: 5%;
            font-weight: 500;

        }
        input#ContentPlaceHolder1_TextBox2 {
             border: none;
            border-bottom: 1px solid #ccc;
            width: 18%;
            font-weight: 500;
}
        img#ContentPlaceHolder1_Image1 {
    max-width: 100px;
    height: 100px !important;
    margin-left: 0px !important;
}
        img#ContentPlaceHolder1_Image2 {
    max-width: 100px;
    height: 100px !important;
    margin-left: 0px !important;
}
        span.input {  
    border: none;
    border-bottom: 1px solid #ccc;
    text-align:center;
}
         span.input:focus-visible {  
    border: none;
    border-bottom: 1px solid #ccc;
    text-align:center;
}
         input#ContentPlaceHolder1_TextBox3 {
    border: none;
    border-bottom: 1px solid #ccc;
    width: 20%;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-wrapper">
        <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
        </div>--%>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12" style="text-align:end;margin-bottom:20px;">
                        <asp:Button ID="btnSubmit" Text="Print" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" TabIndex="16"
                                Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;"
                                OnClientClick="return validateForm()"/>
                    </div>
                </div>
                <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 17px;">Form V</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 600; font-size: 17px;">{see rule 6(3)}</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <p style="text-align: center; text-align:initial; font-weight: 700; font-size: 17px;">No. EC-&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="txtName" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30" ReadOnly="true">
                            </asp:TextBox>&nbsp;&nbsp;/&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox1" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30">
                            </asp:TextBox></p>
                            </div>
                            <div class="col-md-6">
                                <p style="text-align: end; text-align:end; font-weight: 700; font-size: 17px;">Date of Birth:&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox2" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30">
                            </asp:TextBox></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Image ID="Image1" runat="server" />
                            </div>
                            <div class="col-md-6" style="text-align:end;">
                                <asp:Image ID="Image2" runat="server" />
                            </div>
                        </div>
                        <div class="row"  style="margin-top:30px;">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 18px;">PERFORMA FOR RENEWAL OF CERTIFICATE OF CEMPETENCY</p>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <p style="text-align:justify;line-height:2;text-align: justify;text-justify: inter-word; font-size: 17px;">
                                    <span class="input" role="textbox" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;son/daughter of Sh.
                                    <span class="input" role="textbox" style="text-align:center;" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;R/o&nbsp;&nbsp;
                                    <span class="input" role="textbox" style="text-align:center;" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;
                                    having satisfied the Chief Electrical Inspector, Haryana that his/her qualification and experience as certained
                                    by the Screening Committee, found eligible for grant of Certificate of Competency, is hereby granted this Certificate of Competency. </p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <p style="text-align: center; text-align:initial; font-weight: 700; font-size: 17px;">Dated:&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox3" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30" ReadOnly="true">
                            </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <p style="text-align: end; text-align:end; font-weight: 700; font-size: 17px;">Chief Electrical Inspector<br/>to Government, Haryana, Chandigarh</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Image ID="Image3" runat="server"  Style="margin-left:0px !important;"/><br/>
                                <asp:Label ID="Label1" runat="server" Text="Signature of Applicant"></asp:Label>
                            </div>
                            <div class="col-md-6" style="text-align:end;">
                                <asp:Image ID="Image4" runat="server"  Style="margin-left:0px !important;"/><br/>
                                <asp:Label ID="Label2" runat="server" Text="Authorized Stamp"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-top:50px;">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 17px;"><u>INSTRUCTIONS</u></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ol>
  <li>This Certificate is to be renewed once in five years before its expiry date, failing which it will automatically
stand inoperative.</li>
  <li>Treasury challan of fees for the purpose, deposited in any treasury of Haryana under<text style="font-weight:700;"> Head of
account: - '0043-Taxes and Duties on Electricity –Other Receipts i.e. 0043-51-800-99-51—Other
Receipts'</text> alongwith relevant Form be sent to the Chief Electrical Inspector to Government, Haryana.</li>
  <li>A Medical Fitness Certificate issued by Government / Government approved Hospital, in case he is above
55 years of age on the date of submission of application.</li>
</ol> 
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
    
</asp:Content>
