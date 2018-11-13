using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IConta
{
    class Conta: IConta
    {
        static int contador;

        public string NConta { get; set; }
        protected string nome { get; set; }
        protected bool validade { get; set; }
        protected double saldo { get; set; }
        
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
