using Application;
using Application.Logging;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Cart;
using Application.UseCases.Commands.Color;
using Application.UseCases.Commands.Image;
using Application.UseCases.Commands.Model;
using Application.UseCases.Commands.Price;
using Application.UseCases.Commands.User;
using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Implementation;
using Implementation.Logging;
using Implementation.UseCases.Commands.Brand;
using Implementation.UseCases.Commands.Cart;
using Implementation.UseCases.Commands.Color;
using Implementation.UseCases.Commands.Image;
using Implementation.UseCases.Commands.Model;
using Implementation.UseCases.Commands.ModelColor;
using Implementation.UseCases.Commands.Price;
using Implementation.UseCases.Commands.ProductCart;
using Implementation.UseCases.Commands.User;
using Implementation.UseCases.Queries;
using Implementation.Validation.Brand;
using Implementation.Validation.Cart;
using Implementation.Validation.Color;
using Implementation.Validation.Image;
using Implementation.Validation.Model;
using Implementation.Validation.Price;
using Implementation.Validation.ProductCart;
using Implementation.Validation.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using ProjASP;
using ProjASP.API.Core;
using ProjASP.Application;
using ProjASP.Core;
using ProjASP.Implementation;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var settings = new AppSettings();

builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings.Jwt);
// Add services to the container.
builder.Services.AddTransient<AspProjContext>(x => new AspProjContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IExeptionLogger, ConsoleExeptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();

//Brand
builder.Services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
builder.Services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
builder.Services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
builder.Services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();

// Cart
builder.Services.AddTransient<IGetCartQuery, EfGetCartQuery>();
builder.Services.AddTransient<ICreateCartCommand, EfCreateCartCommand>();
builder.Services.AddTransient<IUpdateCartCommand, EfUpdateCartCommand>();
builder.Services.AddTransient<IDeleteCartCommand, EfDeleteCartCommand>();

// Product Cart
builder.Services.AddTransient<IGetProductCartQuery, EfGetProductCartQuery>();
builder.Services.AddTransient<ICreateProductCartCommand, EfCreateProductCartCommand>();
builder.Services.AddTransient<IUpdateProductCartCommand, EfUpdateProductCartCommand>();
builder.Services.AddTransient<IDeleteProductCartCommand, EfDeleteProductCartCommand>();

// Color
builder.Services.AddTransient<IGetColorQuery, EfGetColorQuery>();
builder.Services.AddTransient<ICreateColorCommand, EfCreateColorCommand>();
builder.Services.AddTransient<IUpdateColorCommand, EfUpdateColorCommand>();
builder.Services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>();

// Image
builder.Services.AddTransient<IGetImageQuery, EfGetImageQuery>();
builder.Services.AddTransient<ICreateImageCommand, EfCreateImageCommand>();
//builder.Services.AddTransient<IUpdateImageCommand, EfUpdateImageCommand>();
//builder.Services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();

// Model
builder.Services.AddTransient<IGetModelQuery, EfGetModelQuery>();
builder.Services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
builder.Services.AddTransient<IUpdateModelCommand, EfUpdateModelCommand>();
builder.Services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();

// ModelColor
builder.Services.AddTransient<IGetModelColorQuery, EfGetModelColorQuery>();
builder.Services.AddTransient<ICreateModelColorCommand, EfCreateModelColorCommand>();
builder.Services.AddTransient<IUpdateModelColorCommand, EfUpdateModelColorCommand>();
builder.Services.AddTransient<IDeleteModelColorCommand, EfDeleteModelColorCommand>();

// Price
builder.Services.AddTransient<IGetPriceQuery, EfGetPriceQuery>();
builder.Services.AddTransient<ICreatePriceCommand, EfCreatePriceCommand>();
builder.Services.AddTransient<IUpdatePriceCommand, EfUpdatePriceCommand>();
builder.Services.AddTransient<IDeletePriceCommand, EfDeletePriceCommand>();

// User
builder.Services.AddTransient<IGetUserQuery, EfGetUserQuery>();
builder.Services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
builder.Services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
builder.Services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogQuery>();

//Validators
builder.Services.AddTransient<BrandCreateValidator>();
builder.Services.AddTransient<CartCreateValidator>();
builder.Services.AddTransient<ColorCreateValidator>();
builder.Services.AddTransient<ImageCreateValidator>();
builder.Services.AddTransient<ModelCreateValidator>();
builder.Services.AddTransient<ModelColorCreateValidator>();
builder.Services.AddTransient<PriceCreateValidator>();
builder.Services.AddTransient<ProductCartCreateValidator>();
builder.Services.AddTransient<UserCreateValidator>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<AspProjContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //Token dohvatamo iz Authorization header-a

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }


            return Task.CompletedTask;

        }
    };
});


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
