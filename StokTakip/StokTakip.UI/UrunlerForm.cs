using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.ORM;
using StokTakip.ORM.Entity;
using StokTakip.ORM.Facade;

namespace StokTakip.UI
{
    public partial class UrunlerForm : Form
    {
        public UrunlerForm()
        {
            InitializeComponent();
        }
        UrunlerORM urunlerORM = new UrunlerORM();
        KategorilerORM kategorilerORM = new KategorilerORM();
        private void UrunlerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urunlerORM.Select();
            cmbKategoriID.DisplayMember = "Ad";
            cmbKategoriID.ValueMember = "Id";
            cmbKategoriID.DataSource = kategorilerORM.Select();
        }

        Urunler urunler = new Urunler();
        private void button1_Click(object sender, EventArgs e)
        {

            urunler.UrunAd = txtAd.Text;
            urunler.Adet = txtAdet.Text;
            urunler.KategoriID = (int)cmbKategoriID.SelectedValue;
            
            bool sonuc = urunlerORM.Insert(urunler);
            if (sonuc)
            {
                MessageBox.Show("Kayit Eklenmiştir");
                dataGridView1.DataSource = urunlerORM.Select();
            }
            else
            {
                MessageBox.Show("Kayıt ekleme sırasında bir hata oluştu");
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
            txtAdet.Text = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();
            cmbKategoriID.SelectedValue = dataGridView1.Rows[seciliAlan].Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            urunler.ID = id;
            urunler.UrunAd = txtAd.Text;
            urunler.Adet = txtAdet.Text;
            urunler.KategoriID = (int)cmbKategoriID.SelectedValue;
            bool sonuc = urunlerORM.Update(urunler);
            if (sonuc)
            {
                MessageBox.Show("Kayit başarıyle güncellendi");
                dataGridView1.DataSource = urunlerORM.Select();
            }
            else
            {
                MessageBox.Show("Kayıt güncelleme sırasında bir hata oluştu");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            urunler.ID = id;
           
            bool sonuc = urunlerORM.Delete(urunler);
            if (sonuc)
            {
                MessageBox.Show("Kayit Başarıyla silinmiştir");
                dataGridView1.DataSource = urunlerORM.Select();
            }
            else
            {
                MessageBox.Show("Kayıt  silme sırasında bir hata oluştu");
            }

        }
    }

}

