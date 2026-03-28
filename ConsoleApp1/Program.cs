// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

#region Program & Main
class Program
{
    // LISTA (banco de dados em memória)
    public static List<Cliente> clientes = new List<Cliente>();
    public static List<Produto> produtos = new List<Produto>();
    
    static void Main()
    {
       string loginFuncCorreto = "admin";
       string senhaFuncCorreta = "1234";

        while (true)
        {
            Console.WriteLine("=== SISTEMA DE SUPERMERCADO ===");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Sou funcionario");
            Console.WriteLine("4 - Sair");
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
                Console.WriteLine("Digite o login do funcionário:");
                string loginFunc = Console.ReadLine();
                Console.WriteLine("Digite a senha do funcionário:");
                string senhaFunc = Console.ReadLine();

                if (loginFunc == loginFuncCorreto && senhaFunc == senhaFuncCorreta)
                {
                    Console.WriteLine("Login de funcionário realizado com sucesso!");
                }
                while (true)
                {
                  



                }
            }
            else if (resposta == "4")
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

        #endregion
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

#region Product class
class Produto
{
    public string Nome;
    public double Preco;
    public int Estoque;

    public Produto(string nome, double preco, int estoque)
    {
        this.Nome = nome;
        this.Preco = preco;
        this.Estoque = estoque;
    }
    public static void CadastrarProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o preço do produto:");
        double preco = double.Parse(Console.ReadLine());
        Console.WriteLine("Digite a quantidade em estoque:");
        int estoque = int.Parse(Console.ReadLine());
        Produto novoproduto = new Produto(nome, preco, estoque);

        Program.produtos.Add(novoproduto);

        Console.WriteLine($"Produto {nome} cadastrado com sucesso!");
    }
    #endregion
}
