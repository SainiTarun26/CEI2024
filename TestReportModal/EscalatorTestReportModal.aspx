<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscalatorTestReportModal.aspx.cs" Inherits="CEIHaryana.TestReportModal.EscalatorTestReportModal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 8px solid #ced4da !important;
            border-bottom-left-radius: 15px;
            border-bottom-right-radius: 15px;
            border-top-left-radius: 15px;
            border-top-right-radius: 15px;
        }

        ul {
            font-size: 0px;
        }

        li.tab-content.tab-content-3.typography {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 8px solid #CED4DA;
            border-top: 0;
            padding: 2rem 1rem;
            text-align: justify;
            border-bottom-left-radius: 15px;
            border-bottom-right-radius: 15px;
            border-top-left-radius: 15px;
            border-top-right-radius: 15px;
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

        .card .card-title {
            font-size: 22px !important;
            font-weight: 700;
            margin-bottom: -10px;
        }

        div#intimation-card {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            margin-left: -25px;
            margin-right: -25px;
            margin-top: 5px;
            padding: 15px;
        }

        div#inspection-card {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            margin-left: -25px;
            margin-right: -25px;
            margin-top: 20px;
            padding: 15px;
            padding-bottom: 45px;
        }

        div#IntimationData {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            margin-left: -25px;
            margin-right: -25px;
            margin-top: 20px;
            padding: 15px;
            padding-bottom: 45px;
        }

        div#SubmitDetails {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            margin-left: -25px;
            margin-right: -25px;
            margin-top: 20px;
            padding: 15px;
        }

        .row {
            margin-bottom: 30px !important;
            margin-top: -10px !important;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('You did not add any Email Please Contact Admin For Update your Email')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }

        function openNewWindow() {
            var newWindow = window.open('../SiteOwnerPages/PrintEscalatorTestReportModal.aspx', '_blank');
            newWindow.focus();
            console.log(newWindow);
        }
    </script>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul style="margin: 40px 20px 20px 15px!important;">
                <li class="tab-content tab-content-3 typography">
                   <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
    <asp:Button ID="btnBack" Text="Back" Enabled="true" runat="server" class="btn btn-primary mr-2" OnClick="btnback_Click"
        Style="margin-top: -45px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; left: 10px; z-index: 50;"  />
    
    <asp:Button ID="btnPrint" Text="Print" Enabled="true" runat="server" class="btn btn-primary mr-2"
        Style="margin-top: -45px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; right: 10px; z-index: 50;" OnClientClick="openNewWindow(); return false;" />
</div>
                    <div class="row" style="margin-bottom: 15PX;">
                        <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Site Details & Test Details (Escalator)</h6>
                            <div class="row" style="font-size: 18px; font-weight: 600;">
                                <div class="col-12" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                    TestDetailId: (<asp:Label ID="lbltestReportId" runat="server" />) &nbsp;&nbsp;&nbsp;&nbsp;  Intimation Id: (<asp:Label ID="lblWorkIntimationId" runat="server" />)
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="card-body" id="divGeneratingSet" runat="server" style="margin-top: -30px; margin-bottom: -60px;">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="card-body" style="margin-top: -30px;">
                            <div class="card" id="IntimationData" runat="server" visible="true" style="background: #fcfcfc;">
                                <div class="card-title" style="margin-bottom: 1px;">Site Owner Information</div>
                                <div>
                                    <div class="row row-modal">
                                        <div class="col-md-3">
                                            <label>
                                                Applicant Type
             
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="ddlApplicantType" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>

                                        <%--<div class="col-md-3" runat="server" id="DivPancard_TanNo" visible="true">
        <label for="PanNumber">
            PAN Card
         
        </label>
        <asp:TextBox ReadOnly="true" class="form-control" ID="txtPAN" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revPAN" runat="server" ControlToValidate="txtPAN" ValidationExpression="[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}" ValidationGroup="Submit"
            ErrorMessage="Enter a valid PAN number" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPAN" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3" runat="server" id="DivOtherDepartment" visible="true">
        <label for="TanNumber">
            TAN Number
         
        </label>
        <asp:TextBox ReadOnly="true" class="form-control" ID="txtTanNumber" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTANNumber" runat="server" ControlToValidate="txtTanNumber" ValidationExpression="[A-Za-z]{4}[0-9]{5}[A-Za-z]" ValidationGroup="Submit"
            ErrorMessage="Enter a valid TAN number" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtTanNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
    </div>--%>

                                        <div class="col-md-3">
                                            <label>
                                                Electrical Installation For<samp style="color: red"> * </samp>
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtInstallationFor" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-md-3" id="individual" runat="server">
                                            <label for="Name">
                                                Name of Owner/ Consumer<samp style="color: red"> * </samp>
                                            </label>
                                            <div class="input-box" style="padding-left: 0px !important;">
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtName" TabIndex="4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return alphabetKey(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="margin-left: 18px; box-shadow: none !important;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3" id="agency" runat="server">
                                            <label for="agency">
                                                Name of Firm/ Org./ Company/ Department
      
                                            </label>
                                            <div class="input-box">
                                                <span class="prefix">M/s.</span>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                                                <%-- <asp:TextBox ReadOnly="true" class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            </div>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtagency"
         ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-md-8">
                                            <label for="Address">
                                                Address of Site(Preferred As Per Demand Notice of Utility or Electricity Bill)
          
                                            </label>
                                            <%-- <asp:TextBox ReadOnly="true" class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>

                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">State</label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtState" MaxLength="6" Text="Haryana" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                District
            
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDistrict" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">PinCode</label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPin" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblPinError" style="color: red"></span>
                                        </div>
                                        <div class="col-md-4">
                                            <label for="Phone">
                                                Contact Number (Site Owner)
         
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPhone" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblErrorContect" style="color: red"></span>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Email">
                                                Email
             
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtEmail" TabIndex="9" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblError" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" runat="server" visible="false">
                                <div class="card-title"  runat="server" visible="false" style="margin-bottom: 1px;">Application Details</div>
                                <div class="row" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <div class="table-responsive pt-3" id="Installation" runat="server">
                                            <table class="table table-bordered table-striped">
                                                <thead class="table-dark">
                                                    <tr>
                                                        <th style="width: 70%;">Installation Type
                                                        </th>
                                                        <th style="width: 20%;">No of Installations
                                                        </th>
                                                        <th style="width: 10%;"></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <div id="installationType1" runat="server">
                                                        <tr>
                                                            <td>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType1" Text="Escalator" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-md-12">

                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo1" TabIndex="13" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    <%--  <p style="color:red; margin-bottom: 0px; margin-top: -12px; font-weight: 600;
                                            font-size: 12px;">Max no. of Installations is only 25.</p>--%>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:ImageButton ID="imgDelete1" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30"
                                                                    runat="server" />
                                                            </td>
                                                        </tr>
                                                    </div>
                                                    <div id="installationType2" runat="server">
                                                        <tr>
                                                            <td>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType2" Text="Escalator" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo2" TabIndex="14" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:ImageButton ID="imgDelete2" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </div>

                                                    <%--    <div id="installationType4" runat="server" visible="False">
                        <tr>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtinstallationNo4" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnDelete4" Text="DELETE" CssClass="submit" OnClick="btnDelete4_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="installationType5" runat="server" visible="False">
                        <tr>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo5" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtinstallationNo5" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnDelete5" Text="DELETE" CssClass="submit" OnClick="btnDelete5_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="installationType6" runat="server" visible="False">
                        <tr>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtinstallationNo6" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnDelete6" Text="DELETE" CssClass="submit" OnClick="btnDelete6_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="installationType7" runat="server" visible="False">
                        <tr>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo7" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstallationNo7" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnDelete7" Text="DELETE" CssClass="submit" OnClick="btnDelete7_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="installationType8" runat="server" visible="False">
                        <tr>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-md-12">
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtinstallationNo8" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnDelete8" Text="DELETE" CssClass="submit" OnClick="btnDelete8_Click" />
                            </td>
                        </tr>
                    </div>--%>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <%--<div>
                               <div class="col-4">
                               <label for="Name">  Reason For Rejection   </label>
                               <asp:TextBox ReadOnly="true" class="form-control" ReadOnly="true" ID="TextReason" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                               </div></div>--%>
                                <div id="SolarPanelGeneratingSet" runat="server" visible="false">
                                    <div class="row">
                                        <%-- <div class="col-4">
                                            <label for="Name">
                                                Type of plant  </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ReadOnly="true" ID="txtPlantType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                       </div>--%>
                                        <div class="col-2" style="margin-top: -15px;" id="unitofplant" runat="server" visible="false">
                                            <label for="Name">
                                                capacity of plant
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPlantCapacityType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-2" style="margin-top: -15px;" id="capacityofplant" runat="server" visible="false">
                                            <label for="Name">
                                                capacity of plant      
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPlantCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-2" id="Div184" runat="server" style="margin-top: -15px;">
                                            <label for="Name">
                                                DC string       
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDCString" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" Highest Voltage" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-2" id="Div185" runat="server" style="margin-top: -15px;">
                                            <label for="Name" style="text-align: initial; font-size: 12px;">
                                                Lowest Insulation Resistance        
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtLowestInsulation" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div186" runat="server">
                                            <label for="Name">
                                                No of PCU or Solar Inverter        
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPCVOrSolar" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div187" runat="server">
                                            <label for="Name">
                                                capacity of main LTAC Breaker        
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtLTACCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div188" runat="server">
                                            <label for="Name">
                                                Lowest Insulation resistance of AC cables       
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtLowestInsulationAC" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <%--<div class="row" runat="server" id="Contractor3" visible="false">
                                <div class="col-4"></div>
                                <div class="col-4" style="margin-top: 40px; text-align: Center;">
                                    <asp:Button ID="btnVerify" Text="SendOTP" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                                        OnClick="btnVerify_Click" />
                                    <br />
                                    <label>Submit Will be Enable When You Verify Your Details</label>
                                </div>
                            </div>--%>
                            <div class="card" style="background: #fcfcfc; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-left: -25px; margin-right: -25px; margin-top: 20px; padding: 15px; padding-bottom: 45px;">
                                <div class="card-title" style="margin-bottom: 1px;">Installation Details</div>

                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <div>
                                        <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Local Agent Details</h8>
                                        <div class="row" id="LocalAgents" runat="server" style="margin-top: 10px;">
                                            <%--<div class="col-md-3">
                                        <label>
                                            Name and Address of Local Agent
         
                                        </label>
                                        <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="0" style="margin-top: auto; margin-bottom: auto;"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>--%>
                                            <div class="col-md-4" id="Name" runat="server" visible="True" style="top: 0px !important;">
                                                <label for="Voltage">
                                                    Name of Local Agent
                                             
                                                </label>
                                                <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" ID="TxtAgentName" MaxLength="50" onKeyPress="return alphabetKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <%--<asp:RangeValidator ID="rangevalidator" runat="server" ControlToValidate="TxtOthervoltage" MinimumValue="200" MaximumValue="400000" Type="Integer" ForeColor="Red" ErrorMessage="Voltage between 200 to 400000" ></asp:RangeValidator>--%>
                                            </div>
                                            <div class="col-md-4" id="Address" runat="server">
                                                <label for="Name">
                                                    Address of Local Agent 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtAgentAddress" onKeyPress="return alphabetKey(event)" onkeydown="return preventEnterSubmit(event)" MaxLength="250" placeholder="" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAgentAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Local Agent Address</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" runat="server" id="Contact">
                                                <label for="Name">
                                                    Contact No. of Local Agent 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtAgentPhone" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="10" placeholder="" autocomplete="off" TabIndex="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Escalator Details</h8>
                                        <div class="row" style="margin-top: 10px;">
                                                    <div class="col-md-4" runat="server" visible="True" style="top: 0px !important;">
            <label for="Voltage">
                Make of Escalator
 
            </label>
            <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" ID="txtMake" MaxLength="10" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
            <%--<asp:RangeValidator ID="rangevalidator" runat="server" ControlToValidate="TxtOthervoltage" MinimumValue="200" MaximumValue="400000" Type="Integer" ForeColor="Red" ErrorMessage="Voltage between 200 to 400000" ></asp:RangeValidator>--%>
        </div>
                                                                                                <div class="col-md-4" runat="server" visible="True" style="top: 0px !important;">
            <label for="Voltage">
                Serial No. of Escalator
 
            </label>
            <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" ID="txtSerialNo" MaxLength="10" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
            <%--<asp:RangeValidator ID="rangevalidator" runat="server" ControlToValidate="TxtOthervoltage" MinimumValue="200" MaximumValue="400000" Type="Integer" ForeColor="Red" ErrorMessage="Voltage between 200 to 400000" ></asp:RangeValidator>--%>
        </div>
                                            <div class="col-md-4" runat="server" visible="True" style="top: 0px !important;">
                                                <label for="Voltage">
                                                    Date of Erection
                                     
                                                </label>
                                                <asp:TextBox ReadOnly="true" class="form-control" Type="Date" AutoPostBack="true" ID="txtErectionDate" MaxLength="10" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <%--<asp:RangeValidator ID="rangevalidator" runat="server" ControlToValidate="TxtOthervoltage" MinimumValue="200" MaximumValue="400000" Type="Integer" ForeColor="Red" ErrorMessage="Voltage between 200 to 400000" ></asp:RangeValidator>--%>
                                            </div>
                                            <div class="col-md-4">
                                                <label>
                                                    Type of Escalator Erected
         
                                                </label>
                                                <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" ID="txtEscalatorType" MaxLength="10" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Contract Speed of Escalator (Mtr./sec) 
                                                </label>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorSpeedContract"
                                                    onKeyPress="return allowNumbersAndSlash(event);"
                                                    onkeydown="return preventEnterSubmit(event)"
                                                    MaxLength="6" placeholder="" autocomplete="off"
                                                    TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Contract Load of Escalator (in Kg) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorLoad" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="5" placeholder="" autocomplete="off" TabIndex="8" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Max Person Capacity (with Escalator Operator) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtMaxPersonCapacity" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="9" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Weight of Escalator Car with Contact Load (in kg)
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtWeight" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="6" placeholder="" autocomplete="off" TabIndex="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Weight of Counter Weight (in kg) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtCounterWeight" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="6" placeholder="" autocomplete="off" TabIndex="11" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Depth of Pit (in mm) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtPitDepth" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="6" placeholder="" autocomplete="off" TabIndex="12" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Travel Distance of Escalator (in mtr) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtTravelDistance" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="13" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    No. of Floors Served (in mtr) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtFloorsServed" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="5" placeholder="" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" runat="server">
                                                <label for="Name">
                                                    Total Head Room (in mm) 
                                                </label>
                                                <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtTotalHeadRoom" onKeyPress="return isNumberdecimalKey(event, this);" onkeydown="return preventEnterSubmit(event)" MaxLength="6" placeholder="" autocomplete="off" TabIndex="15" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                      
                                       
                                       
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 10px; margin-bottom: 0px !important;">
                                    <div class="col-md-12" style="text-align: left;">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Machine Main Breaker Details</h7>
                                    </div>
                                </div>
                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Main Breaker</h8>
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Make 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtMakeMainBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="21" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Type 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTypeMainBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="22" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                Poles
                         
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox4" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="22" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Current Rating (in Amps) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtratingMainBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="24" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Breaking Capacity (in KA) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtCapacityMainBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="25" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">RCCB</h8>
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Make 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtMakeRCCBMainBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="26" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                Poles   
                         
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox5" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="26" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Current Rating (in Amps) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRatingRCCBMainBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="28" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Fault Current Rating (in MA) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtfaultratingRCCBMainBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="29" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row" style="margin-top: 10px; margin-bottom: 0px !important;">
                                    <div class="col-md-12" style="text-align: left;">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Lighting Load Breaker Details</h7>
                                    </div>
                                </div>
                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Main Breaker</h8>
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Make 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtMakeLoadBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="30" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Type 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTypeLoadBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="31" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                Poles
                         
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox6" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="31" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Current Rating (in Amps) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRatingLoadBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="33" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Breaking Capacity (in KA) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtCapacityLoadBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="34" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">RCCB</h8>
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Make 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtMakeRCCBLoadBreaker" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="35" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                Poles
                         
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox7" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="31" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Current Rating (in Amps) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRatingRCCBLoadBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="37" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Fault Current Rating 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtFaultCurrentRCCBLoadBreaker" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="38" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row" style="margin-top: 10px; margin-bottom: 0px !important;">
                                    <div class="col-md-12" style="text-align: left;">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Insulation Resistance</h7>
                                    </div>
                                </div>
                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                For Whole Installation 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtwholeInstallation" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="39" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" id="TPN1" runat="server" visible="false">
    <label for="Name">
        Neutral and Phase (ohms)<samp style="color: red">* </samp>
    </label>
    <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
    <asp:TextBox class="form-control" ID="txtNeutralPhase" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="41" runat="server" Style="margin-left: 18px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtNeutralPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Installation</asp:RequiredFieldValidator>
</div>
<div class="col-md-4" id="TPN2" runat="server" visible="false">
    <label for="Name">
        Earth and Phase (mohms)<samp style="color: red">* </samp>
    </label>
    <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
    <asp:TextBox class="form-control" ID="txtEarthPhase" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="42" runat="server" Style="margin-left: 18px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txtEarthPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Installation</asp:RequiredFieldValidator>
</div>
                                    </div>

                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Between Phases</h8>
                                    <div class="row" id="InDPO1" runat="server" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Red Phase – Yellow Phase(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRedYellow" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="40" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Red Phase – Blue Phase(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRedBlue" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="41" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Yellow Phase – Blue Phase(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtYellowBlue" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="42" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h8 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Between Each Phase and Earth</h8>
                                    <div class="row" id="InDPO2" runat="server" style="margin-top: 10px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Red Phase – Earth Wire(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRedEarth" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Yellow Phase – Earth Wire(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtYellowEarth" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Name">
                                                Blue Phase – Earth Wire(in Mohms) 
                                            </label>
                                            <%--<asp:TextBox ReadOnly="true" class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtBlueEarth" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="45" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="card" style="background: #fcfcfc; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-left: -25px; margin-right: -25px; margin-top: 20px; padding: 15px; padding-bottom: 45px;">
                                <div class="card-title" style="margin-bottom: 1px;">Earthing Details</div>
                                <div class="col-4" id="Div189" runat="server">
                                    <label for="Name">
                                        Number of Earthing
                                    </label>
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthing" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <label id="Limit" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Minimum Limit is 4     
                                    </label>
                                </div>
                                <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="false">
                                    <table class="table table-bordered table-striped">
    <thead class="table-dark">
        <tr>
            <th>S.No.</th>
            <th>Earthing Type</th>
            <th>Value in(ohms)</th>
        </tr>
    </thead>
    <tbody>

        <tr id="EscalatorEarthing1" runat="server" visible="false">
            <td>1</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing2" runat="server" visible="false">
            <td>2</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing3" runat="server" visible="false">
            <td>3</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing4" runat="server" visible="false">
            <td>4</td>
            <td>
                <div class="col-12" id="Div9" runat="server">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12" id="Div10" runat="server">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>

        <tr id="EscalatorEarthing5" runat="server" visible="false">
            <td>5</td>
            <td>
                <div class="col-12" id="Div12" runat="server">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing6" runat="server" visible="false">
            <td>6</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing7" runat="server" visible="false">
            <td>7</td>
            <td>
                <div class="col-12" id="Div13" runat="server">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing8" runat="server" visible="false">
            <td>8</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <asp:Label ID="Label1" runat="server" Visible="false" />
        <tr id="EscalatorEarthing9" runat="server" visible="false">
            <td>9</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing10" runat="server" visible="false">
            <td>10</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing11" runat="server" visible="false">
            <td>11</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing12" runat="server" visible="false">
            <td>12</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther12" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing13" runat="server" visible="false">
            <td>13</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther13" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing14" runat="server" visible="false">
            <td>14</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther14" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr id="EscalatorEarthing15" runat="server" visible="false">
            <td>15</td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-12">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther15" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </td>
        </tr>
    </tbody>
</table>
                                </div>
                            </div>



                            <div class="card" style="background: #fcfcfc; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-left: -25px; margin-right: -25px; margin-top: 20px; padding: 15px; padding-bottom: 45px;">
                                <div class="card-title" style="margin-bottom: 1px;">Supervisor/Contractor Details</div>
                                <div class="row">
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            Contractor Name 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtContName" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            Contractor License No. 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtLicenseNo" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            License Expiry Date 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtContExp" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            Supervisor Name 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtSupName" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            Supervisor License No. 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtSupLicenseNo" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4" runat="server">
                                        <label for="Name">
                                            License Expiry Date 
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtSupExpiryDate" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="43" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; margin-left: -25px; margin-right: -25px;">
    <div class="card-title" style="margin-bottom: 1px; font-size: 22px; font-weight: 700; margin-bottom: 20px;">
        Document Details
    </div>
    <div class="row">
        <div class="col-12">
            <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  OnRowCommand="Grd_Document_RowCommand"  runat="server" AutoGenerateColumns="false">--%>
                <PagerStyle CssClass="pagination-ys" />
                <Columns>


                    <asp:TemplateField HeaderText="SNo">
                        <HeaderStyle Width="5%" CssClass="headercolor" />
                        <ItemStyle Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="SNo" HeaderText="SNo" />--%>
                    <%--  <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />--%>
                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                        <HeaderStyle HorizontalAlign="Left" Width="85%" CssClass="headercolor leftalign" />
                        <ItemStyle HorizontalAlign="Left" Width="85%" />
                    </asp:BoundField>

                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDocumentPath" runat="server" Text="View Document" CommandName="View" CommandArgument='<%# Eval("DocumentPath") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
        </div>
    </form>
</body>
</html>
