using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enums;

namespace ToDoList.Models.Form
{
    public class TodoListSearch
    {
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }

        public Priority? Priority { get; set; }
    }
}
