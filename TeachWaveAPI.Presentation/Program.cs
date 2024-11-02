using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.Mappings;
using TeachWaveAPI.Infraestructure.Configuration;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => 
                                            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)),
                                            b => b.MigrationsAssembly("TeachWaveAPI.Infraestructure")
                                            ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

ConfigScoped.AddScopedServices(builder.Services);

var app = builder.Build();

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
