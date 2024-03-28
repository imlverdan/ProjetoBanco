using System;

namespace ProjetoBanco
{
    public class Conta : IContaCorrente, IContaPoupanca
    {
        private int ContaId { get; set; }
        public string NumeroConta { get; set; }

        private decimal _saldoConta;
        public decimal SaldoConta => _saldoConta;
        
        
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
            ((IContaCorrente)this).TaxaManutencao = 10;
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
            decimal taxaManutencao = 10;
            decimal taxaAdicionalPoupanca = 5; 

            if (quantia <= 0)
            {
                throw new ArgumentException("O valor da quantia a transferir deve ser maior que zero.");
            }

            if (Tipo == TipoConta.ContaCorrente)
            {
                if (quantia + taxaManutencao > _saldoConta)
                {
                    throw new InvalidOperationException("Saldo insuficiente para realizar a transferência incluindo a taxa de manutenção.");
                }

                _saldoConta -= quantia - taxaManutencao;
            }
            else if (Tipo == TipoConta.ContaPoupanca)
            {
                if (quantia + taxaAdicionalPoupanca > _saldoConta)
                {
                    throw new InvalidOperationException("Saldo insuficiente para realizar a transferência incluindo a taxa adicional.");
                }

                _saldoConta -= quantia + taxaAdicionalPoupanca;
            }


        }


        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }

            _saldoConta += valor;

        }

        public decimal DescontarTaxa(decimal taxaManutencao)
        {
            
                    if (SaldoConta >= taxaManutencao)
                    {
                        _saldoConta -= taxaManutencao;
                        
                        return taxaManutencao;
                    }
                    else
                    {
                        throw new InvalidOperationException("Saldo insuficiente para descontar a taxa de manutenção.");
                    }
                
                
        }


        public void AcrescentarRendimento()
        {
            decimal rendimento = SaldoConta * ((IContaPoupanca)this).TaxaRendimento;
            _saldoConta += rendimento;

        }

    }
}