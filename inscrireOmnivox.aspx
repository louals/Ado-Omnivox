<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscrireOmnivox.aspx.cs" Inherits="prjWebCsAdoOmnivox.inscrireOmnivox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .center{
            text-align:center;
        }
        table{
            height:200px;
            width:550px;
            background-color:aquamarine;
            color:black;
            font-weight:bold;
            border-radius:10px;
            padding:4px;
            margin:auto;
        }
        .boite{
            width:300px;
            color:brown;
            font-weight:bold;
            border-radius:3px;
        }
        .bouton{
            width:200px;
            background-color:forestgreen;
            color:white;
            font-weight:bold;
            border-radius:3px;
        }
    </style>
</head>
    
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="center">OMNIVOX TECCART <br />Inscription Nouveau Membre</h1>
            <table>

                <tr>
                    <td>Numero Etudiant : </td>
                    <td>
                        <asp:TextBox ID="txtNumero" CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                
                <tr>
                    <td>Date Naissance : </td>
                    <td>
                         <asp:TextBox ID="txtNaissance" CssClass="boite" TextMode="Date" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>Email Etudiant : </td>
                    <td>
                         <asp:TextBox ID="txtEmail" CssClass="boite" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                 <tr>
                    <td>Mot de passe : </td>
                    <td>
                        <asp:TextBox ID="txtMotdepasse" CssClass="boite" runat="server" TextMode="Password"></asp:TextBox>
                   </td>
                   <td></td>
                </tr>
                
                 <tr>
                <td>Confirmer Mot de passe : </td>
                <td>
                        <asp:TextBox ID="txtMotdepasse2" CssClass="boite" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
                </tr>

                 <tr>
                <td>
                    <asp:Button ID="btnInscrire" runat="server" Text="Inscrire Membre" CssClass="bouton" onclick="btnInscrire_Click"/>
                </td>
                <td colspan="2">
                    <asp:Button ID="btnEffacer"  runat="server" Text="Effacer" CssClass="bouton" />
                </td>
                
                </tr>

                 <tr>

                <td colspan="3">
                    <asp:Label ID="lblErreur" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                </td>
                </tr>

                 <tr>

                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" Font-Bold="true" ForeColor="Red" runat="server" />
                </td>
                </tr>


            </table>
        </div>

    </form>
</body>
</html>
