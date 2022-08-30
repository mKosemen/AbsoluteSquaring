using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbsoluteSquaring
{
    public partial class Form1 : Form
    {
        List<int> sayilar = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Rakam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtDeger.Text != "")
            {
                sayilar.Add(Convert.ToInt32(txtDeger.Text));
                txtDeger.Clear();
                MessageBox.Show("Toplam " + sayilar.Count + " adet sayı eklendi.");
            }
            else
            {
                MessageBox.Show("Lütfen bir sayı girişi yapınız.");
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            txtDeger.Clear();
            int kSayilar = 0;
            double bSayilar = 0;
            foreach (var item in sayilar)
            {
                if (item <= 67)
                {
                    kSayilar += (67 - item);
                }
                else
                {
                    bSayilar += Math.Pow((item - 67), 2);
                }
            }
            if (kSayilar==0)
            {
                txtDeger.Text = string.Join(", ", sayilar) + Environment.NewLine +  bSayilar;
                MessageBox.Show("67'den küçük sayı bulunmamaktadır.");
            }
            else if (bSayilar==0)
            {
                txtDeger.Text = string.Join(", ", sayilar) + Environment.NewLine + kSayilar;
                MessageBox.Show("67'den büyük sayı bulunmamaktadır.");
            }
            else
            {
                txtDeger.Text = string.Join(", ", sayilar) + Environment.NewLine + kSayilar + " " + bSayilar;
            }
            
        }
    }
}
