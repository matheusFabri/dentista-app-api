using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class PacienteController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Paciente>> Get()
    {

        var paciPacientes = db.Pacientes.ToList();

        return Ok(paciPacientes);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Paciente> GetById(string id)
    {

        var paciPaciente = db.Pacientes.FirstOrDefault(x => x.Id == id);

        return paciPaciente == null ? NotFound() : Ok(paciPaciente);
    }

    [HttpPost]
    public ActionResult<Paciente> Post(Paciente obj)
    {
        if (obj.Id == null)
            obj.Id = Guid.NewGuid().ToString();

        db.Pacientes.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Paciente obj)
    {
        if (id != obj.Id)
            return BadRequest();

        db.Pacientes.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Pacientes == null)
            return NotFound();

        var obj = db.Pacientes.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound();

        db.Pacientes.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}
