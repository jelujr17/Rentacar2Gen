
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
 * Clase Notificaciones:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class NotificacionesRepository : BasicRepository, INotificacionesRepository
{
public NotificacionesRepository() : base ()
{
}


public NotificacionesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public NotificacionesEN ReadOIDDefault (int idNotificacion
                                        )
{
        NotificacionesEN notificacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionesEN = (NotificacionesEN)session.Get (typeof(NotificacionesNH), idNotificacion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesEN;
}

public System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionesEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionesNH)).List<NotificacionesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesNH notificacionesNH = (NotificacionesNH)session.Load (typeof(NotificacionesNH), notificaciones.IdNotificacion);

                notificacionesNH.Mensaje = notificaciones.Mensaje;


                notificacionesNH.Fecha = notificaciones.Fecha;


                session.Update (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevaNotificacion (NotificacionesEN notificaciones)
{
        NotificacionesNH notificacionesNH = new NotificacionesNH (notificaciones);

        try
        {
                SessionInitializeTransaction ();
                if (notificaciones.Usuario != null) {
                        for (int i = 0; i < notificaciones.Usuario.Count; i++) {
                                notificaciones.Usuario [i] = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN), notificaciones.Usuario [i].IdUsuario);
                                notificaciones.Usuario [i].Notificaciones.Add (notificacionesNH);
                        }
                }

                session.Save (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesNH.IdNotificacion;
}

public void Modificar (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesNH notificacionesNH = (NotificacionesNH)session.Load (typeof(NotificacionesNH), notificaciones.IdNotificacion);

                notificacionesNH.Mensaje = notificaciones.Mensaje;


                notificacionesNH.Fecha = notificaciones.Fecha;

                session.Update (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarNotificacion (int idNotificacion
                                  )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesNH notificacionesNH = (NotificacionesNH)session.Load (typeof(NotificacionesNH), idNotificacion);
                session.Delete (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
