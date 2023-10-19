using DentistaApi.Data;
using DentistaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DentistaApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class PagamentoController : ControllerBase
{
    [HttpGet]
    public ActionResult<IList<Pagamento>> Get()
    {

        var pagaPagamentos = db.Pagamentos.ToList();

        return Ok(pagaPagamentos);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Pagamento> GetById(string id)
    {

        var pagaPagamento = db.Pagamentos.FirstOrDefault(x => x.PagamentoId == id);

        return pagaPagamento == null ? NotFound() : Ok(pagaPagamento);
    }

    [HttpPost]
    public ActionResult<Pagamento> Post(Pagamento obj)
    {
        if (obj.PagamentoId == null)
            obj.PagamentoId = Guid.NewGuid().ToString();

        db.Pagamentos.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.PagamentoId }, obj);

    }

    // PUT: api/Atleta/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Pagamento obj)
    {
        if (id != obj.PagamentoId)
            return BadRequest();

        db.Pagamentos.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Pagamentos == null)
            return NotFound();

        var obj = db.Pagamentos.FirstOrDefault(x => x.PagamentoId == id);

        if (obj == null)
            return NotFound();

        db.Pagamentos.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly AppDbContext db = new();
}

