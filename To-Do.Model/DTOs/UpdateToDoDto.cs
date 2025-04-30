using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.Enums;

namespace To_Do.Model.DTOs
{
    public class UpdateToDoDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
