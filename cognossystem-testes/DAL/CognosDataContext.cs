using cognossystem_testes.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace cognossystem_testes.DAL
{
    public class CognosDataContext : DbContext
    {
        public CognosDataContext() : base("CognosTeste") {}
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}