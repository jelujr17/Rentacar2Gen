
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
 * Clase Mensajes:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class MensajesRepository : BasicRepository, IMensajesRepository
{
public MensajesRepository() : base ()
{
}


public MensajesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MensajesEN ReadOIDDefault (int idMensaje
                                  )
{
        MensajesEN mensajesEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajesEN = (MensajesEN)session.Get (typeof(MensajesNH), idMensaje);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajesEN;
}

public System.Collections.Generic.IList<MensajesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajesEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajesNH)).List<MensajesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MensajesEN mensajes)
{
        try
        {
                SessionInitializeTransaction ();
                MensajesNH mensajesNH = (MensajesNH)session.Load (typeof(MensajesNH), mensajes.IdMensaje);


                mensajesNH.UsuarioReceptor = mensajes.UsuarioReceptor;


                mensajesNH.Mensaje = mensajes.Mensaje;


                mensajesNH.Fecha = mensajes.Fecha;

                session.Update (mensajesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevoMensaje (MensajesEN mensajes)
{
        MensajesNH mensajesNH = new MensajesNH (mensajes);

        try
        {
                SessionInitializeTransaction ();
                if (mensajes.Usuario != null) {
                        // Argumento OID y no colección.
                        mensajesNH
                        .Usuario = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN), mensajes.Usuario.IdUsuario);

                        mensajesNH.Usuario.Mensajes
                        .Add (mensajesNH);
                }

                session.Save (mensajesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajesNH.IdMensaje;
}

public void Modificar (MensajesEN mensajes)
{
        try
        {
                SessionInitializeTransaction ();
                MensajesNH mensajesNH = (MensajesNH)session.Load (typeof(MensajesNH), mensajes.IdMensaje);

                mensajesNH.UsuarioReceptor = mensajes.UsuarioReceptor;


                mensajesNH.Mensaje = mensajes.Mensaje;


                mensajesNH.Fecha = mensajes.Fecha;

                session.Update (mensajesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarMensaje (int idMensaje
                             )
{
        try
        {
                SessionInitializeTransaction ();
                MensajesNH mensajesNH = (MensajesNH)session.Load (typeof(MensajesNH), idMensaje);
                session.Delete (mensajesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
