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

		private Timer tmPrompt;

		public Prompt(string text, string caption)
		{
			InitializeComponent();

			this.lblHint.Text = text;
			this.Text = caption;

			tmPrompt = new Timer();
			tmPrompt.Interval = 800;
			tmPrompt.Tick += new EventHandler(this.tmPrompt_Tick);
			tmPrompt.Start();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.tmPrompt.Stop();
			this.Close();
		}

		private void tmPrompt_Tick(object sender, EventArgs e)
		{
			this.tmPrompt.Stop();
			this.Close();
		}
	}
}
