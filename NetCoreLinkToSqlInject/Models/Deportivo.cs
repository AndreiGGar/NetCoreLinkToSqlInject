namespace NetCoreLinkToSqlInject.Models
{
    public class Deportivo : ICoche
    {
        public Deportivo()
        {
            this.Marca = "Koenigsegg";
            this.Modelo = "Regera";
            this.Imagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Regera_%28light_gradient%29.png/1200px-Regera_%28light_gradient%29.png";
            this.Velocidad = 0;
            this.VelocidadMax = 400;
        }
        public string Marca { get ; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMax { get; set; }

        public int Acelerar()
        {
            this.Velocidad += 60;
            if (this.Velocidad > this.VelocidadMax)
            {
                this.Velocidad = this.VelocidadMax;
            }
            return this.Velocidad;
        }

        public int Frenar()
        {
            this.Velocidad -= 30;
            if (this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;
        }
    }
}
