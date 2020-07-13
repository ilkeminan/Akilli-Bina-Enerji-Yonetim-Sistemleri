namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    partial class Fiyatlandirma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fiyatlandirma));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFiyatlandırma = new System.Windows.Forms.Label();
            this.dataGridViewFiyatlandirma = new System.Windows.Forms.DataGridView();
            this.buttonGrafik = new System.Windows.Forms.Button();
            this.buttonGeri = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiyatlandirma)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.labelFiyatlandırma);
            this.panel1.Location = new System.Drawing.Point(24, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 60);
            this.panel1.TabIndex = 0;
            // 
            // labelFiyatlandırma
            // 
            this.labelFiyatlandırma.AutoSize = true;
            this.labelFiyatlandırma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFiyatlandırma.Location = new System.Drawing.Point(12, 16);
            this.labelFiyatlandırma.Name = "labelFiyatlandırma";
            this.labelFiyatlandırma.Size = new System.Drawing.Size(121, 24);
            this.labelFiyatlandırma.TabIndex = 0;
            this.labelFiyatlandırma.Text = "Fiyatlandırma";
            // 
            // dataGridViewFiyatlandirma
            // 
            this.dataGridViewFiyatlandirma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiyatlandirma.Location = new System.Drawing.Point(24, 91);
            this.dataGridViewFiyatlandirma.Name = "dataGridViewFiyatlandirma";
            this.dataGridViewFiyatlandirma.Size = new System.Drawing.Size(761, 161);
            this.dataGridViewFiyatlandirma.TabIndex = 1;
            // 
            // buttonGrafik
            // 
            this.buttonGrafik.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonGrafik.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGrafik.Location = new System.Drawing.Point(604, 258);
            this.buttonGrafik.Name = "buttonGrafik";
            this.buttonGrafik.Size = new System.Drawing.Size(92, 36);
            this.buttonGrafik.TabIndex = 2;
            this.buttonGrafik.Text = "Grafik";
            this.buttonGrafik.UseVisualStyleBackColor = false;
            this.buttonGrafik.Click += new System.EventHandler(this.ButtonGrafik_Click);
            // 
            // buttonGeri
            // 
            this.buttonGeri.BackColor = System.Drawing.Color.Olive;
            this.buttonGeri.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGeri.Location = new System.Drawing.Point(693, 258);
            this.buttonGeri.Name = "buttonGeri";
            this.buttonGeri.Size = new System.Drawing.Size(92, 36);
            this.buttonGeri.TabIndex = 3;
            this.buttonGeri.Text = "Geri";
            this.buttonGeri.UseVisualStyleBackColor = false;
            this.buttonGeri.Click += new System.EventHandler(this.ButtonGeri_Click);
            // 
            // Fiyatlandirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(809, 318);
            this.Controls.Add(this.buttonGeri);
            this.Controls.Add(this.buttonGrafik);
            this.Controls.Add(this.dataGridViewFiyatlandirma);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fiyatlandirma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiyatlandırma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fiyatlandirma_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Fiyatlandirma_FormClosed);
            this.Load += new System.EventHandler(this.Fiyatlandirma_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiyatlandirma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFiyatlandırma;
        private System.Windows.Forms.DataGridView dataGridViewFiyatlandirma;
        private System.Windows.Forms.Button buttonGrafik;
        private System.Windows.Forms.Button buttonGeri;
    }
}