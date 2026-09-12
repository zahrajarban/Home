using Home.Data;
using Home.Services;
using Jose;
using JWT.Algorithms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtCreator = JWT.Builder.JwtBuilder.Create();
string jwtStr = jwtCreator
    .AddClaim("name", "zahra jarban")
    .AddClaim("company", "fanavid")
    .WithAlgorithm(new HMACSHA256Algorithm())
    .WithSecret("11111111111111111111111111111111")
    .Encode();

builder.Services.AddScoped<FavoriteService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HomeService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("11111111111111111111111111111111")),
            RequireExpirationTime = false,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
