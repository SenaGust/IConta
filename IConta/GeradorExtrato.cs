using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class GeradorExtrato
    {
        public string GeraExtrato(Conta a)
        {
            string extrato = "\tExtrato da Conta";



            extrato += "\nNúmero da Conta: " + a.NConta;

            extrato += "\nTipo da Conta: ";
            if (a.tipo == "10")
                extrato += "Conta Corrente";
            if (a.tipo == "20")
                extrato += "Conta Poupança";
            if (a.tipo == "30")
                extrato += "Conta Investimento";


            extrato += "\nSaldo: " + a.Saldo;

            return extrato;
        }
    }
}
