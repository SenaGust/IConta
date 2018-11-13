using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    class Conta : IConta
    {
        public static int contador = 0;

        public string NConta { get; protected set; }
        public string nome { get; protected set; }
        public bool validade { get; protected set; }
        public double saldo { get; protected set; }
        public string tipo { get; protected set; } //10, corrente //20, poupança //30, investimento

        
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
