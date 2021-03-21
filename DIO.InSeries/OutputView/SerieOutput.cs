using DIO.InSeries.Classes;
using DIO.InSeries.Enum;
using System;

namespace DIO.InSeries.OutputView
{
    public static class SerieOutput
    {
        private static SerieRepository _repositorio = new SerieRepository();

        private static int ObterOId()
        {
            Console.Write("Digite o id da série: ");
            return int.Parse(Console.ReadLine());
        }

        private static DadosEntrada ObterDadosEntrada()
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

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("======   DIO Séries a seu dispor!!!   ========");
            Console.WriteLine("==============================================");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar para o Menu Principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void Atualizar()
        {
            int indiceSerie = ObterOId();

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            DadosEntrada dadosEntradaSerie = ObterDadosEntrada();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)dadosEntradaSerie.Genero,
                                        titulo: dadosEntradaSerie.Titulo,
                                        ano: dadosEntradaSerie.AnoInicio,
                                        descricao: dadosEntradaSerie.Descricao);

            _repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void Excluir()
        {
            int indiceSerie = ObterOId();

            _repositorio.Exclui(indiceSerie);
        }

        private static void Inserir()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            DadosEntrada dadosEntradaSerie = ObterDadosEntrada();

            Serie novaSerie = new Serie(id: _repositorio.ProximoId(),
                                        genero: (Genero)dadosEntradaSerie.Genero,
                                        titulo: dadosEntradaSerie.Titulo,
                                        ano: dadosEntradaSerie.AnoInicio,
                                        descricao: dadosEntradaSerie.Descricao);

            _repositorio.Insere(novaSerie);
        }

        private static void Listar()
        {
            Console.WriteLine("Listar séries");

            var lista = _repositorio.Lista();

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

        private static void Visualizar()
        {
            int indiceSerie = ObterOId();

            var serie = _repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static void Executar()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
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
    }
}
