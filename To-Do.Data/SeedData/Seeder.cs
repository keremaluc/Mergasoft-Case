using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.Entities;
using To_Do.Model.Enums;

namespace To_Do.Data.SeedData
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Tüm ToDo verilerini sil
            context.ToDos.RemoveRange(context.ToDos);
            context.SaveChanges();

            // Default verileri yeniden ekle
            var defaultItems = new List<ToDoItem>
    {
        new ToDoItem { Title = "Projeyi başlat", Description = "İskelet yapıyı kur", IsCompleted = false, Priority = Priority.High },
        new ToDoItem { Title = "AutoMapper ekle", Description = "DTO dönüşümlerini yap", IsCompleted = false, Priority = Priority.Medium },
        new ToDoItem { Title = "Controller test et", Description = "Postman ile dene", IsCompleted = false, Priority = Priority.Low }
    };

            context.ToDos.AddRange(defaultItems);
            context.SaveChanges();
        }
    }
}
