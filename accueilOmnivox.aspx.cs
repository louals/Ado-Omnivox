using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class accueilOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                int nbM = 0;
                string numeroMbr = Session["Numero"].ToString(); ;
                // Creation de la premiere ligne du tableau
                TableRow maLigne = new TableRow();
                TableCell maCellule = new TableCell();
                maCellule.Text = "Titre";
                maLigne.Cells.Add(maCellule);

                maCellule = new TableCell();
                maCellule.Text = "Envoyeur";
                maLigne.Cells.Add(maCellule);

                maCellule = new TableCell();
                maCellule.Text = "Actions";
                maLigne.Cells.Add(maCellule);

                TabMessage.Rows.Add(maLigne);
                maLigne.BackColor = Color.Aquamarine;

                lblMessage.Text = " Bienvenue " + Session["Nom"];



                //se connecter a la BD

                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
                mycon.Open();


                // interroger avec une requete avec un objet command

                //string sql = "SELECT RefMessage , Titre , Envoyeur , Nouveau , Nom FROM Messages,Membres WHERE ";

                //sql += "Messages.Envoyeur = Membres.Numero AND ";

                //sql += "Receveur = '" + numeroMbr + "'";

                string sql = "SELECT RefMessage, Titre, Envoyeur, Nouveau, Nom FROM Messages ";
                sql += "JOIN Membres On Messages.Envoyeur = Membres.Numero ";
                sql += "WHERE Receveur ='" + numeroMbr + "'";
                
               

                SqlCommand mycmd = new SqlCommand(sql, mycon);


                SqlDataReader myRder = mycmd.ExecuteReader();

               
                while (myRder.Read() == true)
                {
                    
                    TableRow maLigne1 = new TableRow();
                    TableCell maCellule1 = new TableCell();
                    maCellule1.Text = myRder["Titre"].ToString();
                    maLigne1.Cells.Add(maCellule1);

                    maCellule1 = new TableCell();
                    maCellule1.Text = myRder["Nom"].ToString();
                    maLigne1.Cells.Add(maCellule1);



                    int refMsg = Convert.ToInt32(myRder["RefMessage"]);

                    maCellule1 = new TableCell();
                    string liens = "<a href='LireMessage.aspx?msgID="+refMsg+"'>Lire</a>";
                    liens += "&nbsp;&nbsp;&nbsp;";
                    liens += "<a href='effacermessage.aspx'>Effacer</a>";
                    maCellule1.Text = liens;
                    maLigne1.Cells.Add(maCellule1);

                    if (myRder["Nouveau"].ToString()=="True")
                    {
                        maLigne1.BackColor = Color.Yellow;
                    }

                    TabMessage.Rows.Add(maLigne1);
                    nbM++;
                }
                
                myRder.Close();
                
                mycon.Close();
         
                lblMessage.Text += " Vous avez " + nbM + " Messages !";
            }

        }

        protected void btnComposer_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComposerMessage.aspx");
        }
    }
}