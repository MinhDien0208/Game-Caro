namespace TextGame
{
    partial class PlayerVSCom
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
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnDiLai = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.btnDauHang = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pgbDemTG = new System.Windows.Forms.ProgressBar();
            this.tmDemTG = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroVe.BackColor = System.Drawing.SystemColors.Control;
            this.btnTroVe.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTroVe.Location = new System.Drawing.Point(683, 393);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(240, 43);
            this.btnTroVe.TabIndex = 16;
            this.btnTroVe.Text = "Trở về";
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnDiLai
            // 
            this.btnDiLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiLai.BackColor = System.Drawing.SystemColors.Control;
            this.btnDiLai.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDiLai.Location = new System.Drawing.Point(816, 250);
            this.btnDiLai.Name = "btnDiLai";
            this.btnDiLai.Size = new System.Drawing.Size(102, 45);
            this.btnDiLai.TabIndex = 15;
            this.btnDiLai.Text = "Đi lại";
            this.btnDiLai.UseVisualStyleBackColor = false;
            this.btnDiLai.Click += new System.EventHandler(this.btnDiLai_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNew.Location = new System.Drawing.Point(685, 250);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(102, 45);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Location = new System.Drawing.Point(12, 3);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(657, 625);
            this.pnlChessBoard.TabIndex = 10;
            // 
            // btnDauHang
            // 
            this.btnDauHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDauHang.BackColor = System.Drawing.SystemColors.Control;
            this.btnDauHang.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDauHang.Location = new System.Drawing.Point(759, 318);
            this.btnDauHang.Name = "btnDauHang";
            this.btnDauHang.Size = new System.Drawing.Size(102, 45);
            this.btnDauHang.TabIndex = 18;
            this.btnDauHang.Text = "Đầu Hàng";
            this.btnDauHang.UseVisualStyleBackColor = false;
            this.btnDauHang.Click += new System.EventHandler(this.btnDauHang_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::TextGame.Properties.Resources.Avatar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(675, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 241);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pgbDemTG
            // 
            this.pgbDemTG.Location = new System.Drawing.Point(687, 453);
            this.pgbDemTG.Name = "pgbDemTG";
            this.pgbDemTG.Size = new System.Drawing.Size(236, 36);
            this.pgbDemTG.TabIndex = 19;
            // 
            // tmDemTG
            // 
            this.tmDemTG.Tick += new System.EventHandler(this.tmDemTG_Tick);
            // 
            // PlayerVSCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 629);
            this.Controls.Add(this.pgbDemTG);
            this.Controls.Add(this.btnDauHang);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnDiLai);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlChessBoard);
            this.Name = "PlayerVSCom";
            this.Text = "Chơi với máy ";
            this.Load += new System.EventHandler(this.PlayerVSCom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnDiLai;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlChessBoard;
		private System.Windows.Forms.Button btnDauHang;
        private System.Windows.Forms.ProgressBar pgbDemTG;
        private System.Windows.Forms.Timer tmDemTG;
    }
}