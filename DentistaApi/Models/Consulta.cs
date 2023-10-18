namespace DentistaApi.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string ProcedimentoConsulta { get; set; } = "";
        public DateOnly DataConsulta { get; set; }
        public TimeOnly HoraConsulta { get; set; }
        public TimeOnly TempoPrevisto { get; set; }
        public Usuario? Cliente { get; set; }
        public Dentista? Dentista { get; set; }
        public Especialidade? Especialidade { get; set; }
        public Pagamento? Pagamento { get; set; }

    }
}