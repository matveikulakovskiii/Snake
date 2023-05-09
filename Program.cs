using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);

            HorizontalLine Upline = new HorizontalLine(0, 78, 0, '*');
            HorizontalLine Downline = new HorizontalLine(0, 78, 24, '*');
            VerticalLine Leftline = new VerticalLine(0, 24, 0, '*');
            VerticalLine Rightline = new VerticalLine(0, 24, 78, '*');
            Upline.Draw();
            Downline.Draw();
            Leftline.Draw();
            Rightline.Draw();
            Point p = new Point(40, 10, '+');
            Snake snake = new Snake(p, 6,Direction.RIGHT);
            snake.Draw();
            snake.Move();
            for (int i = 0; i < 14; i++)
            {
                Thread.Sleep(300);
                snake.Move();
            }
        }
    }
}