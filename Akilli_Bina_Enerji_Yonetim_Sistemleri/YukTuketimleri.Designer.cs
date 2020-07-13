namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    partial class YukTuketimleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YukTuketimleri));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewKullanici1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewDigerKullanicilar = new System.Windows.Forms.DataGridView();
            this.buttonKullanici1Grafik = new System.Windows.Forms.Button();
            this.buttonTumKullanicilarGrafik = new System.Windows.Forms.Button();
            this.buttonGeri = new System.Windows.Forms.Button();
            this.buttonAydinlatma = new System.Windows.Forms.Button();
            this.buttonKahveMakinesi = new System.Windows.Forms.Button();
            this.buttonUtu = new System.Windows.Forms.Button();
            this.labelEnerjiKaynagi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigerKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Kullanıcı";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.Location = new System.Drawing.Point(12, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 51);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Diğer Kullanıcılar";
            // 
            // dataGridViewKullanici1
            // 
            this.dataGridViewKullanici1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanici1.Location = new System.Drawing.Point(12, 69);
            this.dataGridViewKullanici1.Name = "dataGridViewKullanici1";
            this.dataGridViewKullanici1.Size = new System.Drawing.Size(770, 150);
            this.dataGridViewKullanici1.TabIndex = 2;
            // 
            // dataGridViewDigerKullanicilar
            // 
            this.dataGridViewDigerKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDigerKullanicilar.Location = new System.Drawing.Point(12, 288);
            this.dataGridViewDigerKullanicilar.Name = "dataGridViewDigerKullanicilar";
            this.dataGridViewDigerKullanicilar.Size = new System.Drawing.Size(770, 150);
            this.dataGridViewDigerKullanicilar.TabIndex = 3;
            // 
            // buttonKullanici1Grafik
            // 
            this.buttonKullanici1Grafik.BackColor = System.Drawing.Color.Brown;
            this.buttonKullanici1Grafik.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonKullanici1Grafik.Location = new System.Drawing.Point(455, 447);
            this.buttonKullanici1Grafik.Name = "buttonKullanici1Grafik";
            this.buttonKullanici1Grafik.Size = new System.Drawing.Size(111, 40);
            this.buttonKullanici1Grafik.TabIndex = 4;
            this.buttonKullanici1Grafik.TabStop = false;
            this.buttonKullanici1Grafik.Text = "1. Kullanıcı Grafiği";
            this.buttonKullanici1Grafik.UseVisualStyleBackColor = false;
            this.buttonKullanici1Grafik.Click += new System.EventHandler(this.ButtonKullanici1Grafik_Click);
            // 
            // buttonTumKullanicilarGrafik
            // 
            this.buttonTumKullanicilarGrafik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonTumKullanicilarGrafik.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonTumKullanicilarGrafik.Location = new System.Drawing.Point(563, 447);
            this.buttonTumKullanicilarGrafik.Name = "buttonTumKullanicilarGrafik";
            this.buttonTumKullanicilarGrafik.Size = new System.Drawing.Size(111, 40);
            this.buttonTumKullanicilarGrafik.TabIndex = 5;
            this.buttonTumKullanicilarGrafik.TabStop = false;
            this.buttonTumKullanicilarGrafik.Text = "Tüm Kullanıcıların Grafiği";
            this.buttonTumKullanicilarGrafik.UseVisualStyleBackColor = false;
            this.buttonTumKullanicilarGrafik.Click += new System.EventHandler(this.ButtonTumKullanicilarGrafik_Click);
            // 
            // buttonGeri
            // 
            this.buttonGeri.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonGeri.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGeri.Location = new System.Drawing.Point(671, 447);
            this.buttonGeri.Name = "buttonGeri";
            this.buttonGeri.Size = new System.Drawing.Size(111, 40);
            this.buttonGeri.TabIndex = 6;
            this.buttonGeri.TabStop = false;
            this.buttonGeri.Text = "Geri";
            this.buttonGeri.UseVisualStyleBackColor = false;
            this.buttonGeri.Click += new System.EventHandler(this.ButtonGeri_Click);
            // 
            // buttonAydinlatma
            // 
            this.buttonAydinlatma.Location = new System.Drawing.Point(316, 75);
            this.buttonAydinlatma.Name = "buttonAydinlatma";
            this.buttonAydinlatma.Size = new System.Drawing.Size(44, 22);
            this.buttonAydinlatma.TabIndex = 7;
            this.buttonAydinlatma.UseVisualStyleBackColor = true;
            this.buttonAydinlatma.Click += new System.EventHandler(this.ButtonAydinlatma_Click);
            // 
            // buttonKahveMakinesi
            // 
            this.buttonKahveMakinesi.Location = new System.Drawing.Point(717, 75);
            this.buttonKahveMakinesi.Name = "buttonKahveMakinesi";
            this.buttonKahveMakinesi.Size = new System.Drawing.Size(44, 22);
            this.buttonKahveMakinesi.TabIndex = 8;
            this.buttonKahveMakinesi.UseVisualStyleBackColor = true;
            this.buttonKahveMakinesi.Click += new System.EventHandler(this.ButtonKahveMakinesi_Click);
            // 
            // buttonUtu
            // 
            this.buttonUtu.Location = new System.Drawing.Point(601, 75);
            this.buttonUtu.Name = "buttonUtu";
            this.buttonUtu.Size = new System.Drawing.Size(44, 22);
            this.buttonUtu.TabIndex = 9;
            this.buttonUtu.UseVisualStyleBackColor = true;
            this.buttonUtu.Click += new System.EventHandler(this.ButtonUtu_Click);
            // 
            // labelEnerjiKaynagi
            // 
            this.labelEnerjiKaynagi.AutoSize = true;
            this.labelEnerjiKaynagi.Location = new System.Drawing.Point(13, 445);
            this.labelEnerjiKaynagi.Name = "labelEnerjiKaynagi";
            this.labelEnerjiKaynagi.Size = new System.Drawing.Size(35, 13);
            this.labelEnerjiKaynagi.TabIndex = 10;
            this.labelEnerjiKaynagi.Text = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(171, 444);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // YukTuketimleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(798, 499);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelEnerjiKaynagi);
            this.Controls.Add(this.buttonUtu);
            this.Controls.Add(this.buttonKahveMakinesi);
            this.Controls.Add(this.buttonAydinlatma);
            this.Controls.Add(this.buttonGeri);
            this.Controls.Add(this.buttonTumKullanicilarGrafik);
            this.Controls.Add(this.buttonKullanici1Grafik);
            this.Controls.Add(this.dataGridViewDigerKullanicilar);
            this.Controls.Add(this.dataGridViewKullanici1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YukTuketimleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yük Tüketimleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YukTuketimleri_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.YukTuketimleri_FormClosed);
            this.Load += new System.EventHandler(this.YukTuketimleri_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigerKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewKullanici1;
        private System.Windows.Forms.DataGridView dataGridViewDigerKullanicilar;
        private System.Windows.Forms.Button buttonKullanici1Grafik;
        private System.Windows.Forms.Button buttonTumKullanicilarGrafik;
        private System.Windows.Forms.Button buttonGeri;
        private System.Windows.Forms.Button buttonAydinlatma;
        private System.Windows.Forms.Button buttonKahveMakinesi;
        private System.Windows.Forms.Button buttonUtu;
        private System.Windows.Forms.Label labelEnerjiKaynagi;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}