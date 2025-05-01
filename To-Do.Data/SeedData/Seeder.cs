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
        new ToDoItem { Title = "Projeyi başlat.", Description = "İskelet yapıyı kur", IsCompleted = true, Priority = Priority.Yüksek },
        new ToDoItem { Title = "AutoMapper ekle.", Description = "DTO dönüşümlerini yap", IsCompleted = true, Priority = Priority.Orta },
        new ToDoItem { Title = "Controller test et.", Description = "Postman ile dene", IsCompleted = false, Priority = Priority.Düşük },
        new ToDoItem { Title = "To-Do uygulaması yap.", Description = "Mergasoft için ToDo uygulaması geliştir", IsCompleted = false, Priority = Priority.Yüksek },
        new ToDoItem { Title = "Eğitim haritası çiz", Description = "Angular ve React öğren.", IsCompleted = false, Priority = Priority.Orta },
        new ToDoItem { Title = "Test verisi.", Description = "Bu bir test verisidir.Bu bir test verisidir.", IsCompleted = true, Priority = Priority.Orta }
    };

            context.ToDos.AddRange(defaultItems);
            context.SaveChanges();
        }
    }
}
