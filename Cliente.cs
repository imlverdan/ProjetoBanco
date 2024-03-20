using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public class Cliente
    {
        private int ID;
        private string CPF;
        private string Nome;
        private DateTime Nascimento;
        public TipoCliente Tipo { get; set; }
        public Conta Conta { get; set; }
        private static readonly Random rand = new Random();


        private int IdAleatorio()
        {
            return rand.Next(100000, 999999);
        }
        public string CpfCliente
        {
            get { return CPF; }
            set { CPF = value; }
        }

        public string NomeCliente
        {
            get { return Nome; }
            set { Nome = value; }

        }
        public DateTime DataNascimento
        {
            get { return Nascimento; }
            set { Nascimento = value; }
        }

       

        
        public void AtualizarTipoCliente()
        {
            if (Conta.SaldoConta >= 15000)
            {
                Tipo = TipoCliente.Premium;
            }
            else if (Conta.SaldoConta >= 5000)
            {
                Tipo = TipoCliente.Super;
            }
            else
            {
                Tipo = TipoCliente.Comum;
            }
        }
    }
}


