﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminMaster.aspx.cs" Inherits="CEIHaryana.Admin.AdminMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="au theme template">
    <meta name="author" content="Hau Nguyen">
    <meta name="keywords" content="CEI cei haryana">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Title Page-->
    <title>Dashboard</title>

    <!-- Fontfaces CSS-->
    <link href="/Dashboard_Css/css/font-face.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@6.4.2/css/fontawesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.11.2/font/bootstrap-icons.min.css" />
    <!-- Bootstrap CSS-->
    <link href="/Dashboard_Css/vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all">

    <!-- Vendor CSS-->
    <link href="/Dashboard_Css/vendor/animsition/animsition.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/wow/animate.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/slick/slick.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all">
    <!-- Example using CDN -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>


    <!-- Main CSS-->
    <link href="/Dashboard_Css/css/theme.css" rel="stylesheet" media="all">
    <style type="text/css">
        .overview__inner {
            margin-top: -15px;
        }

        i.bi.bi-journal-medical {
            font-size: 32px;
        }

        i.bi.bi-folder-symlink-fill {
            font-size: 32px;
        }

        i.bi.bi-file-earmark-check {
            font-size: 32px;
        }

        i.bi.bi-file-earmark-plus {
            font-size: 32px;
        }

        canvas#doughutChart {
            height: 200px !important;
            width: 525px !important;
        }

        canvas#barChart {
            height: 200px !important;
        }

        .overview-box .text span {
            font-size: 15px !important;
            color: rgba(255, 255, 255, 0.6);
            MARGIN-LEFT: 81PX;
            FONT-WEIGHT: 400;
            COLOR: WHITE;
        }

        .col-md-6 {
            max-width: 49% !important;
        }

        .content-wrapper {
            padding: 0px !important;
        }

        ::before {
            color: #ffffff !important;
        }

        h2 {
            font-size: 20px !important;
            font-weight: 700 !important;
        }

        .au-card.recent-report {
            padding: 15px !important;
        }

        .au-card.chart-percent-card {
            padding: 15px !important;
        }

        .percent-chart {
            padding-top: 10px !important;
        }

        .section__content--p30 {
            padding: 0px !important;
        }

        .container, .container-fluid, .container-sm, .container-md, .container-lg, .container-xl {
            padding-right: 2px !important;
            padding-left: 2px !important;
            margin-right: auto !important;
            margin-left: auto !important;
        }

        canvas#recent-rep-chart {
            height: 160px !important;
        }

        canvas#percent-chart {
            height: 190px !important;
        }

        .icon {
            margin-top: -8px;
        }

        input#ContentPlaceHolder1_txtFirmName {
            border: none;
            background: #2d51fe;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }

        input#ContentPlaceHolder1_TextBox1 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }

        input#ContentPlaceHolder1_TextBox3 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }

        input#ContentPlaceHolder1_TextBox4 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }

        input#ContentPlaceHolder1_TextBox2 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }

        input#ContentPlaceHolder1_TextBox5 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }
        input#ContentPlaceHolder1_TextBox6 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox7 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox8 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox9 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox10 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox11 {
            border: none;
            background: transparent;
            color: white;
            font-size: 15px;
            padding: 0px;
            margin-top: -13%;
            margin-bottom: -15px;
        }  
         input#ContentPlaceHolder1_TextBox12 {
     border: none;
     background: transparent;
     color: white;
     font-size: 15px;
     padding: 0px;
     margin-top: -13%;
     margin-bottom: -15px;
 }  
        input#ContentPlaceHolder1_TextBox13 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox14 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox15 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox16 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox17 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox18 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox19 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox20 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox21 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox22 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox23 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox24 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox25 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox26 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox27 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox28 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        input#ContentPlaceHolder1_TextBox29 {
    border: none;
    background: transparent;
    color: white;
    font-size: 15px;
    padding: 0px;
    margin-top: -13%;
    margin-bottom: -15px;
}
        .au-card.au-card--bg-blue.au-card-top-countries.m-b-40 {
    height: 300px;
}
   
     div#officers_table {
    height: 335px;
}
    <%-- ::-webkit-scrollbar {
    display: none;
}--%>
     h2.title-1.m-b-25 {
    margin-bottom: 10px;
    margin-top: 10px;
}
        input#ContentPlaceHolder1_TotalRequestRecieved {
            TEXT-ALIGN: END;
            border: none;
            background: transparent;
            color: white;
            font-size: 30px;
            padding: 0px;
            margin-top: -30%;
            margin-bottom: -2px;
            font-weight: 700;
        }

        input#ContentPlaceHolder1_Approved_rejected {
            TEXT-ALIGN: END;
            border: none;
            background: transparent;
            color: white;
            font-size: 30px;
            padding: 0px;
            margin-top: -30%;
            margin-bottom: -2px;
            font-weight: 700;
        }

        input#ContentPlaceHolder1_In_process {
            TEXT-ALIGN: END;
            border: none;
            background: transparent;
            color: white;
            font-size: 30px;
            padding: 0px;
            margin-top: -30%;
            margin-bottom: -2px;
            font-weight: 700;
        }

        input#ContentPlaceHolder1_Initiated {
            TEXT-ALIGN: END;
            border: none;
            background: transparent;
            color: white;
            font-size: 30px;
            padding: 0px;
            margin-top: -30%;
            margin-bottom: -2px;
            font-weight: 700;
        }

        .title-2 {
            text-transform: capitalize;
            font-weight: 400;
            font-size: 20px;
            line-height: 1;
        }

        input#ContentPlaceHolder1_txtApprovalAndReject  {
            TEXT-ALIGN: END;
            border: none;
            background: transparent;
            color: white;
            font-size: 30px;
            padding: 0px;
            margin-top: -30%;
            margin-bottom: -2px;
            font-weight: 700;
        }

        canvas#myDoughnutChart {
            margin-top: -50px;
            height: 290px;
        }
     canvas#myChart {
    height: 240px !important;
}
     th.headercolor {
    background: #1d4be3;
    padding:9px;
}
     .au-card.au-card--bg-blue.au-card-top-countries.m-b-40 {   
    background: white;
    padding: 10px;
}
    th.division-align {
    text-align: left;
}
    th.staff-align {
    text-align: left;
}
.overview-item.overview-item--c1 {
    background: #604db8;
}
 .overview-item.overview-item--c2 {
    background: #63c28d;
}
 .overview-item.overview-item--c3 {
    background: #f13a94;
}
 .overview-item.overview-item--c4 {
    background: #ff826c;
}
        h3.title-2.m-b-40 {
            margin-top: -20px;
            margin-bottom: 30px;
            font-weight: 700;
        }

        a#ContentPlaceHolder1_HyperLink1 {
            color: blue;
            text-decoration-line: underline;
            font-size: 17px;
            margin-right: 10px;
            margin-bottom: 5px;
        }

        .bi-printer-fill::before {
            content: "\f500";
            color: blue !important;
            font-size: 30px;
            margin-right: 6px;
        }

        span#APPROVED {
             MARGIN-LEFT: 9%;
        }

        span#PROCESS {
            margin-left: 69%;
        }

        span#INITIATED {
            margin-left: 49%;
        }
        table#ContentPlaceHolder1_GridView2 {
    width: 775px !important;
}
        table#ContentPlaceHolder1_GridView3 {
    width: 775px !important;
}
          svg {
            margin-right: 0px;
            height: 20px;
            width: 23px;
        }

          a#ContentPlaceHolder1_GridView1_LinkButton4_0 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_0:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_1 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_1:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_2 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_2:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_3 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_3:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_4 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_4:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_5 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_5:hover {
    font-weight: 600;
    text-decoration: underline;
}
                    a#ContentPlaceHolder1_GridView1_LinkButton4_6 {
    font-weight: 600;
    letter-spacing: 2px;
}
          a#ContentPlaceHolder1_GridView1_LinkButton4_6:hover {
    font-weight: 600;
    text-decoration: underline;
}
          a#ContentPlaceHolder1_GridView2_LinkButton1_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton1_1{
              font-weight: 600;
text-decoration: underline;
          }
                    a#ContentPlaceHolder1_GridView2_LinkButton1_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton1_1{
              font-weight: 600;
text-decoration: underline;
          }          a#ContentPlaceHolder1_GridView2_LinkButton1_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton1_1{
              font-weight: 600;
text-decoration: underline;
          }          a#ContentPlaceHolder1_GridView2_LinkButton1_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton1_1{
              font-weight: 600;
text-decoration: underline;
          }          a#ContentPlaceHolder1_GridView2_LinkButton2_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton2_1{
              font-weight: 600;
text-decoration: underline;
          }          a#ContentPlaceHolder1_GridView2_LinkButton3_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton3_1{
              font-weight: 600;
text-decoration: underline;
          }          a#ContentPlaceHolder1_GridView2_LinkButton4_0{
              font-weight: 600;
letter-spacing: 2px;
          }
          a#ContentPlaceHolder1_GridView2_LinkButton4_1{
              font-weight: 600;
text-decoration: underline;
          }
.overview-box .text {
    font-weight: 300;
    display: inline-block;
    text-align: end;
}
          p {
    font-weight: 600;
}
          input#ContentPlaceHolder1_TotalRequestRecieved {
    padding-top: 20px;
}
          input#ContentPlaceHolder1_txtApprovalAndReject {
    margin-bottom: 8px;
}
          input#ContentPlaceHolder1_In_process {
    margin-bottom: 8px;
}
          input#ContentPlaceHolder1_Initiated {
    margin-bottom: 8px;
}
          div#firstcapsule {
    padding-bottom: 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper" style="margin-top:30px;">
        <%--<div class="main-content">--%>
        <div class="section__content section__content--p30">
            <div class="container-fluid">
                <%--<div class="row">
                        <div class="col-md-12">
                            <div class="overview-wrap">
                                <h2 class="title-1">overview</h2>
                                <button class="au-btn au-btn-icon au-btn--blue">
                                    <i class="zmdi zmdi-plus"></i>add item</button>
                            </div>
                        </div>
                    </div>--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card" style="background: #f9f9f9; margin: 15px; margin-top: 10px; margin-bottom: 10px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding: 0px 24px 5px 25px; border-radius: 10px;">
                            <div class="row m-t-25">
                                <div class="col-sm-6 col-lg-3">
                                    <div class="overview-item overview-item--c1">
                                        <div class="overview__inner">
                                             <a href="TotalRequestInspectionForAdmin.aspx">
                                            <div class="overview-box clearfix">
                                                <div class="icon">
                                                    <i class="bi bi-file-earmark-plus"></i>
                                                </div>
                                                <div class="text" id="firstcapsule">
                                                    <h2>
                                                        <asp:TextBox class="form-control" ID="TotalRequestRecieved" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                        <br/> <p>All Requests Recieved</p>
                                                    </h2>

                                                   
                                                </div>
                                            </div>
                                                 </a>
                                            <%--<div class="overview-chart">
                                        <canvas id="widgetChart1"></canvas>
                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-lg-3">
                                    <div class="overview-item overview-item--c2">
                                        <div class="overview__inner">
                                             <a href="AcceptedOrRejectedRequest.aspx">
                                            <div class="overview-box clearfix">
                                                <div class="icon">
                                                    <i class="bi bi-file-earmark-check"></i>
                                                </div>
                                                <div class="text">
                                                    <h2>
                                                        <asp:TextBox class="form-control" ID="txtApprovalAndReject" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                        <p id="APPROVED">Approved/Rejected/Returned</p>
                                                    </h2>

                                                    
                                                </div>
                                            </div>
                                                 </a>
                                            <%--<div class="overview-chart">
                                        <canvas id="widgetChart2"></canvas>
                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-lg-3">
                                    <div class="overview-item overview-item--c3">
                                        <div class="overview__inner">
                                            <a href="InProcessRequest.aspx">
                                            <div class="overview-box clearfix">
                                                <div class="icon">
                                                    <i class="bi bi-journal-medical"></i>
                                                </div>
                                                <div class="text">
                                                    <h2>
                                                        <asp:TextBox class="form-control" ID="In_process" runat="server" onkeydown="return preventEnterSubmit(event)"
                                                            autocomplete="off" ReadOnly="true"></asp:TextBox>

                                                    <p id="PROCESS">In Process</p>
</h2>
                                                </div>
                                            </div>
                                                </a>
                                            <%--<div class="overview-chart">
                                        <canvas id="widgetChart3"></canvas>
                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-lg-3">
                                    <div class="overview-item overview-item--c4">
                                        <div class="overview__inner">
                                             <a href="NewRequestInspectionForAdmin.aspx">
                                            <div class="overview-box clearfix">
                                                <div class="icon">
                                                    <i class="bi bi-folder-symlink-fill"></i>
                                                </div>
                                                <div class="text">
                                                    <h2>
                                                        <asp:TextBox class="form-control" ID="Initiated" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" ReadOnly="true"></asp:TextBox>

                                                    <p id="INITIATED">New Application</p>
                                                    </h2>
                                                </div>
                                            </div>
                                                 </a>
                                            <%--<div class="overview-chart">
                                        <canvas id="widgetChart4"></canvas>
                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="background: #f9f9f9; margin: 5px; border-radius: 10px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-top: 15px; margin: 18px;">
                            <div class="row" style="margin-left: 4px;">

                                <div class="col-md-6">
                                    <div class="au-card m-b-30">
                                        <div class="au-card-inner" style="text-align: -webkit-center !important;">
                                            <h3 class="title-2 m-b-40">Pending Status(division Wise)</h3>
                                            <canvas id="myChart" width="400" height="200"></canvas>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="au-card m-b-30">
                                        <div class="au-card-inner" style="text-align: -webkit-center !important;">
                                            <h3 class="title-2 m-b-40">Overall Applications Representation</h3>
                                            <canvas id="myDoughnutChart" width="400" height="322"></canvas>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: -10px !important;">
                               <div class="col-md-8">
                                <div class="card" style="box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1); margin-left: 15px; border-radius: 10px;">

                                    <div class="col-md-12">
                                        <h2 class="title-1 m-b-25">Division Wise Report</h2>

                                        <div>
                                            <div id="printableDiv">
                                                <asp:GridView CssClass="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderStyle Width="34%" CssClass="headercolor division-align" />
                                                            <ItemStyle Width="34%" />
                                                            <HeaderTemplate>
                                                                Division
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Division") %> ' CommandName="Select"><%#Eval("Division") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArea" runat="server" Text='<%#Eval("Area") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RecordCount" HeaderText="Total Request">
                                                            <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Initiated" HeaderText="New Application">
                                                            <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="13%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InProgress" HeaderText="In Process">
                                                            <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="13%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ActionTaken" HeaderText="Action Taken">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>

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
                                            <div id="printableDiv2">
                                                <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView2" Visible="false"
                                                    OnRowCommand="GridView2_RowCommand" AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" PageSize="10"
                                                    AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    BorderWidth="1px" BorderColor="#dbddff">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No">
                                                            <HeaderStyle Width="5%" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDistrictofData" runat="server" Text='<%#Eval("DistrictofData") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="DistrictofData" HeaderText="District">
                                                            <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="13%" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Less than 15 Days">
                                                            <HeaderStyle Width="25%" CssClass="headercolor" />
                                                            <ItemStyle Width="25%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("15Days") %> ' CommandName="Select15Days"><%#Eval("15Days") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="15 to 30 days">
                                                            <HeaderStyle Width="25%" CssClass="headercolor" />
                                                            <ItemStyle Width="25%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("15to30Days") %> ' CommandName="Select15to30Days"><%#Eval("15to30Days") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="30 to 45 Days">
                                                            <HeaderStyle Width="25%" CssClass="headercolor" />
                                                            <ItemStyle Width="25%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton3" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("30to45Days") %> ' CommandName="Select30to45Days"><%#Eval("30to45Days") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="More than 45 Days">
                                                            <HeaderStyle Width="25%" CssClass="headercolor" />
                                                            <ItemStyle Width="25%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton5" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("MoreThan45Days") %> ' CommandName="SelectMoreThan45Days"><%#Eval("MoreThan45Days") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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

                                            <div class="row" style="text-align: center; margin-top: 10px; margin-bottom: 10px;">
                                                <div class="col-6" id="Back" runat="server" visible="false" style="text-align: end;">
                                                    <a href="/Admin/AdminMaster.aspx">
                                                        <svg xmlns="http://www.w3.org/2000/svg" height="30" width="30" fill="blue" viewBox="0 0 512 512">
                                                            <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2023 Fonticons, Inc.-->
                                                            <path d="M512 256A256 256 0 1 0 0 256a256 256 0 1 0 512 0zM231 127c9.4-9.4 24.6-9.4 33.9 0s9.4 24.6 0 33.9l-71 71L376 232c13.3 0 24 10.7 24 24s-10.7 24-24 24l-182.1 0 71 71c9.4 9.4 9.4 24.6 0 33.9s-24.6 9.4-33.9 0L119 273c-9.4-9.4-9.4-24.6 0-33.9L231 127z" />
                                                        </svg></a>
                                                </div>
                                                <div class="col-6" id="PrintableDivision" runat="server" style="text-align: end; margin-top: auto;">
                                                    <a href="#" id="btnPrint" onclick="printDiv('printableDiv');"><i class="bi bi-printer-fill"></i><%--<asp:HyperLink ID="HyperLink1" runat="server">Print</asp:HyperLink>--%></a>
                                                </div>
                                                <div class="col-6" id="PrintableDistrict" runat="server" visible="false" style="text-align: left; margin-top: auto;">
                                                    <a href="#" id="btnPrintDistrict" onclick="printDiv2('printableDiv2');"><i class="bi bi-printer-fill"></i><%--<asp:HyperLink ID="HyperLink1" runat="server">Print</asp:HyperLink>--%></a>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                   </div>
                                <div class="col-md-4">
                                <div class="card" style="box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1); background: #604db8; border-radius: 10px;width:94%;">
                                    <div class="col-lg-10">
                                        <h2 class="title-1 m-b-25" style="color: white;">Officers Pendency</h2>
                                        <div class="card" style="box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1); margin-left: 0px; margin-right: -50px;">
                                            <div class="au-card-inner">
                                                <div class="table-responsive" id="officers_table">
                                                    <asp:GridView CssClass="table-responsive table table-hover table-striped" ID="OfficersGrid" runat="server" Width="100%"
                                                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>

                                                            <asp:BoundField DataField="UserId" HeaderText="Staff UserId">
                                                                <HeaderStyle HorizontalAlign="left" Width="13%" CssClass="headercolor staff-align" />
                                                                <ItemStyle HorizontalAlign="left" Width="13%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Pending" HeaderText="Pending">
                                                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                                <ItemStyle HorizontalAlign="center" Width="12%" />
                                                            </asp:BoundField>

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
                                    </div>
                                </div>
                                    </div>
                                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%-- </div>--%>
        </div>
    </div>
    <script src="/Dashboard_Css/vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="/Dashboard_Css/vendor/bootstrap-4.1/popper.min.js"></script>

    <!-- Vendor JS       -->
    <script src="/Dashboard_Css/vendor/slick/slick.min.js">    </script>
    <script src="/Dashboard_Css/vendor/wow/wow.min.js"></script>
    <script src="/Dashboard_Css/vendor/animsition/animsition.min.js"></script>
    <script src="/Dashboard_Css/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">    </script>
    <script src="/Dashboard_Css/vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="/Dashboard_Css/vendor/counter-up/jquery.counterup.min.js">    </script>
    <script src="/Dashboard_Css/vendor/circle-progress/circle-progress.min.js"></script>
    <script src="/Dashboard_Css/vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="/Dashboard_Css/vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="/Dashboard_Css/vendor/select2/select2.min.js">    </script>

    <!-- Main JS-->
    <script src="/Dashboard_Css/js/main.js"></script>

    <script>

        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <script>

        function printDiv2(printableDiv2) {
            var printContents = document.getElementById(printableDiv2).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>
