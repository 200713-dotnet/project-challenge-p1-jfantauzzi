using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Storing
{
  public partial class PizzaStoreDbContext : DbContext
  {
    public PizzaStoreDbContext()
    {
    }
    public PizzaStoreDbContext(DbContextOptions Options) : base(Options) { }

    //Create Tables
    public DbSet<CrustModel> Crusts { get; set; }
    public DbSet<Pizza> Pizzas { get; set; } //create table

    public DbSet<Size> Sizes { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<PizzaTopping> PizzaTopping { get; set; }
    /*  public DbSet<User> Users { get; set; }
     public DbSet<Store> Stores { get; set; }
     public DbSet<Order> Orders { get; set; } */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("server=localhost;database=PizzaBoxDb;user id=sa;password=Password12345");
      }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      /* builder.Entity<PizzaModel>().HasKey(e => e.Id); //primary constraint
       builder.Entity<PizzaModel>().Property(e => e.Option).HasColumnType("string");
       //builder.Entity<PizzaModel>().Property(e => e.Crust).HasColumnType("Crust");
       //builder.Entity<PizzaModel>().Property(e => e.Size).HasColumnType("Size");
       // builder.Entity<PizzaModel>().Property(e => e.Toppings).HasColumnType("List<Topping>"); //need the junction pizzatopping table
       builder.Entity<PizzaModel>().Property(e => e.Price).HasColumnType("double");


       builder.Entity<CrustModel>().HasKey(e => e.Id);
       builder.Entity<CrustModel>().Property(e => e.Option).HasColumnType("string");

       builder.Entity<SizeModel>().HasKey(e => e.Id);
       builder.Entity<SizeModel>().Property(e => e.Option).HasColumnType("string");

       builder.Entity<ToppingModel>().HasKey(e => e.Id);
       builder.Entity<ToppingModel>().Property(e => e.Option).HasColumnType("string");

       builder.Entity<UserModel>().HasKey(e => e.Id);
       builder.Entity<UserModel>().Property(e => e.Option).HasColumnType("string");

       builder.Entity<StoreModel>().HasKey(e => e.Id);
       builder.Entity<StoreModel>().Property(e => e.Option).HasColumnType("string");
       // builder.Entity<StoreModel>().Property(e => e.Orders).HasColumnType("List<OrderModel>"); //need to reference an order record? or have an storeorder table

       builder.Entity<OrderModel>().HasKey(e => e.Id);
       builder.Entity<OrderModel>().Property(e => e.Total).HasColumnType("double"); //decimal(18, 2)
       builder.Entity<OrderModel>().Property(e => e.DateOrdered).HasColumnType("DateTime");   */

      builder.Entity<Crust>(entity =>
               {
                 entity.ToTable("Crust", "Pizza");

                 entity.Property(e => e.Option)
                       .IsRequired()
                       .HasMaxLength(100);
               });

      builder.Entity<Pizza>(entity =>
               {
                 entity.ToTable("Pizza", "Pizza");

                 entity.Property(e => e.Option)
                  .IsRequired()
                  .HasMaxLength(200);

                 entity.HasOne(d => d.Crust)
                  .WithMany(p => p.Pizza)
                  .HasForeignKey(d => d.CrustId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_CrustId");

                 entity.HasOne(d => d.Size)
                  .WithMany(p => p.Pizza)
                  .HasForeignKey(d => d.SizeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_SizeId");
               });

      builder.Entity<Size>(entity =>
              {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.Option)
                    .IsRequired()
                    .HasMaxLength(200);
              });

      builder.Entity<Topping>(entity =>
               {
                 entity.ToTable("Topping", "Pizza");

                 entity.Property(e => e.Option)
               .IsRequired()
               .HasMaxLength(200);
               });

      builder.Entity<PizzaTopping>(entity =>
               {
                 entity.HasNoKey();

                 entity.ToTable("PizzaTopping", "Pizza");

                 entity.Property(e => e.PizzaToppingId).ValueGeneratedOnAdd();

                 entity.HasOne(d => d.Pizza)
               .WithMany()
               .HasForeignKey(d => d.PizzaId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PizzaId");

                 entity.HasOne(d => d.Topping)
               .WithMany()
               .HasForeignKey(d => d.ToppingId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_ToppingId");
               });

      OnModelCreatingPartial(builder);

    }
    partial void OnModelCreatingPartial(ModelBuilder builder);
  }
}