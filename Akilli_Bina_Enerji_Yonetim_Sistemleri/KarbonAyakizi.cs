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
    public partial class KarbonAyakizi : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        int baud_rate;
        string veri, sebeke;
        string buzdolabi, aydinlatma, camasir_makinesi, bulasik_makinesi, utu, kahve_makinesi, kullanici1, kullanici2, kullanici3, kullanici4, kullanici5, kullanici6;
        public KarbonAyakizi()
        {
            InitializeComponent();
            KarbonAyakiziDataGridiniDoldur();
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

        private void KarbonAyakizi_FormClosing(object sender, FormClosingEventArgs e)
        {
            YukTuketimleri yukTuketimleri = new YukTuketimleri();
            yukTuketimleri.UpdateConfigKey("aydinlatma", "kapali");
            yukTuketimleri.UpdateConfigKey("utu", "kapali");
            yukTuketimleri.UpdateConfigKey("kahve_makinesi", "kapali");
        }

        private void KarbonAyakizi_Load(object sender, EventArgs e)
        {
            dataGridViewKarbonAyakizi.ClearSelection();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                veri = serialPort1.ReadExisting();
                char[] spearator = { ',' };
                int count = 12;
                string[] strlist = veri.Split(spearator, count, StringSplitOptions.None);
                string buzdolabi = strlist[0];
                string aydinlatma = strlist[1];
                string camasir_makinesi = strlist[2];
                string bulasik_makinesi = strlist[3];
                string utu = strlist[4];
                string kahve_makinesi = strlist[5];
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
                KarbonAyakiziDataGridiniDoldur();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void KarbonAyakizi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                timer1.Stop();
            }
        }

        public void KarbonAyakiziDataGridiniDoldur()
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
            float[] kullanici1_karbon_ayak_izi = new float[5000];
            float[] kullanici2_karbon_ayak_izi = new float[5000];
            float[] kullanici3_karbon_ayak_izi = new float[5000];
            float[] kullanici4_karbon_ayak_izi = new float[5000];
            float[] kullanici5_karbon_ayak_izi = new float[5000];
            float[] kullanici6_karbon_ayak_izi = new float[5000];
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
            for (i = 0; i < length; i++)
            {
                kullanici1_karbon_ayak_izi[i] = 0;
                kullanici2_karbon_ayak_izi[i] = 0;
                kullanici3_karbon_ayak_izi[i] = 0;
                kullanici4_karbon_ayak_izi[i] = 0;
                kullanici5_karbon_ayak_izi[i] = 0;
                kullanici6_karbon_ayak_izi[i] = 0;
                int j;
                for (j = 0; j <= i; j++)
                {
                    kullanici1_karbon_ayak_izi[i] = kullanici1_karbon_ayak_izi[i] + Convert.ToSingle(kullanici1_yukler[j]);
                    kullanici2_karbon_ayak_izi[i] = kullanici2_karbon_ayak_izi[i] + Convert.ToSingle(kullanici2_yukler[j]);
                    kullanici3_karbon_ayak_izi[i] = kullanici3_karbon_ayak_izi[i] + Convert.ToSingle(kullanici3_yukler[j]);
                    kullanici4_karbon_ayak_izi[i] = kullanici4_karbon_ayak_izi[i] + Convert.ToSingle(kullanici4_yukler[j]);
                    kullanici5_karbon_ayak_izi[i] = kullanici5_karbon_ayak_izi[i] + Convert.ToSingle(kullanici5_yukler[j]);
                    kullanici6_karbon_ayak_izi[i] = kullanici6_karbon_ayak_izi[i] + Convert.ToSingle(kullanici6_yukler[j]);
                }
                kullanici1_karbon_ayak_izi[i] = (kullanici1_karbon_ayak_izi[i] * 0.001388f / 100) / j;
                kullanici2_karbon_ayak_izi[i] = (kullanici2_karbon_ayak_izi[i] * 0.001388f / 100) / j;
                kullanici3_karbon_ayak_izi[i] = (kullanici3_karbon_ayak_izi[i] * 0.001388f / 100) / j;
                kullanici4_karbon_ayak_izi[i] = (kullanici4_karbon_ayak_izi[i] * 0.001388f / 100) / j;
                kullanici5_karbon_ayak_izi[i] = (kullanici5_karbon_ayak_izi[i] * 0.001388f / 100) / j;
                kullanici6_karbon_ayak_izi[i] = (kullanici6_karbon_ayak_izi[i] * 0.001388f / 100) / j;
            }
            for (i = length - 1; i >= 0; i--)
            {
                if (i == length - 1)
                {
                    kullanicilar.Add(new Kullanici { Zaman = "Şimdi", Kullanici1 = kullanici1_karbon_ayak_izi[i].ToString()+" ton", Kullanici2 = kullanici2_karbon_ayak_izi[i].ToString() + " ton", Kullanici3 = kullanici3_karbon_ayak_izi[i].ToString() + " ton", Kullanici4 = kullanici4_karbon_ayak_izi[i].ToString() + " ton", Kullanici5 = kullanici5_karbon_ayak_izi[i].ToString() + " ton", Kullanici6 = kullanici6_karbon_ayak_izi[i].ToString() + " ton" });
                }
                else
                {
                    string zaman = (length - 1 - i).ToString() + " saat önce";
                    kullanicilar.Add(new Kullanici { Zaman = zaman, Kullanici1 = kullanici1_karbon_ayak_izi[i].ToString() + " ton", Kullanici2 = kullanici2_karbon_ayak_izi[i].ToString() + " ton", Kullanici3 = kullanici3_karbon_ayak_izi[i].ToString() + " ton", Kullanici4 = kullanici4_karbon_ayak_izi[i].ToString() + " ton", Kullanici5 = kullanici5_karbon_ayak_izi[i].ToString() + " ton", Kullanici6 = kullanici6_karbon_ayak_izi[i].ToString() + " ton" });
                }
            }
            dataGridViewKarbonAyakizi.DataSource = kullanicilar;
            dataGridViewKarbonAyakizi.Columns[0].HeaderCell.Value = "Zaman";
            dataGridViewKarbonAyakizi.Columns[1].HeaderCell.Value = "Kullanıcı 1";
            dataGridViewKarbonAyakizi.Columns[2].HeaderCell.Value = "Kullanıcı 2";
            dataGridViewKarbonAyakizi.Columns[3].HeaderCell.Value = "Kullanıcı 3";
            dataGridViewKarbonAyakizi.Columns[4].HeaderCell.Value = "Kullanıcı 4";
            dataGridViewKarbonAyakizi.Columns[5].HeaderCell.Value = "Kullanıcı 5";
            dataGridViewKarbonAyakizi.Columns[6].HeaderCell.Value = "Kullanıcı 6";
            dataGridViewKarbonAyakizi.ClearSelection();
        }

        private void ButtonGrafik_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();
            Grafik grafik = new Grafik("karbon_ayakizi");
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
    public class Kullanici
    {
        public string Zaman { get; set; }
        public string Kullanici1 { get; set; }
        public string Kullanici2 { get; set; }
        public string Kullanici3 { get; set; }
        public string Kullanici4 { get; set; }
        public string Kullanici5 { get; set; }
        public string Kullanici6 { get; set; }
    }
}
