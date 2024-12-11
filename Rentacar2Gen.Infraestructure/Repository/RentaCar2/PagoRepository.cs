
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
 * Clase Pago:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class PagoRepository : BasicRepository, IPagoRepository
{
public PagoRepository() : base ()
{
}


public PagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PagoEN ReadOIDDefault (int idReserva
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoNH), idReserva);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoNH)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdReserva);

                pagoNH.FechaPago = pago.FechaPago;

                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevoPago (PagoEN pago)
{
        PagoNH pagoNH = new PagoNH (pago);

        try
        {
                SessionInitializeTransaction ();
                if (pago.Coche != null) {
                        // Argumento OID y no colección.
                        pagoNH
                        .Coche = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN), pago.Coche.Id);

                        pagoNH.Coche.ReservaActiva
                                = pagoNH;
                }
                if (pago.Usuario != null) {
                        // Argumento OID y no colección.
                        pagoNH
                        .Usuario = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN), pago.Usuario.IdUsuario);

                        pagoNH.Usuario.Reservas
                        .Add (pagoNH);
                }

                session.Save (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoNH.IdReserva;
}

public void Modificar (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdReserva);

                pagoNH.FechaInicio = pago.FechaInicio;


                pagoNH.FechaFin = pago.FechaFin;


                pagoNH.FechaPago = pago.FechaPago;

                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarPago (int idReserva
                          )
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), idReserva);
                session.Delete (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
