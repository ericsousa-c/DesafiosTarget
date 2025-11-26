using VendasComissoesAPI.Models;

namespace VendasComissoesAPI.Services
{
    public class ComissaoService
    {
        public decimal CalcularComissao(decimal valor)
        {
            decimal comissao;

            if (valor < 100)
            {
                comissao = 0;
            }
            else if (valor < 500)
            {
                comissao = valor * 0.01m;
            }
            else
            {
                comissao = valor * 0.05m;
            }

            return decimal.Round(comissao, 2);
        }
    }
}
