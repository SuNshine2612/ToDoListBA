using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enums;

namespace ToDoList.Models.Form
{
    public class TodoUpdate
    {
		[DisplayName("Tên")]
		public string Name { get; set; }

		[DisplayName("Ưu tiên")]
		public Priority Priority { get; set; }
	}
}
