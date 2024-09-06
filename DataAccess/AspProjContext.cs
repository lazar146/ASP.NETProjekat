using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AspProjContext : DbContext
    {
        

        private readonly string _connectionString;
        public AspProjContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public AspProjContext()
        {
            _connectionString = "Data Source=ZOZA\\SQLEXPRESS;Initial Catalog=AspProjekat;Integrated Security=True;Trust Server Certificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ZOZA\\SQLEXPRESS;Initial Catalog=AspProjekat;Integrated Security=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ModelColor> ModelColors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
