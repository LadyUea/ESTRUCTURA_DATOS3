using System;

public class Nodo
{
    public int Dato;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(int dato)
    {
        Dato = dato;
        Izquierda = null;
        Derecha = null;
    }
}

public class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Insertar un nodo en el árbol
    public void Insertar(int dato)
    {
        raiz = InsertarRecursivo(raiz, dato);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            nodo = new Nodo(dato);
            return nodo;
        }

        if (dato < nodo.Dato)
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, dato);
        else if (dato > nodo.Dato)
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, dato);

        return nodo;
    }

    // Buscar un nodo en el árbol
    public bool Buscar(int dato)
    {
        return BuscarRecursivo(raiz, dato);
    }

    private bool BuscarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
            return false;

        if (dato == nodo.Dato)
            return true;

        if (dato < nodo.Dato)
            return BuscarRecursivo(nodo.Izquierda, dato);
        else
            return BuscarRecursivo(nodo.Derecha, dato);
    }

    // Recorrido en preorden
    public void Preorden()
    {
        PreordenRecursivo(raiz);
    }

    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            PreordenRecursivo(nodo.Izquierda);
            PreordenRecursivo(nodo.Derecha);
        }
    }

    // Recorrido en inorden
    public void Inorden()
    {
        InordenRecursivo(raiz);
    }

    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Dato + " ");
            InordenRecursivo(nodo.Derecha);
        }
    }

    // Recorrido en postorden
    public void Postorden()
    {
        PostordenRecursivo(raiz);
    }

    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.Izquierda);
            PostordenRecursivo(nodo.Derecha);
            Console.Write(nodo.Dato + " ");
        }
    }

    // Eliminar un nodo
    public void Eliminar(int dato)
    {
        raiz = EliminarRecursivo(raiz, dato);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null) return nodo;

        if (dato < nodo.Dato)
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, dato);
        else if (dato > nodo.Dato)
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, dato);
        else
        {
            if (nodo.Izquierda == null)
                return nodo.Derecha;
            else if (nodo.Derecha == null)
                return nodo.Izquierda;

            nodo.Dato = MinValor(nodo.Derecha);
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Dato);
        }

        return nodo;
    }

    private int MinValor(Nodo nodo)
    {
        int min = nodo.Dato;
        while (nodo.Izquierda != null)
        {
            min = nodo.Izquierda.Dato;
            nodo = nodo.Izquierda;
        }
        return min;
    }
}

public class Programa
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, dato;

        do
        {
            Console.Clear();
            Console.WriteLine("Menú de operaciones con Árbol Binario:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Recorrido en preorden");
            Console.WriteLine("4. Recorrido en inorden");
            Console.WriteLine("5. Recorrido en postorden");
            Console.WriteLine("6. Eliminar nodo");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el dato a insertar: ");
                    dato = int.Parse(Console.ReadLine());
                    arbol.Insertar(dato);
                    Console.WriteLine("Nodo insertado.");
                    break;
                case 2:
                    Console.Write("Ingrese el dato a buscar: ");
                    dato = int.Parse(Console.ReadLine());
                    if (arbol.Buscar(dato))
                        Console.WriteLine("Nodo encontrado.");
                    else
                        Console.WriteLine("Nodo no encontrado.");
                    break;
                case 3:
                    Console.WriteLine("Recorrido en preorden:");
                    arbol.Preorden();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Recorrido en inorden:");
                    arbol.Inorden();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Recorrido en postorden:");
                    arbol.Postorden();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Ingrese el dato a eliminar: ");
                    dato = int.Parse(Console.ReadLine());
                    arbol.Eliminar(dato);
                    Console.WriteLine("Nodo eliminado.");
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        } while (opcion != 7);
    }
}
