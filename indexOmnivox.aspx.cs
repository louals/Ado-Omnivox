using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class indexOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // recuperer les valeurs saisies par utilisateur
             
            string num = txtNumero.Text.Trim();
            string mdp = txtMot2passe.Text.Trim();


            //se connecter a la BD

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
            mycon.Open();

            // interroger avec une requete avec un objet command

            string sql = "SELECT Numero, Nom FROM Membres WHERE ";
            sql  += "Numero ='" + num + "'AND Motdepasse ='" + mdp + "'";



            SqlCommand mycmd = new SqlCommand(sql, mycon);


            SqlDataReader myRder = mycmd.ExecuteReader();


            if (myRder.Read() == true)  // si membre trouve 
            {
                // mettre numero et nom du membre dans 2 variables global 

                Session["Numero"] = myRder["Numero"];
                Session["Nom"] = myRder["Nom"];

                myRder.Close();
                mycon.Close();
                Response.Redirect("accueilOmnivox.aspx");

            }
            else
            {
                myRder.Close();
                mycon.Close();
                lblErreur.Text = "Numero ou Mot de passe invalide, Essayez de nouveau";

            }
        }
    }
}