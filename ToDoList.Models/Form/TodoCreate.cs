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
		public Guid Id { get; set; } = Guid.NewGuid();

		[Display(Name = "Task name")]
		[MaxLength(20, ErrorMessage = "{0} can be up to {1} characters.")]
		[Required(ErrorMessage = "please enter your {0}")]
		public string Name { get; set; }


		[Display(Name = "Priority")]
		public Priority Priority { get; set; }
	}
}
