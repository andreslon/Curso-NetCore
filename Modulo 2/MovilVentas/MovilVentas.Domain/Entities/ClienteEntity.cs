using System;
namespace MovilVentas.Domain.Entities
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }

        //public ClienteEntity(int id, string nombres)
        //{
        //    this.Id = id;
        //    if (string.IsNullOrEmpty(nombres))
        //    {
        //        throw new Exception("El campo nombres no puede ser vacio");
        //    }
        //    this.Nombres = nombres;
        //}
    }
}
