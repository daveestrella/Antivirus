/****************************************************************************************
 Integrantes:David Estrella, David Maldonado, Edson Márquez, Jimmy Rivera, Andrés Vásquez 

 Curso: Tercero de Sistemas y Computación

 Año: I Semestre 2017-2018

 Materia: Estructuras II

 Profesor: Ing. Jorge Alarcón

 Descripción: Para resolver este problema se uso un arreglo de listas de strings para 
 representar los archivos y registros. Para las plantaciones de virus se usó control de 
 excepciones para evitar que los virus se expandan mas alla del tamaño del arreglo y las 
 listas. Además se usó lista de strings para hacer el programa más entendible marcando
 los archivos infectados como "infectados". Se usó funciones para calcular los valores
 de respuesta que son el numero maximo de registros infectados y numero de registros no
 infectados.
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antivirus
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string>[] Archivos; //Arreglo (del tamaño del número de archivos) de listas(con elementos igual al número de registros)
            List<string>[] aux; //Arreglo auxiliar que copia los valores de "Archivos" para no modificar el arreglo original
            string[] numregistros; //Arreglo con los numeros de registros de cada archivo
            int[,] respuesta; //Arreglo bidimensional con las respuestas que se presentan por consola
            int indice; //Entero que almacena el indice del archivo
            int numconsultas; //Entero que almacena el numero de consultas
            string[] consulta; //Arreglo de strings que contiene los 3 inputs una consulta
            int i,j,k,r; //Contadores de bucles (r es un contador exclusivo para el arreglo "respuesta")

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ANTIVIRUS\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INPUT\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Número de Archivos: ");

            Archivos = new List<string>[int.Parse(Console.ReadLine())];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Número de Registros de cada archivo: ");

            numregistros = Console.ReadLine().Split(' ');

            for (i = 0; i < Archivos.Length; i++) //Se repite mientras sea menor al numero de archivos ingresado
            {
                Archivos[i] = new List<string>();
                for (j = 0; j < int.Parse(numregistros[i]); j++) //Se llena la lista de cadenas vacias mientras sea menor al numero de registros ingresado
                {
                    Archivos[i].Add("");
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Número de Consultas: ");

            numconsultas = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese las consultas: ");

            respuesta = new int[numconsultas, 2];
            for (r=0,i=0;i<numconsultas;i++) //Se repite mientras sea menor al numero de consultas ingresado
            {
                consulta = Console.ReadLine().Split(' ');

                indice = int.Parse(consulta[1])-1;

                if (consulta[0]=="1") //Si el primer valor es 1 es para cambiar el numero de registros del archivo
                {
                    Archivos[indice] = new List<string>();
                    for (j = 0; j < int.Parse(consulta[2]); j++)
                        Archivos[indice].Add("");
                        
                }
                else //Si es 2 u otro es para plantar un virus
                {
                    aux = new List<string>[Archivos.Length];
                    Clonar(Archivos, aux);

                    if (consulta[2] == "1") //Si el virus es tipo A
                    {

                        for (j = 0; j < aux[indice].Count; j++) //Se repite mientras sea menor al numero de registros 
                        {
                            try
                            {

                                for (k = 0; k <= j; k++)
                                    if (aux[indice - k][j - k] != null && aux[indice + k][j - k] != null) //Comprueba que hay como expandir el triangulo por ambos lados
                                    {
                                    }

                                for (k = 0; k <= j; k++) //Se marca los registros como infectados
                                {
                                    aux[indice - k][j - k] = "infectado";
                                    aux[indice + k][j - k] = "infectado";
                                }

                            }

                            catch (Exception e)
                            {

                            }
                        }

                        //Se almacena en la matriz de respuesta el maximo de registros infectados y el numero de registros no infectados
                        respuesta[r, 0] = MaximoRegistros(aux);
                        respuesta[r, 1] = RegistrosNoInfectados(aux);
                        r++;

                    }

                    else //Si el virus es tipo B
                    {

                        for (j = 0; j < aux[indice].Count; j++)  //Se repite mientras sea menor al numero de registros
                        {
                            try
                            {

                                for (k = 0; k <= j; k++) //Comprueba que hay como expandir el triangulo por la derecha (En el virus B no importa que este incompleto por la izquierda)
                                    if (aux[indice + k][j - k] != null)
                                    {
                                    }

                                for (k = 0; k <= j; k++) //Se marca los registros como infectados
                                {
                                    aux[indice + k][j - k] = "infectado";
                                    aux[indice - k][j - k] = "infectado";
                                }

                            }

                            catch (Exception e)
                            {

                            }                           
                        }

                        //Se almacena en la matriz de respuesta el maximo de registros infectados y el numero de registros no infectados
                        respuesta[r, 0] = MaximoRegistros(aux);
                        respuesta[r, 1] = RegistrosNoInfectados(aux);
                        r++;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nOUTPUT");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Imprimir(respuesta);


            Console.ReadKey();
        }

        public static void Clonar(List<string>[] fuente, List<string>[] destino)
        {
            int i, j;

            for (i = 0; i < fuente.Length; i++)
            {
                destino[i] = new List<string>();
                for (j = 0; j < fuente[i].Count; j++)
                    destino[i].Add(fuente[i][j]);
            }
        } //Funcion que copia lo elementos de un arreglo de listas a otro

        public static void Dibujar()
        {

        }
        public static void Imprimir(int[,] arr)
        {
            int i, j;

            for (i = 0; i < arr.GetLength(0); i++)
            {
                for (j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, 0] == 0)
                        break;
                    Console.Write(arr[i, j] + "  ");
                }


                Console.WriteLine();
            }
        } //Imprime un arreglo bidimensional

        public static int MaximoRegistros(List<string>[] arr)
        {
            int i, j;
            int maximo = 0;

            for (i = 0; i < arr.Length; i++)
                for(j=0;j<arr[i].Count;j++)
                    if (arr[i][j] == "infectado")
                    {
                        if (j > maximo)
                            maximo = j;
                    }

            return (maximo+1);
        } //Calcula el numero maximo de registros que se han infectado

        public static int RegistrosNoInfectados(List<string>[]arr)
        {
            int i,j;
            int total=0;
            int numinfectados=0;

            for (i = 0; i < arr.Length; i++)
                for (j = 0; j < arr[i].Count; j++)
                {
                    if (arr[i][0] == "infectado")
                    {
                        total++;

                        if (arr[i][j] == "infectado")
                            numinfectados++;
                    }

                    else
                        break;
                }


            return (total-numinfectados);
        } //Calcula el numero de registros que no han sido infectados
    }

}
