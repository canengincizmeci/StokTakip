using StokTakip.ORM.Entity;
using StokTakip.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.UI
{
    public partial class SatislarForm : Form
    {
        public SatislarForm()
        {
            InitializeComponent();
        }
        MusterilerORM musterilerORM = new MusterilerORM();
        SatislarORM satislarORM = new SatislarORM();
        UrunlerORM urunlerORM = new UrunlerORM();
        Satislar satıslar = new Satislar();
        private void SatislarForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislarORM.Select();
            cmbUrunID.DisplayMember = "UrunAd";
            cmbUrunID.ValueMember = "ID";
            cmbMusteriID.DisplayMember = "MusteriAd";
            cmbMusteriID.ValueMember = "ID";
            cmbMusteriID.DataSource = musterilerORM.Select();
            cmbUrunID.DataSource = urunlerORM.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satıslar.MusteriID = (int)cmbMusteriID.SelectedValue;
            satıslar.UrunID = (int)cmbUrunID.SelectedValue;
            bool sonuc = satislarORM.Insert(satıslar);
            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarıyla Kaydedildi");
                dataGridView1.DataSource = satislarORM.Select();
            }
            else
                MessageBox.Show("Kayıt Kaydedilirken hata oluştu");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            cmbMusteriID.SelectedValue = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
            cmbUrunID.SelectedValue = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            satıslar.ID = id;
            satıslar.MusteriID = (int)cmbMusteriID.SelectedValue;
            satıslar.UrunID = (int)cmbUrunID.SelectedValue;
            bool sonuc = satislarORM.Update(satıslar);
            if (sonuc)
            {
                MessageBox.Show("Kayıt başarıyla güncellendi");
                dataGridView1.DataSource = satislarORM.Select();
            }
            else
                MessageBox.Show("Kayıt güncellenirken hata oluştu");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            satıslar.ID = id;
            bool sonuc = satislarORM.Delete(satıslar);
            if (sonuc)
            {
                MessageBox.Show("Kayıt başarıyla silindi");
                dataGridView1.DataSource = satislarORM.Select();
            }
            else
                MessageBox.Show("Kayıt silme başarısız");


        }
    }
}
