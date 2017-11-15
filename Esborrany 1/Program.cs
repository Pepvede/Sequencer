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
        static double ObtenerFrecuencia(double nota, double octava)
        {
            return (440.0 * Math.Exp(((octava - 4) + (nota - 10) / 12.0) * Math.Log(2)));
        }
        static void Main(string[] args)
        {
            string fila;
            StreamReader F = new StreamReader("fitxer.txt");
            fila = F.ReadLine();
            F.Close();
            string[] beat = fila.Split('.');
            int i = 0, bpm=150;
            double Frecuencia = 0, Nota=0.0, Octava=4.0;
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
