namespace DentistaApi.Models
{
    public class Consulta
    {
        public string? ConsultaId { get; set; }
        public string ProcedimentoConsulta { get; set; } = "";
        public DateOnly DataConsulta { get; set; }
        public TimeOnly HoraConsulta { get; set; }
        public TimeOnly TempoPrevisto { get; set; }
        public string? PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public string? DentistaId { get; set; }
        public Dentista Dentista { get; set; } = null!;
        public string? PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; } = null!;

    }
}