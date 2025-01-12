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
builder.Services.Configure<IdentityOptions>(options =>
options.SignIn.RequireConfirmedEmail = true
);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //database related
builder.Services.AddScoped<ICategoryservice, CategoryManager>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseservice, CourseManager>();    
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

app.MapRazorPages();

app.Run();
