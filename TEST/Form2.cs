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
    public partial class Form2 : Form
    {
        const string constr = "Server=SEYFITURAN;Database=TestDB;Trusted_Connection=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }
        private void KategoriGetir()
        {
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

        private void button1_Click(object sender, EventArgs e)
        {            
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string query = string.Format("insert into Kategori values('{0}')", textBox1.Text);
                        SqlCommand comm = new SqlCommand(query, con);
                        int retVal = comm.ExecuteNonQuery();
                        if (retVal > 0)
                        {
                            MessageBox.Show(" Kategori Kaydedildi...");
                            KategoriGetir();
                        }
                    }
                    else
                        MessageBox.Show("Bağlantı Kurulamadı...");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("HATA: " + exc.Message);
            }
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (txtKategoriAd.Text != string.Empty && txtKategoriId.Text != string.Empty)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string query = string.Format("update Kategori set KategoriAd='{0}' where KategoriId={1}", txtKategoriAd.Text,txtKategoriId.Text);
                            SqlCommand comm = new SqlCommand(query, con);
                            int retVal = comm.ExecuteNonQuery();
                            if (retVal > 0)
                            {
                                MessageBox.Show(" Kategori Güncellendi...");
                                KategoriGetir();
                            }
                        }
                        else
                            MessageBox.Show("Bağlantı Kurulamadı...");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("HATA: " + exc.Message);
                }
            }
            else
                MessageBox.Show("Kategori Id ve Kategori Adı Girmelisiniz...");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtKategoriIds.Text != string.Empty)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string query = string.Format("delete from Kategori where KategoriId={0}", txtKategoriIds.Text);
                            SqlCommand comm = new SqlCommand(query, con);
                            int retVal = comm.ExecuteNonQuery();
                            if (retVal > 0)
                            {
                                MessageBox.Show(" Kategori Silindi...");
                                KategoriGetir();
                            }
                        }
                        else
                            MessageBox.Show("Bağlantı Kurulamadı...");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("HATA: " + exc.Message);
                }
            }
            else
                MessageBox.Show("Kategori Id Girmelisiniz...");
        }
    }
}
