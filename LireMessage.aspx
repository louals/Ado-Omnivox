<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LireMessage.aspx.cs" Inherits="prjWebCsAdoOmnivox.LireMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td> Titre : </td>
                    <td>
                        <asp:Label ID="lblTitre" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>


                 <tr>
                    <td> Date : </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>


                 <tr>
                    <td> Message : </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>


                
                 <tr>
                    <td> Envoeyeur : </td>
                    <td>
                        <asp:Label ID="lblEnvoyeur" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>





            </table>
        </div>
    </form>
</body>
</html>
