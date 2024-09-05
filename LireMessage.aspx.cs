using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class LireMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // recuperer le refmessage envoye a partir de accueil
            int refmsg = Convert.ToInt32(Request.QueryString["msgID"]);

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
            mycon.Open();

            // interroger avec une requete avec un objet command

            string sql = "SELECT * FROM Messages WHERE RefMessage = " + refmsg;



            SqlCommand mycmd = new SqlCommand(sql, mycon);


            SqlDataReader myRder = mycmd.ExecuteReader();


            if (myRder.Read() == true)  // si membre trouve 
            {
                // mettre numero et nom du membre dans 2 variables global 

                lblTitre.Text = myRder["Titre"].ToString();
                lblDate.Text = myRder["Date"].ToString();
                lblMessage.Text = myRder["Message"].ToString();
                lblEnvoyeur.Text = myRder["Envoyeur"].ToString();
                Response.Redirect("accueilOmnivox.aspx");

            }
            myRder.Close();
            mycon.Close();

            //coder la requete de update pour le champ nouveau a false et ajouter le nom d'envoyeur
        }
    }
}