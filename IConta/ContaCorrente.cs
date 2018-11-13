using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class ContaCorrente: Conta
    {
        public ContaCorrente(string nome, string NConta, double saldo)
        {
            base.validade = true;
            base.saldo = saldo;
            base.nome = nome;
            base.NConta = NConta;
            base.tipo = "10";

            Conta.contador++;
        }


        public override double Saldo()
        {
            return base.saldo;
        }
    }
}
