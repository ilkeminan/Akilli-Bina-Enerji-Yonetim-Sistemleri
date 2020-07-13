using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Configuration;

namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    public partial class Fiyatlandirma : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        int baud_rate;
        string veri, sebeke;
        string buzdolabi, aydinlatma, camasir_makinesi, bulasik_makinesi, utu, kahve_makinesi, kullanici1, kullanici2, kullanici3, kullanici4, kullanici5, kullanici6;
        public Fiyatlandirma()
        {
            InitializeComponent();
            FiyatlandirmaDataGridiniDoldur();
            baud_rate = 115200;
            if (portlar.Length != 0)
            {
                timer1.Start();
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.PortName = portlar[0];
                    serialPort1.BaudRate = baud_rate;
                    try
                    {
                        serialPort1.Open();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata" + hata.Message);
                    }
                }
            }
        }

        private void Fiyatlandirma_FormClosing(object sender, FormClosingEventArgs e)
        {
            YukTuketimleri yukTuketimleri = new YukTuketimleri();
            yukTuketimleri.UpdateConfigKey("aydinlatma", "kapali");
            yukTuketimleri.UpdateConfigKey("utu", "kapali");
            yukTuketimleri.UpdateConfigKey("kahve_makinesi", "kapali");
        }

        private void Fiyatlandirma_Load(object sender, EventArgs e)
        {
            dataGridViewFiyatlandirma.ClearSelection();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                veri = serialPort1.ReadExisting();
                char[] spearator = { ',' };
                int count = 12;
                string[] strlist = veri.Split(spearator, count, StringSplitOptions.None);
                buzdolabi = strlist[0];
                aydinlatma = strlist[1];
                camasir_makinesi = strlist[2];
                bulasik_makinesi = strlist[3];
                utu = strlist[4];
                kahve_makinesi = strlist[5];
                kullanici2 = strlist[6];
                kullanici3 = strlist[7];
                kullanici4 = strlist[8];
                kullanici5 = strlist[9];
                kullanici6 = strlist[10];
                sebeke = strlist[11];
                Random rastgele = new Random();
                kullanici4 = rastgele.Next(7000).ToString();
                kullanici5 = rastgele.Next(7000).ToString();
                kullanici6 = rastgele.Next(7000).ToString();
                if (Convert.ToSingle(aydinlatma) == 0)
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("aydinlatma", "kapali");
                }
                else
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("aydinlatma", "acik");
                }
                if (Convert.ToSingle(utu) == 0)
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("utu", "kapali");
                }
                else
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("utu", "acik");
                }
                if (Convert.ToSingle(kahve_makinesi) == 0)
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("kahve_makinesi", "kapali");
                }
                else
                {
                    YukTuketimleri yukTuketimleri = new YukTuketimleri();
                    yukTuketimleri.UpdateConfigKey("kahve_makinesi", "acik");
                }
                ConfigurationManager.RefreshSection("appSettings");
                SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Yuk_Tuketimleri (Buzdolabi,Aydinlatma,Camasir_Makinesi,Bulasik_Makinesi,Utu,Kahve_Makinesi,Kullanici2,Kullanici3,Kullanici4,Kullanici5,Kullanici6) values('" + buzdolabi + "', '" + aydinlatma + "','" + camasir_makinesi + "', '" + bulasik_makinesi + "','" + utu + "','" + kahve_makinesi + "','" + kullanici2 + "','" + kullanici3 + "','" + kullanici4 + "','" + kullanici5 + "','" + kullanici6 + "') ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                FiyatlandirmaDataGridiniDoldur();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Fiyatlandirma_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                timer1.Stop();
                serialPort1.Close();
            }
        }

        public void FiyatlandirmaDataGridiniDoldur()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
            List<Kullanici> kullanicilar = new List<Kullanici>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            string[] kullanici1_yukler = new string[5000];
            string[] kullanici2_yukler = new string[5000];
            string[] kullanici3_yukler = new string[5000];
            string[] kullanici4_yukler = new string[5000];
            string[] kullanici5_yukler = new string[5000];
            string[] kullanici6_yukler = new string[5000];
            float[] kullanici1_fiyat = new float[5000];
            float[] kullanici2_fiyat = new float[5000];
            float[] kullanici3_fiyat = new float[5000];
            float[] kullanici4_fiyat = new float[5000];
            float[] kullanici5_fiyat = new float[5000];
            float[] kullanici6_fiyat = new float[5000];
            int i = 0;
            while (oku.Read())
            {
                buzdolabi = oku["Buzdolabi"].ToString();
                aydinlatma = oku["Aydinlatma"].ToString();
                camasir_makinesi = oku["Camasir_Makinesi"].ToString();
                bulasik_makinesi = oku["Bulasik_Makinesi"].ToString();
                utu = oku["Utu"].ToString();
                kahve_makinesi = oku["Kahve_Makinesi"].ToString();
                kullanici1_yukler[i] = (Convert.ToSingle(buzdolabi) + Convert.ToSingle(aydinlatma) + Convert.ToSingle(camasir_makinesi) + Convert.ToSingle(bulasik_makinesi) + Convert.ToSingle(utu) + Convert.ToSingle(kahve_makinesi)).ToString();
                kullanici2_yukler[i] = oku["Kullanici2"].ToString();
                kullanici3_yukler[i] = oku["Kullanici3"].ToString();
                kullanici4_yukler[i] = oku["Kullanici4"].ToString();
                kullanici5_yukler[i] = oku["Kullanici5"].ToString();
                kullanici6_yukler[i] = oku["Kullanici6"].ToString();
                i++;
            }
            int length = i;
            for(i = 0; i < length; i++)
            {
                kullanici1_fiyat[i] = 0;
                kullanici2_fiyat[i] = 0;
                kullanici3_fiyat[i] = 0;
                kullanici4_fiyat[i] = 0;
                kullanici5_fiyat[i] = 0;
                kullanici6_fiyat[i] = 0;
                int j;
                for (j = 0; j <= i; j++)
                {
                    kullanici1_fiyat[i] = kullanici1_fiyat[i] + Convert.ToSingle(kullanici1_yukler[j]);
                    kullanici2_fiyat[i] = kullanici2_fiyat[i] + Convert.ToSingle(kullanici2_yukler[j]);
                    kullanici3_fiyat[i] = kullanici3_fiyat[i] + Convert.ToSingle(kullanici3_yukler[j]);
                    kullanici4_fiyat[i] = kullanici4_fiyat[i] + Convert.ToSingle(kullanici4_yukler[j]);
                    kullanici5_fiyat[i] = kullanici5_fiyat[i] + Convert.ToSingle(kullanici5_yukler[j]);
                    kullanici6_fiyat[i] = kullanici6_fiyat[i] + Convert.ToSingle(kullanici6_yukler[j]);
                }
                kullanici1_fiyat[i] = (kullanici1_fiyat[i] * 10/100 )/ j;
                kullanici2_fiyat[i] = (kullanici2_fiyat[i] * 10 / 100) / j;
                kullanici3_fiyat[i] = (kullanici3_fiyat[i] * 10 / 100) / j;
                kullanici4_fiyat[i] = (kullanici4_fiyat[i] * 10 / 100) / j;
                kullanici5_fiyat[i] = (kullanici5_fiyat[i] * 10 / 100) / j;
                kullanici6_fiyat[i] = (kullanici6_fiyat[i] * 10 / 100) / j;
            }
            for (i = length - 1; i >= 0; i--)
            {
                if (i == length - 1)
                {
                    kullanicilar.Add(new Kullanici { Zaman = "Şimdi", Kullanici1 = kullanici1_fiyat[i].ToString() + " TL", Kullanici2 = kullanici2_fiyat[i].ToString() + " TL", Kullanici3 = kullanici3_fiyat[i].ToString() + " TL", Kullanici4 = kullanici4_fiyat[i].ToString() + " TL", Kullanici5 = kullanici5_fiyat[i].ToString() + " TL", Kullanici6 = kullanici6_fiyat[i].ToString() + " TL" });
                }
                else
                {
                    string zaman = (length - 1 - i).ToString() + " saat önce";
                    kullanicilar.Add(new Kullanici { Zaman = zaman, Kullanici1 = kullanici1_fiyat[i].ToString()+" TL", Kullanici2 = kullanici2_fiyat[i].ToString() + " TL", Kullanici3 = kullanici3_fiyat[i].ToString() + " TL", Kullanici4 = kullanici4_fiyat[i].ToString() + " TL", Kullanici5 = kullanici5_fiyat[i].ToString() + " TL", Kullanici6 = kullanici6_fiyat[i].ToString() + " TL" });
                }
                
            }
            dataGridViewFiyatlandirma.DataSource = kullanicilar;
            dataGridViewFiyatlandirma.Columns[0].HeaderCell.Value = "Zaman";
            dataGridViewFiyatlandirma.Columns[1].HeaderCell.Value = "Kullanıcı 1";
            dataGridViewFiyatlandirma.Columns[2].HeaderCell.Value = "Kullanıcı 2";
            dataGridViewFiyatlandirma.Columns[3].HeaderCell.Value = "Kullanıcı 3";
            dataGridViewFiyatlandirma.Columns[4].HeaderCell.Value = "Kullanıcı 4";
            dataGridViewFiyatlandirma.Columns[5].HeaderCell.Value = "Kullanıcı 5";
            dataGridViewFiyatlandirma.Columns[6].HeaderCell.Value = "Kullanıcı 6";
            dataGridViewFiyatlandirma.ClearSelection();
        }

        private void ButtonGrafik_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();
            Grafik grafik = new Grafik("fiyatlandirma");
            this.Visible = false;
            grafik.Show();
        }

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();
            Form1 ana_pencere = new Form1();
            this.Visible = false;
            ana_pencere.Show();
        }
    }
}
