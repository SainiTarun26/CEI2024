<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="ViewLiftPeriodicReport.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.ViewLiftPeriodicReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        .modal .modal-dialog {
            margin-top: 100px;
            margin-left: 23%;
        }

        .modal {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            justify-content: center;
            align-items: center;
            z-index: 1050;
        }

        .modal-dialog {
            background: #fff;
            border-radius: 5px;
            padding: 20px;
            max-width: 70%;
            width: 100%;
        }

        input#ContentPlaceHolder1_customFile {
            padding: 0px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 10px;
            background: left 3px top 5px no-repeat #563d7c;
        }

            .submit:hover {
                border: 1px solid #563d7c;
                border-radius: 5px;
                color: white;
                padding: 5px 10px 5px 10px;
                background: left 3px top 5px no-repeat #26005f;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
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

        select.form-control.select-form.select2 {
            height: 30px !important;
            padding: 2px 0px 5px 10px;
        }

        ul.chosen-choices {
            border-radius: 5px;
        }

        input#customFile {
            padding: 0px 0px 0px 0px;
        }

        input#ContentPlaceHolder1_txtName {
            font-size: 12.5px !important;
        }

        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        .card {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: white; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 5px; font-size: 22px; font-weight: 600; margin-left: -10px; margin-bottom: 15px; text-align: center;">
                Lift/Escalator Renewal
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Installation Details
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>
                            Installation Type
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtInstallationType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="card-title" id="divInspectiondetailsLabel" runat="server" visible="true" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Inspection Detail
            </div>
            <div class="card" id="divInspectiondetails" runat="server" visible="true" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            Registration No.
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtRegistrationNo" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Previous Challan Date
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtPrevChallanDate" autocomplete="off" runat="server" Style="margin-left: 18px; width: 100% !important;"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label" for="customFile">
                            Upload Previous Challan<samp style="color: red">* </samp>
                        </label>
                        <br />
                        <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" OnClick="lnkFile_Click" Visible="true" Text="Open Document" />

                    </div>
                </div>
            </div>
            <div class="card-title" id="divLiftDetails" runat="server" visible="false" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Lift Details
            </div>
            <div class="card-title" id="divEscalatorDetails" runat="server" visible="True" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Escalator Details
            </div>
            <div class="card" id="divdetails" runat="server" visible="true" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>
                            Make
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtMake" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Serial No.
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtSerialNo" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label id="lblTypeOfLift" runat="server">
                            Type of Lift
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtLiftType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Type of Control
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtControlType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Capacity/Weight
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtCapacityWeight" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            District
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtDistrict" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                    <div class="col-md-12" runat="server">
                        <label>
                            Site Address
                        </label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtSiteAddress" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="divLabelLiftAttachments" runat="server" visible="true" class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Attachments
            </div>
            <div class="card" id="divLiftAttachments" runat="server" visible="true" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <%-- Add Grid Here --%>
                <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <HeaderStyle Width="1%" CssClass="headercolor" />
                            <ItemStyle Width="1%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DocumentID" HeaderText="Document ID" Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                            <ItemStyle HorizontalAlign="center" Width="12%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">View Document </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
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
            <div class="row" style="margin-top: 25px;">
                <div class="col-12" style="text-align: center; padding-left: 0px;">
                    <asp:Button ID="btnBack" OnClick="btnBack_Click" Style="padding-left: 35px; padding-right: 35px;" Text="Back" runat="server" class="btn btn-primary mr-2" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
