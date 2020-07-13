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
    public partial class Grafik : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        int baud_rate;
        string veri, sebeke;
        string buzdolabi, aydinlatma, camasir_makinesi, bulasik_makinesi, utu, kahve_makinesi, kullanici1, kullanici2, kullanici3, kullanici4, kullanici5, kullanici6;
        string tur;
        public Grafik(string tur)
        {
            InitializeComponent();
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
            this.tur = tur;
            GrafigiDoldur();
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
                /*if (Convert.ToSingle(aydinlatma) == 0)
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
                ConfigurationManager.RefreshSection("appSettings");*/
                SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Yuk_Tuketimleri (Buzdolabi,Aydinlatma,Camasir_Makinesi,Bulasik_Makinesi,Utu,Kahve_Makinesi,Kullanici2,Kullanici3,Kullanici4,Kullanici5,Kullanici6) values('" + buzdolabi + "', '" + aydinlatma + "','" + camasir_makinesi + "', '" + bulasik_makinesi + "','" + utu + "','" + kahve_makinesi + "','" + kullanici2 + "','" + kullanici3 + "','" + kullanici4 + "','" + kullanici5 + "','" + kullanici6 + "') ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                GrafigiDoldur();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Grafik_FormClosing(object sender, FormClosingEventArgs e)
        {
            YukTuketimleri yukTuketimleri = new YukTuketimleri();
            yukTuketimleri.UpdateConfigKey("aydinlatma", "kapali");
            yukTuketimleri.UpdateConfigKey("utu", "kapali");
            yukTuketimleri.UpdateConfigKey("kahve_makinesi", "kapali");
        }

        private void Grafik_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                timer1.Stop();
                serialPort1.Close();
            }
        }

        public void GrafigiDoldur()
        {
            string[] kullanici1_yukler = new string[5000];
            string[] kullanici2_yukler = new string[5000];
            string[] kullanici3_yukler = new string[5000];
            string[] kullanici4_yukler = new string[5000];
            string[] kullanici5_yukler = new string[5000];
            string[] kullanici6_yukler = new string[5000];
            string[] buzdolabi_yukler = new string[5000];
            string[] aydinlatma_yukler = new string[5000];
            string[] camasir_makinesi_yukler = new string[5000];
            string[] bulasik_makinesi_yukler = new string[5000];
            string[] utu_yukler = new string[5000];
            string[] kahve_makinesi_yukler = new string[5000];
            if (tur.Equals("kullanici1_yuk_tuketimi"))
            {
                SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri ORDER BY id DESC", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                int i = 0;
                while (oku.Read() && i<10)
                {
                    buzdolabi_yukler[i] = oku["Buzdolabi"].ToString();
                    aydinlatma_yukler[i] = oku["Aydinlatma"].ToString();
                    camasir_makinesi_yukler[i] = oku["Camasir_Makinesi"].ToString();
                    bulasik_makinesi_yukler[i] = oku["Bulasik_Makinesi"].ToString();
                    utu_yukler[i] = oku["Utu"].ToString();
                    kahve_makinesi_yukler[i] = oku["Kahve_Makinesi"].ToString();
                    i++;
                }
                baglanti.Close();
                int length = i;
                chart1.Series[0].LegendText = "Buzdolabı Yük Tüketimi";
                for (i = length-1; i > 0; i--)
                {
                    chart1.Series[0].Points.AddXY(i.ToString()+" saat önce", Convert.ToSingle(buzdolabi_yukler[i]));
                }
                chart1.Series[0].Points.AddXY("Şimdi", Convert.ToSingle(buzdolabi_yukler[0]));
                chart1.Series[1].LegendText = "Aydınlatma Yük Tüketimi";
                for (i = length - 1; i > 0; i--)
                {
                    chart1.Series[1].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(aydinlatma_yukler[i]));
                }
                chart1.Series[1].Points.AddXY("Şimdi", Convert.ToSingle(aydinlatma_yukler[0]));
                chart1.Series[2].LegendText = "Çamaşır Makinesi Yük Tüketimi";
                for (i = length - 1; i > 0; i--)
                {
                    chart1.Series[2].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(camasir_makinesi_yukler[i]));
                }
                chart1.Series[2].Points.AddXY("Şimdi", Convert.ToSingle(camasir_makinesi_yukler[0]));
                chart1.Series[3].LegendText = "Bulaşık Makinesi Yük Tüketimi";
                for (i = length - 1; i > 0; i--)
                {
                    chart1.Series[3].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(bulasik_makinesi_yukler[i]));
                }
                chart1.Series[3].Points.AddXY("Şimdi", Convert.ToSingle(bulasik_makinesi_yukler[0]));
                chart1.Series[4].LegendText = "Ütü Yük Tüketimi";
                for (i = length - 1; i > 0; i--)
                {
                    chart1.Series[4].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(utu_yukler[i]));
                }
                chart1.Series[4].Points.AddXY("Şimdi", Convert.ToSingle(utu_yukler[0]));
                chart1.Series[5].LegendText = "Kahve Makinesi Yük Tüketimi";
                for (i = length - 1; i > 0; i--)
                {
                    chart1.Series[5].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kahve_makinesi_yukler[i]));
                }
                chart1.Series[5].Points.AddXY("Şimdi", Convert.ToSingle(kahve_makinesi_yukler[0]));
            }
            else
            {
                if (tur.Equals("tum_kullanicilar_yuk_tuketimi"))
                {
                    SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri ORDER BY id DESC", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    int i = 0;
                    while (oku.Read() && i<10)
                    {
                        buzdolabi_yukler[i] = oku["Buzdolabi"].ToString();
                        aydinlatma_yukler[i] = oku["Aydinlatma"].ToString();
                        camasir_makinesi_yukler[i] = oku["Camasir_Makinesi"].ToString();
                        bulasik_makinesi_yukler[i] = oku["Bulasik_Makinesi"].ToString();
                        utu_yukler[i] = oku["Utu"].ToString();
                        kahve_makinesi_yukler[i] = oku["Kahve_Makinesi"].ToString();
                        kullanici1_yukler[i] = (Convert.ToSingle(buzdolabi_yukler[i]) + Convert.ToSingle(aydinlatma_yukler[i]) + Convert.ToSingle(camasir_makinesi_yukler[i]) + Convert.ToSingle(bulasik_makinesi_yukler[i]) + Convert.ToSingle(utu_yukler[i]) + Convert.ToSingle(kahve_makinesi_yukler[i])).ToString();
                        kullanici2_yukler[i] = oku["Kullanici2"].ToString();
                        kullanici3_yukler[i] = oku["Kullanici3"].ToString();
                        kullanici4_yukler[i] = oku["Kullanici4"].ToString();
                        kullanici5_yukler[i] = oku["Kullanici5"].ToString();
                        kullanici6_yukler[i] = oku["Kullanici6"].ToString();
                        i++;
                    }
                    baglanti.Close();
                    int length = i;
                    chart1.Series[0].LegendText = "1. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[0].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici1_yukler[i]));
                    }
                    chart1.Series[0].Points.AddXY("Şimdi", Convert.ToSingle(kullanici1_yukler[0]));
                    chart1.Series[1].LegendText = "2. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[1].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici2_yukler[i]));
                    }
                    chart1.Series[1].Points.AddXY("Şimdi", Convert.ToSingle(kullanici2_yukler[0]));
                    chart1.Series[2].LegendText = "3. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[2].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici3_yukler[i]));
                    }
                    chart1.Series[2].Points.AddXY("Şimdi", Convert.ToSingle(kullanici3_yukler[0]));
                    chart1.Series[3].LegendText = "4. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[3].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici4_yukler[i]));
                    }
                    chart1.Series[3].Points.AddXY("Şimdi", Convert.ToSingle(kullanici4_yukler[0]));
                    chart1.Series[4].LegendText = "5. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[4].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici5_yukler[i]));
                    }
                    chart1.Series[4].Points.AddXY("Şimdi", Convert.ToSingle(kullanici5_yukler[0]));
                    chart1.Series[5].LegendText = "6. Kullanıcının Yük Tüketimi";
                    for (i = length - 1; i > 0; i--)
                    {
                        chart1.Series[5].Points.AddXY(i.ToString() + " saat önce", Convert.ToSingle(kullanici6_yukler[i]));
                    }
                    chart1.Series[5].Points.AddXY("Şimdi", Convert.ToSingle(kullanici6_yukler[0]));
                }
                else
                {
                    SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();
                    float[] kullanici1_degerler = new float[5000];
                    float[] kullanici2_degerler = new float[5000];
                    float[] kullanici3_degerler = new float[5000];
                    float[] kullanici4_degerler = new float[5000];
                    float[] kullanici5_degerler = new float[5000];
                    float[] kullanici6_degerler = new float[5000];
                    float[] kullanici1_son_degerler = new float[50];
                    float[] kullanici2_son_degerler = new float[50];
                    float[] kullanici3_son_degerler = new float[50];
                    float[] kullanici4_son_degerler = new float[50];
                    float[] kullanici5_son_degerler = new float[50];
                    float[] kullanici6_son_degerler = new float[50];
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
                        kullanici1_degerler[i] = 0;
                        kullanici2_degerler[i] = 0;
                        kullanici3_degerler[i] = 0;
                        kullanici4_degerler[i] = 0;
                        kullanici5_degerler[i] = 0;
                        kullanici6_degerler[i] = 0;
                        int j;
                        for (j = 0; j <= i; j++)
                        {
                            kullanici1_degerler[i] = kullanici1_degerler[i] + Convert.ToSingle(kullanici1_yukler[j]);
                            kullanici2_degerler[i] = kullanici2_degerler[i] + Convert.ToSingle(kullanici2_yukler[j]);
                            kullanici3_degerler[i] = kullanici3_degerler[i] + Convert.ToSingle(kullanici3_yukler[j]);
                            kullanici4_degerler[i] = kullanici4_degerler[i] + Convert.ToSingle(kullanici4_yukler[j]);
                            kullanici5_degerler[i] = kullanici5_degerler[i] + Convert.ToSingle(kullanici5_yukler[j]);
                            kullanici6_degerler[i] = kullanici6_degerler[i] + Convert.ToSingle(kullanici6_yukler[j]);
                        }
                        kullanici1_degerler[i] = kullanici1_degerler[i] / j;
                        kullanici2_degerler[i] = kullanici2_degerler[i] / j;
                        kullanici3_degerler[i] = kullanici3_degerler[i] / j;
                        kullanici4_degerler[i] = kullanici4_degerler[i] / j;
                        kullanici5_degerler[i] = kullanici5_degerler[i] / j;
                        kullanici6_degerler[i] = kullanici6_degerler[i] / j;
                    }
                    int length_son_degerler = 0;
                    for (i = length - 10; i < length; i++)
                    {
                        kullanici1_son_degerler[length_son_degerler] = kullanici1_degerler[i];
                        kullanici2_son_degerler[length_son_degerler] = kullanici2_degerler[i];
                        kullanici3_son_degerler[length_son_degerler] = kullanici3_degerler[i];
                        kullanici4_son_degerler[length_son_degerler] = kullanici4_degerler[i];
                        kullanici5_son_degerler[length_son_degerler] = kullanici5_degerler[i];
                        kullanici6_son_degerler[length_son_degerler] = kullanici6_degerler[i];
                        length_son_degerler++;
                    }
                    if (tur.Equals("fiyatlandirma"))
                    {
                        chart1.Series[0].LegendText = "1. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[0].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici1_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[0].Points.AddXY("Şimdi", kullanici1_son_degerler[length_son_degerler - 1]*10 / 100);
                        chart1.Series[1].LegendText = "2. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[1].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici2_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[1].Points.AddXY("Şimdi", kullanici2_son_degerler[length_son_degerler - 1]*10 / 100);
                        chart1.Series[2].LegendText = "3. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[2].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici3_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[2].Points.AddXY("Şimdi", kullanici3_son_degerler[length_son_degerler - 1]*10 / 100);
                        chart1.Series[3].LegendText = "4. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[3].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici4_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[3].Points.AddXY("Şimdi", kullanici4_son_degerler[length_son_degerler - 1]*10 / 100);
                        chart1.Series[4].LegendText = "5. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[4].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici5_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[4].Points.AddXY("Şimdi", kullanici5_son_degerler[length_son_degerler - 1]*10 / 100);
                        chart1.Series[5].LegendText = "6. Kullanıcının Fiyatlandırması";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[5].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici6_son_degerler[i]*10 / 100);
                        }
                        chart1.Series[5].Points.AddXY("Şimdi", kullanici6_son_degerler[length_son_degerler - 1]*10 / 100);
                    }
                    else
                    {
                        chart1.Series[0].LegendText = "1. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[0].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici1_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[0].Points.AddXY("Şimdi", kullanici1_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                        chart1.Series[1].LegendText = "2. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[1].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici2_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[1].Points.AddXY("Şimdi", kullanici2_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                        chart1.Series[2].LegendText = "3. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[2].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici3_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[2].Points.AddXY("Şimdi", kullanici3_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                        chart1.Series[3].LegendText = "4. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[3].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici4_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[3].Points.AddXY("Şimdi", kullanici4_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                        chart1.Series[4].LegendText = "5. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[4].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici5_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[4].Points.AddXY("Şimdi", kullanici5_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                        chart1.Series[5].LegendText = "6. Kullanıcının Karbon Ayak İzi";
                        for (i = 0; i < length_son_degerler - 1; i++)
                        {
                            chart1.Series[5].Points.AddXY((length_son_degerler - 1 - i).ToString() + " saat önce", kullanici6_son_degerler[i] * 0.001388f / 100);
                        }
                        chart1.Series[5].Points.AddXY("Şimdi", kullanici6_son_degerler[length_son_degerler - 1] * 0.001388f / 100);
                    }
                }
            }
        }

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            if (tur.Equals("kullanici1_yuk_tuketimi") || tur.Equals("tum_kullanicilar_yuk_tuketimi"))
            {
                timer1.Stop();
                serialPort1.Close();
                YukTuketimleri yukTuketimleri = new YukTuketimleri();
                this.Visible = false;
                yukTuketimleri.Show();
            }
            else if (tur.Equals("fiyatlandirma"))
            {
                timer1.Stop();
                serialPort1.Close();
                Fiyatlandirma fiyatlandirma = new Fiyatlandirma();
                this.Visible = false;
                fiyatlandirma.Show();
            }
            else if (tur.Equals("karbon_ayakizi"))
            {
                timer1.Stop();
                serialPort1.Close();
                KarbonAyakizi karbonAyakizi = new KarbonAyakizi();
                this.Visible = false;
                karbonAyakizi.Show();
            }
        }

    }
}
