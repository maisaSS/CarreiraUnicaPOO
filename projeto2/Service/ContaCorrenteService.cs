using System;
using System.Collections.Generic;
using System.Text;
using projeto2.Models;

namespace projeto2.Service
{
    public class ContaCorrenteService
    {
        public static void MensagemDeSucesso()
        {
            Console.WriteLine("Operação realizada com sucesso!");
        }

        public static void MensagemDeErro()
        {
            Console.WriteLine("Falha na operação!");
        }


        static int AutorizacaoDeAcesso(Conta conta)
        {
            int retorno;
            int tentativas = 0;
            string senha;
            do
            {
                Console.WriteLine("Digite a sua senha");
                senha = Console.ReadLine();
                if (senha == conta.Senha)
                {
                    tentativas = 4;
                    retorno = 0;
                }
                else
                {
                    tentativas++;
                    retorno = 1;
                    Console.WriteLine("Senha Incorreta");

                }
            } while (tentativas < 3);

            if (retorno == 1)
            {
                Console.WriteLine("Voce ultrapassou o limite de tentativas! Tente novamente mais tarde!");
            }
            else
            {
                Console.WriteLine("Acesso Liberado.");
            }
            return (retorno);
        }

        public static void MostrarTudo(Conta conta)
        {
            var autorizacao = AutorizacaoDeAcesso(conta);
            if (autorizacao == 0)
            {
                Console.WriteLine(conta.Titular + ", os dados da sua conta são: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Número: " + conta.Numero + " | Agência: " + conta.Agencia);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Saldo atual: " + conta.Saldo);
            }
        }

        public static void Sacar(Conta conta)
        {
            var autorizacao = AutorizacaoDeAcesso(conta);
            if (autorizacao == 0)
            {
                Console.WriteLine("Qual valor deseja sacar?");
                double ValorDeSaque = Convert.ToDouble(Console.ReadLine());
                if (ValorDeSaque >= conta.Saldo)
                {
                    MensagemDeErro();
                    Console.WriteLine("Saldo insuficiente. O seu saldo é de " + conta.Saldo);
                }
                else
                {
                    MensagemDeSucesso();
                    conta.Saldo = (conta.Saldo) - ValorDeSaque;

                    //Mostrar dados da conta:
                    Console.WriteLine(conta.Titular + ", os dados da sua conta são: ");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Número: " + conta.Numero + " | Agência: " + conta.Agencia);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Saldo: " + conta.Saldo);
                }
            }
        }

        public static void Transferir(Conta contaAtual, Conta contaDestino)
        {
            var autorizacao = AutorizacaoDeAcesso(contaAtual);
            if (autorizacao == 0)
            {
                Console.WriteLine("Qual valor deseja Tranferir?");
                double ValorDeTransferencia = Convert.ToDouble(Console.ReadLine());
                if (ValorDeTransferencia >= contaAtual.Saldo)
                {
                    MensagemDeErro();
                    Console.WriteLine("Saldo insuficiente. O seu saldo é de " + contaAtual.Saldo);
                }
                else
                {
                    MensagemDeSucesso();
                    contaAtual.Saldo = contaAtual.Saldo - ValorDeTransferencia;
                    Console.WriteLine("Transação finalizada para a conta de número " + contaDestino.Numero + ", da Agência " + contaDestino.Agencia);
                }
            }
        }

        public static void Depositar(Conta conta)
        {
            var autorizacao = AutorizacaoDeAcesso(conta);
            if (autorizacao == 0)
            {
                Console.WriteLine("Qual valor deseja Depositar?");
                double ValorDeDeposito = Convert.ToDouble(Console.ReadLine());
                MensagemDeSucesso();
                conta.Saldo = conta.Saldo + ValorDeDeposito;

                //Mostrar dados da conta:
                Console.WriteLine(conta.Titular + ", os dados da sua conta são: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Número: " + conta.Numero + " | Agência: " + conta.Agencia);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Saldo: " + conta.Saldo);

            }
        }
    }
}
