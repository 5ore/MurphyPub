namespace Murphy_Windows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DLeftPanel = new System.Windows.Forms.Panel();
            this.Dlist = new System.Windows.Forms.ListBox();
            this.DbtnDodaj = new System.Windows.Forms.Button();
            this.DbtnIzbrisi = new System.Windows.Forms.Button();
            this.DbtnIzmeni = new System.Windows.Forms.Button();
            this.DRightPanel = new System.Windows.Forms.Panel();
            this.Dpicture = new System.Windows.Forms.PictureBox();
            this.Ddatetime = new System.Windows.Forms.DateTimePicker();
            this.DbtnIzadji = new System.Windows.Forms.Button();
            this.DbtnSacuvaj = new System.Windows.Forms.Button();
            this.DtbOpis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtbNaziv = new System.Windows.Forms.TextBox();
            this.DbtnIzaberi = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PRightPanel = new System.Windows.Forms.Panel();
            this.Ppicture = new System.Windows.Forms.PictureBox();
            this.FixPanel = new System.Windows.Forms.Panel();
            this.PtbOpis = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PrivPanel = new System.Windows.Forms.Panel();
            this.Pnum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Pdatetime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PbtnIzaberi = new System.Windows.Forms.Button();
            this.rbFix = new System.Windows.Forms.RadioButton();
            this.rbPriv = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.PbtnIzadji = new System.Windows.Forms.Button();
            this.PbtnSacuvaj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PtbNaziv = new System.Windows.Forms.TextBox();
            this.PLeftPanel = new System.Windows.Forms.Panel();
            this.Plist = new System.Windows.Forms.ListBox();
            this.PbtnDodaj = new System.Windows.Forms.Button();
            this.PbtnIzbrisi = new System.Windows.Forms.Button();
            this.PbtnIzmeni = new System.Windows.Forms.Button();
            this.TabDisabled = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.DLeftPanel.SuspendLayout();
            this.DRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dpicture)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ppicture)).BeginInit();
            this.FixPanel.SuspendLayout();
            this.PrivPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pnum)).BeginInit();
            this.PLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 482);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DLeftPanel);
            this.tabPage1.Controls.Add(this.DRightPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Događaji";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DLeftPanel
            // 
            this.DLeftPanel.Controls.Add(this.Dlist);
            this.DLeftPanel.Controls.Add(this.DbtnDodaj);
            this.DLeftPanel.Controls.Add(this.DbtnIzbrisi);
            this.DLeftPanel.Controls.Add(this.DbtnIzmeni);
            this.DLeftPanel.Location = new System.Drawing.Point(6, 22);
            this.DLeftPanel.Name = "DLeftPanel";
            this.DLeftPanel.Size = new System.Drawing.Size(316, 410);
            this.DLeftPanel.TabIndex = 5;
            // 
            // Dlist
            // 
            this.Dlist.FormattingEnabled = true;
            this.Dlist.Location = new System.Drawing.Point(26, 22);
            this.Dlist.Name = "Dlist";
            this.Dlist.Size = new System.Drawing.Size(262, 238);
            this.Dlist.TabIndex = 0;
            this.Dlist.SelectedIndexChanged += new System.EventHandler(this.Dlist_SelectedIndexChanged);
            // 
            // DbtnDodaj
            // 
            this.DbtnDodaj.Location = new System.Drawing.Point(26, 331);
            this.DbtnDodaj.Name = "DbtnDodaj";
            this.DbtnDodaj.Size = new System.Drawing.Size(262, 50);
            this.DbtnDodaj.TabIndex = 4;
            this.DbtnDodaj.Text = "Dodaj";
            this.DbtnDodaj.UseVisualStyleBackColor = true;
            this.DbtnDodaj.Click += new System.EventHandler(this.DbtnDodaj_Click);
            // 
            // DbtnIzbrisi
            // 
            this.DbtnIzbrisi.Location = new System.Drawing.Point(26, 275);
            this.DbtnIzbrisi.Name = "DbtnIzbrisi";
            this.DbtnIzbrisi.Size = new System.Drawing.Size(127, 50);
            this.DbtnIzbrisi.TabIndex = 1;
            this.DbtnIzbrisi.Text = "Izbriši";
            this.DbtnIzbrisi.UseVisualStyleBackColor = true;
            this.DbtnIzbrisi.Click += new System.EventHandler(this.DbtnIzbrisi_Click);
            // 
            // DbtnIzmeni
            // 
            this.DbtnIzmeni.Location = new System.Drawing.Point(159, 275);
            this.DbtnIzmeni.Name = "DbtnIzmeni";
            this.DbtnIzmeni.Size = new System.Drawing.Size(129, 50);
            this.DbtnIzmeni.TabIndex = 2;
            this.DbtnIzmeni.Text = "Izmeni";
            this.DbtnIzmeni.UseVisualStyleBackColor = true;
            this.DbtnIzmeni.Click += new System.EventHandler(this.DbtnIzmeni_Click);
            // 
            // DRightPanel
            // 
            this.DRightPanel.Controls.Add(this.Dpicture);
            this.DRightPanel.Controls.Add(this.Ddatetime);
            this.DRightPanel.Controls.Add(this.DbtnIzadji);
            this.DRightPanel.Controls.Add(this.DbtnSacuvaj);
            this.DRightPanel.Controls.Add(this.DtbOpis);
            this.DRightPanel.Controls.Add(this.label2);
            this.DRightPanel.Controls.Add(this.label1);
            this.DRightPanel.Controls.Add(this.DtbNaziv);
            this.DRightPanel.Controls.Add(this.DbtnIzaberi);
            this.DRightPanel.Location = new System.Drawing.Point(356, 6);
            this.DRightPanel.Name = "DRightPanel";
            this.DRightPanel.Size = new System.Drawing.Size(386, 447);
            this.DRightPanel.TabIndex = 3;
            // 
            // Dpicture
            // 
            this.Dpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Dpicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dpicture.Image = global::Murphy_Windows.Properties.Resources.logo;
            this.Dpicture.Location = new System.Drawing.Point(155, 44);
            this.Dpicture.Name = "Dpicture";
            this.Dpicture.Size = new System.Drawing.Size(217, 188);
            this.Dpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Dpicture.TabIndex = 12;
            this.Dpicture.TabStop = false;
            // 
            // Ddatetime
            // 
            this.Ddatetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ddatetime.Location = new System.Drawing.Point(0, 0);
            this.Ddatetime.Name = "Ddatetime";
            this.Ddatetime.Size = new System.Drawing.Size(386, 20);
            this.Ddatetime.TabIndex = 11;
            // 
            // DbtnIzadji
            // 
            this.DbtnIzadji.Location = new System.Drawing.Point(225, 385);
            this.DbtnIzadji.Name = "DbtnIzadji";
            this.DbtnIzadji.Size = new System.Drawing.Size(147, 41);
            this.DbtnIzadji.TabIndex = 10;
            this.DbtnIzadji.Text = "Izađi";
            this.DbtnIzadji.UseVisualStyleBackColor = true;
            this.DbtnIzadji.Click += new System.EventHandler(this.DbtnIzadji_Click);
            // 
            // DbtnSacuvaj
            // 
            this.DbtnSacuvaj.Location = new System.Drawing.Point(27, 385);
            this.DbtnSacuvaj.Name = "DbtnSacuvaj";
            this.DbtnSacuvaj.Size = new System.Drawing.Size(147, 41);
            this.DbtnSacuvaj.TabIndex = 4;
            this.DbtnSacuvaj.Text = "Sačuvaj ";
            this.DbtnSacuvaj.UseVisualStyleBackColor = true;
            this.DbtnSacuvaj.Click += new System.EventHandler(this.button5_Click);
            // 
            // DtbOpis
            // 
            this.DtbOpis.Location = new System.Drawing.Point(27, 280);
            this.DtbOpis.MaxLength = 1024;
            this.DtbOpis.Multiline = true;
            this.DtbOpis.Name = "DtbOpis";
            this.DtbOpis.Size = new System.Drawing.Size(345, 99);
            this.DtbOpis.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Opis:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Naziv:";
            // 
            // DtbNaziv
            // 
            this.DtbNaziv.Location = new System.Drawing.Point(27, 238);
            this.DtbNaziv.MaxLength = 50;
            this.DtbNaziv.Name = "DtbNaziv";
            this.DtbNaziv.Size = new System.Drawing.Size(345, 20);
            this.DtbNaziv.TabIndex = 6;
            // 
            // DbtnIzaberi
            // 
            this.DbtnIzaberi.Location = new System.Drawing.Point(37, 98);
            this.DbtnIzaberi.Name = "DbtnIzaberi";
            this.DbtnIzaberi.Size = new System.Drawing.Size(112, 70);
            this.DbtnIzaberi.TabIndex = 4;
            this.DbtnIzaberi.Text = "Izaberi sliku";
            this.DbtnIzaberi.UseVisualStyleBackColor = true;
            this.DbtnIzaberi.Click += new System.EventHandler(this.DbtnIzaberi_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PRightPanel);
            this.tabPage2.Controls.Add(this.PLeftPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(769, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Promocije";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // PRightPanel
            // 
            this.PRightPanel.Controls.Add(this.Ppicture);
            this.PRightPanel.Controls.Add(this.FixPanel);
            this.PRightPanel.Controls.Add(this.PrivPanel);
            this.PRightPanel.Controls.Add(this.PbtnIzaberi);
            this.PRightPanel.Controls.Add(this.rbFix);
            this.PRightPanel.Controls.Add(this.rbPriv);
            this.PRightPanel.Controls.Add(this.label6);
            this.PRightPanel.Controls.Add(this.PbtnIzadji);
            this.PRightPanel.Controls.Add(this.PbtnSacuvaj);
            this.PRightPanel.Controls.Add(this.label4);
            this.PRightPanel.Controls.Add(this.PtbNaziv);
            this.PRightPanel.Location = new System.Drawing.Point(356, 6);
            this.PRightPanel.Name = "PRightPanel";
            this.PRightPanel.Size = new System.Drawing.Size(386, 447);
            this.PRightPanel.TabIndex = 7;
            this.PRightPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Ppicture
            // 
            this.Ppicture.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Ppicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Ppicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ppicture.Image = global::Murphy_Windows.Properties.Resources.logo;
            this.Ppicture.Location = new System.Drawing.Point(145, 16);
            this.Ppicture.Name = "Ppicture";
            this.Ppicture.Size = new System.Drawing.Size(224, 201);
            this.Ppicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ppicture.TabIndex = 14;
            this.Ppicture.TabStop = false;
            // 
            // FixPanel
            // 
            this.FixPanel.Controls.Add(this.PtbOpis);
            this.FixPanel.Controls.Add(this.label7);
            this.FixPanel.Location = new System.Drawing.Point(16, 256);
            this.FixPanel.Name = "FixPanel";
            this.FixPanel.Size = new System.Drawing.Size(367, 98);
            this.FixPanel.TabIndex = 19;
            this.FixPanel.Visible = false;
            // 
            // PtbOpis
            // 
            this.PtbOpis.Location = new System.Drawing.Point(13, 15);
            this.PtbOpis.MaxLength = 1024;
            this.PtbOpis.Multiline = true;
            this.PtbOpis.Name = "PtbOpis";
            this.PtbOpis.Size = new System.Drawing.Size(328, 83);
            this.PtbOpis.TabIndex = 1;
            this.PtbOpis.TextChanged += new System.EventHandler(this.PtbOpis_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Opis:";
            // 
            // PrivPanel
            // 
            this.PrivPanel.Controls.Add(this.Pnum);
            this.PrivPanel.Controls.Add(this.label3);
            this.PrivPanel.Controls.Add(this.Pdatetime);
            this.PrivPanel.Controls.Add(this.label5);
            this.PrivPanel.Location = new System.Drawing.Point(16, 254);
            this.PrivPanel.Name = "PrivPanel";
            this.PrivPanel.Size = new System.Drawing.Size(353, 98);
            this.PrivPanel.TabIndex = 18;
            // 
            // Pnum
            // 
            this.Pnum.DecimalPlaces = 2;
            this.Pnum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Pnum.Location = new System.Drawing.Point(13, 17);
            this.Pnum.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Pnum.Name = "Pnum";
            this.Pnum.Size = new System.Drawing.Size(182, 20);
            this.Pnum.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cena:";
            // 
            // Pdatetime
            // 
            this.Pdatetime.Location = new System.Drawing.Point(13, 71);
            this.Pdatetime.Name = "Pdatetime";
            this.Pdatetime.Size = new System.Drawing.Size(330, 20);
            this.Pdatetime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Traje do:";
            // 
            // PbtnIzaberi
            // 
            this.PbtnIzaberi.Location = new System.Drawing.Point(27, 16);
            this.PbtnIzaberi.Name = "PbtnIzaberi";
            this.PbtnIzaberi.Size = new System.Drawing.Size(112, 70);
            this.PbtnIzaberi.TabIndex = 4;
            this.PbtnIzaberi.Text = "Izaberi sliku";
            this.PbtnIzaberi.UseVisualStyleBackColor = true;
            this.PbtnIzaberi.Click += new System.EventHandler(this.PbtnIzaberi_Click);
            // 
            // rbFix
            // 
            this.rbFix.AutoSize = true;
            this.rbFix.Location = new System.Drawing.Point(33, 161);
            this.rbFix.Name = "rbFix";
            this.rbFix.Size = new System.Drawing.Size(56, 17);
            this.rbFix.TabIndex = 17;
            this.rbFix.TabStop = true;
            this.rbFix.Text = "Fiksna";
            this.rbFix.UseVisualStyleBackColor = true;
            this.rbFix.CheckedChanged += new System.EventHandler(this.rbFix_CheckedChanged);
            // 
            // rbPriv
            // 
            this.rbPriv.AutoSize = true;
            this.rbPriv.Checked = true;
            this.rbPriv.Location = new System.Drawing.Point(33, 138);
            this.rbPriv.Name = "rbPriv";
            this.rbPriv.Size = new System.Drawing.Size(78, 17);
            this.rbPriv.TabIndex = 16;
            this.rbPriv.TabStop = true;
            this.rbPriv.Text = "Privremena";
            this.rbPriv.UseVisualStyleBackColor = true;
            this.rbPriv.CheckedChanged += new System.EventHandler(this.rbPriv_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Vrsta promocije:";
            // 
            // PbtnIzadji
            // 
            this.PbtnIzadji.Location = new System.Drawing.Point(210, 358);
            this.PbtnIzadji.Name = "PbtnIzadji";
            this.PbtnIzadji.Size = new System.Drawing.Size(147, 41);
            this.PbtnIzadji.TabIndex = 10;
            this.PbtnIzadji.Text = "Izađi";
            this.PbtnIzadji.UseVisualStyleBackColor = true;
            this.PbtnIzadji.Click += new System.EventHandler(this.PbtnIzadji_Click);
            // 
            // PbtnSacuvaj
            // 
            this.PbtnSacuvaj.Location = new System.Drawing.Point(27, 358);
            this.PbtnSacuvaj.Name = "PbtnSacuvaj";
            this.PbtnSacuvaj.Size = new System.Drawing.Size(147, 41);
            this.PbtnSacuvaj.TabIndex = 4;
            this.PbtnSacuvaj.Text = "Sačuvaj ";
            this.PbtnSacuvaj.UseVisualStyleBackColor = true;
            this.PbtnSacuvaj.Click += new System.EventHandler(this.PbtnSacuvaj_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Naziv:";
            // 
            // PtbNaziv
            // 
            this.PtbNaziv.Location = new System.Drawing.Point(29, 223);
            this.PtbNaziv.MaxLength = 50;
            this.PtbNaziv.Name = "PtbNaziv";
            this.PtbNaziv.Size = new System.Drawing.Size(171, 20);
            this.PtbNaziv.TabIndex = 6;
            // 
            // PLeftPanel
            // 
            this.PLeftPanel.Controls.Add(this.Plist);
            this.PLeftPanel.Controls.Add(this.PbtnDodaj);
            this.PLeftPanel.Controls.Add(this.PbtnIzbrisi);
            this.PLeftPanel.Controls.Add(this.PbtnIzmeni);
            this.PLeftPanel.Location = new System.Drawing.Point(6, 22);
            this.PLeftPanel.Name = "PLeftPanel";
            this.PLeftPanel.Size = new System.Drawing.Size(316, 410);
            this.PLeftPanel.TabIndex = 6;
            // 
            // Plist
            // 
            this.Plist.FormattingEnabled = true;
            this.Plist.Location = new System.Drawing.Point(26, 22);
            this.Plist.Name = "Plist";
            this.Plist.Size = new System.Drawing.Size(262, 238);
            this.Plist.TabIndex = 0;
            this.Plist.SelectedIndexChanged += new System.EventHandler(this.Plist_SelectedIndexChanged);
            // 
            // PbtnDodaj
            // 
            this.PbtnDodaj.Location = new System.Drawing.Point(26, 331);
            this.PbtnDodaj.Name = "PbtnDodaj";
            this.PbtnDodaj.Size = new System.Drawing.Size(262, 50);
            this.PbtnDodaj.TabIndex = 4;
            this.PbtnDodaj.Text = "Dodaj";
            this.PbtnDodaj.UseVisualStyleBackColor = true;
            this.PbtnDodaj.Click += new System.EventHandler(this.PbtnDodaj_Click);
            // 
            // PbtnIzbrisi
            // 
            this.PbtnIzbrisi.Location = new System.Drawing.Point(26, 275);
            this.PbtnIzbrisi.Name = "PbtnIzbrisi";
            this.PbtnIzbrisi.Size = new System.Drawing.Size(127, 50);
            this.PbtnIzbrisi.TabIndex = 1;
            this.PbtnIzbrisi.Text = "Izbriši";
            this.PbtnIzbrisi.UseVisualStyleBackColor = true;
            this.PbtnIzbrisi.Click += new System.EventHandler(this.PbtnIzbrisi_Click);
            // 
            // PbtnIzmeni
            // 
            this.PbtnIzmeni.Location = new System.Drawing.Point(159, 275);
            this.PbtnIzmeni.Name = "PbtnIzmeni";
            this.PbtnIzmeni.Size = new System.Drawing.Size(129, 50);
            this.PbtnIzmeni.TabIndex = 2;
            this.PbtnIzmeni.Text = "Izmeni";
            this.PbtnIzmeni.UseVisualStyleBackColor = true;
            this.PbtnIzmeni.Click += new System.EventHandler(this.PbtnIzmeni_Click);
            // 
            // TabDisabled
            // 
            this.TabDisabled.AutoSize = true;
            this.TabDisabled.BackColor = System.Drawing.Color.Transparent;
            this.TabDisabled.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TabDisabled.Location = new System.Drawing.Point(9, 26);
            this.TabDisabled.Name = "TabDisabled";
            this.TabDisabled.Padding = new System.Windows.Forms.Padding(70, 10, 70, 10);
            this.TabDisabled.Size = new System.Drawing.Size(140, 33);
            this.TabDisabled.TabIndex = 6;
            this.TabDisabled.Visible = false;
            this.TabDisabled.Click += new System.EventHandler(this.TabDisabled_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 507);
            this.Controls.Add(this.TabDisabled);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Murphy\'s Pub";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.DLeftPanel.ResumeLayout(false);
            this.DRightPanel.ResumeLayout(false);
            this.DRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dpicture)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.PRightPanel.ResumeLayout(false);
            this.PRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ppicture)).EndInit();
            this.FixPanel.ResumeLayout(false);
            this.FixPanel.PerformLayout();
            this.PrivPanel.ResumeLayout(false);
            this.PrivPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pnum)).EndInit();
            this.PLeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel DRightPanel;
        private System.Windows.Forms.Button DbtnSacuvaj;
        private System.Windows.Forms.TextBox DtbOpis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DtbNaziv;
        private System.Windows.Forms.Button DbtnIzaberi;
        private System.Windows.Forms.Button DbtnIzmeni;
        private System.Windows.Forms.Button DbtnIzbrisi;
        private System.Windows.Forms.ListBox Dlist;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel DLeftPanel;
        private System.Windows.Forms.Button DbtnDodaj;
        private System.Windows.Forms.DateTimePicker Ddatetime;
        private System.Windows.Forms.Button DbtnIzadji;
        private System.Windows.Forms.Panel PRightPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Pnum;
        private System.Windows.Forms.DateTimePicker Pdatetime;
        private System.Windows.Forms.Button PbtnIzadji;
        private System.Windows.Forms.Button PbtnSacuvaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PtbNaziv;
        private System.Windows.Forms.Button PbtnIzaberi;
        private System.Windows.Forms.Panel PLeftPanel;
        private System.Windows.Forms.ListBox Plist;
        private System.Windows.Forms.Button PbtnDodaj;
        private System.Windows.Forms.Button PbtnIzbrisi;
        private System.Windows.Forms.Button PbtnIzmeni;
        private System.Windows.Forms.PictureBox Dpicture;
        private System.Windows.Forms.PictureBox Ppicture;
        private System.Windows.Forms.RadioButton rbFix;
        private System.Windows.Forms.RadioButton rbPriv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TabDisabled;
        private System.Windows.Forms.Panel FixPanel;
        private System.Windows.Forms.TextBox PtbOpis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PrivPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

