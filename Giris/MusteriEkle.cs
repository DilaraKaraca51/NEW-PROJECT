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

namespace Giris
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0OVAJQJ\\MSSQLSERVER01;Initial Catalog=Banka;Integrated Security=True");
        private void ekle_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("INSERT INTO Musteri ([TC No],AdSoyad,Adres,Telefon,Sifre,Bakiye,Durum) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtTC.Text);
            komut.Parameters.AddWithValue("@p2", txtadsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtadres.Text);
            komut.Parameters.AddWithValue("@p4", maskedTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", maskedbakiye.Text);
            komut.Parameters.AddWithValue("@p7", 1);

            baglanti.Open();

            

            if (txtTC.Text == "" || txtadsoyad.Text == "" || txtadres.Text == "" || maskedTelefon.Text == "")
            {
                MessageBox.Show("Tüm Alanları Doldurunuz");
            }
            else
            {
                int sonuc = komut.ExecuteNonQuery();
                if ( sonuc > 0)
                    MessageBox.Show("Yeni Müşteri Eklendi");
                else
                    MessageBox.Show("Yeni Müşteri Eklenemedi");
                txtTC.Text="";
                txtadsoyad.Text="";
                txtadres.Text="";
                maskedTelefon.Text="";
                maskedbakiye.Text="";


            }
            baglanti.Close();

        }
    }
}
