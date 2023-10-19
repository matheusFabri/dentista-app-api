namespace DentistaApi.Models
{
    public class Pagamento
    {
        public string? PagamentoId { get; set; }
        public double ValorTotal { get; set; }
        public string FormaDePagamento { get; set; } = "";
        public bool Pago { get; set; }
        public DateOnly DataDoPagamento { get; set; }
    }
}