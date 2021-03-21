using DIO.InSeries.Enum;

namespace DIO.InSeries.Classes
{
    public class Filme : EntityBase
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }
        public bool Excluido { get; set; }


        public Filme(int id, string titulo, string diretor, int duracao, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Diretor = Diretor;
            this.Duracao = duracao;
            this.Genero = genero;
        }

        public override string ToString()
        {
            return $"{this.Id}|{this.Genero}|{this.Titulo}|{this.Diretor}|{this.Duracao}|{this.Excluido}";
        }
    }
}
