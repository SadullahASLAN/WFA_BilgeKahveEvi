using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_BilgeKahveEvi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] kahveler = { "Misto", "Americano", "Bianco", "Cappucino", "Macchiato", "Con Panna", "Mocha" };
        string[] sogukIcecekler = { "Buzlu Caffee Latte", "Ice Americano", "Espresso Frappe", "Buzlu Caramel Crest"};
        string[] sicakIcecekler = { "Çay", "Hot Chocolate", "Chai Tea Latte" };

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbKahve.Items.AddRange(kahveler);
            cmbSogukIcecekler.Items.AddRange(sogukIcecekler);
            cmbSicakIcecekler.Items.AddRange(sicakIcecekler);
        }

        decimal toplamTutar;

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            SiparisKontrol();
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || string.IsNullOrWhiteSpace(txtTelefonNumarasi.Text) || string.IsNullOrWhiteSpace(txtAdres.Text) || comboBoxSecimAdet != 1 || !boyutSecimKontrol)
            {
                MessageBox.Show("Hesaplama yapılabilmesi için müşterinin \"Ad, Soyad, Adres\" bilgilerini, ürünlerden sadece birinin seçimi ve adet bilgisi, son olarakta boyut seçilmelidir.", "Bilgileri kontrol ederek tekrar giriniz.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Siparis sprs = new Siparis();
                foreach (Control ctr in groupBox3.Controls)
                {
                    if (ctr is RadioButton && (ctr as RadioButton).Checked == true)
                    {
                        sprs.Boyut = ctr.Text;
                    }
                    if (ctr is CheckBox && (ctr as CheckBox).Checked == true)
                    {
                        sprs.Shot = ctr.Text;
                    }
                }
                foreach (Control ctrl in groupBox2.Controls)
                {
                    if (ctrl is NumericUpDown && (ctrl as NumericUpDown).Value != 0)
                    {
                        sprs.Adet = Convert.ToInt32((ctrl as NumericUpDown).Value);
                    }
                    if (ctrl is ComboBox && (ctrl as ComboBox).SelectedIndex != -1)
                    {
                        sprs.Icecek = (ctrl as ComboBox).Text;
                        break;

                    }
                }
                if (rbSutYagsiz.Checked == true)
                {
                    sprs.Sut = rbSutYagsiz.Text;
                }
                else if (rbSutSoya.Checked == true)
                {
                    sprs.Sut = rbSutSoya.Text;
                }
                lstSiparisler.Items.Add(sprs);
                toplamTutar += sprs.Fiyat;
                lblToplamTutar.Text = toplamTutar.ToString("c2");
            }

            SiparisTemizle();
        }

        void SiparisTemizle()
        {
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedIndex = -1;
                }
                if (ctrl is NumericUpDown)
                {
                    (ctrl as NumericUpDown).Value = 0;
                }
                if (ctrl is GroupBox)
                {
                    foreach (Control x in ctrl.Controls)
                    {
                        if (x is CheckBox)
                        {
                            (x as CheckBox).Checked = false;
                        }
                        if (x is RadioButton)
                        {
                            (x as RadioButton).Checked = false;
                        }
                        if (x is Panel)
                        {
                            foreach (Control y in x.Controls)
                            {
                                (y as RadioButton).Checked = false;
                            }
                        }
                    }
                }
            }
        }

        void FormTemizle()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
            }
            lstSiparisler.Items.Clear();
            SiparisTemizle();
        }

        int comboBoxSecimAdet;

        bool boyutSecimKontrol;

        void SiparisKontrol()
        {
            comboBoxSecimAdet = 0;
            boyutSecimKontrol = false;
            ComboBox[] cmb = { cmbKahve, cmbSogukIcecekler, cmbSicakIcecekler };
            NumericUpDown[] nud = { nudKahveAdet, nudSogukİceceklerAdet, nudSicakIceceklerAdet };
            RadioButton[] rb = { rbBoyutTall, rbBoyutGrande, rbBoyutVenti };
            for (int i = 0; i < cmb.Count(); i++)
            {
                if (cmb[i].SelectedIndex != -1 && nud[i].Value != 0)
                {
                    comboBoxSecimAdet++;
                }
                if (rb[i].Checked)
                {
                    boyutSecimKontrol = true;
                }
            }

        }

        MusteriSiparis[] ms = new MusteriSiparis[0];

        int dizi = 0;

        private void BtnSiparisVer_Click(object sender, EventArgs e)
        {
            MusteriSiparis musteri = new MusteriSiparis();
            musteri.adiSoyadi = txtAdSoyad.Text;
            musteri.telefonNumarasi = txtTelefonNumarasi.Text;
            musteri.adresi = txtAdres.Text;
            foreach (Siparis sprs in lstSiparisler.Items)
            {
                musteri.siparisleri.Add(sprs);
            }
            dizi++;
            Array.Resize(ref ms, dizi);
            ms[dizi - 1] = musteri;
            MessageBox.Show($"Toplam {musteri.siparisleri.Count} adet siparişiniz {toplamTutar.ToString("c2")} tutarındadır.");
            FormTemizle();
            toplamTutar = 0;
            lblToplamTutar.Text = toplamTutar.ToString("c2");
        }
    }
}
