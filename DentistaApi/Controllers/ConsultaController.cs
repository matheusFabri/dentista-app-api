using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ConsultaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Consulta>> Get()
    {

        var consultas = db.Consultas.ToList();

        return Ok(consultas);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Consulta> GetById(string id)
    {

        var consulta = db.Consultas.FirstOrDefault(x => x.ConsultaId == id);

        return consulta == null ? NotFound() : Ok(consulta);
    }

    [HttpPost]
    public ActionResult<Consulta> Post(Consulta obj)
    {
        if (obj.ConsultaId == null)
            obj.ConsultaId = Guid.NewGuid().ToString();

        db.Consultas.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.ConsultaId }, obj);

    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Consulta obj)
    {
        if (id != obj.ConsultaId)
            return BadRequest();

        db.Consultas.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Consultas == null)
            return NotFound();

        var obj = db.Consultas.FirstOrDefault(x => x.ConsultaId == id);

        if (obj == null)
            return NotFound();

        db.Consultas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
