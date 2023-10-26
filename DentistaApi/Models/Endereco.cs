namespace DentistaApi.Models;

public class Endereco
{
    public string? Id { get; set; }
    public string Rua { get; set; } = "";
    public string Bairro { get; set; } = "";
    public string Cidade { get; set; } = "";
    public string Cep { get; set; } = "";
    public string Numero { get; set; } = "";
    public string Complemento { get; set; } = "";
    public string Referencia { get; set; } = "";
    public string PacienteId { get; set; } = "";
    public Paciente Paciente { get; set; } = null!;
}