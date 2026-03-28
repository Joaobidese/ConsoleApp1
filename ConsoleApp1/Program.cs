// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Program
{
    // LISTA (banco de dados em memória)
    public static List<Cliente> clientes = new List<Cliente>();
    

    static void Main()
    {
       
        while (true)
        {
            Console.WriteLine("=== SISTEMA DE SUPERMERCADO ===");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Sair");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                Cliente.Cadastrar();
            }
            else if (resposta == "2")
            {
                Cliente clienteLogado = Cliente.LoginCliente();
                if (clienteLogado != null)
                {
                    Console.WriteLine($"Bem-vindo, {clienteLogado.Nome}!");

                    // MENU DO CLIENTE
                    while (true)
                    {
                        Console.WriteLine("1 - Ver produtos");
                        Console.WriteLine("2 - Comprar");
                        Console.WriteLine("3 - Sair");

                        string op = Console.ReadLine();

                        if (op == "3")
                            break;
                    }
                }
            }
            else if (resposta == "3")
            {
                Console.WriteLine("Saindo do sistema...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine(); // espaço visual
        }
     

    }

}
#region Client class
class Cliente
{
    public string Nome;
    public string Email;
    public string Senha;

    public Cliente(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
    }

    public static void Cadastrar()
    {
        Console.WriteLine("Digite o nome do cliente:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o email do cliente:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite a senha do cliente:");
        string senha = Console.ReadLine();

        Cliente novo = new Cliente(nome, email, senha);

        Program.clientes.Add(novo);

        Console.WriteLine($"Cliente {nome} cadastrado com sucesso!");
    }

    public static Cliente LoginCliente()
    {
        Console.WriteLine("Digite o email do cliente:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite a senha do cliente:");
        string senha = Console.ReadLine();

        foreach (var c in Program.clientes)
        {
            if (c.Email == email && c.Senha == senha)
            {
                Console.WriteLine("Login realizado com sucesso!");
                return c;
            }
        }

        Console.WriteLine("Email ou senha incorretos.");
        return null;

      
    }
    #endregion
}


