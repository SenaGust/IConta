using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class Conta: IConta
    {
        static int contador = 0;

        public string NConta { get; set; }
        protected string nome { get; set; }
        protected bool validade { get; set; }
        protected double saldo { get; set; }
        protected int tipo { get; set; } //10, corrente //20, poupança //30, investimento

        #region Métodos IConta
        public void Saque(double valor)
        {
            saldo -= valor;
        }
        public void Depositar(double valor)
        {
            saldo += valor;
        }
        public virtual double Saldo()
        {
            return 0;
        }
        #endregion
    }
}
