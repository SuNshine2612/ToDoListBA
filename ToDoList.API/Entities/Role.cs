using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;

namespace ToDoList.API.Entities
{
	public class Role : IdentityRole<Guid>
	{
		[DisplayName("Mô tả")]
		public string Description { get; set; }
	}
}
