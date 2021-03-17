using DIO.InSeries.Classes;
using DIO.InSeries.Enum;
using System;

namespace DIO.InSeries
{
    class Program
    {
		static SerieRepository repositorio = new SerieRepository();

		static void Main(string[] args)
        {
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
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

				opcaoUsuario = ObterOpcaoUsuario();
			}
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

		private static void ExcluirSerie()
		{
			int indiceSerie = ObterOIdSerie();

			repositorio.Exclui(indiceSerie);
		}

		private static void VisualizarSerie()
		{
			int indiceSerie = ObterOIdSerie();

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
			int indiceSerie = ObterOIdSerie();

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			}
			
			DadosEntrada dadosEntradaSerie = ObterDadosEntradaSerie();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)dadosEntradaSerie.Genero,
										titulo: dadosEntradaSerie.Titulo,
										ano: dadosEntradaSerie.AnoInicio,
										descricao: dadosEntradaSerie.Descricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			}

			DadosEntrada dadosEntradaSerie = ObterDadosEntradaSerie();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)dadosEntradaSerie.Genero,
										titulo: dadosEntradaSerie.Titulo,
										ano: dadosEntradaSerie.AnoInicio,
										descricao: dadosEntradaSerie.Descricao);

			repositorio.Insere(novaSerie);
		}

		private static int ObterOIdSerie()
        {
			Console.Write("Digite o id da série: ");
			return int.Parse(Console.ReadLine());
		}

		private static DadosEntrada ObterDadosEntradaSerie()
        {
			DadosEntrada dadosEntrada = new DadosEntrada();

			Console.Write("Digite o gênero entre as opções acima: ");
			dadosEntrada.Genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			dadosEntrada.Titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			dadosEntrada.AnoInicio = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			dadosEntrada.Descricao = Console.ReadLine();

			return dadosEntrada;
		}
	}
}
