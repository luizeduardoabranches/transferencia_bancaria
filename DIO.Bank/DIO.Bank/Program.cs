using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listacontas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaousuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta física ou digite 2 para conta jurídica: ");
            int entradaTipoconta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoconta: (TipoConta)entradaTipoconta, nome: entradaNome, saldo: entradaSaldo, credito: entradaCredito);
            listacontas.Add(novaConta);      
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceconta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorsaque = double.Parse(Console.ReadLine());

            listacontas[(indiceconta - 1)].Sacar(valorsaque);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceconta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valordeposito = double.Parse(Console.ReadLine());

            listacontas[(indiceconta - 1)].Depositar(valordeposito);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listacontas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi cadastrada.");
                return;
            }
            else
            {
                for (int i = 0; i < listacontas.Count; i++)
                {
                    Conta conta = listacontas[i];
                    Console.WriteLine();
                    Console.Write("#" +(i + 1) +" - ");
                    Console.Write(conta);
                    Console.WriteLine();
                }
            }
        }
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            indiceContaOrigem = indiceContaOrigem - 1;

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            indiceContaDestino = indiceContaDestino - 1;

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferência = double.Parse(Console.ReadLine());

            listacontas[indiceContaOrigem].Transferencia(valorTransferência, listacontas[indiceContaDestino]);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor !");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
