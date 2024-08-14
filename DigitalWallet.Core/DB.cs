using DigitalWallet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWallet.Infrastructure
{
    //adding new IDBConetcxt In Appication Layering 
    //TODO
    //public interface ICHMSDbContext
    //{
    //    DbSet<RejectionReason> Wallets { get; set; }
    //    DbSet<Reason> Transactions { get; set; }
    //    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //}
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        ///Adding 
        ///

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(RejectionReasonConfig).Assembly);
        //}
        //public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return await base.SaveChangesAsync(cancellationToken);
        //}


    }
}
