using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Entities;
using ToDoList.API.Repositories;
using ToDoList.Models.DTO;
using ToDoList.Models.Enums;
using ToDoList.Models.Form;
using ToDoList.Models.SeedWorks;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TodoListSearch search)
        {
            var pagedList = await _todoRepository.GetTodos(search);

            var rs = pagedList.Datas.Select(x => new TodoDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                AssigneeId = x.AssigneeId,
                Priority = x.Priority,
                Status = x.Status,
                AssigneeName = x.Assignee is not null ? $"{x.Assignee.FirstName} {x.Assignee.LastName}" : "Not Assign"
            });
            //var rs = new List<TodoDTO>();

            return Ok(new PagedList<TodoDTO>(rs.ToList(), 
                pagedList.MetaData.TotalCount,
                pagedList.MetaData.CurrentPage, 
                pagedList.MetaData.PageSize
            ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var todo = await _todoRepository.GetById(id);
            if (todo == null) return NotFound($"{id} is not found!");
            return Ok(new TodoDTO()
            {
                Id = todo.Id,
                Name = todo.Name,
                CreatedDate = todo.CreatedDate,
                AssigneeId = todo.AssigneeId,
                Priority = todo.Priority,
                Status = todo.Status,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoCreate todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rs = await _todoRepository.Create(new Todo()
            {
                Name = todo.Name,
                Priority = todo.Priority,
                Status = Status.Open,
                CreatedDate = DateTime.Now,
                Id = todo.Id
            });
            return CreatedAtAction(nameof(GetDetails), new { id = rs.Id }, rs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TodoUpdate todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var find = await _todoRepository.GetById(id).ConfigureAwait(false);
            if (find == null)
                return NotFound($"{id} is not found!");

            find.Name = todo.Name;
            find.Priority = todo.Priority;

            var rs = await _todoRepository.Update(find);

            return Ok(new TodoDTO()
            {
                Id = rs.Id,
                Name = rs.Name,
                CreatedDate = rs.CreatedDate,
                AssigneeId = rs.AssigneeId,
                Priority = rs.Priority,
                Status = rs.Status,
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignUser(TodoAssignUser assignUser)
        {
            var find = await _todoRepository.GetById(assignUser.TodoId).ConfigureAwait(false);
            if(find == null)
                return NotFound(ModelState);

            find.AssigneeId = assignUser.UserId;
            var rs = await _todoRepository.Update(find).ConfigureAwait(false);
            if (rs != null)
                return Ok();
            else
                return BadRequest(ModelState);
            /*return Ok(new TodoDTO()
            {
                Id = rs.Id,
                Name = rs.Name,
                CreatedDate = rs.CreatedDate,
                AssigneeId = rs.AssigneeId,
                Priority = rs.Priority,
                Status = rs.Status,
            });*/
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var find = await _todoRepository.GetById(id);
            if(find == null)
                return NotFound(ModelState);

            var rs = await _todoRepository.Delete(find);
            return Ok(new TodoDTO()
            {
                Id = rs.Id,
                Name = rs.Name,
                CreatedDate = rs.CreatedDate,
                AssigneeId = rs.AssigneeId,
                Priority = rs.Priority,
                Status = rs.Status,
            });
        }
    }
}
