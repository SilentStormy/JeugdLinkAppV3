using Core.Repositories;
//using JeugdLinkBLL.Interfaces;
using JeugdLinkBLL.Services;
//using JeugdLinkBLL.UserService;
using JeugdLinkDAL.Data;
using JeugdLinkDAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Core.Entities;
using JeugdLinkBLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 27))));
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //database related
builder.Services.AddScoped<ICategoryservice, CategoryService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseservice, CourseService>();    
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
    var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryservice>();
    var categories = categoryService.GetAllCategories();

    if (categories == null || !categories.Any())
    {
        Console.WriteLine("[ERROR]: No categories found. Check database connection or seeding.");
    }
    else
    {
        Console.WriteLine("[INFO]: Categories successfully retrieved:");
        foreach (var category in categories)
        {
            Console.WriteLine($"- {category.name} ({category.description})");
        }
    }
}
app.MapRazorPages();

app.Run();
