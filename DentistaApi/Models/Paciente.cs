using System;

namespace DentistaApi.Models
{
	public class Paciente
	{
		public string? Id { get; set; }
		public string Nome { get; set; } = "";
		public string Email { get; set; } = "";
		public string Login { get; set; } = "";
		public string Senha { get; set; } = "";
		public string Cpf { get; set; } = "";
		public string Telefone { get; set; } = "";
		public DateOnly DataCadastro { get; set; }
		public Endereco? Endereco { get; set; }
		public Anamnese? Anamnese { get; set; }
		public Responsavel? Responsavel { get; set; }
		public ICollection<Consulta> Consultas { get; } = new List<Consulta>();

	}
}