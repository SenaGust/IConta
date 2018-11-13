using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IConta
{
    class ContaCorrente: Conta
    {
        public override double Saldo()
        {
            return base.saldo;
        }
    }
}
