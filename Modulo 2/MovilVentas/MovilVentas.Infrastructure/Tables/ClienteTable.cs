using System;
namespace MovilVentas.Infrastructure.Tables
{
    public class ClienteTable
    { 
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
    }
}
