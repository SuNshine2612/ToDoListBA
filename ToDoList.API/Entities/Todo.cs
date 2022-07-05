using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.API.Enums;

namespace ToDoList.API.Entities
{
	public class Todo
	{
		[Key]
		public Guid Id { get; set; }

		[DisplayName("Tên")]
		[MaxLength(250)]
		[Required]
		public string Name { get; set; }
		
		[DisplayName("Người nhận")]
		public Guid? AssigneeId { get; set; }

		[ForeignKey("AssigneeId")]
		public User Assignee { get; set; }

		[DisplayName("Ngày tạo")]
		public DateTime CreatedDate { get; set; }
		
		[DisplayName("Ưu tiên")]
		public Priority Priority { get; set; }
		
		[DisplayName("Trạng thái")]
		public Status Status { get; set; }
	}
}
