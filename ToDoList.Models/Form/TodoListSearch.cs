using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enums;
using ToDoList.Models.SeedWorks;

namespace ToDoList.Models.Form
{
    public class TodoListSearch : PagingParamaters
    {
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }

        public Priority? Priority { get; set; }
    }
}
