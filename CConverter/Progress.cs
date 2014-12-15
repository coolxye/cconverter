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

		public void InitProgBar(int maxValue)
		{
			this.pgBarProcess.Minimum = 0;
			this.pgBarProcess.Step = 1;
			this.pgBarProcess.Maximum = maxValue;
		}

		public void RunProgBar()
		{
			//this.pgBarProcess.PerformStep();
			while (this.pgBarProcess.Value < this.pgBarProcess.Maximum)
				this.pgBarProcess.Increment(1);

			this.Close();
		}

		public void CloseProgress()
		{
			this.Close();
		}
	}
}
