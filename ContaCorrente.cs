﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoBanco
{
    public interface IContaCorrente
    {
        decimal TaxaManutencao { get; set; }
        decimal SaldoConta { get;  } 

    }
}
