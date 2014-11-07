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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CConverter));
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
			this.btnClear = new System.Windows.Forms.Button();
			this.ssCC = new System.Windows.Forms.StatusStrip();
			this.tspbCC = new System.Windows.Forms.ToolStripProgressBar();
			this.tsslCC = new System.Windows.Forms.ToolStripStatusLabel();
			this.msCC.SuspendLayout();
			this.gbFList.SuspendLayout();
			this.gbOp.SuspendLayout();
			this.ssCC.SuspendLayout();
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
			this.tsmiFi.Size = new System.Drawing.Size(41, 20);
			this.tsmiFi.Text = "File";
			// 
			// tsmiOFi
			// 
			this.tsmiOFi.Name = "tsmiOFi";
			this.tsmiOFi.Size = new System.Drawing.Size(136, 22);
			this.tsmiOFi.Text = "Open Files";
			this.tsmiOFi.Click += new System.EventHandler(this.tsmiOFi_Click);
			// 
			// tsmiOFo
			// 
			this.tsmiOFo.Name = "tsmiOFo";
			this.tsmiOFo.Size = new System.Drawing.Size(136, 22);
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
			this.gbFList.Size = new System.Drawing.Size(610, 214);
			this.gbFList.TabIndex = 2;
			this.gbFList.TabStop = false;
			this.gbFList.Text = "Source files";
			// 
			// lbCC
			// 
			this.lbCC.AllowDrop = true;
			this.lbCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbCC.FormattingEnabled = true;
			this.lbCC.HorizontalScrollbar = true;
			this.lbCC.ItemHeight = 12;
			this.lbCC.Location = new System.Drawing.Point(7, 19);
			this.lbCC.Name = "lbCC";
			this.lbCC.Size = new System.Drawing.Size(597, 184);
			this.lbCC.TabIndex = 0;
			this.lbCC.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbCC_DragDrop);
			this.lbCC.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbCC_DragEnter);
			this.lbCC.DragOver += new System.Windows.Forms.DragEventHandler(this.lbCC_DragOver);
			// 
			// gbOp
			// 
			this.gbOp.Controls.Add(this.rbUnix);
			this.gbOp.Controls.Add(this.rbWin);
			this.gbOp.Controls.Add(this.cbEncode);
			this.gbOp.Location = new System.Drawing.Point(12, 247);
			this.gbOp.Name = "gbOp";
			this.gbOp.Size = new System.Drawing.Size(302, 50);
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
			this.rbUnix.Size = new System.Drawing.Size(47, 16);
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
			this.rbWin.Size = new System.Drawing.Size(65, 16);
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
			this.btnStart.Location = new System.Drawing.Point(379, 263);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(507, 263);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// ssCC
			// 
			this.ssCC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbCC,
            this.tsslCC});
			this.ssCC.Location = new System.Drawing.Point(0, 306);
			this.ssCC.Name = "ssCC";
			this.ssCC.Size = new System.Drawing.Size(634, 22);
			this.ssCC.TabIndex = 8;
			this.ssCC.Text = "statusStrip1";
			// 
			// tspbCC
			// 
			this.tspbCC.Name = "tspbCC";
			this.tspbCC.Size = new System.Drawing.Size(400, 16);
			this.tspbCC.Step = 1;
			this.tspbCC.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// tsslCC
			// 
			this.tsslCC.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.tsslCC.Name = "tsslCC";
			this.tsslCC.Size = new System.Drawing.Size(217, 17);
			this.tsslCC.Spring = true;
			this.tsslCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 328);
			this.Controls.Add(this.ssCC);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.gbOp);
			this.Controls.Add(this.gbFList);
			this.Controls.Add(this.msCC);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msCC;
			this.Name = "CConverter";
			this.Text = "CConverter";
			this.msCC.ResumeLayout(false);
			this.msCC.PerformLayout();
			this.gbFList.ResumeLayout(false);
			this.gbOp.ResumeLayout(false);
			this.gbOp.PerformLayout();
			this.ssCC.ResumeLayout(false);
			this.ssCC.PerformLayout();
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
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.StatusStrip ssCC;
		private System.Windows.Forms.ToolStripProgressBar tspbCC;
		private System.Windows.Forms.ToolStripStatusLabel tsslCC;
	}
}

