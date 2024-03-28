namespace TextGame
{
    partial class DangKy
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtDKMatKhau = new System.Windows.Forms.TextBox();
            this.txtDKTaiKhoan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDKNhapLai = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(104, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = " Mật khẩu";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangKy.Location = new System.Drawing.Point(276, 456);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(156, 47);
            this.btnDangKy.TabIndex = 14;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtDKMatKhau
            // 
            this.txtDKMatKhau.Location = new System.Drawing.Point(298, 324);
            this.txtDKMatKhau.Multiline = true;
            this.txtDKMatKhau.Name = "txtDKMatKhau";
            this.txtDKMatKhau.PasswordChar = '*';
            this.txtDKMatKhau.Size = new System.Drawing.Size(209, 25);
            this.txtDKMatKhau.TabIndex = 13;
            // 
            // txtDKTaiKhoan
            // 
            this.txtDKTaiKhoan.Location = new System.Drawing.Point(298, 267);
            this.txtDKTaiKhoan.Multiline = true;
            this.txtDKTaiKhoan.Name = "txtDKTaiKhoan";
            this.txtDKTaiKhoan.Size = new System.Drawing.Size(209, 25);
            this.txtDKTaiKhoan.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(104, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = " Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(104, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // txtDKNhapLai
            // 
            this.txtDKNhapLai.Location = new System.Drawing.Point(298, 376);
            this.txtDKNhapLai.Multiline = true;
            this.txtDKNhapLai.Name = "txtDKNhapLai";
            this.txtDKNhapLai.PasswordChar = '*';
            this.txtDKNhapLai.Size = new System.Drawing.Size(209, 25);
            this.txtDKNhapLai.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TextGame.Properties.Resources.Avatar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(239, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 173);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 559);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDKNhapLai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txtDKMatKhau);
            this.Controls.Add(this.txtDKTaiKhoan);
            this.Controls.Add(this.label1);
            this.Name = "DangKy";
            this.Text = "Đăng ký";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.TextBox txtDKMatKhau;
        private System.Windows.Forms.TextBox txtDKTaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDKNhapLai;
    }
}