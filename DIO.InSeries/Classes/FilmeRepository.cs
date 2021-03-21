using DIO.InSeries.Interfaces;
using DIO.InSeries.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DIO.InSeries.Classes
{
    public class FilmeRepository : IRepository<Filme>
    {
        private const string pathArquivo = "Filme.txt";

        private List<string> linhasArquivo;

        public FilmeRepository()
        {
            if (!File.Exists(pathArquivo))
            {
                File.Create(pathArquivo).Dispose();
            }
        }

        public void Atualiza(int id, Filme entity)
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

        public void Insere(Filme entity)
        {
            using (StreamWriter writer = new StreamWriter(pathArquivo, append: true))
            {
                writer.WriteLine(entity.ToString());
                writer.Dispose();
            }
        }

        public List<Filme> Lista()
        {
            List<Filme> lista = new List<Filme>();
            string line = string.Empty;

            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lista.Add(new Filme(line));
                }
            }

            return lista;//.Where(x => !x.retornaExcluido()).ToList();
        }

        public int ProximoId()
        {
            return new Random().Next(1, 100000);
        }

        public Filme RetornaPorId(int id)
        {
            Filme filme = null;
            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                string linha = string.Empty;
                while ((linha = reader.ReadLine()) != null)
                {
                    if (linha.Contains(id.ToString()))
                        filme = new Filme(linha);
                }
            }

            if (filme == null)
                throw new ArgumentNullException("Série não localizada!");

            return filme;
        }
    }
}
