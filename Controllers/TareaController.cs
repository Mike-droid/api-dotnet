using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("/api/[controller]")]
public class TareaController : ControllerBase
{
  protected readonly ITareasService _tareasService;

  public TareaController(ITareasService service)
  {
    _tareasService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_tareasService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tarea tarea)
  {
    _tareasService.Save(tarea);
    return Ok("Tarea creada");
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Tarea tarea)
  {
    _tareasService.Update(id, tarea);
    return Ok("Tarea actualizada");
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    _tareasService.Delete(id);
    return Ok("Tarea eliminada");
  }
}
