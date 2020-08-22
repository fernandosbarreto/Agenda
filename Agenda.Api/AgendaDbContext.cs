using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda
{
    public class AgendaDbContext : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Encomenda> Encomendas { get; set; }
        DbSet<Doce> Doces { get; set; }
        DbSet<TpDoce> TpDoces { get; set; }


        public AgendaDbContext(DbContextOptions options) : base(options)
        {

        }

        public AgendaDbContext()
        {
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Nome).HasMaxLength(100);
                entity.Property(o => o.Sobrenome).HasMaxLength(200);
                entity.Property(o => o.Telefone).HasMaxLength(11);
                entity.Property(o => o.Celular).HasMaxLength(11);
                entity.Property(o => o.Email).HasMaxLength(200);
                entity.Property(o => o.Endereco).HasMaxLength(200);
            });

            modelBuilder.Entity<Encomenda>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Quantidade).HasMaxLength(4);
                entity.Property(o => o.Preco).HasMaxLength(10);
            });

            modelBuilder.Entity<Doce>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Sabor).HasMaxLength(100);
                entity.Property(o => o.Preco).HasMaxLength(10);
            });
            
            modelBuilder.Entity<TpDoce>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.NomeProduto).HasMaxLength(100);
            });
        }
    }
}