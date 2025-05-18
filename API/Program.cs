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

//the cores header service, will allow request to go through
builder.Services.AddCors();

var app = builder.Build();

//just have to add this service here then chain on additional parameters
//AllowAnyMethod means all methods can be perform, ex. Put, Get, Delete, Etc
//the withOrgins is the client (angular project) server port
//if you did all of this and still getting errors check your string spelling
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
