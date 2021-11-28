using System;

namespace DIO.Series
{
    class Program
    {
        //Pega o repositório/lista da classe SereRepositório
        static SerieRepositorio repositorio = new SerieRepositorio(); 

        static void Main(string[] args)
        {
            string opcaoDoUsuario = OpcaoDoUsuario();

            while (opcaoDoUsuario != "X")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "L":
                        //Limpar();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoDoUsuario = OpcaoDoUsuario();
            }
            Console.WriteLine("\nObrigado por utilizar a DIO Séries.\n");
            Console.WriteLine();

        }
        
        private static void ListaSeries()
        {
            Console.WriteLine("\nListando séries\n");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("Série ID {0}: - {1} {2}", serie.retornaId(),
                                                             serie.retornaTitulo(),
                                                             (excluido ? "'Série removida'" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nInserir nova série\n");

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-6.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-6.0
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nEscolha uma das opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Qual o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Qual o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Qual a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID  da série que deseja atualizar: ");
            int serieId = int.Parse(Console.ReadLine());

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-6.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-6.0
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nEscolha o gênero entre uma das opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Qual o título da série? ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Qual o ano de lançamento? ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Qual a descrição da série? ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: serieId,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(serieId, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID  da série que deseja excluir: ");
            int serieId = int.Parse(Console.ReadLine());

            repositorio.Exclui(serieId);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID  da série que deseja visualizar: ");
            int serieId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(serieId);

            Console.WriteLine(serie);
        }

        private static string OpcaoDoUsuario()
        {
            Console.WriteLine("\n+++++++++++++++++++++++++++++");
            Console.WriteLine("     * DIO Séries *");
            Console.WriteLine("  O point do entretenimento.");
            Console.WriteLine("+++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("Informe uma das opção para proseguir:");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries.");
            Console.WriteLine("2 - Inserir nova série.");
            Console.WriteLine("3 - Atualizar série.");
            Console.WriteLine("4 - Excluir série.");
            Console.WriteLine("5 - Visualizaer série.");
            Console.WriteLine("L - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine(opcaoDoUsuario);
            return opcaoDoUsuario;

        }
    }
}
