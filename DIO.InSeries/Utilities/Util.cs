using DIO.InSeries.Enum;
using System;
using System.Reflection;

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

        public static string ObterValoresSeparadoPorPipe(object classe)
        {
            string retorno = string.Empty;

            PropertyInfo[] properties = classe.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (var property in properties)
            {
                if (string.IsNullOrEmpty(retorno))
                {
                    retorno += property.GetValue(classe, null).ToString();
                }else
                {
                    retorno += $"|{property.GetValue(classe, null)}";
                }
            }

            return retorno;
        }
    }
}
