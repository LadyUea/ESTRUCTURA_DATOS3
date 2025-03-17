using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear catálogo de revistas con 10 títulos
        List<string> catalogo = new List<string>
        {
            "Revista de Ciencias y Tecnología",
            "Revista de Sistemas Operativos",
            "Revista de Sistemas Digitales",
            "Revista de Locución",
            "Revista de Inglés",
            "Revista de IoT",
            "Revista de Salud",
            "Revista de Viajes y Turismo",
            "Revista de Vestidos de Novia",
            "Revista de Negocios Internacionales"
        };

        // Mostrar menú
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string titulo = Console.ReadLine();
                
                // Llamada a la función de búsqueda (iterativa o recursiva)
                bool encontrado = BuscarTitulo(catalogo, titulo, 0); // Búsqueda iterativa (puedes cambiarla por recursiva)
                if (encontrado)
                {
                    Console.WriteLine("Título encontrado.");
                }
                else
                {
                    Console.WriteLine("Título no encontrado.");
                }
            }
            else if (opcion == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
            }
        }
    }

    // Búsqueda iterativa
    static bool BuscarTitulo(List<string> catalogo, string titulo, int indice)
    {
        for (int i = indice; i < catalogo.Count; i++)
        {
            if (catalogo[i].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    // Búsqueda recursiva (descomentar para usar recursiva)
    /*
    static bool BuscarTituloRecursivo(List<string> catalogo, string titulo, int indice)
    {
        if (indice >= catalogo.Count)
        {
            return false;
        }
        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return BuscarTituloRecursivo(catalogo, titulo, indice + 1);
    }
    */
}
