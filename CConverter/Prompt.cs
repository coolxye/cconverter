using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CConverter
{
	public partial class Prompt : Form
	{
		public Prompt()
		{
			InitializeComponent();
		}

		public Prompt(string text, string caption)
		{
			InitializeComponent();

			this.lblHint.Text = text;
			this.Text = caption;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
