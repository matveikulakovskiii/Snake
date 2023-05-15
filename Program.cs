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
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else 
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandLeKey(key.Key);
                }
                Thread.Sleep( 100);
                snake.Move();
            }
        }
    }
}