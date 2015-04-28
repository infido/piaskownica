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
    public partial class Panel : Form
    {
        public ConnectionDB polaczenie;
        private FbDataAdapter fda;
        private DataSet fds;
        private DataView fDataView;
        private String strQuery;
        private String tabela;
        private Dictionary<string, string> cascheStatus;
        private string kolumna;

        private Int32 memberRow = -1;
        private Int32 memberColumn = -1;

        public Panel()
        {
            InitializeComponent();
            polaczenie = new ConnectionDB();
            Text = "Piaskownica " + Application.ProductVersion;
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            cacheStatus();
            wczytajDaneZamowien();
        }

        private void wczytajDaneZamowien()
        {
            dataGridView1.Columns.Clear();

            tabela = "ZAMOWIENIA";
            strQuery = "SELECT * from " + tabela;

            if (cbShowArchiwum.Checked == false)
            {
                strQuery += " where STATUS <> 'Archiwum' ";
            }

            fda = new FbDataAdapter(strQuery, polaczenie.getConnection());
            fds = new DataSet();
            fDataView = new DataView();
            fds.Tables.Add("TAB");
            //Text = "Piaskownica " + aktualnyContext;

            try
            {
                fda.Fill(fds.Tables["TAB"]);
                fDataView.Table = fds.Tables["TAB"];
                dataGridView1.DataSource = fDataView;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Błąd ładowania wartości: " + ee.Message);
                //throw;
            }

            timer1.Start();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["STATUS"].Visible = false;
            dataGridView1.Columns["PRACOWNIK"].Visible = false;

            dataGridView1.Columns["Z_DNIA"].Width = 75;
            dataGridView1.Columns["PRODUKT"].Width = 260;



            #region dodatkowoa kolumna z ustawieniem statusu

            // tworzymy nowy obiekt
            fds.Tables.Add("STATUSYTMP");
            // Dodajemy kolumy do zbioru
              //fds.Tables["STATUSYTMP"].Columns.Add("aktualnyStatus", typeof(string));
            // Dodajemy zawartość 
            fda = new FbDataAdapter("select STATUS,KOLOR from STATUSY", polaczenie.getConnection());
            try
            {
                fda.Fill(fds.Tables["STATUSYTMP"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania statusów do zamówień!: " + ex.Message);
                //throw;
            }

            DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
            col2.AutoComplete = false;
            col2.Name = "currstate";
            col2.HeaderText = "Aktualny_status";
            col2.FlatStyle = FlatStyle.Flat;
            col2.DataSource = fds.Tables["STATUSYTMP"];
            col2.ValueMember = "STATUS";
            col2.DisplayMember = "STATUS";
            col2.DataPropertyName = "STATUS";

            dataGridView1.Columns.Add(col2);

            #endregion
            #region dodatkowoa kolumna z ustawieniem pracownika

            // tworzymy nowy obiekt
            fds.Tables.Add("PRACOWNIKTMP");
            // Dodajemy kolumy do zbioru
            //fds.Tables["STATUSYTMP"].Columns.Add("aktualnyStatus", typeof(string));
            // Dodajemy zawartość 
            fda = new FbDataAdapter("select UZYTKOWNIK as PRACOWNIK from UZYTKOWNICY", polaczenie.getConnection());
            try
            {
                fda.Fill(fds.Tables["PRACOWNIKTMP"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania listy użytkowników do zamówień!: " + ex.Message);
                //throw;
            }

            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            col3.AutoComplete = false;
            col3.Name = "currpracownik";
            col3.HeaderText = "Pracownik";
            col3.FlatStyle = FlatStyle.Flat;
            col3.DataSource = fds.Tables["PRACOWNIKTMP"];
            col3.ValueMember = "PRACOWNIK";
            col3.DisplayMember = "PRACOWNIK";
            col3.DataPropertyName = "PRACOWNIK";

            dataGridView1.Columns.Add(col3);

            #endregion

            #region Wypełnieni rekordów w tabelce kolorami
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells["STATUS"].Value != null)
                {
                    try
                    {
                        string tmpKol = cascheStatus[(string)item.Cells["STATUS"].Value.ToString()];

                        if (tmpKol != "")
                        {
                            item.DefaultCellStyle.BackColor = (Color)zamianaKoloruNaColor(tmpKol);
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }

            }

            #endregion

            if (tTextToFind.Text.Length > 0 && kolumna!=null && kolumna!="")
            {
                bSearch.PerformClick();
            }
        }

        private void cacheStatus()
        {
            cascheStatus = new Dictionary<string, string>();
            strQuery = "SELECT STATUS, KOLOR from STATUSY";
            FbCommand cdk = new FbCommand("SELECT STATUS, KOLOR from STATUSY", polaczenie.getConnection());
            try
            {
                FbDataReader fdk = cdk.ExecuteReader();
                while (fdk.Read())
                {
                    cascheStatus.Add((string)fdk["STATUS"], (string)fdk["KOLOR"]);
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Błąd wczytywania statusów dla kolorów: " + ex.Message);
            }

        }

        private void połączenieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polaczenie.Show();
        }

        private void Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            polaczenie.Close();
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            dataGridView1.Columns.Clear();
            tabela = "UZYTKOWNICY";
            strQuery = "SELECT ID, UZYTKOWNIK from " + tabela;
            
            fda = new FbDataAdapter(strQuery, polaczenie.getConnection());
            fds = new DataSet();
            fDataView = new DataView();
            fds.Tables.Add("TAB");
            //Text = "Piaskownica " + aktualnyContext;

            try
            {
                fda.Fill(fds.Tables["TAB"]);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Błąd ładowania wartości: " + ee.Message);
                throw;
            }

            fDataView.Table = fds.Tables["TAB"];
            dataGridView1.DataSource = fDataView;

            dataGridView1.Columns["ID"].Visible = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (tabela.Equals("ZAMOWIENIA")) isEditing=true;
            
            if (tabela.Equals("UZYTKOWNICY") && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString() != "")
            {
                strQuery = "UPDATE " + tabela + "  SET UZYTKOWNIK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["UZYTKOWNIK"].Value.ToString() + "' WHERE ID=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value + ";";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd update: " + ex.Message);
                    //throw;
                }
            }
            else if (tabela.Equals("UZYTKOWNICY"))
            {
                strQuery = "INSERT INTO " + tabela + " (UZYTKOWNIK) VALUES ('" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["UZYTKOWNIK"].Value.ToString() + "');";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd insert: " + ex.Message);
                    //throw;
                }
                użytkownicyToolStripMenuItem.PerformClick();
            }
            else if (tabela.Equals("ZAMOWIENIA") && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString() != "")
            {
                strQuery = "UPDATE " + tabela;
                strQuery += " SET ";
                strQuery += "DOSTAWCA='" + dataGridView1.Rows[e.RowIndex].Cells["DOSTAWCA"].Value.ToString() + "', ";
                strQuery += "PRODUKT='" + dataGridView1.Rows[e.RowIndex].Cells["PRODUKT"].Value.ToString() + "', ";
                strQuery += "CENA='" + dataGridView1.Rows[e.RowIndex].Cells["CENA"].Value.ToString() + "', ";
                strQuery += "ZALICZKA='" + dataGridView1.Rows[e.RowIndex].Cells["ZALICZKA"].Value.ToString() + "', ";
                strQuery += "TELEFON='" + dataGridView1.Rows[e.RowIndex].Cells["TELEFON"].Value.ToString() + "', ";
                strQuery += "STATUS='" + dataGridView1.Rows[e.RowIndex].Cells["STATUS"].Value.ToString() + "', ";
                strQuery += "PRACOWNIK='" + dataGridView1.Rows[e.RowIndex].Cells["PRACOWNIK"].Value.ToString() + "', ";
                strQuery += "TOWAR_NA_MIEJSCU='" + dataGridView1.Rows[e.RowIndex].Cells["TOWAR_NA_MIEJSCU"].Value.ToString() + "'";
                strQuery += " WHERE ID=" + dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString() + ";";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd update zamówienie: " + ex.Message);
                    //throw;
                }
            }
            else if (tabela.Equals("STATUSY") && dataGridView1.CurrentRow!=null && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString() != "")
            {
                strQuery = "UPDATE " + tabela;
                strQuery += " SET ";
                strQuery += "STATUS='" + dataGridView1.Rows[e.RowIndex].Cells["STATUS"].Value.ToString() + "' ";
                strQuery += ", KOLOR='" + dataGridView1.Rows[e.RowIndex].Cells["KOLOR"].Value.ToString() + "' ";
                
                strQuery += " WHERE ID=" + dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString() + ";";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd update zamówienie: " + ex.Message);
                    //throw;
                }
            }
 
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Kolumna " + e.ColumnIndex + " Wiersz " + e.RowIndex);
            if (tabela.Equals("ZAMOWIENIA") && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value!=null 
                && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString() == "")
            {
                strQuery = "INSERT INTO " + tabela;
                strQuery += " (DOSTAWCA,PRODUKT,CENA,ZALICZKA,TELEFON,TOWAR_NA_MIEJSCU,STATUS,PRACOWNIK) ";
                strQuery += " VALUES (";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["DOSTAWCA"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["PRODUKT"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["CENA"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["ZALICZKA"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["TELEFON"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["TOWAR_NA_MIEJSCU"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["STATUS"].Value.ToString() + "', ";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["PRACOWNIK"].Value.ToString() + "'";
                strQuery += ") returning id;";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    dataGridView1.Rows[e.RowIndex].Cells["ID"].Value = (Int32)kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd insert zamówienie: " + ex.Message);
                    //throw;
                }
            }
            else if (tabela.Equals("STATUSY") && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value!=null &&
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString() == "")
            {
                string kol = "";
                if (e.ColumnIndex == 3 && dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    kol = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                else
                {
                    kol = dataGridView1.Rows[e.RowIndex].Cells["KOLOR"].Value.ToString();
                }
                //MessageBox.Show("Kolor " + kol);
                
                strQuery = "INSERT INTO " + tabela;
                strQuery += " (STATUS,KOLOR) ";
                strQuery += " VALUES (";
                strQuery += "'" + dataGridView1.Rows[e.RowIndex].Cells["STATUS"].Value.ToString() + "', ";
                strQuery += "'" + kol + "' ";
                strQuery += ") returning id;";
                try
                {
                    FbCommand kom = new FbCommand(strQuery, polaczenie.getConnection());
                    dataGridView1.Rows[e.RowIndex].Cells["ID"].Value = (Int32)kom.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd insert status: " + ex.Message);
                    //throw;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentKomorka(e);
            lToSearch.Text = "Kolumna do filtrowania: " + kolumna;
        }

        private void setCurrentKomorka(DataGridViewCellEventArgs e)
        {
            memberColumn = e.ColumnIndex;
            memberRow = e.RowIndex;
            kolumna = dataGridView1.Columns[e.ColumnIndex].Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                wczytajDaneZamowien();
                if (memberColumn >= 0 && memberRow >= 0)
                {
                    try
                    {
                        this.dataGridView1.CurrentCell = this.dataGridView1[memberColumn, memberRow];
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }
        }

        private void listaZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheStatus();
            wczytajDaneZamowien();
        }

        private void statusyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            dataGridView1.Columns.Clear();
            tabela = "STATUSY";
            strQuery = "SELECT ID, STATUS, KOLOR from " + tabela;

            fda = new FbDataAdapter(strQuery, polaczenie.getConnection());
            fds = new DataSet();
            fDataView = new DataView();
            fds.Tables.Add("TAB");
            //Text = "Piaskownica " + aktualnyContext;

            try
            {
                fda.Fill(fds.Tables["TAB"]);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Błąd ładowania wartości: " + ee.Message);
                throw;
            }

            fDataView.Table = fds.Tables["TAB"];
            dataGridView1.DataSource = fDataView;

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["KOLOR"].Visible = false;


            #region dodatkowoa kolumna z ustawieniem koloru

            // tworzymy nowy obiekt
            DataTable dt = new DataTable();
            // Dodajemy kolumy do zbioru
            dt.Columns.Add("nazwaKoloru", typeof(string));
            // Dodajemy zawartość 
            dt.Rows.Add("Standardowy");
            dt.Rows.Add("Niebieski");
            dt.Rows.Add("Zielony");
            dt.Rows.Add("Czerwony");
            dt.Rows.Add("Żółty");
            dt.Rows.Add("Pomarańczowy");

            DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
            col2.AutoComplete = false;
            //col2.Name = "kolortla";
            col2.HeaderText = "Kolor_Tła";
            col2.FlatStyle = FlatStyle.Flat;
            col2.DataSource = dt;
            col2.ValueMember = "nazwaKoloru";
            col2.DisplayMember = "nazwaKoloru";
            col2.DataPropertyName = "nazwaKoloru";
            
            dataGridView1.Columns.Add(col2);

            #endregion

            #region Wypełnieni rekordów w tabelce kolorami
            foreach  (DataGridViewRow item in this.dataGridView1.Rows)
            {
                item.Cells[3].Value = item.Cells["KOLOR"].Value;
                if (item.Cells["KOLOR"].Value == null)
                {
                    item.DefaultCellStyle.BackColor = Color.Empty;
                }else{
                item.DefaultCellStyle.BackColor = (Color)zamianaKoloruNaColor((string)item.Cells["KOLOR"].Value.ToString());
                }
            }

            #endregion
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //timer1.Start();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (
                (
                  (tabela.Equals("STATUSY") && dataGridView1.CurrentCell.ColumnIndex == 3) ||
                  (tabela.Equals("ZAMOWIENIA") && dataGridView1.CurrentCell.ColumnIndex >= 11)
                )
                && e.Control is ComboBox && dataGridView1.CurrentCell.RowIndex==memberRow)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            } 
        }
        
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = dataGridView1.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            DataGridViewTextBoxCell cel = null;
            if (tabela.Equals("STATUSY"))
            {
                cel = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells["KOLOR"];
            }
            else if (tabela.Equals("ZAMOWIENIA") && dataGridView1.CurrentCell.ColumnIndex==11)
            {
                cel = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells["STATUS"];
            }
            else if (tabela.Equals("ZAMOWIENIA") && dataGridView1.CurrentCell.ColumnIndex == 12)
            {
                cel = (DataGridViewTextBoxCell)dataGridView1.Rows[currentcell.Y].Cells["PRACOWNIK"];
            }
            try
            {
                cel.Value = sendingCB.EditingControlFormattedValue.ToString();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Nic nie ma robić...
        }

        private Color zamianaKoloruNaColor(string Kolor)
        {
            switch (Kolor)
            {
                case "Niebieski":
                    return Color.LightSkyBlue;
                    //break;
                case "Zielony":
                    return Color.GreenYellow;
                    //break;
                case "Czerwony":
                    return Color.Red;
                    //break;
                case "Żółty":
                    return Color.Yellow;
                    //break;
                case "Pomarańczowy":
                    return Color.Orange;
                    //break;
                default:
                    return Color.Empty;
                    //break;
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (kolumna != null)
                {
                    //filtrowanie tekstowe
                    if (kolumna.Equals("currpracownik"))
                        fDataView.RowFilter = "PRACOWNIK Like '%" + tTextToFind.Text + "%'";
                    else if (kolumna.Equals("currstate"))
                        fDataView.RowFilter = "STATUS Like '%" + tTextToFind.Text + "%'";  
                    else
                    fDataView.RowFilter = kolumna + " Like '%" + tTextToFind.Text + "%'";  
                    
                    dataGridView1.Refresh();
                }
                else
                    MessageBox.Show("Nie wskazano kolumny do wyszukania!", "Wyszukiwanie");
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tTextToFind.Text = "";
            fDataView.RowFilter = "";
            dataGridView1.Refresh();
        }

        private void tTextToFind_KeyUp(object sender, KeyEventArgs e)
        {
            bSearch.PerformClick();
        }

        private void cbShowArchiwum_CheckedChanged(object sender, EventArgs e)
        {
            if (tabela.Equals("ZAMOWIENIA"))
            {
                wczytajDaneZamowien();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //wejście do komórki
            setCurrentKomorka(e);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Stop();
        }


    }
}
