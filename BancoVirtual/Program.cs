using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoVirtual
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                ContaCorrente contaMateus = new ContaCorrente(123, 2323124);
                ContaCorrente contaMarcos = new ContaCorrente(312, 3213213);

                
                contaMateus.Titular = "Mateus";
                contaMarcos.Titular = "Marcos";

                contaMateus.Depositar(-500);
                contaMateus.Sacar(20);
                contaMateus.Transferencia(50, contaMarcos);
                contaMarcos.Depositar(30);

                Console.WriteLine(contaMateus.Titular);
                Console.WriteLine(contaMateus.Saldo);
                Console.WriteLine(contaMarcos.Titular);
                Console.WriteLine(contaMarcos.Saldo);
            }
            catch(ArgumentException e)
            {
                if(e.ParamName == "valor")
                {
                    Console.WriteLine("Excecao do tipo ArgumentException valor");
                    Console.WriteLine(e.Message);
                }
                if (e.ParamName == "numero")
                {
                    Console.WriteLine("Excecao do tipo ArgumentException numero");
                    Console.WriteLine(e.Message);
                }
                if (e.ParamName == "agencia")
                {
                    Console.WriteLine("Excecao do tipo ArgumentException agencia");
                    Console.WriteLine(e.Message);
                }
            }

            catch(SaldoInsuficienteException e)
            {
                Console.WriteLine("Excecao do tipo SaldoInsuficienteException");
                Console.WriteLine(e.Message);
            }

            catch(Exception e)
            {
                Console.WriteLine("Excecao do tipo Exception");
                Console.WriteLine(e.Message);
            }


            

            Console.ReadLine();
        }
    }
}
