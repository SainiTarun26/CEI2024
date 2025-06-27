<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReSubmitContractorDocuments.aspx.cs" Inherits="CEIHaryana.UserPages.ReSubmitContractorDocuments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div class="card"
        style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
        <div class="card-body">
            <div class="row">
                <div class="col-md-12" style="text-align: center; font-size: 22px; font-weight: 800;">
                    <asp:Label ID="Label1" runat="server" Text="Documents"></asp:Label>
                </div>
            </div>
            <hr />

            <br />
            <div class="row">
                <div class="col-md-12">
                    <h4 class="card-title">Documents Checklist</h4>
                </div>
            </div>
            <hr />

            <div class="row">
                <div class="col-md-12">
                    <%-- Add GridView Here --%>
                    <asp:HiddenField ID="hdnContractorId" runat="server" />
                  
                     <asp:HiddenField ID="hdnCategory" runat="server" />
                    <asp:GridView class="table-responsive table table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" >


                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="UTR No." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                  
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select"> View document </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblDocumentID" runat="server" Text='<%#Eval("DocumentID") %>'></asp:Label>
                                    <asp:Label ID="LblDocumentName" runat="server" Text='<%#Eval("DocumentName") %>'></asp:Label>
                                     <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                     <asp:Label ID="lblTempId" runat="server" Text='<%#Eval("TempId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload Document">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                <ItemTemplate>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
            <br />
            <div class="row">
                <div class="col-md-12" style="text-align:center;">
                <%--    <asp:Button ID="btnsubmit" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="btnsubmit_Click"/>--%>
                </div>
            </div>
            <div class="col-4">
                <asp:HiddenField ID="hdnId" runat="server" />
                                                                   <asp:HiddenField ID="hdnTotalExperience" runat="server" />
            </div>
        </div>
    </div>
        </div>
    </form>
</body>
</html>
