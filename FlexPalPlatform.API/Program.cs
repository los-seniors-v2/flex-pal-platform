
using System.Text;
using FlexPalPlatform.API.Counseling.Application.CommandServices;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;
using FlexPalPlatform.API.iam.Application.Internal.CommandServices;
using FlexPalPlatform.API.iam.Application.Internal.OutboundServices;
using FlexPalPlatform.API.iam.Application.Internal.QueryServices;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.iam.Infrastructure.Hashing.BCrypt.Services;
using FlexPalPlatform.API.iam.Infrastructure.Persistence.EFC.Repositories;
using FlexPalPlatform.API.iam.Infrastructure.Tokens.JWT.Services;
using FlexPalPlatform.API.iam.Interfaces.ACL;
using FlexPalPlatform.API.iam.Interfaces.ACL.Services;
using FlexPalPlatform.API.Profiles.Application.Internal.CommandServices;
using FlexPalPlatform.API.Profiles.Application.Internal.QueryServices;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Profiles.Domain.Services;
using FlexPalPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using FlexPalPlatform.API.Profiles.Interfaces.ACL;
using FlexPalPlatform.API.Profiles.Interfaces.ACL.Services;
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
// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

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
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ACME.LearningCenterPlatform.API",
                Version = "v1",
                Description = "ACME Learning Center Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
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
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Add Counseling context services and repositories
builder.Services.AddScoped<IFitnessPlanRepository, FitnessPlanRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IFitnessPlanService, FitnessPlanCommandService>();
builder.Services.AddScoped<ICoachService, CoachCommandService>();
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

// Use CORS in Configure
app.UseCors("AllowedAllPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();