using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAuto
{
	public partial class Arrivee : Form
	{

		private SqlConnection clientConnection = new SqlConnection(@"Data Source=DESKTOP-R15PUFM;Initial Catalog=AutoMobile;Integrated Security=True");
		public Arrivee()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			clientConnection.Open();
			String nom = textBox1.Text;
			String prenom = textBox2.Text;
			String cin = textBox3.Text;
			String matricule = textBox4.Text;

			if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
			{
				MessageBox.Show("Erreur : Un des champs n'a pas été rempli");
			}

			else
			{
				SqlCommand nomCmd = new SqlCommand("select nom FROM personnel where nom = '" + nom + "'", clientConnection);
				SqlDataReader readClient1 = nomCmd.ExecuteReader();
				bool result1 = readClient1.HasRows;
				if (!result1)
				{
					MessageBox.Show("Le nom '" + nom + "' n'existe pas dans la liste des personnels");
				}
				else
				{
					readClient1.Close();
					SqlCommand prenomCmd = new SqlCommand("select prenom FROM personnel where nom = '" + nom + "' and prenom = '" + prenom + "'", clientConnection);
					SqlDataReader readClient2 = prenomCmd.ExecuteReader();
					bool result2 = readClient2.HasRows;
					if (!result2)
					{
						MessageBox.Show("Vérifier si le nom et le prénom sélectionnés se correspondent");
					}
					else
					{
						SqlCommand cin1Cmd = new SqlCommand("select nom FROM personnel where CIN = '" + cin + "'", clientConnection);
						SqlDataReader readClientcin = cin1Cmd.ExecuteReader();
						bool resultcin = readClientcin.HasRows;
						if (!resultcin) {
							MessageBox.Show("Le numéro CIN " + cin + " ne figure pas dans la liste des personnels");
						}
						else {
							SqlCommand cinCmd = new SqlCommand("select CIN FROM personnel where nom = '" + nom + "' and prenom = '" + prenom + "' and CIN = '" + cin + "'", clientConnection);
							SqlDataReader readClient3 = cinCmd.ExecuteReader();
							bool result3 = readClient3.HasRows;
							if (!result3)
							{
								MessageBox.Show("Erreur : Le nom-prénom et le CIN ne se correspondent pas");
							}
							else
							{
								SqlCommand matCmd = new SqlCommand("select matricule FROM personnel where matricule = '" + matricule + "'", clientConnection);
								SqlDataReader readClient4 = matCmd.ExecuteReader();
								bool result4 = readClient4.HasRows;
								if (!result4)
								{
									MessageBox.Show("Erreur : Pas de voiture avec ce matricule");
								}
								else
								{

								}
								readClient4.Close();
							}
							readClient3.Close();
						}
						readClientcin.Close();
					}
					readClient2.Close();
				}
				readClient1.Close();
			}
			clientConnection.Close();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
