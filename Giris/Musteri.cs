using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Giris
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Giris frm = new Giris();
            frm.Show();
            this.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            MusteriEkle ekle = new MusteriEkle();
            ekle.Show();
            
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            MusteriGuncelle guncelle = new MusteriGuncelle();
            guncelle.Show();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            MusteriSil Sil = new MusteriSil();
            Sil.Show();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            MusteriListesi Listele = new MusteriListesi();
            Listele.Show();
        }

    }
}
