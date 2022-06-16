using System;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndPortafolioTarjeta
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}
