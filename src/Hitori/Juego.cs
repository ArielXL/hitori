using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hitori
{
    [Serializable]
    public class Juego
    {
        #region //Elementos publicos
        //variables
        public bool[,] Marcado;
        public bool [,] Soluble;
        public int[,] Numeros;
        int dimension;
        int rango1, rango2;
        private Stack<Juego> stackJuego;

        //direcciones
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        // indexer
        public int this[int fila, int columna]
        {
            get { return Numeros[fila, columna]; }
            private set { Numeros[fila, columna] = value; }
        }
        #endregion

        #region //Constructor 
        public Juego(int dimension, int rango1, int rango2)
        {
            Marcado=new bool[dimension,dimension];
            Soluble = new bool[dimension, dimension];
            Numeros = new int[dimension, dimension];
            this.dimension = dimension;
            this.rango1 = rango1;
            this.rango2 = rango2;
            GenerarTablero();

            for (int i = 0; i < Soluble.GetLength(0); i++)
            {
                for (int j = 0; j < Soluble.GetLength(0); j++)
                {
                    if (Soluble[i, j])
                    {
                        Soluble[i, j] = false;
                        Marcado[i, j] = true;
                    }
                }    
            }
        }
        #endregion

        #region //Metodo para crear el tablero
        //Si la posicion pertenece al tablero
        public bool Pertenece( int fila, int columna)
        {
            if(fila >= 0 && columna >= 0 && fila < dimension && columna < dimension)
            return true;
            else
            return false;
        }

        //si no tengo tachada las posiciones adyacentes a mi (estar tachado significa tener valor 0)
        public bool PuedoTachar( int fila, int columna)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Pertenece(fila + dx[i], columna + dy[i]) && Soluble[fila + dx[i], columna + dy[i]])
                    return false;
            }
            return true;
        }

        //creando tablero
        public void GenerarTablero()
        {
            List<Tuple<int, int>> vect = new List<Tuple<int, int>>();
            while (true)
            {
                for (int i = 0; i < Soluble.GetLength(0); i++)
                {
                    for (int j = 0; j < Soluble.GetLength(1); j++)
                    {
                        if (PuedoTachar(i, j))
                        {
                            if (!conectividad(i, j))
                            {
                                Soluble[i, j] = false;
                            }
                            else
                                vect.Add(new Tuple<int, int>(i, j));
                        }
                            
                    }
                }
                if (vect.Count == 0)
                    break;

                Random r = new Random();

                int taches = r.Next(Soluble.GetLength(0), vect.Count + 1);

                int temp = 0;

                Soluble = new bool[dimension, dimension];

                while (temp < taches)
                {
                    int num = r.Next(0, vect.Count);//vec.Count

                    Numeros[vect[num].Item1, vect[num].Item2] = -1;

                    Soluble[vect[num].Item1, vect[num].Item2] = true;

                    temp++;
                }

                if (temp == taches) break;

                vect.Clear();
            }

            for (int i = 0; i < Soluble.GetLength(0); i++)
            {
                for (int j = 0; j < Soluble.GetLength(1); j++)
                {
                    Random r = new Random();

                    if (Numeros[i, j] != -1)
                    {
                        int num = r.Next(rango1, rango2);
                        Numeros[i, j] = num;
                        while (ElemntosRepetidos(Numeros, num, i, j))
                        {
                            num = r.Next(rango1, rango2);
                            Numeros[i, j] = num;
                        }
                    }
                }
            }
            RellenarTablero(Numeros);
        }

        // Comprobar si existe conexion entre las casillas del tablero
        bool conectividad(int a, int b)
        {
            int tachados = 0, sintachar = 0;

            bool[,] pase = new bool[dimension, dimension];

            Soluble[a, b] = true;
            Queue<Tuple<int, int>> cola = new Queue<Tuple<int, int>>();

            int[] direcfil = { -1, 1, 0, 0 };
            int[] direccol = { 0, 0, 1, -1 };

            int aa = 0, bb = 0, na, nb;

            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                {
                    if (Soluble[i, j] == true)
                    {
                        tachados++;
                    }
                    else {
                        aa = i;
                        bb = j;
                    }
                }

            cola.Enqueue(new Tuple<int, int> (aa, bb));

            while (cola.Count > 0) 
            {
                aa = cola.Peek().Item1;
                bb = cola.Peek().Item2;
                cola.Dequeue();
                if (pase[aa, bb])
                    continue;
                pase[aa, bb] = true;
                sintachar++;

                for (int i = 0; i < 4; i++) {
                    na = aa + direcfil[i];
                    nb = bb + direccol[i];
                    if (Pertenece(na, nb) && !Soluble[na, nb] && !pase[na, nb])
                    {
                        cola.Enqueue(new Tuple<int, int>(na, nb));
                    }
                }
            }
            if (tachados + sintachar == dimension * dimension)
                return true;
            Soluble[a, b] = false;
            return false;
        }
        
        //si se repite el elemento
        public bool ElemntosRepetidos(int[,] Numeros, int num, int i, int j)
        {
            for (int k = 0; k < dimension; k++)
            {
                if (Numeros[i, k] == num && k != j)
                        return true;
                if (Numeros[k, j] == num && k != i)
                        return true;
            }
            return false;
        }

        //dar un valor a las posiciones tachadas
        public void RellenarTablero(int[,] Numeros)
        {
            List<int> Valores = new List<int>();
            Random x = new Random();

            for (int a = 0; a < Numeros.GetLength(0); a++)
            {
                for (int b = 0; b < Numeros.GetLength(1); b++)
                {
                    if (Numeros[a, b] == -1)
                    {
                        for (int dir = 0; dir < 4; dir++)
                        {
                            for (int rad = 0; rad < 4; rad++)
                            {
                                if (Pertenece(a + dx[dir] * rad, b + dy[dir] * rad) && Numeros[a + dx[dir] * rad, b + dy[dir] * rad] != -1)
                                    Valores.Add(Numeros[a + dx[dir] * rad, b + dy[dir] * rad]);
                            }
                        }
                        Numeros[a, b] = Valores[x.Next(0, Valores.Count)];
                    }
                }
            }
        }
        #endregion

        #region //Condiciones del Juego
        public bool JuegoTerminado()
        {
            for (int i = 0; i < Numeros.GetLength(0); i++)
            {
                bool[] flags = new bool[564];
                for (int j = 0; j < Numeros.GetLength(1); j++)
                {
                    if (!Soluble[i, j])
                    {
                        if (flags[Numeros[i, j]])
                            return false;
                        else flags[Numeros[i, j]] = true;
                    }
                }
            }

            for (int i = 0; i < Numeros.GetLength(1); i++)
            {
                bool[] flags = new bool[564];
                for (int j = 0; j < Numeros.GetLength(0); j++)
                {
                    if (!Soluble[j,i])
                    {
                        if (flags[Numeros[j, i]])
                            return false;
                        else flags[Numeros[j, i]] = true;
                    }
                }
            }

            return true;
        }

        public void NuevoJuego()
        {
            if (JuegoTerminado() == true || !JuegoTerminado())
                for (int i = 0; i < Marcado.GetLength(0); i++)
                {
                    for (int j = 0; j < Marcado.GetLength(1); j++)
                    {
                        bool[,] Soluble = new bool[dimension, dimension];
                    }
                }
        }

        public void ReiniciarJuego()
        {
            for (int i = 0; i < Soluble.GetLength(0); i++)
            {
                for (int j = 0; j < Soluble.GetLength(1); j++)
                {
                    Soluble[i, j] = false;
                }
            }
        }
        
        public void SaveGame()
        {
            StreamWriter toSave = new StreamWriter("save.txt");
            toSave.WriteLine($"{Numeros.GetLength(0)} {Numeros.GetLength(1)}");

            for (int i = 0; i < Numeros.GetLength(0); i++)
            {
                for (int j = 0; j < Numeros.GetLength(1); j++)
                    toSave.Write(Numeros[j, i] + " ");
                toSave.WriteLine();
            }
            toSave.Close();
        }

        public void CargarGame()
        {
            StreamReader toRead = new StreamReader("save.txt");
            string[] linea = toRead.ReadLine().Split();
            int dimension = int.Parse(linea[0]);
            this.stackJuego = new Stack<Juego>();
            this.Numeros = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                linea = toRead.ReadLine().Split();
                for (int j = 0; j < dimension; j++)
                {
                    this.Numeros[i, j] = int.Parse(linea[j]);
                }
            }
            toRead.Close();
        }
        #endregion

        #region //Para marcar las casillas del tablero 
        public bool TacharBien(int fila, int columna)
        {
            if(Pertenece(fila, columna))
            {
                if (PuedoTachar(fila, columna))
                {
                    if (conectividad(fila, columna))
                        return true;
                    else return false;
                }
                else
                    return false;
            }
            else 
                return false;
        }

        public bool NoPoderTachar(int fila, int columna)
        {
            for (int i = 0; i < Marcado.GetLength(0); i++)
            {
                for (int j = 0; j < Marcado.GetLength(1); j++)
			   {
			        if(Soluble[i,j]==false && !PuedoTachar(i,j) && !conectividad(i,j))
                          Soluble[i,j]=false;                      
			   }
            }
            return true;
        }
        #endregion

        #region // Para mostar el tablero en consola
        public void Mostrar(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (Marcado[i, j] == false)
                        Console.Write(matriz[i, j] + " ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public void run()
        {
            while (!JuegoTerminado())
            {
                Mostrar(Numeros);
                string[] line = Console.ReadLine().Split();

                int a, b;

                a = int.Parse(line[0]);
                b = int.Parse(line[1]);

                if (PuedoTachar(a, b))
                {
                    if (Marcado[a, b] == true)
                        Marcado[a, b] = false;
                    else
                        Marcado[a, b] = true;
                }
            }
        }
        #endregion
    }
}
