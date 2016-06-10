namespace Piaskownica
{
    partial class SQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQL));
            this.tSQL = new System.Windows.Forms.TextBox();
            this.bRun = new System.Windows.Forms.Button();
            this.tresult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tSQL
            // 
            this.tSQL.Location = new System.Drawing.Point(13, 13);
            this.tSQL.Name = "tSQL";
            this.tSQL.Size = new System.Drawing.Size(683, 20);
            this.tSQL.TabIndex = 0;
            // 
            // bRun
            // 
            this.bRun.Location = new System.Drawing.Point(702, 10);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 1;
            this.bRun.Text = "Wykonaj";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // tresult
            // 
            this.tresult.Location = new System.Drawing.Point(13, 49);
            this.tresult.Multiline = true;
            this.tresult.Name = "tresult";
            this.tresult.Size = new System.Drawing.Size(764, 33);
            this.tresult.TabIndex = 2;
            // 
            // SQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 99);
            this.Controls.Add(this.tresult);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.tSQL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SQL";
            this.Text = "SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tSQL;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.TextBox tresult;
    }
}