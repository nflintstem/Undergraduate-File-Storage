
namespace SquareGOL
{
    partial class ConwayGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoLBox = new System.Windows.Forms.PictureBox();
            this.sizeCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Resetter = new System.Windows.Forms.Button();
            this.gamePlay = new System.Windows.Forms.Button();
            this.gameInc = new System.Windows.Forms.Button();
            this.ShapeNamer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.percentageCheck = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Clearer = new System.Windows.Forms.Button();
            this.playMENU = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceMENU = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GenerateMENU = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMENU = new System.Windows.Forms.ToolStripMenuItem();
            this.savePNG = new System.Windows.Forms.Button();
            this.saveTXT = new System.Windows.Forms.Button();
            this.loadF = new System.Windows.Forms.Button();
            this.LoadBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GoLBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // GoLBox
            // 
            this.GoLBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoLBox.BackColor = System.Drawing.Color.Black;
            this.GoLBox.Location = new System.Drawing.Point(3, 32);
            this.GoLBox.Name = "GoLBox";
            this.GoLBox.Size = new System.Drawing.Size(936, 518);
            this.GoLBox.TabIndex = 0;
            this.GoLBox.TabStop = false;
            this.GoLBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoLBox_MouseClick);
            // 
            // sizeCounter
            // 
            this.sizeCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeCounter.Location = new System.Drawing.Point(747, 556);
            this.sizeCounter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sizeCounter.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sizeCounter.Name = "sizeCounter";
            this.sizeCounter.Size = new System.Drawing.Size(48, 23);
            this.sizeCounter.TabIndex = 1;
            this.sizeCounter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 559);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cell Size";
            // 
            // Resetter
            // 
            this.Resetter.Location = new System.Drawing.Point(165, 3);
            this.Resetter.Name = "Resetter";
            this.Resetter.Size = new System.Drawing.Size(75, 23);
            this.Resetter.TabIndex = 3;
            this.Resetter.Text = "Reset";
            this.Resetter.UseVisualStyleBackColor = true;
            this.Resetter.Click += new System.EventHandler(this.Resetter_Click);
            // 
            // gamePlay
            // 
            this.gamePlay.Location = new System.Drawing.Point(84, 3);
            this.gamePlay.Name = "gamePlay";
            this.gamePlay.Size = new System.Drawing.Size(75, 23);
            this.gamePlay.TabIndex = 4;
            this.gamePlay.Text = "Play";
            this.gamePlay.UseVisualStyleBackColor = true;
            this.gamePlay.Click += new System.EventHandler(this.gamePlay_Click);
            // 
            // gameInc
            // 
            this.gameInc.Location = new System.Drawing.Point(3, 3);
            this.gameInc.Name = "gameInc";
            this.gameInc.Size = new System.Drawing.Size(75, 23);
            this.gameInc.TabIndex = 5;
            this.gameInc.Text = "Advance";
            this.gameInc.UseVisualStyleBackColor = true;
            this.gameInc.Click += new System.EventHandler(this.gameInc_Click);
            // 
            // ShapeNamer
            // 
            this.ShapeNamer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShapeNamer.FormattingEnabled = true;
            this.ShapeNamer.Items.AddRange(new object[] {
            "Moore",
            "von Neumann",
            "Diagonals"});
            this.ShapeNamer.Location = new System.Drawing.Point(110, 555);
            this.ShapeNamer.Name = "ShapeNamer";
            this.ShapeNamer.Size = new System.Drawing.Size(157, 23);
            this.ShapeNamer.TabIndex = 6;
            this.ShapeNamer.SelectedIndexChanged += new System.EventHandler(this.ShapeNamer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Neighbourhood";
            // 
            // percentageCheck
            // 
            this.percentageCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percentageCheck.Location = new System.Drawing.Point(881, 556);
            this.percentageCheck.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.percentageCheck.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.percentageCheck.Name = "percentageCheck";
            this.percentageCheck.Size = new System.Drawing.Size(51, 23);
            this.percentageCheck.TabIndex = 9;
            this.percentageCheck.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(801, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "% Alive Cells";
            // 
            // Clearer
            // 
            this.Clearer.Location = new System.Drawing.Point(246, 2);
            this.Clearer.Name = "Clearer";
            this.Clearer.Size = new System.Drawing.Size(75, 24);
            this.Clearer.TabIndex = 11;
            this.Clearer.Text = "Clear";
            this.Clearer.UseVisualStyleBackColor = true;
            this.Clearer.Click += new System.EventHandler(this.Clearer_Click);
            // 
            // playMENU
            // 
            this.playMENU.Name = "playMENU";
            this.playMENU.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.playMENU.Size = new System.Drawing.Size(186, 22);
            this.playMENU.Text = "Play";
            // 
            // advanceMENU
            // 
            this.advanceMENU.Name = "advanceMENU";
            this.advanceMENU.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.advanceMENU.Size = new System.Drawing.Size(186, 22);
            this.advanceMENU.Text = "Advance";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // GenerateMENU
            // 
            this.GenerateMENU.Name = "GenerateMENU";
            this.GenerateMENU.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.GenerateMENU.Size = new System.Drawing.Size(186, 22);
            this.GenerateMENU.Text = "Generate New";
            // 
            // clearMENU
            // 
            this.clearMENU.Name = "clearMENU";
            this.clearMENU.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.clearMENU.Size = new System.Drawing.Size(186, 22);
            this.clearMENU.Text = "Clear";
            // 
            // savePNG
            // 
            this.savePNG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savePNG.Location = new System.Drawing.Point(857, 3);
            this.savePNG.Name = "savePNG";
            this.savePNG.Size = new System.Drawing.Size(75, 23);
            this.savePNG.TabIndex = 12;
            this.savePNG.Text = "Save (PNG)";
            this.savePNG.UseVisualStyleBackColor = true;
            this.savePNG.Click += new System.EventHandler(this.savePNG_Click);
            // 
            // saveTXT
            // 
            this.saveTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTXT.Location = new System.Drawing.Point(776, 3);
            this.saveTXT.Name = "saveTXT";
            this.saveTXT.Size = new System.Drawing.Size(75, 23);
            this.saveTXT.TabIndex = 13;
            this.saveTXT.Text = "Save (TXT)";
            this.saveTXT.UseVisualStyleBackColor = true;
            this.saveTXT.Click += new System.EventHandler(this.saveTXT_Click);
            // 
            // loadF
            // 
            this.loadF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadF.Location = new System.Drawing.Point(695, 3);
            this.loadF.Name = "loadF";
            this.loadF.Size = new System.Drawing.Size(75, 23);
            this.loadF.TabIndex = 14;
            this.loadF.Text = "Load";
            this.loadF.UseVisualStyleBackColor = true;
            this.loadF.Click += new System.EventHandler(this.loadF_Click);
            // 
            // LoadBox
            // 
            this.LoadBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadBox.Location = new System.Drawing.Point(525, 2);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new System.Drawing.Size(164, 23);
            this.LoadBox.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(463, 557);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Proportional Rules";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(409, 557);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 23);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 559);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Neighbourhood Radius";
            // 
            // ConwayGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 581);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LoadBox);
            this.Controls.Add(this.loadF);
            this.Controls.Add(this.saveTXT);
            this.Controls.Add(this.savePNG);
            this.Controls.Add(this.Clearer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.percentageCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShapeNamer);
            this.Controls.Add(this.gameInc);
            this.Controls.Add(this.gamePlay);
            this.Controls.Add(this.Resetter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeCounter);
            this.Controls.Add(this.GoLBox);
            this.Name = "ConwayGUI";
            this.Text = "Conway\'s Game of Life";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConwayGUI_FormClosing);
            this.Load += new System.EventHandler(this.ConwayGUI_Load);
            this.Resize += new System.EventHandler(this.ConwayGUI_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GoLBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GoLBox;
        private System.Windows.Forms.NumericUpDown sizeCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Resetter;
        private System.Windows.Forms.Button gamePlay;
        private System.Windows.Forms.Button gameInc;
        private System.Windows.Forms.ComboBox ShapeNamer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown percentageCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Clearer;
        private System.Windows.Forms.ToolStripMenuItem playMENU;
        private System.Windows.Forms.ToolStripMenuItem advanceMENU;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem GenerateMENU;
        private System.Windows.Forms.ToolStripMenuItem clearMENU;
        private System.Windows.Forms.Button savePNG;
        private System.Windows.Forms.Button saveTXT;
        private System.Windows.Forms.Button loadF;
        private System.Windows.Forms.TextBox LoadBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
    }
}

