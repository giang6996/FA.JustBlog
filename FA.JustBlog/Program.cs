using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core;
using FA.JustBlog.Controllers;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<JustBlogDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagService, TagService>();


var app = builder.Build();

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
            name: "PostDetails",
            pattern: "Post/{year}/{month}/{title}",
            defaults: new { controller = "Post", action = "DetailDate" }
        );

app.MapControllerRoute(
    name: "CategoryDetails",
    pattern: "Category/{name}",
    defaults: new { controller = "Category", action = "DetailName" }
);

app.MapControllerRoute(
    name: "TagList",
    pattern: "Tag/{name}",
    defaults: new { controller = "Tag", action = "List" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
