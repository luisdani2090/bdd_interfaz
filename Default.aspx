
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            text-align: left;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            height: 319px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style3"><span class="auto-style1">
    
        <strong>Server3 and Server4 
                    <br />
                    <br />
                    </strong>
        1. Display tests<br />
                    <br />
    
        <asp:GridView ID="GridView1" runat="server" ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="width: 187px">
        </asp:GridView>
    
                    <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh Table" />
                    </span></td>
                <td class="auto-style3"><span class="auto-style1">
        <strong>Server3<br />
                    <br />
                    </strong>1. Insert new test<strong><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert Server3" />
                    <br />
        <br />
                    </strong>Result:
        <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
        2. Delete a test<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete Server3" />
                    <br />
        <br />
        Result:
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
                    </span></td>
                <td class="auto-style3">
        <strong><span class="auto-style1">Server4</span></strong><br />
        <br />
                    <span class="auto-style2">1. Insert new test</span><br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Insert Server4" OnClick="Button3_Click" />
                    <br />
                    <br />
                    <span class="auto-style2">Result:</span><asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
                    <br />
        <br />
                    <span class="auto-style2">2. Delete a test</span><br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" Text="Delete Server4" OnClick="Button4_Click" />
                    <br />
                    <br />
                    <span class="auto-style2">Result:</span><asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
    
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
