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
        public static int contaMes = 1;
        public string NConta { get; protected set; }
        public string nome { get; protected set; }
        public string tipo { get; protected set; } //10, corrente //20, poupança //30, investimento

        private double saldo;
        public double Saldo
        {
            get { return Math.Round(saldo,2); }
            set { saldo = value; }
        }

        #region Métodos IConta
        public void Saque(double valor)
        {
            Saldo -= valor;
        }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public virtual double SaldoA()
        {
            return 0;
        }
        #endregion
    }
}
