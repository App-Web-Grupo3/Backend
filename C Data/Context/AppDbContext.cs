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
    public DbSet<Answer> Responses { get; set; }
    public DbSet<Activities> Activities { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Cuentademysql16+;Database=uniquetrip;", serverVersion);

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Representante>().ToTable("Representatives");
        builder.Entity<Representante>().HasKey(p => p.Id);
        builder.Entity<Representante>().Property(p => p.Nombre).IsRequired().HasMaxLength(20);
        builder.Entity<Representante>().Property(p => p.Apellido).IsRequired().HasMaxLength(20);
        builder.Entity<Representante>().Property(p => p.Correo).IsRequired().HasMaxLength(20);
        builder.Entity<Representante>().Property(p=>p.Contrasenia).IsRequired().HasMaxLength(20);
        builder.Entity<Representante>().Property(p => p.Telefono).IsRequired().HasMaxLength(9);
        builder.Entity<Representante>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Representante>().Property(p => p.IsActive).HasDefaultValue(true);

        builder.Entity<Answer>().ToTable("Responses");
        builder.Entity<Answer>().HasKey(p => p.Id);
        builder.Entity<Answer>().Property(p => p.response).IsRequired().HasMaxLength(50);
        builder.Entity<Answer>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Answer>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Tourist>().ToTable("Tourists");
        builder.Entity<Tourist>().HasKey(p => p.Id);
        builder.Entity<Tourist>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p => p.LastName).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p => p.Mail).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p=>p.Password).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Tourist>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Tourist>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Activities>().ToTable("Activities");
        builder.Entity<Activities>().HasKey(p => p.Id);
        builder.Entity<Activities>().Property(p => p.Title).IsRequired().HasMaxLength(20);
        builder.Entity<Activities>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Entity<Activities>().Property(p => p.Discount).HasDefaultValue(false);
        builder.Entity<Activities>().Property(p => p.Percentage).HasDefaultValue(0);
        builder.Entity<Activities>().Property(p => p.Restriction).HasDefaultValue(false);
        builder.Entity<Activities>().Property(p => p.people).HasDefaultValue(0);
        builder.Entity<Activities>().Property(p => p.Price).HasDefaultValue(0);
        builder.Entity<Activities>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Activities>().Property(p => p.IsActive).HasDefaultValue(true);

        builder.Entity<Images>().ToTable("Images");
        builder.Entity<Images>().HasKey(p => p.Id);
        builder.Entity<Images>().Property(p => p.Url).IsRequired().HasMaxLength(50);
        builder.Entity<Images>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Images>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Favorites>().ToTable("Favorites");
        builder.Entity<Favorites>().HasKey(p => p.Id);
        builder.Entity<Favorites>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Favorites>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Company>().ToTable("Companies");
        builder.Entity<Company>().HasKey(p => p.Id);
        builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Company>().Property(p => p.Mail).IsRequired().HasMaxLength(20);
        builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Entity<Company>().Property(p => p.Ruc).IsRequired().HasMaxLength(9);
        builder.Entity<Company>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Company>().Property(p => p.Address).IsRequired().HasMaxLength(50);
        builder.Entity<Company>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Company>().Property(p => p.IsActive).HasDefaultValue(true);
    }
}