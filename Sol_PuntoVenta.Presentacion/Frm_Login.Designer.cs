namespace Sol_PuntoVenta.Presentacion
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pct_logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_login_us = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Password_us = new System.Windows.Forms.TextBox();
            this.Btn_acceder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Pct_logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 291);
            this.panel1.TabIndex = 0;
            // 
            // Pct_logo
            // 
            this.Pct_logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pct_logo.Image = ((System.Drawing.Image)(resources.GetObject("Pct_logo.Image")));
            this.Pct_logo.Location = new System.Drawing.Point(43, 12);
            this.Pct_logo.Name = "Pct_logo";
            this.Pct_logo.Size = new System.Drawing.Size(162, 136);
            this.Pct_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pct_logo.TabIndex = 1;
            this.Pct_logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 118);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema \r\nde \r\nPunto de Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Versión 1.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "Iniciar Sesión";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_login_us
            // 
            this.Txt_login_us.Location = new System.Drawing.Point(403, 86);
            this.Txt_login_us.MaxLength = 20;
            this.Txt_login_us.Name = "Txt_login_us";
            this.Txt_login_us.Size = new System.Drawing.Size(233, 20);
            this.Txt_login_us.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(399, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contraseña:";
            // 
            // Txt_Password_us
            // 
            this.Txt_Password_us.Location = new System.Drawing.Point(403, 142);
            this.Txt_Password_us.MaxLength = 20;
            this.Txt_Password_us.Name = "Txt_Password_us";
            this.Txt_Password_us.PasswordChar = '*';
            this.Txt_Password_us.Size = new System.Drawing.Size(233, 20);
            this.Txt_Password_us.TabIndex = 4;
            // 
            // Btn_acceder
            // 
            this.Btn_acceder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_acceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_acceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_acceder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_acceder.Location = new System.Drawing.Point(403, 201);
            this.Btn_acceder.Name = "Btn_acceder";
            this.Btn_acceder.Size = new System.Drawing.Size(233, 44);
            this.Btn_acceder.TabIndex = 6;
            this.Btn_acceder.Text = "ACCEDER";
            this.Btn_acceder.UseVisualStyleBackColor = false;
            this.Btn_acceder.Click += new System.EventHandler(this.Btn_acceder_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 291);
            this.Controls.Add(this.Btn_acceder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_Password_us);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_login_us);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pct_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Pct_logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_login_us;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_Password_us;
        private System.Windows.Forms.Button Btn_acceder;
    }
}