using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EFCore
{
    public static class SeedData
    {
        public static void TestData(IApplicationBuilder app) {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context is not null)
            {
                if (context.Database.GetPendingMigrations().Any())//uygulanmayan migration olup olmadığını kontrol eder
                {
                    context.Database.Migrate(); //migrationları uygula
                }

                if (!context.Tags.Any()) //Tags tablosunda kayıt olup olmadığını kontrol eder
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Programlama",URL="web-programlama"},
                        new Tag { Text = "Backend",URL="backend"},
                        new Tag { Text = "Frontend",URL="frontend"},
                        new Tag { Text = "Fullstack",URL="fullstack"},
                        new Tag { Text = "PHP",URL="php"}
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any()) //Users tablosunda kayıt olup olmadığını kontrol eder
                {
                    context.Users.AddRange(
                        new User { Name = "aliogul", Image="p1.jpg"},
                        new User { Name = "busecevik", Image = "p2.jpg" }
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any()) //Posts tablosunda kayıt olup olmadığını kontrol eder
                {
                    context.Posts.AddRange(
                        new Post 
                        { Title = "ASP.Net Core 8.0",
                          Content="A-Z Detaylı ASP.NET Core 8.0 Dersleri",
                          URL="asp-net-core-dersleri",
                          IsActive=true,
                          Image="3.jpg",
                          PublishedOn=DateTime.Now.AddDays(-10),
                          Tags=context.Tags.Take(3).ToList(),
                          UserID = 1,
                        },
                        new Post
                        {
                            Title = "PHP",
                            Content = "A-Z Detaylı PHP Dersleri",
                            URL="php-dersleri",
                            IsActive = true,
                            Image = "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserID = 1,
                        }, new Post
                        {
                            Title = "NodeJS",
                            Content = "A-Z Detaylı NodeJS Dersleri",
                            URL="node-js-dersleri",
                            IsActive = false,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Tags = context.Tags.Take(2).ToList(),
                            UserID = 1,
                        },
                        new Post
                        {
                            Title = "AngularJS ile Frontend Geliştirme",
                            Content = "A-Z Detaylı AngularJS Dersleri",
                            URL="detayli-angular-dersleri",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            UserID = 2,
                        }
                    );
                    context.SaveChanges();
                }

            }
        }
    }
}
