using System;
using System.Linq;

namespace IntelimundoERP
{
    public class ControlCorporativo
    {
        public static bool AltaCorporativo(string strNombreCorporativo, string strEmailCorporativo, string strTelefonoCorporativo, string strCalleNumeroCorporativo, string strCodigoPostalCorporativo, int sColoniaCorporativo)
        {
            Guid CorporativoID = Guid.NewGuid(), EmpresaID = Guid.NewGuid(), UsuarioID = Guid.NewGuid();

            try
            {
                using (IntelimundoERPEntities mEmpresa = new IntelimundoERPEntities())
                {
                    var iEmpresa = (from c in mEmpresa.tblEmpresa
                                    select c).ToList();

                    if (iEmpresa.Count == 0)
                    {
                    }
                    else
                    {
                        EmpresaID = iEmpresa[0].EmpresaID;
                    }
                }

                using (IntelimundoERPEntities mCorporativo = new IntelimundoERPEntities())
                {
                    var dCorporativo = (from iCorporativo in mCorporativo.tblCorporativo
                                        select iCorporativo).ToList();

                    if (dCorporativo.Count == 0)
                    {
                        var i_registro = new IntelimundoERPEntities();

                        var diCorporativo = new tblCorporativo
                        {
                            CorporativoID = CorporativoID,
                            Nombre = strNombreCorporativo,
                            email = strEmailCorporativo,
                            Telefono = strTelefonoCorporativo,
                            CalleNumero = strCalleNumeroCorporativo,
                            CodigoPostal = strCodigoPostalCorporativo,
                            ColoniaID = sColoniaCorporativo,
                            EstatusRegistroID = 1,
                            FechaRegistro = DateTime.Now,
                            EmpresaID = EmpresaID
                        };

                   

                        var dDirector = (from iDirector in mCorporativo.tblUsuarios
                                         where iDirector.TipoUsuarioID == 2
                                         select iDirector).ToList();

                        UsuarioID = dDirector[0].UsuarioID;

                        var dCorporativoU = new tblUsuariosCorporativo
                        {
                            CorporativoID = CorporativoID,
                            UsuarioID = UsuarioID
                        };

                        i_registro.tblCorporativo.Add(diCorporativo);
                        i_registro.tblUsuariosCorporativo.Add(dCorporativoU);
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