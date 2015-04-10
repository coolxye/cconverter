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
	public partial class Progress : Form
	{
		public Progress()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;
		}

		public void SetMaximum(int maxValue)
		{
			this.pgBarProcess.Maximum = maxValue;
		}

		public void InitProgBar()
		{
			this.pgBarProcess.Minimum = 0;
			this.pgBarProcess.Step = 1;
		}

		public void InitProgBar(int maxValue)
		{
			this.pgBarProcess.Minimum = 0;
			this.pgBarProcess.Step = 1;
			this.pgBarProcess.Maximum = maxValue;
		}

		public void PerformProgBar()
		{
			this.pgBarProcess.PerformStep();
			Application.DoEvents();
		}
	}
}
