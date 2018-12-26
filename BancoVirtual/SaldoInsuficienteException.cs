using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoVirtual
{
    public class SaldoInsuficienteException : Exception
    {

        public double Saldo { get; }
        public double Valor { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double saldo, double valor)
            : this("Nao e possivel realizar essa operacao pois o valor do saldo e: " + saldo + " e o valor solicitado e: " + valor)
        {
            Saldo = saldo;
            Valor = valor;

        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }
    }
}
