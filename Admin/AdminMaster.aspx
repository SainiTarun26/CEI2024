<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="AdminMaster.aspx.cs" Inherits="CEIHaryana.Admin.AdminMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="au theme template">
    <meta name="author" content="Hau Nguyen">
    <meta name="keywords" content="au theme template"> 

    <!-- Title Page-->
    <title>Dashboard</title>

    <!-- Fontfaces CSS-->
    <link href="/Dashboard_Css/css/font-face.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all">
    <link href="/Dashboard_Css/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">

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
        canvas#doughutChart {
    height: 200px !important;
    width:525px !important;
}
        canvas#barChart {
    height: 200px !important;
}
        .overview-box .text span {
    font-size: 15px !important;
    color: rgba(255, 255, 255, 0.6);
}
        .col-lg-6 {
            max-width: 47% !important;
        }

        .content-wrapper {
            padding: 0px !important;
        }

        ::before {
            color: #ffffff !important;
        }

        h2 {
            font-size: 20px !important;
            font-weight:700 !important;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
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
                <div class="card" style="background: #f9f9f9; margin: 5px; margin-top: 10px; margin-bottom: 10px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding: 2px 30px 5px 30px;">
                    <div class="row m-t-25">
                        <div class="col-sm-6 col-lg-3">
                            <div class="overview-item overview-item--c1">
                                <div class="overview__inner">
                                    <div class="overview-box clearfix">
                                        <div class="icon">
                                            <i class="zmdi zmdi-account-o"></i>
                                        </div>
                                        <div class="text">
                                            <h2>10368</h2>
                                            <span>members online</span>
                                        </div>
                                    </div>
                                    <%--<div class="overview-chart">
                                        <canvas id="widgetChart1"></canvas>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="overview-item overview-item--c2">
                                <div class="overview__inner">
                                    <div class="overview-box clearfix">
                                        <div class="icon">
                                            <i class="zmdi zmdi-shopping-cart"></i>
                                        </div>
                                        <div class="text">
                                            <h2>388,688</h2>
                                            <span>items solid</span>
                                        </div>
                                    </div>
                                    <%--<div class="overview-chart">
                                        <canvas id="widgetChart2"></canvas>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="overview-item overview-item--c3">
                                <div class="overview__inner">
                                    <div class="overview-box clearfix">
                                        <div class="icon">
                                            <i class="zmdi zmdi-calendar-note"></i>
                                        </div>
                                        <div class="text">
                                            <h2>1,086</h2>
                                            <span>this week</span>
                                        </div>
                                    </div>
                                    <%--<div class="overview-chart">
                                        <canvas id="widgetChart3"></canvas>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="overview-item overview-item--c4">
                                <div class="overview__inner">
                                    <div class="overview-box clearfix">
                                        <div class="icon">
                                            <i class="zmdi zmdi-money"></i>
                                        </div>
                                        <div class="text">
                                            <h2>$1,060,386</h2>
                                            <span>total earnings</span>
                                        </div>
                                    </div>
                                    <%--<div class="overview-chart">
                                        <canvas id="widgetChart4"></canvas>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card" style="background: #f9f9f9; margin: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding: 12px;">
                    <div class="row" style="margin-left: 20px;">

                        <div class="col-lg-6">
                                <div class="au-card m-b-30">
                                    <div class="au-card-inner">
                                        <h3 class="title-2 m-b-40">Bar chart</h3>
                                          <canvas id="myChart" width="400" height="200"></canvas>
                                    </div>
                                </div>
                            </div>
                        <div class="col-lg-6" style="margin-left:30px !important;">
                                <div class="au-card m-b-30">
                                    <div class="au-card-inner">
                                        <h3 class="title-2 m-b-40">Doughut Chart</h3>
                                        <canvas id="doughutChart"></canvas>
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="row" style="margin-top:-20px !important;">
                        <div class="col-lg-9">
                            <h2 class="title-1 m-b-25">Earnings By Items</h2>
                            <div class="table-responsive table--no-card m-b-40">
                                <table class="table table-borderless table-striped table-earning">
                                    <thead>
                                        <tr>
                                            <th>date</th>
                                            <th>order ID</th>
                                            <th>name</th>
                                            <th class="text-right">price</th>
                                            <th class="text-right">quantity</th>
                                            <th class="text-right">total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>2018-09-29 05:57</td>
                                            <td>100398</td>
                                            <td>iPhone X 64Gb Grey</td>
                                            <td class="text-right">$999.00</td>
                                            <td class="text-right">1</td>
                                            <td class="text-right">$999.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-28 01:22</td>
                                            <td>100397</td>
                                            <td>Samsung S8 Black</td>
                                            <td class="text-right">$756.00</td>
                                            <td class="text-right">1</td>
                                            <td class="text-right">$756.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-27 02:12</td>
                                            <td>100396</td>
                                            <td>Game Console Controller</td>
                                            <td class="text-right">$22.00</td>
                                            <td class="text-right">2</td>
                                            <td class="text-right">$44.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-26 23:06</td>
                                            <td>100395</td>
                                            <td>iPhone X 256Gb Black</td>
                                            <td class="text-right">$1199.00</td>
                                            <td class="text-right">1</td>
                                            <td class="text-right">$1199.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-25 19:03</td>
                                            <td>100393</td>
                                            <td>USB 3.0 Cable</td>
                                            <td class="text-right">$10.00</td>
                                            <td class="text-right">3</td>
                                            <td class="text-right">$30.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-29 05:57</td>
                                            <td>100392</td>
                                            <td>Smartwatch 4.0 LTE Wifi</td>
                                            <td class="text-right">$199.00</td>
                                            <td class="text-right">6</td>
                                            <td class="text-right">$1494.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-24 19:10</td>
                                            <td>100391</td>
                                            <td>Camera C430W 4k</td>
                                            <td class="text-right">$699.00</td>
                                            <td class="text-right">1</td>
                                            <td class="text-right">$699.00</td>
                                        </tr>
                                        <tr>
                                            <td>2018-09-22 00:43</td>
                                            <td>100393</td>
                                            <td>USB 3.0 Cable</td>
                                            <td class="text-right">$10.00</td>
                                            <td class="text-right">3</td>
                                            <td class="text-right">$30.00</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <h2 class="title-1 m-b-25">Top countries</h2>
                            <div class="au-card au-card--bg-blue au-card-top-countries m-b-40">
                                <div class="au-card-inner">
                                    <div class="table-responsive">
                                        <table class="table table-top-countries">
                                            <tbody>
                                                <tr>
                                                    <td>United States</td>
                                                    <td class="text-right">$119</td>
                                                </tr>
                                                <tr>
                                                    <td>Australia</td>
                                                    <td class="text-right">$70</td>
                                                </tr>
                                                <tr>
                                                    <td>United Kingdom</td>
                                                    <td class="text-right">$46</td>
                                                </tr>
                                                <tr>
                                                    <td>Turkey</td>
                                                    <td class="text-right">$35</td>
                                                </tr>
                                                <tr>
                                                    <td>Germany</td>
                                                    <td class="text-right">$20</td>
                                                </tr>
                                                <tr>
                                                    <td>France</td>
                                                    <td class="text-right">$103</td>
                                                </tr>
                                                <tr>
                                                    <td>Australia</td>
                                                    <td class="text-right">$5,366.96</td>
                                                </tr>
                                                <tr>
                                                    <td>Italy</td>
                                                    <td class="text-right">$1639.32</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- </div>--%>
        </div>
    </div>
    <script src="/Dashboard_Css/vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="/Dashboard_Css/vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="/Dashboard_Css/vendor/bootstrap-4.1/bootstrap.min.js"></script>
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

</asp:Content>
