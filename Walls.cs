using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallist;
        public Walls(int mapWidth, int mapHeight)
        {
            wallist= new List<Figure>();

            HorizontalLine Upline = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine Downline = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine Leftline = new VerticalLine(0, mapHeight - 1, 1, '+');
            VerticalLine Rightline = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallist.Add(Upline);
            wallist.Add(Downline);
            wallist.Add(Leftline);
            wallist.Add(Rightline);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallist)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallist)
            {
                wall.Draw();
            }
        }
    }
}
