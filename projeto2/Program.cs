using System;
using projeto2.Models;
using projeto2.Service;

namespace projeto2
{
    public class Program : ContaCorrenteService
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta()
            {
                Agencia = 8793,
                Titular = "Maísa",
                Numero = 36999,
                Saldo = 4000.00,
                Senha = "123456M"
            };
            Conta conta2 = new Conta()
            {
                Agencia = 8792,
                Titular = "Jéssica",
                Numero = 36921,
                Saldo = 5000.00,
                Senha = "12345j"
            };
            Console.WriteLine("Olá, Qual operação gostaria de realizar? (Digite Sacar, para Saque; Transferir, para transferência; e Depositar, para depósito.");
            string operacao = Console.ReadLine();
            if(operacao == "Sacar")
            {
                Sacar(conta1);
            }
            if (operacao == "Transferir")
            {
                Transferir(conta1, conta2);
            }
            if(operacao == "Depositar")
            {
                Depositar(conta1);
            }

        }
    }
}
