using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enums;

namespace ToDoList.Models.DTO
{
    public class TodoDTO
    {
		public Guid Id { get; set; }

		[DisplayName("Tên")]
		public string Name { get; set; }

		[DisplayName("Người nhận")]
		public Guid? AssigneeId { get; set; }

		[DisplayName("Người nhận")]
		public string AssigneeName { get; set; }

		[DisplayName("Ngày tạo")]
		public DateTime CreatedDate { get; set; }

		[DisplayName("Trạng thái")]
		public Status Status { get; set; }

		[DisplayName("Ưu tiên")]
		public Priority Priority { get; set; }
	}
}
