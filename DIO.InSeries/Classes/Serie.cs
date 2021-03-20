using DIO.InSeries.Enum;
using System;

namespace DIO.InSeries.Classes
{
    public class Serie : EntityBase
    {
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string  Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

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
            this.Genero = (Genero) Convert.ToInt32(arquivo[1]);
            this.Titulo = arquivo[2];
            this.Descricao = arquivo[3];
            this.Ano = Convert.ToInt32(arquivo[4]);
            this.Excluido = Convert.ToBoolean(arquivo[3]);
        }

        public override string ToString()
        {
            //string retorno = string.Empty;
            //retorno += $" Gênero: {this.Genero} {Environment.NewLine}";
            //retorno += $" Título: {this.Titulo} {Environment.NewLine}";
            //retorno += $" Descrição: {this.Descricao} {Environment.NewLine}";
            //retorno += $" Ano Início: {this.Ano} {Environment.NewLine}";
            //retorno += $" Excluído: {this.Excluido}";
            
            //return retorno;
            return $"{this.Id}|{this.Genero}|{this.Titulo}|{this.Descricao}|{this.Ano}|{this.Excluido}";
        }
        

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

        internal bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}
