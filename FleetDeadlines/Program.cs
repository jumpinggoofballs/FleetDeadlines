using FleetDeadlines.Data;
using FleetDeadlines.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = "DataSource=myshareddb;mode=memory;cache=shared";
var keepAliveConnection = new SqliteConnection(connectionString);
keepAliveConnection.Open();

builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlite(keepAliveConnection)
);

var app = builder.Build();

// Seed initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    string api = builder.Configuration.GetValue<string>("UserOptions:TestApi");
    string key = builder.Configuration.GetValue<string>("UserOptions:TestKey");

    SeedData.Initialize(services, api, key);
}

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
