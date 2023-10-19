namespace DentistaApi.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string ProcedimentoConsulta { get; set; } = "";
        public DateOnly DataConsulta { get; set; }
        public TimeOnly HoraConsulta { get; set; }
        public TimeOnly TempoPrevisto { get; set; }
        public Usuario Cliente { get; set; } = null!;
        public Dentista Dentista { get; set; } = null!;
        public Pagamento Pagamento { get; set; } = null!;

    }
}