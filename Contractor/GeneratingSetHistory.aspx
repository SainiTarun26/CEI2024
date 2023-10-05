<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="GeneratingSetHistory.aspx.cs" Inherits="CEIHaryana.Contractor.GeneratingSetHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:GridView class="table-responsive" ID="GridView1" runat="server" Width="100%" 
                            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                    <HeaderTemplate>
                                        TestReportId
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("GeneratingSetId") %> ' CommandName="Select"><%#Eval("GeneratingSetId") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GeneratingSetCapacityType" HeaderText="GeneratingSetCapacityType">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GeneratingSetCapacity" HeaderText="GeneratingSetCapacity">
                                    <HeaderStyle HorizontalAlign="center" Width="12%" />
                                    <ItemStyle HorizontalAlign="center" Width="12%" />
                                </asp:BoundField>
                            
                                <asp:BoundField DataField="GeneratingSetType" HeaderText="GeneratingSetType">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreatedDate" HeaderText="Request Date">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>


                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <%-- <asp:LinkButton runat="server" ID="LinkButton4" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;"
                                        Text="<i class='fa fa-edit' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />--%>
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
</asp:Content>
