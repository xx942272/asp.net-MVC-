using Microsoft.EntityFrameworkCore;
using s14112310482.Models;

namespace s14112310482.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ImgCarousel> ImgCarousels { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category 欄位資料
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Memo).HasMaxLength(100);
            });
            //測試資料
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "主世界", DisplayOrder = 1, Memo = "礦坑" },
            new Category { Id = 2, Name = "下界", DisplayOrder = 2, Memo = "地獄" },
            new Category { Id = 3, Name = "終界", DisplayOrder = 3, Memo = "末地" });
            modelBuilder.Entity<Product>().HasData
(
new Product
{
    Id = 1,
    Name = "伏守者",
    Difficulty = 7,
    ImgF = "e1.png",
    Description = "遠古遺跡BOSS，潛藏危機與寶藏。",
    CategoryId = 1
},
new Product
{
    Id = 2,
    Name = "地獄堡壘",
    Difficulty = 5,
    ImgF = "q1.png",
    Description = "烈焰燃燒，危機四伏的堡壘。",
    CategoryId = 2
}, 
new Product
{
    Id = 3,
    Name = "終界城",
    Difficulty = 9,
    ImgF = "w1.png",
    Description = "遺落空島，探索神秘終界城。",
    CategoryId = 3

}, new Product
{
    Id = 4,
    Name = "遠古城市",
    Difficulty = 9,
    ImgF = "e2.png",
    Description = "幽匿遺跡伏守危險寶庫",
    CategoryId = 1

},
new Product
{
    Id =5,
    Name = "試煉密室",
    Difficulty =7,
    ImgF = "e3.png",
    Description = "探秘考驗解謎奪寶生存",
    CategoryId = 1

}
,
new Product
{
    Id = 6,
    Name = "紫晶洞",
    Difficulty = 7,
    ImgF = "e4.png",
    Description = "晶石洞穴探險挖礦尋寶",
    CategoryId = 1

}
,
new Product
{
    Id = 7,
    Name = "試煉密室生怪塔",
    Difficulty = 9,
    ImgF = "e5.png",
    Description = "高塔刷怪狩獵挑戰生存",
    CategoryId = 1

}
,
new Product
{
    Id = 8,
    Name = "廢棄傳送門",
    Difficulty = 9,
    ImgF = "q2.png",
    Description = "廢棄傳送門幽暗生存戰",
    CategoryId =2

}
,
new Product
{
    Id = 9,
    Name = "堡壘遺跡",
    Difficulty = 6,
    ImgF = "q3.png",
    Description = "豬靈要塞危險尋寶挑戰",
    CategoryId = 2

}
,
new Product
{
    Id = 10,
    Name = "終界傳送門",
    Difficulty = 6,
    ImgF = "w2.png",
    Description = "終界入口激活冒險終章",
    CategoryId = 3

}
,
new Product
{
    Id = 11,
    Name = "終界",
    Difficulty = 8,
    ImgF = "w3.png",
    Description = "虛空島嶼龍巢巔峰決戰",
    CategoryId = 3

}
,
new Product
{
    Id = 12,
    Name = "終界龍",
    Difficulty = 10,
    ImgF = "w4.png",
    Description = "終界霸主黑翼終極龍戰",
    CategoryId = 3

}

);


//ImgCarousel欄位資料
modelBuilder.Entity<ImgCarousel>(entity =>
{
    entity.Property(e => e.Id).HasMaxLength(100);
    entity.Property(e => e.ImgF).HasMaxLength(100);
});
            //測試資料
            modelBuilder.Entity
            <ImgCarousel>().HasData
            (
            new ImgCarousel { Id = 1, ImgF = "a1.png" },
            new ImgCarousel { Id = 2, ImgF = "a2.png" },
            new ImgCarousel { Id = 3, ImgF = "a3.png" },
            new ImgCarousel { Id = 4, ImgF = "a4.png" },
            new ImgCarousel { Id = 5, ImgF = "a5.png" },
            new ImgCarousel { Id = 6, ImgF = "a6.png" },
            new ImgCarousel { Id = 7, ImgF = "a7.png" }
            );
        }
    }
}