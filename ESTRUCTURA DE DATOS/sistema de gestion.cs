using System;

class SistemaDeGestion
{
    public void EjecutarSimulacion()
    {
        ColaEspera cola = new ColaEspera();
        Atraccion atraccion = new Atraccion();

        // Simulación de llegada de personas
        for (int i = 1; i <= 50; i++)
        {
            cola.Encolar(new Persona(i, "Persona " + i));
        }

        Console.WriteLine("Se ha formado la cola de espera con 50 personas.");
        
        // Asignación de los primeros 30 asientos
        atraccion.AsignarAsientos(cola);
        Console.WriteLine("Se han asignado los asientos a las primeras 30 personas.");
        
        GenerarReporte(atraccion);
    }

    public void GenerarReporte(Atraccion atraccion)
    {
        Console.WriteLine("\n--- Reporte de Asignación de Asientos ---");
        foreach (var persona in atraccion.ObtenerAsientos())
        {
            Console.WriteLine($"Asiento ocupado por: {persona.Nombre} (ID: {persona.Id})");
        }
    }
}
