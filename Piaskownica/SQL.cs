using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Piaskownica
{
    public partial class SQL : Form
    {
        FbConnection polaczenie;
        
        public SQL(FbConnection conn)
        {
            InitializeComponent();
            polaczenie = conn;
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            FbCommand cdk = new FbCommand(tSQL.Text, polaczenie);
            try
            {
                tresult.Text = cdk.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
                throw;
            }
        }
    }
}
