using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Interfaces.Services;
using ForecAPI.Interfaces.Services.Bases;
using ForecAPI.Interfaces.Services.BaseSections;
using ForecAPI.Interfaces.Services.Forces;
using ForecAPI.Models;
using ForecAPI.Repoitories;
using ForecAPI.Repoitories.General;
using ForecAPI.Service;
using ForecAPI.Service.Bases;
using ForecAPI.Service.BaseSections;
using ForecAPI.Service.Forces;
using ForecAPI.Service.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ForceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForceDBConnStr"));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ForceDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(MappingProfileBase));

#region Configure Repositories
builder.Services.AddScoped(typeof(IApplicationUserRepository), typeof(ApplicationUserRepository));
builder.Services.AddScoped(typeof(IForceRepository), typeof(ForceRepository));
builder.Services.AddScoped(typeof(IForceBaseRepository), typeof(ForceBaseRepository));
builder.Services.AddScoped(typeof(IBaseSectionRepository), typeof(BaseSectionReposiroty));
#endregion
#region Configure services
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
//builder.Services.AddScoped(typeof(IConfiguration), typeof(Configuration));
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
builder.Services.AddScoped(typeof(IForceService), typeof(ForceService));
builder.Services.AddScoped(typeof(IForceBaseService), typeof(ForceBaseService));
builder.Services.AddScoped(typeof(IBaseSectionService), typeof(BaseSectionService));
#endregion
#region Read Token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = "Force.com",
        ValidAudience = "Force.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ForceSuperSecretPassword"))
    };
});
#endregion


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
