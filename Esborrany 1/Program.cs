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
        public class CPartitura
        {
            public string Nom;
            public string Ubicacio;
            public string ID;
        }
        public class CListaPartituras
        {
            public CPartitura[] ListaPartituras;
        }

        static double ObtenerFrecuencia(int nota, int octava)
        {
            double auxiliar=(octava-4)*12+(nota-10);
            auxiliar=Math.Pow(2, auxiliar / 12);
            return(440.0* auxiliar);
        }
        static void Main(string[] args)
        {
            int i = 0, bpm=350, Octava=4, Nota=0, I=0, Menu, IniciApp=0, j = 0, k = 0, Selector = 0, ContadorOpciones = 0; ;
            double Frecuencia = 0;
            string ID, Nom, fila;
            bool Sortir = false, Seleccionado = false;

            string[] dirs = Directory.GetFiles(@".\", "*.txt");
            CListaPartituras Partituras = new CListaPartituras();
            Partituras.ListaPartituras = new CPartitura[100];
            while (IniciApp < dirs.Length)
            {
                StreamReader Reader = new StreamReader(dirs[IniciApp]);
                Nom = Reader.ReadLine();
                Reader.Close();

                Partituras.ListaPartituras[IniciApp] = new CPartitura();
                Partituras.ListaPartituras[IniciApp].ID = Convert.ToString(IniciApp);
                Partituras.ListaPartituras[IniciApp].Nom = Nom;
                Partituras.ListaPartituras[IniciApp].Ubicacio = dirs[IniciApp];

                IniciApp++;
            }

            Console.WriteLine("1- Crear nueva partitura");
            Console.WriteLine("2- Modificar partitura existente");
            Console.WriteLine("3- Reproducir partitura");
            Console.WriteLine("4- Salir");

            Menu = Convert.ToInt32(Console.ReadLine());
            switch(Menu){
                case 1:

                    Console.WriteLine("Introduce el nombre del fichero");
                    string NombreFichero = Console.ReadLine();

                    string path = @".\" + NombreFichero + ".txt";
                    if (!File.Exists(path))
                    {
                        using (StreamWriter Escritor = File.CreateText(path))
                        {
                            Escritor.WriteLine(NombreFichero);
                            Escritor.WriteLine("0.0.0.0");
                        }
                    }
                    Partituras.ListaPartituras[IniciApp] = new CPartitura();
                    Partituras.ListaPartituras[IniciApp].ID = Convert.ToString(IniciApp);
                    Partituras.ListaPartituras[IniciApp].Nom = NombreFichero;
                    Partituras.ListaPartituras[IniciApp].Ubicacio = @".\" + NombreFichero + ".txt";
                    break;

                case 2:
                    Selector = 0;
                    ContadorOpciones =0;
                    Seleccionado = false;

                    while (!Seleccionado)
                    {
                        Console.Clear();
                        while (ContadorOpciones<dirs.Length) {
                            if (Selector == ContadorOpciones)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine(Partituras.ListaPartituras[ContadorOpciones].Nom);
                            Console.ForegroundColor = ConsoleColor.White;
                            ContadorOpciones++;
                        }
                        ContadorOpciones = 0;

                        ConsoleKeyInfo EntradaUsuario = Console.ReadKey();
                        if ((EntradaUsuario.KeyChar == 'w')&&(Selector>0))
                        {
                            Selector--;
                        }
                        if ((EntradaUsuario.KeyChar == 's')&& (Selector < dirs.Length-1))
                        {
                            Selector++;
                        }
                        if (EntradaUsuario.Key == ConsoleKey.Spacebar)
                        {
                            Seleccionado = true;
                        }
                    }

                    Sortir = false;
                    j = 0;
                    k = 0;

                    StreamReader F = new StreamReader(Partituras.ListaPartituras[Selector].Ubicacio);
                    fila = F.ReadLine();
                    fila = F.ReadLine();
                    F.Close();
                    string[] beat = fila.Split('.');

                    while (!Sortir)
                    {
                        while (I < beat.Length)
                        {
                            Console.Clear();

                            Console.Write("    ");
                            while (i < beat.Length)
                            {
                                Console.Write("-");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Si  ");
                            while (i < beat.Length)
                            {
                                if ((j == 0) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "12")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write(" ");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("La  ");
                            while (i < beat.Length)
                            {
                                if ((j == 1) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "11")
                                {
                                    Console.Write('#');
                                }
                                else if (beat[i] == "10")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write("-");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Sol ");
                            while (i < beat.Length)
                            {
                                if ((j == 2) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "9")
                                {
                                    Console.Write('#');
                                }
                                else if (beat[i] == "8")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write(" ");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Fa  ");
                            while (i < beat.Length)
                            {
                                if ((j == 3) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "7")
                                {
                                    Console.Write('#');
                                }
                                else if (beat[i] == "6")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write("-");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Mi  ");
                            while (i < beat.Length)
                            {
                                if ((j == 4) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "5")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write(" ");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Re  ");
                            while (i < beat.Length)
                            {
                                if ((j == 5) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "4")
                                {
                                    Console.Write('#');
                                }
                                else if (beat[i] == "3")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write("-");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;

                            Console.Write("Do  ");
                            while (i < beat.Length)
                            {
                                if ((j == 6) && (k == i))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write('X');
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (beat[i] == "2")
                                {
                                    Console.Write('#');
                                }
                                else if (beat[i] == "1")
                                {
                                    Console.Write('o');
                                }
                                else
                                    Console.Write(" ");
                                i++;
                            }
                            Console.Write("\n");
                            i = 0;
                            I++;
                        }
                        I = 0;
                        ConsoleKeyInfo Moviment = Console.ReadKey();
                        if ((Moviment.KeyChar == 'a') && (k > 0))
                        {
                            k--;
                        }
                        if ((Moviment.KeyChar == 'd') && (k < beat.Length - 1))
                        {
                            k++;
                        }
                        if ((Moviment.KeyChar == 'w') && (j > 0))
                        {
                            j--;
                        }
                        if ((Moviment.KeyChar == 's') && (j < 6))
                        {
                            j++;
                        }
                        if (Moviment.Key == ConsoleKey.Spacebar)
                        {
                            switch (j)
                            {
                                case 0:
                                    if (beat[k] == "12")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "12";
                                    break;
                                case 1:
                                    if (beat[k] == "10")
                                    {
                                        beat[k] = "11";
                                    }
                                    else if (beat[k] == "11")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "10";
                                    break;
                                case 2:
                                    if (beat[k] == "8")
                                    {
                                        beat[k] = "9";
                                    }
                                    else if (beat[k] == "9")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "8";
                                    break;
                                case 3:
                                    if (beat[k] == "6")
                                    {
                                        beat[k] = "7";
                                    }
                                    else if (beat[k] == "7")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "6";
                                    break;
                                case 4:
                                    if (beat[k] == "5")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "5";
                                    break;
                                case 5:
                                    if (beat[k] == "3")
                                    {
                                        beat[k] = "4";
                                    }
                                    else if (beat[k] == "4")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "3";
                                    break;
                                case 6:
                                    if (beat[k] == "1")
                                    {
                                        beat[k] = "2";
                                    }
                                    else if (beat[k] == "2")
                                    {
                                        beat[k] = "0";
                                    }
                                    else
                                        beat[k] = "1";
                                    break;
                            }
                        }
                        if (Moviment.Key == ConsoleKey.Escape)
                        {
                            Sortir = true;
                            Console.Clear();
                        }
                        if (Moviment.KeyChar == 'g')
                        {
                            Sortir = true;

                            using (StreamWriter GuardarPartitura = File.CreateText(Partituras.ListaPartituras[Selector].Ubicacio))
                            {
                                GuardarPartitura.WriteLine(Partituras.ListaPartituras[Selector].Nom);

                                while (i<beat.Length)
                                {
                                    if(i == beat.Length - 1)
                                    {
                                        GuardarPartitura.Write(beat[i]);
                                    }
                                    else
                                    {
                                        GuardarPartitura.Write(beat[i]+'.');
                                    }
                                    i++;
                                }
                            }
                            Console.Clear();
                        }
                    }
                    break;

                case 3:

                    Selector = 0;
                    ContadorOpciones = 0;
                    Seleccionado = false;

                    while (!Seleccionado)
                    {
                        Console.Clear();
                        while (ContadorOpciones < dirs.Length)
                        {
                            if (Selector == ContadorOpciones)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine(Partituras.ListaPartituras[ContadorOpciones].Nom);
                            Console.ForegroundColor = ConsoleColor.White;
                            ContadorOpciones++;
                        }
                        ContadorOpciones = 0;

                        ConsoleKeyInfo EntradaUsuario = Console.ReadKey();
                        if ((EntradaUsuario.KeyChar == 'w') && (Selector > 0))
                        {
                            Selector--;
                        }
                        if ((EntradaUsuario.KeyChar == 's') && (Selector < dirs.Length - 1))
                        {
                            Selector++;
                        }
                        if (EntradaUsuario.Key == ConsoleKey.Spacebar)
                        {
                            Seleccionado = true;
                        }
                    }

                    Sortir = false;
                    j = 0;
                    k = 0;

                    StreamReader X = new StreamReader(Partituras.ListaPartituras[Selector].Ubicacio);
                    fila = X.ReadLine();
                    fila = X.ReadLine();
                    X.Close();
                    string[] beat_2 = fila.Split('.');

                    while (I<beat_2.Length)
                    {
                        Console.Clear();

                        Nota = Convert.ToInt32(beat_2[I]);
                        Frecuencia = ObtenerFrecuencia(Nota,Octava);

                        Console.Write("   ");
                        while (i < beat_2.Length)
                        {
                            Console.Write("-");
                            i++;
                        }
                        Console.Write("\n");
                        i = 0;

                        Console.Write("Si ");
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 12)&&(beat_2[i]=="12"))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 11) && (beat_2[i] == "11") && (I == i))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('#');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if ((Nota == 10) && (beat_2[i] == "10") && (I == i))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 9) && (beat_2[i] == "9") && (I == i))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('#');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if ((Nota == 8) && (beat_2[i] == "8") && (I == i))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 7) && (beat_2[i] == "7") && (I == i))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('#');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if ((Nota == 6) && (beat_2[i] == "6") && (I == i))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 5) && (beat_2[i] == "5") && (I == i))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 4) && (beat_2[i] == "4") && (I == i))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('#');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if ((Nota == 3) && (beat_2[i] == "3") && (I == i))
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
                        while (i < beat_2.Length)
                        {
                            if ((Nota == 2) && (beat_2[i] == "2")&&(I==i))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('#');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if ((Nota == 1) && (beat_2[i] == "1") && (I == i))
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

                        I++;
                    }
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Carácter incorrecto");
                    break;
            }
        }
    }
}
