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
    public partial class MusteriSil : Form
    {
        public MusteriSil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0OVAJQJ\\MSSQLSERVER01;Initial Catalog=Banka;Integrated Security=True");
        private void BTNARA_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Musteri WHERE ID=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtıdgir.Text);

            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                txtID.Text=reader["ID"].ToString();
                txtADSOYAD.Text=reader["adsoyad"].ToString();
                txtADRES.Text=reader["adres"].ToString();
                maskedTELEFON.Text=reader["Telefon"].ToString();
                txtBakiye.Text=reader["bakiye"].ToString();
            }
            else
            {
                MessageBox.Show(txtID.Text + "Numaralı Kayıt Bulunamadı ");
                txtID.Text="";
                txtADRES.Text="";
                txtADSOYAD.Text="";
                maskedTELEFON.Text="";
                txtBakiye.Text="";
            }
            baglanti.Close();
        }

        private void BTNSİL_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE  Musteri WHERE ID=@p1",baglanti);
            komutsil.Parameters.AddWithValue("@p1", txtıdgir.Text);
            int sonuc = komutsil.ExecuteNonQuery();

            if(sonuc == 1)
            {
                MessageBox.Show("Kayıt Silindi");
            }
            else
            {
                MessageBox.Show("Kayıt Silinemedi");
            }
            baglanti.Close();
           
        }
    }
    
}
