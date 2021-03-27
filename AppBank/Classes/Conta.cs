using AppBank.Enum;
using System;

namespace AppBank.Classes
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double credito, double saldo, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito - 1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Tipo Conta " + this.TipoConta;
            return retorno;
        }
    }
}
