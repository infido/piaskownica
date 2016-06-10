namespace Ewispergi
{
    partial class Zapytanie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zapytanie));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tSQL = new System.Windows.Forms.TextBox();
            this.bWykonaj = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bWykonaj);
            this.panel1.Controls.Add(this.tSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 50);
            this.panel1.TabIndex = 0;
            // 
            // tSQL
            // 
            this.tSQL.Location = new System.Drawing.Point(13, 13);
            this.tSQL.Name = "tSQL";
            this.tSQL.Size = new System.Drawing.Size(954, 20);
            this.tSQL.TabIndex = 0;
            // 
            // bWykonaj
            // 
            this.bWykonaj.Location = new System.Drawing.Point(974, 13);
            this.bWykonaj.Name = "bWykonaj";
            this.bWykonaj.Size = new System.Drawing.Size(66, 23);
            this.bWykonaj.TabIndex = 1;
            this.bWykonaj.Text = "Wykonaj";
            this.bWykonaj.UseVisualStyleBackColor = true;
            this.bWykonaj.Click += new System.EventHandler(this.bWykonaj_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1052, 555);
            this.dataGridView1.TabIndex = 1;
            // 
            // Zapytanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1052, 605);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zapytanie";
            this.Text = "Zapytanie";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bWykonaj;
        private System.Windows.Forms.TextBox tSQL;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}