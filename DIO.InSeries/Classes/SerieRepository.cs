using DIO.InSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace DIO.InSeries.Classes
{
    class SerieRepository : IRepository<Serie>
    {
        private const string pathArquivo = "~\\Data\\Serie.txt";

        public void Atualiza(int id, Serie entity)
        {
            string line = string.Empty;

            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                using (StreamWriter writer = new StreamWriter(pathArquivo))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, id.ToString()) == 0)
                            writer.WriteLine(entity.ToString());

                        writer.WriteLine(line);
                    }
                }
            }
        }

        public void Exclui(int id)
        {
            string line = string.Empty;
            
            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                using (StreamWriter writer = new StreamWriter(pathArquivo))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, id.ToString()) == 0)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
        }

        public void Insere(Serie entity)
        {
            using (StreamWriter writer = new StreamWriter(pathArquivo))
            {
                writer.WriteLine(entity.ToString());
            }
        }

        public List<Serie> Lista()
        {
            List<Serie> lista = new List<Serie>();

            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                var lineSerie = reader.ReadLine();
                lista.Add(new Serie(lineSerie));
            }

            return lista;
        }

        public int ProximoId()
        {
            var random = new Random();
            return random.Next(1, 100000);
        }

        public Serie RetornaPorId(int id)
        {
            string line = string.Empty;
            Serie serie = null;
            using (StreamReader reader = new StreamReader(pathArquivo))
            {
                using (StreamWriter writer = new StreamWriter(pathArquivo))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, id.ToString()) == 0)
                            serie = new Serie(line);
                    }
                }
            }

            if (serie ==null )
                throw new ArgumentNullException("Série não localizada!");

            return serie;
        }
    }
}
