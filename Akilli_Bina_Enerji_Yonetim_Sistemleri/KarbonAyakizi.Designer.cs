namespace Akilli_Bina_Enerji_Yonetim_Sistemleri
{
    partial class KarbonAyakizi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KarbonAyakizi));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelKarbonAyakizi = new System.Windows.Forms.Label();
            this.dataGridViewKarbonAyakizi = new System.Windows.Forms.DataGridView();
            this.buttonGrafik = new System.Windows.Forms.Button();
            this.buttonGeri = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKarbonAyakizi)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Controls.Add(this.labelKarbonAyakizi);
            this.panel1.Location = new System.Drawing.Point(26, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 63);
            this.panel1.TabIndex = 0;
            // 
            // labelKarbonAyakizi
            // 
            this.labelKarbonAyakizi.AutoSize = true;
            this.labelKarbonAyakizi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKarbonAyakizi.Location = new System.Drawing.Point(12, 17);
            this.labelKarbonAyakizi.Name = "labelKarbonAyakizi";
            this.labelKarbonAyakizi.Size = new System.Drawing.Size(139, 24);
            this.labelKarbonAyakizi.TabIndex = 0;
            this.labelKarbonAyakizi.Text = "Karbon Ayak İzi";
            // 
            // dataGridViewKarbonAyakizi
            // 
            this.dataGridViewKarbonAyakizi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKarbonAyakizi.Location = new System.Drawing.Point(26, 93);
            this.dataGridViewKarbonAyakizi.Name = "dataGridViewKarbonAyakizi";
            this.dataGridViewKarbonAyakizi.Size = new System.Drawing.Size(760, 151);
            this.dataGridViewKarbonAyakizi.TabIndex = 1;
            // 
            // buttonGrafik
            // 
            this.buttonGrafik.BackColor = System.Drawing.Color.Navy;
            this.buttonGrafik.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGrafik.Location = new System.Drawing.Point(611, 250);
            this.buttonGrafik.Name = "buttonGrafik";
            this.buttonGrafik.Size = new System.Drawing.Size(88, 40);
            this.buttonGrafik.TabIndex = 2;
            this.buttonGrafik.Text = "Grafik";
            this.buttonGrafik.UseVisualStyleBackColor = false;
            this.buttonGrafik.Click += new System.EventHandler(this.ButtonGrafik_Click);
            // 
            // buttonGeri
            // 
            this.buttonGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGeri.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGeri.Location = new System.Drawing.Point(696, 250);
            this.buttonGeri.Name = "buttonGeri";
            this.buttonGeri.Size = new System.Drawing.Size(90, 40);
            this.buttonGeri.TabIndex = 3;
            this.buttonGeri.Text = "Geri";
            this.buttonGeri.UseVisualStyleBackColor = false;
            this.buttonGeri.Click += new System.EventHandler(this.ButtonGeri_Click);
            // 
            // KarbonAyakizi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(808, 310);
            this.Controls.Add(this.buttonGeri);
            this.Controls.Add(this.buttonGrafik);
            this.Controls.Add(this.dataGridViewKarbonAyakizi);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KarbonAyakizi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karbon Ayak İzi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KarbonAyakizi_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KarbonAyakizi_FormClosed);
            this.Load += new System.EventHandler(this.KarbonAyakizi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKarbonAyakizi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelKarbonAyakizi;
        private System.Windows.Forms.DataGridView dataGridViewKarbonAyakizi;
        private System.Windows.Forms.Button buttonGrafik;
        private System.Windows.Forms.Button buttonGeri;
    }
}