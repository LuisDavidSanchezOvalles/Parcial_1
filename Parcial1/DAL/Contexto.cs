using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;

namespace Parcial1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulo> Articulo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LUISDAVIDSO\SQLEXPRESS; Database = ParcialDb1; Trusted_Connection = True ");
        }
    }
}
