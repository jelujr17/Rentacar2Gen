
using System;
using System.Text;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;
using Rentacar2Gen.Infraestructure.EN.RentaCar2;


/*
 * Clase Usuario:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
{
public UsuarioRepository() : base ()
{
}


public UsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioEN ReadOIDDefault (int idUsuario
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), idUsuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.IdUsuario);

                usuarioNH.Correo = usuario.Correo;


                usuarioNH.Pass = usuario.Pass;


                usuarioNH.Foto = usuario.Foto;


                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;


                usuarioNH.Telefono = usuario.Telefono;


                usuarioNH.Direccion = usuario.Direccion;


                usuarioNH.Favoritos = usuario.Favoritos;







                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevoUsuario (UsuarioEN usuario)
{
        UsuarioNH usuarioNH = new UsuarioNH (usuario);

        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioNH.IdUsuario;
}

public void Modificar (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.IdUsuario);

                usuarioNH.Correo = usuario.Correo;


                usuarioNH.Pass = usuario.Pass;


                usuarioNH.Foto = usuario.Foto;


                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;


                usuarioNH.Telefono = usuario.Telefono;


                usuarioNH.Direccion = usuario.Direccion;


                usuarioNH.Favoritos = usuario.Favoritos;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarUsuario (int idUsuario
                             )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), idUsuario);
                session.Delete (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ObtenUsuarioId
//Con e: UsuarioEN
public UsuarioEN ObtenUsuarioId (int idUsuario
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), idUsuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}


        public UsuarioEN GetByCorreo(string correo)
        {
            UsuarioEN usuarioEN = null;

            try
            {
                SessionInitializeTransaction();
                usuarioEN = session.CreateCriteria<UsuarioNH>()
                                   .Add(Restrictions.Eq("Correo", correo))
                                   .UniqueResult<UsuarioEN>();
                SessionCommit();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }

            return usuarioEN;
        }


        public System.Collections.Generic.IList<UsuarioEN> ObtenerUsuarios (int first, int size)
{
System.Collections.Generic.IList<UsuarioEN> result = null;
try
{
        SessionInitializeTransaction ();
        if (size > 0)
                result = session.CreateCriteria (typeof(UsuarioNH)).
                            SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
        else
                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
        SessionCommit ();
}

catch (Exception ex) {
        SessionRollBack ();
        if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                throw;
        else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
}


finally
{
        SessionClose ();
}

return result;
}
}
}
