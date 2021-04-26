using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta
        {
            get; set;
        }
        private double Saldo
        {
            get; set;
        }
        private double Credito
        {
            get; set;
        }
        private string Nome
        {
            get; set;
        }
        public Conta(TipoConta tipoconta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorsaque)
        {
            if (this.Saldo - valorsaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            else
            {
                this.Saldo -= valorsaque;
                Console.WriteLine();
                Console.WriteLine("Saldo atual da conta de " + this.Nome + " é de: " + this.Saldo.ToString("C"));
                return true;
            }

        }
        public void Depositar(double valordeposito)
        {

            this.Saldo += valordeposito;
            Console.WriteLine();
            Console.WriteLine("Saldo atual da conta de " + this.Nome + " é de: " + this.Saldo.ToString("C"));
        }
        public void Transferencia(double valortransferencia, Conta contadestino)
        {
            if (this.Sacar(valortransferencia))
            {
                contadestino.Depositar(valortransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo.ToString("C") + " | ";
            retorno += "Crédito: " + this.Credito.ToString("C") + " | ";
            return retorno;
        }
    }
}
