using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasData(
                new Company { 
                    Id = 1,
                    Name = "Metasoft",
                    City = "Riyadh",
                    State = "East",
                    PhoneNumber = "+9662488551239",
                    StreetAddress = "Aish-bnt-ababkr",
                    PostalCode = "20056"
                },
                new Company { 
                    Id = 2,
                    Name = "Elm",
                    City = "Riyadh",
                    State = "North",
                    PhoneNumber = "+9662488221239",
                    StreetAddress = "Aba-hanifa",
                    PostalCode = "46560"
                },
                new Company
                {
                    Id = 3,
                    Name = "Riyadh Bank",
                    City = "Riyadh",
                    State = "East",
                    PhoneNumber = "+9662411551239",
                    StreetAddress = "King-Fahd",
                    PostalCode = "20389"
                }
            );

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
               new Category { Id = 2, Name = "SiFi", DisplayOrder = 2 },
               new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Description = "The Catcher in the Rye by J.D. Salinger\r\nA coming-of-age novel about Holden Caulfield, a disillusioned teenager who narrates his experiences after being expelled from school. Through his journey in New York City, the story explores themes of alienation, loss of innocence, and the challenges of growing up in a superficial world.\r\n\r\n",
                    ISBN = "SWD7799001",
                    ListPrice = 50,
                    Price = 45,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2
                },

                new Product
                {
                    Id = 2,
                    Title = "Harry Potter",
                    Author = "J.K. Rowling",
                    Description = "Harry Potter and the Cursed Child by J.K. Rowling, John Tiffany, and Jack Thorne\r\nA stage play and sequel to the original Harry Potter series, this story focuses on Harry's son, Albus Potter, as he struggles with the weight of his family’s legacy. Through time-travel adventures, the play explores themes of family, friendship, and the consequences of altering the past.",
                    ISBN = "SWD2299001",
                    ListPrice = 60,
                    Price = 55,
                    Price50 = 50,
                    Price100 = 45,
                    CategoryId = 3
                },

                new Product
                {
                    Id = 3,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },

                new Product
                {
                    Id = 4,
                    Title = "The Little Prince",
                    Author = "Antoine de",
                    Description = "The Little Prince by Antoine de Saint-Exupéry\r\nThis philosophical tale follows a pilot stranded in the desert who meets a young prince from another planet. Through their conversations, the story delves into themes of love, friendship, loneliness, and the importance of looking beyond appearances to understand the world and human relationships.\r\n\r\n\r\n",
                    ISBN = "SWD9339001",
                    ListPrice = 35,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2
                },

                new Product
                {
                    Id = 5,
                    Title = "Brave New World",
                    Author = "Aldous Huxley",
                    Description = "Brave New World by Aldous Huxley\r\nA dystopian novel set in a future society driven by technological and scientific advancements, where humans are genetically engineered, emotions are suppressed, and individuality is discouraged. The story explores themes of conformity, freedom, and the cost of a utopian world controlled by artificial happiness.\r\n\r\n",
                    ISBN = "SWD9449001",
                    ListPrice = 45,
                    Price = 40,
                    Price50 = 35,
                    Price100 = 30,
                    CategoryId = 1
                },


                new Product
                {
                    Id = 6,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 7,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 8,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 9,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 10,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 11,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 2
                },

                new Product
                {
                    Id = 12,
                    Title = "The Color Purple",
                    Author = "Alice Walker",
                    Description = "The Color Purple by Alice Walker\r\nThis Pulitzer Prize-winning novel is a powerful story of struggle, resilience, and self-discovery. Set in the early 20th-century American South, it follows Celie, an African-American woman who endures years of abuse and oppression. Through letters to God and later to her sister, Nettie, Celie finds her voice, forms deep bonds with other women, and discovers her own strength and independence. The book explores themes of race, gender, love, and the transformative power of friendship and faith.",
                    ISBN = "AOT002300001",
                    ListPrice = 34,
                    Price = 29,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 3
                }

            //new Product
            //{
            //    Id = 12,
            //    Title = "I Know Why the Caged Bird Sings",
            //    Author = "by Maya Angelou",
            //    Description = "I Know Why the Caged Bird Sings by Maya Angelou\r\nThis autobiographical memoir recounts Maya Angelou's early life, detailing her struggles with racism, identity, and trauma as a Black girl growing up in the segregated South. Through powerful prose, Angelou explores themes of resilience, self-discovery, and the triumph of the human spirit in the face of adversity.\r\n",
            //    ISBN = "FOA078000001",
            //    ListPrice = 34,
            //    Price = 29,
            //    Price50 = 25,
            //    Price100 = 20,
            //    CategoryId = 3
            //},

            //new Product
            //{
            //    Id = 13,
            //    Title = "A Teaspoon of Earth and Sea",
            //    Author = "Dina Nayeri",
            //    Description = "A Teaspoon of Earth and Sea by Dina Nayeri\r\nSet in post-revolutionary Iran, this novel tells the story of Saba, a young girl who dreams of life in America after her twin sister disappears. The narrative blends reality and imagination as Saba weaves stories of a life she imagines her sister is living abroad, reflecting themes of cultural identity, loss, and the tension between tradition and modernity.\r\n",
            //    ListPrice = 19,
            //    Price = 17,
            //    Price50 = 15,
            //    Price100 = 13,
            //    CategoryId = 2
            //}

            );
        }
    }
}
