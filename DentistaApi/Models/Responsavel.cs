namespace DentistaApi.Models;

public class Responsavel
{
    public string? Id { get; set; }
    public string Nome { get; set; } = "";
    public string Cpf { get; set; } = "";
    public string Telefone { get; set; } = "";
    public Paciente? Paciente { get; set; } = null!;
    public string? PacienteId { get; set; }
}