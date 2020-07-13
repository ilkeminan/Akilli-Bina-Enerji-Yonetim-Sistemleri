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
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;

namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    public partial class YukTuketimleri : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        int baud_rate;
        string veri, sebeke;
        string buzdolabi, aydinlatma, camasir_makinesi, bulasik_makinesi, utu, kahve_makinesi, kullanici1, kullanici2, kullanici3, kullanici4, kullanici5, kullanici6;
        
        public YukTuketimleri()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["aydinlatma"].Equals("acik"))
            {
                buttonAydinlatma.Text = "Açık";
                buttonAydinlatma.BackColor = Color.Green;
            }
            else
            {
                buttonAydinlatma.Text = "Kapalı";
                buttonAydinlatma.BackColor = Color.Red;
            }
            if (ConfigurationManager.AppSettings["utu"].Equals("acik"))
            {
                buttonUtu.Text = "Açık";
                buttonUtu.BackColor = Color.Green;
            }
            else
            {
                buttonUtu.Text = "Kapalı";
                buttonUtu.BackColor = Color.Red;
            }
            if (ConfigurationManager.AppSettings["kahve_makinesi"].Equals("acik"))
            {
                buttonKahveMakinesi.Text = "Açık";
                buttonKahveMakinesi.BackColor = Color.Green;
            }
            else
            {
                buttonKahveMakinesi.Text = "Kapalı";
                buttonKahveMakinesi.BackColor = Color.Red;
            }
            labelEnerjiKaynagi.Visible = false;
            pictureBox1.Visible = false;
            Kullanici1DataGridiniDoldur();
            DigerKullanicilarDataGridiniDoldur();
            baud_rate = 115200;
            veri = "";
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

                serialPort1.Write("000");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                veri = serialPort1.ReadExisting();
                char[] spearator = { ',' };
                int count = 12;
                string [] strlist = veri.Split(spearator, count, StringSplitOptions.None);
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
                if (sebeke.Equals("1.00"))
                {
                    labelEnerjiKaynagi.Text = "Enerji Kaynağı: Şebeke";
                    pictureBox1.Image = Properties.Resources.sebeke;
                }
                else
                {
                    labelEnerjiKaynagi.Text = "Enerji Kaynağı: Alternatif Enerji";
                    pictureBox1.Image = Properties.Resources.gunes_paneli;
                }
                pictureBox1.Visible = true;
                labelEnerjiKaynagi.Visible = true;
                if (Convert.ToSingle(aydinlatma) == 0)
                {
                    buttonAydinlatma.Text = "Kapalı";
                    buttonAydinlatma.BackColor = Color.Red;
                    UpdateConfigKey("aydinlatma", "kapali");
                }
                else
                {
                    buttonAydinlatma.Text = "Açık";
                    buttonAydinlatma.BackColor = Color.Green;
                    UpdateConfigKey("aydinlatma", "acik");
                }
                if (Convert.ToSingle(utu) == 0)
                {
                    buttonUtu.Text = "Kapalı";
                    buttonUtu.BackColor = Color.Red;
                    UpdateConfigKey("utu", "kapali");
                }
                else
                {
                    buttonUtu.Text = "Açık";
                    buttonUtu.BackColor = Color.Green;
                    UpdateConfigKey("utu", "acik");
                }
                if (Convert.ToSingle(kahve_makinesi) == 0)
                {
                    buttonKahveMakinesi.Text = "Kapalı";
                    buttonKahveMakinesi.BackColor = Color.Red;
                    UpdateConfigKey("kahve_makinesi", "kapali");
                }
                else
                {
                    buttonKahveMakinesi.Text = "Açık";
                    buttonKahveMakinesi.BackColor = Color.Green;
                    UpdateConfigKey("kahve_makinesi", "acik");
                }
                ConfigurationManager.RefreshSection("appSettings");
                SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Yuk_Tuketimleri (Buzdolabi,Aydinlatma,Camasir_Makinesi,Bulasik_Makinesi,Utu,Kahve_Makinesi,Kullanici2,Kullanici3,Kullanici4,Kullanici5,Kullanici6) values('" + buzdolabi + "', '" + aydinlatma + "','" + camasir_makinesi + "', '" + bulasik_makinesi + "','" + utu + "','" + kahve_makinesi + "','"+ kullanici2 + "','" + kullanici3 + "','" + kullanici4 + "','" + kullanici5 + "','" + kullanici6 + "') ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Kullanici1DataGridiniDoldur();
                DigerKullanicilarDataGridiniDoldur();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ButtonAydinlatma_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["aydinlatma"].Equals("acik"))
            {
                buttonAydinlatma.Text = "Kapalı";
                buttonAydinlatma.BackColor = Color.Red;
                UpdateConfigKey("aydinlatma", "kapali");
            }
            else
            {
                buttonAydinlatma.Text = "Açık";
                buttonAydinlatma.BackColor = Color.Green;
                UpdateConfigKey("aydinlatma", "acik");
            }
            ConfigurationManager.RefreshSection("appSettings");
            if (portlar.Length != 0)
            {
                string arduino_data="";
                int aydinlatma_acik_mi, utu_acik_mi, kahve_makinesi_acik_mi;
                if (ConfigurationManager.AppSettings["aydinlatma"].Equals("acik"))
                {
                    aydinlatma_acik_mi = 1;
                }
                else
                {
                    aydinlatma_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["utu"].Equals("acik"))
                {
                    utu_acik_mi = 1;
                }
                else
                {
                    utu_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["kahve_makinesi"].Equals("acik"))
                {
                    kahve_makinesi_acik_mi = 1;
                }
                else
                {
                    kahve_makinesi_acik_mi = 0;
                }
                arduino_data = aydinlatma_acik_mi.ToString() + utu_acik_mi.ToString() + kahve_makinesi_acik_mi.ToString();
                serialPort1.Write(arduino_data);
            }
        }

        private void ButtonUtu_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["utu"].Equals("acik"))
            {
                buttonUtu.Text = "Kapalı";
                buttonUtu.BackColor = Color.Red;
                UpdateConfigKey("utu", "kapali");
            }
            else
            {
                buttonUtu.Text = "Açık";
                buttonUtu.BackColor = Color.Green;
                UpdateConfigKey("utu", "acik");
            }
            ConfigurationManager.RefreshSection("appSettings");
            if (portlar.Length != 0)
            {
                string arduino_data = "";
                int aydinlatma_acik_mi, utu_acik_mi, kahve_makinesi_acik_mi;
                if (ConfigurationManager.AppSettings["aydinlatma"].Equals("acik"))
                {
                    aydinlatma_acik_mi = 1;
                }
                else
                {
                    aydinlatma_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["utu"].Equals("acik"))
                {
                    utu_acik_mi = 1;
                }
                else
                {
                    utu_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["kahve_makinesi"].Equals("acik"))
                {
                    kahve_makinesi_acik_mi = 1;
                }
                else
                {
                    kahve_makinesi_acik_mi = 0;
                }
                arduino_data = aydinlatma_acik_mi.ToString() + utu_acik_mi.ToString() + kahve_makinesi_acik_mi.ToString();
                serialPort1.Write(arduino_data);
            }
        }

        private void ButtonKahveMakinesi_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["kahve_makinesi"].Equals("acik"))
            {
                buttonKahveMakinesi.Text = "Kapalı";
                buttonKahveMakinesi.BackColor = Color.Red;
                UpdateConfigKey("kahve_makinesi", "kapali");
            }
            else
            {
                buttonKahveMakinesi.Text = "Açık";
                buttonKahveMakinesi.BackColor = Color.Green;
                UpdateConfigKey("kahve_makinesi", "acik");
            }
            ConfigurationManager.RefreshSection("appSettings");
            if (portlar.Length != 0)
            {
                string arduino_data = "";
                int aydinlatma_acik_mi, utu_acik_mi, kahve_makinesi_acik_mi;
                if (ConfigurationManager.AppSettings["aydinlatma"].Equals("acik"))
                {
                    aydinlatma_acik_mi = 1;
                }
                else
                {
                    aydinlatma_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["utu"].Equals("acik"))
                {
                    utu_acik_mi = 1;
                }
                else
                {
                    utu_acik_mi = 0;
                }
                if (ConfigurationManager.AppSettings["kahve_makinesi"].Equals("acik"))
                {
                    kahve_makinesi_acik_mi = 1;
                }
                else
                {
                    kahve_makinesi_acik_mi = 0;
                }
                arduino_data = aydinlatma_acik_mi.ToString() + utu_acik_mi.ToString() + kahve_makinesi_acik_mi.ToString();
                serialPort1.Write(arduino_data);
            }
        }

        private void YukTuketimleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                timer1.Stop();
                serialPort1.Close();
            }
        }

        public void Kullanici1DataGridiniDoldur()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
            List<Kullanici1> yukler = new List<Kullanici1>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri ORDER BY id DESC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            int i = 0;
            while (oku.Read())
            {
                buzdolabi = oku["Buzdolabi"].ToString();
                aydinlatma = oku["Aydinlatma"].ToString();
                camasir_makinesi = oku["Camasir_Makinesi"].ToString();
                bulasik_makinesi = oku["Bulasik_Makinesi"].ToString();
                utu = oku["Utu"].ToString();
                kahve_makinesi = oku["Kahve_Makinesi"].ToString();
                kullanici1 = (Convert.ToSingle(buzdolabi) + Convert.ToSingle(aydinlatma) + Convert.ToSingle(camasir_makinesi) + Convert.ToSingle(bulasik_makinesi) + Convert.ToSingle(utu) + Convert.ToSingle(kahve_makinesi)).ToString();
                if (i == 0)
                { 
                    yukler.Add(new Kullanici1 { Zaman = "Şimdi", Buzdolabi = buzdolabi, Aydinlatma = aydinlatma, CamasirMakinesi = camasir_makinesi, BulasikMakinesi = bulasik_makinesi, Utu = utu, KahveMakinesi = kahve_makinesi });
                }
                else
                {
                    string zaman = i.ToString() + " saat önce";
                    yukler.Add(new Kullanici1 { Zaman = zaman, Buzdolabi = buzdolabi, Aydinlatma = aydinlatma, CamasirMakinesi = camasir_makinesi, BulasikMakinesi = bulasik_makinesi, Utu = utu, KahveMakinesi = kahve_makinesi });
                }
                i++;
            }
            baglanti.Close();
            dataGridViewKullanici1.DataSource = yukler;
            dataGridViewKullanici1.Columns[0].HeaderCell.Value = "Zaman";
            dataGridViewKullanici1.Columns[1].HeaderCell.Value = "Buzdolabı";
            dataGridViewKullanici1.Columns[2].HeaderCell.Value = "Aydınlatma";
            dataGridViewKullanici1.Columns[3].HeaderCell.Value = "Çamaşır Makinesi";
            dataGridViewKullanici1.Columns[4].HeaderCell.Value = "Bulaşık Makinesi";
            dataGridViewKullanici1.Columns[5].HeaderCell.Value = "Ütü";
            dataGridViewKullanici1.Columns[6].HeaderCell.Value = "Kahve Makinesi";
            dataGridViewKullanici1.Columns[2].Width = 110;
            dataGridViewKullanici1.Columns[6].Width = 100;
            dataGridViewKullanici1.ClearSelection();
        }

        public void DigerKullanicilarDataGridiniDoldur()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=Yuk_Tuketimleri;Integrated Security=True");
            List<DigerKullanicilar> kullanicilar = new List<DigerKullanicilar>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Yuk_Tuketimleri ORDER BY id DESC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            int i = 0;
            while (oku.Read())
            {
                kullanici2 = oku["Kullanici2"].ToString();
                kullanici3 = oku["Kullanici3"].ToString();
                kullanici4 = oku["Kullanici4"].ToString();
                kullanici5 = oku["Kullanici5"].ToString();
                kullanici6 = oku["Kullanici6"].ToString();
                if (i == 0)
                {
                    kullanicilar.Add(new DigerKullanicilar {Zaman = "Şimdi", Kullanici2 = kullanici2, Kullanici3 = kullanici3, Kullanici4 = kullanici4, Kullanici5 = kullanici5, Kullanici6 = kullanici6 });
                }
                else
                {
                    string zaman = i.ToString() + " saat önce";
                    kullanicilar.Add(new DigerKullanicilar {Zaman = zaman , Kullanici2 = kullanici2, Kullanici3 = kullanici3, Kullanici4 = kullanici4, Kullanici5 = kullanici5, Kullanici6 = kullanici6 });
                }
                i++;
            }
            dataGridViewDigerKullanicilar.DataSource = kullanicilar;
            dataGridViewDigerKullanicilar.Columns[0].HeaderCell.Value = "Zaman";
            dataGridViewDigerKullanicilar.Columns[1].HeaderCell.Value = "Kullanıcı 2";
            dataGridViewDigerKullanicilar.Columns[2].HeaderCell.Value = "Kullanıcı 3";
            dataGridViewDigerKullanicilar.Columns[3].HeaderCell.Value = "Kullanıcı 4";
            dataGridViewDigerKullanicilar.Columns[4].HeaderCell.Value = "Kullanıcı 5";
            dataGridViewDigerKullanicilar.Columns[5].HeaderCell.Value = "Kullanıcı 6";
            dataGridViewDigerKullanicilar.Columns[0].Width = 122;
            dataGridViewDigerKullanicilar.Columns[1].Width = 122;
            dataGridViewDigerKullanicilar.Columns[2].Width = 122;
            dataGridViewDigerKullanicilar.Columns[3].Width = 122;
            dataGridViewDigerKullanicilar.Columns[4].Width = 122;
            dataGridViewDigerKullanicilar.ClearSelection();
        }

        private void ButtonKullanici1Grafik_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();
            Grafik grafik = new Grafik("kullanici1_yuk_tuketimi");
            this.Visible = false;
            grafik.Show();
        }

        private void ButtonTumKullanicilarGrafik_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();
            Grafik grafik = new Grafik("tum_kullanicilar_yuk_tuketimi");
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

        private void YukTuketimleri_Load(object sender, EventArgs e)
        {
            dataGridViewKullanici1.ClearSelection();
            dataGridViewDigerKullanicilar.ClearSelection();
        }

        public void UpdateConfigKey(string strKey, string newValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            bool configKeyExists = false;
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                {
                    configKeyExists = true;
                }
            }
            if (configKeyExists == false)
            {
                throw new ArgumentNullException("Key", "<" + strKey + "> not find in the configuration.");
            }
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                {
                    childNode.Attributes["value"].Value = newValue;
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private void YukTuketimleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConfigKey("aydinlatma", "kapali");
            UpdateConfigKey("utu", "kapali");
            UpdateConfigKey("kahve_makinesi", "kapali");
        }
    }

    public class Kullanici1
    {
        public string Zaman { get; set; }
        public string Buzdolabi { get; set; }
        public string Aydinlatma { get; set; }
        public string CamasirMakinesi { get; set; }
        public string BulasikMakinesi { get; set; }
        public string Utu { get; set; }
        public string KahveMakinesi { get; set; }
    }

    public class DigerKullanicilar
    {
        public string Zaman { get; set; }
        public string Kullanici2 { get; set; }
        public string Kullanici3 { get; set; }
        public string Kullanici4 { get; set; }
        public string Kullanici5 { get; set; }
        public string Kullanici6 { get; set; }
    }
}
