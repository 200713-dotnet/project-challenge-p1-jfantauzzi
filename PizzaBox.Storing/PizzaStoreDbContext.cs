using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaStoreDbContext : DbContext{
    
    //Create Tables
    public DbSet<PizzaModel> Pizzas { get; set; } //create table
    public DbSet<UserModel> Users{ get; set; }
    public DbSet<StoreModel> Stores{ get; set; }
    public DbSet<OrderModel> Orders{ get; set; }

    public PizzaStoreDbContext(DbContextOptions Options) : base(Options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PizzaModel>().HasKey(e => e.Id); //primary constraint
      builder.Entity<PizzaModel>().Property(e => e.Option).HasColumnType("string");
      builder.Entity<PizzaModel>().Property(e => e.Crust).HasColumnType("Crust");
      builder.Entity<PizzaModel>().Property(e => e.Size).HasColumnType("Size");
      /**/ builder.Entity<PizzaModel>().Property(e => e.Toppings).HasColumnType("List<Topping>");
      builder.Entity<PizzaModel>().Property(e => e.Price).HasColumnType("decimal(18,2)");

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
      /**/ builder.Entity<StoreModel>().Property(e => e.Orders).HasColumnType("List<OrderModel>"); //need to reference an order record?

      builder.Entity<OrderModel>().HasKey(e => e.Id);
      builder.Entity<OrderModel>().Property(e => e.Total).HasColumnType("decimal(18, 2)");
      builder.Entity<OrderModel>().Property(e => e.DateOrdered).HasColumnType("DateTime");
    }
    
  }
}