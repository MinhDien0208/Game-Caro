using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextGame
{
    public partial class PlayerVSCom : Form
    {
        ChessBoardManagerCom chessBoard;
        public PlayerVSCom()
        {
            InitializeComponent();
            chessBoard = new ChessBoardManagerCom(pnlChessBoard);

            chessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            pgbDemTG.Step = Const.step;
            pgbDemTG.Maximum = Const.end_time;
            pgbDemTG.Value = 0;

            tmDemTG.Interval = Const.step_interval;

            chessBoard.DrawChessBoardCom();

        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmDemTG.Start();
            pgbDemTG.Value = 0;
        }

        

        private void PlayerVSCom_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            chessBoard.Deletebtn();
            chessBoard.DrawChessBoardCom();
            tmDemTG.Stop();
            pgbDemTG.Value = 0;
        }

		private void btnDiLai_Click(object sender, EventArgs e)
		{
            if (pnlChessBoard.Enabled != false && chessBoard.SavePoint.Count >0)
            {
                chessBoard.Undo();
                chessBoard.Undo();
                pgbDemTG.Value = 0;
            }
		}

		private void btnDauHang_Click(object sender, EventArgs e)
		{
            DialogResult result = MessageBox.Show("Bạn có chắc chắn là đầu hàng !!!","Cảnh Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã thua. Computer chiến thắng !");
                pnlChessBoard.Enabled = false;
            } else if(result == DialogResult.No)
            {
                return;
            }
		}

		private void btnTroVe_Click(object sender, EventArgs e)
		{
            this.Close();
		}

        private void tmDemTG_Tick(object sender, EventArgs e)
        {
            pgbDemTG.PerformStep();
            if(Const.check_tm == true) tmDemTG.Stop();
            if(pgbDemTG.Value >= pgbDemTG.Maximum)
            {
                tmDemTG.Stop();
                MessageBox.Show("Bạn đã thua. Computer chiến thắng !");
                pnlChessBoard.Enabled = false;
                
            }
            Const.check_tm = false;
        }
    }
}
