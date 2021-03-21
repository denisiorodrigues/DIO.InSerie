using DIO.InSeries.Classes;
using DIO.InSeries.Enum;
using DIO.InSeries.OutputView;
using System;

namespace DIO.InSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "S":
                        SerieOutput.Executar();
                        break;
                    case "F":
                        FilmeOutput.Executar();
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

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("==   DIO Selecione uma Opção do MENU !!!   ===");
            Console.WriteLine("==============================================");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("S - Series");
            Console.WriteLine("F - Filme");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ExecutarSerie()
        {
            
        }

        private static void ExecutarFilme()
        {

        }
    }
}
