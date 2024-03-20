using System;

namespace ProjetoBanco
{
    public class Conta : IContaCorrente, IContaPoupanca
    {
        private int ContaId { get; set; }
        public string NumeroConta { get; set; }

        private decimal _saldoConta;
        public decimal SaldoConta => _saldoConta;
        private DateTime UltimoDescontoTaxa { get; set; }
        private decimal _rendimentoDiario;
        public TipoConta Tipo { get; set; }
        decimal IContaCorrente.TaxaManutencao { get; set; }
        decimal IContaPoupanca.TaxaRendimento { get; set; }


        private static readonly Random rand = new Random();

        public Conta(TipoConta tipoConta)
        {
            Tipo = tipoConta;
            ContaId = GerarIdAleatorio();
            NumeroConta = GerarNumeroContaAleatorio();
            _saldoConta = 0;
            UltimoDescontoTaxa = DateTime.Today;
            _rendimentoDiario = 0;
        }

        private string GerarNumeroContaAleatorio()
        {
            string numeroConta = "";

            for (int i = 0; i < 6; i++)
            {
                numeroConta += rand.Next(0, 10);
            }

            return numeroConta;
        }

        private int GerarIdAleatorio()
        {
            return rand.Next(100000, 999999);
        }

        public void Transferir(decimal quantia)
        {

            _saldoConta -= quantia - quantia;

        }


        public void Depositar(decimal valor)
        {
            _saldoConta += valor;

        }

        public decimal DescontarTaxa(decimal taxaManutencao)
        {
            try
            {
                if (DateTime.Today >= UltimoDescontoTaxa.AddDays(30))
                {
                    if (SaldoConta >= taxaManutencao)
                    {
                        _saldoConta -= taxaManutencao;
                        UltimoDescontoTaxa = DateTime.Today;
                        return taxaManutencao;
                    }
                    else
                    {
                        throw new InvalidOperationException("Saldo insuficiente para descontar a taxa de manutenção.");
                    }
                }
                else
                {
                    Console.WriteLine("Ainda não se passaram 30 dias desde o último desconto de taxa.");
                    return 0;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


        public void AcrescentarRendimento()
        {
            decimal rendimento = SaldoConta * ((IContaPoupanca)this).TaxaRendimento;
            _saldoConta += rendimento;

        }

    }
}