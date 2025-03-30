using System;
using System.Collections.Generic;

class CatalogoRevistas
{
    private List<string> catalogo;
    
    public CatalogoRevistas()
    {
        catalogo = new List<string>();
    }
    
    public void AgregarRevista(string titulo)
    {
        catalogo.Add(titulo);
    }
    
    public bool BuscarIterativo(string titulo)
    {
        foreach (var revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    
    public bool BuscarRecursivo(string titulo, int index = 0)
    {
        if (index >= catalogo.Count) return false;
        if (catalogo[index].Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;
        return BuscarRecursivo(titulo, index + 1);
    }
    
    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMenú del Catálogo de Revistas:");
            Console.WriteLine("1. Buscar título (iterativo)");
            Console.WriteLine("2. Buscar título (recursivo)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }
            
            if (opcion == 3) break;
            
            Console.Write("Ingrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();
            
            bool encontrado = opcion == 1 ? BuscarIterativo(titulo) : BuscarRecursivo(titulo);
            Console.WriteLine(encontrado ? "Título encontrado" : "Título no encontrado");
        }
    }
}

class Program
{
    static void Main()
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();
        
        Console.WriteLine("Ingrese 10 títulos de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: ");
            string titulo = Console.ReadLine();
            catalogo.AgregarRevista(titulo);
        }
        
        catalogo.MostrarMenu();
    }
}
