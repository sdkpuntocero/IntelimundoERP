using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public class ControlUsuarios
    {
        public static bool AltaUsuario(int i_TipoUsuarioID, int i_PerfilUsuarioID, int sGeneroUsuario, DateTime iNacimientoUsuario, string Nombre, string Apaterno, string Amaterno, string striEmailPersonalUsuario, string striEmailCorporativoUsuario)
        {
            Guid i_UsuarioID, EmpresaID = Guid.NewGuid(), CorporativoID = Guid.NewGuid();
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;

            string strNombreUsuario = CINombre.ToTitleCase(Nombre.ToLower());
            string strApaternoUsuario = CIApaterno.ToTitleCase(Apaterno.ToLower());
            string strAmaternoUsuario = CIAmaterno.ToTitleCase(Amaterno.ToLower());

            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            try
            {
                i_clave = Encrypta.Encrypt("poc123");
                i_UsuarioID = Guid.NewGuid();
                i_CodigoUsuario = GeneraCodigoUsuario();

                using (IntelimundoERPEntities mUsuarioR = new IntelimundoERPEntities())
                {
                    var iUsuarioR = (from a in mUsuarioR.tblUsuarios
                                     where a.Usuario == i_usuario
                                     select a).ToList();

                    if (iUsuarioR.Count == 0)
                    {
                        switch (i_TipoUsuarioID)
                        {
                            case 2:
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

                                var i_registro = new IntelimundoERPEntities();

                                var dn_usr = new tblUsuarios
                                {
                                    UsuarioID = i_UsuarioID,
                                    TipoUsuarioID = i_TipoUsuarioID,
                                    PerfilID = i_PerfilUsuarioID,
                                    CodigoUsuario = i_CodigoUsuario,
                                    Usuario = i_usuario,
                                    Clave = i_clave,
                                    Nombres = strNombreUsuario,
                                    Apaterno = strApaternoUsuario,
                                    Amaterno = strAmaternoUsuario,
                                    GeneroID = sGeneroUsuario,
                                    CorreoPersonal = striEmailPersonalUsuario,
                                    CorreoTrabajo = striEmailCorporativoUsuario,
                                    FechaNacimiento = iNacimientoUsuario,
                                    EstatusRegistroID = 1,
                                    FechaRegistro = DateTime.Now
                                };

                                var dn_usremp = new tblUsuariosEmpresa
                                {
                                    UsuarioID = i_UsuarioID,
                                    EmpresaID = EmpresaID,
                                };

                                i_registro.tblUsuarios.Add(dn_usr);
                                i_registro.tblUsuariosEmpresa.Add(dn_usremp);
                                i_registro.SaveChanges();
                                break;

                            case 3:
                                using (IntelimundoERPEntities mEmpresa = new IntelimundoERPEntities())
                                {
                                    var iEmpresa = (from c in mEmpresa.tblCorporativo
                                                    select c).ToList();

                                    if (iEmpresa.Count == 0)
                                    {
                                    }
                                    else
                                    {
                                        CorporativoID = iEmpresa[0].CorporativoID;
                                    }
                                }
                                var iUsuarioCorporativo = new IntelimundoERPEntities();

                                var dnUsuarioCorporativo = new tblUsuarios
                                {
                                    UsuarioID = i_UsuarioID,
                                    TipoUsuarioID = i_TipoUsuarioID,
                                    PerfilID = i_PerfilUsuarioID,
                                    CodigoUsuario = i_CodigoUsuario,
                                    Usuario = i_usuario,
                                    Clave = i_clave,
                                    Nombres = strNombreUsuario,
                                    Apaterno = strApaternoUsuario,
                                    Amaterno = strAmaternoUsuario,
                                    GeneroID = sGeneroUsuario,
                                    CorreoPersonal = striEmailPersonalUsuario,
                                    CorreoTrabajo = striEmailCorporativoUsuario,
                                    FechaNacimiento = iNacimientoUsuario,
                                    EstatusRegistroID = 1,
                                    FechaRegistro = DateTime.Now
                                };

                                var rUsuarioCorporativo = new tblUsuariosCorporativo
                                {
                                    UsuarioID = i_UsuarioID,
                                    CorporativoID = CorporativoID,
                                };

                                iUsuarioCorporativo.tblUsuarios.Add(dnUsuarioCorporativo);
                                iUsuarioCorporativo.tblUsuariosCorporativo.Add(rUsuarioCorporativo);
                                iUsuarioCorporativo.SaveChanges();
                                break;
                        }
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

        private static string GeneraCodigoUsuario()
        {
            string CodigoUsuarios = string.Empty;

            using (IntelimundoERPEntities mCodigoUsuarios = new IntelimundoERPEntities())
            {
                var iCodigoUsuarios = (from c in mCodigoUsuarios.tblUsuarios
                                       select c).ToList();

                if (iCodigoUsuarios.Count == 0)
                {
                    CodigoUsuarios = "USR0001";
                }
                else
                {
                    CodigoUsuarios = "USR" + string.Format("{0:0000}", iCodigoUsuarios.Count + 1);
                }
            }

            return CodigoUsuarios;
        }

        public static string GeneraUsuario(string Nombre, string Apaterno, string Amaterno)
        {
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;
            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            return i_usuario;
        }

        public static DataSet FiltroUsuarios(string strCodigoUsuario, Guid usr_ID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("UsuarioID", typeof(Guid));
            dt.Columns.Add("CodigoUsuario", typeof(string));
            dt.Columns.Add("nom_comp", typeof(string));
            dt.Columns.Add("FechaRegistro", typeof(DateTime));

            using (IntelimundoERPEntities mUsuarios = new IntelimundoERPEntities())
            {
                if (strCodigoUsuario == "TODO")
                {
                    var iUsuarios = (from a in mUsuarios.tblUsuarios
                                     where a.PerfilID != 1
                                     where a.UsuarioID != usr_ID
                                     select new
                                     {
                                         a.UsuarioID,
                                         a.CodigoUsuario,
                                         nom_comp = a.Nombres + " " + a.Apaterno + " " + a.Amaterno,
                                         a.FechaRegistro
                                     }).Distinct().ToList();

                    if (iUsuarios.Count == 0)
                    {
                        return ds;
                    }
                    else
                    {
                        foreach (var item in iUsuarios)
                        {
                            DataRow row = dt.NewRow();

                            row["UsuarioID"] = item.UsuarioID;
                            row["CodigoUsuario"] = item.CodigoUsuario;
                            row["nom_comp"] = item.nom_comp;
                            row["FechaRegistro"] = item.FechaRegistro;

                            dt.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    Char char_s = '|';

                    String[] de_rub = strCodigoUsuario.Trim().Split(char_s);

                    if (de_rub.Length == 2)
                    {
                        strCodigoUsuario = de_rub[1].Trim();
                    }

                    var iUsuarios = (from a in mUsuarios.tblUsuarios
                                     where a.CodigoUsuario == strCodigoUsuario
                                     where a.PerfilID != 1
                                     select new
                                     {
                                         a.UsuarioID,
                                         a.CodigoUsuario,
                                         nom_comp = a.Nombres + " " + a.Apaterno + " " + a.Amaterno,
                                         a.FechaRegistro
                                     }).Distinct().ToList();

                    if (iUsuarios.Count == 0)
                    {
                        return ds;
                    }
                    else
                    {
                        foreach (var item in iUsuarios)
                        {
                            DataRow row = dt.NewRow();

                            row["UsuarioID"] = item.UsuarioID;
                            row["CodigoUsuario"] = item.CodigoUsuario;
                            row["nom_comp"] = item.nom_comp;
                            row["FechaRegistro"] = item.FechaRegistro;

                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet FiltroUsuario(Guid usr_ID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("UsuarioID", typeof(Guid));
            dt.Columns.Add("CodigoUsuario", typeof(string));
            dt.Columns.Add("nom_comp", typeof(string));
            dt.Columns.Add("FechaRegistro", typeof(DateTime));

            using (IntelimundoERPEntities mInformacionusuario = new IntelimundoERPEntities())
            {
                var fInformacionusuario = (from a in mInformacionusuario.tblUsuarios
                                           where a.UsuarioID == usr_ID
                                           select new
                                           {
                                               a.UsuarioID,
                                               a.CodigoUsuario,
                                               nom_comp = a.Nombres + " " + a.Apaterno + " " + a.Amaterno,
                                               a.FechaRegistro
                                           }).Distinct().ToList();

                if (fInformacionusuario.Count == 0)
                {
                    return ds;
                }
                else
                {
                    foreach (var item in fInformacionusuario)
                    {
                        DataRow row = dt.NewRow();

                        row["UsuarioID"] = item.UsuarioID;
                        row["CodigoUsuario"] = item.CodigoUsuario;
                        row["nom_comp"] = item.nom_comp;
                        row["FechaRegistro"] = item.FechaRegistro;

                        dt.Rows.Add(row);
                    }
                }

                ds.Tables.Add(dt);
                return ds;
            }
        }

        public static DataSet InformacionUsuario(Guid usr_ID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("AreaID", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(DateTime));
            dt.Columns.Add("PerfilID", typeof(int));
            dt.Columns.Add("GeneroID", typeof(int));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apaterno", typeof(string));
            dt.Columns.Add("Amaterno", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("CodigoUsuario", typeof(string));
            dt.Columns.Add("CorreoPersonal", typeof(string));

            using (IntelimundoERPEntities mInformacionusuario = new IntelimundoERPEntities())
            {
                var iInformacionusuario = (from a in mInformacionusuario.tblUsuarios
                                           join b in mInformacionusuario.tblAreasPerfil on a.PerfilID equals b.PerfilID
                                           join c in mInformacionusuario.catAreas on b.AreaID equals c.AreaID
                                           where a.UsuarioID == usr_ID
                                           select new
                                           {
                                               c.AreaID,
                                               c.Descripcion,
                                               a.FechaNacimiento,
                                               a.PerfilID,
                                               a.GeneroID,
                                               a.Nombres,
                                               a.Apaterno,
                                               a.Amaterno,
                                               a.Usuario,
                                               a.CodigoUsuario,
                                               a.CorreoPersonal
                                           }).ToList();

                if (iInformacionusuario.Count == 0)
                {
                    return ds;
                }
                else
                {
                    foreach (var item in iInformacionusuario)
                    {
                        DataRow row = dt.NewRow();

                        row["AreaID"] = item.AreaID;
                        row["Descripcion"] = item.Descripcion;
                        row["FechaNacimiento"] = item.FechaNacimiento;
                        row["PerfilID"] = item.PerfilID;
                        row["GeneroID"] = item.GeneroID;
                        row["Nombres"] = item.Nombres;
                        row["Apaterno"] = item.Apaterno;
                        row["Amaterno"] = item.Amaterno;
                        row["Usuario"] = item.Usuario;
                        row["CodigoUsuario"] = item.CodigoUsuario;
                        row["CorreoPersonal"] = item.CorreoPersonal;

                        dt.Rows.Add(row);
                    }
                }
            }

            ds.Tables.Add(dt);
            return ds;
        }
    }
}