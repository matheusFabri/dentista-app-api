using System.ComponentModel.DataAnnotations.Schema;

namespace DentistaApi.Models
{
    public class Dentista : User
    {
        [InverseProperty("Dentista")]
        public ICollection<Consulta> Consultas { get; } = new List<Consulta>();
        public DateOnly DataNascimento { get; set; }
        
        public Especialidade? Especialidade { get; set; }

        public void SetRole()
        {
            if (this.Role == null || this.Role == "")
            {
                this.Role = "Dentista";
            }

        }
    }
}