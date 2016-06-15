using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MercadoEnvio.Helpers;
using System.Configuration;
using MercadoEnvio.Entidades;
using MercadoEnvio.Properties;
using MercadoEnvio.Servicios;

namespace MercadoEnvio.DataManagers
{
    public class DataManagerUsuario
    {
        public static Entidades.Login Login(string userName, string password)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Usuario usuario = GetUsuarioByUserName(userName, db);

                Entidades.Login login = new Entidades.Login();
                if (usuario.IdUsuario == 0)
                {
                    login.LoginSuccess = false;
                    login.ErrorMessage = Resources.UsuarioNoExiste;
                }
                else
                {
                    if (!usuario.Activo)
                    {
                        if (usuario.CantIntFallidos >= 3)
                        {
                            login.Usuario = usuario;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioBloqueado + Resources.ContactarAdministrador;
                        }
                        else
                        {
                            login.Usuario = usuario;
                            login.LoginSuccess = false;
                            login.ErrorMessage = Resources.UsuarioDeshabilitado + "\n" + Resources.ContactarAdministrador;
                        }
                    }
                    else if (usuario.Password.Equals(password))
                    {
                        ResetCountLogin(userName, db);

                        usuario.CantIntFallidos = 0;
                        login.Usuario = usuario;
                        login.LoginSuccess = true;
                    }
                    else
                    {
                        usuario.CantIntFallidos = (int)IncrementCountLogin(userName, db);

                        login.Usuario = usuario;
                        login.LoginSuccess = false;
                        login.ErrorMessage = Resources.ContraseñaIncorrecta;

                        if (usuario.CantIntFallidos >= 3)
                            BloqUser(userName, db);
                    }
                }

                db.EndConnection();

                return login;
            }
        }

        private static Usuario GetUsuarioByUserName(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetUsuarioByUserName", parameters);
            Usuario usuario = new Usuario();
            foreach (DataRow row in res.Rows)
            {
                usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                usuario.UserName = Convert.ToString(row["UserName"]);
                usuario.Password = Convert.ToString(row["PassEncr"]);
                usuario.CantIntFallidos = Convert.ToByte(row["CantIntFallidos"]);
                usuario.Activo = Convert.ToBoolean(row["Activo"]);
            }

            usuario.Roles = GetRolesUsuario(usuario.IdUsuario, db);

            return usuario;
        }

        private static void BloqUser(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_BloqUser", parameters);
        }

        private static object IncrementCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            return db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_IncrementCountLogin", parameters);
        }

        private static void ResetCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_ResetCountLogin", parameters);
        }

        public static List<Cliente> FindClientes(string filtroNombre, string filtroApellido, string filtroDni, string filtroEmail)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Cliente> usuarios = FindClientes(filtroNombre, filtroApellido, filtroDni, filtroEmail, db);

                db.EndConnection();

                return usuarios;
            }
        }

        private static List<Cliente> FindClientes(string filtroNombre, string filtroApellido, string filtroDni, string filtroEmail, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter nombreParameter = new SqlParameter("@FiltroNombre", SqlDbType.NVarChar);
            nombreParameter.Value = filtroNombre.Trim();

            SqlParameter apllidoParameter = new SqlParameter("@FiltroApellido", SqlDbType.NVarChar);
            apllidoParameter.Value = filtroApellido;

            SqlParameter emailParameter = new SqlParameter("@FiltroEmail", SqlDbType.NVarChar);
            emailParameter.Value = filtroEmail;

            SqlParameter dniParameter = new SqlParameter("@FiltroDni", SqlDbType.Decimal);
            dniParameter.Value = string.IsNullOrEmpty(filtroDni) ? 0 : Convert.ToDecimal(filtroDni);

            parameters.Add(nombreParameter);
            parameters.Add(apllidoParameter);
            parameters.Add(emailParameter);
            parameters.Add(dniParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindClientes", parameters);
            List<Cliente> usuarios = new List<Cliente>();
            foreach (DataRow row in res.Rows)
            {
                var usuario = new Cliente
                {
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    Nombre = Convert.ToString(row["Nombre"]),
                    Apellido = Convert.ToString(row["Apellido"]),
                    Calle = Convert.ToString(row["Calle"]),
                    NroCalle = Convert.ToInt32(row["NroCalle"]),
                    CodigoPostal = Convert.ToString(row["CodigoPostal"]),
                    Departamento = Convert.ToString(row["Departamento"]),
                    Email = Convert.ToString(row["Email"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    Localidad = Convert.ToString(row["Localidad"]),
                    NumeroDoc = Convert.ToInt32(row["NroDoc"]),
                    Piso = Convert.ToInt32(row["Piso"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                    TipoDoc = Convert.ToString(row["TipoDoc"]),
                    UserName = Convert.ToString(row["UserName"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Password = Convert.ToString(row["PasswordEnc"]),
                };

                usuario.Roles = GetRolesUsuario(usuario.IdUsuario, db);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        private static List<Rol> GetRolesUsuario(int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            parameters.Add(idUsuarioParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetRolesUsuario", parameters);
            List<Rol> roles = new List<Rol>();
            List<Rol> rolesAux = new List<Rol>(RolesServices.GetAllData());
            foreach (DataRow row in res.Rows)
            {
                var idRol = Convert.ToInt32(row["IdRol"]);

                roles.Add(rolesAux.Find(x => x.IdRol == idRol));
            }

            return roles;
        }

        public static List<Empresa> FindEmpresas(string filtroRazonSocial, string filtroCuit, string filtroEmail)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                List<Empresa> usuarios = FindEmpresas(filtroRazonSocial, filtroCuit, filtroEmail, db);

                db.EndConnection();

                return usuarios;
            }
        }

        private static List<Empresa> FindEmpresas(string filtroRazonSocial, string filtroCuit, string filtroEmail, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter razonSocialParameter = new SqlParameter("@FiltroRazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = filtroRazonSocial.Trim();

            SqlParameter cuitParameter = new SqlParameter("@FiltroCuit", SqlDbType.NVarChar);
            cuitParameter.Value = filtroCuit;

            SqlParameter emailParameter = new SqlParameter("@FiltroEmail", SqlDbType.NVarChar);
            emailParameter.Value = filtroEmail;

            parameters.Add(razonSocialParameter);
            parameters.Add(cuitParameter);
            parameters.Add(emailParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_FindEmpresas", parameters);
            List<Empresa> usuarios = new List<Empresa>();
            foreach (DataRow row in res.Rows)
            {
                var usuario = new Empresa
                {
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    UserName = Convert.ToString(row["UserName"]),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Password = Convert.ToString(row["PasswordEnc"]),
                    Calle = Convert.ToString(row["Calle"]),
                    Ciudad = Convert.ToString(row["Ciudad"]),
                    CodigoPostal = Convert.ToString(row["CodigoPostal"]),
                    Contacto = Convert.ToString(row["Contacto"]),
                    Cuit = Convert.ToString(row["Cuit"]),
                    Departamento = Convert.ToString(row["Departamento"]),
                    Email = Convert.ToString(row["Email"]),
                    Localidad = Convert.ToString(row["Localidad"]),
                    NroCalle = Convert.ToInt32(row["NroCalle"]),
                    Piso = Convert.ToInt32(row["Piso"]),
                    RazonSocial = Convert.ToString(row["RazonSocial"]),
                    Rubro = Convert.ToString(row["Rubro"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                };

                usuario.Roles = GetRolesUsuario(usuario.IdUsuario, db);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public static void SaveNewEmpresa(Empresa newEmpresa)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertUsuario(newEmpresa, db);
                InsertEmpresa(newEmpresa, db);
                newEmpresa.Roles.Add(RolesServices.GetRolByDescription("Empresa"));

                foreach (Rol rol in newEmpresa.Roles)
                {
                    InsertUsuarioRol(newEmpresa.IdUsuario, rol.IdRol, true, db);
                }

                db.EndConnection();
            }
        }

        private static void InsertUsuario(Usuario newUsuario, DataBaseHelper db)
        {
            EncryptHelper encryptHelper = new EncryptHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = newUsuario.UserName;

            SqlParameter passEncrParameter = new SqlParameter("@PassEncr", SqlDbType.NVarChar);
            passEncrParameter.Value = encryptHelper.Sha256Encrypt(newUsuario.Password);

            SqlParameter cantIntFallidosParameter = new SqlParameter("@CantIntFallidos", SqlDbType.Int);
            cantIntFallidosParameter.Value = newUsuario.CantIntFallidos;

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = true;

            parameters.Add(userNameParameter);
            parameters.Add(passEncrParameter);
            parameters.Add(cantIntFallidosParameter);
            parameters.Add(activoParameter);

            newUsuario.IdUsuario = (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "MASTERDBA.SP_InsertUsuario", parameters);
        }

        private static void InsertEmpresa(Empresa newEmpresa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = newEmpresa.IdUsuario;

            SqlParameter razonSocialParameter = new SqlParameter("@RazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = newEmpresa.RazonSocial.Trim();

            SqlParameter mailParameter = new SqlParameter("@Mail", SqlDbType.NVarChar);
            mailParameter.Value = newEmpresa.Email.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = newEmpresa.Telefono.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = newEmpresa.Calle.Trim();

            SqlParameter nroParameter = new SqlParameter("@Nro", SqlDbType.Int);
            nroParameter.Value = newEmpresa.NroCalle;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = newEmpresa.Piso;

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = newEmpresa.Departamento.Trim();

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = newEmpresa.Localidad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = newEmpresa.CodigoPostal.Trim();

            SqlParameter ciudadParameter = new SqlParameter("@Ciudad", SqlDbType.NVarChar);
            ciudadParameter.Value = newEmpresa.Ciudad.Trim();

            SqlParameter cuitParameter = new SqlParameter("@CUIT", SqlDbType.NVarChar);
            cuitParameter.Value = newEmpresa.Cuit.Trim();

            SqlParameter contactoParameter = new SqlParameter("@Contacto", SqlDbType.NVarChar);
            contactoParameter.Value = newEmpresa.Contacto.Trim();

            SqlParameter rubroParameter = new SqlParameter("@Rubro", SqlDbType.NVarChar);
            rubroParameter.Value = newEmpresa.Rubro.Trim();

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now; // TODO Recuperar del app.config

            parameters.Add(idUsuarioParameter);
            parameters.Add(razonSocialParameter);
            parameters.Add(mailParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(calleParameter);
            parameters.Add(nroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(localidadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(ciudadParameter);
            parameters.Add(cuitParameter);
            parameters.Add(contactoParameter);
            parameters.Add(rubroParameter);
            parameters.Add(fechaCreacionParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertEmpresa", parameters);
        }

        private static void InsertUsuarioRol(int idUsuario, int idRol, bool activa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            SqlParameter activaParameter = new SqlParameter("@Activa", SqlDbType.Bit);
            activaParameter.Value = activa;

            parameters.Add(idUsuarioParameter);
            parameters.Add(idRolParameter);
            parameters.Add(activaParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertUsuarioRol", parameters);
        }

        public static void SaveNewCliente(Cliente newCliente)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertUsuario(newCliente, db);
                InsertCliente(newCliente, db);
                newCliente.Roles.Add(RolesServices.GetRolByDescription("Cliente"));

                foreach (Rol rol in newCliente.Roles)
                {
                    InsertUsuarioRol(newCliente.IdUsuario, rol.IdRol, true, db);
                }

                db.EndConnection();
            }
        }

        private static void InsertCliente(Cliente newCliente, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = newCliente.IdUsuario;

            SqlParameter apellidoParameter = new SqlParameter("@Apellido", SqlDbType.NVarChar);
            apellidoParameter.Value = newCliente.Apellido.Trim();

            SqlParameter nombreParameter = new SqlParameter("@Nombre", SqlDbType.NVarChar);
            nombreParameter.Value = newCliente.Nombre.Trim();

            SqlParameter tipoDocParameter = new SqlParameter("@TipoDoc", SqlDbType.NVarChar);
            tipoDocParameter.Value = newCliente.TipoDoc.Trim();

            SqlParameter nroDocParameter = new SqlParameter("@NroDoc", SqlDbType.Int);
            nroDocParameter.Value = newCliente.NumeroDoc;

            SqlParameter mailParameter = new SqlParameter("@Mail", SqlDbType.NVarChar);
            mailParameter.Value = newCliente.Email.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = newCliente.Telefono.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = newCliente.Calle.Trim();

            SqlParameter nroParameter = new SqlParameter("@Nro", SqlDbType.Int);
            nroParameter.Value = newCliente.NroCalle;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = newCliente.Piso;

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = newCliente.Departamento.Trim();

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = newCliente.Localidad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = newCliente.CodigoPostal.Trim();

            SqlParameter fechaNacimientoParameter = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParameter.Value = newCliente.FechaNacimiento.Date;

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now; // TODO Recuperar del app.config

            parameters.Add(idUsuarioParameter);
            parameters.Add(apellidoParameter);
            parameters.Add(nombreParameter);
            parameters.Add(tipoDocParameter);
            parameters.Add(nroDocParameter);
            parameters.Add(mailParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(calleParameter);
            parameters.Add(nroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(localidadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(fechaNacimientoParameter);
            parameters.Add(fechaCreacionParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_InsertCliente", parameters);
        }

        public static void UpdateCliente(Cliente cliente)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateCliente(cliente, db);

                List<Rol> roles = GetRolesUsuario(cliente.IdUsuario, db);

                foreach (Rol rol in cliente.Roles)
                {
                    if (!roles.Exists(x => x.IdRol == rol.IdRol))
                        InsertUsuarioRol(cliente.IdUsuario, rol.IdRol, true, db);
                }

                foreach (Rol rol in roles)
                {
                    if (!cliente.Roles.Exists(x => x.IdRol == rol.IdRol))
                        DeleteUsuarioRol(cliente.IdUsuario, rol.IdRol, db);
                }

                db.EndConnection();
            }
        }

        private static void UpdateCliente(Cliente cliente, DataBaseHelper db)
        {
            EncryptHelper encryptHelper = new EncryptHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = cliente.IdUsuario;

            SqlParameter apellidoParameter = new SqlParameter("@Apellido", SqlDbType.NVarChar);
            apellidoParameter.Value = cliente.Apellido.Trim();

            SqlParameter nombreParameter = new SqlParameter("@Nombre", SqlDbType.NVarChar);
            nombreParameter.Value = cliente.Nombre.Trim();

            SqlParameter tipoDocParameter = new SqlParameter("@TipoDoc", SqlDbType.NVarChar);
            tipoDocParameter.Value = cliente.TipoDoc.Trim();

            SqlParameter nroDocParameter = new SqlParameter("@NroDoc", SqlDbType.Int);
            nroDocParameter.Value = cliente.NumeroDoc;

            SqlParameter mailParameter = new SqlParameter("@Mail", SqlDbType.NVarChar);
            mailParameter.Value = cliente.Email.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = cliente.Telefono.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = cliente.Calle.Trim();

            SqlParameter nroParameter = new SqlParameter("@Nro", SqlDbType.Int);
            nroParameter.Value = cliente.NroCalle;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = cliente.Piso;

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = cliente.Departamento.Trim();

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = cliente.Localidad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = cliente.CodigoPostal.Trim();

            SqlParameter fechaNacimientoParameter = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParameter.Value = cliente.FechaNacimiento.Date;

            SqlParameter passEncrParameter = new SqlParameter("@PassEncr", SqlDbType.NVarChar);
            passEncrParameter.Value = encryptHelper.Sha256Encrypt(cliente.Password);

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = cliente.Activo;

            parameters.Add(idUsuarioParameter);
            parameters.Add(apellidoParameter);
            parameters.Add(nombreParameter);
            parameters.Add(tipoDocParameter);
            parameters.Add(nroDocParameter);
            parameters.Add(mailParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(calleParameter);
            parameters.Add(nroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(localidadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(fechaNacimientoParameter);
            parameters.Add(passEncrParameter);
            parameters.Add(activoParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_UpdateCliente", parameters);
        }

        public static void UpdateEmpresa(Empresa empresa)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateEmpresa(empresa, db);

                List<Rol> roles = GetRolesUsuario(empresa.IdUsuario, db);

                foreach (Rol rol in empresa.Roles)
                {
                    if (!roles.Exists(x => x.IdRol == rol.IdRol))
                        InsertUsuarioRol(empresa.IdUsuario, rol.IdRol, true, db);
                }

                foreach (Rol rol in roles)
                {
                    if (!empresa.Roles.Exists(x => x.IdRol == rol.IdRol))
                        DeleteUsuarioRol(empresa.IdUsuario, rol.IdRol, db);
                }

                db.EndConnection();
            }
        }

        private static void UpdateEmpresa(Empresa empresa, DataBaseHelper db)
        {
            EncryptHelper encryptHelper = new EncryptHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = empresa.IdUsuario;

            SqlParameter razonSocialParameter = new SqlParameter("@RazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = empresa.RazonSocial.Trim();

            SqlParameter mailParameter = new SqlParameter("@Mail", SqlDbType.NVarChar);
            mailParameter.Value = empresa.Email.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = empresa.Telefono.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = empresa.Calle.Trim();

            SqlParameter nroParameter = new SqlParameter("@Nro", SqlDbType.Int);
            nroParameter.Value = empresa.NroCalle;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = empresa.Piso;

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = empresa.Departamento.Trim();

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = empresa.Localidad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = empresa.CodigoPostal.Trim();

            SqlParameter ciudadParameter = new SqlParameter("@Ciudad", SqlDbType.NVarChar);
            ciudadParameter.Value = empresa.Ciudad.Trim();

            SqlParameter cuitParameter = new SqlParameter("@CUIT", SqlDbType.NVarChar);
            cuitParameter.Value = empresa.Cuit.Trim();

            SqlParameter contactoParameter = new SqlParameter("@Contacto", SqlDbType.NVarChar);
            contactoParameter.Value = empresa.Contacto.Trim();

            SqlParameter rubroParameter = new SqlParameter("@Rubro", SqlDbType.NVarChar);
            rubroParameter.Value = empresa.Rubro.Trim();

            SqlParameter passEncrParameter = new SqlParameter("@PassEncr", SqlDbType.NVarChar);
            passEncrParameter.Value = encryptHelper.Sha256Encrypt(empresa.Password);

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = empresa.Activo;

            parameters.Add(idUsuarioParameter);
            parameters.Add(razonSocialParameter);
            parameters.Add(mailParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(calleParameter);
            parameters.Add(nroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(localidadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(ciudadParameter);
            parameters.Add(cuitParameter);
            parameters.Add(contactoParameter);
            parameters.Add(rubroParameter);
            parameters.Add(passEncrParameter);
            parameters.Add(activoParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_UpdateEmpresa", parameters);
        }

        private static void DeleteUsuarioRol(int idUsuario, int idRol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = idRol;

            parameters.Add(idRolParameter);
            parameters.Add(idUsuarioParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_DeleteUsuarioRol", parameters);
        }

        public static Cliente GetClienteByTipoDocNroDoc(string tipoDoc, string nroDoc)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Cliente cliente = GetClienteByTipoDocNroDoc(tipoDoc, nroDoc, db);

                db.EndConnection();

                return cliente;
            }
        }

        private static Cliente GetClienteByTipoDocNroDoc(string tipoDoc, string nroDoc, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter tipoDocParameter = new SqlParameter("@TipoDoc", SqlDbType.NVarChar);
            tipoDocParameter.Value = tipoDoc.Trim();

            SqlParameter nroDocParameter = new SqlParameter("@NroDoc", SqlDbType.Int);
            nroDocParameter.Value = Convert.ToInt32(nroDoc);

            parameters.Add(tipoDocParameter);
            parameters.Add(nroDocParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetClienteByTipoDocNroDoc", parameters);
            Cliente cliente = new Cliente();
            foreach (DataRow row in res.Rows)
            {
                cliente.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                cliente.Nombre = Convert.ToString(row["Nombre"]);
                cliente.Apellido = Convert.ToString(row["Apellido"]);
                cliente.Calle = Convert.ToString(row["Calle"]);
                cliente.NroCalle = Convert.ToInt32(row["NroCalle"]);
                cliente.CodigoPostal = Convert.ToString(row["CodigoPostal"]);
                cliente.Departamento = Convert.ToString(row["Departamento"]);
                cliente.Email = Convert.ToString(row["Email"]);
                cliente.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                cliente.Localidad = Convert.ToString(row["Localidad"]);
                cliente.NumeroDoc = Convert.ToInt32(row["NroDoc"]);
                cliente.Piso = Convert.ToInt32(row["Piso"]);
                cliente.Telefono = Convert.ToString(row["Telefono"]);
                cliente.TipoDoc = Convert.ToString(row["TipoDoc"]);
                cliente.UserName = Convert.ToString(row["UserName"]);
                cliente.Activo = Convert.ToBoolean(row["Activo"]);
                cliente.Password = Convert.ToString(row["PasswordEnc"]);
            }

            return cliente;
        }

        public static Empresa GetEmpresaByRazonSocial(string razonSocial)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Empresa empresa = GetEmpresaByRazonSocial(razonSocial, db);

                db.EndConnection();

                return empresa;
            }
        }

        private static Empresa GetEmpresaByRazonSocial(string razonSocial, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter razonSocialParameter = new SqlParameter("@RazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = razonSocial.Trim();

            parameters.Add(razonSocialParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetEmpresaByRazonSocial", parameters);
            Empresa empresa = new Empresa();
            foreach (DataRow row in res.Rows)
            {
                empresa.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                empresa.UserName = Convert.ToString(row["UserName"]);
                empresa.Activo = Convert.ToBoolean(row["Activo"]);
                empresa.Password = Convert.ToString(row["PasswordEnc"]);
                empresa.Calle = Convert.ToString(row["Calle"]);
                empresa.Ciudad = Convert.ToString(row["Ciudad"]);
                empresa.CodigoPostal = Convert.ToString(row["CodigoPostal"]);
                empresa.Contacto = Convert.ToString(row["Contacto"]);
                empresa.Cuit = Convert.ToString(row["Cuit"]);
                empresa.Departamento = Convert.ToString(row["Departamento"]);
                empresa.Email = Convert.ToString(row["Email"]);
                empresa.Localidad = Convert.ToString(row["Localidad"]);
                empresa.NroCalle = Convert.ToInt32(row["NroCalle"]);
                empresa.Piso = Convert.ToInt32(row["Piso"]);
                empresa.RazonSocial = Convert.ToString(row["RazonSocial"]);
                empresa.Rubro = Convert.ToString(row["Rubro"]);
                empresa.Telefono = Convert.ToString(row["Telefono"]);
            }

            return empresa;
        }

        public static Empresa GetEmpresaByCuit(string cuit)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                Empresa empresa = GetEmpresaByCuit(cuit, db);

                db.EndConnection();

                return empresa;
            }
        }

        private static Empresa GetEmpresaByCuit(string cuit, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter cuitParameter = new SqlParameter("@CUIT", SqlDbType.NVarChar);
            cuitParameter.Value = cuit.Trim();

            parameters.Add(cuitParameter);

            DataTable res = db.GetDataAsTable("MASTERDBA.SP_GetEmpresaByCUIT", parameters);
            Empresa empresa = new Empresa();
            foreach (DataRow row in res.Rows)
            {
                empresa.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                empresa.UserName = Convert.ToString(row["UserName"]);
                empresa.Activo = Convert.ToBoolean(row["Activo"]);
                empresa.Password = Convert.ToString(row["PasswordEnc"]);
                empresa.Calle = Convert.ToString(row["Calle"]);
                empresa.Ciudad = Convert.ToString(row["Ciudad"]);
                empresa.CodigoPostal = Convert.ToString(row["CodigoPostal"]);
                empresa.Contacto = Convert.ToString(row["Contacto"]);
                empresa.Cuit = Convert.ToString(row["Cuit"]);
                empresa.Departamento = Convert.ToString(row["Departamento"]);
                empresa.Email = Convert.ToString(row["Email"]);
                empresa.Localidad = Convert.ToString(row["Localidad"]);
                empresa.NroCalle = Convert.ToInt32(row["NroCalle"]);
                empresa.Piso = Convert.ToInt32(row["Piso"]);
                empresa.RazonSocial = Convert.ToString(row["RazonSocial"]);
                empresa.Rubro = Convert.ToString(row["Rubro"]);
                empresa.Telefono = Convert.ToString(row["Telefono"]);
            }

            return empresa;
        }

        public static void DeleteUsuario(Usuario usuario)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                DeleteUsuario(usuario.IdUsuario, db);

                db.EndConnection();
            }
        }

        private static void DeleteUsuario(int idUsuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idUsuarioParameter.Value = idUsuario;

            parameters.Add(idUsuarioParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "MASTERDBA.SP_DeleteUsuario", parameters);
        }
    }
}
