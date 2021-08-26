using System;
using System.Collections.Generic;

namespace cadastro_de_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Listar Séries:");
                        ListarSeries();
                        break;
                    case "2":
                        Console.WriteLine("Adicionar nova série:");
                        AdicionarSerie();
                        break;
                    case "3":
                        Console.WriteLine("Atualizar série:");
                        AtualizarSerie();
                        break;
                    case "4":
                        Console.WriteLine("Atualizar série:");
                        ExcluirSerie();
                        break;
                    case "5":
                        Console.WriteLine("Visualizar série:");
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            ListarSeries();
            Console.Write("Digite o ID da série que deseja visualizar com mais detalhes: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Serie serie = repositorio.GetPorId(id);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            ListarSeries();
            Console.Write("Digite o ID da série que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            repositorio.Excluir(id);
        }

        private static Serie GetNovaSerie(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine();

            Console.Write("Digite o número do gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            Serie novaSerie = new Serie(id: id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            return novaSerie;
        }
        private static void AtualizarSerie()
        {
            ListarSeries();
            Console.Write("Digite o ID da série para atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Serie novaSerie = GetNovaSerie(id);

            repositorio.Atualizar(id, novaSerie);
        }
        private static void AdicionarSerie()
        {
            Serie novaSerie = GetNovaSerie(repositorio.ProximoId());
            repositorio.Adicionar(novaSerie);
        }
        private static void ListarSeries()
        {

            List<Serie> lista = repositorio.GetLista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                if (!serie.GetExcluido())
                {
                    Console.WriteLine($"#ID {serie.GetId()} - {serie.GetTitulo()}");
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada: ");

            Console.WriteLine("[1] - Listar séries");
            Console.WriteLine("[2] - Adicionar nova série");
            Console.WriteLine("[3] - Atualizar série");
            Console.WriteLine("[4] - Excluir série");
            Console.WriteLine("[5] - Visualizar série");
            Console.WriteLine("[C] - Limpar tela");
            Console.WriteLine("[X] - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
