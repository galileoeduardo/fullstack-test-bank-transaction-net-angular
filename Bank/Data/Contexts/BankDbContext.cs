using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections.Generic;

namespace Bank.Data.Contexts
{
    public class BankDbContext : DbContext
    {
        public DbSet<TransactionEntity> TransactionEntities { get; set; }

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
            raw.SetProvider(new SQLite3Provider_e_sqlite3());
            Batteries.Init();
        }
    }
}
