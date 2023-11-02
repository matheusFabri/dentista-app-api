using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class EspecialidadeController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Especialidade>> Get()
    {

        var Especialidades = db.Especialidades.ToList();

        return Ok(Especialidades);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Especialidade> GetById(string id)
    {

        var espEspecialidade = db.Especialidades.FirstOrDefault(x => x.EspecialidadeId == id);

        return espEspecialidade == null ? NotFound() : Ok(espEspecialidade);
    }

    [HttpPost]
    public ActionResult<Especialidade> Post(Especialidade obj)
    {
        if (obj.EspecialidadeId == null)
            obj.EspecialidadeId = Guid.NewGuid().ToString();

        db.Especialidades.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.EspecialidadeId }, obj);

    }

    // PUT: api/Atleta/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Especialidade obj)
    {
        if (id != obj.EspecialidadeId)
            return BadRequest();

        db.Especialidades.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Especialidades == null)
            return NotFound();

        var obj = db.Especialidades.FirstOrDefault(x => x.EspecialidadeId == id);

        if (obj == null)
            return NotFound();

        db.Especialidades.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
