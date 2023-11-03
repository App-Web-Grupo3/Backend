using Data.Context;
using Data.Persistencia;
using Data.Persistencia.Impl;
using Domain.Service;
using Domain.Service.Impl;
using Microsoft.EntityFrameworkCore;
using UniqueTrip.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependencie Injection 
builder.Services.AddScoped<IRepresentanteDomain, RepresentanteDomain>();
builder.Services.AddScoped<IRepresentanteData, RepresentanteData>();
builder.Services.AddScoped<ITouristDomain, TouristDomain>();
builder.Services.AddScoped<ITouristData, TouristData>();
builder.Services.AddScoped<IResponseDomain, ResponseDomain>();
builder.Services.AddScoped<IResponseData, ResponseData>();
builder.Services.AddScoped<IActivitiesDomain, ActivitiesDomain>();
builder.Services.AddScoped<IActivitiesData, ActivitiesData>();
builder.Services.AddScoped<IImagesDomain, ImagesDomain>();
builder.Services.AddScoped<IImagesData, ImagesData>();

var connectionString = builder.Configuration.GetConnectionString("Conection");

builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToResource),
    typeof(ResourceToModel)
);


var app = builder.Build();


using (var scoope = app.Services.CreateScope())
using (var context = scoope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

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