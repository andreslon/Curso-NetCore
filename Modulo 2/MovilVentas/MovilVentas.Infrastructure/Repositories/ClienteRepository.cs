using System;
using System.Collections.Generic;
using MovilVentas.Infrastructure.Tables;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovilVentas.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        public MovilVentasContext Context { get; set; }
        public ClienteRepository(MovilVentasContext context)
        {
            Context = context;
        } 
        public List<ClienteTable> Get()
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


    }
}
