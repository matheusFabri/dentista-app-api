using System;

namespace DentistaApi.Models
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; } = "";
		public string Email { get; set; } = "";
		public string Login { get; set; } = "";
		public string Senha { get; set; } = "";
		public ICollection<Consulta> Consultas { get; } = new List<Consulta>();
	}
}