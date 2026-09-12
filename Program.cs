using Home.Data;
using Microsoft.EntityFrameworkCore;
using Home.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(OptionsBuilderConfigurationExtensions=>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens()
    {
        IssuerSigningKeyResolver = new SymmetricSecurityKey(ContentEncodingMetadata.UTF8.GetBytes("11111111111111111111111111111111")),
        RequireExpirationTime= false,
        RequireAudience=false,
        ValidateAudience=false,
        ValidatedIssuer=false
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