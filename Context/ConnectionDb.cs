using APIServicosResidencia.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APIServicosResidencia.Context
{
    public class ConnectionDb : DbContext
    {
        public ConnectionDb(DbContextOptions<ConnectionDb> options) : base(options)
        {
        }

        public DbSet<Localizacao> LocalizacaCliente { get; set; }

        public DbSet<NomeCliente> NomeClientes { get; set; }
        public DbSet<NomeServico> NomeServicos { get; set; }

    }
}
