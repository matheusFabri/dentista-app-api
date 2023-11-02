using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AnamneseController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Anamnese>> Get()
    {

        var anaAnamneses = db.Anamneses.ToList();

        return Ok(anaAnamneses);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Anamnese> GetById(string id)
    {

        var anaAnamnese = db.Anamneses.FirstOrDefault(x => x.Id == id);

        return anaAnamnese == null ? NotFound() : Ok(anaAnamnese);
    }

    [HttpPost]
    public ActionResult<Anamnese> Post(Anamnese obj)
    {
        if (obj.Id == null)
            obj.Id = Guid.NewGuid().ToString();

        db.Anamneses.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Anamnese obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Anamneses.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Anamneses == null)
            return NotFound();

        var obj = db.Anamneses.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Anamneses.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
