using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Giris
{
    public partial class MusteriGuncelle : Form
    {
        public MusteriGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0OVAJQJ\\MSSQLSERVER01;Initial Catalog=Banka;Integrated Security=True");
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE  Musteri SET AdSoyad=@p1,Adres=@p2,Telefon=@p3,Bakiye=@p4 WHERE ID=@p5", baglanti);
            komut.Parameters.AddWithValue("@p5", txtID.Text);
            komut.Parameters.AddWithValue("@p1", txtadsoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtadres.Text);
            komut.Parameters.AddWithValue("@p3", maskedTelefon.Text);
            komut.Parameters.AddWithValue("@p4", txtbakiye.Text);

            baglanti.Open();

            int sonuc = komut.ExecuteNonQuery();

            if (sonuc == 1)
            {
                MessageBox.Show("Güncelleme Yapıldı");
            }
            else
            { 
                MessageBox.Show("Güncelleme Yapılmadı");
                txtID.Text="";
                txtadsoyad.Text="";
                txtadres.Text="";
                maskedTelefon.Text="";
                txtbakiye.Text="";
            }
            baglanti.Close();
        }

        private void Btnara_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Musteri WHERE ID=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtıdno.Text);

            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                txtID.Text=reader["ID"].ToString();
                txtadsoyad.Text=reader["adsoyad"].ToString();
                txtadres.Text=reader["adres"].ToString();
                maskedTelefon.Text=reader["Telefon"].ToString();
                txtbakiye.Text=reader["bakiye"].ToString();
            }
            else
            {
                MessageBox.Show(txtID.Text + "Numaralı Kayıt Bulunamadı ");
                txtID.Text="";
                txtadres.Text="";
                txtadsoyad.Text="";
                maskedTelefon.Text="";
                txtbakiye.Text="";
            }
            baglanti.Close();
        }

      
    }
}
