
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMessage> contactMessages { get; set; }
        public DbSet<ContactSocial> ContactSocials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<WhatClientSays> WhatClientSays { get; set; }
        public DbSet<OurMission> ourMissions { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamMemberSocial> TeamMemberSocials { get; set; }
        public DbSet<Fag> Fags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategorys { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<TagToBlog> TagToBlogs { get; set; }
        public DbSet<SavedBlog> SavedBlogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<BlogSocial> BlogSocials { get; set; }
    }
}
