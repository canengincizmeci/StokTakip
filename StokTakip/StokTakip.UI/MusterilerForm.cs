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
    public partial class MusterilerForm : Form
    {
        public MusterilerForm()
        {
            InitializeComponent();
        }

        MusterilerORM musterilerORM = new MusterilerORM();
        Musteriler musteriler = new Musteriler();
        private void MusterilerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = musterilerORM.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriler.MusteriAd = txtAd.Text;
            bool sonuc = musterilerORM.Insert(musteriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt Ekleme Başarılı");
                dataGridView1.DataSource = musterilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt ekleme başarısız");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            musteriler.ID = id;
            musteriler.MusteriAd = txtAd.Text;
            bool sonuc = musterilerORM.Update(musteriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt güncelleme başarılı");
                dataGridView1.DataSource = musterilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt güncelleme başarısız");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            musteriler.ID = id;
            bool sonuc = musterilerORM.Delete(musteriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt başarıyla silindi");
                dataGridView1.DataSource = musterilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt silme başarısız");
        }
    }
}
