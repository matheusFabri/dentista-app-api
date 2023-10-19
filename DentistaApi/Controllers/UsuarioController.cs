using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Usuario>> Get()
    {

        var usuarios = db.Usuarios.ToList();

        return Ok(usuarios);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Usuario> GetById(string id)
    {

        var usuario = db.Usuarios.FirstOrDefault(x => x.Id == id);

        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public ActionResult<Usuario> Post(Usuario obj)
    {
        if (obj.Id == null)
            obj.Id = Guid.NewGuid().ToString();

        db.Usuarios.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    // PUT: api/Atleta/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Usuario obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Usuarios.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Usuarios == null)
            return NotFound();

        var obj = db.Usuarios.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Usuarios.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
