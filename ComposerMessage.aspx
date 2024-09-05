<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComposerMessage.aspx.cs" Inherits="prjWebCsAdoOmnivox.ComposerMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envoyer un Message</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
            margin: 0;
            padding: 0;
        }
        .centrer {
            text-align: center;
            margin-top: 20px;
        }
        table {
            font-weight: bold;
            background-color: #e0f7fa;
            color: #6b4226;
            width: 900px;
            border-radius: 15px;
            margin: 20px auto;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        table td {
            padding: 10px;
        }
        hr {
            width: 400px;
            border: 1px solid #ccc;
            margin: 10px auto;
        }
        input[type="text"], textarea {
            width: calc(100% - 22px);
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 1em;
        }
        .buttons {
            text-align: center;
        }
        .buttons .aspNetButton {
            padding: 10px 20px;
            margin: 5px;
            border: none;
            border-radius: 5px;
            font-size: 1em;
            cursor: pointer;
        }
        .buttons .aspNetButton:hover {
            opacity: 0.8;
        }
        .buttons .green {
            background-color: green;
            color: white;
        }
        .buttons .red {
            background-color: red;
            color: white;
        }
        .buttons .blue {
            background-color: blue;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="centrer">OMNIVOX-TECCART-MIO <br /> Envoi de messages</h1>
            <hr>
            <table>
                <tr>
                    <td>Destinataire du message:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="cboDestnataires" Font-Bold="true" runat="server" Width="200px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Titre du message:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTitre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="txtMessage" runat="server" ForeColor="Navy" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="buttons">
                    <td>
                        <asp:Button ID="btnEnvoie" runat="server" Text="Envoyer" CssClass="aspNetButton green" Onclick="btnEnvoie_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnEffacer" runat="server" Text="Effacer" CssClass="aspNetButton red" />
                    </td>
                    <td>
                        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CssClass="aspNetButton blue" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblErreur" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>