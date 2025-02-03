using System;
using System.Collections.Generic;

class ColaEspera
{
    private Queue<Persona> cola = new Queue<Persona>();

    public void Encolar(Persona persona)
    {
        cola.Enqueue(persona);
    }

    public Persona Desencolar()
    {
        return cola.Count > 0 ? cola.Dequeue() : null;
    }

    public List<Persona> ObtenerCola()
    {
        return new List<Persona>(cola);
    }
}
