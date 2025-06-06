<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="ActionForDsc.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.ActionForDsc" %>
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
        input#ContentPlaceHolder1_btnBack {
    padding-left: 20px;
    padding-right: 20px;
}
        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
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

        .col-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 14px;
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

        .headercolor {
            background-color: #9292cc;
            color:white;
        }


        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 17px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
            margin-bottom: 0px;
            margin-top: 30px;
        }

        div#row3 {
            margin-top: -20px;
        }

        svg#svgcross {
            height: 35px;
            width: 67px;
        }

        svg#svgcross1 {
            height: 35px;
            width: 67px;
        }

        svg#svgcross2 {
            height: 35px;
            width: 67px;
        }

        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        th.headercolor {
            width: 28% !important;
        }


        th {
            width: 1%;
        }


            th.headersizeSignature {
                width: 40% !important;
            }


        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }

        .row {
            margin-bottom: 15px;
        }

        input#ContentPlaceHolder1_txtSearch {
            font-size: 13px !important;
        }
        th.headercolor.thwidth {
    width: 1% !important;
}
        th.headercolor.textalign {
    text-align: center;
}
    </style>
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
    <script type="text/javascript">
        function preventEnterSubmit(e) {

            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>
   
    <script type="text/javascript">
        function validateAlphanumeric(event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            // Allow alphabets (A-Z, a-z), space, all special characters, and control keys
            if ((charCode >= 65 && charCode <= 90) || // Uppercase (A-Z)
                (charCode >= 97 && charCode <= 122) || // Lowercase (a-z)
                (charCode == 32) || // Space
                (charCode == 8 || charCode == 37 || charCode == 39 || charCode == 46) || // Backspace, Arrow keys, Delete
                (charCode >= 33 && charCode <= 47) || // Special characters like ! " # $ % & ' ( ) * + , - . /
                (charCode >= 58 && charCode <= 64) || // Special characters like : ; < = > ? @
                (charCode >= 91 && charCode <= 96) || // Special characters like [ \ ] ^ _
                (charCode >= 123 && charCode <= 126)) // Special characters like { | } ~
            {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold" style="font-size: 20px !important;" id="maincard">Notice for Disconnection</h7>
                    </div>
                </div>
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
                  
                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold" style="margin-top: 0px !important;">
                            <asp:Label ID="Label4" runat="server"></asp:Label>Utility Details</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">

                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Power Utility
                       
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtUtility" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                        </div>
                        <div class="col-md-4">
                            <label>
                                Wing
                      
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtWing" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                           
                        </div>
                        <div class="col-md-4">
                            <label>
                                Zone 
                                
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtZone" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-4">
                            <label>
                                Circle
                          
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtCircle" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                           
                        </div>
                        <div class="col-md-4">
                            <label for="Division">
                                Division Name
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDivision" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            

                        </div>
                        <div class="col-md-4">
                            <label>
                                Sub-Division
    
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtSubDivision" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                          
                        </div>

                    </div>

               

                
                </div>

                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label1" runat="server"></asp:Label>Details of Person/Firm for Disconnection</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">

                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Firm/Person Name
 
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtName" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                          
                        </div>
                        <div class="col-md-4">
                            <label>
                                PAN Card
  
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPanNo" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                       
                        </div>
                        <div class="col-md-4">
                            <label>
                                Consumer Account No. 
            
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAccNo" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                        
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Contact No.
   
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="TxtContactNo" runat="server" autocomplete="off"  TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                           
                        </div>
                        <div class="col-md-4">
                            <label>
                                Category of Consumer
 
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtCategory" runat="server" autocomplete="off" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            
                        </div>
                        <div class="col-md-4" id="OtherCat" runat="server" visible="false">
                            <label>
                                Other
            
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtOtherCategory" runat="server" autocomplete="off" 
                                TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            
                        </div>
                        <div class="col-md-4">
                            <label>
                                Sanction Load (in Kva)
         
                            </label>
                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtSanctionLoad" runat="server" autocomplete="off" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label2" runat="server"></asp:Label>Attachments</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                       <asp:GridView ID="grd_Documemnts" OnRowCommand="grd_Documemnts_RowCommand" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
       <HeaderStyle BackColor="#B7E2F0" />
       <Columns>
           <asp:TemplateField HeaderText="SNo">
               <HeaderStyle CssClass="headercolor thwidth" />
               <ItemStyle />
               <ItemTemplate>
                   <%#Container.DataItemIndex+1 %>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
               <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
               <ItemStyle HorizontalAlign="Left" />
           </asp:BoundField>

           <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
               <ItemTemplate>
                   <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("Document_Path") %>' CommandName="Select">View Document </asp:LinkButton>
               </ItemTemplate>
               <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
               <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalign" />
           </asp:TemplateField>
       </Columns>
       <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
   </asp:GridView>
                </div>
                             <%-- </ContentTemplate>
</asp:UpdatePanel>--%>
               <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label3" runat="server"></asp:Label>Disconnection Approval</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">
                     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>--%>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Select Action
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" CssClass="form-control select-form select2" Style="width: 100% !important;" TabIndex="2">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Please Select  any Action to proceed" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAction" runat="server" InitialValue="Select" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <%-- </ContentTemplate></asp:UpdatePanel>--%>
                    <div class="row">
                            <div class="col-md-4">
        <label>
            Action Taken Report
<samp style="color: red">* </samp>
        </label>
        <asp:FileUpload ID="FileReport" runat="server" CssClass="form-control"
            Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
            ControlToValidate="FileReport" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

    </div>
   <div class="col-md-4">
       <label>
           Any Other Document
   
       </label>
       <asp:FileUpload ID="FileOther" runat="server" CssClass="form-control"
           Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
   </div>
                    </div>
                    <div class="row" style="margin-bottom: 0px !important;" id="Suggestion" runat="server" visible="false">
                        <div class="col-md-12">
                            <label>
                                Suggestion/Note
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox ID="txtSuggestion" runat="server" TextMode="MultiLine" Rows="2" ReadOnly="false" CssClass="form-control" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1" MaxLength="200" Style="margin-left: 18px;"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSuggestion" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Suggestion or note</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>
                                Remarks
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="2" ReadOnly="false" CssClass="form-control" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1" MaxLength="200" Style="margin-left: 18px;"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Remarks</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 30px !important;">
                    <div class="col-md-6" style="text-align: end;">
                        <asp:Button ID="btnBack" runat="server" Class="btn btn-primary" Text="Back" OnClick="btnBack_Click"  />
                                            </div>
                    <div class="col-md-6" style="text-align: justify;">
    <asp:Button ID="btnSubmit" runat="server" Class="btn btn-primary" Text="Submit" ValidationGroup="Submit" OnClick="btnSubmit_Click" />
</div>
                </div>
              
                
                <asp:HiddenField ID="hdnOwnerId" runat="server" />
                <asp:HiddenField ID="hdnDisId" runat="server" />
                <div>
                </div>
            </div>
        </div>

        <footer class="footer">
        </footer>
    </div>


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
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 25);

                    if (chunk.length < 25) {
                        // If the chunk is less than 20 characters, add it without breaking
                        formattedText += chunk;
                        break; // Exit the loop as we've processed the remaining text
                    }

                    // For chunks of 20 or more characters, try to break at the last whitespace
                    let breakIndex = chunk.lastIndexOf(" ");
                    if (breakIndex !== -1) {
                        // If there's a whitespace, break at that space
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1; // Move past the space
                    } else {
                        // Otherwise, break at the 20-character limit
                        formattedText += chunk + '<br>';
                        currentIndex += 25;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>
</asp:Content>

