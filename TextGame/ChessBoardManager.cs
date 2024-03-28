
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextGame
{
    public class ChessBoardManager 
    {
		int ChessBoardColumn = 25;
		int ChessBoardRow = 25;

        private Panel chessBoard;

        public Panel Chessborad
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }


        private List<Player> player; // tao danh sach de luu nguoi choi

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
        private int currentPlayer; // luu lai ai dang la nguoi danh va no cung la index cua danh sach nguoi choi

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private TextBox playName;

        public TextBox PlayerName
        {
            get { return playName; }
            set { playName = value; }
        }

        private PictureBox playerMark;
        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }

        private Stack<Point> savePoint; // Lưu lại vị trí nước vừa đánh để thực hiện chức năng undo

        public Stack<Point> SavePoint
        {
            get { return savePoint; }
            set { savePoint = value; }
        }

        private List<List<Button>> matrix; // danh sach luu button dong<cot<button>>

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public ChessBoardManager(Panel chessboard, TextBox playername, PictureBox mark)// ham dung de thay doi nguoi choi
        {
            this.Chessborad = chessboard;
            this.PlayerMark = mark;
            this.PlayerName = playername;
            this.Player = new List<Player>() 
            { 
                new Player("Player 1",Image.FromFile(Application.StartupPath + "\\Resources\\Image X.jpg") ),
                new Player("Player 2",Image.FromFile(Application.StartupPath + "\\Resources\\Image Y.jpg") )
            }; // khoi tạo người chơi gồm tên, hình ảnh thay đổi
            this.CurrentPlayer = 0;
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
            this.SavePoint = new Stack<Point>();
        }
        
        public void DrawChessBoard()
        {
            Matrix = new List<List<Button>>();
            Chessborad.Enabled = true;
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < ChessBoardRow; i++)
            {
                Matrix.Add(new List<Button>()); // them hang moi trong list de luu tru button
                for (int j = 0; j < ChessBoardColumn; j++)
                {
                    Button btn = new Button()
                    {
                        Width = 25,
                        Height = 25,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag= i.ToString() // luu vi tri button dang nam o hang nao
                    };
                    
                    Chessborad.Controls.Add(btn);
                    Matrix[i].Add(btn); // neu i = 0 no o hang thu nhat thi them cac button vao danh sach
                    oldbtn = btn;
                    btn.Click += Btn_Click; //ủy thác sự kiện cho nó 
                }
                oldbtn.Location = new Point(0, oldbtn.Location.Y + 25);
                oldbtn.Width = 0;
                oldbtn.Height = 0;
            }
           
        }
        private void Btn_Click(object sender, EventArgs e) // sender gui even click
        {
            
            Button btn = sender as Button; // ép kiểu sender để có button click
            if (btn.BackgroundImage != null) // click roi k dc click nua
                return;
            btn.BackgroundImage = Player[CurrentPlayer].Mark; // khi nhap vao button thi hinh anh se thay doi theo nguoi choi
            if (CurrentPlayer == 0)
            {
                CurrentPlayer = 1;
            }
            else
            {
                CurrentPlayer = 0;
            }
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
            SavePoint.Push(GetChessPoint(btn)); // them button vua nhap vao ngan xep

            if (isEndGame(btn))
            {
                
                if (CurrentPlayer == 0)
                {
                    CurrentPlayer = 1;
                    MessageBox.Show("Người chơi " + Player[CurrentPlayer].Name + " đã chiến thắng");
                }
                else
                {
                    CurrentPlayer = 0;
                    MessageBox.Show("Người chơi " + Player[CurrentPlayer].Name + " đã chiến thắng");
                }
                chessBoard.Enabled= false;

            }
        }
        
        private bool isEndGame(Button btn)

        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn) ;
        }
        private Point GetChessPoint(Button btn)
        {
            
            int vertical = Convert.ToInt32(btn.Tag); // Lấy ra vị trí ở hàng thứ mấy
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal,vertical); 
            return point;
        }
       
       public void Deletebtn()
        {
            for(int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    chessBoard.Controls.Clear();
                }
            }
        }
        private bool isEndHorizontal(Button btn)// kiểm tra kết thúc ở hàng ngang
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            int countRight = 0;

            for (int i = point.X; i >=0 ; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else break;
            }
            for (int i = point.X +1; i < ChessBoardColumn; i++   )
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else break;
            }
            return countLeft + countRight == 5;
        }
        private bool isEndVertical(Button btn)// kiểm tra kết thúc ở hàng dọc 
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
            for (int i = point.Y + 1; i < ChessBoardRow; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndPrimary(Button btn)// kiểm tra kết thúc ở đường chéo chính
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            int countBottom = 0;

            for (int i = 0; i <=point.X; i++)
            {
                if(point.Y-i < 0 || point.X-i < 0) 
                    break;
                if (Matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= 25 - point.X; i++)
            {
                if (point.X + i >= 25 || point.Y + i >= 25)
                    break;
                    if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    {
                        countBottom++;
                    }
                    else break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndSub(Button btn)//kiểm tra kết thúc ở đường chéo phụ
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            int countBottom = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X + i >20)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= 25 - point.X; i++)
            {
                if (point.X - i <0|| point.Y +i >=25)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }

        public bool Undo()
        {
            Point oldPoint = SavePoint.Pop();
            Button btn = Matrix[oldPoint.Y][oldPoint.X];
            btn.BackgroundImage = null;
            if (SavePoint.Count <= 0)
            {
                CurrentPlayer = 0;
                PlayerName.Text = Player[CurrentPlayer].Name;
                PlayerMark.Image = Player[CurrentPlayer].Mark;
            }
            else
            {
                if (CurrentPlayer == 0)
                {
                    CurrentPlayer = 1;
                }
                else
                {
                    CurrentPlayer = 0;
                }
                PlayerName.Text = Player[CurrentPlayer].Name;
                PlayerMark.Image = Player[CurrentPlayer].Mark;
            }
            
          

            return true;
        }
        
    }
}
