namespace PKHeXRNG
{
    partial class CitraRNG
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
            this.B_Connect = new System.Windows.Forms.Button();
            this.NUD_Port = new System.Windows.Forms.NumericUpDown();
            this.L_Port = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tab_Main = new System.Windows.Forms.TabPage();
            this.B_ReadPKM = new System.Windows.Forms.Button();
            this.NUD_Read = new System.Windows.Forms.NumericUpDown();
            this.B_Disconnect = new System.Windows.Forms.Button();
            this.CB_PKMOffsets = new System.Windows.Forms.ComboBox();
            this.Tab_Memory = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.NUD_ReadOffset = new System.Windows.Forms.NumericUpDown();
            this.B_ReadMemory = new System.Windows.Forms.Button();
            this.NUD_ReadLength = new System.Windows.Forms.NumericUpDown();
            this.L_ReadOffset = new System.Windows.Forms.Label();
            this.L_Length = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Port)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Tab_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Read)).BeginInit();
            this.Tab_Memory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ReadOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ReadLength)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(12, 12);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(75, 20);
            this.B_Connect.TabIndex = 0;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // NUD_Port
            // 
            this.NUD_Port.Location = new System.Drawing.Point(209, 12);
            this.NUD_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Port.Name = "NUD_Port";
            this.NUD_Port.Size = new System.Drawing.Size(52, 20);
            this.NUD_Port.TabIndex = 1;
            this.NUD_Port.Value = new decimal(new int[] {
            45987,
            0,
            0,
            0});
            // 
            // L_Port
            // 
            this.L_Port.AutoSize = true;
            this.L_Port.Location = new System.Drawing.Point(174, 16);
            this.L_Port.Name = "L_Port";
            this.L_Port.Size = new System.Drawing.Size(29, 13);
            this.L_Port.TabIndex = 2;
            this.L_Port.Text = "Port:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Tab_Main);
            this.tabControl1.Controls.Add(this.Tab_Memory);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 397);
            this.tabControl1.TabIndex = 3;
            // 
            // Tab_Main
            // 
            this.Tab_Main.Controls.Add(this.CB_PKMOffsets);
            this.Tab_Main.Controls.Add(this.B_ReadPKM);
            this.Tab_Main.Controls.Add(this.NUD_Read);
            this.Tab_Main.Location = new System.Drawing.Point(4, 22);
            this.Tab_Main.Name = "Tab_Main";
            this.Tab_Main.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main.Size = new System.Drawing.Size(768, 371);
            this.Tab_Main.TabIndex = 1;
            this.Tab_Main.Text = "Main";
            this.Tab_Main.UseVisualStyleBackColor = true;
            // 
            // B_ReadPKM
            // 
            this.B_ReadPKM.Location = new System.Drawing.Point(3, 3);
            this.B_ReadPKM.Name = "B_ReadPKM";
            this.B_ReadPKM.Size = new System.Drawing.Size(75, 23);
            this.B_ReadPKM.TabIndex = 1;
            this.B_ReadPKM.Text = "Read PKM";
            this.B_ReadPKM.UseVisualStyleBackColor = true;
            this.B_ReadPKM.Click += new System.EventHandler(this.B_ReadPKM_Click);
            // 
            // NUD_Read
            // 
            this.NUD_Read.Hexadecimal = true;
            this.NUD_Read.Location = new System.Drawing.Point(84, 6);
            this.NUD_Read.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_Read.Name = "NUD_Read";
            this.NUD_Read.Size = new System.Drawing.Size(120, 20);
            this.NUD_Read.TabIndex = 0;
            // 
            // B_Disconnect
            // 
            this.B_Disconnect.Enabled = false;
            this.B_Disconnect.Location = new System.Drawing.Point(93, 12);
            this.B_Disconnect.Name = "B_Disconnect";
            this.B_Disconnect.Size = new System.Drawing.Size(75, 20);
            this.B_Disconnect.TabIndex = 4;
            this.B_Disconnect.Text = "Disconnect";
            this.B_Disconnect.UseVisualStyleBackColor = true;
            this.B_Disconnect.Click += new System.EventHandler(this.B_Disconnect_Click);
            // 
            // CB_PKMOffsets
            // 
            this.CB_PKMOffsets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PKMOffsets.FormattingEnabled = true;
            this.CB_PKMOffsets.Location = new System.Drawing.Point(210, 5);
            this.CB_PKMOffsets.Name = "CB_PKMOffsets";
            this.CB_PKMOffsets.Size = new System.Drawing.Size(121, 21);
            this.CB_PKMOffsets.TabIndex = 2;
            // 
            // Tab_Memory
            // 
            this.Tab_Memory.Controls.Add(this.L_Length);
            this.Tab_Memory.Controls.Add(this.L_ReadOffset);
            this.Tab_Memory.Controls.Add(this.NUD_ReadLength);
            this.Tab_Memory.Controls.Add(this.B_ReadMemory);
            this.Tab_Memory.Controls.Add(this.NUD_ReadOffset);
            this.Tab_Memory.Controls.Add(this.richTextBox1);
            this.Tab_Memory.Location = new System.Drawing.Point(4, 22);
            this.Tab_Memory.Name = "Tab_Memory";
            this.Tab_Memory.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Memory.Size = new System.Drawing.Size(768, 371);
            this.Tab_Memory.TabIndex = 2;
            this.Tab_Memory.Text = "Memory";
            this.Tab_Memory.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(768, 334);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // NUD_ReadOffset
            // 
            this.NUD_ReadOffset.Hexadecimal = true;
            this.NUD_ReadOffset.Location = new System.Drawing.Point(47, 11);
            this.NUD_ReadOffset.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_ReadOffset.Name = "NUD_ReadOffset";
            this.NUD_ReadOffset.Size = new System.Drawing.Size(90, 20);
            this.NUD_ReadOffset.TabIndex = 1;
            // 
            // B_ReadMemory
            // 
            this.B_ReadMemory.Location = new System.Drawing.Point(339, 8);
            this.B_ReadMemory.Name = "B_ReadMemory";
            this.B_ReadMemory.Size = new System.Drawing.Size(75, 23);
            this.B_ReadMemory.TabIndex = 2;
            this.B_ReadMemory.Text = "Read Memory";
            this.B_ReadMemory.UseVisualStyleBackColor = true;
            this.B_ReadMemory.Click += new System.EventHandler(this.B_ReadMemory_Click);
            // 
            // NUD_ReadLength
            // 
            this.NUD_ReadLength.Hexadecimal = true;
            this.NUD_ReadLength.Location = new System.Drawing.Point(213, 11);
            this.NUD_ReadLength.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.NUD_ReadLength.Name = "NUD_ReadLength";
            this.NUD_ReadLength.Size = new System.Drawing.Size(120, 20);
            this.NUD_ReadLength.TabIndex = 3;
            this.NUD_ReadLength.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // L_ReadOffset
            // 
            this.L_ReadOffset.AutoSize = true;
            this.L_ReadOffset.Location = new System.Drawing.Point(6, 13);
            this.L_ReadOffset.Name = "L_ReadOffset";
            this.L_ReadOffset.Size = new System.Drawing.Size(35, 13);
            this.L_ReadOffset.TabIndex = 4;
            this.L_ReadOffset.Text = "Offset";
            // 
            // L_Length
            // 
            this.L_Length.AutoSize = true;
            this.L_Length.Location = new System.Drawing.Point(167, 13);
            this.L_Length.Name = "L_Length";
            this.L_Length.Size = new System.Drawing.Size(40, 13);
            this.L_Length.TabIndex = 5;
            this.L_Length.Text = "Length";
            // 
            // CitraRNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_Port);
            this.Controls.Add(this.NUD_Port);
            this.Controls.Add(this.B_Disconnect);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.B_Connect);
            this.Name = "CitraRNG";
            this.Text = "CitraRNG";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Port)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Tab_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Read)).EndInit();
            this.Tab_Memory.ResumeLayout(false);
            this.Tab_Memory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ReadOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ReadLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.NumericUpDown NUD_Port;
        private System.Windows.Forms.Label L_Port;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tab_Main;
        private System.Windows.Forms.Button B_Disconnect;
        private System.Windows.Forms.Button B_ReadPKM;
        private System.Windows.Forms.NumericUpDown NUD_Read;
        private System.Windows.Forms.ComboBox CB_PKMOffsets;
        private System.Windows.Forms.TabPage Tab_Memory;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label L_ReadOffset;
        private System.Windows.Forms.NumericUpDown NUD_ReadLength;
        private System.Windows.Forms.Button B_ReadMemory;
        private System.Windows.Forms.NumericUpDown NUD_ReadOffset;
        private System.Windows.Forms.Label L_Length;
    }
}