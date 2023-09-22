<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="TestReportForm.aspx.cs" Inherits="CEIHaryana.Supervisor.TestReportForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                                <%-- <div class="col-4" runat="server">
                            <label for="SiteContact">Contact Details of Site Owner</label>
                            <asp:TextBox class="form-control" ID="txtSiteContact" MaxLength="10" onkeydown="return preventEnterSubmit(event)" onkeyup="return isvalidphoneno2();" onKeyPress="return isNumberKey(event);" TabIndex="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect2" style="color: red"></span>

                        </div>--%>
                                <div class="col-4">
                                    <label>
                                        Select Installation Type
        <samp style="color: red">* </samp>
                                    </label>
                                 
                                   <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" TabIndex="8" ID="ddlWorkDetail" runat="server" OnSelectedIndexChanged="ddlWorkDetail_SelectedIndexChanged">
                       
                                       </asp:DropDownList>
                                    <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
   </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <div class="table-responsive pt-3" id="Installation" runat="server" visible="false">
                                        <table class="table table-bordered table-striped">
                                            <thead class="table-dark">
                                                <tr>
                                                   
                                                    <th style="width: 70%;">Installation Type
                                                    </th>
                                                    <th style="width: 20%;">No of Installations
                                                    </th>
                                                    <th style="width:10%;"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <div id="installationType1" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinstallationNo1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>

                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete1" Text="DELETE" CssClass="submit" OnClick="btnDelete1_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType2" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType2" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtinstallationNo2" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                          <td>
                                                            <asp:Button runat="server" ID="btnDelete2" Text="DELETE" CssClass="submit" OnClick="btnDelete2_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType3" runat="server" visible="False">
                                                <tr>        
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType3" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px;"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div style="margin-left: 15px !important; margin-right: 15px !important;">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtinstallationNo3" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>

                                                            </div>
                                                        </td>
                                                          <td>
                                                            <asp:Button runat="server" ID="btnDelete3" Text="DELETE" CssClass="submit" OnClick="btnDelete3_Click" />
                                                        </td>
                                                    </tr>
                                                    </div>                                               
                                                <div id="installationType4" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtinstallationNo4" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete4" Text="DELETE" CssClass="submit" OnClick="btnDelete4_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType5" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtinstallationNo5" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete5" Text="DELETE" CssClass="submit" OnClick="btnDelete5_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType6" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtinstallationNo6" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete6" Text="DELETE" CssClass="submit" OnClick="btnDelete6_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType7" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstallationNo7" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete7" Text="DELETE" CssClass="submit" OnClick="btnDelete7_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div id="installationType8" runat="server" visible="False">
                                                    <tr>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationType8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtinstallationNo8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtinstallationNo8" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>  <td>
                                                            <asp:Button runat="server" ID="btnDelete8" Text="DELETE" CssClass="submit" OnClick="btnDelete8_Click" />
                                                        </td>
                                                    </tr>
                                                </div>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                 <div class="row">
                                <div class="col-4"></div>
                                <div class="col-4" style="text-align: center;">
                                    <asp:Button type="submit" ID="btnNext" ValidationGroup="Submit" Text="Next" runat="server" class="btn btn-primary mr-2" OnClick="btnNext_Click" />
                                  
                                </div>
                            </div>
</asp:Content>
