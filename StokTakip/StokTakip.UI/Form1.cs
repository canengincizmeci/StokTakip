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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

            UrunlerForm urunlerForm = new UrunlerForm();
        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (urunlerForm.IsDisposed)
                urunlerForm = new UrunlerForm();
            urunlerForm.MdiParent = this;
            urunlerForm.Show();
        }
        MusterilerForm musterilerForm = new MusterilerForm();
        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (musterilerForm.IsDisposed)
                musterilerForm = new MusterilerForm();
            musterilerForm.MdiParent = this;
            musterilerForm.Show();
        }
        KategorilerForm kategorilerForm = new KategorilerForm();
        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kategorilerForm.IsDisposed)
                kategorilerForm = new KategorilerForm();
            kategorilerForm.MdiParent = this;
            kategorilerForm.Show();
        }
        SatislarForm satislarForm = new SatislarForm();
        private void satışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (satislarForm.IsDisposed)
                satislarForm = new SatislarForm();
            satislarForm.MdiParent = this;
            satislarForm.Show();
        }
    }
}
