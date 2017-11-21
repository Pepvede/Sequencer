using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Esborrany_1
{
    class Program
    {
        static double ObtenerFrecuencia(int nota, int octava)
        {
            double auxiliar=(octava-4)*12+(nota-10);
            auxiliar=Math.Pow(2, auxiliar / 12);
            return(440.0* auxiliar);
        }
        static void Main(string[] args)
        {
           /* int i = 0, j = 0;
            int[,] V = new int[12,8];
            StreamReader F = new StreamReader("fitxer.txt");
            string Aux_Partitura;
            while (i < 12)
            {
                Aux_Partitura = F.ReadLine();
                while (j<8) {
                    V[i, j] =;
                    j++;
                }
                j = 0;
                i++;
            }
            Console.ReadKey();
            /*while (j<8)
            {
                while (i<12)
                {
                    if (V[i,j])
                    {

                    }
                }
            }*/
            string fila;
            StreamReader F = new StreamReader("fitxer.txt");
            fila = F.ReadLine();
            F.Close();
            string[] beat = fila.Split('.');
            int i = 0, j=0, bpm=300, Octava=4, Nota=0;
            double Frecuencia = 0;
            while (i<beat.Length)
            {  
                Nota = Convert.ToInt32(beat[i]);
                Frecuencia = ObtenerFrecuencia(Nota,Octava);
                if(Nota!=0)
                    Console.Beep((int)Frecuencia, bpm);
                else
                    Thread.Sleep(bpm);
                i++;
            }
        }
    }
}
