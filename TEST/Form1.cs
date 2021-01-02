using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = "Server=SEYFITURAN;Database=TestDB;Trusted_Connection=True;";
                string query = "SELECT * FROM Kategori";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("HATA: " + exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Server=SEYFITURAN;Database=TestDB;Trusted_Connection=True;";
            string query = "SELECT * FROM Urun";

            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                if(con.State== ConnectionState.Open)
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Bağlantı kurulamadı...");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("HATA: " + exc.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = "Server=SEYFITURAN;Database=TestDB;Trusted_Connection=True;";
                string query = "select " +
                                    "Kat.KategoriAd , "+
	                                "Urn.UrunAdi, "+
	                                "Urn.Fiyat,  "+
	                                "Urn.StokMiktari as Miktar "+
                                "from Urun Urn "+
                                "left join Kategori Kat on Urn.KategoriId = Kat.KategoriId";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("HATA: " + exc.Message);
            }
        }
    }
}
