using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Player
    {
		private string name; // Tên người chơi
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private Image mark; // Lưu hình ảnh quân cờ của người chơi
		public Image Mark
		{
			get { return mark; }
			set { mark = value; }
		}

		public Player(string name, Image mark)
		{
			this.Name = name;
			this.Mark = mark;
		}
	}
}
