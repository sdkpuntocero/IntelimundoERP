using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelimundoERP
{
    public class IzquierdaMedioDerecha
    {
        public static string Izquierda(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }

        public static string Derecha(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public static string Medio(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        public static string Medio(string param, int startIndex)
        {
            string result = param.Substring(startIndex);
            return result;
        }
    }
}