using System;


namespace ProjetoBanco
{
    public interface IContaPoupanca
    {
        public decimal TaxaRendimento { get; set; }
        decimal SaldoConta { get;  } 
        void AcrescentarRendimento();
        
    }
}
