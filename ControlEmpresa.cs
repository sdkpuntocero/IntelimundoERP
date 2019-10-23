using System;
using System.Globalization;
using System.Linq;

namespace IntelimundoERP
{
    public class ControlEmpresa
    {
        public static bool AltaEmpresa(string striNombreEmpresa, int sTipoRFCEmpresa, string strRFCEmpresa, string strEmailEmpresa, string strTelefonoEmpresa, string striCalleNumeroEmpresa, string strCodigoPostalEmpresa, int sColoniaEmpresa)
        {
            Guid EmpresaID = Guid.NewGuid();
            string strNombreDirector = null, strApaternoDirector = null, strAmaternoDirector = null, strNombreEmpresa = null, strNombreCorporativo = null, strCalleNumeroEmpresa = null, strCalleNumeroCorporativo = null;

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompania = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompaniaNombre = new CultureInfo("es-MX", false).TextInfo;

            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            strNombreDirector = CINombre.ToTitleCase(strNombreDirector.ToLower());
            strApaternoDirector = CIApaterno.ToTitleCase(strApaternoDirector.ToLower());
            strAmaternoDirector = CIAmaterno.ToTitleCase(strAmaternoDirector.ToLower());

            strNombreEmpresa = CICompania.ToTitleCase(strNombreEmpresa.ToLower());
            strNombreCorporativo = CICompaniaNombre.ToTitleCase(strNombreCorporativo.ToLower());
            strCalleNumeroEmpresa = CICalleNum.ToTitleCase(strCalleNumeroEmpresa.ToLower());
            strCalleNumeroCorporativo = CICalleNum.ToTitleCase(strCalleNumeroCorporativo.ToLower());
            try
            {
                using (IntelimundoERPEntities mEmpresa = new IntelimundoERPEntities())
                {
                    var dEmpresa = (from iEmpresa in mEmpresa.tblEmpresa
                                    select iEmpresa).ToList();

                    if (dEmpresa.Count == 0)
                    {
                        var i_registro = new IntelimundoERPEntities();

                        var diEmpresa = new tblEmpresa
                        {
                            EmpresaID = EmpresaID,
                            Nombre = strNombreEmpresa,
                            TipoRFCID = sTipoRFCEmpresa,
                            RFC = strRFCEmpresa,
                            email = strEmailEmpresa,
                            Telefono = strTelefonoEmpresa,
                            CalleNumero = strCalleNumeroEmpresa,
                            CodigoPostal = strCodigoPostalEmpresa,
                            ColoniaID = sColoniaEmpresa,
                            EstatusRegistroID = 1,
                            FechaRegistro = DateTime.Now
                        };

                        i_registro.tblEmpresa.Add(diEmpresa);
                        i_registro.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}