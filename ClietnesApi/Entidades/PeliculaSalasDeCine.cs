namespace ClientesAPI.Entidades
{
    public class PeliculaSalasDeCine
    {
        public int PeliculaId { get; set; }
        public int SalaDeCineId { get; set; }
        public Pelicula Pelicula { get; set; }
        public SalaDeCine SalaDeCine { get; set; }
    }
}
