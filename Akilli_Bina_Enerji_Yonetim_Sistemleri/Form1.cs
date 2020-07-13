using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
            label1.Text = "Günümüzün en önemli konuları arasında doğal kaynakların verimli kullanılması yer alıyor. Bu noktada sürdürülebilir enerji, doğal kaynakların kendilerini yenileyebilmesi ve çevreye en az zararı vererek enerji üretebilmenin en doğru yöntemi olarak karşımıza çıkıyor. Aynı zamanda enerji tasarrufu da bu duruma azımsanmayacak ölçüde bir fayda sağlıyor.";
            label2.Text = "Küresel ısınma ve çevre kirliliği artıkça, doğanın bize sağlamış olduğu doğa ürünü kaynaklar da hızla azalarak canlıların sıkıntı yaşamasına neden olmaktadır. Gün geçtikçe her alanda yaşanan bu sıkıntıların önüne geçebilmek için yapı sektöründe kaynakların doğru kullanılması amacıyla çevre dostu binaların yapılması fikri oluşturulmuştur.";
            label3.Text = "Akıllı ve çevre dostu binalarda elektrik ihtiyaçlarının karşılanması için sürdürülebilir enerji çözümlerinden yararlanılmaktadır. Yapılı çevrenin oluşumunda, çevreye verilen zararı minimumda tutmak için bütüncül bir yaklaşım gerekmektedir. Akıllı bina sistemi ile de aydınlatma, ütü ve kahve makinesi gibi aygıtlar bina dışından açlılıp kapatılabilmektedir. ";
        }

        private void ButtonYukTuketimleri_Click(object sender, EventArgs e)
        {
            Animasyon();
            YukTuketimleri yukTuketimleri = new YukTuketimleri();
            this.Visible = false;
            yukTuketimleri.Show();
        }

        private void ButtonFiyatlandirma_Click(object sender, EventArgs e)
        {
            Animasyon();
            Fiyatlandirma fiyatlandirma = new Fiyatlandirma();
            this.Visible = false;
            fiyatlandirma.Show();
        }

        private void ButtonKarbonAyakizi_Click(object sender, EventArgs e)
        {
            Animasyon();
            KarbonAyakizi karbonAyakizi = new KarbonAyakizi();
            this.Visible = false;
            karbonAyakizi.Show();
        }

        public void Animasyon()
        {
            this.BackColor = Color.White;
            pictureBox2.Visible = true;
            labelBaslik.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox1.Visible = false;
            buttonYukTuketimleri.Visible = false;
            buttonFiyatlandirma.Visible = false;
            buttonKarbonAyakizi.Visible = false;
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.logo1);
            b1.Add(Properties.Resources.logo2);
            b1.Add(Properties.Resources.logo3);
            b1.Add(Properties.Resources.logo4);
            b1.Add(Properties.Resources.logo5);
            b1.Add(Properties.Resources.logo6);
            b1.Add(Properties.Resources.logo7);
            b1.Add(Properties.Resources.logo8);
            b1.Add(Properties.Resources.logo9);
            b1.Add(Properties.Resources.logo10);
            b1.Add(Properties.Resources.logo11);
            b1.Add(Properties.Resources.logo12);
            b1.Add(Properties.Resources.logo13);
            for (int i = 0; i < 13; i++)
            {
                pictureBox2.Image = b1[i];
                pictureBox2.Refresh();
                if (i==0 || i == 12)
                {
                    System.Threading.Thread.Sleep(500);
                }

                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            YukTuketimleri yukTuketimleri = new YukTuketimleri();
            yukTuketimleri.UpdateConfigKey("aydinlatma", "kapali");
            yukTuketimleri.UpdateConfigKey("utu", "kapali");
            yukTuketimleri.UpdateConfigKey("kahve_makinesi", "kapali");
        }
    }

}
