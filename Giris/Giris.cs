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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Giris
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0OVAJQJ\\MSSQLSERVER01;Initial Catalog=Banka;Integrated Security=True");

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Giris WHERE Ad=@p1 AND Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                Musteri frm2 = new Musteri();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kulanıcı Adı veya Şifre");
            }
            baglanti.Close();

           
        }
    }
}
