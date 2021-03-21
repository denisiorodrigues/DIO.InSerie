namespace DIO.InSeries.Classes
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        protected bool Excluido { get; set; }
        
        public void Exclui()
        {
            this.Excluido = true;
        }

        public int retornaId()
        {
            return this.Id;
        }

        internal bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}
