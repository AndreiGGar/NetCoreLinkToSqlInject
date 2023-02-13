namespace NetCoreLinkToSqlInject.Models
{
    public class Coche : ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMax { get; set; }

        public Coche()
        {
            this.Marca = "Dodge";
            this.Modelo = "Viper";
            this.Imagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Aewroi.jpg/1200px-Aewroi.jpg";
            this.Velocidad = 0;
            this.VelocidadMax = 320;
        }

        public int Acelerar()
        {
            this.Velocidad += 20;
            if (this.Velocidad > VelocidadMax)
            {
                this.Velocidad = this.VelocidadMax;
            }
            return this.Velocidad;
        }

        public int Frenar()
        {
            this.Velocidad -= 20;
            if (this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;  
        }
    }
}
