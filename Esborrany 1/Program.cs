using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Esborrany_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fila;
            StreamReader F = new StreamReader("fitxer.txt");
            fila = F.ReadLine();
            F.Close();
            string[] beat = fila.Split('.');
            int i = 0, a=0;
            while (i<beat.Length)
            {
                a = Convert.ToInt32(beat[i]);
                if (a == 1)
                {
                    Console.Beep(440, 100);
                }
                System.Threading.Thread.Sleep(100);
                i++;
            }
        }
    }
}
