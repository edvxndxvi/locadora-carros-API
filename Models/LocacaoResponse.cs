namespace LocadoraCarros.Models
{
    public class LocacaoResponse
    {
        public string Carro { get; set; }
        public string Marca { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public double ValorDiaria { get; set; }
        public double Subtotal { get; set; }
        public string Desconto { get; set; }
        public double ValorFinal { get; set; }

        public LocacaoResponse() { }

        public LocacaoResponse(string carro, string marca, string DataInicio, string DataFim, double ValorDiaria, double Subtotal, string Desconto, double ValorFinal)
        {
            this.Carro = carro;
            this.Marca = marca;
            this.DataInicio = DataInicio;
            this.DataFim = DataFim;
            this.ValorDiaria = ValorDiaria;
            this.Subtotal = Subtotal;
            this.Desconto = Desconto;
            this.ValorFinal = ValorFinal;
        }
    }
}
