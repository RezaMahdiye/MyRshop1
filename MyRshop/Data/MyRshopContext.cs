using Microsoft.EntityFrameworkCore;
using MyRshop.Models;

namespace MyRshop.Data
{
    public class MyRshopContext : DbContext
    {
        public MyRshopContext(DbContextOptions<MyRshopContext> options) : base(options)
        {


        }
          public DbSet<Users> Users { set; get; }
        public DbSet<CategoryOfFile> CategoryOfFiles { set; get; }
        public DbSet<FileModel> FileModel { set; get; }
        public DbSet<Comment>Comment { set; get; }
        public DbSet<ClassProgram> ClassProgram { set; get; }
        public DbSet<HirringModel> Hirring { set; get; }
        public DbSet<AffairModel> Affair { set; get; }
        public DbSet<Request> Requests { set; get; }
        public DbSet<Service> Service { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<CategoryToProduct> CategoryToProducts { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Item> Items { set; get; }
      

        public DbSet<Order> Order { set; get; }
        public DbSet<OrderDetail> OrderDetail { set; get; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<OrderDetail>()
          .HasOne(s => s.ClassProgram)
          .WithMany(g => g.OrderDetails)
          .OnDelete(DeleteBehavior.NoAction)
          .HasForeignKey(s => s.ClassProgramId);

            // modelBuilder.Entity<Product>(
            //     p =>
            //     {
            //         p.HasKey(w => w.Id);
            //         p.OwnsOne<Item>(w => w.Item);
            //         p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //         .HasForeignKey<Item>(w => w.Id);
            //     }
            //);
            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });
            #region seed data Category 
            //modelBuilder.Entity<Category>().HasData(new Category()
            //{
            //    Id = 1,
            //    Name = "Asp.netcore 3",
            //    Description = "Asp.netcore 3"
            //},
            //new Category()
            //{
            //    Id = 2,
            //    Name = "لباس ورزشی",
            //    Description = "لباس ورزشی"
            //},
            //new Category()
            //{
            //    Id = 3,
            //    Name = "ساعت مچی",
            //    Description = "ساعت مچی"
            //},
            //new Category()
            //{
            //    Id = 4,
            //    Name = "کیف",
            //    Description = "کیف"
            //}
            //    );

            //modelBuilder.Entity<Item>().HasData(
            //    new Item()
            //    {
            //        Id = 1,
            //        Price = 856,
            //        QuantityInStock = 5
            //    },
            //         new Item()
            //         {
            //             Id = 2,
            //             Price = 45646,
            //             QuantityInStock = 3
            //         },
            //         new Item()
            //         {
            //             Id = 3,
            //             Price = 2500,
            //             QuantityInStock = 8
            //         }
            //);

            //modelBuilder.Entity<Product>().HasData(
            //     new Product()
            //     {
            //         Id = 1,
            //         ItemId = 1,
            //         Name = "اموزش Asp",
            //         Description = "اموزش Asp"
            //     },
            //                      new Product()
            //                      {
            //                          Id = 2,
            //                          ItemId = 2,
            //                          Name = "اموزش php",
            //                          Description = "اموزش php"
            //                      },
            //                                       new Product()
            //                                       {
            //                                           Id = 3,
            //                                           ItemId = 3,
            //                                           Name = "اموزش word",
            //                                           Description = "اموزش word"
            //                                       }
            //    );

            //modelBuilder.Entity<CategoryToProduct>().HasData(
            //    new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
            //    new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
            //    new CategoryToProduct() { CategoryId = 3, ProductId = 1 },

            //    new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
            //    new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
            //    new CategoryToProduct() { CategoryId = 3, ProductId = 2 },

            //   new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
            //    new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
            //    new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
            //    );

            modelBuilder.Entity<Users>().HasData(new Users()
            {
                Email = "rezamediye@gmail.com",
                IsAdmin = true,
                Password = "Reza123456!",
                RegisterDate = System.DateTime.Now,
                UserId = 1,

            });

            #endregion

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
