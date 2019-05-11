using System;
using System.Collections.Generic;
using MovilVentas.Infrastructure.Tables;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovilVentas.Infrastructure.Interfaces;
using MovilVentas.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovilVentas.Infrastructure.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        public MovilVentasContext Context { get; set; }
        public ClienteRepository(MovilVentasContext context)
        {
            Context = context;
        } 
         public List<ClienteTable> GetSample()
        {

            //Obtener un unico cliente
            //Formas diferentes para la misma consulta
            ClienteTable client = Context.Cliente.Where(x => x.Activo).FirstOrDefault();
            ClienteTable client2 = Context.Cliente.FirstOrDefault(x=> x.Activo);

            var d = Context.Cliente.Where(x => x.Apellidos.Contains("uan"))
                .OrderByDescending(x => x.Edad).Take(15);




            IQueryable<ClienteTable> clients = Context.Cliente.Where(x => x.Activo);

            clients = clients.Where(x => x.Edad > 20);

            clients = clients.Where(x => x.Nombres=="juan");



            var sql = Context.ClienteRol.FromSql("select name, rol from cliente left join rol on .....");





            return clients.ToList();
        }

        public IList<ClienteEntity> Get()
        { 
            //Conversión directa en el query con expresiones lambda
            IList<ClienteEntity> clientes = Context.Cliente.Where(x => x.Activo)
                .Select(cliente=> new ClienteEntity
                {
                    Id = cliente.Id,
                    Activo = cliente.Activo,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Edad = cliente.Edad,
                    FechaNacimiento = cliente.FechaNacimiento 
                } 
                ).ToList();

            //Conversion mediante ForEach con mayor costo de performance

            //IList<ClienteEntity> response = new List<ClienteEntity>();
            //foreach (var cliente in clientes)
            //{
            //    response.Add(new ClienteEntity
            //    {
            //        Id = cliente.Id,
            //        Activo = cliente.Activo,
            //        Nombres = cliente.Nombres,
            //        Apellidos = cliente.Apellidos,
            //        Edad = cliente.Edad,
            //        FechaNacimiento = cliente.FechaNacimiento
            //    }
            //    );
            //} 
            return clientes;
        }

        public ClienteEntity Get(int Id)
        {
            ClienteTable cliente = Context.Cliente.FirstOrDefault(x=> x.Id==Id);
            return new ClienteEntity { 
                Id= cliente.Id,
                Activo = cliente.Activo,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Edad = cliente.Edad,
                FechaNacimiento = cliente.FechaNacimiento
            };
        }

        public ClienteEntity Create(ClienteEntity entity)
        {


            EntityEntry<ClienteTable> cliente = Context.Cliente.Add(new ClienteTable
            {
                Activo = entity.Activo,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Edad = entity.Edad,
                FechaNacimiento = entity.FechaNacimiento
            });


            //Expresion para validar objeto y determinar el valor cuando es true y cuando es false
            //var val = cliente != null ? true : false;
            //Expresion para determinar un valor por defecto en caso de que el objeto sea null
            //var val1 = cliente.Entity.Apellidos??"Uribe";
            //Expresion para validar el valo null del objeto y no continuar con la expresion siguiente
            //var val2 = cliente?.Entity?.Apellidos?.Substring(0, 2); 
            return new ClienteEntity
            {
                Id = cliente.Entity.Id,
                Activo = cliente.Entity.Activo,
                Nombres = cliente.Entity.Nombres,
                Apellidos = cliente.Entity.Apellidos,
                Edad = cliente.Entity.Edad,
                FechaNacimiento = cliente.Entity.FechaNacimiento
            }; 
        }

        public void Update(int Id, ClienteEntity entity)
        {

            ClienteTable cliente = Context.Cliente.FirstOrDefault(x => x.Id == Id); 
            cliente.Activo = entity.Activo;
            cliente.Nombres = entity.Nombres;
            cliente.Apellidos = entity.Apellidos;
            cliente.Edad = entity.Edad;
            cliente.FechaNacimiento = entity.FechaNacimiento; 

            Context.Cliente.Update(cliente);
        }

        public void Delete(int Id)
        {
            ClienteTable cliente = Context.Cliente.FirstOrDefault(x => x.Id == Id);
            Context.Cliente.Remove(cliente);
        }
    }
}
