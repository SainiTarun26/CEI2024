<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractorApplicationForm.aspx.cs" Inherits="CEIHaryana.UserPages.ContractorApplicationForm" %>

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
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlPenalities {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        input#txtBirthDate {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
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
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlDistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        input#txtContractorName {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        input#txtFatherName {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        input#txtIssueDate {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        input#txtAppliedFor {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlOffice {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#DdlPartnerOrDirector {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlAnnexureOrNot {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlUnitOrNot {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlLicenseGranted {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlEmployer1 {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlEmployer2 {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
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
        }

            select#ddlCompanyStyle:hover {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlCompanyStyle:focus {
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
                <div class="container" data-aos="fade-up">
                    <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                            Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/CONTRACTOR_APPLICATION_CAPSULE.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />

                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
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
                                                                    <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">REGISTRATION DETAILS</h7>
                                                                </div>
                                                            </div>
                                                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: #d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 15px; margin-left: -20px; margin-right: -20px;">
                                                                <div class="row">
                                                                    <div class="col-3" id="Div8" runat="server">
                                                                        <label for="Name">
                                                                            Name
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtContractorName" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-3" id="Div9" runat="server">
                                                                        <label for="Name">
                                                                            Father's Name
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtFatherName" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-3" id="Div10" runat="server">
                                                                        <label for="Name">
                                                                            Date of Birth
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtBirthDate" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>

                                                                    </div>
                                                                    <div class="col-3" id="Div12" runat="server">
                                                                        <label for="Name">
                                                                            Applied For
                                                                    <samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAppliedFor" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                                <div class="col-md-12">
                                                                    <h3 class="card-title" style="margin-top: 20px; font-size: 20PX;">ORGANIZATION DETAILS
                                                                    </h3>
                                                                </div>
                                                            </div>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 15px;">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="contractor" runat="server" visible="true">
                                                                                    GST No.<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber" ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit" ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                                <%-- <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber" ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit" ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGstNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label for="Gender">
                                                                                    Whether the company have Partner/Director<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true"
                                                                                    ID="DdlPartnerOrDirector" runat="server" OnSelectedIndexChanged="DdlPartnerOrDirector_SelectedIndexChanged" TabIndex="4">
                                                                                    <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1" data-bs-toggle="modal" data-bs-target="#myModal"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlPartnerOrDirector" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                            </div>
                                                                            <%--   <div class="form-group" id="CalculatedDatey" runat="server" visible="false">
                                                                                <label for="Age">Age</label>
                                                                                <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtyears" Width="210px" runat="server"> </asp:TextBox>
                                                                            </div>--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label>
                                                                                    Style of Company<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlCompanyStyle" runat="server" TabIndex="2">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Proprietary Concern" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Company(Limited)" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Firm(Registered under the company's act.)" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Partnership Firm (As per selection, below field will display)" Value="3"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCompanyStyle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />--%>
                                                                            </div>
                                                                            <div class="form-group" style="margin-top: 20px;">
                                                                                <label for="Gender">
                                                                                    Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlAnnexureOrNot" runat="server">
                                                                                    <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnnexureOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />  --%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAnnexureOrNot" ValidationGroup="Submit"
                                                                                    InitialValue="" ErrorMessage="Please select an option" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                                                                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
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
                                                                                                                        <asp:ListItem Text="Director" Value="1"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="Partner" Value="2"></asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlAuthority" InitialValue="" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAgentName" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                                                                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator22" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUnitOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />--%>
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
                                                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />--%>
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
                                                                                                                        ID="ddlState" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" runat="server" TabIndex="8">
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
                                                                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtDOB"
                                                                                                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                                                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtLicenseExpiry"
                                                                                                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPinCode"
                                                                                                                        ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-12" style="text-align: end;">
                                                                                                            <asp:Button type="Submit" OnClientClick="return validateFormodal();" ID="btnModalSubmit" Text="Add" OnClick="btnModalSubmit_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <hr style="margin-top: 10px; margin-bottom: 10px;" />
                                                                                                <div class="row" style="margin-top: 40px;">
                                                                                                    <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                                                                                                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                                                                                                        <PagerStyle CssClass="pagination-ys" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                                                                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                                                                                <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
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
                                                                                            <!-- Modal footer -->
                                                                                            <%--<div class="modal-footer">
                                                                                                 <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                                                                                            </div>--%>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <%--<asp:UpdatePanel ID="UpdatePanelCalculatedMonths" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDateM" runat="server" visible="false" style="margin-top: -37px;">
                                                                            <label for="Months">Months</label>
                                                                            <asp:TextBox class="form-control" ID="txtMonths" ReadOnly="true" runat="server" TabIndex="" MaxLength="30"> </asp:TextBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
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
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOffice" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOffice" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" /> --%>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <%--<div id="CalculatedDaysContainer" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanelCalculatedDays" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDate" visible="false" runat="server" style="margin-top: -19px;">
                                                                            <label for="Days">Days</label>
                                                                            <asp:TextBox class="form-control" ID="txtDays" ReadOnly="true" runat="server" TabIndex="" MaxLength="30"> </asp:TextBox>

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>--%>
                                                                    </div>
                                                                </div>
                                                                <%--<div class="row">
                                                                    <table class="table table-bordered" id="xirector" runat="server" visible="true" style="margin-top: 10px; margin-bottom: 20px; margin-left: 15px; width: 97%;">
                                                                        <thead>
                                                                            <tr style="text-align: center;">
                                                                                <th scope="col" style="padding-left: 1px; padding-right: 1px;">&nbsp; &nbsp; &nbsp; &nbsp; Type of Authority &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                                                                <th scope="col" id="FullName">Full Name</th>
                                                                                <th scope="col">Address</th>
                                                                                <th scope="col">State</th>
                                                                                <th scope="col">District</th>
                                                                                <th scope="col" id="pincoe">Pincode</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody id="dynamicTableBody">
                                                                            <tr>
                                                                                <td id="authoritytype">
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                        ID="DropDownList3" runat="server" TabIndex="">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="Partner" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="Director" Value="2"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription2" runat="server"> </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="TextBox2" runat="server"> </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; width: 100%; border-radius: 5px;"
                                                                                        ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" runat="server" TabIndex="">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; width: 100%; border-radius: 5px;"
                                                                                        ID="ddlDistrict" runat="server" TabIndex="">
                                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="TextBox1" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                            </tr>

                                                                        </tbody>
                                                                    </table>
                                                                    <div class="col-md-4">
                                                                        <asp:Button type="button" ID="btnBack" Text="Add More" OnClick="btnAddMore_Click" runat="server" class="btn btn-primary" Style="padding: 7px 5px 5px 5px; border-radius: 5px; margin-bottom: 5%;" />
                                                                    </div>
                                                                </div>--%>
                                                                <hr style="margin-top: 10px; margin-bottom: 10px;" />

                                                                <div class="row">
                                                                    <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="100%"
                                                                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                                                                        <PagerStyle CssClass="pagination-ys" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                                                <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
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
                                                            <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                                <div class="col-md-12">
                                                                    <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">APPLICANT DETAILS
                                                                    </h3>
                                                                </div>
                                                            </div>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label2" runat="server" visible="true">
                                                                                    Full Name of Agent/Manager<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgentName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgentName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label3" runat="server" visible="true">
                                                                                    Is Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlUnitOrNot" runat="server">
                                                                                    <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUnitOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUnitOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />--%>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label4" runat="server" visible="true">
                                                                                    Is Contractor License Previously Granted with same name from other state<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlLicenseGranted" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLicenseGranted_SelectedIndexChanged">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" /> --%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group" id="divIssueAuthority" runat="server" visible="false">
                                                                                <label id="Label5" runat="server" visible="true">
                                                                                    Name of Issuing Authority<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssusuingName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssusuingName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group" id="divLicensePreviouslyGranted" runat="server" visible="false">
                                                                                <label id="Label13" runat="server" visible="true">
                                                                                    Is Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlSameNameLicense" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssusuingName"        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtIssusuingName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group" id="divDOB" runat="server" visible="false">
                                                                                <label>
                                                                                    Date of Issue<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDOB" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDOB"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDOB"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group" id="divLicenseNo" runat="server" visible="false">

                                                                                <label id="Label14" runat="server" visible="true">
                                                                                    Enter License No.<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" onKeyPress="return isNumberKey(event) || alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIssusuingName" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtIssusuingName"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group" id="divLicenseExpiry" runat="server" visible="false">
                                                                                <label id="Label7" runat="server" visible="true">
                                                                                    Date of License Expiry<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseExpiry" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLicenseExpiry"  CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLicenseExpiry"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="form-group" id="divDOIssue" runat="server" visible="false">
                                                                                <label id="Labe20" runat="server" visible="true">
                                                                                    Date of Issue<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseIssue" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLicenseExpiry"  CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtLicenseIssue"
                                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                                <div class="col-md-12">
                                                                    <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">EMPLOYEES DETAILS
                                                                    </h3>
                                                                </div>
                                                            </div>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                                <div class="row">
                                                                    <table class="table table-bordered" style="margin-top: 10px; margin-bottom: 20px; margin-left: 15px; width: 97%;">
                                                                        <thead>
                                                                            <tr style="text-align: center;">
                                                                                <%--  <th scope="col" id="sno">Sno.</th>--%>
                                                                                <th scope="col" style="padding-left: 1px; padding-right: 1px;">&nbsp; &nbsp; Type of Employee &nbsp;&nbsp;</th>
                                                                                <th scope="col" id="LicenceNo">License No</th>
                                                                                <th scope="col">Issue Date</th>
                                                                                <th scope="col">Validity</th>
                                                                                <th scope="col">Qualification</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <%-- <td style="text-align: center; font-size: 13px;">1 </td>--%>
                                                                                <td>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                        ID="ddlEmployer1" runat="server">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="Supervisor" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="Wiremen" Value="2"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlEmployer1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />--%>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtLicense1" runat="server"> </asp:TextBox>
                                                                                    <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLicense1" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtIssueDate1" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' onchange="validateDates()" AutoPostBack="true"> </asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtIssueDate1" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtValidity1" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' onchange="validateDates()" AutoPostBack="true"> </asp:TextBox>
                                                                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtValidity1"  CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:CompareValidator ID="cmpDate" runat="server" ControlToCompare="txtIssueDate1" ControlToValidate="txtValidity1" Operator="GreaterThanEqual" Display="Dynamic" ForeColor="Red" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification1" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtQualification1" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                            </tr>
                                                                            <tr>
                                                                                <%-- <td style="text-align: center; font-size: 13px;">1</td>--%>
                                                                                <td>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                        ID="ddlEmployer2" runat="server">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="Supervisor" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="Wiremen" Value="2"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlEmployer2" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />--%>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtLicense2" runat="server"> </asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtLicense2" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtIssueDate2" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' onchange="validateDates1()" AutoPostBack="true"> </asp:TextBox>
                                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtIssueDate2" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtValidity2" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' onchange="validateDates1()" AutoPostBack="true"> </asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtQualification1"  CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtIssueDate2" ControlToValidate="txtValidity2" Operator="GreaterThanEqual" Display="Dynamic" ForeColor="Red" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification2" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtQualification1" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                                <div class="col-md-12">
                                                                    <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">PENALTIES/PUNISHMENT
                                                                    </h3>
                                                                </div>
                                                            </div>
                                                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label12" runat="server" visible="true">
                                                                                    Do company/firm have any penalties or punishments?<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" /> --%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4" id="DdlPenelity" runat="server" visible="false">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label10" runat="server" visible="true">
                                                                                    Select penalties or punishments<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlPenalities" runat="server" OnSelectedIndexChanged="ddlPenalities_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="By state licensing board, Haryana/chief Electrical inspector,Haryana" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="By government & other agencies" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Any court of law." Value="3"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red"--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4" id="ShowPenelity" runat="server" visible="false">
                                                                        <div class="forms-sample">
                                                                            <div class="form-group">
                                                                                <label id="Label1" runat="server" visible="true">
                                                                                    <%-- Selected<samp style="color: red">* </samp>--%>
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtPenalities" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server" TextMode="MultiLine" Rows="2"> </asp:TextBox>
                                                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgentName" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAgentName" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-bottom: -75px; margin-top: 50px;">
                                                                <div class="col-md-6" style="padding-left: 0px;">
                                                                    <asp:Button type="BtnSubmit" ID="Button1" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px; margin-bottom: 5%;" />
                                                                </div>
                                                                <div class="col-md-6" style="padding-right: 0px; text-align: end;">
                                                                    <asp:Button type="BtnSubmit" ID="Button2" Text="Next" OnClientClick="return validateForm();" OnClick="BtnSubmit_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px; margin-bottom: 5%;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col-md-1"></div>
                </div>

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
        function validateFormodal() {
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

            var DdlPartnerOrDirector = document.getElementById('DdlPartnerOrDirector');
            if (DdlPartnerOrDirector && DdlPartnerOrDirector.value === '1') {
                validateDropdown(document.getElementById('ddlAuthority'));
                validateField(document.getElementById('txtName'), 'Full Name');
                validateField(document.getElementById('txtAddress'), 'Address');
                validateDropdown(document.getElementById('ddlState'));
                validateDropdown(document.getElementById('ddlDistrict'));
                validateField(document.getElementById('txtPinCode'), 'PinCode');
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            return isValid;
        }
    </script>
    <script type="text/javascript">
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

            validateField(document.getElementById('txtGstNumber'), 'GstNumber');
            validateDropdown(document.getElementById('ddlCompanyStyle'));
            validateDropdown(document.getElementById('ddlOffice'));
            validateDropdown(document.getElementById('DdlPartnerOrDirector'));
            validateDropdown(document.getElementById('ddlAnnexureOrNot'));

            // Applicant details
            validateField(document.getElementById('txtAgentName'), 'AgentName');
            validateDropdown(document.getElementById('ddlUnitOrNot'));
            validateDropdown(document.getElementById('ddlLicenseGranted'));

            var ddlLicenseGranted = document.getElementById('ddlLicenseGranted');
            if (ddlLicenseGranted && ddlLicenseGranted.value === '1') {
                validateField(document.getElementById('txtIssusuingName'), 'Issusuing Name');
                validateField(document.getElementById('txtDOB'), 'DOB');
                validateField(document.getElementById('txtLicenseExpiry'), 'License Expiry');
                validateDropdown(document.getElementById('ddlSameNameLicense'));
            }

            var ddlSameNameLicense = document.getElementById('ddlSameNameLicense');
            if (ddlSameNameLicense && ddlSameNameLicense.value === '1') {
                validateField(document.getElementById('txtLicenseNo'), 'txtLicenseNo');
                validateField(document.getElementById('txtLicenseIssue'), 'LicenseIssue');
            }

            // EmployeeDetails
            validateDropdown(document.getElementById('ddlEmployer1'));
            validateField(document.getElementById('txtLicense1'), 'License1');
            validateField(document.getElementById('txtIssueDate1'), 'IssueDate1');
            validateField(document.getElementById('txtValidity1'), 'Validity1');
            validateField(document.getElementById('txtQualification1'), 'Qualification1');

            validateDropdown(document.getElementById('ddlEmployer2'));
            validateField(document.getElementById('txtLicense2'), 'License2');
            validateField(document.getElementById('txtIssueDate2'), 'IssueDate2');
            validateField(document.getElementById('txtValidity2'), 'Validity2');
            validateField(document.getElementById('txtQualification2'), 'Qualification2');

            // PENALTIES/PUNISHMENT
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
    </script>
    <script type="text/javascript">
        function validateDates() {
            var issuingDate = document.getElementById('<%=txtIssueDate1.ClientID %>').value;
            var validityDate = document.getElementById('<%=txtValidity1.ClientID %>').value;

            if (new Date(issuingDate) > new Date(validityDate)) {
                alert('Validity Date should be greater than Issuing Date');
                document.getElementById('<%=txtValidity1.ClientID %>').value = ''; // Clear the expiry date
            }
        }
    </script>
    <script type="text/javascript">
        function validateDates1() {
            var issuingDate = document.getElementById('<%=txtIssueDate2.ClientID %>').value;
            var validityDate = document.getElementById('<%=txtValidity2.ClientID %>').value;

            if (new Date(issuingDate) > new Date(validityDate)) {
                alert('Validity Date should be greater than Issuing Date');
                document.getElementById('<%=txtValidity2.ClientID %>').value = ''; // Clear the expiry date
            }
        }
    </script>

</body>
</html>
