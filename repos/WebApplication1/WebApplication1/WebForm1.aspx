<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Registration Form</h1>
        <asp:Button ID="btnPatient" runat="server" Text="Patient" OnClick="btnPatient_Click" />
        <asp:Button ID="btnDoctor" runat="server" Text="Doctor" OnClick="btnDoctor_Click" />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
             <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>         
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            </Columns>



        </asp:GridView>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT * FROM [Patient]"></asp:SqlDataSource>



        <asp:MultiView ID="RegistrationView" runat="server">
            <asp:View ID="View1" runat="server" >
                <h1>Patient Registration</h1>
                <asp:Label ID="lIdPatient" runat="server" Text="Id" style="margin:5px"></asp:Label>&emsp;  
                <asp:TextBox ID="tbIdPatient" runat="server" PlaceHolder="Enter Your Id" style="margin:5px" ></asp:TextBox><br />
                
                <asp:Label ID="lNamePatient" runat="server" Text="Name" style="margin:5px"></asp:Label>&emsp; 
                <asp:TextBox ID="tbNamePatient" runat="server" PlaceHolder="Enter Your Name" style="margin:5px"></asp:TextBox><br />
                
                <asp:Label ID="lAgePatient" runat="server" Text="Age" style="margin:5px"></asp:Label>&emsp; 
                <asp:TextBox ID="tbAgePatient" runat="server" PlaceHolder="Enter Your Age" style="margin:5px"></asp:TextBox><br />
                <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbAgePatient"></asp:RequiredFieldValidator>-->
                <asp:Button ID="btnRegisterPatient" runat="server" Text="Register" style="margin:5px; " OnClick="btnRegisterPatient_Click" />
                <asp:Button ID="btnLoginPatient" runat="server" Text="LogIn" style="margin:5px; " OnClick="btnLoginPatient_Click" /> 
                <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                </asp:GridView>
                <br />
                <asp:Button ID="btnUpdatePatient" runat="server" Text="Update" style="margin:5px; " OnClick="btnUpdatePatient_Click" /> <br />
                <asp:Button ID="btnDeletePatient" runat="server" Text="Delete" OnClick="btnDeletePatient_Click" />
                <asp:MultiView ID="RegistrationViewPatient" runat="server">
                    <asp:View ID="ViewRegisterPatient" runat="server">
                        <asp:Label ID="lRegisterMsg" runat="server" style="margin:5px"></asp:Label>
                    </asp:View>
                    <asp:View ID="ViewLoginPatient" runat="server">
                        <asp:Label ID="lIdPatientLogin" runat="server" Text="Id" style="margin:5px"></asp:Label>
                        <asp:TextBox ID="tbIdPatientLogin" runat="server" style="margin:5px"></asp:TextBox><br />
                        <asp:Button ID="btnLogin" runat="server" Text="Display" style="margin:5px" OnClick="btnLogin_Click"/> <br />
                     
                        <asp:Label ID="lLoginMsg" runat="server" style="margin:5px"></asp:Label>
                    </asp:View>
                    <asp:View ID="ViewUpdatePatient" runat="server">
                        <asp:Label ID="lUpdatePatient" runat="server" style="margin:5px"></asp:Label>

                    </asp:View>

                </asp:MultiView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <h1>Doctor Registration</h1>
                <asp:Label ID="lIdDoctor" runat="server" Text="Id" style="margin:5px"></asp:Label>&emsp;  
                <asp:TextBox ID="tbIdDoctor" runat="server" PlaceHolder="Enter Your Id" style="margin:5px" ></asp:TextBox><br />
                
                <asp:Label ID="lNameDoctor" runat="server" Text="Name" style="margin:5px"></asp:Label>&emsp; 
                <asp:TextBox ID="tbNameDoctor" runat="server" PlaceHolder="Enter Your Name" style="margin:5px"></asp:TextBox><br />
                
                <asp:Label ID="lContactDoctor" runat="server" Text="Contact" style="margin:5px"></asp:Label>&emsp; 
                <asp:TextBox ID="tbContactDoctor" runat="server" PlaceHolder="Enter Your Contact" style="margin:5px"></asp:TextBox><br />

                <asp:Button ID="btnRegisterDoctor" runat="server" Text="Register" style="margin:5px; " />
                <asp:Button ID="btnLoginDoctor" runat="server" Text="LogIn" style="margin:5px; " />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
