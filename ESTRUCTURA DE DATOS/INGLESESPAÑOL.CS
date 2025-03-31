using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Traductor
{
    // Diccionario con palabras en inglés y su traducción al español
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        { "time", "tiempo" }, { "person", "persona" }, { "year", "año" },
        { "way", "camino" }, { "day", "día" }, { "thing", "cosa" },
        { "man", "hombre" }, { "world", "mundo" }, { "life", "vida" },
        { "hand", "mano" }, { "part", "parte" }, { "child", "niño/a" },
        { "eye", "ojo" }, { "woman", "mujer" }, { "place", "lugar" },
        { "work", "trabajo" }, { "week", "semana" }, { "case", "caso" },
        { "point", "punto" }, { "government", "gobierno" }, { "company", "empresa" }
    };

    static void Main()
    {
        // Menú principal del programa
        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase de Inglés a Español");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            if (input == "0") break;
            
            switch (input)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void TraducirFrase()
    {
        // Solicita una frase al usuario y la procesa para traducir las palabras conocidas
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            // Se eliminan signos de puntuación para comparar correctamente
            string palabraLimpia = Regex.Replace(palabras[i], "[^a-zA-ZáéíóúüñÁÉÍÓÚÜÑ]", "").ToLower();

            // Reemplaza palabras si están en el diccionario
            if (diccionario.ContainsKey(palabraLimpia))
            {
                palabras[i] = palabras[i].Replace(palabraLimpia, diccionario[palabraLimpia]);
            }
            else if (diccionario.ContainsValue(palabraLimpia))
            {
                foreach (var kvp in diccionario)
                {
                    if (kvp.Value == palabraLimpia)
                    {
                        palabras[i] = palabras[i].Replace(palabraLimpia, kvp.Key);
                        break;
                    }
                }
            }
        }
        
        // Muestra la frase traducida
        Console.WriteLine("Frase traducida: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra()
    {
        // Permite al usuario agregar nuevas palabras al diccionario
        Console.Write("Ingrese la palabra en que requiere traducir: ");
        string ingles = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español de la palabra ingresada: ");
        string espanol = Console.ReadLine().ToLower();

        // Verifica si la palabra ya existe antes de agregarla
        if (!diccionario.ContainsKey(ingles) && !diccionario.ContainsValue(espanol))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada de manera correcta.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
