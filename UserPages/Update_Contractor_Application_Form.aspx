<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_Contractor_Application_Form.aspx.cs" Inherits="CEIHaryana.UserPages.Update_Contractor_Application_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.css" />
    <script src="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.8.1/js/bootstrap-select.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i"
        rel="stylesheet" />
    <!-- Vendor CSS Files -->
    <link rel="stylesheet" href="/MultiSelect_Css/modal.css" />
    <script src="/MultiSelect_Css/modal.js"></script>
    <link rel="stylesheet" href="/MultiSelect_Css/mobiscroll.javascript.min.css" />
    <script src="/MultiSelect_Css/mobiscroll.javascript.min.js"></script>
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
        #penaltyContainer {
            min-height: 100px;
            padding: 8px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            display: flex;
            flex-wrap: wrap;
        }

        .penalty-tag {
            background: white;
            border: 1px solid black;
            color: black;
            padding: 10px 10px;
            border-radius: 20px;
            margin: 4px;
            display: flex;
            align-items: center;
            font-size: 14px;
            height: 30px;
        }

            .penalty-tag span.remove-icon {
                cursor: pointer;
                margin-left: 10px;
                font-weight: bold;
                color: red;
                font-size: 18px;
                background: #cbcbcb;
                border-radius: 40px;
                height: 16px;
                padding-left: 4px;
                padding-right: 4px;
            }


        th.headercolor {
            background: #9292cc;
            color: white;
        }

        txtPenalities {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlPenalities {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtBirthDate {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        .modal-dialog {
            border-radius: 10px;
        }

        .modal-content {
            box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: -175px;
            margin-top: 8px !important;
        }

        li#logout {
            padding-left: 10px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding-right: 10px !important;
            padding-top: 10px !important;
            padding-bottom: 10px !important;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: -175px;
            margin-top: 18px;
        }

        select[data-multi-select-plugin] {
            display: none !important;
        }

        .multi-select-component {
            position: relative;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            height: auto;
            width: 100%;
            padding: 3px 8px;
            font-size: 14px;
            line-height: 1.42857143;
            padding-bottom: 0px;
            color: #555;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            -webkit-transition: border-color ease-in-out 0.15s, -webkit-box-shadow ease-in-out 0.15s;
            -o-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }

        .autocomplete-list {
            border-radius: 4px 0px 0px 4px;
        }

        .multi-select-component:focus-within {
            box-shadow: inset 0px 0px 0px 2px #78ABFE;
        }

        .multi-select-component .btn-group {
            display: none !important;
        }

        .multiselect-native-select .multiselect-container {
            width: 100%;
        }

        .selected-wrapper {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            display: inline-block;
            border: 1px solid #d9d9d9;
            background-color: #ededed;
            white-space: nowrap;
            margin: 1px 5px 5px 0;
            height: 22px;
            vertical-align: top;
            cursor: default;
        }

            .selected-wrapper .selected-label {
                max-width: 514px;
                display: inline-block;
                overflow: hidden;
                text-overflow: ellipsis;
                padding-left: 4px;
                vertical-align: top;
            }

            .selected-wrapper .selected-close {
                display: inline-block;
                text-decoration: none;
                font-size: 14px;
                line-height: 1.49em;
                margin-left: 5px;
                padding-bottom: 10px;
                height: 100%;
                vertical-align: top;
                padding-right: 4px;
                opacity: 0.2;
                color: #000;
                text-shadow: 0 1px 0 #fff;
                font-weight: 700;
            }

        .search-container {
            display: flex;
            flex-direction: row;
        }

            .search-container .selected-input {
                background: none;
                border: 0;
                height: 20px;
                width: 60px;
                padding: 0;
                margin-bottom: 6px;
                -webkit-box-shadow: none;
                box-shadow: none;
            }

                .search-container .selected-input:focus {
                    outline: none;
                }

        .dropdown-icon.active {
            transform: rotateX(180deg)
        }

        .search-container .dropdown-icon {
            display: inline-block;
            padding: 10px 5px;
            position: absolute;
            top: 5px;
            right: 5px;
            width: 10px;
            height: 10px;
            border: 0 !important;
            /* needed */
            -webkit-appearance: none;
            -moz-appearance: none;
            /* SVG background image */
            background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20width%3D%2212%22%20height%3D%2212%22%20viewBox%3D%220%200%2012%2012%22%3E%3Ctitle%3Edown-arrow%3C%2Ftitle%3E%3Cg%20fill%3D%22%23818181%22%3E%3Cpath%20d%3D%22M10.293%2C3.293%2C6%2C7.586%2C1.707%2C3.293A1%2C1%2C0%2C0%2C0%2C.293%2C4.707l5%2C5a1%2C1%2C0%2C0%2C0%2C1.414%2C0l5-5a1%2C1%2C0%2C1%2C0-1.414-1.414Z%22%20fill%3D%22%23818181%22%3E%3C%2Fpath%3E%3C%2Fg%3E%3C%2Fsvg%3E");
            background-position: center;
            background-size: 10px;
            background-repeat: no-repeat;
        }

        .search-container ul {
            position: absolute;
            list-style: none;
            padding: 0;
            z-index: 3;
            margin-top: 29px;
            width: 100%;
            right: 0px;
            background: #fff;
            border: 1px solid #ccc;
            border-top: none;
            border-bottom: none;
            -webkit-box-shadow: 0 6px 12px rgba(0, 0, 0, .175);
            box-shadow: 0 6px 12px rgba(0, 0, 0, .175);
        }

            .search-container ul :focus {
                outline: none;
            }

            .search-container ul li {
                display: block;
                text-align: left;
                padding: 8px 29px 2px 12px;
                border-bottom: 1px solid #ccc;
                font-size: 14px;
                min-height: 31px;
            }

                .search-container ul li:first-child {
                    border-top: 1px solid #ccc;
                    border-radius: 4px 0px 0 0;
                }

                .search-container ul li:last-child {
                    border-radius: 4px 0px 0 0;
                }


                .search-container ul li:hover.not-cursor {
                    cursor: default;
                }

                .search-container ul li:hover {
                    color: #333;
                    background-color: rgb(251, 242, 152);
                    border-color: #adadad;
                    cursor: pointer;
                }

        /* Adding scrool to select options */
        .autocomplete-list {
            max-height: 130px;
            overflow-y: auto;
        }

        select#ddlAuthority {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlDistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtContractorName {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtFatherName {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtIssueDate {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtAppliedFor {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlOffice {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlBusinessState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#DdlPartnerOrDirector {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlAnnexureOrNot {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlUnitOrNot {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlLicenseGranted {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlEmployer1 {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        select#ddlEmployer2 {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        .modal-dialog {
            max-width: 1150px !important;
            height: auto !important;
            box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
        }

        .modal-backdrop.show {
            height: 0% !important;
            width: 0% !important;
        }

        label.mbsc-ios.mbsc-ltr.mbsc-form-control-wrapper.mbsc-textfield-wrapper.mbsc-font.mbsc-textfield-wrapper-outline.mbsc-textfield-wrapper-stacked.mbsc-textarea-wrapper {
            margin-top: 0px;
            margin-left: 0px;
            font-size: 14px;
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

        select#ddlCompanyStyle {
            height: 31px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            font-size: 12px !important;
        }

            select#ddlCompanyStyle:hover {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                font-size: 12px !important;
            }

            select#ddlCompanyStyle:focus {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
                font-size: 12px !important;
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

        select#ddlSameNameLicense {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#ddlSameNameLicense:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#ddlSameNameLicense:focus {
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

        select#ddlCompanyStyle {
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
            margin-top: 10px;
            margin-bottom: 9px;
        }

        input#txtapplication {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
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
            font-size: 12px !important;
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
            font-size: 12px !important;
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
            font-size: 12px !important;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        td {
            padding: 15px !important;
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


        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        label {
            display: inline-block;
            margin-bottom: 0.5rem;
            font-size: 12px;
        }

        select#ddlforsearch {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 12px !important;
            border-radius: 4px;
        }

        input#txtBusinessAddress {
            width: 100%;
        }

        .card .card-title {
            font-size: 14px !important;
        }

        th.headercolor {
            width: 1% !important;
        }

        input#btnupdate1 {
            padding: 12px;
            border-radius: 5px;
        }

        input#btnupdate2 {
            padding: 12px;
            border-radius: 5px;
        }

        input#btnupdate3 {
            padding: 12px;
            border-radius: 5px;
        }

        input#btnupdate4 {
            padding: 12px;
            border-radius: 5px;
        }

        input#btnupdate5 {
            padding: 12px;
            border-radius: 5px;
        }

        textarea#txtPenalities {
            margin-top: 20px;
            height: 100px;
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
    <script>
        $(document).ready(function () {
            // Hide the modal on page load
            $("#myModal").modal("hide");
        });
    </script>
    <script type="text/javascript">
        function PartnerDirectorAlert() {
            if (confirm('Please Add You Partners Or Directors information')) {
                DdlPartnerOrDirector.style.border = '1px solid red';;
            } else {
            }
        }
    </script>

    <script type="text/javascript">
        function CheckVacantSupervisor() {
            if (confirm('Please Add Different Supervisor this is already exits.')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function ContractorTeamAlert() {
            if (confirm('Please Add Atleast One Wireman And Supervisor Information')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <section id="topbar" class="d-flex align-items-center">
            <div class="container d-flex justify-content-center justify-content-md-between">
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
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Lift & Esclator</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>

                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Licensing</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Inspection</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
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
                                    <a href="/UserPages/User_Profile_Create.aspx">
                                        <span>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-badge" viewBox="0 0 16 16">
                                      User      
<path d="M6.5 2a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                                    <path d="M4.5 0A2.5 2.5 0 0 0 2 2.5V14a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2.5A2.5 2.5 0 0 0 11.5 0zM3 2.5A1.5 1.5 0 0 1 4.5 1h7A1.5 1.5 0 0 1 13 2.5v10.795a4.2 4.2 0 0 0-.776-.492C11.392 12.387 10.063 12 8 12s-3.392.387-4.224.803a4.2 4.2 0 0 0-.776.492z" />
                                                </svg>&nbsp;&nbsp;Profile</span>

                                    </a>
                                </li>
                                <li id="ProfileLogout">
                                    <a href="#">
                                        <span>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-box-arrow-left" viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M6 12.5a.5.5 0 0 0 .5.5h8a.5.5 0 0 0 .5-.5v-9a.5.5 0 0 0-.5-.5h-8a.5.5 0 0 0-.5.5v2a.5.5 0 0 1-1 0v-2A1.5 1.5 0 0 1 6.5 2h8A1.5 1.5 0 0 1 16 3.5v9a1.5 1.5 0 0 1-1.5 1.5h-8A1.5 1.5 0 0 1 5 12.5v-2a.5.5 0 0 1 1 0z" />
                                                <path fill-rule="evenodd" d="M.146 8.354a.5.5 0 0 1 0-.708l3-3a.5.5 0 1 1 .708.708L1.707 7.5H10.5a.5.5 0 0 1 0 1H1.707l2.147 2.146a.5.5 0 0 1-.708.708z" />
                                            </svg>&nbsp;&nbsp;
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
        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up" style="max-width: 1350px !important;">
                    <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                            Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/CONTRACTOR_APPLICATION_CAPSULE.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12" style="text-align: center; font-size: 22px; font-weight: 800;">
                                            <asp:Label ID="Label17" runat="server" Text="APPLICATON FOR GRANT OF 'A' CLASS ELECTRICAL CONTRACTOR LICENCE"></asp:Label>
                                        </div>
                                    </div>
                                    <hr style="margin-bottom: 15PX;" />
                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="row" style="margin-top: -15px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 14px !important;">Registration Details</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: #d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 15px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-3" id="Div8" runat="server">
                                                                <label for="Name">
                                                                    Name Of Electrical contractor
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtContractorName" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-3" id="Div9" runat="server">
                                                                <label for="Name">
                                                                    Father's Name
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtFatherName" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-3" id="Div10" runat="server">
                                                                <label for="Name">
                                                                    Date of Birth
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtBirthDate" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-3" id="Div12" runat="server">
                                                                <label for="Name">
                                                                    Applied For
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtAppliedFor" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 20px; font-size: 20PX;">Organisation Details
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 15px;">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label>
                                                                                    Style of Company<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlCompanyStyle" runat="server" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyStyle_SelectedIndexChanged">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Proprietary Concern" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Company(Limited)" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Firm(Registered under the company's act.)" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Partnership Firm" Value="3"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ErrorMessage="Required" ControlToValidate="ddlCompanyStyle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit1" ForeColor="Red" />
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 23px;">
                                                                                <label>
                                                                                    State<samp style="color: red">* </samp>
                                                                                </label>

                                                                                <asp:DropDownList ID="ddlBusinessState" class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ControlToValidate="ddlBusinessState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit1" ForeColor="Red" />
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 23px;">
                                                                                <label>
                                                                                    Business Pin Code<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtBusinessPin" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event);" MaxLength="6"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label>
                                                                                    Business Phone No.<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtBusinessPhoneNo" autocomplete="off" runat="server" onkeyup="return isvalidphoneno();" onKeyPress="return isNumberKey(event);" MaxLength="10"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtBusinessPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Lbl1" runat="server" visible="true">
                                                                                    Name Of Proprietary Concern<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <label id="Lbl2" runat="server" visible="false">
                                                                                    Name Of Company(Limited)<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <label id="Lbl3" runat="server" visible="false">
                                                                                    Name Of Firm(Registered under the company's act.)<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <label id="Lbl4" runat="server" visible="false">
                                                                                    Name Of Partnership Firm<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtNameOfCompany" autocomplete="off" runat="server" MaxLength="100"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtNameOfCompany" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label>
                                                                                    District<samp style="color: red">* </samp>
                                                                                </label>

                                                                                <asp:TextBox class="form-control" ID="txtBusinessDistrict" autocomplete="off" runat="server" MaxLength="50"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtBusinessDistrict" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label id="contractor" runat="server" visible="true">
                                                                                    GST No.<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber" ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit" ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGstNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>

                                                                            <div class="form-group" id="DivAgentName" runat="server" visible="false">
                                                                                <label id="Label2" runat="server" visible="true">
                                                                                    Full Name of Agent/Manager<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgentName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <button type="button" runat="server" visible="false" style="padding: 10px 20px 10px 20px;" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal">
                                                                                    Open modal
                                                                                </button>
                                                                                <div class="modal" id="myModal">
                                                                                    <div class="modal-dialog">
                                                                                        <div class="modal-content">
                                                                                            <!-- Modal Header -->
                                                                                            <div class="modal-header">
                                                                                                <h3 class="modal-title">Director Details</h3>
                                                                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                                                            </div>
                                                                                            <!-- Modal body -->
                                                                                            <div class="modal-body">
                                                                                                <div style="margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label id="Label6" runat="server" visible="true">
                                                                                                                        Type of Authority<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                                                        ID="ddlAuthority" runat="server" TabIndex="5">
                                                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="Director" Value="1"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="Partner" Value="2"></asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlAuthority" InitialValue="0" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label id="Label8" runat="server" visible="true">
                                                                                                                        Full Name<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:TextBox class="form-control" ID="txtName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server" TabIndex="6"> </asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ErrorMessage="Required" ControlToValidate="txtName" runat="server" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label id="Label9" runat="server" visible="true">
                                                                                                                        Address<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" runat="server" TabIndex="7"> </asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" runat="server" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label>
                                                                                                                        State<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                                                        ID="ddlState" AutoPostBack="true" runat="server" TabIndex="8" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Text="Please Select State" ErrorMessage="Required" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label>
                                                                                                                        District<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                                                        ID="ddlDistrict" runat="server" TabIndex="9">
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ErrorMessage="Required" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <div class="forms-sample">
                                                                                                                <div class="form-group">
                                                                                                                    <label id="Label11" runat="server" visible="true">
                                                                                                                        Pin Code<samp style="color: red">* </samp>
                                                                                                                    </label>
                                                                                                                    <asp:TextBox class="form-control" ID="txtPinCode" autocomplete="off" onKeyPress="return isNumberKey(event);" runat="server" MaxLength="6" TabIndex="10"> </asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPinCode"
                                                                                                                        ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-12" style="text-align: end;">
                                                                                                            <asp:Button type="Submit" OnClientClick="return validateFormodal();" ID="btnModalSubmit" OnClick="btnModalSubmit_Click" Text="Add" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <hr style="margin-top: 45px; margin-bottom: 10px;" />
                                                                                                <div class="row" style="margin-top: 40px;">
                                                                                                    <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                                                                                                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                                                                                        <%--OnRowCommand="GridView1_RowCommand"--%>
                                                                                                        <PagerStyle CssClass="pagination-ys" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                                                                                <HeaderStyle HorizontalAlign="left" Width="12%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="left" Width="12%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="State" HeaderText="State">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="District" HeaderText="District">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Address" HeaderText="Address">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRecord"
                                                                                                                        Text="Delete" ForeColor="Red" CommandArgument='<%# Eval("Id") %>'>
                                                                                                                    </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                                                                        <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
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
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label>
                                                                                    Business Address<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtBusinessAddress" autocomplete="off" runat="server" MaxLength="250"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtBusinessAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label for="Gender">
                                                                                    Registered office in (Haryana/UT Chandigarh/ NCT Delhi)<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlOffice" runat="server" TabIndex="3">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOffice" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit1" ForeColor="Red" />
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 23px !important;">
                                                                                <label>
                                                                                    Business E-mail<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtBusinessEmail" autocomplete="off" runat="server" MaxLength="50" onkeyup="return ValidateEmail();"> </asp:TextBox>
                                                                                <span id="lblError" style="color: red"></span>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validation_required" runat="server" ControlToValidate="txtBusinessEmail"
                                                                                    ErrorMessage="Required" ValidationGroup="Submit1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 23px !important;">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 23px !important; text-align: end;">
                                                                                <asp:Button ID="btnupdate1" OnClick="btnupdate1_Click" runat="server" ValidationGroup="Submit1" Text="Update" Class="btn btn-primary" />
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">Other Organisation Details
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 15px;">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <label id="Label4" runat="server" visible="true">
                                                                            Is Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlUnitOrNot" runat="server">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUnitOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit2" ForeColor="Red" />
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <label id="Label13" runat="server" visible="true">
                                                                            Is Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlSameNameLicense" runat="server" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlSameNameLicense" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit2" ForeColor="Red" />

                                                                    </div>
                                                                    <div class="col-md-4" id="DivLicenseNo" runat="server" visible="true">
                                                                        <label id="Label14" runat="server" visible="true">
                                                                            Enter License No.<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" MaxLength="10" onKeyPress="return isNumberKey(event) || alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtLicenseNo"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-4" id="DivLicenseIssueDateifSameName" runat="server" visible="false">
                                                                        <label id="Labe20" runat="server" visible="true">
                                                                            Date of Issue<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseIssue" Onchange="validateDate()" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtLicenseIssue"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <label id="Label5" runat="server" visible="true">
                                                                            Is Contractor License Previously Granted with same name from other state<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlLicenseGranted" runat="server" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit2" ForeColor="Red" />
                                                                    </div>
                                                                    <div class="col-md-4" id="divIssueAuthority" runat="server" visible="true">
                                                                        <label id="Label7" runat="server" visible="true">
                                                                            Name of Issuing Authority<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssusuingName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-4" id="divLicenseIssueDate" runat="server" visible="true">
                                                                        <label>
                                                                            Date of Issue<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtIssuedateOtherState" Onchange="validateDate1()" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtIssuedateOtherState"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-4" id="divLicenseExpiry" runat="server" visible="true">
                                                                        <label id="Label15" runat="server" visible="true">
                                                                            Date of License Expiry<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseExpiry" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true" onchange="validateDates1()"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLicenseExpiry"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-4" id="divDetailsOfWorkPermit" runat="server" visible="true">
                                                                        <label id="Label21" runat="server" visible="true">
                                                                            Details of work permit to be undertaken.<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtWorkPermitUndertaken" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtWorkPermitUndertaken"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-12" style="text-align: end;">
                                                                        <asp:Button ID="btnupdate2" OnClick="btnupdate2_Click" ValidationGroup="Submit2" runat="server" Text="Update" class="btn btn-primary" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">Partner/Directors Details
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                             <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 15px;">
     <div class="row">
         <div class="col-md-4">
             <div class="form-group">
                 <label for="Gender">
                     Whether the company have Partner/Director<samp style="color: red">* </samp>
                 </label>
                 <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true"
                     ID="DdlPartnerOrDirector" runat="server" OnSelectedIndexChanged="DdlPartnerOrDirector_SelectedIndexChanged" TabIndex="4" Enabled="true">
                     <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="YES" Value="1" data-bs-toggle="modal" data-bs-target="#myModal"></asp:ListItem>
                     <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlPartnerOrDirector" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
             </div>
         </div>
         <div class="col-md-4">
             <div class="form-group">
                 <div id="ADDpartner" runat="server" visible="false" class="form-group" style="margin-top: 8px;">
                     <asp:Button ID="btnShowPartnerDiv" runat="server" Text="Add Partner" OnClick="btnShowPartnerDiv_Click" CssClass="btn btn-primary" Style="border-radius: 5px; font-size: 18px; padding: 4px 8px; margin-top: 16px;" />
                 </div>
             </div>
         </div>
     </div>
     <hr />
     <div class="row">
         <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="100%"
             AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
             <PagerStyle CssClass="pagination-ys" />
             <Columns>
                 <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                     <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Name" HeaderText="Name">
                     <HeaderStyle HorizontalAlign="left" Width="12%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="left" Width="12%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:BoundField DataField="State" HeaderText="State">
                     <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:BoundField DataField="District" HeaderText="District">
                     <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                     <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Address" HeaderText="Address">
                     <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="Delete">
                     <ItemTemplate>
                         <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRecord"
                             Text="Delete" ForeColor="Red" CommandArgument='<%# Eval("Id") %>'>
                         </asp:LinkButton>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                     <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="White" ForeColor="#000066" />
             <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
             <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
             <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
             <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#007DBB" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#00547E" />
         </asp:GridView>
     </div>
 </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="row" style="margin-top: 15px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                    <div class="col-md-12">
                                                        <h3 class="card-title" style="margin-top: 15px; font-size: 21px; padding-left: 25px !important;">Employees Details (From Here You Can Add Supervisor and Wireman)
                                                        </h3>
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                         <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding: 17px; padding-bottom: 17px; margin: -20px 0px 0px 0px;">
      <div class="row">
          <div class="col-md-3">
              <asp:Label ID="typeemp" runat="server" Style="font-size: 12px;">Type of Employee<samp style="color: red">* </samp></asp:Label>
              <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true"
                  ID="ddlEmployer1" runat="server">
                  <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Supervisor" Value="Supervisor"></asp:ListItem>
                  <asp:ListItem Text="Wireman" Value="Wireman"></asp:ListItem>
              </asp:DropDownList>
          </div>
          <div class="col-md-3">
              <asp:Label ID="toserch" Text="Search According To " runat="server" Style="font-size: 12px;"></asp:Label>
              <br />
              <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true" ID="ddlforsearch" runat="server">
                  <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Name" Value="Name"></asp:ListItem>
                  <asp:ListItem Text="Licence No" Value="Licence No"></asp:ListItem>
                  <asp:ListItem Text="Phone No" Value="Phone No"></asp:ListItem>
              </asp:DropDownList>
          </div>
          <div class="col-md-4">
              <asp:Label runat="server" Text="Enter text" Style="font-size: 12px;"></asp:Label>
              <asp:TextBox ID="txtSearchValue" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="col-md-2" style="margin-top: 15px;">
              <asp:Button class="btn btn-primary" runat="server" ID="searchbtn" Text="Search" OnClick="searchbtn_Click" Style="padding: 10px 20px 10px 20px; border-radius: 5px; margin-bottom: 5%;" />
          </div>
      </div>
      <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
      <!-- Bootstrap Modal -->
      <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
              <div class="modal-content">
                  <div class="modal-header">
                      <h5 class="modal-title" id="myModalLabel">Details</h5>
                      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                      <!-- Content will go here -->
                      <div class="row" style="margin-bottom: 15px;">
                          <div class="col-md-4 d-flex align-items-center">
                              <label for="inputBox" class="me-2" style="margin-top: 7px;">Search:</label>
                              <asp:TextBox ID="txtSearch" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                      </div>

                      <div class="row" style="margin-top: 5px;">
                          <div class="col-md-12">
                              <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView4" runat="server"
                                  AutoGenerateColumns="false" BorderWidth="1px" DataKeyNames="LicenceNo" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                                  <PagerStyle CssClass="pagination-ys" />
                                  <Columns>
                                      <asp:TemplateField HeaderText="SNo">
                                          <HeaderStyle CssClass="headercolor" />
                                          <ItemStyle />
                                          <ItemTemplate>
                                              <%#Container.DataItemIndex+1 %>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Name">
                                          <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                          <ItemTemplate>
                                              <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Phone No">
                                          <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                          <ItemTemplate>
                                              <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo") %>' />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="License No">
                                          <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                          <ItemTemplate>
                                              <asp:Label ID="lblLicenseNo" runat="server" Text='<%# Eval("LicenceNo") %>' />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Issue Date">
                                          <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                          <ItemTemplate>
                                              <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate", "{0:dd-MM-yyyy}") %>' />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Validity Date">
                                          <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                          <ItemTemplate>
                                              <asp:Label ID="lblValidityDate" runat="server" Text='<%# Eval("ValidityDate", "{0:dd-MM-yyyy}") %>' />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Select">
                                          <ItemTemplate>
                                              <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Text="Select" ForeColor="Blue" />
                                          </ItemTemplate>
                                          <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                          <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                      </asp:TemplateField>
                                  </Columns>
                              </asp:GridView>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
      <div class="row">
          <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView3" runat="server" Width="100%"
              AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id" OnRowCommand="GridView3_RowCommand">
              <PagerStyle CssClass="pagination-ys" />
              <Columns>
                  <asp:BoundField DataField="Name" HeaderText="Name">
                      <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="tdpadding" />
                  </asp:BoundField>
                  <asp:BoundField DataField="TypeOfEmployee" HeaderText="Type Of Employee">
                      <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="tdpadding" />
                  </asp:BoundField>
                  <asp:BoundField DataField="LicenseNo" HeaderText="License No">
                      <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="tdpadding" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="Issue Date">
                      <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="tdpadding" />
                      <ItemTemplate>
                          <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate", "{0:dd-MM-yyyy}") %>' />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Validity Date">
                      <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="tdpadding" />
                      <ItemTemplate>
                          <asp:Label ID="lblValidityDate" runat="server" Text='<%# Eval("ValidityDate", "{0:dd-MM-yyyy}") %>' />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Delete">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteTeam" CommandArgument='<%# Eval("Id") %>'
                              Text="Delete" ForeColor="Red">
                          </asp:LinkButton>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                      <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </div>
  </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                    <div class="col-md-12">
                                                        <h3 class="card-title" style="margin-top: 35px; font-size: 21px; padding-left: 25px !important;">Other Details
                                                        </h3>
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px 0px 0px 0px !important; padding: 17px; padding-bottom: 20px;">
                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <div class="forms-sample">
                                                                        <div class="form-group">
                                                                            <label for="Gender">
                                                                                Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                ID="ddlAnnexureOrNot" runat="server">
                                                                                <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnnexureOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit3" ForeColor="Red" />

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="forms-sample">
                                                                        <div class="form-group">
                                                                            <label id="Label12" runat="server" visible="true">
                                                                                Do company/firm have any <b>Penalties or Punishments</b>?<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownList2" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit3" ForeColor="Red" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4" id="DdlPenelity" runat="server" visible="true">
                                                                    <div class="forms-sample">
                                                                        <div class="form-group">
                                                                            <label id="Label10" runat="server" visible="true">
                                                                                Select penalties or punishments<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:DropDownList ID="ddlPenalities" runat="server"
                                                                                CssClass="select-form select2 form-control"
                                                                                AutoPostBack="false"
                                                                                onchange="updatePenalityText(this)">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="By state licensing board, Haryana/chief Electrical inspector,Haryana" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="By government & other agencies" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="Any court of law." Value="3"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPenalities"
                                                                                runat="server" Display="Dynamic" ValidationGroup="Submit3" ForeColor="Red" />
                                                                       
                                                                        </div>

                                                                        <div class="form-group">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" id="ShowPenelity" runat="server" visible="false">
                                                                        <label id="Label1" runat="server" visible="true"></label>
                                                                        <div id="penaltyContainer" class="form-control">
                                                                            <!-- Tags will be added here -->
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6"  id="DivPenelity" runat="server" visible="true">
                                                                    <asp:TextBox ID="txtPenalities" runat="server" TextMode="MultiLine"
                                                                        Rows="2" CssClass="form-control" />
                                                               <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                                                        runat="server" ControlToValidate="txtPenalities"
                                                                        CssClass="validation_required" ErrorMessage="Required"
                                                                        ValidationGroup="Submit3" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                                <div class="col-md-12" style="text-align: end; margin-top: 15px;">
                                                                    <asp:Button ID="btnupdate3" OnClick="btnupdate3_Click" ValidationGroup="Submit3" runat="server" Text="Update" class="btn btn-primary" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>

                                                </asp:UpdatePanel>
                                                <div class="row" style="margin-bottom: -75px; margin-top: 50px;">
                                                    <div class="col-md-6" style="padding-left: 0px;">
                                                    </div>
                                                    <div class="col-md-6" style="padding-right: 35px; text-align: end;">
                                                        <asp:Button type="BtnSubmit" ID="BtnSubmit" Text="Next" OnClick="BtnSubmit_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px; margin-bottom: 5%;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="HFContractor" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </section>
            <!-- End About Section -->
        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>
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
    <script>
        mobiscroll.setOptions({
            locale: mobiscroll.localeEn,                                         // Specify language like: locale: mobiscroll.localePl or omit setting to use default
            theme: 'ios',                                                        // Specify theme like: theme: 'ios' or omit setting to use default
            themeVariant: 'light'                                                // More info about themeVariant: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-themeVariant
        });
        mobiscroll.select('#demo-multiple-select', {
            inputElement: document.getElementById('demo-multiple-select-input')  // More info about inputElement: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-inputElement
        });
    </script>
    <script>
        // Initialize function, create initial tokens with itens that are already selected by the user
        function init(element) {
            // Create div that wroaps all the elements inside (select, elements selected, search div) to put select inside
            const wrapper = document.createElement("div");
            wrapper.addEventListener("click", clickOnWrapper);
            wrapper.classList.add("multi-select-component");

            // Create elements of search
            const search_div = document.createElement("div");
            search_div.classList.add("search-container");
            const input = document.createElement("input");
            input.classList.add("selected-input");
            input.setAttribute("autocomplete", "off");
            input.setAttribute("tabindex", "0");
            input.addEventListener("keyup", inputChange);
            input.addEventListener("keydown", deletePressed);
            input.addEventListener("click", openOptions);

            const dropdown_icon = document.createElement("a");
            dropdown_icon.setAttribute("href", "#");
            dropdown_icon.classList.add("dropdown-icon");

            dropdown_icon.addEventListener("click", clickDropdown);
            const autocomplete_list = document.createElement("ul");
            autocomplete_list.classList.add("autocomplete-list")
            search_div.appendChild(input);
            search_div.appendChild(autocomplete_list);
            search_div.appendChild(dropdown_icon);

            // set the wrapper as child (instead of the element)
            element.parentNode.replaceChild(wrapper, element);
            // set element as child of wrapper
            wrapper.appendChild(element);
            wrapper.appendChild(search_div);

            createInitialTokens(element);
            addPlaceholder(wrapper);
        }

        function removePlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            input_search.removeAttribute("placeholder");
        }

        function addPlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            const tokens = wrapper.querySelectorAll(".selected-wrapper");
            if (!tokens.length && !(document.activeElement === input_search))
                input_search.setAttribute("placeholder", "---------");
        }

        // Function that create the initial set of tokens with the options selected by the users
        function createInitialTokens(select) {
            let {
                options_selected
            } = getOptions(select);
            const wrapper = select.parentNode;
            for (let i = 0; i < options_selected.length; i++) {
                createToken(wrapper, options_selected[i]);
            }
        }

        // Listener of user search
        function inputChange(e) {
            const wrapper = e.target.parentNode.parentNode;
            const select = wrapper.querySelector("select");
            const dropdown = wrapper.querySelector(".dropdown-icon");

            const input_val = e.target.value;

            if (input_val) {
                dropdown.classList.add("active");
                populateAutocompleteList(select, input_val.trim());
            } else {
                dropdown.classList.remove("active");
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
        }

        // Listen for clicks on the wrapper, if click happens focus on the input
        function clickOnWrapper(e) {
            const wrapper = e.target;
            if (wrapper.tagName == "DIV") {
                const input_search = wrapper.querySelector(".selected-input");
                const dropdown = wrapper.querySelector(".dropdown-icon");
                if (!dropdown.classList.contains("active")) {
                    const event = new Event('click');
                    dropdown.dispatchEvent(event);
                }
                input_search.focus();
                removePlaceholder(wrapper);
            }
        }

        function openOptions(e) {
            const input_search = e.target;
            const wrapper = input_search.parentElement.parentElement;
            const dropdown = wrapper.querySelector(".dropdown-icon");
            if (!dropdown.classList.contains("active")) {
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
            e.stopPropagation();

        }

        // Function that create a token inside of a wrapper with the given value
        function createToken(wrapper, value) {
            const search = wrapper.querySelector(".search-container");
            // Create token wrapper
            const token = document.createElement("div");
            token.classList.add("selected-wrapper");
            const token_span = document.createElement("span");
            token_span.classList.add("selected-label");
            token_span.innerText = value;
            const close = document.createElement("a");
            close.classList.add("selected-close");
            close.setAttribute("tabindex", "-1");
            close.setAttribute("data-option", value);
            close.setAttribute("data-hits", 0);
            close.setAttribute("href", "#");
            close.innerText = "x";
            close.addEventListener("click", removeToken)
            token.appendChild(token_span);
            token.appendChild(close);
            wrapper.insertBefore(token, search);
        }

        // Listen for clicks in the dropdown option
        function clickDropdown(e) {

            const dropdown = e.target;
            const wrapper = dropdown.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const select = wrapper.querySelector("select");
            dropdown.classList.toggle("active");

            if (dropdown.classList.contains("active")) {
                removePlaceholder(wrapper);
                input_search.focus();

                if (!input_search.value) {
                    populateAutocompleteList(select, "", true);
                } else {
                    populateAutocompleteList(select, input_search.value);
                }
            } else {
                clearAutocompleteList(select);
                addPlaceholder(wrapper);
            }
        }

        // Clears the results of the autocomplete list
        function clearAutocompleteList(select) {
            const wrapper = select.parentNode;

            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
        }

        // Populate the autocomplete list following a given query from the user
        function populateAutocompleteList(select, query, dropdown = false) {
            const {
                autocomplete_options
            } = getOptions(select);

            let options_to_show;

            if (dropdown)
                options_to_show = autocomplete_options;
            else
                options_to_show = autocomplete(query, autocomplete_options);

            const wrapper = select.parentNode;
            const input_search = wrapper.querySelector(".search-container");
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
            const result_size = options_to_show.length;

            if (result_size == 1) {
                const li = document.createElement("li");
                li.innerText = options_to_show[0];
                li.setAttribute('data-value', options_to_show[0]);
                li.addEventListener("click", selectOption);
                autocomplete_list.appendChild(li);
                if (query.length == options_to_show[0].length) {
                    const event = new Event('click');
                    li.dispatchEvent(event);

                }
            } else if (result_size > 1) {

                for (let i = 0; i < result_size; i++) {
                    const li = document.createElement("li");
                    li.innerText = options_to_show[i];
                    li.setAttribute('data-value', options_to_show[i]);
                    li.addEventListener("click", selectOption);
                    autocomplete_list.appendChild(li);
                }
            } else {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
        }

        // Listener to autocomplete results when clicked set the selected property in the select option 
        function selectOption(e) {
            const wrapper = e.target.parentNode.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const option = wrapper.querySelector(`select option[value="${e.target.dataset.value}"]`);

            option.setAttribute("selected", "");
            createToken(wrapper, e.target.dataset.value);
            if (input_search.value) {
                input_search.value = "";
            }

            input_search.focus();

            e.target.remove();
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");

            if (!autocomplete_list.children.length) {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
            const event = new Event('keyup');
            input_search.dispatchEvent(event);
            e.stopPropagation();
        }

        // function that returns a list with the autcomplete list of matches
        function autocomplete(query, options) {
            // No query passed, just return entire list
            if (!query) {
                return options;
            }
            let options_return = [];

            for (let i = 0; i < options.length; i++) {
                if (query.toLowerCase() === options[i].slice(0, query.length).toLowerCase()) {
                    options_return.push(options[i]);
                }
            }
            return options_return;
        }

        // Returns the options that are selected by the user and the ones that are not
        function getOptions(select) {
            // Select all the options available
            const all_options = Array.from(
                select.querySelectorAll("option")
            ).map(el => el.value);

            // Get the options that are selected from the user
            const options_selected = Array.from(
                select.querySelectorAll("option:checked")
            ).map(el => el.value);

            // Create an autocomplete options array with the options that are not selected by the user
            const autocomplete_options = [];
            all_options.forEach(option => {
                if (!options_selected.includes(option)) {
                    autocomplete_options.push(option);
                }
            });

            autocomplete_options.sort();

            return {
                options_selected,
                autocomplete_options
            };

        }

        // Listener for when the user wants to remove a given token.
        function removeToken(e) {
            // Get the value to remove
            const value_to_remove = e.target.dataset.option;
            const wrapper = e.target.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const dropdown = wrapper.querySelector(".dropdown-icon");
            // Get the options in the select to be unselected
            const option_to_unselect = wrapper.querySelector(`select option[value="${value_to_remove}"]`);
            option_to_unselect.removeAttribute("selected");
            // Remove token attribute
            e.target.parentNode.remove();
            input_search.focus();
            dropdown.classList.remove("active");
            const event = new Event('click');
            dropdown.dispatchEvent(event);
            e.stopPropagation();
        }

        // Listen for 2 sequence of hits on the delete key, if this happens delete the last token if exist
        function deletePressed(e) {
            const wrapper = e.target.parentNode.parentNode;
            const input_search = e.target;
            const key = e.keyCode || e.charCode;
            const tokens = wrapper.querySelectorAll(".selected-wrapper");

            if (tokens.length) {
                const last_token_x = tokens[tokens.length - 1].querySelector("a");
                let hits = +last_token_x.dataset.hits;

                if (key == 8 || key == 46) {
                    if (!input_search.value) {

                        if (hits > 1) {
                            // Trigger delete event
                            const event = new Event('click');
                            last_token_x.dispatchEvent(event);
                        } else {
                            last_token_x.dataset.hits = 2;
                        }
                    }
                } else {
                    last_token_x.dataset.hits = 0;
                }
            }
            return true;
        }

        // You can call this function if you want to add new options to the select plugin
        // Target needs to be a unique identifier from the select you want to append new option for example #multi-select-plugin
        // Example of usage addOption("#multi-select-plugin", "tesla", "Tesla")
        function addOption(target, val, text) {
            const select = document.querySelector(target);
            let opt = document.createElement('option');
            opt.value = val;
            opt.innerHTML = text;
            select.appendChild(opt);
        }

        document.addEventListener("DOMContentLoaded", () => {

            // get select that has the options available
            const select = document.querySelectorAll("[data-multi-select-plugin]");
            select.forEach(select => {

                init(select);
            });

            // Dismiss on outside click
            document.addEventListener('click', () => {
                // get select that has the options available
                const select = document.querySelectorAll("[data-multi-select-plugin]");
                for (let i = 0; i < select.length; i++) {
                    if (event) {
                        var isClickInside = select[i].parentElement.parentElement.contains(event.target);

                        if (!isClickInside) {
                            const wrapper = select[i].parentElement.parentElement;
                            const dropdown = wrapper.querySelector(".dropdown-icon");
                            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
                            //the click was outside the specifiedElement, do something
                            dropdown.classList.remove("active");
                            autocomplete_list.innerHTML = "";
                            addPlaceholder(wrapper);
                        }
                    }
                }
            });
        });
    </script>
    <script type="text/javascript">
        function validateAddTeam() {
            var isValid = true;

            function validatetxtField(element) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }
            validatetxtField(document.getElementById('txtLicense1'));
            validatetxtField(document.getElementById('txtValidity1'));
            validatetxtField(document.getElementById('txtQualification1'));
            validatetxtField(document.getElementById('txtIssueDate1'));

            if (document.getElementById('ddlEmployer1').value === '0') {
                isValid = false;
                document.getElementById('ddlEmployer1').style.border = '1px solid red';
            }
            else {
                document.getElementById('ddlEmployer1').style.border = '';
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            //document.getElementById('hdnIsClientSideValid').value = isValid;
            return isValid;
        }
    </script>
    <script type="text/javascript">
        function validateFormodal() {
            var isValid = true;

            function validateField(element) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validateDropdown(element) {
                if (element.value === '0' || element.selectedIndex === 0) {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validatePinCode(element) {
                var pin = element.value.trim();
                var pinRegex = /^\d{6}$/;
                if (!pinRegex.test(pin)) {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            var authority = document.getElementById('<%= ddlAuthority.ClientID %>');
            var name = document.getElementById('<%= txtName.ClientID %>');
            var address = document.getElementById('<%= txtAddress.ClientID %>');
            var state = document.getElementById('<%= ddlState.ClientID %>');
            var district = document.getElementById('<%= ddlDistrict.ClientID %>');
            var pinCode = document.getElementById('<%= txtPinCode.ClientID %>');

            validateDropdown(authority);
            validateField(name);
            validateField(address);
            validateDropdown(state);
            validateDropdown(district);
            validatePinCode(pinCode);

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }

            return isValid;
        }
    </script>
  <%--  <script type="text/javascript">
        function validateForm() {
            var isValid = true;

            function validateField(element, fieldName) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validateDropdown(element) {
                if (element.value === '0') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }


            validateField(document.getElementById('txtBusinessAddress'), 'BusinessAddress');
            validateField(document.getElementById('txtBusinessPin'), 'BusinessPin');
            validateField(document.getElementById('txtBusinessEmail'), 'BusinessEmail');
            validateField(document.getElementById('txtBusinessPhoneNo'), 'BusinessPhoneNo');
            validateField(document.getElementById('txtNameOfCompany'), 'NameOfCompany');
            validateField(document.getElementById('txtGstNumber'), 'GstNumber');
            validateDropdown(document.getElementById('ddlCompanyStyle'));
            validateDropdown(document.getElementById('ddlOffice'));
            validateDropdown(document.getElementById('DdlPartnerOrDirector'));
            validateDropdown(document.getElementById('ddlAnnexureOrNot'));

            // Applicant details
            validateField(document.getElementById('txtAgentName'), 'AgentName');
            validateDropdown(document.getElementById('ddlUnitOrNot'));
            validateDropdown(document.getElementById('ddlLicenseGranted'));
            validateDropdown(document.getElementById('ddlSameNameLicense'));

            var ddlLicenseGranted = document.getElementById('ddlLicenseGranted');
            if (ddlLicenseGranted && ddlLicenseGranted.value === '1') {
                validateField(document.getElementById('txtIssusuingName'), 'Issusuing Name');
                validateField(document.getElementById('txtIssuedateOtherState'), 'DOB');
                validateField(document.getElementById('txtLicenseExpiry'), 'License Expiry');
                validateField(document.getElementById('txtWorkPermitUndertaken'), 'Work Permit Undertaken');

            }

            var ddlSameNameLicense = document.getElementById('ddlSameNameLicense');
            if (ddlSameNameLicense && ddlSameNameLicense.value === '1') {
                validateField(document.getElementById('txtLicenseNo'), 'txtLicenseNo');
                validateField(document.getElementById('txtLicenseIssue'), 'LicenseIssue');
            }


            validateDropdown(document.getElementById('DropDownList2'));

            var DropDownList2 = document.getElementById('DropDownList2');
            if (DropDownList2 && DropDownList2.value === '1') {
                validateField(document.getElementById('txtPenalities'), 'Penalities');
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            return isValid;
        }
    </script>--%>
    <script type="text/javascript">
        function validateDates1() {
            var issuingDate = document.getElementById('<%=txtIssuedateOtherState.ClientID %>').value;
            var validityDate = document.getElementById('<%=txtLicenseExpiry.ClientID %>').value;

            if (new Date(issuingDate) > new Date(validityDate)) {
                alert('Validity Date should be greater than Issuing Date');
                document.getElementById('<%=txtLicenseExpiry.ClientID %>').value = ''; // Clear the expiry date
            }
        }
    </script>
    <script type="text/javascript">
        function validateDate() {
            var ClnDate = document.getElementById('<%=txtLicenseIssue.ClientID %>');

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (ClnDate.value) {
                var ChallanDate = new Date(ClnDate.value);
                if (ChallanDate > today) {
                    alert('Issue Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function validateDate1() {
            var ClnDate = document.getElementById('<%=txtIssuedateOtherState.ClientID %>');

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (ClnDate.value) {
                var ChallanDate = new Date(ClnDate.value);
                if (ChallanDate > today) {
                    alert('Issue Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtBusinessEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
            if (email == "") {
                //lblError.innerHTML = "Please Enter Email" + "\n";
                return false;
            }
            else if (expr.test(email)) {
                lblError.innerHTML = "";
                return true;
            }
            else {
                lblError.innerHTML = "Invalid email address.ex:abc@xyz.com" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtBusinessPhoneNo.ClientID %>");
            phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("lblErrorContect");
            lblErrorContect.innerHTML = "";
            var expr = /^[6-9]\d{9}$/;
            if (phoneNo == "") {
                lblErrorContect.innerHTML = "Please Enter Contact Number" + "\n";
                return false;
            }
            else if (expr.test(phoneNo)) {
                lblErrorContect.innerHTML = "";
                return true;
            }
            else {
                lblErrorContect.innerHTML = "Invalid Contact Number" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView4.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
    <script type="text/javascript">
        function updatePenalityText(dropdown) {
            var selectedOption = dropdown.options[dropdown.selectedIndex];
            var value = selectedOption.value;
            var text = selectedOption.text;

            if (value === "0") return;

            // Remove selected option from dropdown
            dropdown.remove(dropdown.selectedIndex);

            // Create tag element
            var container = document.getElementById("penaltyContainer");

            var tag = document.createElement("div");
            tag.className = "penalty-tag";
            tag.setAttribute("data-value", value);
            tag.setAttribute("data-text", text);
            tag.innerHTML = '' + text + ' <span class="remove-icon" onclick="removePenaltyTag(this, \'' + value + '\', \'' + text + '\')">&times;</span>';

            container.appendChild(tag);

            renumberPenaltyTags();
            updateHiddenTextbox();
        }

        function removePenaltyTag(span, value, text) {
            var tag = span.parentElement;
            tag.parentNode.removeChild(tag);

            // Re-add option to dropdown
            var ddl = document.getElementById("<%= ddlPenalities.ClientID %>");
            var newOption = document.createElement("option");
            newOption.value = value;
            newOption.text = text;
            ddl.add(newOption);

            ddl.selectedIndex = 0;

            renumberPenaltyTags();
            updateHiddenTextbox();
        }

        function renumberPenaltyTags() {
            var container = document.getElementById("penaltyContainer");
            var tags = container.children;

            for (var i = 0; i < tags.length; i++) {
                var tag = tags[i];
                var value = tag.getAttribute("data-value");
                var text = tag.getAttribute("data-text");

                tag.innerHTML = (i + 1) + '. ' + text + ' <span class="remove-icon" onclick="removePenaltyTag(this, \'' + value + '\', \'' + text + '\')">&times;</span>';
            }
        }

        function updateHiddenTextbox() {
            var tags = document.getElementById("penaltyContainer").children;
            var values = [];

            for (var i = 0; i < tags.length; i++) {
                var tag = tags[i];
                var text = tag.getAttribute("data-text");
                values.push((i + 1) + '. ' + text);
            }

            document.getElementById("<%= txtPenalities.ClientID %>").value = values.join(", ");
        }
    </script>
</body>
</html>
