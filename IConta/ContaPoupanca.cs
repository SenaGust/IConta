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

        public ContaPoupanca(string nome, string NConta, double saldo)
        {
            base.Saldo = saldo;
            base.nome = nome;
            base.NConta = NConta;
            base.tipo = "20";

            Conta.contador++;
        }

        public override double SaldoA()
        {
            base.Saldo += Saldo * aliquotaRendimento ;

            return base.Saldo;
        }
    }
}
