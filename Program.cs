using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using NAudio;
using NAudio.Wave;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Media;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);
            int score = 0;
            int speed = 100;
            Walls walls = new Walls(80, 25);
            walls.Draw();


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();



            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 6, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            FoodCreator foodCreator2 = new FoodCreator(80, 25, '/');
            Point food2 = foodCreator.CreateFood2();
            food2.Draw();

            FoodCreator foodCreator3 = new FoodCreator(80, 25, '£');
            Point food3 = foodCreator.CreateFood3();
            food3.Draw();


            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)random.Next(1, 16);

            
            IWavePlayer waveOutDevice = new WaveOutEvent();
            AudioFileReader audioFileReader = new AudioFileReader("../../../Daft Punk - Around the World.wav");
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();


            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    score++;
                    Console.ForegroundColor = randomColor;
                    sound background1 = new sound();
                    _ = background1.Eating_play("../../../2515.wav");
                    speed = speed;
                }
                else if (snake.Eat2(food2))
                {
                    food2 = foodCreator2.CreateFood2();
                    food2.Draw();
                    score--;
                    Console.ForegroundColor = randomColor;
                    sound background1 = new sound();
                    _ = background1.Eating_play("../../../d19400703bb8adc.wav");
                    speed -= 10;
                }
                else if (snake.Eat3(food3))
                {
                    food3 = foodCreator3.CreateFood3();
                    food3.Draw();
                    score++;
                    Console.ForegroundColor = randomColor;
                    sound background1 = new sound();
                    _ = background1.Eating_play("../../../2515.wav");
                    speed += 20;
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
            }
            WriteGameOver();

            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine();
            }
            waveOutDevice.Stop();
            sound over = new sound();
            _ = over.Eating_play("../../../hello-darkness-my-old-friend-sound-effect.wav");
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("Time " + elapsedTime);
            stopwatch.Stop();
            Console.WriteLine("Points " + score);
            Console.Write("Kirjutage oma nimi ");
            string Line;
            while (true)
            {
                Console.Write("(minimaalselt 3 tähte): ");
                Line = Console.ReadLine();

                try
                {
                    if (Line.Length < 3)
                    {
                        throw new Exception("Nimi ei tohi olla lühem kui 3 tähemärki");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            StreamWriter text = new StreamWriter(@"..\..\..\Nimed.txt", true);
            string line = $"{Line}: {score}";
            text.WriteLine(line);
            text.Close();
            StringReader text1 = new StringReader(line);
            string lines = text1.ReadToEnd();
            text1.Close();
            Console.WriteLine(lines);

            static void WriteGameOver()
            {
                Random random = new Random();
                ConsoleColor randomColor1 = (ConsoleColor)random.Next(1, 16);
                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = randomColor1;
                Console.SetCursorPosition(xOffset, yOffset++);
                WriteText("============================", xOffset, yOffset++);
                WriteText("         MÄNG LÄBI", xOffset + 1, yOffset++);
                yOffset++;
                WriteText("Autor: Matvei Kulakovski", xOffset + 2, yOffset++);
                WriteText("============================", xOffset, yOffset++);
            }

            static void WriteText(String text, int xOffset, int yOffset)
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.WriteLine(text);
            }
        }
    }
}