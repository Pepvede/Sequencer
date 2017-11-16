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
        static double ObtenerFrecuencia(int nota, int octava)
        {
            double ayudante=(octava-4)*12+(nota-10);
            ayudante=Math.Pow(2,ayudante/12);
            return(440.0*ayudante);
        }
        static void Main(string[] args)
        {
            string fila;
            StreamReader F = new StreamReader("fitxer.txt");
            fila = F.ReadLine();
            F.Close();
            string[] beat = fila.Split('.');
            int i = 0, bpm=429, Octava=4, Nota=0;
            double Frecuencia = 0;
            while (i<beat.Length)
            {
                Nota = Convert.ToInt32(beat[i]);
                Frecuencia = ObtenerFrecuencia(Nota,Octava);
                if(Nota!=0)
                    Console.Beep((int)Frecuencia, bpm);
                else
                    System.Threading.Thread.Sleep(bpm);
                i++;
            }
        }
    }
}
