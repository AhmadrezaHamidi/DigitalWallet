using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DigitalWallet.Infrastructure
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DB>
    {
        public DB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DB>();

            // پیکربندی ارتباط با دیتابیس
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new DB(optionsBuilder.Options);
        }
    }
}

internal partial class RejectionReasonConfig
{
    internal class ReasonConfig : IEntityTypeConfiguration<Reason>
    {
        public void Configure(EntityTypeBuilder<Reason> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.LastUpdated)
                .IsRequired(false);
        }
    }
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnection = configuration["ConnectionStrings:SqlConnectionString"];
        services.AddScoped<ICHMSDbContext, CHMSDbContext>();

        services.AddEntityFrameworkSqlServer().AddDbContext<CHMSDbContext>(opt =>

        opt.UseSqlServer(sqlConnection));
        return services;
    }
}