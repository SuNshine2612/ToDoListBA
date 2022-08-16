using System;

namespace ToDoList.Models.Form
{
    public class TodoAssignUser
    {
        public Guid? UserId { get; set; }
        public Guid TodoId { get; set; }
    }
}
