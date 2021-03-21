using DIO.InSeries.Enum;
using DIO.InSeries.Utilities;
using System;
using System.Reflection;

namespace DIO.InSeries.Classes
{
    public class Serie : EntityBase
    {
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string  Descricao { get; set; }

        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao,  int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public Serie(string linhaArquivo)
        {
            var arquivo = linhaArquivo.Split("|");
            this.Id = Convert.ToInt32(arquivo[0]);
            this.Genero = Utilities.Util.ObterValorGenero(arquivo[1].ToString());

            this.Titulo = arquivo[2];
            this.Descricao = arquivo[3];
            this.Ano = Convert.ToInt32(arquivo[4]);
            this.Excluido = Convert.ToBoolean(arquivo[5]);
        }

        public override string ToString()
        {
            return $"{this.Id}|{this.Genero}|{this.Titulo}|{this.Descricao}|{this.Ano}|{this.Excluido}";
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
    }
}
