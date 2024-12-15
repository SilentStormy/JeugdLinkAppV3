using Core.Repositories;
using JeugdLinkBLL.Interfaces;
using JeugdLinkBLL.Services;
using JeugdLinkBLL.UserService;
using JeugdLinkDAL.Data;
using JeugdLinkDAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegistration, Registration>();
builder.Services.AddScoped<IAuthenticator, Authentication>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseManager, CourseManager>();


//builder.Services.AddScoped<IAuthenticator, Authentication>();
builder.Services.AddScoped<ICourseManager, CourseManager>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
