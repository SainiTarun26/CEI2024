﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TestReport/TestReport.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="GeneratingSetTestReport.aspx.cs" Inherits="CEIHaryana.TestReport.GeneratingSetTestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>CEI</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="/Assets/css/feather/feather.css" />
    <link rel="stylesheet" href="/Assets/css/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="/Assets/css/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="/Assets/css/datatables.net-bs4/dataTables.bootstrap4.css" />
    <link rel="stylesheet" href="/Assets/css/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" type="/Assets/css/css" href="js/select.dataTables.min.css" />
    <link rel="stylesheet" href="/Assets/css/vertical-layout-light/style.css" />
    <link rel="shortcut icon" href="images/favicon.png" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/3.1.0/css/font-awesome.min.css" />

    <style type="text/css">
        li.tab-content.tab-content-3.typography {
            border: 8px solid #CED4DA;
            border-top: 0;
            padding: 2rem 1rem;
            text-align: justify;
            border-bottom-left-radius: 15px;
            border-bottom-right-radius: 15px;
            width: 99%;
        }

        svg {
            margin-right: 8px !important;
        }

        z
        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        div#ContentPlaceHolder1_individual {
            top: 15px;
        }

        .col-4 {
            left: 0px;
        }

        .col-2 {
            top: 15px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
            padding: 0px 5px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
            padding: 0px 5px !important;
        }

        label {
            font-size: 13px;
            margin-top: 15px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single .form-control {
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

        span.select2-dropdown.select2-dropdown--below {
            margin-top: 30px !important;
        }

        .pcss3t {
            margin: 0;
            padding: 10px;
            border: 0;
            outline: none;
            font-size: 0;
            text-align: left;
        }

            .pcss3t > input {
                position: absolute;
                left: -9999px;
            }

            .pcss3t > label {
                position: relative;
                display: inline-block;
                margin: 0;
                padding: 0;
                border: 0;
                outline: none;
                cursor: pointer;
                transition: all 0.1s;
                -o-transition: all 0.1s;
                -ms-transition: all 0.1s;
                -moz-transition: all 0.1s;
                -webkit-transition: all 0.1s;
            }

                .pcss3t > label i {
                    display: block;
                    float: left;
                    margin: 16px 8px 0 -2px;
                    padding: 0;
                    border: 0;
                    outline: none;
                    font-family: FontAwesome;
                    font-style: normal;
                    font-size: 17px;
                }

            .pcss3t > input:checked + label {
                cursor: default;
            }

            .pcss3t > ul {
                list-style: none;
                position: relative;
                display: block;
                overflow: hidden;
                margin: 0;
                padding: 0;
                border: 0;
                outline: none;
                font-size: 13px;
            }

                .pcss3t > ul > li {
                    position: absolute;
                    width: 100%;
                    overflow: auto;
                    padding: 30px 40px 40px;
                    box-sizing: border-box;
                    -moz-box-sizing: border-box;
                    opacity: 0;
                    transition: all 0.5s;
                    -o-transition: all 0.5s;
                    -ms-transition: all 0.5s;
                    -moz-transition: all 0.5s;
                    -webkit-transition: all 0.5s;
                }

            .pcss3t > .tab-content-first:checked ~ ul .tab-content-first,
            .pcss3t > .tab-content-2:checked ~ ul .tab-content-2,
            .pcss3t > .tab-content-3:checked ~ ul .tab-content-3,
            .pcss3t > .tab-content-4:checked ~ ul .tab-content-4,
            .pcss3t > .tab-content-5:checked ~ ul .tab-content-5,
            .pcss3t > .tab-content-6:checked ~ ul .tab-content-6,
            .pcss3t > .tab-content-7:checked ~ ul .tab-content-7,
            .pcss3t > .tab-content-8:checked ~ ul .tab-content-8,
            .pcss3t > .tab-content-9:checked ~ ul .tab-content-9,
            .pcss3t > .tab-content-last:checked ~ ul .tab-content-last {
                z-index: 1;
                top: 0;
                left: 0;
                opacity: 1;
                -webkit-transform: scale(1,1);
                -webkit-transform: rotate(0deg);
            }



        .pcss3t-height-auto > ul {
            height: auto !important;
        }

            .pcss3t-height-auto > ul > li {
                position: static;
                display: none;
                height: auto !important;
            }

        .pcss3t-height-auto > .tab-content-first:checked ~ ul .tab-content-first,
        .pcss3t-height-auto > .tab-content-2:checked ~ ul .tab-content-2,
        .pcss3t-height-auto > .tab-content-3:checked ~ ul .tab-content-3,
        .pcss3t-height-auto > .tab-content-4:checked ~ ul .tab-content-4,
        .pcss3t-height-auto > .tab-content-5:checked ~ ul .tab-content-5,
        .pcss3t-height-auto > .tab-content-last:checked ~ ul .tab-content-last {
            display: block;
        }



        .pcss3t .grid-row {
            margin-top: 20px;
        }

            .pcss3t .grid-row:after {
                content: '';
                display: table;
                clear: both;
            }

            .pcss3t .grid-row:first-child {
                margin-top: 0;
            }

        .pcss3t .grid-col {
            display: block;
            float: left;
            margin-left: 2%;
        }

            .pcss3t .grid-col:first-child {
                margin-left: 0;
            }

            .pcss3t .grid-col .inner {
                padding: 10px 0;
                border-radius: 5px;
                background: #f2f2f2;
                text-align: center;
            }

        .pcss3t .grid-col-1 {
            width: 15%;
        }

        .pcss3t .grid-col-2 {
            width: 32%;
        }

        .pcss3t .grid-col-3 {
            width: 49%;
        }

        .pcss3t .grid-col-4 {
            width: 66%;
        }

        .pcss3t .grid-col-5 {
            width: 83%;
        }

        .pcss3t .grid-col-offset-1 {
            margin-left: 19%;
        }

            .pcss3t .grid-col-offset-1:first-child {
                margin-left: 17%;
            }

        .pcss3t .grid-col-offset-2 {
            margin-left: 36%;
        }

            .pcss3t .grid-col-offset-2:first-child {
                margin-left: 34%;
            }

        .pcss3t .grid-col-offset-3 {
            margin-left: 53%;
        }

            .pcss3t .grid-col-offset-3:first-child {
                margin-left: 51%;
            }

        .pcss3t .grid-col-offset-4 {
            margin-left: 70%;
        }

            .pcss3t .grid-col-offset-4:first-child {
                margin-left: 68%;
            }

        .pcss3t .grid-col-offset-5:first-child {
            margin-left: 85%;
        }


        .pcss3t .typography {
            color: #666;
        }

            .pcss3t .typography h1,
            .pcss3t .typography h2,
            .pcss3t .typography h3,
            .pcss3t .typography h4,
            .pcss3t .typography h5,
            .pcss3t .typography h6 {
                margin: 40px 0 0 0;
                padding: 0;
                font-family: Gabriela, Georgia, serif;
                text-align: left;
                color: #333;
            }

            .pcss3t .typography h1 {
                font-size: 40px;
                line-height: 60px;
                text-shadow: 3px 3px rgba(0,0,0,0.1);
            }

            .pcss3t .typography h2 {
                font-size: 32px;
                line-height: 48px;
                text-shadow: 2px 2px rgba(0,0,0,0.1);
            }

            .pcss3t .typography h3 {
                font-size: 26px;
                line-height: 38px;
                text-shadow: 1px 1px rgba(0,0,0,0.1);
            }

            .pcss3t .typography h4 {
                font-size: 20px;
                line-height: 30px;
            }

            .pcss3t .typography h5 {
                font-size: 15px;
                line-height: 23px;
                text-transform: uppercase;
            }

            .pcss3t .typography h6 {
                font-size: 13px;
                line-height: 20px;
                font-weight: 700;
                text-transform: uppercase;
            }

            .pcss3t .typography p {
                margin: 20px 0 0 0;
                padding: 0;
                line-height: 20px;
                text-align: left;
            }

            .pcss3t .typography ul,
            .pcss3t .typography ol {
                list-style: none;
                margin: 20px 0 0 0;
                padding: 0;
            }

            .pcss3t .typography li {
                position: relative;
                margin-top: 5px;
                padding-left: 20px;
            }

                .pcss3t .typography li ul,
                .pcss3t .typography li ol {
                    margin-top: 5px;
                }

            .pcss3t .typography ul li:before {
                content: '';
                position: absolute;
                top: 8px;
                left: 0;
                width: 6px;
                height: 4px;
                background: #404040;
            }

            .pcss3t .typography ol {
                counter-reset: list1;
            }

                .pcss3t .typography ol > li:before {
                    counter-increment: list1;
                    content: counter(list1)'.';
                    position: absolute;
                    top: 0;
                    left: 0;
                }

            .pcss3t .typography a {
                text-decoration: underline;
                color: #1889e6;
            }

                .pcss3t .typography a:hover {
                    text-decoration: none;
                }

            .pcss3t .typography .pic {
                padding: 4px;
                border: 1px dotted #ccc;
            }

                .pcss3t .typography .pic img {
                    display: block;
                }

            .pcss3t .typography .pic-right {
                float: right;
                margin: 0 0 10px 20px;
            }

            .pcss3t .typography .link {
                text-decoration: underline;
                color: #1889e6;
                cursor: pointer;
            }

                .pcss3t .typography .link:hover {
                    text-decoration: none;
                }

            .pcss3t .typography h1:first-child,
            .pcss3t .typography h2:first-child,
            .pcss3t .typography h3:first-child,
            .pcss3t .typography h4:first-child,
            .pcss3t .typography h5:first-child,
            .pcss3t .typography h6:first-child,
            .pcss3t .typography p:first-child {
                margin-top: 0;
            }

            .pcss3t .typography .text-center {
                text-align: center;
            }

            .pcss3t .typography .text-right {
                text-align: right;
            }


        /**/
        /* steps */
        /**/
        .pcss3t-steps > label {
            cursor: default;
        }


        /**/
        /* animation effects */
        /**/
        .pcss3t-effect-scale > ul > li {
            -webkit-transform: scale(0.1,0.1);
        }

        .pcss3t-effect-rotate > ul > li {
            -webkit-transform: rotate(180deg);
        }

        .pcss3t-effect-slide-top > ul > li {
            top: -40px;
        }

        .pcss3t-effect-slide-right > ul > li {
            left: 80px;
        }

        .pcss3t-effect-slide-bottom > ul > li {
            top: 40px;
        }

        .pcss3t-effect-slide-left > ul > li {
            left: -80px;
        }



        /*----------------------------------------------------------------------------*/
        /*                                   LAYOUTS                                  */
        /*----------------------------------------------------------------------------*/

        /**/
        /* top right */
        /**/
        .pcss3t-layout-top-right {
            text-align: right;
        }


        /**/
        /* top center */
        /**/
        .pcss3t-layout-top-center {
            text-align: center;
        }


        /**/
        /* top combi */
        /**/
        .pcss3t > .right {
            float: right;
        }



        /*----------------------------------------------------------------------------*/
        /*                                    ICONS                                   */
        /*----------------------------------------------------------------------------*/

        /**/
        /* icons positions */
        /**/
        .pcss3t-icons-top > label {
            text-align: center;
        }

            .pcss3t-icons-top > label i {
                float: none;
                margin: 0 auto -10px;
                padding-top: 17px;
                font-size: 23px;
                line-height: 23px;
                text-align: center;
            }

        .pcss3t-icons-right > label i {
            float: right;
            margin: 0 -2px 0 8px;
        }

        .pcss3t-icons-bottom > label {
            text-align: center;
        }

            .pcss3t-icons-bottom > label i {
                float: none;
                margin: -10px auto 0;
                padding-bottom: 17px;
                font-size: 23px;
                line-height: 23px;
                text-align: center;
            }

        .pcss3t-icons-only > label i {
            float: none;
            margin: 0 auto;
            font-size: 23px;
        }


        /**/
        /* font awesome */
        /**/
        @font-face {
            font-family: 'FontAwesome';
            src: url('../fonts/fontawesome-webfont.eot?v=3.0.1');
            src: url('../fonts/fontawesome-webfont.eot?#iefix&v=3.0.1') format('embedded-opentype'), url('../fonts/fontawesome-webfont.woff?v=3.0.1') format('woff'), url('../fonts/fontawesome-webfont.ttf?v=3.0.1') format('truetype');
            font-weight: normal;
            font-style: normal;
        }

        .icon-glass:before {
            content: '\f000';
        }

        .icon-music:before {
            content: '\f001';
        }

        .icon-search:before {
            content: '\f002';
        }

        .icon-envelope:before {
            content: '\f003';
        }

        .icon-heart:before {
            content: '\f004';
        }

        .icon-star:before {
            content: '\f005';
        }

        .icon-star-empty:before {
            content: '\f006';
        }

        .icon-user:before {
            content: '\f007';
        }

        .icon-film:before {
            content: '\f008';
        }

        .icon-th-large:before {
            content: '\f009';
        }

        .icon-th:before {
            content: '\f00a';
        }

        .icon-th-list:before {
            content: '\f00b';
        }

        .icon-ok:before {
            content: '\f00c';
        }

        .icon-remove:before {
            content: '\f00d';
        }

        .icon-zoom-in:before {
            content: '\f00e';
        }

        .icon-zoom-out:before {
            content: '\f010';
        }

        .icon-off:before {
            content: '\f011';
        }

        .icon-signal:before {
            content: '\f012';
        }

        .icon-cog:before {
            content: '\f013';
        }

        .icon-trash:before {
            content: '\f014';
        }

        .icon-home:before {
            content: '\f015';
        }

        .icon-file:before {
            content: '\f016';
        }

        .icon-time:before {
            content: '\f017';
        }

        .icon-road:before {
            content: '\f018';
        }

        .icon-download-alt:before {
            content: '\f019';
        }

        .icon-download:before {
            content: '\f01a';
        }

        .icon-upload:before {
            content: '\f01b';
        }

        .icon-inbox:before {
            content: '\f01c';
        }

        .icon-play-circle:before {
            content: '\f01d';
        }

        .icon-repeat:before {
            content: '\f01e';
        }

        .icon-refresh:before {
            content: '\f021';
        }

        .icon-list-alt:before {
            content: '\f022';
        }

        .icon-lock:before {
            content: '\f023';
        }

        .icon-flag:before {
            content: '\f024';
        }

        .icon-headphones:before {
            content: '\f025';
        }

        .icon-volume-off:before {
            content: '\f026';
        }

        .icon-volume-down:before {
            content: '\f027';
        }

        .icon-volume-up:before {
            content: '\f028';
        }

        .icon-qrcode:before {
            content: '\f029';
        }

        .icon-barcode:before {
            content: '\f02a';
        }

        .icon-tag:before {
            content: '\f02b';
        }

        .icon-tags:before {
            content: '\f02c';
        }

        .icon-book:before {
            content: '\f02d';
        }

        .icon-bookmark:before {
            content: '\f02e';
        }

        .icon-print:before {
            content: '\f02f';
        }

        .icon-camera:before {
            content: '\f030';
        }

        .icon-font:before {
            content: '\f031';
        }

        .icon-bold:before {
            content: '\f032';
        }

        .icon-italic:before {
            content: '\f033';
        }

        .icon-text-height:before {
            content: '\f034';
        }

        .icon-text-width:before {
            content: '\f035';
        }

        .icon-align-left:before {
            content: '\f036';
        }

        .icon-align-center:before {
            content: '\f037';
        }

        .icon-align-right:before {
            content: '\f038';
        }

        .icon-align-justify:before {
            content: '\f039';
        }

        .icon-list:before {
            content: '\f03a';
        }

        .icon-indent-left:before {
            content: '\f03b';
        }

        .icon-indent-right:before {
            content: '\f03c';
        }

        .icon-facetime-video:before {
            content: '\f03d';
        }

        .icon-picture:before {
            content: '\f03e';
        }

        .icon-pencil:before {
            content: '\f040';
        }

        .icon-map-marker:before {
            content: '\f041';
        }

        .icon-adjust:before {
            content: '\f042';
        }

        .icon-tint:before {
            content: '\f043';
        }

        .icon-edit:before {
            content: '\f044';
        }

        .icon-share:before {
            content: '\f045';
        }

        .icon-check:before {
            content: '\f046';
        }

        .icon-move:before {
            content: '\f047';
        }

        .icon-step-backward:before {
            content: '\f048';
        }

        .icon-fast-backward:before {
            content: '\f049';
        }

        .icon-backward:before {
            content: '\f04a';
            position: relative;
            left: -2px;
        }

        .icon-play:before {
            content: '\f04b';
            position: relative;
            left: 1px;
        }

        .icon-pause:before {
            content: '\f04c';
        }

        .icon-stop:before {
            content: '\f04d';
        }

        .icon-forward:before {
            content: '\f04e';
            position: relative;
            left: 2px;
        }

        .icon-fast-forward:before {
            content: '\f050';
        }

        .icon-step-forward:before {
            content: '\f051';
        }

        .icon-eject:before {
            content: '\f052';
        }

        .icon-chevron-left:before {
            content: '\f053';
        }

        .icon-chevron-right:before {
            content: '\f054';
        }

        .icon-plus-sign:before {
            content: '\f055';
        }

        .icon-minus-sign:before {
            content: '\f056';
        }

        .icon-remove-sign:before {
            content: '\f057';
        }

        .icon-ok-sign:before {
            content: '\f058';
        }

        .icon-question-sign:before {
            content: '\f059';
        }

        .icon-info-sign:before {
            content: '\f05a';
        }

        .icon-screenshot:before {
            content: '\f05b';
        }

        .icon-remove-circle:before {
            content: '\f05c';
        }

        .icon-ok-circle:before {
            content: '\f05d';
        }

        .icon-ban-circle:before {
            content: '\f05e';
        }

        .icon-arrow-left:before {
            content: '\f060';
        }

        .icon-arrow-right:before {
            content: '\f061';
        }

        .icon-arrow-up:before {
            content: '\f062';
        }

        .icon-arrow-down:before {
            content: '\f063';
        }

        .icon-share-alt:before {
            content: '\f064';
        }

        .icon-resize-full:before {
            content: '\f065';
        }

        .icon-resize-small:before {
            content: '\f066';
        }

        .icon-plus:before {
            content: '\f067';
        }

        .icon-minus:before {
            content: '\f068';
        }

        .icon-asterisk:before {
            content: '\f069';
        }

        .icon-exclamation-sign:before {
            content: '\f06a';
        }

        .icon-gift:before {
            content: '\f06b';
        }

        .icon-leaf:before {
            content: '\f06c';
        }

        .icon-fire:before {
            content: '\f06d';
        }

        .icon-eye-open:before {
            content: '\f06e';
        }

        .icon-eye-close:before {
            content: '\f070';
        }

        .icon-warning-sign:before {
            content: '\f071';
        }

        .icon-plane:before {
            content: '\f072';
        }

        .icon-calendar:before {
            content: '\f073';
        }

        .icon-random:before {
            content: '\f074';
        }

        .icon-comment:before {
            content: '\f075';
        }

        .icon-magnet:before {
            content: '\f076';
        }

        .icon-chevron-up:before {
            content: '\f077';
        }

        .icon-chevron-down:before {
            content: '\f078';
        }

        .icon-retweet:before {
            content: '\f079';
        }

        .icon-shopping-cart:before {
            content: '\f07a';
        }

        .icon-folder-close:before {
            content: '\f07b';
        }

        .icon-folder-open:before {
            content: '\f07c';
        }

        .icon-resize-vertical:before {
            content: '\f07d';
        }

        .icon-resize-horizontal:before {
            content: '\f07e';
        }

        .icon-bar-chart:before {
            content: '\f080';
        }

        .icon-twitter-sign:before {
            content: '\f081';
        }

        .icon-facebook-sign:before {
            content: '\f082';
        }

        .icon-camera-retro:before {
            content: '\f083';
        }

        .icon-key:before {
            content: '\f084';
        }

        .icon-cogs:before {
            content: '\f085';
        }

        .icon-comments:before {
            content: '\f086';
        }

        .icon-thumbs-up:before {
            content: '\f087';
        }

        .icon-thumbs-down:before {
            content: '\f088';
        }

        .icon-star-half:before {
            content: '\f089';
        }

        .icon-heart-empty:before {
            content: '\f08a';
        }

        .icon-signout:before {
            content: '\f08b';
        }

        .icon-linkedin-sign:before {
            content: '\f08c';
        }

        .icon-pushpin:before {
            content: '\f08d';
        }

        .icon-external-link:before {
            content: '\f08e';
        }

        .icon-signin:before {
            content: '\f090';
        }

        .icon-trophy:before {
            content: '\f091';
        }

        .icon-github-sign:before {
            content: '\f092';
        }

        .icon-upload-alt:before {
            content: '\f093';
        }

        .icon-lemon:before {
            content: '\f094';
        }

        .icon-phone:before {
            content: '\f095';
        }

        .icon-check-empty:before {
            content: '\f096';
        }

        .icon-bookmark-empty:before {
            content: '\f097';
        }

        .icon-phone-sign:before {
            content: '\f098';
        }

        .icon-twitter:before {
            content: '\f099';
        }

        .icon-facebook:before {
            content: '\f09a';
        }

        .icon-github:before {
            content: '\f09b';
        }

        .icon-unlock:before {
            content: '\f09c';
        }

        .icon-credit-card:before {
            content: '\f09d';
        }

        .icon-rss:before {
            content: '\f09e';
        }

        .icon-hdd:before {
            content: '\f0a0';
        }

        .icon-bullhorn:before {
            content: '\f0a1';
        }

        .icon-bell:before {
            content: '\f0a2';
        }

        .icon-certificate:before {
            content: '\f0a3';
        }

        .icon-hand-right:before {
            content: '\f0a4';
        }

        .icon-hand-left:before {
            content: '\f0a5';
        }

        .icon-hand-up:before {
            content: '\f0a6';
        }

        .icon-hand-down:before {
            content: '\f0a7';
        }

        .icon-circle-arrow-left:before {
            content: '\f0a8';
        }

        .icon-circle-arrow-right:before {
            content: '\f0a9';
        }

        .icon-circle-arrow-up:before {
            content: '\f0aa';
        }

        .icon-circle-arrow-down:before {
            content: '\f0ab';
        }

        .icon-globe:before {
            content: '\f0ac';
        }

        .icon-wrench:before {
            content: '\f0ad';
        }

        .icon-tasks:before {
            content: '\f0ae';
        }

        .icon-filter:before {
            content: '\f0b0';
        }

        .icon-briefcase:before {
            content: '\f0b1';
        }

        .icon-fullscreen:before {
            content: '\f0b2';
        }

        .icon-group:before {
            content: '\f0c0';
        }

        .icon-link:before {
            content: '\f0c1';
        }

        .icon-cloud:before {
            content: '\f0c2';
        }

        .icon-beaker:before {
            content: '\f0c3';
        }

        .icon-cut:before {
            content: '\f0c4';
        }

        .icon-copy:before {
            content: '\f0c5';
        }

        .icon-paper-clip:before {
            content: '\f0c6';
        }

        .icon-save:before {
            content: '\f0c7';
        }

        .icon-sign-blank:before {
            content: '\f0c8';
        }

        .icon-reorder:before {
            content: '\f0c9';
        }

        .icon-list-ul:before {
            content: '\f0ca';
        }

        .icon-list-ol:before {
            content: '\f0cb';
        }

        .icon-strikethrough:before {
            content: '\f0cc';
        }

        .icon-underline:before {
            content: '\f0cd';
        }

        .icon-table:before {
            content: '\f0ce';
        }

        .icon-magic:before {
            content: '\f0d0';
        }

        .icon-truck:before {
            content: '\f0d1';
        }

        .icon-pinterest:before {
            content: '\f0d2';
        }

        .icon-pinterest-sign:before {
            content: '\f0d3';
        }

        .icon-google-plus-sign:before {
            content: '\f0d4';
        }

        .icon-google-plus:before {
            content: '\f0d5';
        }

        .icon-money:before {
            content: '\f0d6';
        }

        .icon-caret-down:before {
            content: '\f0d7';
        }

        .icon-caret-up:before {
            content: '\f0d8';
        }

        .icon-caret-left:before {
            content: '\f0d9';
        }

        .icon-caret-right:before {
            content: '\f0da';
        }

        .icon-columns:before {
            content: '\f0db';
        }

        .icon-sort:before {
            content: '\f0dc';
        }

        .icon-sort-down:before {
            content: '\f0dd';
        }

        .icon-sort-up:before {
            content: '\f0de';
        }

        .icon-envelope-alt:before {
            content: '\f0e0';
        }

        .icon-linkedin:before {
            content: '\f0e1';
        }

        .icon-undo:before {
            content: '\f0e2';
        }

        .icon-legal:before {
            content: '\f0e3';
        }

        .icon-dashboard:before {
            content: '\f0e4';
        }

        .icon-comment-alt:before {
            content: '\f0e5';
        }

        .icon-comments-alt:before {
            content: '\f0e6';
        }

        .icon-bolt:before {
            content: '\f0e7';
        }

        .icon-sitemap:before {
            content: '\f0e8';
        }

        .icon-umbrella:before {
            content: '\f0e9';
        }

        .icon-paste:before {
            content: '\f0ea';
        }

        .icon-lightbulb:before {
            content: '\f0eb';
        }

        .icon-exchange:before {
            content: '\f0ec';
        }

        .icon-cloud-download:before {
            content: '\f0ed';
        }

        .icon-cloud-upload:before {
            content: '\f0ee';
        }

        .icon-user-md:before {
            content: '\f0f0';
        }

        .icon-stethoscope:before {
            content: '\f0f1';
        }

        .icon-suitcase:before {
            content: '\f0f2';
        }

        .icon-bell-alt:before {
            content: '\f0f3';
        }

        .icon-coffee:before {
            content: '\f0f4';
        }

        .icon-food:before {
            content: '\f0f5';
        }

        .icon-file-alt:before {
            content: '\f0f6';
        }

        .icon-building:before {
            content: '\f0f7';
        }

        .icon-hospital:before {
            content: '\f0f8';
        }

        .icon-ambulance:before {
            content: '\f0f9';
        }

        .icon-medkit:before {
            content: '\f0fa';
        }

        .icon-fighter-jet:before {
            content: '\f0fb';
        }

        .icon-beer:before {
            content: '\f0fc';
        }

        .icon-h-sign:before {
            content: '\f0fd';
        }

        .icon-plus-sign-alt:before {
            content: '\f0fe';
        }

        .icon-double-angle-left:before {
            content: '\f100';
        }

        .icon-double-angle-right:before {
            content: '\f101';
        }

        .icon-double-angle-up:before {
            content: '\f102';
        }

        .icon-double-angle-down:before {
            content: '\f103';
        }

        .icon-angle-left:before {
            content: '\f104';
        }

        .icon-angle-right:before {
            content: '\f105';
        }

        .icon-angle-up:before {
            content: '\f106';
        }

        .icon-angle-down:before {
            content: '\f107';
        }

        .icon-desktop:before {
            content: '\f108';
        }

        .icon-laptop:before {
            content: '\f109';
        }

        .icon-tablet:before {
            content: '\f10a';
        }

        .icon-mobile-phone:before {
            content: '\f10b';
        }

        .icon-circle-blank:before {
            content: '\f10c';
        }

        .icon-quote-left:before {
            content: '\f10d';
        }

        .icon-quote-right:before {
            content: '\f10e';
        }

        .icon-spinner:before {
            content: '\f110';
        }

        .icon-circle:before {
            content: '\f111';
        }

        .icon-reply:before {
            content: '\f112';
        }

        .icon-github-alt:before {
            content: '\f113';
        }

        .icon-folder-close-alt:before {
            content: '\f114';
        }

        .icon-folder-open-alt:before {
            content: '\f115';
        }



        /*----------------------------------------------------------------------------*/
        /*                               RESPONSIVENESS                               */
        /*----------------------------------------------------------------------------*/

        /**/
        /* pad */
        /**/
        @media screen and (max-width: 980px) {
        }


        /**/
        /* phone */
        /**/
        @media screen and (max-width: 767px) {
            .pcss3t > label {
                display: block;
            }

            .pcss3t > .right {
                float: none;
            }
        }



        /*----------------------------------------------------------------------------*/
        /*                                   THEMES                                   */
        /*----------------------------------------------------------------------------*/

        /**/
        /* default */
        /**/
        .pcss3t > label {
            padding: 0 20px;
            background: #e5e5e5;
            font-size: 13px;
            line-height: 49px;
        }

            .pcss3t > label:hover {
                background: #f2f2f2;
            }

        .pcss3t > input:checked + label {
            background: #fff;
        }

        .pcss3t > ul {
            background: #fff;
            text-align: left;
        }

        .pcss3t-steps > label:hover {
            background: #e5e5e5;
        }


        /**/
        /* theme 1 */
        /**/
        .pcss3t-theme-1 > label {
            margin: 0 5px 5px 0;
            border-radius: 5px;
            background: #fff;
            box-shadow: 0 2px rgba(0,0,0,0.2);
            color: #808080;
            opacity: 0.8;
        }

            .pcss3t-theme-1 > label:hover {
                background: #fff;
                opacity: 1;
            }

        .pcss3t-theme-1 > input:checked + label {
            margin-bottom: 0;
            padding-bottom: 5px;
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
            color: #2b82d9;
            opacity: 1;
        }

        .pcss3t-theme-1 > ul {
            border-radius: 5px;
            box-shadow: 0 3px rgba(0,0,0,0.2);
        }

        .pcss3t-theme-1 > .tab-content-first:checked ~ ul {
            border-top-left-radius: 0;
        }

        @media screen and (max-width: 767px) {
            .pcss3t-theme-1 > label {
                margin-right: 0;
            }

            .pcss3t-theme-1 > input:checked + label {
                margin-bottom: 5px;
                padding-bottom: 0;
                border-radius: 5px;
            }

            .pcss3t-theme-1 > .tab-content-first:checked ~ ul {
                border-top-left-radius: 5px;
            }
        }


        /**/
        /* theme 2 */
        /**/
        .pcss3t-theme-2 {
            padding: 5px;
            background: rgba(0,0,0,0.2);
        }

            .pcss3t-theme-2 > label {
                margin-right: 0;
                margin-bottom: 0;
                background: none;
                border-radius: 0;
                text-shadow: 1px 1px 1px rgba(0,0,0,0.2);
                color: #fff;
                opacity: 1;
            }

                .pcss3t-theme-2 > label:hover {
                    background: rgba(255,255,255,0.2);
                }

            .pcss3t-theme-2 > input:checked + label {
                padding-bottom: 0;
                background: #fff;
                background: linear-gradient(to bottom, #e5e5e5 0%, #ffffff 100%);
                background: -o-linear-gradient(top, #e5e5e5 0%, #ffffff 100%);
                background: -ms-linear-gradient(top, #e5e5e5 0%, #ffffff 100%);
                background: -moz-linear-gradient(top, #e5e5e5 0%, #ffffff 100%);
                background: -webkit-linear-gradient(top, #e5e5e5 0%, #ffffff 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#e5e5e5', endColorstr='#ffffff', GradientType=0);
                text-shadow: 1px 1px 1px rgba(255,255,255,0.5);
                color: #822bd9;
            }

            .pcss3t-theme-2 > ul {
                margin: 0 -5px -5px;
                border-radius: 0;
                box-shadow: none;
            }

        @media screen and (max-width: 767px) {
            .pcss3t-theme-2 > ul {
                margin-top: 5px;
            }
        }


        /**/
        /* theme 3 */
        /**/
        .pcss3t-theme-3 {
            background: rgba(0,0,0,0.8);
        }

            .pcss3t-theme-3 > label {
                background: none;
                border-right: 1px dotted rgba(255,255,255,0.5);
                text-align: center;
                color: #fff;
                opacity: 0.6;
            }

                .pcss3t-theme-3 > label:hover {
                    background: none;
                    color: #d9d92b;
                    opacity: 0.8;
                }

            .pcss3t-theme-3 > input:checked + label {
                background: #d9d92b;
                color: #000;
                opacity: 1;
            }

            .pcss3t-theme-3 > ul {
                border-top: 4px solid #d9d92b;
                border-bottom: 4px solid #d9d92b;
                border-radius: 0;
                box-shadow: none;
            }


        /**/
        /* theme 4 */
        /**/
        .pcss3t-theme-4 > label {
            margin: 0 10px 10px 0;
            border-radius: 5px;
            background: #78c5fd;
            background: linear-gradient(to bottom, #78c5fd 0%, #2c8fdd 100%);
            background: -o-linear-gradient(top, #78c5fd 0%, #2c8fdd 100%);
            background: -ms-linear-gradient(top, #78c5fd 0%, #2c8fdd 100%);
            background: -moz-linear-gradient(top, #78c5fd 0%, #2c8fdd 100%);
            background: -webkit-linear-gradient(top, #78c5fd 0%, #2c8fdd 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#78c5fd', endColorstr='#2c8fdd', GradientType=0);
            box-shadow: inset 0 1px rgba(255,255,255,0.5), 0 1px rgba(0,0,0,0.5);
            line-height: 39px;
            text-shadow: 0 1px rgba(0,0,0,0.5);
            color: #fff;
        }

            .pcss3t-theme-4 > label:hover {
                background: #90cffc;
                background: linear-gradient(to bottom, #90cffc 0%, #439bde 100%);
                background: -o-linear-gradient(top, #90cffc 0%, #439bde 100%);
                background: -ms-linear-gradient(top, #90cffc 0%, #439bde 100%);
                background: -moz-linear-gradient(top, #90cffc 0%, #439bde 100%);
                background: -webkit-linear-gradient(top, #90cffc 0%, #439bde 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#90cffc', endColorstr='#439bde', GradientType=0);
            }

        .pcss3t-theme-4 > input:checked + label {
            top: 1px;
            background: #5f9dc9;
            background: linear-gradient(to bottom, #5f9dc9 0%, #2270ab 100%);
            background: -o-linear-gradient(top, #5f9dc9 0%, #2270ab 100%);
            background: -ms-linear-gradient(top, #5f9dc9 0%, #2270ab 100%);
            background: -moz-linear-gradient(top, #5f9dc9 0%, #2270ab 100%);
            background: -webkit-linear-gradient(top, #5f9dc9 0%, #2270ab 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5f9dc9', endColorstr='#2270ab', GradientType=0);
            box-shadow: inset 0 1px 1px rgba(0,0,0,0.5), 0 1px rgba(255,255,255,0.5);
            text-shadow: none;
        }

        .pcss3t-theme-4 > ul {
            border-radius: 5px;
            box-shadow: 0 2px 2px rgba(0,0,0,0.3);
        }

        @media screen and (max-width: 767px) {
            .pcss3t-theme-4 > label {
                margin-right: 0;
            }
        }


        /**/
        /* theme 5 */
        /**/
        .pcss3t-theme-5 {
            padding: 15px;
            border-radius: 5px;
            background: #ad6395;
            background: linear-gradient(to right, #ad6395 0%, #a163ad 100%);
            background: -o-linear-gradient(left, #ad6395 0%, #a163ad 100%);
            background: -ms-linear-gradient(left, #ad6395 0%, #a163ad 100%);
            background: -moz-linear-gradient(left, #ad6395 0%, #a163ad 100%);
            background: -webkit-linear-gradient(left, #ad6395 0%, #a163ad 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5f9dc9', endColorstr='#a163ad', GradientType=1);
        }

            .pcss3t-theme-5 > label {
                margin-right: 10px;
                margin-bottom: 15px;
                background: none;
                border-radius: 5px;
                text-align: center;
                color: #fff;
                opacity: 1;
            }

                .pcss3t-theme-5 > label:hover {
                    background: rgba(255,255,255,0.15);
                }

            .pcss3t-theme-5 > input:checked + label {
                background: rgba(255,255,255,0.3);
                color: #000;
            }

                .pcss3t-theme-5 > input:checked + label:after {
                    content: '';
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-top: 10px;
                    margin-left: -6px;
                    border-right: 6px solid transparent;
                    border-bottom: 6px solid #fff;
                    border-left: 6px solid transparent;
                }

            .pcss3t-theme-5 > ul {
                margin: 0 -15px -15px;
                border-radius: 0 0 5px 5px;
                box-shadow: none;
            }

        @media screen and (max-width: 767px) {
            .pcss3t-theme-5 > input:checked + label:after {
                display: none;
            }
        }


        /*----------------------------------------------------------------------------*/
        /*                               CUSTOMIZATION                                */
        /*----------------------------------------------------------------------------*/

        /**/
        /* height */
        /**/
        .pcss3t > ul,
        .pcss3t > ul > li {
            height: 570px;
        }

        span.menu-title {
            COLOR: #F9F9F9 !IMPORTANT;
        }

        ::before {
            color: #382c2c;
        }

        img {
            height: 60px !important;
            width: 222px;
            margin-left: 8px !important;
            max-width: 126% !important;
        }

        .avatar {
            width: 60px !important;
        }

        nav.navbar.col-lg-12.col-12.p-0.fixed-top.d-flex.flex-row {
            box-shadow: 0px 5px 21px -5px #CDD1E1;
        }

        body {
            -moz-transform: scale(0.5, 0.5); /* Moz-browsers */
            zoom: 0.5; /* Other non-webkit browsers */
            zoom: 90%; /* Webkit browsers */
            zoom: 90%; /* Webkit browsers */
        }
    </style>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        } ``

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ul>
        <li class="tab-content tab-content-3 typography">
            <div class="card-body" id="divGeneratingSet" runat="server" style="margin-top: -30px;">
                <div class="card-body" style="margin-top: -30px;">
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-sm-4" style="text-align: center;">
                            <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                Data Updated Successfully !!!.
                            </label>
                            <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                Data Saved Successfully !!!.
                            </label>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-2" id="Div170" runat="server" style="margin-top: -15px;">
                                    <label for="Name">
                                        Capacity
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCapacity" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="KVA" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="MVA" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="ddlCapacity" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Capacity "></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-2" id="Div171" runat="server" style="margin-top: -15px;">
                                    <label for="Name">
                                        Value
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCapacity" AutoPostBack="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" autocomplete="off"
                                        placeholder="" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvfCapacity" runat="server" ForeColor="Red" ControlToValidate="txtCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Capacity"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-2" runat="server" style="margin-top: -15px;">
                                    <label for="Name">
                                        Serial no. 
                                    <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtSerialNoOfGenerator" placeholder="of Ac generator/ Alternator" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtSerialNoOfGenerator" ValidationGroup="Submit" ErrorMessage="Please Enter Serial No Of Generator"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-2" id="Div172" runat="server" style="margin-top: -15px;">
                                    <label for="Name">
                                        Type of Generating Set
                                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGeneratingSetType_SelectedIndexChanged" ID="ddlGeneratingSetType" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Diesel Engine" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Gas Engine" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Solar Panel" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Bio Fuel" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingSetType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Generator Set Type"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Generator voltage level(IN VOLTS)
                                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtGeneratorVoltage" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="5" placeholder="" AutoPostBack="true" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtGeneratorVoltage" ValidationGroup="Submit" ErrorMessage="Please Enter Generator Voltage"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Current capacity of breaker( IN AMPS)
                                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCurrentCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtCurrentCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Current Capacity Of Breaker"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Breaking capacity of breaker (IN KA)
                                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtBreakingCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtBreakingCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Breaking Capacity"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Number of Earthing:
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGeneratingEarthing_SelectedIndexChanged" ID="ddlGeneratingEarthing" selectionmode="Multiple" Style="width: 100% !important">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select No Of Earthing"></asp:RequiredFieldValidator>
                                    <label id="Limit" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Minimum Limit is 4     
                                    </label>
                                </div>
                            </div>
                            <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="false">
                                <table class="table table-bordered table-striped">
                                    <thead class="table-dark">
                                        <tr>
                                            <th>S.No.
                                            </th>
                                            <th>Earthing Type
                                            </th>
                                            <th>Value in(ohms)
                                            </th>
                                            <th>Used For
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <div id="GeneratingEarthing4" runat="server" visible="false">
                                            <tr>
                                                <td>1</td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing1" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing1" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing1" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing1" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed1_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed1" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed1" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtOtherEarthing1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing1" ValidationGroup="Submit" ErrorMessage="Please Enter Other earthing"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing2" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing2" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing2" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed2_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed2" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed2" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtOtherEarthing2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing2" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing3" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing3" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing3" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed3_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed3" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed3" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtOtherEarthing3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing3" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>
                                                    <div class="col-12" id="Div9" runat="server">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing4" selectionmode="Multiple" Style="width: 100% !important">

                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing4" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12" id="Div10" runat="server">
                                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing4" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed4_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed4" selectionmode="Multiple" Style="width: 100% !important">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed4" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-12">
                                                        <asp:TextBox class="form-control" ID="txtOtherEarthing4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing4" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                        </div>
                                        <tr id="GeneratingEarthing5" runat="server" visible="false">
                                            <td>5 </td>
                                            <td>
                                                <div class="col-12" id="Div12" runat="server">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing5" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing5" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing5" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed5_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed5" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed5" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing5" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing6" runat="server" visible="false">
                                            <td>6</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing6" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing6" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing6" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed6_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed6" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed6" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing6" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing7" runat="server" visible="false">
                                            <td>7</td>
                                            <td>
                                                <div class="col-12" id="Div13" runat="server">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing7" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing7" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing7" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing7" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed7_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed7" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed7" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing7" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing8" runat="server" visible="false">
                                            <td>8</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing8" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing8" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing8" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing8" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed8_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed8" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed8" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing8" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing9" runat="server" visible="false">
                                            <td>9</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing9" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing9" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing9" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing9" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed9_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed9" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed9" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing9" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing10" runat="server" visible="false">
                                            <td>10</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing10" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing10" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing10" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing10" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed10_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed10" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed10" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing10" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing11" runat="server" visible="false">
                                            <td>11</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing11" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing11" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing11" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing11" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed11_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed11" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed11" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing11" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing12" runat="server" visible="false">
                                            <td>12</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing12" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing12" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing12" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing12" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed12_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed12" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed12" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing12" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing13" runat="server" visible="false">
                                            <td>13</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing13" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing13" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing13" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing13" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed13_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed13" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed13" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing13" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing14" runat="server" visible="false">
                                            <td>14</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing14" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing14" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing14" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing14" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed14_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed14" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed14" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing14" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="GeneratingEarthing15" runat="server" visible="false">
                                            <td>15</td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing15" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing15" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtGeneratingEarthing15" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing15" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed15_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed15" selectionmode="Multiple" Style="width: 100% !important">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed15" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtOtherEarthing15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing15" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="SolarPanelGeneratingSet" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Type of plant<samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlPlantType" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Ground Mounted" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Roof top" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="ddlPlantType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Plant Type"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2" style="margin-top: -15px;">
                                        <label for="Name">
                                            capacity of plant
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlPlantCapacity" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="KW" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="MW" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ForeColor="Red" ControlToValidate="ddlPlantCapacity" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Plant Type"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2" style="margin-top: -15px;">
                                        <label for="Name">
                                            capacity of plant      
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPlantCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtPlantCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Plant capacity"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2" id="Div184" runat="server" style="margin-top: -15px;">
                                        <label for="Name">
                                            DC string       
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDCString" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="2" placeholder=" Highest Voltage" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txtDCString" ValidationGroup="Submit" ErrorMessage="Please Enter Dc String"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-2" id="Div185" runat="server" style="margin-top: -15px;">
                                        <label for="Name" style="text-align: initial; font-size: 12px;">
                                            Lowest Insulation Resistance        
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLowestInsulation" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="4" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txtLowestInsulation" ValidationGroup="Submit" ErrorMessage="Please Enter Lowest Insulation"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" id="Div186" runat="server">
                                        <label for="Name">
                                            No of PCU or Solar Inverter        
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPCVOrSolar" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txtPCVOrSolar" ValidationGroup="Submit" ErrorMessage="Please Enter Pvc"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" id="Div187" runat="server">
                                        <label for="Name">
                                            capacity of main LTAC Breaker        
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLTACCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" MaxLength="4" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ControlToValidate="txtLTACCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter LTAC Capacity"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" id="Div188" runat="server">
                                        <label for="Name">
                                            Lowest Insulation resistance of AC cables       
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLowestInsulationAC" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="4" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ControlToValidate="txtLowestInsulationAC" ValidationGroup="Submit" ErrorMessage="Please Enter Lowest Insulation Resistance of Ac"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 100px;" id="Declaration" runat="server" visible="false">
                                <%--  <div class="col-2"></div>--%>
                                <div class="col-12" style="text-align: center;">
                                    <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="true" Text="&nbsp;I hereby declare that all information submitted as part of the form is true to my knowledge." Font-Size="Medium" Font-Bold="True" />
                                    <br />
                                    <label id="label2" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Please Verify this.
                                    </label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row" id="OTP" runat="server" visible="false">
                        <div class="col-4"></div>
                        <div class="col-4">
                            <label>
                                Enter the OTP you received to Your Phone Number
                                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOTP" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator76" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                        </div>

                        <div class="col-12" style="text-align: center;">
                            <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />
                            <asp:Button ID="btnVerify" Text="Verify Details" Visible="false" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnVerify_Click" />
                            <asp:Button ID="BtnSubmitGeneratingSet" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                                OnClick="BtnSubmitGeneratingSet_Click" />
                        </div>
                        <div class="col-4">
                            <asp:HiddenField ID="hdn" Value="0" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </li>
    </ul>

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

    <script>
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
    </script>
      <script type="text/javascript">
          function alertWithRedirect() {
              if (confirm('Test report has been submitted and is under review by the Contractor for final submission')) {
                  window.location.href = "/Supervisor/IntimationData.aspx";
              } else {
              }
          }
      </script>
</asp:Content>
