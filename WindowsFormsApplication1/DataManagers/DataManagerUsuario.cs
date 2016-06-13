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

            DataTable res = db.GetDataAsTable("SP_GetUsuarioByUserName", parameters);
            Usuario usuario = new Usuario();
            foreach (DataRow row in res.Rows)
            {
                usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                usuario.UserName = Convert.ToString(row["UserName"]);
                usuario.Password = Convert.ToString(row["PassEncr"]);
                usuario.CantIntFallidos = Convert.ToByte(row["CantIntFallidos"]);
                usuario.Activo = Convert.ToBoolean(row["Activo"]);
            }

            return usuario;
        }

        private static void BloqUser(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_BloqUser", parameters);
        }

        private static object IncrementCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            return db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_IncrementCountLogin", parameters);
        }

        private static void ResetCountLogin(string userName, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar);
            userNameParameter.Value = userName;

            parameters.Add(userNameParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_ResetCountLogin", parameters);
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

            DataTable res = db.GetDataAsTable("SP_FindClientes", parameters);
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

                usuario.Roles = GetRolesUsuario(usuario,db);

                usuarios.Add(usuario);
            }

            return usuarios;

        }

        private static List<Rol> GetRolesUsuario(Usuario usuario, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = usuario.IdUsuario;

            parameters.Add(idUsuarioParameter);

            DataTable res = db.GetDataAsTable("SP_GetRolesUsuario", parameters);
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

            DataTable res = db.GetDataAsTable("SP_FindEmpresas", parameters);
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

                usuario.Roles = GetRolesUsuario(usuario, db);

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

                InsertEmpresa(newEmpresa, db);
                newEmpresa.Roles.Add(RolesServices.GetRolByDescription("Empresa"));

                foreach (Rol rol in newEmpresa.Roles)
                {
                    InsertRolUsuario(newEmpresa, rol, true, db);
                }

                db.EndConnection();
            }
        }

        private static void InsertEmpresa(Empresa newEmpresa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter razonSocialParameter = new SqlParameter("@RazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = newEmpresa.RazonSocial.Trim();

            //SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            //activoParameter.Value = newEmpresa.Activo;

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = newEmpresa.Calle.Trim();

            SqlParameter ciudadParameter = new SqlParameter("@Ciudad", SqlDbType.NVarChar);
            ciudadParameter.Value = newEmpresa.Ciudad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = newEmpresa.CodigoPostal.Trim();

            SqlParameter contactoParameter = new SqlParameter("@Contato", SqlDbType.NVarChar);
            contactoParameter.Value = newEmpresa.Contacto.Trim();

            SqlParameter cuitParameter = new SqlParameter("@Cuit", SqlDbType.NVarChar);
            cuitParameter.Value = newEmpresa.Cuit.Trim();

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = newEmpresa.Departamento.Trim();

            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            emailParameter.Value = newEmpresa.Email.Trim();

            SqlParameter rubroParameter = new SqlParameter("@Rubro", SqlDbType.NVarChar);
            rubroParameter.Value = newEmpresa.Rubro.Trim();

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = newEmpresa.Piso;

            SqlParameter nroCalleParameter = new SqlParameter("@NroCalle", SqlDbType.Int);
            nroCalleParameter.Value = newEmpresa.NroCalle;

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = newEmpresa.Localidad.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = newEmpresa.Telefono.Trim();

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now;

            parameters.Add(razonSocialParameter);
            //parameters.Add(activoParameter);
            parameters.Add(calleParameter);
            parameters.Add(ciudadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(contactoParameter);
            parameters.Add(cuitParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(emailParameter);
            parameters.Add(rubroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(nroCalleParameter);
            parameters.Add(localidadParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(fechaCreacionParameter);

            newEmpresa.IdUsuario = (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_InsertEmpresa", parameters);
        }

        public static void SaveNewCliente(Cliente newCliente)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                InsertCliente(newCliente, db);
                newCliente.Roles.Add(RolesServices.GetRolByDescription("Cliente"));

                foreach (Rol rol in newCliente.Roles)
                {
                    InsertRolUsuario(newCliente, rol, true, db);
                }

                db.EndConnection();
            }
        }

        private static void InsertRolUsuario(Usuario usuario, Rol rol, bool activa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = usuario.IdUsuario;

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = rol.IdRol;

            SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            activoParameter.Value = activa;

            parameters.Add(idRolParameter);
            parameters.Add(idUsuarioParameter);
            parameters.Add(activoParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_InsertRolUsuario", parameters);
        }

        private static void InsertCliente(Cliente newCliente, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter nombreParameter = new SqlParameter("@Nombre", SqlDbType.NVarChar);
            nombreParameter.Value = newCliente.Nombre.Trim();

            //SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            //activoParameter.Value = newCliente.Activo;

            SqlParameter apellidoParameter = new SqlParameter("@Apellido", SqlDbType.NVarChar);
            apellidoParameter.Value = newCliente.Apellido.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = newCliente.Calle.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = newCliente.CodigoPostal.Trim();

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = newCliente.Departamento.Trim();

            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            emailParameter.Value = newCliente.Email.Trim();

            SqlParameter fechaNacimientoParameter = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParameter.Value = newCliente.FechaNacimiento.Date;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = newCliente.Piso;

            SqlParameter nroCalleParameter = new SqlParameter("@NroCalle", SqlDbType.Int);
            nroCalleParameter.Value = newCliente.NroCalle;

            SqlParameter tipoDocParameter = new SqlParameter("@TipoDoc", SqlDbType.NVarChar);
            tipoDocParameter.Value = newCliente.TipoDoc.Trim();

            SqlParameter numeroDocParameter = new SqlParameter("@NumeroDoc", SqlDbType.Int);
            numeroDocParameter.Value = newCliente.NumeroDoc;

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = newCliente.Localidad.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = newCliente.Telefono.Trim();

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now;

            parameters.Add(nombreParameter);
            //parameters.Add(activoParameter);
            parameters.Add(apellidoParameter);
            parameters.Add(calleParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(emailParameter);
            parameters.Add(fechaNacimientoParameter);
            parameters.Add(pisoParameter);
            parameters.Add(nroCalleParameter);
            parameters.Add(tipoDocParameter);
            parameters.Add(numeroDocParameter);
            parameters.Add(localidadParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(fechaCreacionParameter);

            newCliente.IdUsuario = (int)db.ExecInstruction(DataBaseHelper.ExecutionType.Scalar, "SP_InsertCliente", parameters);
        }

        public static void UpdateCliente(Cliente cliente)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateCliente(cliente, db);

                List<Rol> roles = GetRolesUsuario(cliente, db);

                foreach (Rol rol in cliente.Roles)
                {
                    if (!roles.Exists(x => x.IdRol == rol.IdRol))
                        InsertRolUsuario(cliente, rol, true, db);
                }

                foreach (Rol rol in roles)
                {
                    if (!cliente.Roles.Exists(x => x.IdRol == rol.IdRol))
                        DeleteRolUsuario(cliente, rol, db);
                }

                db.EndConnection();
            }
        }

        public static void UpdateEmpresa(Empresa empresa)
        {
            DataBaseHelper db = new DataBaseHelper(ConfigurationManager.AppSettings["connectionString"]);

            using (db.Connection)
            {
                db.BeginTransaction();

                UpdateEmpresa(empresa, db);

                List<Rol> roles = GetRolesUsuario(empresa, db);

                foreach (Rol rol in empresa.Roles)
                {
                    if (!roles.Exists(x => x.IdRol == rol.IdRol))
                        InsertRolUsuario(empresa, rol, true, db);
                }

                foreach (Rol rol in roles)
                {
                    if (!empresa.Roles.Exists(x => x.IdRol == rol.IdRol))
                        DeleteRolUsuario(empresa, rol, db);
                }

                db.EndConnection();
            }
        }

        private static void UpdateEmpresa(Empresa empresa, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter razonSocialParameter = new SqlParameter("@RazonSocial", SqlDbType.NVarChar);
            razonSocialParameter.Value = empresa.RazonSocial.Trim();

            //SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            //activoParameter.Value = empresa.Activo;

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = empresa.Calle.Trim();

            SqlParameter ciudadParameter = new SqlParameter("@Ciudad", SqlDbType.NVarChar);
            ciudadParameter.Value = empresa.Ciudad.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = empresa.CodigoPostal.Trim();

            SqlParameter contactoParameter = new SqlParameter("@Contato", SqlDbType.NVarChar);
            contactoParameter.Value = empresa.Contacto.Trim();

            SqlParameter cuitParameter = new SqlParameter("@Cuit", SqlDbType.NVarChar);
            cuitParameter.Value = empresa.Cuit.Trim();

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = empresa.Departamento.Trim();

            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            emailParameter.Value = empresa.Email.Trim();

            SqlParameter rubroParameter = new SqlParameter("@Rubro", SqlDbType.NVarChar);
            rubroParameter.Value = empresa.Rubro.Trim();

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = empresa.Piso;

            SqlParameter nroCalleParameter = new SqlParameter("@NroCalle", SqlDbType.Int);
            nroCalleParameter.Value = empresa.NroCalle;

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = empresa.Localidad.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = empresa.Telefono.Trim();

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now;

            parameters.Add(razonSocialParameter);
            //parameters.Add(activoParameter);
            parameters.Add(calleParameter);
            parameters.Add(ciudadParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(contactoParameter);
            parameters.Add(cuitParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(emailParameter);
            parameters.Add(rubroParameter);
            parameters.Add(pisoParameter);
            parameters.Add(nroCalleParameter);
            parameters.Add(localidadParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(fechaCreacionParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_UpdateEmpresa", parameters);
        }

        private static void DeleteRolUsuario(Usuario usuario, Rol rol, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idUsuarioParameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
            idUsuarioParameter.Value = usuario.IdUsuario;

            SqlParameter idRolParameter = new SqlParameter("@IdRol", SqlDbType.Int);
            idRolParameter.Value = rol.IdRol;

            parameters.Add(idRolParameter);
            parameters.Add(idUsuarioParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_DeleteRolUsuario", parameters);
        }

        private static void UpdateCliente(Cliente cliente, DataBaseHelper db)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter nombreParameter = new SqlParameter("@Nombre", SqlDbType.NVarChar);
            nombreParameter.Value = cliente.Nombre.Trim();

            //SqlParameter activoParameter = new SqlParameter("@Activo", SqlDbType.Bit);
            //activoParameter.Value = cliente.Activo;

            SqlParameter apellidoParameter = new SqlParameter("@Apellido", SqlDbType.NVarChar);
            apellidoParameter.Value = cliente.Apellido.Trim();

            SqlParameter calleParameter = new SqlParameter("@Calle", SqlDbType.NVarChar);
            calleParameter.Value = cliente.Calle.Trim();

            SqlParameter codigoPostalParameter = new SqlParameter("@CodigoPostal", SqlDbType.NVarChar);
            codigoPostalParameter.Value = cliente.CodigoPostal.Trim();

            SqlParameter departamentoParameter = new SqlParameter("@Departamento", SqlDbType.NVarChar);
            departamentoParameter.Value = cliente.Departamento.Trim();

            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            emailParameter.Value = cliente.Email.Trim();

            SqlParameter fechaNacimientoParameter = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParameter.Value = cliente.FechaNacimiento.Date;

            SqlParameter pisoParameter = new SqlParameter("@Piso", SqlDbType.Int);
            pisoParameter.Value = cliente.Piso;

            SqlParameter nroCalleParameter = new SqlParameter("@NroCalle", SqlDbType.Int);
            nroCalleParameter.Value = cliente.NroCalle;

            SqlParameter tipoDocParameter = new SqlParameter("@TipoDoc", SqlDbType.NVarChar);
            tipoDocParameter.Value = cliente.TipoDoc.Trim();

            SqlParameter numeroDocParameter = new SqlParameter("@NumeroDoc", SqlDbType.Int);
            numeroDocParameter.Value = cliente.NumeroDoc;

            SqlParameter localidadParameter = new SqlParameter("@Localidad", SqlDbType.NVarChar);
            localidadParameter.Value = cliente.Localidad.Trim();

            SqlParameter telefonoParameter = new SqlParameter("@Telefono", SqlDbType.NVarChar);
            telefonoParameter.Value = cliente.Telefono.Trim();

            SqlParameter fechaCreacionParameter = new SqlParameter("@FechaCreacion", SqlDbType.DateTime);
            fechaCreacionParameter.Value = DateTime.Now;

            parameters.Add(nombreParameter);
            //parameters.Add(activoParameter);
            parameters.Add(apellidoParameter);
            parameters.Add(calleParameter);
            parameters.Add(codigoPostalParameter);
            parameters.Add(departamentoParameter);
            parameters.Add(emailParameter);
            parameters.Add(fechaNacimientoParameter);
            parameters.Add(pisoParameter);
            parameters.Add(nroCalleParameter);
            parameters.Add(tipoDocParameter);
            parameters.Add(numeroDocParameter);
            parameters.Add(localidadParameter);
            parameters.Add(telefonoParameter);
            parameters.Add(fechaCreacionParameter);

            db.ExecInstruction(DataBaseHelper.ExecutionType.NonQuery, "SP_UpdateCliente", parameters);
        }
    }
}
