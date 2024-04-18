using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("mysql_connection");
    //options.UseSqlite(connectionString);
    var version = new MySqlServerVersion(new Version(8,0,36));
    options.UseMySql(connectionString, version);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
//her sanal nesneye(IPostRepository) kar��l�k ger�ek (EfPostRepository) nesne olu�tur. AddScoped her http iste�inde ayn� nesnenin kullan�lmas�n� sa�lar.

var app = builder.Build();
SeedData.TestData(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/{url}",
    defaults:new{controller="Posts",action="Detail"}); //slug url anlamına geliyor
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
