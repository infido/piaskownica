namespace Piaskownica
{
    partial class Panel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel));
            this.panelNaglowek = new System.Windows.Forms.Panel();
            this.cbShowArchiwum = new System.Windows.Forms.CheckBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.tTextToFind = new System.Windows.Forms.TextBox();
            this.lToSearch = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listaZamówieńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.użytkownicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.połączenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStopka = new System.Windows.Forms.Panel();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelNaglowek.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelStopka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNaglowek
            // 
            this.panelNaglowek.Controls.Add(this.cbShowArchiwum);
            this.panelNaglowek.Controls.Add(this.bClear);
            this.panelNaglowek.Controls.Add(this.bSearch);
            this.panelNaglowek.Controls.Add(this.tTextToFind);
            this.panelNaglowek.Controls.Add(this.lToSearch);
            this.panelNaglowek.Controls.Add(this.menuStrip1);
            this.panelNaglowek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNaglowek.Location = new System.Drawing.Point(0, 0);
            this.panelNaglowek.Name = "panelNaglowek";
            this.panelNaglowek.Size = new System.Drawing.Size(1250, 62);
            this.panelNaglowek.TabIndex = 0;
            // 
            // cbShowArchiwum
            // 
            this.cbShowArchiwum.AutoSize = true;
            this.cbShowArchiwum.Location = new System.Drawing.Point(1087, 33);
            this.cbShowArchiwum.Name = "cbShowArchiwum";
            this.cbShowArchiwum.Size = new System.Drawing.Size(160, 17);
            this.cbShowArchiwum.TabIndex = 5;
            this.cbShowArchiwum.Text = "Pokazać zapisy archiwalne?";
            this.cbShowArchiwum.UseVisualStyleBackColor = true;
            this.cbShowArchiwum.CheckedChanged += new System.EventHandler(this.cbShowArchiwum_CheckedChanged);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(573, 31);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 4;
            this.bClear.Text = "&Wyczyść";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(492, 31);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 3;
            this.bSearch.Text = "&Filtruj";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tTextToFind
            // 
            this.tTextToFind.Location = new System.Drawing.Point(265, 33);
            this.tTextToFind.Name = "tTextToFind";
            this.tTextToFind.Size = new System.Drawing.Size(221, 20);
            this.tTextToFind.TabIndex = 2;
            this.tTextToFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tTextToFind_KeyUp);
            // 
            // lToSearch
            // 
            this.lToSearch.AutoSize = true;
            this.lToSearch.Location = new System.Drawing.Point(12, 36);
            this.lToSearch.Name = "lToSearch";
            this.lToSearch.Size = new System.Drawing.Size(140, 13);
            this.lToSearch.TabIndex = 1;
            this.lToSearch.Text = "Wyszukiwanie w kolumnie...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.ustawieniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1250, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamknijToolStripMenuItem,
            this.toolStripSeparator2,
            this.listaZamówieńToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // listaZamówieńToolStripMenuItem
            // 
            this.listaZamówieńToolStripMenuItem.Name = "listaZamówieńToolStripMenuItem";
            this.listaZamówieńToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.listaZamówieńToolStripMenuItem.Text = "Lista zamówień";
            this.listaZamówieńToolStripMenuItem.Click += new System.EventHandler(this.listaZamówieńToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.użytkownicyToolStripMenuItem,
            this.statusyToolStripMenuItem,
            this.toolStripSeparator1,
            this.połączenieToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ustawieniaToolStripMenuItem.Text = "&Ustawienia";
            // 
            // użytkownicyToolStripMenuItem
            // 
            this.użytkownicyToolStripMenuItem.Name = "użytkownicyToolStripMenuItem";
            this.użytkownicyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.użytkownicyToolStripMenuItem.Text = "&Użytkownicy";
            this.użytkownicyToolStripMenuItem.Click += new System.EventHandler(this.użytkownicyToolStripMenuItem_Click);
            // 
            // statusyToolStripMenuItem
            // 
            this.statusyToolStripMenuItem.Name = "statusyToolStripMenuItem";
            this.statusyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.statusyToolStripMenuItem.Text = "&Statusy";
            this.statusyToolStripMenuItem.Click += new System.EventHandler(this.statusyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // połączenieToolStripMenuItem
            // 
            this.połączenieToolStripMenuItem.Name = "połączenieToolStripMenuItem";
            this.połączenieToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.połączenieToolStripMenuItem.Text = "&Połączenie";
            this.połączenieToolStripMenuItem.Click += new System.EventHandler(this.połączenieToolStripMenuItem_Click);
            // 
            // panelStopka
            // 
            this.panelStopka.Controls.Add(this.buttonZamknij);
            this.panelStopka.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStopka.Location = new System.Drawing.Point(0, 652);
            this.panelStopka.Name = "panelStopka";
            this.panelStopka.Size = new System.Drawing.Size(1250, 43);
            this.panelStopka.TabIndex = 1;
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(1163, 8);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 0;
            this.buttonZamknij.Text = "&Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1250, 590);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 695);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelStopka);
            this.Controls.Add(this.panelNaglowek);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Panel";
            this.Text = "Piaskownica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Panel_FormClosing);
            this.Load += new System.EventHandler(this.Panel_Load);
            this.panelNaglowek.ResumeLayout(false);
            this.panelNaglowek.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelStopka.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNaglowek;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem połączenieToolStripMenuItem;
        private System.Windows.Forms.Panel panelStopka;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.ToolStripMenuItem użytkownicyToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem statusyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem listaZamówieńToolStripMenuItem;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TextBox tTextToFind;
        private System.Windows.Forms.Label lToSearch;
        private System.Windows.Forms.CheckBox cbShowArchiwum;
        private System.Windows.Forms.Timer timer1;
    }
}

