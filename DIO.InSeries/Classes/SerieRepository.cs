using DIO.InSeries.Interfaces;
using DIO.InSeries.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DIO.InSeries.Classes
{
    class SerieRepository : IRepository<Serie>
    {
        private const string pathArquivo = "Serie.txt";

        private List<string> linhasArquivo;

        public SerieRepository()
        {
            if (!File.Exists(pathArquivo))
            {
                File.Create(pathArquivo).Dispose();
            }
        }

        public void Atualiza(int id, Serie entity)
        {
            linhasArquivo = Arquivo.Ler(pathArquivo);

            //Está aqui para reescrever o arquivo
            File.Create(pathArquivo).Dispose();

            using (StreamWriter writer = new StreamWriter(pathArquivo))
            {
                foreach (var linha in linhasArquivo)
                {
                    if (linha.Contains(id.ToString()))
                    {
                        writer.WriteLine(entity.ToString());
                    }
                    else
                    {
                        writer.WriteLine(linha);
                    }
                }
            }
        }

        public void Exclui(int id)
        {
            var series = Lista();
            var serie = series.Where(x => x.retornaId() == id).FirstOrDefault();
            serie.Exclui();
            Atualiza(id, serie);
        }

        public void Insere(Serie entity)
        {
            using (StreamWriter writer = new StreamWriter(pathArquivo, append: true))
            {
                writer.WriteLine(entity.ToString());
                writer.Dispose();
            }
        }

        public List<Serie> Lista()
        {
            List<Serie> lista = new List<Serie>();
            string line = string.Empty;

            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lista.Add(new Serie(line));
                }
            }

            return lista.Where(x => !x.retornaExcluido()).ToList();
        }

        public int ProximoId()
        {
            return new Random().Next(1, 100000);
        }

        public Serie RetornaPorId(int id)
        {
            Serie serie = null;
            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                string linha = string.Empty;
                while ((linha = reader.ReadLine()) != null)
                {
                    if (linha.Contains(id.ToString()))
                        serie = new Serie(linha);
                }
            }

            if (serie == null)
                throw new ArgumentNullException("Série não localizada!");

            return serie;
        }
    }
}
