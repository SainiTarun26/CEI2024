<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="Inspection.aspx.cs" Inherits="CEIHaryana.Officers.Inspection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-4">
    <label>
        Type of Inspection
<samp style="color: red">* </samp>
    </label>
   <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                 
  
</div>

                                <div class="col-4">
                                    <label>
                                        Type of Installation<samp style="color: red"> * </samp>
                                    </label>
                                  <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                 
                                    </div>
                                <div class="col-4">
                                    <label>
                                        Type of Installation<samp style="color: red"> * </samp>
                                    </label>
                                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                 
                                              </div>                              
                                      <div class="col-4" runat="server">
                                        <label for="Pin"> Voltage Level</label>
                                    <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                  
  <%--<asp:GridView class="table-responsive" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" >

      <Columns>
            <asp:TemplateField HeaderText="DemandNoticeOfLine">
            <ItemTemplate>
                <asp:HyperLink ID="hplnk" runat="server" Target="_blank" 
                    NavigateUrl='<%# ResolveUrl(Eval("DemandNoticeOfLine").ToString()) %>' 
                    Text='<%# Eval("DemandNoticeOfLine") %>' />
            </ItemTemplate>
        </asp:TemplateField>
      </Columns>
  </asp:GridView>--%>
                                    </div>
                              </div>
                            
                            <div class="row">
                                <div class="table-responsive pt-3" id="Uploads" runat="server" visible="false">
                                    <table class="table table-bordered table-striped">
                                        <thead class="table-dark">
                                            <tr>
                                                <th>Name of Documents
                                                </th>
                                                <th>Upload Documents
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <div id="LineSubstationSupplier" runat="server" visible="false">
                                            <tr id="Tr1" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Request letter from concerned Officer<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkLetter" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                     
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Manufacturing test report of equipment<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                   <asp:LinkButton ID="lnktest" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                          </div>
                                                </td>
                                            </tr>
                                            </div>
                                            <div id="SupplierSub" runat="server" visible="false">
                                            <tr id="Tr3" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Single line diagram of Line<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                         <asp:LinkButton ID="lnkDiag" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                        </div>
                                                </td>
                                            </tr>
                                            </div>
                                            <div id="PersonalSub" runat="server" visible="false">
                                            <tr id="Tr4" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Copy of demand notice issued by UHDVN/ DHBVN<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                         <asp:LinkButton ID="lnkCopy" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                         </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr5" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Invoice of transformer<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:LinkButton ID="lnkInvoiceTransformer" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                       </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr6" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Manufacturing test certificate of transformer<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                         <asp:LinkButton ID="lnkManufacturing" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr7" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Single line diagram
                                                        <samp style="color: red">* </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:LinkButton ID="lnkSingleDiag" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr8" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Invoice of fire extinguisher system, apparatus installed at the site<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                         <asp:LinkButton ID="lnkInvoiceFire" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                      </div>
                                                </td>
                                            </tr>
                                            </div>
                                            <div id="PersonalGenerating" runat="server" visible="false">
                                            <tr id="Tr9" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Invoice of DG set<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                      <asp:LinkButton ID="lnkDGSetInvoice" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                  
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr10" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Manufacturing test certificate of DG set
                                                        <samp style="color: red">* </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                     <asp:LinkButton ID="lnkManufacturingCertificate" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                  
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="Tr13" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Invoice Of fire Extinguisher/apparatus installed at the site<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                       <asp:LinkButton ID="lnkInvoice" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
                                                    </div>
                                                </td>
                                            </tr>
                                                <tr id="Tr11" runat="server" visible="true">
                                                <td>
                                                    <div class="col-12">
                                                        Structure stability report issued by authorized engineer<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:LinkButton ID="lnkStructure" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />
  </div>
                                                </td>
                                            </tr>
                                            </div>
                                            
                                            <tr id="LinePersonal" runat="server" visible="false">
                                                <td>
                                                    <div class="col-12">
                                                        Demand Notice<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:LinkButton ID="lnkDocument" runat="server" AutoPostBack="true" OnClick="lnkDocument_Click" Text="Open Document" />

                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
</asp:Content>
