using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankCardRepository, BankCardsRepository>();
builder.Services.AddScoped<IAppUsersRepository, BankAppUsersRepository>();
builder.Services.AddScoped<IStatementRepository, BankStatementRepository>();
builder.Services.AddScoped<ITransactionRepository, BankTransactionRepository>();
builder.Services.AddScoped<IUserAuthenticationRepository, BankUserAuthenticationRepository >();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//For Identity
builder.Services.AddIdentity<AppUsersModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(c => c.LoginPath = "/UserAuthentication/Login");

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
