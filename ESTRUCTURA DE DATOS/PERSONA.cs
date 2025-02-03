class Persona
{
    public string Nombre { get; set; }
    public int Id { get; set; }

    public Persona(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}
