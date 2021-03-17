using DIO.InSeries.Enum;

namespace DIO.InSeries.Classes
{
    public class Filme : EntityBase
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }


        public Filme(int id, string titulo, int duracao, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Duracao = duracao;
            this.Genero = genero;
        }
    }
}
