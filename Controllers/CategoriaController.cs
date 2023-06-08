using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class CategoriaController: ControllerBase
{
  protected readonly ICategoriaService _categoriaService;

  public CategoriaController(ICategoriaService service)
  {
    _categoriaService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_categoriaService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Categoria categoria)
  {
    _categoriaService.Save(categoria);
    return Ok("Categoria creada");
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Categoria categoria)
  {
    _categoriaService.Update(id, categoria);
    return Ok("Categoria actualizada");
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    _categoriaService.Delete(id);
    return Ok("Categoria eliminada");
  }
}
