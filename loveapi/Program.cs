using Microsoft.EntityFrameworkCore;
using LoveApi;
using LoveApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add CORS only once
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Use CORS after Build
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.MapPost("/api/love", async (LoveContext db, Couple couple) =>
{
    db.Couples.Add(couple);
    await db.SaveChangesAsync();
    return Results.Ok(couple);
});

app.MapGet("/api/love", async (LoveContext db) =>
    await db.Couples.ToListAsync());

app.Run();
