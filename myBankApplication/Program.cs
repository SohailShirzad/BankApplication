using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankCardRepository, BankCardsRepositorycs>();
builder.Services.AddScoped<ICustomerRepository, BankCustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository, BankEmployeeRepository>();
builder.Services.AddScoped<IStatementRepository, BankStatementRepository>();
builder.Services.AddScoped<ISupervisorRepository, BankSupervisorRepository>();
builder.Services.AddScoped<ITransactionRepository, BankTransactionRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
