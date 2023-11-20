using Data.Context;
using Data.Persistencia;
using Data.Persistencia.Impl;
using Domain.Mapper;
using Domain.Service;
using Domain.Service.Impl;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using UniqueTrip.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependencie Injection 
builder.Services.AddScoped<IRepresentativeDomain, RepresentativeDomain>();
builder.Services.AddScoped<IRepresentativeData, RepresentativeData>();
builder.Services.AddScoped<ITouristDomain, TouristDomain>();
builder.Services.AddScoped<ITouristData, TouristData>();
builder.Services.AddScoped<ICompanyDomain, CompanyDomain>();
builder.Services.AddScoped<ICompanyData, CompanyData>();
builder.Services.AddScoped<IResponseDomain, ResponseDomain>();
builder.Services.AddScoped<IResponseData, ResponseData>();
builder.Services.AddScoped<IActivitiesDomain, ActivitiesDomain>();
builder.Services.AddScoped<IActivitiesData, ActivitiesData>();
builder.Services.AddScoped<IImagesDomain, ImagesDomain>();
builder.Services.AddScoped<IImagesData, ImagesData>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IEncryptDomain, EncryptDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();
builder.Services.AddScoped<IPaymentMethodDomain, PaymentMethodDomain>();
builder.Services.AddScoped<IPaymentMethodData, PaymentMethodData>();
builder.Services.AddScoped<IFavoritesDomain, FavoritesDomain>();
builder.Services.AddScoped<IFavoritesData, FavoritesData>();
builder.Services.AddScoped<ICommentDomain, CommentDomain>();
builder.Services.AddScoped<ICommentData, CommentData>();
builder.Services.AddScoped<IPurchaseDetailDomain, PurchaseDetailDomain>();
builder.Services.AddScoped<IPurchaseDetailData, PurchaseDetailData>();


//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Connection to MySql
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
    typeof(ResourceToModel),
    typeof(UserBaseTo)
);

// The following line enables Application Insights telemetry collection.
builder.Services.AddApplicationInsightsTelemetry();

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

app.UseExceptionHandler(builder =>
{
    builder.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        await next();
    });
});

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();