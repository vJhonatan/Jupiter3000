using System.Collections.Generic;
using System.Threading;
using System;

public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();
    static string senha = "";

    public static void Main()
    {
        bool produtos = false;
        while (true)
        {

            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.Write("INFORME A SUA SENHA DE ADMINISTRADOR \n\t\t=> ");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar de produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                Console.Write("\n\t=> ");
                int decisao = Convert.ToInt32(Console.ReadLine());
                switch (decisao)
                {
                    case 1:
                        Console.Clear();
                        VenderProdutos();
                        break;
                    case 2:
                        Console.Clear();
                        ListarProdutos();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        AlterarSenha();
                        break;
                    case 4:
                        Console.Clear();
                        FecharCaixa();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\tErro! Digite uma opção válida!");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }

    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }
    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }

    static void ListarProdutos()
    {
        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"Nome produto: {produto.Nome} - Quantidade: {produto.Quantidade}");
        }
    }

    static void VenderProdutos()
    {
        Console.Write("Digite o id do produto: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Digite o quantidade do produto: ");
        int qtd = int.Parse(Console.ReadLine());

        int index = listaProdutos.FindIndex(x => x.Id == id);

        if (index == -1)
        {
            Console.WriteLine("Não encontrado!");
            return;
        }
        else
        {
            int qtd_atual = listaProdutos[index].Quantidade;
            int total_qtd = (qtd < qtd_atual) ? qtd_atual - qtd : qtd;

            listaProdutos[index].Quantidade = total_qtd;
        }

        Thread.Sleep(1000);
    }

    static void AlterarSenha()
    {
        Console.Write("Digite sua senha antiga: ");
        string senha_atual = Console.ReadLine();

        if (senha_atual != senha)
        {
            Console.Clear();
            Console.WriteLine("A senha antiga esta incorreta!");
            Thread.Sleep(2000);
            return;
        }

        Console.Write("Digite a nova senha: ");
        string nova_senha = Console.ReadLine();

        Console.Write("Confirme a nova senha: ");
        string repetir_senha = Console.ReadLine();

        if (nova_senha != repetir_senha)
        {
            Console.Clear();
            Console.WriteLine("As senhas nao coincidem");
            Thread.Sleep(2000);
            return;
        }

        senha = nova_senha;
        Console.Clear();
        Console.WriteLine("\n\tSenha alterada com sucesso!");
        Thread.Sleep(2000);

    }

    static void FecharCaixa()
    {
        Console.Write("-----------------------------");
        Console.Write("Digite sua senha: ");
        string senha_nova = Console.ReadLine();

        if (senha_nova != senha)
        {
            Console.Write("Sua senha está errada, por favor digite corretamente");
            Console.ReadKey();
            return;
        }

        ListarProdutos();

        Thread.Sleep(20000);

        Environment.Exit(0);
    }
}
class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}