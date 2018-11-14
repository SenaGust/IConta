using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class ContaInvestimento: Conta
    {
        const double aliquotaRendimento = 0.04;
        const double aliquotaImposto = 0.1; //aplicado sob o rendimento

        public ContaInvestimento(string nome, string NConta, double saldo)
        {
            base.Saldo = saldo;
            base.nome = nome;
            base.NConta = NConta;
            base.tipo = "30";

            Conta.contador++;
        }

        public override double calculaRendimento()
        {
            double imposto = base.Saldo * aliquotaRendimento * aliquotaImposto;
            base.Saldo += base.Saldo * aliquotaRendimento - imposto;

            return base.Saldo;
        }
    }
}
