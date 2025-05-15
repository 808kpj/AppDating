using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//everything that is injected after it have been called it will be disposed of in memory automatic via the framework.
builder.Services.AddDbContext<DataContext>( opt =>
{
    //the connection string, allows you to talk to the database
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
