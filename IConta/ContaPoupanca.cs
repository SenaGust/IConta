using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class ContaPoupanca: Conta
    {
        const double aliquotaRendimento = 0.04;

        public override double Saldo()
        {
            base.saldo *= aliquotaRendimento;

            return base.saldo;
        }
    }
}
