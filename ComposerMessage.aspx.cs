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
    public partial class ComposerMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(IsPostBack==false)

                
            {


                // ajouter la premier ligne de la liste

                cboDestnataires.Items.Add(new ListItem("Choisir un destinataire" , "0"));
                cboDestnataires.Items[0].Selected = true;

                SqlConnection mycon = new SqlConnection();
                mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
                mycon.Open();

                // interroger avec une requete avec un objet command

                string sql = "SELECT Numero, Nom FROM Membres ORDER BY Nom";



                SqlCommand mycmd = new SqlCommand(sql, mycon);


                SqlDataReader myRder = mycmd.ExecuteReader();


                while(myRder.Read()==true)
                {
                    ListItem elm = new ListItem();
                    elm.Text = myRder["Nom"].ToString() + " (" + myRder["Numero"].ToString()+")";
                    elm.Value = myRder["Numero"].ToString();
                    cboDestnataires.Items.Add(elm);
                }
                myRder.Close();
                mycon.Close();
            }

        }

        protected void btnEnvoie_Click(object sender, EventArgs e)
        {
            if(cboDestnataires.SelectedIndex == 0)
            {
                lblErreur.Text = "Erreur : Choisir un destinataire SVP";
                cboDestnataires.Focus();
                return;
            }
            if (txtTitre.Text.Trim().Length == 0)
            {
                lblErreur.Text = "Erreur : Entrez un Titre pour votre message SVP";
                txtTitre.Focus();
                return;
            }


            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OmnivoxDB;Integrated Security=True";
            mycon.Open();

            string tit = txtTitre.Text;
            string msg = txtMessage.Text;
            string numReceveur = cboDestnataires.SelectedItem.Value.ToString() ;
            string numEnvoyeur = Session["Numero"].ToString();
            string aujourdui = DateTime.Today.ToShortDateString();

            // interroger avec une requete avec un objet command
            string sql = "INSERT INTO Messages (Titre, Message, Envoyeur, Receveur, Date, Nouveau) " +
                                   "VALUES ('" + tit + "', '" + msg + "', '" + numEnvoyeur + "', '" + numReceveur + "', '" + aujourdui + "', 'True');";


            SqlCommand mycmd = new SqlCommand(sql, mycon);


           mycmd.ExecuteNonQuery(); 
            mycon.Close();
            Response.Redirect("accueilOmnivox.aspx");
        }
    }
}