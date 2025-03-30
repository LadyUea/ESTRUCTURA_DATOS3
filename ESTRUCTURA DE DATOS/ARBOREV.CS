using System;
using System.Collections.Generic;

class Nodo
{
    public string Valor;
    public Nodo Izquierdo, Derecho;
    
    public Nodo(string valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;
    
    public ArbolBinario()
    {
        raiz = null;
    }
    
    public void Insertar(string valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }
    
    private Nodo InsertarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
            return new Nodo(valor);
        
        if (string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase) < 0)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase) > 0)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
        
        return nodo;
    }
    
    public bool Buscar(string valor)
    {
        return BuscarRecursivo(raiz, valor);
    }
    
    private bool BuscarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
            return false;
        if (nodo.Valor.Equals(valor, StringComparison.OrdinalIgnoreCase))
            return true;
        return string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase) < 0
            ? BuscarRecursivo(nodo.Izquierdo, valor)
            : BuscarRecursivo(nodo.Derecho, valor);
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
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
        
        foreach (var titulo in catalogo)
        {
            arbol.Insertar(titulo);
        }
        
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título en el árbol");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            
            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string titulo = Console.ReadLine();
                bool encontrado = arbol.Buscar(titulo);
                Console.WriteLine(encontrado ? "Título encontrado." : "Título no encontrado.");
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
}
