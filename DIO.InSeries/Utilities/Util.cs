using DIO.InSeries.Enum;
using System;

namespace DIO.InSeries.Utilities
{
    public static class Util
    {
        public static Genero ObterValorGenero(string descricao)
        {
            foreach (var indice in System.Enum.GetValues(typeof(Genero)))
            {
                
                if (System.Enum.GetName(typeof(Genero), indice).Equals(descricao))
                {
                    return (Genero)indice;
                }
            }

            throw new IndexOutOfRangeException("Enum não encontrado");
        }
    }
}
