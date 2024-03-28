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
	public partial class frmHome : Form
	{
	
		public frmHome()
		{
			InitializeComponent();
		}

		private void btnPlayer_Click(object sender, EventArgs e)
		{
			frmGameCaro f = new frmGameCaro();
			f.ShowDialog();
		}

		private void btnCom_Click(object sender, EventArgs e)
		{
			PlayerVSCom f = new PlayerVSCom();
			f.ShowDialog();
		}

		private void btnHuongDan_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Luật chơi cờ caro khá đơn giản, " +
							"nhiệm vụ của mỗi người chơi cờ caro đó là đạt được một đường thẳng, " +
							"đường chéo, đường ngang với 5 ô nhanh nhất. " +
							"Tuy nhiên, chỉ cần người chơi nào có thể đạt 4 nước mà bị chặn 1 đầu " +
							"hoặc không bị chặn hai đầu là đã có thể chiến thắng.");
		}
		 
       
    }
}
