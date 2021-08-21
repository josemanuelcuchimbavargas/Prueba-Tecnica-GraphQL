using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

        #region Seed Data  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    id = 1,
                    user = "Jay krishna Reddy",
                    status = "Activo"
                },
                new Ticket
                {
                    id = 2,
                    user = "Sey Karl Chan",
                    status = "Inactivo"
                }
                );
        }
        #endregion
    }
}
