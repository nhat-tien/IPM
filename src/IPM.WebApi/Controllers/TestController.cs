using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[ApiController]
public class TestController: Controller
{
[HttpGet("api/test")]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public ActionResult<Todo> Create(Todo item)
{
    return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
}
}
 
