
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
 * Clase Coche:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class CocheRepository : BasicRepository, ICocheRepository
{
public CocheRepository() : base ()
{
}


public CocheRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CocheEN ReadOIDDefault (int id
                               )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CocheNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                        else
                                result = session.CreateCriteria (typeof(CocheNH)).List<CocheEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);

                cocheNH.Matricula = coche.Matricula;


                cocheNH.Imagenes = coche.Imagenes;


                cocheNH.Precio = coche.Precio;


                cocheNH.Plazas = coche.Plazas;


                cocheNH.Tipo = coche.Tipo;


                cocheNH.Descripcion = coche.Descripcion;


                cocheNH.Disponible = coche.Disponible;





                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);

                cocheNH.Matricula = coche.Matricula;


                cocheNH.Imagenes = coche.Imagenes;


                cocheNH.Precio = coche.Precio;


                cocheNH.Plazas = coche.Plazas;


                cocheNH.Tipo = coche.Tipo;


                cocheNH.Descripcion = coche.Descripcion;


                cocheNH.Disponible = coche.Disponible;

                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarCoche (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), id);
                session.Delete (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<CocheEN> ObtenerCoches (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CocheNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                else
                        result = session.CreateCriteria (typeof(CocheNH)).List<CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ObtenCocheId
//Con e: CocheEN
public CocheEN ObtenCocheId (int id
                             )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return cocheEN;
}

public int NuevoCoche (CocheEN coche)
{
        CocheNH cocheNH = new CocheNH (coche);

        try
        {
                SessionInitializeTransaction ();
                if (coche.Propietario != null) {
                        // Argumento OID y no colección.
                        cocheNH
                        .Propietario = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN), coche.Propietario.IdUsuario);

                        cocheNH.Propietario.CochePropiedad
                        .Add (cocheNH);
                }
                if (coche.Marca != null) {
                        // Argumento OID y no colección.
                        cocheNH
                        .Marca = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN), coche.Marca.IdMarca);

                        cocheNH.Marca.Coche
                        .Add (cocheNH);
                }

                session.Save (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheNH.Id;
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXTipo (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum ? tipo)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH WHERE tipo = :tipo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHfiltroXTipoHQL");
                query.SetParameter ("tipo", tipo);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXMarca (string marca)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH c WHERE c.Marca.Nombre = :marca";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHfiltroXMarcaHQL");
                query.SetParameter ("marca", marca);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPlazas (int ? plazas)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH WHERE plazas = :plazas";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHfiltroXPlazasHQL");
                query.SetParameter ("plazas", plazas);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPrecio (double ? precio)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH WHERE precio <= :precio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHfiltroXPrecioHQL");
                query.SetParameter ("precio", precio);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void ReservarCoche (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);
                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DesreservarCoche (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);
                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
