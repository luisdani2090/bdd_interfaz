
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong><span class="auto-style1">Server3 and Server4 </span></strong>
        <br />
        <br />
        1. Display tests<br />
    
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="width: 187px">
        </asp:GridView>
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh Table" />
        <br />
        <br />
        <strong><span class="auto-style1">Server3</span></strong><br />
        <br />
        1. Insert new test<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert Server3" />
        <br />
        Result:
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        2. Delete a test<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete Server3" />
        <br />
        Result:
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <strong><span class="auto-style1">Server4</span></strong><br />
        <br />
        1. Insert new test<br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Insert Server4" />
        <br />
        <br />
        2. Delete a test<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" Text="Delete Server4" />
        <br />
    
    </div>
    </form>
</body>
</html>
