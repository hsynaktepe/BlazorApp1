using BlazorApp1.Client.Utils;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Services.Infrastructure;
using BlazorApp1.Server.Services.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddBlazoredModal();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();

builder.Services.AddHttpClient();


builder.Services.AddScoped<ModalManager>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<ISupplierService, SupplierService>();
//builder.Services.AddScoped<IValidationService, ValidationService>();

//builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(config =>
{

    config.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database = MealApp; Integrated Security = True;");
    config.EnableSensitiveDataLogging();
});

var app = builder.Build();



//var userService = provider.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();
