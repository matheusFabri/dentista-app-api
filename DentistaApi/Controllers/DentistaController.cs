using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class DentistaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Dentista>> Get()
    {

        var dentiDentistas = db.Dentistas.ToList();

        return Ok(dentiDentistas);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Dentista> GetById(string id)
    {

        var dentiDentista = db.Dentistas.FirstOrDefault(x => x.Id == id);

        return dentiDentista == null ? NotFound() : Ok(dentiDentista);
    }

    [HttpPost]
    public ActionResult<Dentista> Post(Dentista obj)
    {
        if (obj.Id == null)
            obj.Id = Guid.NewGuid().ToString();

        db.Dentistas.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Dentista obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Dentistas.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Dentistas == null)
            return NotFound();

        var obj = db.Dentistas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Dentistas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
