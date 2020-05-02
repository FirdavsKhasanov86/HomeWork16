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
                });
                
                
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






