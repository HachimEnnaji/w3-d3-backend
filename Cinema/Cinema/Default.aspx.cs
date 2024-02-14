using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Cinema
{
    public partial class _Default : Page
    {
        int CountSalaNord = 0;
        int CountSalaSud = 0;
        int CountSalaEst = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString.ToString();
            SqlConnection database = new SqlConnection(connectionString);

            try
            {
                database.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database;
                cmd.CommandText = $"SELECT Sala,Ridotto, COUNT(*) AS nPrenotazioni FROM Prenotazioni  GROUP BY Sala,Ridotto ORDER BY Sala ASC";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sala = reader["sala"].ToString();
                    int count = Convert.ToInt32(reader["nPrenotazioni"]);

                    switch (sala)
                    {


                        case "SALA NORD":
                            CountSalaNord += count;
                            break;
                        case "SALA SUD":
                            CountSalaSud += count;

                            break;
                        case "SALA EST":
                            CountSalaEst += count;


                            break;
                    }
                    bigliettiNord.InnerHtml = CountSalaNord.ToString();
                    bigliettiRidottiNord.InnerHtml = count.ToString();

                    bigliettiSud.InnerHtml = CountSalaSud.ToString();
                    bigliettiRidottiSud.InnerHtml = count.ToString();


                    bigliettiEst.InnerHtml = CountSalaEst.ToString();
                    bigliettiRidottiEst.InnerHtml = count.ToString();


                }


            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally { database.Close(); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString.ToString();
            SqlConnection database = new SqlConnection(connectionString);


            try
            {
                database.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database;
                cmd.CommandText = $"INSERT INTO Prenotazioni (Nome , Cognome , Sala, Ridotto) VALUES (@Nome, @Cognome, @NomeSala,@Ridotto)";

                cmd.Parameters.AddWithValue("@Nome", nome.Text);
                cmd.Parameters.AddWithValue("@Cognome", cognome.Text);
                cmd.Parameters.AddWithValue("@NomeSala", DropDownList1.SelectedValue);

                if (ridotto.Checked)
                {
                    cmd.Parameters.AddWithValue("@Ridotto", true);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Ridotto", false);
                }
                cmd.ExecuteNonQuery();

                demo.InnerHtml = "Acquisto andato a buon fine!";

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                database.Close();
                nome.Text = string.Empty;
                cognome.Text = string.Empty;
                ridotto.Checked = false;
            }

        }
    }
}