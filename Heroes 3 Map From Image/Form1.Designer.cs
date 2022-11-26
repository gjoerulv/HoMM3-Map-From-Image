namespace Heroes_3_Map_From_Image
{
    partial class Form1
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
            this.openFileDialogMap = new System.Windows.Forms.OpenFileDialog();
            this.tbMapFile = new System.Windows.Forms.TextBox();
            this.tbTextFile = new System.Windows.Forms.TextBox();
            this.btnMapFile = new System.Windows.Forms.Button();
            this.btnImg = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb4 = new System.Windows.Forms.ComboBox();
            this.cb3 = new System.Windows.Forms.ComboBox();
            this.nudMapNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cb5 = new System.Windows.Forms.ComboBox();
            this.cb6 = new System.Windows.Forms.ComboBox();
            this.cb7 = new System.Windows.Forms.ComboBox();
            this.cb8 = new System.Windows.Forms.ComboBox();
            this.cb9 = new System.Windows.Forms.ComboBox();
            this.cbDims = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbGrayscale = new System.Windows.Forms.RadioButton();
            this.rbRGB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.saveMapFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cbConversionMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogMap
            // 
            this.openFileDialogMap.Filter = "Homm3 map files|*.h3m|All files|*.*";
            // 
            // tbMapFile
            // 
            this.tbMapFile.Location = new System.Drawing.Point(130, 14);
            this.tbMapFile.Name = "tbMapFile";
            this.tbMapFile.Size = new System.Drawing.Size(189, 20);
            this.tbMapFile.TabIndex = 2;
            // 
            // tbTextFile
            // 
            this.tbTextFile.Location = new System.Drawing.Point(130, 69);
            this.tbTextFile.Name = "tbTextFile";
            this.tbTextFile.Size = new System.Drawing.Size(189, 20);
            this.tbTextFile.TabIndex = 5;
            // 
            // btnMapFile
            // 
            this.btnMapFile.Location = new System.Drawing.Point(12, 12);
            this.btnMapFile.Name = "btnMapFile";
            this.btnMapFile.Size = new System.Drawing.Size(112, 23);
            this.btnMapFile.TabIndex = 1;
            this.btnMapFile.Text = "Base on Map...";
            this.btnMapFile.UseVisualStyleBackColor = true;
            this.btnMapFile.Click += new System.EventHandler(this.BtnMapFile_Click);
            // 
            // btnImg
            // 
            this.btnImg.Location = new System.Drawing.Point(12, 67);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(112, 23);
            this.btnImg.TabIndex = 4;
            this.btnImg.Text = "Select Image..";
            this.btnImg.UseVisualStyleBackColor = true;
            this.btnImg.Click += new System.EventHandler(this.BtnImg_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(358, 446);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 21;
            this.btnImport.Text = "Save As..";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // cb1
            // 
            this.cb1.FormattingEnabled = true;
            this.cb1.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb1.Location = new System.Drawing.Point(62, 181);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(98, 21);
            this.cb1.TabIndex = 8;
            this.cb1.Tag = "0";
            this.cb1.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Darkest";
            // 
            // cb2
            // 
            this.cb2.FormattingEnabled = true;
            this.cb2.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb2.Location = new System.Drawing.Point(62, 208);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(98, 21);
            this.cb2.TabIndex = 9;
            this.cb2.Tag = "1";
            this.cb2.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lightest";
            // 
            // cb4
            // 
            this.cb4.FormattingEnabled = true;
            this.cb4.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb4.Location = new System.Drawing.Point(62, 262);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(98, 21);
            this.cb4.TabIndex = 11;
            this.cb4.Tag = "3";
            this.cb4.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cb3
            // 
            this.cb3.FormattingEnabled = true;
            this.cb3.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb3.Location = new System.Drawing.Point(62, 235);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(98, 21);
            this.cb3.TabIndex = 10;
            this.cb3.Tag = "2";
            this.cb3.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // nudMapNumber
            // 
            this.nudMapNumber.Location = new System.Drawing.Point(378, 371);
            this.nudMapNumber.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMapNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMapNumber.Name = "nudMapNumber";
            this.nudMapNumber.Size = new System.Drawing.Size(37, 20);
            this.nudMapNumber.TabIndex = 18;
            this.nudMapNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMapNumber.ValueChanged += new System.EventHandler(this.nudMapNumber_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Import to map number";
            // 
            // cb5
            // 
            this.cb5.FormattingEnabled = true;
            this.cb5.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb5.Location = new System.Drawing.Point(62, 289);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(98, 21);
            this.cb5.TabIndex = 12;
            this.cb5.Tag = "4";
            this.cb5.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cb6
            // 
            this.cb6.FormattingEnabled = true;
            this.cb6.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb6.Location = new System.Drawing.Point(62, 316);
            this.cb6.Name = "cb6";
            this.cb6.Size = new System.Drawing.Size(98, 21);
            this.cb6.TabIndex = 13;
            this.cb6.Tag = "5";
            this.cb6.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cb7
            // 
            this.cb7.FormattingEnabled = true;
            this.cb7.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb7.Location = new System.Drawing.Point(62, 343);
            this.cb7.Name = "cb7";
            this.cb7.Size = new System.Drawing.Size(98, 21);
            this.cb7.TabIndex = 14;
            this.cb7.Tag = "6";
            this.cb7.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cb8
            // 
            this.cb8.FormattingEnabled = true;
            this.cb8.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb8.Location = new System.Drawing.Point(62, 370);
            this.cb8.Name = "cb8";
            this.cb8.Size = new System.Drawing.Size(98, 21);
            this.cb8.TabIndex = 15;
            this.cb8.Tag = "7";
            this.cb8.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cb9
            // 
            this.cb9.FormattingEnabled = true;
            this.cb9.Items.AddRange(new object[] {
            "Dirt",
            "Sand",
            "Grass",
            "Snow",
            "Swamp",
            "Rough",
            "Subterranean",
            "Lava",
            "Water",
            "Rock",
            "Highland",
            "Wasteland"});
            this.cb9.Location = new System.Drawing.Point(62, 397);
            this.cb9.Name = "cb9";
            this.cb9.Size = new System.Drawing.Size(98, 21);
            this.cb9.TabIndex = 16;
            this.cb9.Tag = "8";
            this.cb9.SelectedIndexChanged += new System.EventHandler(this.cbTerrain_SelectedIndexChanged);
            // 
            // cbDims
            // 
            this.cbDims.Enabled = false;
            this.cbDims.FormattingEnabled = true;
            this.cbDims.Items.AddRange(new object[] {
            "S  36",
            "M  72",
            "L  108",
            "XL 144",
            "H  180",
            "XH 216",
            "G  252"});
            this.cbDims.Location = new System.Drawing.Point(90, 40);
            this.cbDims.Name = "cbDims";
            this.cbDims.Size = new System.Drawing.Size(115, 21);
            this.cbDims.TabIndex = 3;
            this.cbDims.SelectedIndexChanged += new System.EventHandler(this.cbDims_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Size detected";
            // 
            // rbGrayscale
            // 
            this.rbGrayscale.AutoSize = true;
            this.rbGrayscale.Location = new System.Drawing.Point(12, 95);
            this.rbGrayscale.Name = "rbGrayscale";
            this.rbGrayscale.Size = new System.Drawing.Size(386, 17);
            this.rbGrayscale.TabIndex = 6;
            this.rbGrayscale.TabStop = true;
            this.rbGrayscale.Text = "Convert image to Grayscale. Then match tarrain based on darkest to lightest.";
            this.rbGrayscale.UseVisualStyleBackColor = true;
            this.rbGrayscale.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbRGB
            // 
            this.rbRGB.AutoSize = true;
            this.rbRGB.Location = new System.Drawing.Point(12, 118);
            this.rbRGB.Name = "rbRGB";
            this.rbRGB.Size = new System.Drawing.Size(233, 17);
            this.rbRGB.TabIndex = 7;
            this.rbRGB.TabStop = true;
            this.rbRGB.Text = "Try to match terrain based on color of pixels.";
            this.rbRGB.UseVisualStyleBackColor = true;
            this.rbRGB.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Grayscale Converts To (only if grayscale)...";
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "1 = Surface, 2 = Subterranean";
            // 
            // saveMapFileDialog
            // 
            this.saveMapFileDialog.Filter = "Homm3 map files|*.h3m|All files|*.*";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(211, 43);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(90, 13);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = "Version detected:";
            // 
            // cbConversionMethod
            // 
            this.cbConversionMethod.FormattingEnabled = true;
            this.cbConversionMethod.Items.AddRange(new object[] {
            "Match for hues only",
            "Match in RGB space",
            "Based on hue, saturation and brightness",
            "Distance in RGB space"});
            this.cbConversionMethod.Location = new System.Drawing.Point(137, 424);
            this.cbConversionMethod.Name = "cbConversionMethod";
            this.cbConversionMethod.Size = new System.Drawing.Size(182, 21);
            this.cbConversionMethod.TabIndex = 23;
            this.cbConversionMethod.SelectedIndexChanged += new System.EventHandler(this.cbConversionMethod_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Pixel conversion method";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 481);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbConversionMethod);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbRGB);
            this.Controls.Add(this.rbGrayscale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDims);
            this.Controls.Add(this.cb9);
            this.Controls.Add(this.cb8);
            this.Controls.Add(this.cb7);
            this.Controls.Add(this.cb6);
            this.Controls.Add(this.cb5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudMapNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb4);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.btnMapFile);
            this.Controls.Add(this.tbTextFile);
            this.Controls.Add(this.tbMapFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Homm3 Import map from image";
            ((System.ComponentModel.ISupportInitialize)(this.nudMapNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogMap;
        private System.Windows.Forms.TextBox tbMapFile;
        private System.Windows.Forms.TextBox tbTextFile;
        private System.Windows.Forms.Button btnMapFile;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb4;
        private System.Windows.Forms.ComboBox cb3;
        private System.Windows.Forms.NumericUpDown nudMapNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb5;
        private System.Windows.Forms.ComboBox cb6;
        private System.Windows.Forms.ComboBox cb7;
        private System.Windows.Forms.ComboBox cb8;
        private System.Windows.Forms.ComboBox cb9;
        private System.Windows.Forms.ComboBox cbDims;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbGrayscale;
        private System.Windows.Forms.RadioButton rbRGB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveMapFileDialog;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox cbConversionMethod;
        private System.Windows.Forms.Label label7;
    }
}

