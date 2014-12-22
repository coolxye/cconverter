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
			this.gbFList = new System.Windows.Forms.GroupBox();
			this.lbCC = new System.Windows.Forms.ListBox();
			this.gbOp = new System.Windows.Forms.GroupBox();
			this.rbMac = new System.Windows.Forms.RadioButton();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.rbUnix = new System.Windows.Forms.RadioButton();
			this.rbWin = new System.Windows.Forms.RadioButton();
			this.cbEncode = new System.Windows.Forms.ComboBox();
			this.stsStripEC = new System.Windows.Forms.StatusStrip();
			this.tsStsLblEC = new System.Windows.Forms.ToolStripStatusLabel();
			this.gbFList.SuspendLayout();
			this.gbOp.SuspendLayout();
			this.stsStripEC.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbFList
			// 
			this.gbFList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbFList.Controls.Add(this.lbCC);
			this.gbFList.Location = new System.Drawing.Point(12, 12);
			this.gbFList.Name = "gbFList";
			this.gbFList.Size = new System.Drawing.Size(608, 227);
			this.gbFList.TabIndex = 0;
			this.gbFList.TabStop = false;
			this.gbFList.Text = "Text File(s)";
			// 
			// lbCC
			// 
			this.lbCC.AllowDrop = true;
			this.lbCC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCC.FormattingEnabled = true;
			this.lbCC.HorizontalScrollbar = true;
			this.lbCC.ItemHeight = 12;
			this.lbCC.Location = new System.Drawing.Point(3, 17);
			this.lbCC.Name = "lbCC";
			this.lbCC.Size = new System.Drawing.Size(602, 207);
			this.lbCC.TabIndex = 0;
			this.lbCC.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbCC_DragDrop);
			this.lbCC.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbCC_DragEnter);
			this.lbCC.DragOver += new System.Windows.Forms.DragEventHandler(this.lbCC_DragOver);
			// 
			// gbOp
			// 
			this.gbOp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbOp.Controls.Add(this.rbMac);
			this.gbOp.Controls.Add(this.btnStart);
			this.gbOp.Controls.Add(this.btnClear);
			this.gbOp.Controls.Add(this.rbUnix);
			this.gbOp.Controls.Add(this.rbWin);
			this.gbOp.Controls.Add(this.cbEncode);
			this.gbOp.Location = new System.Drawing.Point(12, 245);
			this.gbOp.Name = "gbOp";
			this.gbOp.Size = new System.Drawing.Size(608, 50);
			this.gbOp.TabIndex = 1;
			this.gbOp.TabStop = false;
			this.gbOp.Text = "Options";
			// 
			// rbMac
			// 
			this.rbMac.AutoSize = true;
			this.rbMac.Location = new System.Drawing.Point(283, 20);
			this.rbMac.Name = "rbMac";
			this.rbMac.Size = new System.Drawing.Size(41, 16);
			this.rbMac.TabIndex = 3;
			this.rbMac.Text = "MAC";
			this.rbMac.UseVisualStyleBackColor = true;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(352, 17);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(70, 23);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(438, 17);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(70, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// rbUnix
			// 
			this.rbUnix.AutoSize = true;
			this.rbUnix.Location = new System.Drawing.Point(230, 20);
			this.rbUnix.Name = "rbUnix";
			this.rbUnix.Size = new System.Drawing.Size(47, 16);
			this.rbUnix.TabIndex = 2;
			this.rbUnix.Text = "UNIX";
			this.rbUnix.UseVisualStyleBackColor = true;
			// 
			// rbWin
			// 
			this.rbWin.AutoSize = true;
			this.rbWin.Location = new System.Drawing.Point(155, 20);
			this.rbWin.Name = "rbWin";
			this.rbWin.Size = new System.Drawing.Size(65, 16);
			this.rbWin.TabIndex = 1;
			this.rbWin.Text = "Windows";
			this.rbWin.UseVisualStyleBackColor = true;
			// 
			// cbEncode
			// 
			this.cbEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEncode.FormattingEnabled = true;
			this.cbEncode.Items.AddRange(new object[] {
            "ANSI",
            "UTF-8 w/o BOM",
            "UTF-8"});
			this.cbEncode.Location = new System.Drawing.Point(7, 19);
			this.cbEncode.Name = "cbEncode";
			this.cbEncode.Size = new System.Drawing.Size(121, 20);
			this.cbEncode.TabIndex = 0;
			// 
			// stsStripEC
			// 
			this.stsStripEC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStsLblEC});
			this.stsStripEC.Location = new System.Drawing.Point(0, 304);
			this.stsStripEC.Name = "stsStripEC";
			this.stsStripEC.Size = new System.Drawing.Size(632, 22);
			this.stsStripEC.TabIndex = 2;
			this.stsStripEC.Text = "statusStrip1";
			// 
			// tsStsLblEC
			// 
			this.tsStsLblEC.Name = "tsStsLblEC";
			this.tsStsLblEC.Size = new System.Drawing.Size(35, 17);
			this.tsStsLblEC.Text = "Ready";
			// 
			// CConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 326);
			this.Controls.Add(this.stsStripEC);
			this.Controls.Add(this.gbOp);
			this.Controls.Add(this.gbFList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CConverter";
			this.Text = "Encoding Converter";
			this.gbFList.ResumeLayout(false);
			this.gbOp.ResumeLayout(false);
			this.gbOp.PerformLayout();
			this.stsStripEC.ResumeLayout(false);
			this.stsStripEC.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbFList;
		private System.Windows.Forms.ListBox lbCC;
		private System.Windows.Forms.GroupBox gbOp;
		private System.Windows.Forms.ComboBox cbEncode;
		private System.Windows.Forms.RadioButton rbUnix;
		private System.Windows.Forms.RadioButton rbWin;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.RadioButton rbMac;
		private System.Windows.Forms.StatusStrip stsStripEC;
		private System.Windows.Forms.ToolStripStatusLabel tsStsLblEC;
	}
}

