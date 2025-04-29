using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.Entities;

namespace To_Do.Data
{
    public class ApplicationDbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
    }
}
