namespace NetCoreLinkToSqlInject.Models
{
    public interface ICoche
    {
        string Marca { get; set; }
        string Modelo { get; set; }
        string Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMax { get; set; }
        int Acelerar();
        int Frenar();
    }
}
