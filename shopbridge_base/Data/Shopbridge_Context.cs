using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System.Linq;
using System.Reflection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Models.ExternalConnectors;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        protected readonly IConfiguration _configuration;
        public Shopbridge_Context (DbContextOptions<Shopbridge_Context> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();
        }
        
    }

    
}
