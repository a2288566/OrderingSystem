using InStoreOrdering.IRepositorys;
using InStoreOrdering.Repositorys;
using InStoreOrdering.Services;
using System.Data.SqlClient;
using System.Data;
using InStoreOrdering.Models;
using InStoreOrdering.IServices;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("InStoreOrderingDB")));

//// °t¸mDI
//builder.Services.AddScoped<ILoginRepository, LoginRepository>();
//builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<IMealRepository, MealRepository>();
//builder.Services.AddScoped<IMealService, MealService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// ª`¤J IRepository
builder.Services.AddTransient<ILoginRepository>(provider => new LoginRepository(builder.Configuration.GetConnectionString("InStoreOrderingDB")));
builder.Services.AddTransient<IMealRepository>(provider => new MealRepository(builder.Configuration.GetConnectionString("InStoreOrderingDB")));

// ª`¤J Service
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IMealService, MealService>();


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
