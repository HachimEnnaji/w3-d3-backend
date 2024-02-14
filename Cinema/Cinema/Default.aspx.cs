using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Cinema
{
    public partial class _Default : Page
    {
        int countSalaNord = 0;
        int countSalaSud = 0;
        int countSalaEst = 0;


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
                    string tipoSala = reader["Sala"].ToString();
                    int count = Convert.ToInt32(reader["nPrenotazioni"]);
                    int countRidotto = Convert.ToInt32(reader["Ridotto"]);

                    switch (tipoSala)
                    {
                        case "SALA NORD ":
                            countSalaNord += count;
                            if (countRidotto == 1)
                            {
                                bigliettiRidottiNord.InnerText = count.ToString();
                            }
                            SalaNord.InnerText = tipoSala.ToString();
                            bigliettiNord.InnerText = countSalaNord.ToString();
                            break;
                        case "SALA EST  ":
                            countSalaEst += count;
                            if (countRidotto == 1)
                            {
                                bigliettiRidottiEst.InnerText = count.ToString();
                            }
                            SalaEst.InnerText = tipoSala.ToString();
                            bigliettiEst.InnerText = countSalaEst.ToString();
                            break;
                        case "SALA SUD  ":
                            countSalaSud += count;
                            if (countRidotto == 1)
                            {
                                bigliettiRidottiSud.InnerText = count.ToString();
                            }
                            SalaSud.InnerText = tipoSala.ToString();
                            bigliettiSud.InnerText = countSalaSud.ToString();
                            break;
                        default: break;
                    }






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