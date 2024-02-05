<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationForLiftEscalators.aspx.cs" Inherits="CEIHaryana.UserPages.ApplicationForLiftEscalators" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.css" />
    <script src="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.8.1/js/bootstrap-select.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <link
        href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i"
        rel="stylesheet" />
    <!-- Vendor CSS Files -->
    <link href="/assetsnew/vendor/aos/aos.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/glightbox/css/glightbox.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/swiper/swiper-bundle.min.css" rel="stylesheet" />
    <!-- Template Main CSS File -->
    <link href="/assetsnew/css/style.css" rel="stylesheet" />
    <link href="/assetsnew/css/style2.css" rel="stylesheet" />
    <link rel="stylesheet" href="/vendors/feather/feather.css" />
    <link rel="stylesheet" href="/vendors/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="/vendors/css/vendor.bundle.base.css" />
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <link rel="stylesheet" href="/vendors/select2/select2.min.css" />
    <link rel="stylesheet" href="/vendors/select2-bootstrap-theme/select2-bootstrap.min.css" />
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="/css/vertical-layout-light/style.css" />
    <!-- endinject -->
    <link rel="shortcut icon" href="/images/favicon.png" />

    <style>
        img {
    margin-top: -7px;
    width: 100%;
    margin-bottom: 9px;
    height: 40px;
    margin-left: 6px;
}

        @media all and (max-width:700px) {
            div.image_map {
                width: 480px;
                height: 360px;
                overflow: hidden;
                position: relative;
                border: solid red;
                box-shadow: 0 0 0.5em white, 0 0 0 2000px rgba(100, 50, 0, 0.5);
                transition: 0.5s;
            }

            html {
                transition: 0.5s;
                font-size: 20px;
            }

            .image_map img,
            map {
                position: absolute;
                transform: scale(0.75);
                transform-origin: 0 0
            }
        }

        @media all and (max-width:500px) {
            div.image_map {
                border: solid blue;
                width: 320px;
                height: 240px;
                overflow: hidden;
                position: relative;
                border: solid;
                box-shadow: 0 0 0.5em white, 0 0 0 2000px rgba(0, 100, 200, 0.5);
                transition: 0.5s;
            }

            html {
                transition: 0.5s;
                font-size: 15px;
            }

            .image_map img,
            map {
                position: absolute;
                transform: scale(0.5);
                transform-origin: 0 0
            }
        }

        img {
            vertical-align: top;
        }

        h1,
        p {
            margin: 0;
        }

        /* chrome */
        map,
        area {  
            position: absolute;
            display: block;
            text-align: center
        }

        map {
            top: 177px;
            left: 200px;
            font-size: 2em;
        }



        area[title="Lien 1"] {
           top: 8px;
    left: 0;
    width: 150px;
    height: 35px;/*
    background: rgba(0, 0, 0, 0.5);*/
    line-height: 248px;
    border-radius: 20px;
        }

        area[title="lien 2"] {
            top: 8px;
            left: 315px;
            width: 150px;
            height: 35px;
           /* background: rgba(0, 0, 0, 0.5);*/
            line-height: 248px;
            border-radius: 54px;
        }

        area[title="lien 3"] {
            top: 0px;
            left: 365px;
            width: 86px;
            height: 50px;
            /*background: rgba(0, 0, 0, 0.5);*/
            line-height: 232px;
            border-radius: 22px;
        }

        area[title="lien 4"] {
            top: 0px;
            left: 544px;
            width: 87px;
            height: 50px;
           /* background: rgba(0, 0, 0, 0.5);*/
            line-height: 232px;
            border-radius: 20px;
        }

        area:hover {
            background: none;
        }
        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        svg.bi.bi-person-circle {
            color: white;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: -175px;
            margin-top: 7px;
        }


        li#logout {
            padding: 10px;
            background: #4B49AC !important;
            border-radius: 51px !important;
            }
        input#txtMakerName:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtMakerLocalAgent:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtMakerAddress:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtLiftSpeed:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtLiftLoad:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtPersonLoad:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtLiftWeight:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtCounterWeight:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtNumberSuspension:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtDiscription:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtWeight:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtSize:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtPitDepth:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtTotalFloors:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtConstructionDetails:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlApplicantType:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtNameOfApplicant:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtPhoneNo:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtOfficeAddress:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlApplicantState:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlapplicantdistrict:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtPinCode:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtAgentName:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtAgentContactNo:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtAgentAddress:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlAgentState:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#dllAgentdistrict:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtAgentPincode:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtOwnerName:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtLiftAddress:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlLiftState:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlLiftDistrict:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtLiftPincode:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtDateOfErection:Hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        input#txtTypeOfLift:hover {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlApplicantType {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlAgentState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#select#dllAgentdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlLiftState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlLiftDistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlapplicantdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlApplicantState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlagentdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlagentdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#dllAgentdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#Dllagentdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#ddlliftdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlliftdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#ddlfiltstate {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlfiltstate:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        label {
            font-size: 13px !important;
        }

        ::placeholder {
            color: black !important;
            opacity: 1; /* Firefox */
            font-size: 11px !important;
        }

        ::-ms-input-placeholder { /* Edge 12-18 */
            color: black !important;
            font-size: 11px !important;
        }

        .choices__inner {
            display: inline-block;
            vertical-align: top;
            width: 100%;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 2.5px;
            font-size: 14px;
            min-height: 60px;
            overflow: hidden;
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        input.form-control.file-upload-info {
            height: 1px;
        }

        input#exampleInputUsername1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputUsername1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputUsername1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input#exampleInputEmail1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputEmail1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputEmail1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#exampleFormControlSelect3 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#exampleFormControlSelect3:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#exampleFormControlSelect3:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input.form-control {
            height: 1px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }

        input.form-control {
            height: 1px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }

        input#exampleInputConfirmPassword12 {
            width: 100%;
        }

        input#exampleInputConfirmPassword13 {
            width: 100%;
            height: 31px;
        }

        select#ddlGender {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlGender:hover {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlGender:focus {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#ddlcategory {
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
            border: 1px solid #ced4da;
            border-radius: 5px;
            width: 100%;
        }

            select#ddlcategory:hover {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlcategory:focus {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        textarea#txtCommunicationAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#txtCommunicationAddress:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            textarea#txtCommunicationAddress:focus {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        textarea#txtPermanentAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#txtPermanentAddress:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            textarea#txtPermanentAddress:focus {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#DropDownList1 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList1:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList1:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList2 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList2:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList2:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        th#pincoe {
            width: 8%;
        }

        select#DropDownList3 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList3:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList3:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList4 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList4:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList4:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#ddlGender {
            color: #252525;
        }

        input#Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnUpload {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .form-group {
            margin-bottom: 5px !important;
        }

        div#CalculatedDatey {
            margin-top: 20px;
        }

        select#ddlState1:hover {
            height: 31px;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
        }

        .validation_required {
            font-size: 13px;
        }

        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            vertical-align: top;
            margin-bottom: 0px !important;
        }

        img {
            margin-top: 0px;
            margin-bottom: 9px;
        }

        input#txtapplication {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtid {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtInstallation {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtNOOfInstallation {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        td {
            padding: 1% !important;
        }

            td#authoritytype {
                width: 0% !important;
            }

        th#FullName {
            width: 20% !important;
        }

        th#sno {
            width: 0% !important;
        }

        input#txtDescription2 {
            width: 100%;
        }

        input#TextBox2 {
            width: 100%;
        }

        .form-control {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>

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
</head>
<body>

    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <section id="topbar" class="d-flex align-items-center">
            <div class="d-flex justify-content-center justify-content-md-between">
                <div class="contact-info d-flex align-items-center">
                    <i class="bi bi-envelope d-flex align-items-center">
                        <a href="mailto:cei_goh@yahoo.com">cei_goh@yahoo.com</a>
                    </i>
                    <i class="bi bi-phone d-flex align-items-center ms-4">
                        <span>0172 2704090</span>
                    </i>
                </div>
                <div class="social-links d-none d-md-flex align-items-center">
                    <a href="#" class="twitter">
                        <i class="bi bi-twitter"></i>
                    </a>
                    <a href="#" class="facebook">
                        <i class="bi bi-facebook"></i>
                    </a>
                    <a href="#" class="instagram">
                        <i class="bi bi-instagram"></i>
                    </a>
                    <a href="#" class="linkedin">
                        <i class="bi bi-linkedin"></i>

                    </a>
                </div>
            </div>
        </section>
        <!-- ======= Header ======= -->
        <header id="header" class="d-flex align-items-center"
            style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
            <div class="container d-flex align-items-center justify-content-between">
                <a href="index.html" class="logo">
                    <img src="../Assets/Add a heading (1).png" />
                </a>
                <%--<h1 class="logo">
            <a href="index.html">
                <span style="font-size: 18px; margin-left: -30px;">CEI, Haryana<span>.</span></span>
            </a>
        </h1>--%>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">About CEI</a>
                    </li>
                    <li>
                        <a href="#">State Licensing Board, Haryana</a>
                    </li>
                    <li>
                        <a href="#">Functions</a>
                    </li>
                </ul>--%>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Lift & Esclator</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Procedure For Registration/
                        <br>
                            Inspection Lifts and Esclators
                        </a>
                    </li>
                    <li>
                        <a href="#">Checklist for Registration/
                        <br>
                            Inspection of Lifts and Esclators
                        </a>
                    </li>
                    <li>
                        <a href="#">Forms</a>
                    </li>
                </ul>--%>

                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Licensing</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Procedure/ Condition
                        <br>
                            for Various Licences/ Certificates
                        </a>
                    </li>
                    <li>
                        <a href="#">Electrical Supervisor Competency
                        <br />
                            Certificate(Excemption)
                        </a>
                    </li>
                    <li>
                        <a href="#">Forms(Licence)</a>
                    </li>
                </ul>--%>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Inspection</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Checklist for Online Service(Inspection)</a>
                    </li>
                    <li>
                        <a href="#">Procedure for Electrical Installation</a>
                    </li>
                    <li>
                        <a href="#">Procedure for Grant of
                        <br>
                            approval for Energisation of
                        <br>
                            New Electrical Installation
                        </a>
                    </li>
                </ul>--%>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Our Services</a>
                    </li>
                </ul>--%>
                        </li>
                        <li>
                            <a class="nav-link scrollto" href="#contact">Contact Us</a>
                        </li>

                        <li class="dropdown" id="logout" style="margin-left: 300px;">
                            <a href="#">
                                <span id="user">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                                    </svg></span>

                            </a>
                            <ul id="profile_drop">
                                <li id="ProfileUser">
                                    <a href="#">
                                        <span>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-badge" viewBox="0 0 16 16">
                          User      
<path d="M6.5 2a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path d="M4.5 0A2.5 2.5 0 0 0 2 2.5V14a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2.5A2.5 2.5 0 0 0 11.5 0zM3 2.5A1.5 1.5 0 0 1 4.5 1h7A1.5 1.5 0 0 1 13 2.5v10.795a4.2 4.2 0 0 0-.776-.492C11.392 12.387 10.063 12 8 12s-3.392.387-4.224.803a4.2 4.2 0 0 0-.776.492z" />
                                    </svg>&nbsp;&nbsp;</span>

                                    </a>
                                </li>
                                <li id="ProfileLogout">
                                    <a href="#">
                                        <span>

                                            <asp:Button ID="btnLogout" OnClick="btnLogout_Click" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />

                                        </span>

                                    </a>
                                </li>

                            </ul>
                        </li>
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->
            </div>

        </header>
        <!-- End Header -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <main id="main">
                    <section id="about" class="about section-bg" style="padding-top: 20px;">
                        <div class="container" data-aos="fade-up">
                            <div class="row">
                                <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                                    <p style="text-align: center;">
                                        (Please read the instructions carefully as given in Instruction
                            Page before filling the form)                           
                                    </p>
                                    <%--<img src="/Assets/capsules/CONTRACTOR_APPLICATION_CAPSULE.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="image_map">
        <img id="Image-Maps_6201305161140066" src="/Assets/capsules/CONTRACTOR_APPLICATION_CAPSULE.png"
            usemap="#Image-Maps_6201305161140066" border="0" width="640" height="50" alt="No Img Found" />
        <map id="_Image-Maps_6201305161140066" name="Image-Maps_6201305161140066">
            <area shape="rect" coords="0,0,140,90" href="Registration.aspx" alt="" title="Lien 1" />
            <area shape="rect" coords="100,1,150,250" href="Registration.aspx" alt="" title="lien 2" />
          
        </map>
    </div>
                                </div>
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-12">
                                    <div class="card"
                                        style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-12 grid-margin stretch-card">
                                                    <div class="card">

                                                        <div class="card-body">
                                                            <div class="row" style="margin-top: -15px;">
                                                                <div class="col-12" style="text-align: left;">
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">APPLICANT DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 20px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Type of Applicant
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <%--<asp:TextBox class="form-control" ID="TextBox1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>--%>
                                                                        <asp:DropDownList ID="ddlApplicantType" runat="server" class="select-form select2">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Individual" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Govt Organization/Department" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Private Agency/Firm/Company" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlApplicantType" InitialValue="0" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select Applicant Type</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Name of Applicant
                                                                         <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtNameOfApplicant" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtNameOfApplicant" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name of Applicant</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Phone No.
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPhoneNo" onkeypress="return isNumberKey(event)" MaxLength="10" onkeydown="return preventEnterSubmit(event)"  onkeyup="return isvalidphoneno();" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Phone No.</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row" style="margin-top: 18px;">
                                                                    <div class="col-8">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Office Address
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtOfficeAddress" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtOfficeAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            State
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlApplicantState" AutoPostBack="true" OnSelectedIndexChanged="ddlApplicantState_SelectedIndexChanged" runat="server">
                                                                            <%-- <asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="0" ControlToValidate="ddlApplicantState" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select State</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4" style="margin-top: 18px;">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            District
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlapplicantdistrict" AutoPostBack="true" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" InitialValue="0" ControlToValidate="ddlapplicantdistrict" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select District</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4" style="margin-top: 18px;">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Pincode
                                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPinCode" onkeypress="return isNumberKey(event)" MaxLength="6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPinCode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter PinCode</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-top: 50px;">
                                                                <div class="col-12" style="text-align: left;">
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">LOCAL AGENT DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 20px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Name of Agent
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAgentName" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAgentName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name Of Agent</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Contact
   
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAgentContactNo" onkeypress="return isNumberKey(event)" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgentContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Address
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAgentAddress" MaxLength="60" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAgentAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="row" style="margin-top: 18px;">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            State
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlAgentState" OnSelectedIndexChanged="ddlAgentState_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAgentState" InitialValue="0" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select State</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            District
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="dllAgentdistrict" AutoPostBack="true" runat="server">
                                                                            <%--   <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ControlToValidate="dllAgentdistrict" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select District</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Pincode
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAgentPincode" MaxLength="6" onkeypress="return isNumberKey(event)" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgentPincode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter PinCode</asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="card-body">
                                                            <div class="row" style="margin-top: -15px;">
                                                                <div class="col-12" style="text-align: left;">
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">LIFT INSTALLATION DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Owner Name
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtOwnerName" MaxLength="30" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtownername" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Owner Name</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Address
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLiftAddress" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLiftAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            State
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlLiftState" OnSelectedIndexChanged="ddlLiftState_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                            <%--   <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" InitialValue="0" ControlToValidate="ddlLiftState" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select State</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            District
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlLiftDistrict" AutoPostBack="true" runat="server">
                                                                            <%-- <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlliftdistrict" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" InitialValue="0" ForeColor="Red">Please Select District</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            PinCode
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLiftPincode" onkeypress="return isNumberKey(event)" MaxLength="6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtliftpincode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter PinCode</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Date of Erection
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox Type="date" class="form-control" ID="txtDateOfErection" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDateOfErection" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Erection</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Type of Lift
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtTypeOfLift" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtTypeOfLift" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type of Lift</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="card-body">
                                                            <div class="row" style="margin-top: -15px;">
                                                                <div class="col-12" style="text-align: left;">
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">MAKER DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Maker's Name
                                                           <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtMakerName" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="30" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtmakername" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Maker's Name</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Maker's Local Agent
                                                                 <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtMakerLocalAgent" onKeyPress="return alphabetKey(event);" MaxLength="30" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtmakerlocalagent" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Maker's Local Agent</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Address
                                                               <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtMakerAddress" onkeydown="return preventEnterSubmit(event)" placeholder="" MaxLength="50"  autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtmakeraddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Contract Speed of Lift
                                                               <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLiftSpeed" onKeyPress="return isNumberKey(event);" MaxLength="3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtliftspeed" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contract Speed of Lift</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Contract Load of Lift
                                                                  <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLiftLoad" onkeypress="return isNumberKey(event)" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtliftload" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contract Load of Lift</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            No. of Person Carring Capicity of Lift 
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPersonLoad" onkeypress="return isNumberKey(event)" MaxLength="2" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtpersonload" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Person Carring Capicity of Lift</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Total Weight of Lift Car (in Kg)
                                                                       <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLiftWeight" onkeypress="return isNumberKey(event)" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtliftweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Total Weight of Lift Car(Kg)</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Weight of the Counter Weight (in Kg)
                                                                       <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtCounterWeight" onkeypress="return isNumberKey(event)" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtcounterweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-top: -15px; margin-top: 50px;">
                                                                <div class="col-12" style="text-align: left;">
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">SUSPENSION ROPES DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            No. of suspension Roops
                                                                      <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtNumberSuspension" onkeypress="return isNumberKey(event)" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtNumberSuspension" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of suspension Roops</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Discription 
                                                               <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtDiscription" Placeholder="" onKeyPress="return alphabetKey(event);" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtdiscription" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Discription</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Weight (in Kg) 
                                                              <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtWeight" onkeypress="return isNumberKey(event)" MaxLength="5" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Weight(in Kg)</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Size in (mm2) 
                                                             <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtSize" onkeypress="return isNumberKey(event)" MaxLength="4" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtsize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size in (mm2)</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Depth of Pit 
                                                                <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPitDepth" onkeypress="return isNumberKey(event)" MaxLength="4" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtpitdepth" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Depth of Pit</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Travel and No. of Floors 
                                                                     <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtTotalFloors" MaxLength="2" onkeypress="return isNumberKey(event)" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txttotalfloors" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Travel and No. of Floors</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <label for="Name" style="font-size: 12px;">
                                                                            Construction Details of OverHead Arrangement 
                                                                   <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtConstructionDetails" Placeholder="" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtconstructiondetails" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Construction Details</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>



                                                            </div>

                                                            <div class="row">
                                                                <div class="col-6" style="text-align: justify; padding-left: 0px;">
                                                                    <asp:Button type="button" AutoPostback="true" ID="Button1" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                                </div>
                                                                <div class="col-6" style="text-align: end; padding-right: 0px;">
                                                                    <asp:Button type="button" AutoPostback="true" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                                        OnClick="BtnSubmit_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                    </section>
                    <!-- End About Section -->
                </main>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ 1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>
                <%--<div class="credits">
                <!-- All the links in the footer should remain intact. -->
                <!-- You can delete the links only if you purchased the pro version. -->
                <!-- Licensing information: https://bootstrapmade.com/license/ -->
                <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/bizland-bootstrap-business-template/ -->
                Developed by
<a href="http://safedot.in/">Safedot E Solution Pvt. Ltd.</a>
            </div>--%>
            </div>
        </footer>
        <!-- End Footer -->
        <div id="preloader"></div>
        <a href="#" class="back-to-top d-flex align-items-center justify-content-center">
            <i class="bi bi-arrow-up-short"></i>
        </a>
        <!-- Vendor JS Files -->
        <script src="/assetsnew/vendor/purecounter/purecounter_vanilla.js"></script>
        <script src="/assetsnew/vendor/aos/aos.js"></script>
        <script src="/assetsnew/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="/assetsnew/vendor/glightbox/js/glightbox.min.js"></script>
        <script src="/assetsnew/vendor/isotope-layout/isotope.pkgd.min.js"></script>
        <script src="/assetsnew/vendor/swiper/swiper-bundle.min.js"></script>
        <script src="/assetsnew/vendor/waypoints/noframework.waypoints.js"></script>
        <script src="/assetsnew/vendor/php-email-form/validate.js"></script>
        <!-- Template Main JS File -->
        <script src="/assetsnew/js/main.js"></script>
        <script src="/vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page -->
        <script src="/vendors/typeahead.js/typeahead.bundle.min.js"></script>
        <script src="/vendors/select2/select2.min.js"></script>
        <!-- End plugin js for this page -->
        <!-- inject:js -->
        <script src="/js2/off-canvas.js"></script>
        <script src="/js2/hoverable-collapse.js"></script>
        <script src="/js2/template.js"></script>
        <script src="/js2/settings.js"></script>
        <script src="/js2/todolist.js"></script>

        <!-- endinject -->
        <!-- Custom js for this page-->
        <script src="/js2/file-upload.js"></script>
        <script src="/js2/typeahead.js"></script>
        <script src="/js2/select2.js"></script>
    </form>
    <%--<script>
        var checkBox = document.getElementById("<%= CheckBox1.ClientID %>");
        var commAddress = document.getElementById("<%= txtCommunicationAddress.ClientID %>");
        var permAddress = document.getElementById("<%= txtPermanentAddress.ClientID %>");

        checkBox.addEventListener("change", function () {
            if (checkBox.checked) {
                permAddress.value = commAddress.value;
                permAddress.readOnly = true;
            } else {
                permAddress.readOnly = false;
            }
        });
    </script> --%>

    <%-- Multiselect Dropdown --%>
    <script>
        $(document).ready(function () {

            var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
                removeItemButton: true,
                maxItemCount: 3,
                searchResultLimit: 3,
                renderChoiceLimit: 3
            });


        });
    </script>
    <%--    Multiselect Dropdown End    --%>



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
    <script>
        // Function to check if all fields (textboxes and dropdowns) except nationality have values
        function validateForm1() {
            var inputs = document.querySelectorAll('.form-control, .select-form');
            var isValid = true;

            inputs.forEach(function (input) {
                if (input !== document.getElementById('txtNationality')) {
                    if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                        isValid = false;
                        // input.style.border = '1px solid red';
                    } else {
                        input.style.border = '1px solid #ced4da';
                    }
                }
            });

            //if (!isValid) {
            //    alert('Please fill in all the required fields.');
            //}

            return isValid;
        }

        // Add event listeners to remove the red border as the user types/makes selections
        document.querySelectorAll('.form-control, .select-form').forEach(function (input) {
            input.addEventListener('input', function () {
                if (input !== document.getElementById('txtNationality')) {
                    input.style.border = '1px solid #ced4da';
                }
            });
        });
    </script>
    <%--<script>
       // Function to check if all fields (textboxes and dropdowns) have values
       function validateForm() {
           var inputs = document.querySelectorAll('.form-control, .select-form');
           var isValid = true;

           inputs.forEach(function (input) {
               if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                   isValid = false;
                   input.style.border = '1px solid red';
               } else {
                   input.style.border = '1px solid #ced4da'; // Reset border to default
               }
           });

           if (!isValid) {
               alert('Please fill in all the required fields.');
           }

           return isValid;
       }
   </script>--%>
    <%-- <script>
          function validateAadhaar() {
              var aadhaarNumber = document.getElementById('txtAadhaar').value;

              // Define the regular expression pattern for Aadhaar card number
              var aadhaarPattern = /^\d{12}$/;

              // Check if the entered Aadhaar number matches the pattern
              if (aadhaarPattern.test(aadhaarNumber)) {
                  alert('Aadhaar number is valid!');
              } else {
                  alert('Invalid Aadhaar number! Please enter a valid 12-digit Aadhaar number.');
              }
          }
      </script>--%>
    <script type="text/javascript">
        function isvalidphoneno() {
            // Get the phone number from the TextBox
            var phoneNumber = document.getElementById('<%=txtPhoneNo.ClientID%>').value;

        // Define a regular expression for a 10-digit numeric phone number
        var phoneRegex = /^\d{10}$/;

        // Test the phone number against the regular expression
        var isValid = phoneRegex.test(phoneNumber);

        // Update the RequiredFieldValidator based on the validation result
        var validator = document.getElementById('<%=RequiredFieldValidator14.ClientID%>');
            validator.style.display = isValid ? 'none' : 'inline';

            // Return the validation result
            return isValid;
        }
    </script>

</body>
</html>
