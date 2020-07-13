namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonYukTuketimleri = new System.Windows.Forms.Button();
            this.buttonFiyatlandirma = new System.Windows.Forms.Button();
            this.buttonKarbonAyakizi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(439, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonYukTuketimleri
            // 
            this.buttonYukTuketimleri.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonYukTuketimleri.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonYukTuketimleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonYukTuketimleri.Location = new System.Drawing.Point(512, 367);
            this.buttonYukTuketimleri.Name = "buttonYukTuketimleri";
            this.buttonYukTuketimleri.Size = new System.Drawing.Size(94, 36);
            this.buttonYukTuketimleri.TabIndex = 2;
            this.buttonYukTuketimleri.TabStop = false;
            this.buttonYukTuketimleri.Text = "Yük Tüketimleri";
            this.buttonYukTuketimleri.UseVisualStyleBackColor = false;
            this.buttonYukTuketimleri.Click += new System.EventHandler(this.ButtonYukTuketimleri_Click);
            // 
            // buttonFiyatlandirma
            // 
            this.buttonFiyatlandirma.BackColor = System.Drawing.Color.Red;
            this.buttonFiyatlandirma.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonFiyatlandirma.Location = new System.Drawing.Point(603, 367);
            this.buttonFiyatlandirma.Name = "buttonFiyatlandirma";
            this.buttonFiyatlandirma.Size = new System.Drawing.Size(94, 36);
            this.buttonFiyatlandirma.TabIndex = 3;
            this.buttonFiyatlandirma.TabStop = false;
            this.buttonFiyatlandirma.Text = "Fiyatlandırma";
            this.buttonFiyatlandirma.UseVisualStyleBackColor = false;
            this.buttonFiyatlandirma.Click += new System.EventHandler(this.ButtonFiyatlandirma_Click);
            // 
            // buttonKarbonAyakizi
            // 
            this.buttonKarbonAyakizi.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonKarbonAyakizi.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonKarbonAyakizi.Location = new System.Drawing.Point(694, 367);
            this.buttonKarbonAyakizi.Name = "buttonKarbonAyakizi";
            this.buttonKarbonAyakizi.Size = new System.Drawing.Size(94, 36);
            this.buttonKarbonAyakizi.TabIndex = 4;
            this.buttonKarbonAyakizi.TabStop = false;
            this.buttonKarbonAyakizi.Text = "Karbon Ayak İzi";
            this.buttonKarbonAyakizi.UseVisualStyleBackColor = false;
            this.buttonKarbonAyakizi.Click += new System.EventHandler(this.ButtonKarbonAyakizi_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 68);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // labelBaslik
            // 
            this.labelBaslik.AutoSize = true;
            this.labelBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBaslik.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelBaslik.Location = new System.Drawing.Point(12, 19);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(421, 22);
            this.labelBaslik.TabIndex = 6;
            this.labelBaslik.Text = "Akıllı ve Çevre Dostu Bina Enerji Yönetim Sistemleri";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 72);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(282, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(233, 222);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelBaslik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonKarbonAyakizi);
            this.Controls.Add(this.buttonFiyatlandirma);
            this.Controls.Add(this.buttonYukTuketimleri);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akıllı ve Çevre Dostu Bina Enerji Yönetim Sistemleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonYukTuketimleri;
        private System.Windows.Forms.Button buttonFiyatlandirma;
        private System.Windows.Forms.Button buttonKarbonAyakizi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

