using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DIO.InSeries.Classes
{
    public static class Arquivo
    {
        const string path = "~/Data/";

        public static void Gravar(string nomeArquivo, ArrayList listaObjeto)
        {
            using StreamWriter file = new StreamWriter($"{path}{nomeArquivo}.txt");

            foreach (var item in listaObjeto)
            {
                file.WriteLineAsync(item.ToString());
            }
        }

        public static string [] Recuperar(string nomeArquivo)
        {
            return File.ReadAllLines($"{path}{nomeArquivo}.txt");
        }
    }
}
