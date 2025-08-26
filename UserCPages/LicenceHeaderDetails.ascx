<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LicenceHeaderDetails.ascx.cs" Inherits="CEIHaryana.UserCPages.LicenceHeaderDetails" %>
<div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">

    <div class="row">

        <div class="col-md-4">
            <label>
                Registration / Licence Id. <span>
                    <asp:LinkButton ID="LinkButton1" runat="server" AutoPostBack="true" OnClick="lnkFile_Click" Text="Registration Details" /></span>
            </label>
            <asp:TextBox class="form-control" ID="txtRegistrationId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" id="individual" runat="server">
            <label>
                Application Id.
            </label>
            <asp:TextBox class="form-control" ID="txtApplicationId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" runat="server">
            <label>
                Licence Category
            </label>
            <asp:TextBox class="form-control" ID="txtLicenceCategory" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <asp:HiddenField ID="hdnRedirectionRegistrationId" runat="server" />

        <div class="col-md-4" runat="server">
            <label>
                Licence Type
            </label>
            <asp:TextBox class="form-control" ID="txtLicenceType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" runat="server" id="DivOtherDepartment" visible="true">
            <label for="txtApplicantName">
                Applicant Name

            </label>
            <asp:TextBox class="form-control" ID="txtApplicantName" ReadOnly="true" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" id="PermisesType" visible="true" runat="server">
            <label>
                Date of Birth
            </label>
            <asp:TextBox class="form-control" ID="txtDOB" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

    </div>

    <div class="row">

        <div class="col-md-4">
            <label>
                Father's Name
            </label>
            <asp:TextBox class="form-control" ID="txtFatherName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>
                <label id="lblPanOrAadhaar" runat="server"></label>
            </label>
            <asp:TextBox class="form-control" ID="txtAdharNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4">
            <label>
                District
            </label>
            <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>
                Contact No.
            </label>
            <asp:TextBox class="form-control" ID="txtContactNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>
                Email Id.
            </label>
            <asp:TextBox class="form-control" ID="txtEmailId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
        <div class="col-md-4" runat="server" id="DivPancard_TanNo">
            <label for="txtCommiteeId">
                Committee
            </label>
            <asp:TextBox class="form-control" ID="txtCommiteeId" TabIndex="1" ReadOnly="true" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>



        <div class="col-md-12">
            <label>
                Address
            </label>
            <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" TextMode="MultiLine" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>


    </div>
</div>
