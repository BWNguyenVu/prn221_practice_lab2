using BusinessObject;
using DAO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Connection string and DbContext registration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
});

// Add services to the container.
builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
builder.Services.AddScoped<IFlowerService, FlowerService>(); // Make sure this line is present

// Add DAO
builder.Services.AddScoped<FlowerDAO, FlowerDAO>();
builder.Services.AddScoped<FlowerMediaDAO, FlowerMediaDAO>();
builder.Services.AddScoped<AccountDAO, AccountDAO>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFlowerMediaRepository, FlowerMediaRepository>();
builder.Services.AddScoped<IFlowerMediaService, FlowerMediaService>();
// Add Identity
builder.Services.AddIdentity<Account, IdentityRole<string>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapRazorPages();

app.Run();
