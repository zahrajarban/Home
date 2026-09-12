using Home.Data;
using Microsoft.EntityFrameworkCore;
using Home.Services;
var builder = WebApplication.CreateBuilder(args);
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();