using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración del archivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// JWT Secret Key
var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey);

// Configuración de autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SimuVerseLabContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

//builder.Services.AddDbContext<SimuVerseLabContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DevHostConnection")));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
builder.Services.AddScoped<ILaboratorioService, LaboratorioService>();
builder.Services.AddScoped<IAulaService, AulaService>();
builder.Services.AddScoped<IExperimentoService, ExperimentoService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddCors();

var app = builder.Build();

// Middleware de CORS
app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Middleware de Swagger (habilitado siempre)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimuVerse API V1");
    c.RoutePrefix = "swagger"; // cambiar a "" si quieres en la raíz
});

// Redireccionar a Swagger desde "/"
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Middleware de seguridad
app.UseHttpsRedirection();
app.UseAuthentication(); // ¡Esto faltaba!
app.UseAuthorization();

// Rutas de controladores
app.MapControllers();

app.Run();
