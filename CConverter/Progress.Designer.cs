namespace CConverter
{
	partial class Progress
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pgBarProcess = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// pgBarProcess
			// 
			this.pgBarProcess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgBarProcess.Location = new System.Drawing.Point(0, 0);
			this.pgBarProcess.Name = "pgBarProcess";
			this.pgBarProcess.Size = new System.Drawing.Size(300, 15);
			this.pgBarProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pgBarProcess.TabIndex = 0;
			// 
			// Progress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 15);
			this.Controls.Add(this.pgBarProcess);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Progress";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Progress";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar pgBarProcess;
	}
}