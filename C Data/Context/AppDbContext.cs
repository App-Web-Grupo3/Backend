using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Representante> Representantes { get; set; }
    public DbSet<Tourist> Tourists { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=12345;Database=uniquetrip;", serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Representante>().ToTable("Representatives");
        builder.Entity<Representante>().HasKey(p => p.Id);
        builder.Entity<Representante>().Property(p => p.Nombre).IsRequired();
        builder.Entity<Representante>().Property(p => p.Apellido).IsRequired();
        builder.Entity<Representante>().Property(p => p.Correo).IsRequired();
        builder.Entity<Representante>().Property(p=>p.Contrasenia).IsRequired().HasMaxLength(10);
        builder.Entity<Representante>().Property(p => p.Telefono).IsRequired();
        builder.Entity<Representante>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Representante>().Property(p => p.IsActive).HasDefaultValue(true);

        
        builder.Entity<Tourist>().ToTable("Tourists");
        builder.Entity<Tourist>().HasKey(p => p.Id);
        builder.Entity<Tourist>().Property(p => p.Name).IsRequired();
        builder.Entity<Tourist>().Property(p => p.LastName).IsRequired();
        builder.Entity<Tourist>().Property(p => p.Mail).IsRequired();
        builder.Entity<Tourist>().Property(p=>p.Password).IsRequired().HasMaxLength(10);
        builder.Entity<Tourist>().Property(p => p.Phone).IsRequired();
        builder.Entity<Tourist>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Tourist>().Property(p => p.IsActive).HasDefaultValue(true);
    }

}