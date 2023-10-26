namespace DentistaApi.Models
{
    public class Anamnese
    {
        public string? Id { get; set; }
        public string ProblemaSaude { get; set; } = "";
        public string Tratamento { get; set; } = "";
        public string Remedio { get; set; } = "";
        public string Alergia { get; set; } = "";
        public bool SangramentoExcessivo { get; set; }
        public bool Hipertensao { get; set; }
        public bool Gravida { get; set; }
        public bool TraumatismoFace { get; set; }
        public Paciente? Paciente { get; set; }
    }
}