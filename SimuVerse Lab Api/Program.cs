using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SimuVerseLabContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

//builder.Services.AddScoped<IVideoJuegoService, VideoJuegoService>();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
