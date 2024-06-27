using placaappapi.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using placaappapi.Models;
using Microsoft.Extensions.Configuration;

namespace placaappapi.Models
{
   
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetSection("ConnectionStrings:connection").Value);
        }

        public DbSet<Placa> placas { get; set; }
        public DbSet<EscalarValue> escalarValues { get; set; }
        public DbSet<CitaHora> citaHoras { get; set; }


    }
}
