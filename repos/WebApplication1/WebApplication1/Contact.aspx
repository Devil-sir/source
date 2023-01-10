<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>

    <asp:Label ID="lblShowMsg" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" CellPadding="4" CellSpacing="5" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" ShowFooter="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Id">
                <EditItemTemplate>
                    <asp:Label ID="lblIdPatient" runat="server" style="margin: 15px; text-align:center;" Text='<%# Eval("Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblIdPatient" runat="server" style="margin: 15px; text-align:center;" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" >
                <EditItemTemplate>
                    <asp:TextBox ID="tbNamePatient" runat="server" style="margin: 15px; text-align:center;" Text='<%# Eval("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNamePatient" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNamePatient" style="margin: 15px; text-align:center;" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Age">
                <EditItemTemplate>
                    <asp:TextBox ID="tbAgePatient" style="margin: 15px; text-align:center;" runat="server" Text='<%# Eval("Age") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAgePatient" style="margin: 15px;text-align:center;" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAgePatient" style="margin: 15px;text-align:center;" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <FooterTemplate>
                    <asp:ImageButton ID="ImageButton6" runat="server" CommandName="Insert" Height="50px" style ="Margin: 5px; align-items: center; " ImageUrl="~/Images/Insert.jpg" Width="50px" ImageAlign="Middle" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" ImageUrl="Images/Edit.png"  Width="50px" BorderColor="#FF5050" style ="Margin: 5px" BorderWidth="5px" Height="50px" ImageAlign="Left" />
                    <asp:ImageButton ID="ImageButton7" runat="server" CommandName="Cancel" Height="50px" style ="Margin: 5px" ImageUrl="~/Images/cancel.jpg" Width="50px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" ImageUrl="Images/Delete.jpg" style ="Margin: 5px" Width="50px" BorderColor="#CCFF99" BorderWidth="5px" Height="50px" />
                    <asp:ImageButton ID="ImageButton3" runat="server" BorderWidth="5px" CommandName="Update" Height="50px" style ="Margin: 5px" ImageUrl="Images/update.jpg" Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />

    </asp:GridView>
</asp:Content>
