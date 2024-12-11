
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
 * Clase Marca:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class MarcaRepository : BasicRepository, IMarcaRepository
{
public MarcaRepository() : base ()
{
}


public MarcaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MarcaEN ReadOIDDefault (int idMarca
                               )
{
        MarcaEN marcaEN = null;

        try
        {
                SessionInitializeTransaction ();
                marcaEN = (MarcaEN)session.Get (typeof(MarcaNH), idMarca);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return marcaEN;
}

public System.Collections.Generic.IList<MarcaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MarcaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MarcaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MarcaEN>();
                        else
                                result = session.CreateCriteria (typeof(MarcaNH)).List<MarcaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MarcaEN marca)
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), marca.IdMarca);

                marcaNH.Nombre = marca.Nombre;


                session.Update (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevaMarca (MarcaEN marca)
{
        MarcaNH marcaNH = new MarcaNH (marca);

        try
        {
                SessionInitializeTransaction ();

                session.Save (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return marcaNH.IdMarca;
}

public void Modificar (MarcaEN marca)
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), marca.IdMarca);

                marcaNH.Nombre = marca.Nombre;

                session.Update (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarMarca (int idMarca
                           )
{
        try
        {
                SessionInitializeTransaction ();
                MarcaNH marcaNH = (MarcaNH)session.Load (typeof(MarcaNH), idMarca);
                session.Delete (marcaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in MarcaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
