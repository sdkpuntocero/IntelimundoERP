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
            string strNombreEmpresa = null, strCalleNumeroEmpresa = null;

            TextInfo ciNombreEmpresa = new CultureInfo("es-MX", false).TextInfo;
            TextInfo ciCalleNumeroEmpresa = new CultureInfo("es-MX", false).TextInfo;

            strNombreEmpresa = ciNombreEmpresa.ToTitleCase(striNombreEmpresa.ToLower());
            strCalleNumeroEmpresa = ciCalleNumeroEmpresa.ToTitleCase(striCalleNumeroEmpresa.ToLower());

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