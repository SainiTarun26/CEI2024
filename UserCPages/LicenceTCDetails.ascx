<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LicenceTCDetails.ascx.cs" Inherits="CEIHaryana.UserCPages.LicenceTCDetails" %>

<div class="card-title" style="margin-top: -15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
    Treasury Challan Details
</div>

<div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">

    <div class="row">

        <div class="col-md-4">
            <label>
                GrNo/UtrnNo 
            </label>
            <asp:TextBox class="form-control" ID="txtGrUtrno" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" id="individual" runat="server">
            <label>
               ChallanDate
            </label>
            <asp:TextBox class="form-control" ID="txtGrUtrnoDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>

        <div class="col-md-4" runat="server">
            <label>
                Amount
            </label>
            <asp:TextBox class="form-control" ID="txtGrUtrnoAmount" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
        </div>
    </div>

</div>
