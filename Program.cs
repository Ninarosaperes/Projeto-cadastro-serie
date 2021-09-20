using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepositorio catalogo = new SeriesRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            Console.WriteLine("   Bem vindo(a) à Emmyflix!");
            Console.WriteLine("O streaming de séries premiadas.");
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigada pela sua visita!");
            Console.WriteLine("       Até logo!         ");
            Console.WriteLine("");
        }
        private static void ListarSeries()
        {
            int opcaoListagem = ObterOpcaoListagem();
            var lista = catalogo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            while (opcaoListagem != 0)
            {
                switch(opcaoListagem)
                {
                    case 1:
                        Console.WriteLine("Listar séries premiadas:"); 
                        Console.WriteLine("");
                        foreach (var serie in lista)
                        {
                            if (serie.retornaPremio() != 0)
                            {
                                Console.WriteLine("#Id {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as séries:"); 
                        Console.WriteLine("");
                        foreach (var serie in lista)
                        {
                            Console.WriteLine("#Id {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoListagem = ObterOpcaoListagem();
            }
        }
        
        private static void InserirSerie()
        {
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite o gênero da série de acordo com as opções abaixo: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite a premiação da série de acordo com as opções abaixo: ");
            
            foreach (int j in Enum.GetValues(typeof(Premio)))
            {
                Console.WriteLine("{0} - {1}", j, Enum.GetName(typeof(Premio), j));
            }
            int entradaPremio = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Serie novaSerie = new Serie (id: catalogo.ProximoId(),
                                        titulo: entradaTitulo,
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        premio: (Premio)entradaPremio);
            
            catalogo.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série que você deseja atualizar:");
            int idSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite o gênero da série de acordo com as opções abaixo: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescrcao = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite a premiação da série de acordo com as opções abaixo: ");
            
            foreach (int j in Enum.GetValues(typeof(Premio)))
            {
                Console.WriteLine("{0} - {1}", j, Enum.GetName(typeof(Premio), j));
            }
            int entradaPremio = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Serie atualizaSerie = new Serie (id: idSerie,
                                        titulo: entradaTitulo,
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        descricao: entradaDescrcao,
                                        premio: (Premio)entradaPremio);
            
            catalogo.Atualiza(idSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série que você deseja excluir:");
            int idSerie = int.Parse(Console.ReadLine());
            var lista = catalogo.Lista();
            Console.WriteLine("Você realmente deseja excluir a série?");
            Console.WriteLine("Digite S para SIM ou N para NÃO.");
            string opcaoExcluir = Console.ReadLine().ToUpper();
            if (opcaoExcluir == "S")
            {
                lista.RemoveAt(idSerie);
                Console.WriteLine("Série excluída com sucesso!");
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série que você deseja visualizar:");
            int idSerie = int.Parse(Console.ReadLine());
            var serie = catalogo.RetornaPorId(idSerie);
            Console.WriteLine("");
            Console.WriteLine(serie);
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Listar séries ");
            Console.WriteLine("2 - Inserir nova série ");
            Console.WriteLine("3 - Atualizar uma série ");
            Console.WriteLine("4 - Excluir série ");
            Console.WriteLine("5 - Visualizar série ");
            Console.WriteLine("L - Limpar tela ");
            Console.WriteLine("X - Sair ");
            Console.WriteLine(" ");
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine(" ");
            return opcaoUsuario;

        }
        public static int ObterOpcaoListagem()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Digite a opção de listagem desejada: ");
            Console.WriteLine("0 - Retornar ao menu anterior ");
            Console.WriteLine("1 - Apenas as séries premiadas; ");
            Console.WriteLine("2 - Todas as séries ");
            Console.WriteLine(" ");
            
            int opcaoListagem = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            return opcaoListagem;

        }
    }
}