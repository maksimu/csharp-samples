<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtVal1" runat="server" Font-Size="Large"></asp:TextBox>
        <asp:Label ID="lblSymbol" runat="server" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtVal2" runat="server" Font-Size="Large"></asp:TextBox>
    
    </div>

        <div>

            <asp:Button ID="btnAdd" runat="server" OnClick="calc" Text="Addition (+)" BorderStyle="Solid" Font-Size="Large" Height="50px" />
            <asp:Button ID="btnMin" runat="server" OnClick="calc" Text="Subtract (-)" BorderStyle="Solid" Font-Size="Large" Height="50px" />
            <asp:Button ID="btnDivide" runat="server" OnClick="calc" Text="Divide (/)" BorderStyle="Solid" Font-Size="Large" Height="50px" />
            <asp:Button ID="btnMultiply" runat="server" OnClick="calc" Text="Multiply (x)" BorderStyle="Solid" Font-Size="Large" Height="50px" />

        </div>

        <div>

            <asp:Label ID="lblAnswer" runat="server" Font-Size="50pt" ForeColor="#006600"></asp:Label>

        </div>

        <div>
            <asp:Label ID="lblErrorMsg" runat="server" Font-Size="X-Large" ForeColor="#CC0000"></asp:Label>
        </div>
    </form>
</body>
</html>
