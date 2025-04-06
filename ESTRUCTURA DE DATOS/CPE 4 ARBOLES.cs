using System;
using System.Collections.Generic;

namespace PracticoGrafosArboles
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Menú Principal ---");
                Console.WriteLine("1. Cálculo de métricas de centralidad");
                Console.WriteLine("2. Búsqueda de vuelos baratos");
                Console.WriteLine("3. Gráfica de grafos");
                Console.WriteLine("4. Gráfica de árboles");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Centralidad.Calcular();
                        break;
                    case "2":
                        Vuelos.BuscarRutaMasBarata();
                        break;
                    case "3":
                        Grafos.Mostrar();
                        break;
                    case "4":
                        Arboles.Mostrar();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static class Centralidad
    {
        public static void Calcular()
        {
            Console.WriteLine("\n--- Cálculo de centralidad ---");
            // Aquí irá una implementación básica con matriz de adyacencia
            // y cálculo de grado por nodo (como ejemplo)
            int[,] grafo = {
                {0, 1, 1, 0},
                {1, 0, 1, 1},
                {1, 1, 0, 1},
                {0, 1, 1, 0}
            };

            int nodos = grafo.GetLength(0);
            for (int i = 0; i < nodos; i++)
            {
                int grado = 0;
                for (int j = 0; j < nodos; j++)
                {
                    if (grafo[i, j] == 1) grado++;
                }
                Console.WriteLine($"Nodo {i} - Grado: {grado}");
            }
        }
    }

    static class Vuelos
    {
        public class Ruta
        {
            public string Origen;
            public string Destino;
            public int Costo;
        }

        public static void BuscarRutaMasBarata()
        {
            Console.WriteLine("\n--- Búsqueda de vuelos baratos ---");
            var rutas = new List<Ruta>
            {
                new Ruta {Origen = "A", Destino = "B", Costo = 100},
                new Ruta {Origen = "B", Destino = "C", Costo = 150},
                new Ruta {Origen = "A", Destino = "C", Costo = 300},
                new Ruta {Origen = "C", Destino = "D", Costo = 200},
                new Ruta {Origen = "B", Destino = "D", Costo = 250}
            };

            Console.Write("Ingrese ciudad origen: ");
            string origen = Console.ReadLine()?.ToUpper();
            Console.Write("Ingrese ciudad destino: ");
            string destino = Console.ReadLine()?.ToUpper();

            // Algoritmo simplificado: mostrar rutas directas más baratas
            int menorCosto = int.MaxValue;
            Ruta mejorRuta = null;

            foreach (var ruta in rutas)
            {
                if (ruta.Origen == origen && ruta.Destino == destino && ruta.Costo < menorCosto)
                {
                    menorCosto = ruta.Costo;
                    mejorRuta = ruta;
                }
            }

            if (mejorRuta != null)
            {
                Console.WriteLine($"Ruta encontrada: {mejorRuta.Origen} -> {mejorRuta.Destino} por ${mejorRuta.Costo}");
            }
            else
            {
                Console.WriteLine("No se encontró ruta directa.");
            }
        }
    }

    static class Grafos
    {
        public static void Mostrar()
        {
            Console.WriteLine("\n--- Ejemplo de Grafo 1 ---");
            Console.WriteLine("A - B");
            Console.WriteLine("A - C");
            Console.WriteLine("B - C");
            Console.WriteLine("C - D");

            Console.WriteLine("\n--- Ejemplo de Grafo 2 (Dirigido) ---");
            Console.WriteLine("A -> B");
            Console.WriteLine("B -> C");
            Console.WriteLine("C -> A");
            Console.WriteLine("C -> D");
        }
    }

    static class Arboles
    {
        public static void Mostrar()
        {
            Console.WriteLine("\n--- Árbol Binario ---");
            Console.WriteLine("        10");
            Console.WriteLine("       /  \\");
            Console.WriteLine("      5   15");
            Console.WriteLine("     / \");
            Console.WriteLine("    3   7");

            Console.WriteLine("\n--- Árbol General ---");
            Console.WriteLine("         A");
            Console.WriteLine("      /  |  \\");
            Console.WriteLine("     B   C   D");
            Console.WriteLine("         |");
            Console.WriteLine("         E");
        }
    }
}
