using System;
using Microsoft.EntityFrameworkCore;
using MovilVentas.Infrastructure.Tables;

namespace MovilVentas.Infrastructure
{
    public class MovilVentasContext:DbContext
    { 
        //Mapeo de tabla
        public DbSet<ClienteTable> Cliente { get; set; }

        //Mapeo de Query
        public DbQuery<ClienteRol> ClienteRol { get; set; }

        public MovilVentasContext(DbContextOptions<MovilVentasContext> options): 
            base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
