﻿using System;
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
            base.validade = true;
            base.saldo = saldo;
            base.nome = nome;
            base.NConta = NConta;
            base.tipo = "30";

            Conta.contador++;
        }

        public override double Saldo()
        {
            double imposto = base.saldo * aliquotaRendimento * aliquotaImposto;
            base.saldo += base.saldo * aliquotaRendimento - imposto;

            return base.saldo;
        }
    }
}
