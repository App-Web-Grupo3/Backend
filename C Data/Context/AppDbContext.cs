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
    public DbSet<PaymentMethod> PaymentMethod { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
        optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=c0mpl1ces;Database=uniquetrip;", serverVersion);

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
        builder.Entity<Activities>().Property(p => p.People).HasDefaultValue(0);
        builder.Entity<Activities>().Property(p => p.Price).HasDefaultValue(0);
        builder.Entity<Activities>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Activities>().Property(p => p.IsActive).HasDefaultValue(true);
        builder.Entity<Activities>()
            .HasMany(a => a.Images)
            .WithOne(i => i.Activities)
            .HasForeignKey(i => i.ActivitiesId);
        builder.Entity<Activities>()
            .HasMany(a => a.Comments)
            .WithOne(i => i.Activities)
            .HasForeignKey(i => i.ActivitiesId);

        builder.Entity<Images>().ToTable("Images");
        builder.Entity<Images>().HasKey(p => p.Id);
        builder.Entity<Images>().Property(p => p.Url).IsRequired().HasMaxLength(50);
        builder.Entity<Images>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Images>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Favorites>().ToTable("Favorites");
        builder.Entity<Favorites>().HasKey(p => p.Id);
        builder.Entity<Favorites>().HasOne(p => p.Tourist)
            .WithOne(p => p.Favorites);
        builder.Entity<Favorites>().HasOne(p => p.Activities)
            .WithOne(p => p.Favorites);
        builder.Entity<Favorites>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Favorites>().Property(p => p.IsActive).HasDefaultValue(true);


        builder.Entity<PaymentMethod>().ToTable("PaymentMethod");
        builder.Entity<PaymentMethod>().HasKey(p => p.Id);
        builder.Entity<PaymentMethod>().Property(p => p.CardNumber).IsRequired().HasMaxLength(16);
        builder.Entity<PaymentMethod>().Property(p => p.AccountHolderName).IsRequired().HasMaxLength(50);
        builder.Entity<PaymentMethod>().Property(p => p.Month).IsRequired().HasMaxLength(2);
        builder.Entity<PaymentMethod>().Property(p=>p.Year).IsRequired().HasMaxLength(4);
        builder.Entity<PaymentMethod>().Property(p => p.CVC).IsRequired().HasMaxLength(4);
        builder.Entity<PaymentMethod>().HasOne(p => p.Tourist)
            .WithMany(p => p.PaymentMethod);
        builder.Entity<PaymentMethod>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<PaymentMethod>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Company>().ToTable("Companies");
        builder.Entity<Company>().HasKey(p => p.Id);
        builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Company>().Property(p => p.Mail).IsRequired().HasMaxLength(20);
        builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Entity<Company>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);
        builder.Entity<Company>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Company>().Property(p => p.Address).IsRequired().HasMaxLength(50);
        
        builder.Entity<Company>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Company>().Property(p => p.IsActive).HasDefaultValue(true);
        //relacion
        builder.Entity<Company>()
            .HasOne(c => c.Representante)
            .WithOne(r => r.Company)
            .HasForeignKey<Company>(c => c.RepresentanteId);
        
        builder.Entity<Company>()
            .HasMany(c => c.Activities)
            .WithOne(a => a.Company)
            .HasForeignKey(a => a.CompanyId);
    
        builder.Entity<Company>()
            .HasMany(c => c.Comments)
            .WithOne(g => g.Company)
            .HasForeignKey(h => h.CompanyId);
        

        builder.Entity<Comment>().ToTable("Comments");
        builder.Entity<Comment>().HasKey(p => p.Id);
        builder.Entity<Comment>().Property(p => p.Content).IsRequired().HasMaxLength(500);
        builder.Entity<Comment>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Comment>().Property(p => p.IsActive).HasDefaultValue(true);
    }
    
    
}