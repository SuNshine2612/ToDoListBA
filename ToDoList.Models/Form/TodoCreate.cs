using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enums;

namespace ToDoList.Models.Form
{
    public class TodoCreate
    {
		public Guid Id { get; set; }

		[DisplayName("Tên")]
		[MaxLength(250)]
		[Required]
		public string Name { get; set; }


		[DisplayName("Ưu tiên")]
		public Priority Priority { get; set; }
	}
}
