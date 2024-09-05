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
    public partial class inscrireOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {
            // Recuperer les infos saisies par le user
            string num  = txtNumero.Text.Trim();
            string nais = txtNaissance.Text.Trim();
            string eml = txtEmail.Text.Trim();
            string mdp = txtMotdepasse.Text.Trim();

            // recuperer l'anne de la date de naissance 
            int anneNais = Convert.ToDateTime(nais).Year;
            //se connecter a la BD

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
            mycon.Open();

            // Verifier si user est un etudiant 
            // interroger avec une requete avec un objet command

            string sql = "SELECT Nom FROM Etudiants WHERE ";
            sql += "Numero = '" + num + "'AND Email ='" + eml + "'";
            sql += "AND  Year(Naissance) = " + anneNais;


            SqlCommand mycmd = new SqlCommand(sql, mycon);


            SqlDataReader myRder = mycmd.ExecuteReader();


            if (myRder.Read() == true)  // si user est etudiant  
            {
                // mettre numero et nom du membre dans 2 variables global 
                string nom  = myRder["Nom"].ToString(); // Recuperer nom pour affecter
                
                myRder.Close();


                // Verifier si Etudiant n'est pas DEJA membre 
                sql = "SELECT Nom FROM Membres WHERE Numero = '" + num + "'";
                SqlCommand mycmd2 = new SqlCommand(sql, mycon);
                SqlDataReader myRder2 = mycmd2.ExecuteReader();
                


                if (myRder2.Read() == true)
                {

                    myRder2.Close();
                    mycon.Close();
                    lblErreur.Text = " Echec d'inscription : Vous etes deja membre. ";
                }
                else // user est etudiant et pas membre : donc l'ajouter 
                {
                    myRder2.Close();
                    // requete SQL d'ajout de nouveau Membre 
                    sql = "INSERT INTO Membres (Numero , Nom , Motdepasse , Status) ";
                    sql += "VALUES('" + num + "' ,  '" + nom + "' , '" + mdp + "' , 'Actif' ) ";
                    SqlCommand mycmd3 = new SqlCommand(sql, mycon);
                    mycmd3.ExecuteNonQuery();
                    mycon.Close();
                    Response.Redirect("indexOmnivox.aspx");

                }


                mycon.Close();
                
             

            }
            else // user n'est pas Etudiant
            {
                myRder.Close();
                mycon.Close();
                lblErreur.Text = " Echec d'inscription : Il faut etre Etudiant de Teccart. ";

            }
        }
    }
}