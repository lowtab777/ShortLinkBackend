
using Microsoft.EntityFrameworkCore;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Repositories;
using ShortLinkBackend.Services;
using ShortLinkBackend.ShortLinkDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShortUrlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConntection"));
});

builder.Services.AddScoped<IUserRespository, UserRepository>();
builder.Services.AddScoped<IShortLinkRepositroy, ShortLinkRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShortLinkRepositroy, ShortLinkRepository>();

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
