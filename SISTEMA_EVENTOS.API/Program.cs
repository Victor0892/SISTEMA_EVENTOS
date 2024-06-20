using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefautConnection") /*?? throw new InvalidOperationException("Connection string 'Identity_ContextConnection' not found.")*/;

// Add services to the container.
builder.Services.AddScoped<ServiceEvento>();
builder.Services.AddScoped<ServiceInscricao>();
builder.Services.AddScoped<ServiceLocal>();
builder.Services.AddScoped<ServiceOrganizador>();
builder.Services.AddScoped<ServiceParticipante>();

builder.Services.AddDbContext<GerenciamentoEventosContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(policyBuilder =>
     policyBuilder.AddDefaultPolicy(policy =>
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
