class Atraccion
{
    private List<Persona> asientos = new List<Persona>();
    private const int CAPACIDAD = 30;

    public void AsignarAsientos(ColaEspera cola)
    {
        while (asientos.Count < CAPACIDAD && cola.ObtenerCola().Count > 0)
        {
            Persona persona = cola.Desencolar();
            asientos.Add(persona);
        }
    }

    public void LiberarAsientos()
    {
        asientos.Clear();
    }

    public List<Persona> ObtenerAsientos()
    {
        return new List<Persona>(asientos);
    }
}
