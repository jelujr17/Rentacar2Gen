
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
 * Clase Reserva:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class ReservaRepository : BasicRepository, IReservaRepository
{
public ReservaRepository() : base ()
{
}


public ReservaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ReservaEN ReadOIDDefault (int idReserva
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaNH), idReserva);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReservaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReservaNH)).List<ReservaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), reserva.IdReserva);


                reservaNH.FechaInicio = reserva.FechaInicio;


                reservaNH.FechaFin = reserva.FechaFin;



                reservaNH.FechaPago = reserva.FechaPago;

                session.Update (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevaReserva (ReservaEN reserva)
{
        ReservaNH reservaNH = new ReservaNH (reserva);

        try
        {
                SessionInitializeTransaction ();
                if (reserva.Coche != null) {
                        // Argumento OID y no colección.
                        reservaNH
                        .Coche = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN), reserva.Coche.Id);

                        reservaNH.Coche.ReservaActiva
                                = reservaNH;
                }
                if (reserva.Usuario != null) {
                        // Argumento OID y no colección.
                        reservaNH
                        .Usuario = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN), reserva.Usuario.IdUsuario);

                        reservaNH.Usuario.Reservas
                        .Add (reservaNH);
                }

                session.Save (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaNH.IdReserva;
}

public void Modificar (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), reserva.IdReserva);

                reservaNH.FechaInicio = reserva.FechaInicio;


                reservaNH.FechaFin = reserva.FechaFin;


                reservaNH.FechaPago = reserva.FechaPago;

                session.Update (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarReserva (int idReserva
                             )
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), idReserva);
                session.Delete (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ObtenReservaId
//Con e: ReservaEN
public ReservaEN ObtenReservaId (int idReserva
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaNH), idReserva);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ObtenerReservas (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReservaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                else
                        result = session.CreateCriteria (typeof(ReservaNH)).List<ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
