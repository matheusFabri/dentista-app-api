using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DentistaApi.Services;
using DentistaApi.Models;
using DentistaApi.Data;

namespace AtletaBackend.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    public HomeController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
    {
        var retAuth = await authService.Login(userInfo);

        if (retAuth.Status == EReturnStatus.Success)
            return Ok(retAuth);
        else
            return BadRequest(retAuth.Result);
    }

    [HttpPost("Admin")]
    public ActionResult<Administrador> Post(Administrador obj)
    {
        if (obj == null)
            return BadRequest();

        obj.SetSenhaHash();

        db.Administrador.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    [HttpPost("Paciente")]
    public ActionResult<Paciente> Post(Paciente obj)
    {
        if (obj == null)
            return BadRequest();

        obj.SetSenhaHash();

        db.Pacientes.Add(obj);
        db.SaveChanges();


        return CreatedAtAction(nameof(GetById), new { id = obj.Id }, obj);

    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Paciente> GetById(int id)
    {

        var paciPaciente = db.Pacientes.FirstOrDefault(x => x.Id == id);

        return paciPaciente == null ? NotFound() : Ok(paciPaciente);
    }


    private readonly IAuthService authService;
    private readonly AppDbContext db = new();
}