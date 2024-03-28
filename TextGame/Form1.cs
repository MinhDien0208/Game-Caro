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
    public partial class frmGameCaro : Form
    {
        ChessBoardManager chessBoard;
        
        public frmGameCaro()
        {
            InitializeComponent();
            chessBoard = new ChessBoardManager(pnlChessBoard, txtName, ptcMark);
            chessBoard.DrawChessBoard();
           
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            chessBoard.Deletebtn();

            chessBoard.DrawChessBoard();
            
        }

        private void frmGameCaro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDiLai_Click(object sender, EventArgs e)
        {
            if(pnlChessBoard.Enabled != false && chessBoard.SavePoint.Count > 0)
            {
                chessBoard.Undo();
            }
             
        }

		private void btnTroVe_Click(object sender, EventArgs e)
		{
            this.Hide();

        }

        private void frmGameCaro_Load(object sender, EventArgs e)
        {

        }

       
    }
}
