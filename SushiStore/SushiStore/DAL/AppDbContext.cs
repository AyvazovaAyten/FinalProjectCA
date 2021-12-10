using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.DAL
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public virtual DbSet<Bio> Bios { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers{ get; set; }
        public virtual DbSet<Intro> Intros { get; set; }
        public virtual DbSet<IntroSlider> IntroSliders { get; set; }
        public virtual DbSet<AppPart> AppParts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Nutrition> Nutritions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Rating> Ratings{ get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryAdress> DeliveryAdresses { get; set; }
        public virtual DbSet<JSCode> JSCodes { get; set; }
        public virtual DbSet<CSSCode> CSSCodes { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PageIntro> PageIntros { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<MetaTag> MetaTags { get; set; }

    }
}
