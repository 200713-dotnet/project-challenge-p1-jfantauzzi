using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  public class Program
  {
    public static void Main(string[] args)
    {


      /* IHost host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        IServiceProvider services = scope.ServiceProvider;
        using (var context = new PizzaStoreDbContext(services.GetRequiredService<DbContextOptions<PizzaStoreDbContext>>()))
        {
          context.Crusts.RemoveRange(
            new Crust { CrustId = 4 }, 
            new Crust { CrustId = 5 },
            new Crust { CrustId = 6 } 
    );
          context.SaveChanges();
        }
      } */

      /* IHost host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        IServiceProvider services = scope.ServiceProvider;
        using (var context = new PizzaStoreDbContext(services.GetRequiredService<DbContextOptions<PizzaStoreDbContext>>()))
        {
          context.Sizes.AddRange(
            new Size { Option = "small" },
            new Size { Option = "medium" },
            new Size { Option = "large" }
    );
          context.SaveChanges();
        }
      } */

      /* IHost host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        IServiceProvider services = scope.ServiceProvider;
        using (var context = new PizzaStoreDbContext(services.GetRequiredService<DbContextOptions<PizzaStoreDbContext>>()))
        {
          context.Toppings.AddRange(
            new Topping { Option = "cheese" },
            new Topping { Option = "pepperoni" },
            new Topping { Option = "peppers" },
            new Topping { Option = "ham" },
            new Topping { Option = "onions" },
            new Topping { Option = "sausage" }
    );
          context.SaveChanges();
        }
      } */

      /* IHost host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        IServiceProvider services = scope.ServiceProvider;
        using (var context = new PizzaStoreDbContext(services.GetRequiredService<DbContextOptions<PizzaStoreDbContext>>()))
        {
          context.Pizzas.AddRange(
            new Pizza { CrustId = 1, SizeId =  2, Option = "Normal Cheese"},
            new Pizza { CrustId = 3, SizeId =  1, Option = "The Deep Little"},
            new Pizza { CrustId = 2, SizeId =  3, Option = "The Pizza Timer"}
    );
          context.SaveChanges();
        }
      } */

/* IHost host = CreateHostBuilder(args).Build();
      using (var scope = host.Services.CreateScope())
      {
        IServiceProvider services = scope.ServiceProvider;
        using (var context = new PizzaStoreDbContext(services.GetRequiredService<DbContextOptions<PizzaStoreDbContext>>()))
        {
          context.PizzaTopping.AddRange(
            new PizzaTopping{ PizzaToppingId = 1, PizzaId = 1, ToppingId =  1},
            new PizzaTopping{ PizzaToppingId = 2, PizzaId = 1, ToppingId =  2},

            new PizzaTopping{ PizzaToppingId = 3, PizzaId = 2, ToppingId =  1},
            new PizzaTopping{ PizzaToppingId = 4, PizzaId = 2, ToppingId =  3},
            new PizzaTopping{ PizzaToppingId = 5, PizzaId = 2, ToppingId =  4},

            new PizzaTopping{ PizzaToppingId = 6, PizzaId = 3, ToppingId =  1},
            new PizzaTopping{ PizzaToppingId = 7, PizzaId = 3, ToppingId =  3},
            new PizzaTopping{ PizzaToppingId = 8, PizzaId = 3, ToppingId =  5},
            new PizzaTopping{ PizzaToppingId = 9, PizzaId = 3, ToppingId =  6}
    );
          context.SaveChanges();
        }
      } */



      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
