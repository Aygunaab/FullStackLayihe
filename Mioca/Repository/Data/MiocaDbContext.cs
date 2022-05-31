using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
   public class MiocaDbContext:IdentityDbContext<User>
    {

        public MiocaDbContext(DbContextOptions<MiocaDbContext> options) : base(options){

        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Discount>Discounts  { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductPhoto>ProductPhotos { get; set; }
        public DbSet<ProductReview>ProductReviews { get; set; }
        public DbSet<ProductSocial>ProductSocials { get; set; }
        public DbSet<ProductSpecsification> ProductSpecsifications { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SliderItem> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Basket> Baskets { get; set; }



    }
}
