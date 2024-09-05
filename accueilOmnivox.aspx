<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accueilOmnivox.aspx.cs" Inherits="prjWebCsAdoOmnivox.accueilOmnivox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .centrer{
            text-align: center ; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1 class="centrer">OMNIVOX-TECCART-MIO</h1>
            <hr style="width=400px">

            <asp:Label ID="lblMessage" Font-Bold="true" ForeColor="Brown" runat="server"></asp:Label>

            <br />


            <asp:Table ID="TabMessage" Font-Bold="true" Width="900px" GridLines="Both" runat="server">
                
            </asp:Table>
            <p>

                <asp:Button ID="btnComposer" runat="server" Text="Composer un message" Font-Bold="true" BackColor="#804000" ForeColor="White" OnClick="btnComposer_Click"/>

            </p>


        </div>
    </form>
</body>
</html>
