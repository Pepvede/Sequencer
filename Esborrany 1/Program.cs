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

        //Obtener las frecuencias
        static double ObtenerFrecuencia(int nota, int octava)
        {
            //Ecuación para obtener una frecuencia de cualquier nota
            double auxiliar=(octava-4)*12+(nota-10);
            auxiliar=Math.Pow(2, auxiliar / 12);
            return(440.0* auxiliar);
        }

        //Funció para editar las partituras
        static void Partitura_Editar(string[] beat, int j, int k, string NumNota_1, string NumNota_2, int J)
        {
            int i = 0;

            //Escribe una sola línea del pentagrama (una sola nota)de longitud beat.Lenght
            //  i = contador de columna de la partitura
            //  j = Ubicación vertical del selector en el pentagrama
            //  J = contador de fila del pentagrama
            //  k = Ubicación horizontal del selector en el pentagrama
            //  NumNota_1 = Código de las notas (sostenidas)
            //  NumNota_2 = Código de las notas (normales)
            //Para las notas que no tienen sostenido, NumNota_1=13
            while (i < beat.Length)
            {
                //Si las coordenadas del marcador coinciden con la actual, escribe el marcador
                if ((j == J) && (k == i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('X');
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //Si en la posición i hay una nota sostenida, escribe #
                else if (beat[i] == NumNota_1)
                {
                    Console.Write('#');
                }
                //Si en la posición i hay una nota normal, escribe o
                else if (beat[i] == NumNota_2)
                {
                    Console.Write('o');
                }
                //Si en la posición i no hay nota, escribe " " o "-" según la fila.
                else if (J%2==0)
                    Console.Write(" ");
                else
                    Console.Write("-");
                i++;
            }
                Console.Write("\n");
        }

        //Funció para reproducir las partituras
        static void Partitura_Reproducir(string[] beat, int I, int Nota, string NumNota_1, string NumNota_2, int J_1, int J_2, bool Espacio)
        {
            int i = 0;

            //Escribe una sola línea del pentagrama (una sola nota)de longitud beat.Lenght
            //  i = contador de columna de la partitura
            //  I = Posició horizontal de una sola nota en concreto
            //  J_1 = Integral con el código de las notas (sostenidas)
            //  J_2 = Integral con el código de las notas (normales)
            //  NumNota_1 = String con el código de las notas (sostenidas)
            //  NumNota_2 = String con el código de las notas (normales)
            //Para las notas que no tienen sostenido, NumNota_1=13
            //  Nota = Código de la nota con la que se está trabajando
            //  Espacio = booleana para saber si, en caso de no haber nota en esa posición,
            //  debe escribirse guión o espacio.
            while (i < beat.Length)
            {
                //Si la nota que se está tratando es sostenida y se encuentra en la posición
                //actual, escribe #
                if ((Nota == J_1) && (beat[i] == NumNota_1) && (I == i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('#');
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //Si la nota que se está tratando es normal y se encuentra en la posición
                //actual, escribe O
                else if ((Nota == J_2) && (beat[i] == NumNota_2) && (I == i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('O');
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //Si en esta posición no hay nota, escribe espacio o guión según la fila
                else if (Espacio)
                    Console.Write(" ");
                else
                    Console.Write("-");
                i++;
            }
            Console.Write("\n");
        }

        //Función para desplazarse por los diferentes menús
        static int SeleccionMenu(string[] dirs,int Selector, CListaPartituras Partituras)
        {
            bool Seleccionado = false;
            int ContadorOpciones = 0;

            //  Selector = Opción del menú que está seleccionada en este momento
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
            return (Selector);
        }

        static void Main(string[] args)
        {
            int i = 0, bpm=300, Octava=4, Nota=0, I=0, Menu, IniciApp=0, j = 0, k = 0, Selector = 0, J=0, J_1=0, J_2=0;
            double Frecuencia = 0;
            string ID, Nom, fila, NumNota_1, NumNota_2;
            bool Sortir = false, SalirDelPrograma=false, Espacio=false;

            CListaPartituras Partituras = new CListaPartituras();
            Partituras.ListaPartituras = new CPartitura[100];

            while (!SalirDelPrograma)
            {
                string[] dirs = Directory.GetFiles(@".\", "*.txt");
                IniciApp = 0;
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

                Menu = 0;
                Selector = 0;
                Sortir = false;
                j = 0;
                k = 0;
                i = 0;
                I = 0;

                Console.WriteLine("Escribe el número de la opció correspondiente y pulsa Enter \n");
                Console.WriteLine("1- Crear nueva partitura");
                Console.WriteLine("2- Modificar partitura existente");
                Console.WriteLine("3- Reproducir partitura");
                Console.WriteLine("4- Salir");

                try
                {
                    Menu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("El carácter introducido no es válido," +
                        " pulsa Enter para continuar");
                    Console.ReadKey();
                }


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
                                Escritor.WriteLine("0.0.0.0.0.0.0.0");
                            }
                        }
                        Partituras.ListaPartituras[IniciApp] = new CPartitura();
                        Partituras.ListaPartituras[IniciApp].ID = Convert.ToString(IniciApp);
                        Partituras.ListaPartituras[IniciApp].Nom = NombreFichero;
                        Partituras.ListaPartituras[IniciApp].Ubicacio = @".\" + NombreFichero + ".txt";
                        break;

                    case 2:
                        if (dirs.Length==0)
                        {
                            Console.WriteLine("Todavía no existe ninguna partitura");
                        }
                        else
                        {
                            Selector = 0;
                            Selector = SeleccionMenu(dirs, Selector, Partituras);

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

                                Console.WriteLine("Usa las teclas W,A,S,D para desplazarte por el pentagrama. Edita la nota con la barra espaciadora. Pulsa Esc para salir sin guardar i G para guardar.");

                                Console.Write("\n");
                                Console.Write("\n");

                                Console.Write("    ");
                                while (i < beat.Length)
                                {
                                    Console.Write("-");
                                    i++;
                                }
                                Console.Write("\n");
                                i = 0;

                                Console.Write("Si  ");
                                NumNota_1 = "13";
                                NumNota_2 = "12";
                                J = 0;
                                Partitura_Editar(beat,j,k,NumNota_1,NumNota_2,J);


                                Console.Write("La  ");
                                NumNota_1 = "11";
                                NumNota_2 = "10";
                                J = 1;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

                                Console.Write("Sol ");
                                NumNota_1 = "9";
                                NumNota_2 = "8";
                                J = 2;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

                                Console.Write("Fa  ");
                                NumNota_1 = "7";
                                NumNota_2 = "6";
                                J = 3;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

                                Console.Write("Mi  ");
                                NumNota_1 = "13";
                                NumNota_2 = "5";
                                J = 4;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

                                Console.Write("Re  ");
                                NumNota_1 = "4";
                                NumNota_2 = "3";
                                J = 5;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

                                Console.Write("Do  ");
                                NumNota_1 = "2";
                                NumNota_2 = "1";
                                J = 6;
                                Partitura_Editar(beat, j, k, NumNota_1, NumNota_2, J);

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
                        }

                        break;

                    case 3:

                        if (dirs.Length == 0)
                        {
                            Console.WriteLine("Todavía no existe ninguna partitura");
                        }
                        else
                        {
                            Selector = 0;
                            Selector = SeleccionMenu(dirs, Selector, Partituras);

                            Sortir = false;
                            j = 0;
                            k = 0;

                            StreamReader X = new StreamReader(Partituras.ListaPartituras[Selector].Ubicacio);
                            fila = X.ReadLine();
                            fila = X.ReadLine();
                            X.Close();
                            string[] beat = fila.Split('.');

                            while (I< beat.Length)
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
                                J_1= 13;
                                J_2 = 12;
                                NumNota_1 = "13";
                                NumNota_2 = "12";
                                Espacio = true;
                                Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2,Espacio);

                            Console.Write("La ");
                            J_1 = 11;
                            J_2 = 10;
                            NumNota_1 = "11";
                            NumNota_2 = "10";
                            Espacio = false;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            Console.Write("Sl ");
                            J_1 = 9;
                            J_2 = 8;
                            NumNota_1 = "9";
                            NumNota_2 = "8";
                            Espacio = true;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            Console.Write("Fa ");
                            J_1 = 7;
                            J_2 = 6;
                            NumNota_1 = "7";
                            NumNota_2 = "6";
                            Espacio = false;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            Console.Write("Mi ");
                            J_1 = 13;
                            J_2 = 5;
                            NumNota_1 = "13";
                            NumNota_2 = "5";
                            Espacio = true;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            Console.Write("Re ");
                            J_1 = 4;
                            J_2 = 3;
                            NumNota_1 = "4";
                            NumNota_2 = "3";
                            Espacio = false;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            Console.Write("Do ");
                            J_1 = 2;
                            J_2 = 1;
                            NumNota_1 = "2";
                            NumNota_2 = "1";
                            Espacio = true;
                            Partitura_Reproducir(beat, I, Nota, NumNota_1, NumNota_2, J_1, J_2, Espacio);

                            if (Nota!=0)
                                    Console.Beep((int)Frecuencia, bpm);

                            I++;
                            }
                        }


                        break;
                    case 4:
                        SalirDelPrograma = true;
                        break;
                    default:
                        Console.WriteLine("Número no válido," +
                            " pulsa Enter para continuar");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
