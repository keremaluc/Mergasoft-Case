using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Model.Mappings;
using To_Do.Repository.Interfaces;
using To_Do.Repository.Implementations;
using To_Do.Service.Interfaces;
using To_Do.Service.Services;
using To_Do.Model.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!dbContext.ToDos.Any())
    {
        var todo = new ToDoItem
        {
            Title = "Test Baþlýk",
            Description = "Test açýklama",
            Priority = 0,
            IsCompleted = true,
            CreatedAt = DateTime.Parse("2025-03-09T14:00:00")
        };
        dbContext.ToDos.Add(todo);
        await dbContext.SaveChangesAsync();
    }

    var addedToDo = await dbContext.ToDos.OrderBy(m => m.Id).FirstOrDefaultAsync();
    Console.WriteLine($"Eklenen Görev: {addedToDo?.Title}, ID: {addedToDo?.Id}");
}

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
