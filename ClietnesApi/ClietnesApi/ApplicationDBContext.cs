using Microsoft.EntityFrameworkCore;
using ClientesAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Genero> Generos {  get; set; }
    }
}
