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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private SqlConnection clientConnection = new SqlConnection(@"Data Source=DESKTOP-R15PUFM;Initial Catalog=AutoMobile;Integrated Security=True");

		private bool Exists(string nom, string mdp)
		{
			clientConnection.Open();
			SqlCommand clientCmd = new SqlCommand("select _role FROM _user where nom = '" + nom + "' and mdp = '" + mdp + "'", clientConnection);
			SqlDataReader readClient = clientCmd.ExecuteReader();
			bool result = readClient.HasRows;
			readClient.Close();
			clientConnection.Close();
			return result;
		}




		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!Exists(textBox1.Text, textBox2.Text))
			{
				MessageBox.Show("Le nom d'utilisateur ou le mot de passe est invalide");
			}
			else
			{
				Auto auto = new Auto();
				this.Hide();
				auto.Show();
			}
		}
	}
}
