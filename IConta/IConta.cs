using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    interface IConta
    {
        void Depositar(double valor);
        void Saque(double valor);
        double calculaRendimento();
    }
}
