using Microsoft.EntityFrameworkCore;
using PuntosExtra.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuntosExtra.DAL 
{
       public class Contexto : DbContext
         {
            public DbSet<Personas> Persona { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
                optionBuilder.UseSqlite(@"Data Source = Persona.db");
            }
       }
}
