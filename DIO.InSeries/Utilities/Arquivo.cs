using DIO.InSeries.Classes;
using System.Collections.Generic;
using System.IO;

namespace DIO.InSeries.Util
{
    public static class Arquivo
    {
        public static List<string> Ler(string path)
        {
            var linhasArquivo = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string linha = string.Empty;
                while ((linha = reader.ReadLine()) != null)
                {
                    linhasArquivo.Add(linha);
                }
            }

            return linhasArquivo;
        }
    }
}
