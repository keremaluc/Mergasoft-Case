using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Model.Mappings;
using To_Do.Repository.Interfaces;
using To_Do.Repository.Implementations;
using To_Do.Service.Interfaces;
using To_Do.Service.Services;
using To_Do.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbPath = Path.Combine(AppContext.BaseDirectory, "todo.db");
if (File.Exists(dbPath))
{
    File.Delete(dbPath);
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();


var app = builder.Build();
//
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    Seeder.Seed(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
