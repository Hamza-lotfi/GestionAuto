using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAuto
{
	public partial class Auto : Form
	{
		public Auto()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Depart depart = new Depart();
			this.Hide();
			depart.Show();
		}

		private void Auto_Load(object sender, EventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Arrivee arrivee = new Arrivee();
			this.Hide();
			arrivee.Show();
		}
	}
}
