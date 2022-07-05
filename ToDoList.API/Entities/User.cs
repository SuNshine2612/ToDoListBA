using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.API.Entities
{
	public class User : IdentityUser<Guid>
	{
		[DisplayName("Tên")]
		[MaxLength(250)]
		[Required]
		public string FirstName { get; set; }

		[DisplayName("Họ")]
		[MaxLength(250)]
		[Required]
		public string LastName { get; set; }
	}
}
