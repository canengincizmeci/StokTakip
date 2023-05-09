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
    public partial class KategorilerForm : Form
    {
        public KategorilerForm()
        {
            InitializeComponent();
        }
        KategorilerORM kategorilerORM = new KategorilerORM();
        Kategoriler kategoriler = new Kategoriler();
        private void KategorilerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kategorilerORM.Select();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategoriler.Ad = txtAd.Text;
            bool sonuc = kategorilerORM.Insert(kategoriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt başarıyla eklendi");
                dataGridView1.DataSource = kategorilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt eklenirken bir hata oluştu");

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
            kategoriler.ID = id;
            kategoriler.Ad = txtAd.Text;
            bool sonuc = kategorilerORM.Update(kategoriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt Başrıyla Güncellendi");
                dataGridView1.DataSource = kategorilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt güncellenirken bir hata oluştu");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[seciliAlan].Cells[0].Value);
            kategoriler.ID = id;
            bool sonuc = kategorilerORM.Delete(kategoriler);
            if (sonuc)
            {
                MessageBox.Show("Kayıt başarıyla silindi");
                dataGridView1.DataSource = kategorilerORM.Select();
            }
            else
                MessageBox.Show("Kayıt silme başarısız");



        }
    }
}
