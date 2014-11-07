namespace CConverter
{
	partial class CConverter
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.msCC = new System.Windows.Forms.MenuStrip();
			this.tsmiFi = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiOFi = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiOFo = new System.Windows.Forms.ToolStripMenuItem();
			this.gbFList = new System.Windows.Forms.GroupBox();
			this.lbCC = new System.Windows.Forms.ListBox();
			this.gbOp = new System.Windows.Forms.GroupBox();
			this.rbUnix = new System.Windows.Forms.RadioButton();
			this.rbWin = new System.Windows.Forms.RadioButton();
			this.cbEncode = new System.Windows.Forms.ComboBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.msCC.SuspendLayout();
			this.gbFList.SuspendLayout();
			this.gbOp.SuspendLayout();
			this.SuspendLayout();
			// 
			// msCC
			// 
			this.msCC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFi});
			this.msCC.Location = new System.Drawing.Point(0, 0);
			this.msCC.Name = "msCC";
			this.msCC.Size = new System.Drawing.Size(634, 24);
			this.msCC.TabIndex = 0;
			this.msCC.Text = "menuStrip1";
			// 
			// tsmiFi
			// 
			this.tsmiFi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOFi,
            this.tsmiOFo});
			this.tsmiFi.Name = "tsmiFi";
			this.tsmiFi.Size = new System.Drawing.Size(36, 20);
			this.tsmiFi.Text = "File";
			// 
			// tsmiOFi
			// 
			this.tsmiOFi.Name = "tsmiOFi";
			this.tsmiOFi.Size = new System.Drawing.Size(132, 22);
			this.tsmiOFi.Text = "Open Files";
			this.tsmiOFi.Click += new System.EventHandler(this.tsmiOFi_Click);
			// 
			// tsmiOFo
			// 
			this.tsmiOFo.Name = "tsmiOFo";
			this.tsmiOFo.Size = new System.Drawing.Size(132, 22);
			this.tsmiOFo.Text = "Open Folder";
			this.tsmiOFo.Click += new System.EventHandler(this.tsmiOFo_Click);
			// 
			// gbFList
			// 
			this.gbFList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbFList.Controls.Add(this.lbCC);
			this.gbFList.Location = new System.Drawing.Point(12, 27);
			this.gbFList.Name = "gbFList";
			this.gbFList.Size = new System.Drawing.Size(610, 227);
			this.gbFList.TabIndex = 2;
			this.gbFList.TabStop = false;
			this.gbFList.Text = "Source files";
			// 
			// lbCC
			// 
			this.lbCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbCC.FormattingEnabled = true;
			this.lbCC.HorizontalScrollbar = true;
			this.lbCC.ItemHeight = 12;
			this.lbCC.Location = new System.Drawing.Point(7, 19);
			this.lbCC.Name = "lbCC";
			this.lbCC.Size = new System.Drawing.Size(597, 196);
			this.lbCC.TabIndex = 0;
			// 
			// gbOp
			// 
			this.gbOp.Controls.Add(this.rbUnix);
			this.gbOp.Controls.Add(this.rbWin);
			this.gbOp.Controls.Add(this.cbEncode);
			this.gbOp.Location = new System.Drawing.Point(12, 260);
			this.gbOp.Name = "gbOp";
			this.gbOp.Size = new System.Drawing.Size(302, 56);
			this.gbOp.TabIndex = 3;
			this.gbOp.TabStop = false;
			this.gbOp.Text = "Options";
			// 
			// rbUnix
			// 
			this.rbUnix.AutoSize = true;
			this.rbUnix.Checked = true;
			this.rbUnix.Location = new System.Drawing.Point(230, 20);
			this.rbUnix.Name = "rbUnix";
			this.rbUnix.Size = new System.Drawing.Size(49, 16);
			this.rbUnix.TabIndex = 4;
			this.rbUnix.TabStop = true;
			this.rbUnix.Text = "UNIX";
			this.rbUnix.UseVisualStyleBackColor = true;
			// 
			// rbWin
			// 
			this.rbWin.AutoSize = true;
			this.rbWin.Location = new System.Drawing.Point(155, 20);
			this.rbWin.Name = "rbWin";
			this.rbWin.Size = new System.Drawing.Size(67, 16);
			this.rbWin.TabIndex = 3;
			this.rbWin.Text = "Windows";
			this.rbWin.UseVisualStyleBackColor = true;
			// 
			// cbEncode
			// 
			this.cbEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEncode.FormattingEnabled = true;
			this.cbEncode.Items.AddRange(new object[] {
            "Shift-JIS",
            "UTF-8"});
			this.cbEncode.Location = new System.Drawing.Point(7, 19);
			this.cbEncode.Name = "cbEncode";
			this.cbEncode.Size = new System.Drawing.Size(121, 20);
			this.cbEncode.TabIndex = 0;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(350, 277);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(451, 277);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// CConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 328);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.gbOp);
			this.Controls.Add(this.gbFList);
			this.Controls.Add(this.msCC);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.msCC;
			this.Name = "CConverter";
			this.Text = "CConverter";
			this.msCC.ResumeLayout(false);
			this.msCC.PerformLayout();
			this.gbFList.ResumeLayout(false);
			this.gbOp.ResumeLayout(false);
			this.gbOp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip msCC;
		private System.Windows.Forms.ToolStripMenuItem tsmiFi;
		private System.Windows.Forms.ToolStripMenuItem tsmiOFi;
		private System.Windows.Forms.ToolStripMenuItem tsmiOFo;
		private System.Windows.Forms.GroupBox gbFList;
		private System.Windows.Forms.ListBox lbCC;
		private System.Windows.Forms.GroupBox gbOp;
		private System.Windows.Forms.ComboBox cbEncode;
		private System.Windows.Forms.RadioButton rbUnix;
		private System.Windows.Forms.RadioButton rbWin;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnExit;
	}
}

