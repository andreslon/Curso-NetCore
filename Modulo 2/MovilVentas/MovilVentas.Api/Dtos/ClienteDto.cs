using System;
using System.ComponentModel.DataAnnotations;

namespace MovilVentas.Api.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }

        public decimal Comision { get; set; }

    }
}
