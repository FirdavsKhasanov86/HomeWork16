using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork16
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Matrix> list = new List<Matrix>();
            while (true)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < new Random().Next(100, 1000); i++)
                    {
                        list.Add(new Matrix()
                        {
                            Left = new Random().Next(100),
                            simbol = Word(),
                            Top = new Random().Next(2, 8)
                        });
                    }
                }).Wait();
                
                Task.Run(() =>
                {
                    ShowFallingRain(list);
                    list.Clear();

                }).Wait();
            }


        }
        static void ShowFallingRain(List<Matrix> symbols)
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (var k in symbols)
                {
                    Console.CursorTop = i + k.Top;
                    foreach (var z in k.simbol)
                    {
                        Console.CursorLeft = k.Left;
                        if (j == k.simbol.Length - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (j == k.simbol.Length - 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.WriteLine(z);
                        j++;
                    }
                    j = 0;
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }

        static char[] Word()
        {

            string word = "";
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if ((char)new Random().Next(0, 4) == 1)
                {
                    word += i;
                }
            }
            return word.ToCharArray();
        }


    }


    class Matrix
    {
        public char[] simbol { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
    }


}






