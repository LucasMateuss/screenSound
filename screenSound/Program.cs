using System.Runtime.CompilerServices;

string mensagemBoasVindas = "\nBem vindo ao Screen Sound";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Charlie Brown Jr.", new List<int> { 10, 9, 9 });
bandasRegistradas.Add("U2", new List<int>());


void exibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemBoasVindas);
}


void exibirOpcoesMenu()
{
    exibirLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            registrarBanda();
            break;
        case 2:
            mostrarBandas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            mostraMediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau tchau");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}


void registrarBanda()
{
    Console.Clear();

    exibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    exibirOpcoesMenu();
}


void mostrarBandas()
{
    Console.Clear();

    exibirTituloDaOpcao("Exibindo todas as bandas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.Write("\nDigite uma tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    exibirOpcoesMenu();
}


void exibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}


void avaliarBanda()
{
    Console.Clear();
    exibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nQual a nota que a {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine());
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.Write($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        exibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.Write("\nDigite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoesMenu();
    }
}


void mostraMediaDaBanda()
{
    Console.Clear();
    exibirTituloDaOpcao("Mostrar a média de notas de uma banda");
    Console.Write("Digite o nome da banda que deseja mostrar a média: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        if (notasDaBanda.Count > 0)
        {
            double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();
            Console.WriteLine($"\nA média de notas da banda {nomeDaBanda} é {mediaDaBanda}");
            Console.Write("\nDigite uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoesMenu();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não possui notas");
            Console.Write("\nDigite uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoesMenu();
        }

    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.Write("\nDigite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoesMenu();
    }
}


exibirOpcoesMenu();

