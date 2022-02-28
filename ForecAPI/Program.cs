using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Interfaces.Services;
using ForecAPI.Models;
using ForecAPI.Repoitories;
using ForecAPI.Repoitories.General;
using ForecAPI.Service.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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


#region Configure Repositories
builder.Services.AddScoped(typeof(IApplicationUserRepository), typeof(ApplicationUserRepository));
#endregion
#region Configure services
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
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
