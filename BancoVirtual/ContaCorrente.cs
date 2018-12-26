using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoVirtual
{
    class ContaCorrente
    {
        public string Titular { get; set; }
        public int CPF { get; }
        public int Numero { get; }
        public int Agencia { get; set; }
        public double Saldo { get; private set; }
        public int ContadorDeSaquesNaoPermitidos { get; private set; }
        public int ContadorDeTranferenciasNaoPermitidas { get; private set; }

        public ContaCorrente(int numero, int agencia)
        {
            Numero = numero;
            Agencia = agencia;

            if (numero <= 0)
            {
                throw new ArgumentException("O numero da conta nao pode ser menor ou igual a 0", nameof(numero));
            }
            if (agencia <= 0)
            {
                throw new ArgumentException("O numero da agencia nao pode ser menor ou igual a 0", nameof(agencia));
            }
        }

        public void Sacar(double valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("O valor informado para saque e invalido.", nameof(valor));
            }

            if(Saldo < valor)
            {
                ContadorDeSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            else
            {
             
                Saldo -= valor;
            }
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor a ser depositado deve ser maior que zero.", nameof(valor));
            }
            else
            {
                Saldo += valor;
            }
        }
        public void Transferencia(double valor, ContaCorrente contaDestino)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("O valor a ser transfirido deve ser maior que zero.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {
                ContadorDeTranferenciasNaoPermitidas++;
                throw;
            }

                
            contaDestino.Depositar(valor);
                
            }
        }
    }
