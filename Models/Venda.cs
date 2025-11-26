using System.ComponentModel.DataAnnotations;

namespace VendasComissoesAPI.Models
{
    public class Venda
    {
        public string Vendedor { get; set; }
        public decimal Valor { get; set; }
        public decimal? Comissao { get; set; }
    }
}
