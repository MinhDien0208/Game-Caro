using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TextGame
{
    public class ChessBoardManagerCom
    {
		public static string getaccount;

        private Panel chessBoard;
        public Panel Chessborad
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }


		private List<Player> player; // Tạo danh sách để lưu người chơi
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private int currentPlayer; // Lưu lại ai là người đánh và nó cũng là index của danh sách người chơi
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private Stack<Point> savePoint; // Lưu lại vị trí nước vừa đánh để thực hiện chức năng undo
        public Stack<Point> SavePoint
        {
            get { return savePoint; }
            set { savePoint = value; }
        }

        private List<List<Button>> matrix; // Danh sách lưu button  dong<cot<button>>
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

		private event EventHandler playerMarked;
		public event EventHandler PlayerMarked
		{
			add
			{
				playerMarked += value;
			}
			remove
			{
				playerMarked -= value;
			}
		}

        private event EventHandler endGame;

        public event EventHandler EndGame
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        public ChessBoardManagerCom(Panel chessboard)
        {
            this.Chessborad = chessboard;
            this.Player = new List<Player>()
            {
                new Player(""+getaccount,Image.FromFile(Application.StartupPath + "\\Resources\\Image X.jpg")), 
                new Player("Computer",Image.FromFile(Application.StartupPath + "\\Resources\\Image Y.jpg"))
            }; // Khởi tạo người chơi
            this.CurrentPlayer = 0;
            this.SavePoint = new Stack<Point>();
        }

        public void DrawChessBoardCom()
        {
            Matrix = new List<List<Button>>();
            Chessborad.Enabled = true;
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) }; //Button ban đầu 
            for (int i = 0; i < Const.ChessBoardRow; i++)
            {	
                Matrix.Add(new List<Button>()); // Thêm hàng mới trong list để lưu trữ button
                for (int j = 0; j < Const.ChessBoardColumn; j++)
                {
                    Button btn = new Button()
                    {
                        Width = 25,
                        Height = 25,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString() // lưu vị trí button nằm ở hàng nào
                    };

                    Chessborad.Controls.Add(btn);
                    Matrix[i].Add(btn); // Thêm các button vào danh sách
                    oldbtn = btn;
                    btn.Click += Btn_Click; //ủy thác sự kiện cho nó 
                }
                oldbtn.Location = new Point(0, oldbtn.Location.Y + 25);
                oldbtn.Width = 0;
                oldbtn.Height = 0;
            }
        }


        private void Btn_Click(object sender, EventArgs e) // sender gửi đi even click
        {
            Button btn = sender as Button; // ép kiểu sender để có button click
            if (btn.BackgroundImage != null)// click rồi không được click nữa
			{  
                MessageBox.Show("Ô đã đánh rồi không được đánh nữa. Bạn vui lòng đánh lại");
                return;
            }
            if (playerMarked != null)
                playerMarked(this, new EventArgs());
            if (CurrentPlayer == 0)
            {
                btn.BackgroundImage = Player[CurrentPlayer].Mark;
                SavePoint.Push(GetChessPoint(btn)); //Thêm button vừa đánh vào ngăn xếp
				Point point = GetChessPoint(btn); //Lấy vị trí button vừa đánh
                Matrix[point.Y][point.X].Name = "MinhDien"; //Gán tên cho button vừa đánh
                if (isEndGame(btn))
                {
                    Const.check_tm = true;
                    MessageBox.Show(" "+getaccount+"đã chiến thắng ");
                    chessBoard.Enabled = false;
                    return;
                }
				CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
				btn = Matrix[Computer().X][Computer().Y];
				btn.BackgroundImage = Player[CurrentPlayer].Mark;
				SavePoint.Push(GetChessPoint(btn));
				Point point2 = GetChessPoint(btn);
				Matrix[point2.Y][point2.X].Name = "Computer";

                if (isEndGame(btn))
                {
                    Const.check_tm = true;
                    MessageBox.Show("Computer đã chiến thắng");
                    chessBoard.Enabled = false;
                }
					
            }
            
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
		}

        public bool isEndGame(Button btn)

        {

            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }
        private Point GetChessPoint(Button btn) //Hàm lấy ra vị trí button vừa đánh
        {

            int vertical = Convert.ToInt32(btn.Tag); // lấy ra vị trí ở hàng thứ mấy
            int horizontal = Matrix[vertical].IndexOf(btn); // lấy ra vị trí ở cột thứ mấy
            Point point = new Point(horizontal, vertical);
			return point;
        }

        public void Deletebtn()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    chessBoard.Controls.Clear();
                }
            }
        }

		#region Kiểm tra kết thúc game
		private bool isEndHorizontal(Button btn)// Kiểm tra kết thúc game ở hàng ngang
        {
            Point point = GetChessPoint(btn);//Lấy vị trí btn hiện tại
            int countLeft = 0;
            int countRight = 0;

            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else break;
            }
            for (int i = point.X + 1; i < 20; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else break;
            }
            return countLeft + countRight == 5;
        }
        private bool isEndVertical(Button btn)// Kiểm tra kết thúc ở hàng dọc
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            int countBottom = 0;

            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = point.Y + 1; i < 20; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndPrimary(Button btn)// Kiểm tra kết thúc game ở đường chéo chính 
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            int countBottom = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= 20 - point.X; i++)
            {
                if (point.X + i >= 20 || point.Y + i >= 20)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndSub(Button btn)// Kiểm tra kết thúc game ở đường chéo phụ 
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            int countBottom = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X + i > 20)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= 20 - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= 20)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }
		#endregion

		public bool Undo()
		{
			Point oldPoint = SavePoint.Pop();
			Button btn = Matrix[oldPoint.Y][oldPoint.X];
			btn.BackgroundImage = null;
			btn.Name = null;
			if (SavePoint.Count <= 0)
			{
				CurrentPlayer = 0;
			}
			else
			{
				CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
			}

			return true;
		}

		#region AI

		private long[] AttackScores = new long[7] { 0, 4, 25, 246, 7300, 6561, 59049 };
        private long[] DefenseScores = new long[7] { 0, 3, 24, 243, 2197, 19773, 177957 };
		private Point Computer()
        {
            Point pointResult = new Point(0, 0);
            long DiemMax = 0;
            long DiemTC = 0;
            long DiemPN = 0;

            for (int i = 0; i < Const.ChessBoardRow; i++)
            {
                for (int j = 0; j < Const.ChessBoardColumn; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null && !Pruning(i, j))
                    {

                        DiemTC = HorizontalAttack(i, j) + VerticalAttack(i, j) + PrimaryAttack(i, j) + SubAttack(i, j);
                        DiemPN = HorizontalDefense(i, j) + VerticalDefense(i, j) + PrimaryDefense(i, j) + SubDefense(i, j);

                        long DiemTam = DiemPN > DiemTC ? DiemPN : DiemTC;
                        if (DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            pointResult = new Point(i, j);
                        }

                    }
                }
            }
            return pointResult;
        }
        private bool Pruning(int row, int column)
        {
			if (HorizontalPruning(row,column) && VerticalPruning(row,column) && PrimaryPruning(row,column) && SubPruning(row,column))
				return true;
            return false;
		}

        #region Alpha-Beta Pruning
        private bool HorizontalPruning(int row, int column)
        {
            //duyệt bên phải
            if(column <= Const.ChessBoardColumn - 4 )
                for(int i = 1; i <= 3; i++)
                    if (Matrix[row][column+i].BackgroundImage != null)
                        return false;
			//duyệt bên trái;
			if (column >=3)
				for (int i = 1; i <= 3; i++)
					if (Matrix[row][column-i].BackgroundImage != null)
						return false;
            return true;
		} 
        private bool VerticalPruning(int row, int column)
        {
			if (row <= Const.ChessBoardRow - 4)
				for (int i = 1; i <= 3; i++)
					if (Matrix[row+i][column].BackgroundImage != null)
						return false;
			if(row >=3)
				for (int i = 1; i <= 3; i++)
				if (Matrix[row - i][column].BackgroundImage != null)
					return false;
            return true;
		}
        private bool PrimaryPruning(int row, int column)
        {
            if(row <= Const.ChessBoardRow - 4  && column >=3)
                for (int i = 1;i <= 3; i++)
                    if (Matrix[row+i][column-i].BackgroundImage != null)
                        return false;
			if (column <= Const.ChessBoardColumn - 4 && row >= 3)
				for (int i = 1; i <= 3; i++)
					if (Matrix[row - i][column + i].BackgroundImage != null)
						return false;
            return true;
		}
        private bool SubPruning(int row, int column)
        {
            if(row <= Const.ChessBoardRow - 4 && column <= Const.ChessBoardColumn - 4)
                for(int i = 1;i<= 3;i++)
                    if (Matrix[row + i][column+i].BackgroundImage != null)
                        return false;
			if (row >= 3 && column >= 3)
				for (int i = 1; i <= 3; i++)
					if (Matrix[row - i][column - i].BackgroundImage != null)
						return false;
            return true;
		}

		#endregion

		#region Attack
		public long HorizontalAttack(int row, int column)
        { 
			long DiemTC = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
            
            for(int i = 1; i<= 4 && column < Const.ChessBoardColumn - 4; i++)
            {
                if (Matrix[row][column+i].Name == "Computer")
                {
                    if (i == 1)
                        DiemTC += 37;
                    SoQuanTa++;
                    KhoangTrong++;
                }
                else 
                    if(Matrix[row][column + i].Name == "MinhDien")
				    {
                        SoQuanDich++;
                        break;
                    }
                    else KhoangTrong++;
            }

			for (int i = 1; i <= 4  && column > 3; i++)
			{
                if (Matrix[row][column - i].Name == "Computer")
                {
                    if (i == 1)
                        DiemTC += 37;
                    SoQuanTa++;
                    KhoangTrong++;
                }
                else
                    if (Matrix[row][column - i].Name == "MinhDien") 
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}
            if (KhoangTrong < 3 && SoQuanDich >= 2) return 0;
            DiemTC -= DefenseScores[SoQuanDich];
            DiemTC += AttackScores[SoQuanTa];
            return DiemTC;
		}

		public long VerticalAttack(int row, int column)
		{
			long DiemTC = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
			for (int i = 1; i <= 4 && row >3; i++)
			{
				if (Matrix[row-i][column].Name == "Computer")
				{
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
					KhoangTrong++;
				}
				else
					if (Matrix[row-i][column].Name == "MinhDien")
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}

			for (int i = 1; i <= 4 && row < Const.ChessBoardRow - 4; i++)
			{
				if (Matrix[row + i][column].Name == "Computer")
				{
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
					KhoangTrong++;
				}
				else
					if (Matrix[row + i][column].Name == "MinhDien")
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}
			if (KhoangTrong < 3 && SoQuanDich >= 2) return 0;
			DiemTC -= DefenseScores[SoQuanDich];
			DiemTC += AttackScores[SoQuanTa];
			return DiemTC;
		}

        public long PrimaryAttack(int row, int column)
        {
			long DiemTC = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
            for (int i = 1;i <= 4 && column <= Const.ChessBoardColumn - 4 && row < Const.ChessBoardRow - 4; i++)
            {
                if (Matrix[row + i][column + i].Name == "Computer")
                {
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
                    KhoangTrong++;
                }
                else
                    if (Matrix[row + i][column + i].Name == "MinhDien")
                    {
                        SoQuanDich++;
                        break;
                    }
                    else KhoangTrong++; 
            }

			for (int i = 1; i <= 4 && row > 3 && column > 3; i++)
			{
				if (Matrix[row - i][column - i].Name == "Computer")
				{
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
					KhoangTrong++;
				}
				else
					if (Matrix[row - i][column - i].Name == "MinhDien")
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}
			if (KhoangTrong < 3 && SoQuanDich >= 2) return 0;
			DiemTC -= DefenseScores[SoQuanDich];
			DiemTC += AttackScores[SoQuanTa];
			return DiemTC;
		}

		public long SubAttack(int row, int column)
		{
			long DiemTC = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
			for (int i = 1; i <= 4 && column < Const.ChessBoardColumn - 4 && row > 3; i++)
			{
				if (Matrix[row - i][column + i].Name == "Computer")
				{
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
					KhoangTrong++;
				}
				else
					if (Matrix[row - i ][column + i].Name == "MinhDien")
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}

			for (int i = 1; i <= 4 && row < Const.ChessBoardRow - 4 && column > 3; i++)
			{
				if (Matrix[row + i][column - i].Name == "Computer")
				{
					if (i == 1)
						DiemTC += 37;
					SoQuanTa++;
					KhoangTrong++;
				}
				else
					if (Matrix[row + i][column - i].Name == "MinhDien")
				{
					SoQuanDich++;
					break;
				}
				else KhoangTrong++;
			}
			if (KhoangTrong < 3 && SoQuanDich >= 2) return 0;
			DiemTC -= DefenseScores[SoQuanDich];
			DiemTC += AttackScores[SoQuanTa];
			return DiemTC;
		}

		#endregion

		#region Defense
		public long HorizontalDefense(int row, int column)
		{
			long DiemPN = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
            bool ok =false;
			for (int i = 1; i <= 4 && column < Const.ChessBoardColumn - 4; i++)
			{
				if (Matrix[row][column + i].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row][column + i].Name == "Computer")
				{
                    if (i == 3) 
                        DiemPN -= 170;
                    SoQuanTa++;
					break;
				}
                else
                {
                    if(i==1)
                        ok=true;
                    KhoangTrong++;
                }
			}
            if (SoQuanDich == 3 && KhoangTrong == 1 && ok)
                DiemPN -= 200;
            ok=false;

			for (int i = 1; i <= 4 && column > 3; i++)
			{
				if (Matrix[row][column - i].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row][column - i].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
			if (SoQuanDich == 3 && KhoangTrong == 2 && ok)
				DiemPN -= 200;

			if (SoQuanTa >= 2 && (KhoangTrong + SoQuanDich) < 3) return 0;
			DiemPN -= AttackScores[SoQuanTa];
			DiemPN += DefenseScores[SoQuanDich];
			return DiemPN;
		}

		public long VerticalDefense(int row, int column)
		{
			long DiemPN = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
			bool ok = false;
			for (int i = 1; i <= 4 && row > 3; i++)
			{
				if (Matrix[row - i][column].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row - i][column].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
			if (SoQuanDich == 3 && KhoangTrong == 1 && ok)
				DiemPN -= 200;
			ok = false;

			for (int i = 1; i <= 4 && row < Const.ChessBoardRow - 4; i++)
			{
				if (Matrix[row + i][column].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row + i][column].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
			if (SoQuanDich == 3 && KhoangTrong == 2 && ok)
				DiemPN -= 200;

			if (SoQuanTa >= 2 && (KhoangTrong + SoQuanDich) < 3) return 0;
			DiemPN -= AttackScores[SoQuanTa];
			DiemPN += DefenseScores[SoQuanDich];
			return DiemPN;
		}

        public long PrimaryDefense(int row, int column)
        {
			long DiemPN = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
			bool ok = false;

            for(int i = 0; i <= 4 && row < Const.ChessBoardRow - 4 && column < Const.ChessBoardColumn - 4; i++)
            {
                if (Matrix[row + i][column + i].Name == "MinhDien")
                {
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
                } else
                    if (Matrix[row + i][column + i].Name == "Computer")
                {
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
                    break;
                }
                else
                {
                    if(i==1)
                        ok=true;
                    KhoangTrong++;
                }
            }
            if (SoQuanDich == 3 && KhoangTrong == 1 && ok)
                DiemPN -= 200;
            ok=false;

			for (int i = 0; i <= 4 && row > 3 && column > 3; i++)
			{
				if (Matrix[row - i][column - i].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row - i][column - i].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
            if(SoQuanDich == 3 && KhoangTrong >= 2 && ok)
                DiemPN -= 200;
            if (SoQuanTa >= 2 && (KhoangTrong + SoQuanDich) < 3)
                return 0;
            DiemPN -= AttackScores[SoQuanTa];
            DiemPN += DefenseScores[SoQuanDich];
            return DiemPN;
		}

		public long SubDefense(int row, int column)
		{
			long DiemPN = 0;
			int SoQuanTa = 0;
			int SoQuanDich = 0;
			int KhoangTrong = 0;
			bool ok = false;

			for (int i = 0; i <=4  && row > 3 && column < Const.ChessBoardColumn - 4; i++)
			{
				if (Matrix[row - i][column + i].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row - i][column + i].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
			if (SoQuanDich == 3 && KhoangTrong == 1 && ok)
				DiemPN -= 200;
			ok = false;

			for (int i = 0; i <= 4 && row < Const.ChessBoardRow - 4 && column > 3; i++)
			{
				if (Matrix[row + i][column - i].Name == "MinhDien")
				{
					if (i == 1)
						DiemPN += 9;
					SoQuanDich++;
				}
				else
					if (Matrix[row + i][column - i].Name == "Computer")
				{
					if (i == 3)
						DiemPN -= 170;
					SoQuanTa++;
					break;
				}
				else
				{
					if (i == 1)
						ok = true;
					KhoangTrong++;
				}
			}
			if (SoQuanDich == 3 && KhoangTrong >= 2 && ok)
				DiemPN -= 200;
			if (SoQuanTa >= 2 && (KhoangTrong + SoQuanDich) < 3)
				return 0;
			DiemPN -= AttackScores[SoQuanTa];
			DiemPN += DefenseScores[SoQuanDich];
			return DiemPN;
		}

		#endregion
		#endregion

		public void test()
		{
            //Button b = new Button();
            //         b = Matrix[1][1];
            //         b.Name = "NhuHuynh";


            //if (Matrix[0][1].Name == "Computer")
            //{
            //    MessageBox.Show("trung");
            //}
            //else MessageBox.Show("khong trung");
            for(int i=0; i< Const.ChessBoardRow; i++)
            {
                for (int j=0; j< Const.ChessBoardColumn; j++)
                {
                    if (Matrix[i][j].Name != "")
                    {
						MessageBox.Show(" " + Matrix[i][j].Name);
					}
                }
            }
              

			//Point pointResult = new Point();
			//long DiemMax = 0;
			//for (int i = 0; i < 20; i++)
			//{
			//    for (int j = 0; j < 20; j++)
			//    {
			//        if (Matrix[i][j].BackgroundImage == null)
			//        {
			//            MessageBox.Show("chua co");
			//            break;
			//            //long diemtancong = dtc_duyetdoc(i, j) + dtc_duyetngang(i, j) + dtc_duyetcheochinh(i, j) + dtc_duyetcheophu(i, j);
			//            //long diemphongthu = dpt_duyetdoc(i, j) + dpt_duyetngang(i, j) + dpt_duyetcheochinh(i, j) + dpt_duyetcheophu(i, j);
			//            //long diemtam = diemtancong > diemphongthu ? diemtancong : diemphongthu;
			//            //if (DiemMax < diemtam)
			//            //{
			//            //    DiemMax = diemtam;
			//            //    pointResult = new Point(i, j);
			//            //}



			//        }
			//        else MessageBox.Show("co roi"); break;
			//    }
			//}
		}
    }
}
