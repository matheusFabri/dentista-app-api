namespace DentistaApi.Models
{
    public class Dentista : Usuario
    {
        public string Cpf { get; set; } = "";
        public string Telefone { get; set; } = "";
        public DateOnly DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public Especialidade? Especialidade { get; set; }
    }
}