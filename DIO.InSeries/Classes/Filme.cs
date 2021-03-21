using DIO.InSeries.Enum;
using System;

namespace DIO.InSeries.Classes
{
    public class Filme : EntityBase
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }


        public Filme(int id, string titulo, string diretor, int duracao, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Diretor = diretor;
            this.Duracao = duracao;
            this.Genero = genero;
            this.Excluido = false;
        }
        
        public Filme(string linhaArquivo)
        {
            var arquivo = linhaArquivo.Split("|");
            this.Id = Convert.ToInt32(arquivo[0]);
            this.Genero = Utilities.Util.ObterValorGenero(arquivo[1].ToString());
            this.Titulo = arquivo[2];
            this.Diretor = arquivo[3];
            this.Duracao = Convert.ToInt32(arquivo[4]);
            this.Excluido = Convert.ToBoolean(arquivo[5]);
        }
        
        public override string ToString()
        {
            return $"{this.Id}|{this.Genero}|{this.Titulo}|{this.Diretor}|{this.Duracao}|{this.Excluido}";
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
    }
}
