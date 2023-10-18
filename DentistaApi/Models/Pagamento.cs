namespace DentistaApi.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public string FormaDePagamento { get; set; } = "";
        public bool Pago { get; set; }
        public DateOnly DataDoPagamento { get; set; }
        public ICollection<Usuario> Clientes { get; set; } = new List<Usuario>();
    }
}