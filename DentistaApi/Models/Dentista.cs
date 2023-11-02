namespace DentistaApi.Models
{
    public class Dentista : User
    {
        // public string? Id { get; set; }
        // public string Nome { get; set; } = "";
        // public string Email { get; set; } = "";
        // public string Login { get; set; } = "";
        // public string Senha { get; set; } = "";
        // public string Telefone { get; set; } = "";
        public ICollection<Consulta> Consultas { get; } = new List<Consulta>();
        public string Cpf { get; set; } = "";
        public DateOnly DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public Especialidade Especialidade { get; set; } = null!;
    }
}