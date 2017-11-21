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
            int i = 0, bpm=300, Octava=4, Nota=0, I=0;
            double Frecuencia = 0;

            while (I<beat.Length)
            {
                Console.Clear();

                Nota = Convert.ToInt32(beat[I]);
                Frecuencia = ObtenerFrecuencia(Nota,Octava);

                Console.Write("   ");
                while (i < beat.Length)
                {
                    Console.Write("-");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Si ");
                while (i < beat.Length)
                {
                    if ((Nota == 12)&&(beat[i]=="12"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(" ");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("La ");
                while (i < beat.Length)
                {
                    if ((Nota == 11) && (beat[i] == "11") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Nota == 10) && (beat[i] == "10") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write("-");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Sl ");
                while (i < beat.Length)
                {
                    if ((Nota == 9) && (beat[i] == "9") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Nota == 8) && (beat[i] == "8") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(" ");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Fa ");
                while (i < beat.Length)
                {
                    if ((Nota == 7) && (beat[i] == "7") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Nota == 6) && (beat[i] == "6") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write("-");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Mi ");
                while (i < beat.Length)
                {
                    if ((Nota == 5) && (beat[i] == "5") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(" ");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Re ");
                while (i < beat.Length)
                {
                    if ((Nota == 4) && (beat[i] == "4") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Nota == 3) && (beat[i] == "3") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write("-");
                    i++;
                }
                Console.Write("\n");
                i = 0;

                Console.Write("Do ");
                while (i < beat.Length)
                {
                    if ((Nota == 2) && (beat[i] == "2")&&(I==i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Nota == 1) && (beat[i] == "1") && (I == i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('O');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(" ");
                    i++;
                }
                Console.Write("\n");

                i = 0;

                if (Nota!=0)
                    Console.Beep((int)Frecuencia, bpm);
                else
                    Thread.Sleep(bpm);
                I++;
            }
        }
    }
}
