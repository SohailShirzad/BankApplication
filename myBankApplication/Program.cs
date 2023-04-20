using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Helpers;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.Repository;
using myBankApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankCardRepository, BankCardsRepository>();
builder.Services.AddScoped<IAppUsersRepository, BankAppUsersRepository>();
builder.Services.AddScoped<ITransactionRepository, BankTransactionRepository>();
builder.Services.AddScoped<IDepositChequeRepository, BankDepositChequeRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

//builder.Services.AddScoped<IUserAuthenticationRepository, BankUserAuthenticationRepository >();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//For Identity
builder.Services.AddIdentity<AppUsersModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
    //AddDefaultTokenProviders();

   //builder.Services.AddMemoryCache();
    //builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.UsersAndRolesAsync(app);
}

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

// Only allow authorised users to see the dashboard.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
