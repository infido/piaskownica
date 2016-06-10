using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Ewispergi
{
    public partial class Zapytanie : Form
    {
        FbConnection fbc;
        public Zapytanie(FbConnection fbcon)
        {
            InitializeComponent();
            fbc = fbcon;
        }

        private void bWykonaj_Click(object sender, EventArgs e)
        {
            //SpecjalErrorMessage.setMessage(tSQL.Text, RodzajKomunikatuErr.ZapytanieSQL);
            if (tSQL.Text.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
            {
                FbDataAdapter fda = new FbDataAdapter(tSQL.Text, fbc);
                DataSet fds = new DataSet();
                DataView fDataView = new DataView();
                fds.Tables.Add("TAB");
                try
                {
                    fda.Fill(fds.Tables["TAB"]);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Błąd ładowania wartości SQL: " + ee.Message);
                    throw;
                }
                fDataView.Table = fds.Tables["TAB"];
                dataGridView1.DataSource = fDataView;
            }
            else
            {
                //tu trzeba dopisać dla insert update ...
            }
        }
    }
}
