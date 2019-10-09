using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IntelimundoERP
{
    public class RemueveCaracteresEspeciales
    {

        public static string Acentos(string Palabra)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            Palabra = replace_a_Accents.Replace(Palabra, "a");
            Palabra = replace_e_Accents.Replace(Palabra, "e");
            Palabra = replace_i_Accents.Replace(Palabra, "i");
            Palabra = replace_o_Accents.Replace(Palabra, "o");
            Palabra = replace_u_Accents.Replace(Palabra, "u");
            return Palabra;
        }

        public static string CaracteresEspeciales(string Palabra)
        {
            return Regex.Replace(Palabra, @"[^0-9A-Za-z]", string.Empty, RegexOptions.None);
        }
    }
}