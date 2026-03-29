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

                        if (op == "1")
                        {
                            Produto.VerProdutos();
                        }
                        else if (op == "2")
                        {
                            Produto.Comprar();

                        }
                        else if (op == "3")
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
                else if (loginFunc != loginFuncCorreto || senhaFunc != senhaFuncCorreta)
                {
                    Console.WriteLine("Login ou senha incorretos. Acesso negado.");
                    continue; // volta para o início do loop principal
                }
                while (true)
                {
                    Console.WriteLine("1 - Cadastrar produto");
                    Console.WriteLine("2 - Editar produtos");
                    Console.WriteLine("3 - Aplicar descontos");
                    Console.WriteLine("4 - Sair");
                    string respostaFunc = Console.ReadLine();

                    if (respostaFunc == "1")
                    {
                        Produto.CadastrarProduto();
                    }
                    else if (respostaFunc == "2")
                    {
                        Produto.EditarProduto();
                    }
                    else if (respostaFunc == "3")
                    {
                        Produto.AplicarDesconto();
                    }
                    else if (respostaFunc == "4")
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

    public static void EditarProduto()
    {
        Console.WriteLine("Digite o nome do produto que deseja alterar:");
        string nomebusca = Console.ReadLine();

        bool encontrou = false;

        foreach (var p in Program.produtos)
        {
            if (p.Nome == nomebusca)
            {
                encontrou = true;

                Console.WriteLine("Digite o novo nome do produto:");
                p.Nome = Console.ReadLine();

                Console.WriteLine("Digite o novo preço do produto:");
                p.Preco = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite a nova quantidade em estoque:");
                p.Estoque = int.Parse(Console.ReadLine());

                Console.WriteLine("Produto atualizado com sucesso!");

                break; // para não continuar procurando
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    public static void VerProdutos()
    {
        Console.WriteLine("=== LISTA DE PRODUTOS ===");
        foreach (var p in Program.produtos)
        {
            Console.WriteLine($"Nome: {p.Nome} | Preço: {p.Preco} | Estoque: {p.Estoque}");
        }
        if (Program.produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }
    }
    public static void Comprar()
    {
        int i = 1;

        foreach (var p in Program.produtos)
        {
            Console.WriteLine($"{i} - {p.Nome} | R${p.Preco} | Estoque: {p.Estoque}");
            i++;
        }

        int escolha = int.Parse(Console.ReadLine());

        if (escolha < 1 || escolha > Program.produtos.Count)
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        Produto selecionado = Program.produtos[escolha - 1];

        Console.WriteLine($"Você escolheu: {selecionado.Nome}");

        Console.WriteLine("Digite a quantidade que deseja comprar:");
        int quantidade = int.Parse(Console.ReadLine());
        
        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida.");
            return;
        }

        if (quantidade > selecionado.Estoque)
        {
            Console.WriteLine("Desculpe, não temos essa quantidade em estoque.");
        }
        else
        {
            double total = quantidade * selecionado.Preco;
            Console.WriteLine($"O total da compra é: R${total}");
            selecionado.Estoque -= quantidade;
            Console.WriteLine("Compra realizada com sucesso!");
        }

    }
    public static void AplicarDesconto()
    {
        Console.WriteLine("Digite o nome do produto para aplicar desconto:");
        string nomebusca = Console.ReadLine();

        foreach (var p in Program.produtos)
        {
            if (p.Nome == nomebusca)
            {
                Console.WriteLine("Digite a porcentagem de desconto (ex: 10 para 10%):");
                double desconto = double.Parse(Console.ReadLine());

                p.Preco -= p.Preco * (desconto / 100);

                Console.WriteLine($"Desconto aplicado! Novo preço: {p.Preco}");
                return;
            }
        }

        Console.WriteLine("Produto não encontrado.");
    }
}
#endregion
