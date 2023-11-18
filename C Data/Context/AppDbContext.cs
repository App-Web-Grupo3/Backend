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
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<Tourist> Tourists { get; set; }
    public DbSet<Answer> Responses { get; set; }
    public DbSet<Activities> Activities { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=12345;Database=uniquetrip;", serverVersion);

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Representative>().ToTable("Representatives");
        builder.Entity<Representative>().HasKey(p => p.Id);
        builder.Entity<Representative>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Representative>().Property(p => p.LastName).IsRequired().HasMaxLength(20);
        builder.Entity<Representative>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
        builder.Entity<Representative>().Property(p=>p.Password).IsRequired().HasMaxLength(20);
        builder.Entity<Representative>().Property(p=>p.SelectedRole).IsRequired().HasMaxLength(20);
        builder.Entity<Representative>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Representative>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Representative>().Property(p => p.IsActive).HasDefaultValue(true);

        builder.Entity<Answer>().ToTable("Responses");
        builder.Entity<Answer>().HasKey(p => p.Id);
        builder.Entity<Answer>().Property(p => p.response).IsRequired().HasMaxLength(50);
        builder.Entity<Answer>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Answer>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Tourist>().ToTable("Tourists");
        builder.Entity<Tourist>().HasKey(p => p.Id);
        builder.Entity<Tourist>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p => p.LastName).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
        builder.Entity<Tourist>().Property(p=>p.Password).IsRequired().HasMaxLength(20);
        builder.Entity<Tourist>().Property(p=>p.SelectedRole).IsRequired().HasMaxLength(20);
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

        builder.Entity<Images>().ToTable("Images");
        builder.Entity<Images>().HasKey(p => p.Id);
        builder.Entity<Images>().Property(p => p.Url).IsRequired().HasMaxLength(50);
        builder.Entity<Images>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Images>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<Favorites>().ToTable("Favorites");
        builder.Entity<Favorites>().HasKey(p => p.Id);
        builder.Entity<Favorites>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Favorites>().Property(p => p.IsActive).HasDefaultValue(true);


        builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
        builder.Entity<PaymentMethod>().HasKey(p => p.Id);
        builder.Entity<PaymentMethod>().Property(p => p.CardNumber).IsRequired().HasMaxLength(16);
        builder.Entity<PaymentMethod>().Property(p => p.AccountHolderName).IsRequired().HasMaxLength(50);
        builder.Entity<PaymentMethod>().Property(p => p.Month).IsRequired().HasMaxLength(2);
        builder.Entity<PaymentMethod>().Property(p=>p.Year).IsRequired().HasMaxLength(4);
        builder.Entity<PaymentMethod>().Property(p => p.CVC).IsRequired().HasMaxLength(4);
        
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
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.SelectedRole).IsRequired(); 
        builder.Entity<User>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(p => p.IsActive).HasDefaultValue(true);

        builder.Entity<UserRole>().ToTable("UserRoles");
        builder.Entity<UserRole>().HasKey(ur => ur.Id);
        builder.Entity<UserRole>().Property(ur => ur.RoleType).IsRequired();
        builder.Entity<UserRole>().Property(ur => ur.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<UserRole>().Property(ur => ur.IsActive).HasDefaultValue(true);

    }
    
}