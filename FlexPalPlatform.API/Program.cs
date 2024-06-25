
using System.Text;
using FlexPalPlatform.API.counseling.Application.Internal.CommandServices;
using FlexPalPlatform.API.counseling.Application.Internal.QueryServices;
using FlexPalPlatform.API.counseling.Application.Internal.Services;
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
using FlexPalPlatform.API.iam.Infrastructure.Tokens.JWT.Configuration;
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
using FlexPalPlatform.API.Subscriptions.Application.Internal.CommandServices;
using FlexPalPlatform.API.Subscriptions.Application.Internal.QueryServices;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Repositories;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Services;
using FlexPalPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar TokenSettings
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

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
            Contact = new OpenApiContact{ Name = "ACME Learning Center", Email = "contact@acme.com" },
            License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")},
        });
    });

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", policy => policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

// Bounded Context Profile Injection Configuration
builder.Services.AddScoped<IWeightLossService, WeightLossCommandService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService,ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService,ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade,ProfilesContextFacade>();

// Bounded Context User Injection Configuration

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService,UserCommandService>();
builder.Services.AddScoped<IUserQueryService,UserQueryService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Add Counseling context services and repositories
builder.Services.AddScoped<IFitnessPlanRepository, FitnessPlanRepository>();
builder.Services.AddScoped<IFitnessPlanCommandService, FitnessPlanCommandService>();
builder.Services.AddScoped<IFitnessPlanQueryService, FitnessPlanQueryService>();
builder.Services.AddScoped<FlexPalPlatform.API.counseling.Application.Internal.CommandServices.FitnessPlanCommandService, FlexPalPlatform.API.counseling.Application.Internal.CommandServices.FitnessPlanCommandService>();
builder.Services.AddScoped<FlexPalPlatform.API.counseling.Application.Internal.QueryServices.FitnessPlanQueryService, FlexPalPlatform.API.counseling.Application.Internal.QueryServices.FitnessPlanQueryService>();

builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICoachQueryService, CoachQueryService>();
builder.Services.AddScoped<ICoachCommandService, CoachCommandService>();
builder.Services.AddScoped<FlexPalPlatform.API.counseling.Application.Internal.CommandServices.CoachCommandService, FlexPalPlatform.API.counseling.Application.Internal.CommandServices.CoachCommandService>();
builder.Services.AddScoped<FlexPalPlatform.API.counseling.Application.Internal.QueryServices.CoachQueryService, FlexPalPlatform.API.counseling.Application.Internal.QueryServices.CoachQueryService>();

builder.Services.AddScoped<IRoutineItemRepository, RoutineItemRepository>();
builder.Services.AddScoped<IRoutineItemService, RoutineItemService>();

builder.Services.AddScoped<INutritionalMealRepository, NutritionalMealRepository>();
builder.Services.AddScoped<INutritionalMealService, NutritionalMealService>();

builder.Services.AddScoped<IDailyExerciseRepository, DailyExerciseRepository>();
builder.Services.AddScoped<IDailyExerciseService, DailyExerciseService>();


//Bounded Context Subscription Injection Configuration
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();

// Weight Loss Service
builder.Services.AddScoped<IWeightLossService, WeightLossCommandService>();

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

// Add CORS Middleware with AllowAllPolicy
app.UseCors("AllowAllPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();