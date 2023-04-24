using DIO.Bank.Conta;
using DIO.Bank.Enum;
using System.Collections.Generic;

class Program
{
    static List<Conta> listContas=new List<Conta>();
    static void Main(string[] args)
    {        
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper()!="X")
        {
            switch (opcaoUsuario)
        {
            case"1":
                ListarContas();
                break;
            case"2":
                InserirConta();
                break;
            case"3":
                Transferir();
                break;
            case"4":
                Sacar();
                break;
            case"5":
                Depositar();
                    break;
                case"C":
                Console.Clear();
                break;
                
            default:
                throw new ArgumentOutOfRangeException();

        }
        opcaoUsuario = ObterOpcaoUsuario();        
    }
     System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
     Console.ReadLine();
    }

    private static void Transferir()
    {
        Console.WriteLine("Digite o número da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o número da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser transferido: ");
        double valorTranferencia = double.Parse(Console.ReadLine());

        listContas[indiceContaOrigem].Transferir(valorTranferencia, listContas[indiceContaDestino]);
    }

    private static void Sacar()
    {
        System.Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(System.Console.ReadLine());
        Console.Write("Digite o valor a ser sacado :");
        double valorSaque = double.Parse(System.Console.ReadLine());

        listContas[indiceConta].Sacar(valorSaque);
    }
     private static void Depositar()
    {
        System.Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(System.Console.ReadLine());
        Console.Write("Digite o valor a ser depósito :");
        double valorDeposito = double.Parse(System.Console.ReadLine());

        listContas[indiceConta].Sacar(valorDeposito);
    }

    private static void ListarContas()
    {
        System.Console.WriteLine("Listar Contas");
        if(listContas.Count==0)
        {
            System.Console.WriteLine("Nenhuma conta cadastrada");
            return;
        }
        for(int i=0; i<listContas.Count; i++)
        {
            Conta conta = listContas[i];
             Console.Write("#{0} - ",i);
            Console.WriteLine(conta);
        }
    }

    private static void InserirConta()
    {
        Console.WriteLine("Inserir nova conta");
        Console.Write("Digite 1 para conta Fisica ou 2 para Juridica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());
        Console.Write("Digite o nome do cliente: ");
        string entradaNome = Console.ReadLine();
        Console.Write("Digite o saldo inicial: ");
        double entradaSaldo = double.Parse(Console.ReadLine());
        Console.Write("Digite o crédito: ");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
        saldo: entradaSaldo,
        credito: entradaCredito,
        nome: entradaNome);
        listContas.Add(novaConta);
    }

    private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Giga Bank a seu dispor!!");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1- Listar Contas");
            System.Console.WriteLine("2- Inserir nova conta");
            System.Console.WriteLine("3- Transferir");
            System.Console.WriteLine("4- Sacar");
            System.Console.WriteLine("5- Depositar");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }

