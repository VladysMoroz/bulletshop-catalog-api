using ApplicationServices.Services;
using Core.AutoMapper.AmmunitionMappers;
using Core.AutoMapper.BulletMappers;
using Core.AutoMapper.ColdWeaponMapper;
using Core.AutoMapper.OpticMappers;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using DatabaseCatalog;
using DatabaseCatalog.Repositories;
using Host.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddHttpContextAccessor();
// SERVICES
builder.Services.AddScoped<IPreferenceService, PreferenceService>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IColdWeaponService, ColdWeaponService>();
builder.Services.AddScoped<IOpticService, OpticService>();
builder.Services.AddScoped<IBulletService, BulletService>();
builder.Services.AddScoped<IAmmunitionService, AmmunitionService>();

// --------

// REPOSITORIES
builder.Services.AddScoped<IPreferenceRepository, PreferenceRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();
builder.Services.AddScoped<IColdWeaponRepository, ColdWeaponRepository>();
builder.Services.AddScoped<IOpticRepository, OpticRepository>();
builder.Services.AddScoped<IBulletRepository, BulletRepository>();
builder.Services.AddScoped<IAmmunitionRepository, AmmunitionRepository>();

// ---------

builder.Services.AddAutoMapper(
     typeof(FromAmmunitionToAmmunitionViewModelMapper)
    ,typeof(FromColdWeaponToColdWeaponViewModelMapper)
    ,typeof(FromOpticToOpticViewModelMapper)
    ,typeof(FromBulletToBulletViewModelMapper));
//builder.Services.AddAutoMapper(typeof());

//builder.Services.AddScoped<IMyPasswordHasher, MyPasswordHasher>();

builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});


// --------------------------

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});

// --------------------------

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseMiddleware<TokenProcessingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    db.Database.Migrate();
}

app.Run();
