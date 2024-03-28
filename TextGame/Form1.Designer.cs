namespace TextGame
{
    partial class frmGameCaro
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
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.ptcMark = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDiLai = new System.Windows.Forms.Button();
            this.btnTroVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Location = new System.Drawing.Point(3, 0);
            this.pnlChessBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(657, 625);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(666, 305);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 38);
            this.txtName.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNew.Location = new System.Drawing.Point(666, 417);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 44);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ptcMark
            // 
            this.ptcMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptcMark.Location = new System.Drawing.Point(841, 294);
            this.ptcMark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptcMark.Name = "ptcMark";
            this.ptcMark.Size = new System.Drawing.Size(106, 90);
            this.ptcMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptcMark.TabIndex = 3;
            this.ptcMark.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TextGame.Properties.Resources.Avatar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(666, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 286);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnDiLai
            // 
            this.btnDiLai.Location = new System.Drawing.Point(827, 417);
            this.btnDiLai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDiLai.Name = "btnDiLai";
            this.btnDiLai.Size = new System.Drawing.Size(120, 44);
            this.btnDiLai.TabIndex = 7;
            this.btnDiLai.Text = "Đi lại";
            this.btnDiLai.UseVisualStyleBackColor = true;
            this.btnDiLai.Click += new System.EventHandler(this.btnDiLai_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(706, 502);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(208, 44);
            this.btnTroVe.TabIndex = 8;
            this.btnTroVe.Text = "Trở về";
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // frmGameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 629);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnDiLai);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.ptcMark);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGameCaro";
            this.Text = "Chơi với người";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGameCaro_FormClosed);
            this.Load += new System.EventHandler(this.frmGameCaro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptcMark;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDiLai;
		private System.Windows.Forms.Button btnTroVe;
    }
}

