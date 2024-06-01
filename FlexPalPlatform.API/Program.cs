
using System.Text;
using FlexPalPlatform.API.iam.Application.Internal.CommandServices;
using FlexPalPlatform.API.iam.Application.Internal.OutboundServices.ACL;
using FlexPalPlatform.API.iam.Application.Internal.QueryServices;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.iam.Infrastructure.Persistence.EFC.Repositories;
using FlexPalPlatform.API.Profiles.Application.Internal.CommandServices;
using FlexPalPlatform.API.Profiles.Application.Internal.QueryServices;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Profiles.Domain.Services;
using FlexPalPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using FlexPalPlatform.API.Profiles.Interfaces.ACL.Services;
using FlexPalPlatform.API.Profiles.Interfaces.ACL.Services.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.*
var configuration = builder.Configuration;
var jwtSecret = builder.Configuration["Jwt:Secret"];
builder.Services.AddSingleton(jwtSecret);
//Configuration JWT *
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
// Add Configuration for Routing

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment()) 
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction()) 
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
}); 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title   = "Flex-Pal-Platform.API",
            Version = "v1",
            Description = "FlexPal API",
            TermsOfService = new Uri("https://flexpal.com/tos"),
            Contact = new OpenApiContact{ Name = "FLEX PAL", Email = "contact@flexpal.com" },
            License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")},
        });
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
//Bounded Context Profile Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService,ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService,ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade,ProfilesContextFacade>();

//Bounded Context User Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService,UserCommandService>();
builder.Services.AddScoped<IUserQueryService,UserQueryService>();
builder.Services.AddScoped<IExternalProfileService, ExternalProfileService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
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