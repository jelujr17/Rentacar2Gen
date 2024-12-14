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
using NHibernate.Loader.Custom;

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
    public partial class ValoracionRepository : BasicRepository, IValoracionRepository
    {
        public ValoracionRepository() : base()
        {
        }

        public ValoracionRepository(GenericSessionCP sessionAux) : base(sessionAux)
        {
        }

        public void setSessionCP(GenericSessionCP session)
        {
            this.session = (ISession)session.CurrentSession;
            if (this.session == null)
            {
                throw new InvalidOperationException("La sesión NHibernate no está inicializada.");
            }
        }


        public ValoracionEN ReadOIDDefault(int idValoracion)
        {
            ValoracionEN valoracionEN = null;

            try
            {
                SessionInitializeTransaction();
                valoracionEN = (ValoracionEN)session.Get(typeof(ValoracionNH), idValoracion);
                SessionCommit();
            }
            catch (Exception)
            {
            }
            finally
            {
                SessionClose();
            }

            return valoracionEN;
        }

        public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault(int first, int size)
        {
                            SessionInitializeTransaction();

            System.Collections.Generic.IList<ValoracionEN> result = null;

            if (session == null)
            {
                throw new InvalidOperationException("La sesión NHibernate no está inicializada.");
            }

            using (ITransaction tx = session.BeginTransaction())
            {
                try
                {
                    // Verifica si el tamaño es mayor a 0 y ajusta la consulta
                    if (size > 0)
                    {
                        result = session.CreateCriteria(typeof(ValoracionNH))
                                        .SetFirstResult(first)
                                        .SetMaxResults(size)
                                        .List<ValoracionEN>();
                    }
                    else
                    {
                        result = session.CreateCriteria(typeof(ValoracionNH))
                                        .List<ValoracionEN>();
                    }

                    tx.Commit(); // Confirmar la transacción
                }
                catch (Exception ex)
                {
                    tx.Rollback(); // Revertir la transacción si hay error

                    // Relanzar la excepción con manejo adecuado
                    if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    {
                        throw;
                    }
                    else
                    {
                        throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error en ValoracionRepository.", ex);
                    }
                }
            }

            return result;
        }


        public void ModifyDefault(ValoracionEN valoracion)
        {
            try
            {
                SessionInitializeTransaction();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load(typeof(ValoracionNH), valoracion.IdValoracion);

                valoracionNH.Comentario = valoracion.Comentario;
                valoracionNH.Valoracion = valoracion.Valoracion;
                valoracionNH.TipoValoracion = valoracion.TipoValoracion;
                valoracionNH.IdDestinatario = valoracion.IdDestinatario;

                session.Update(valoracionNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }

        public int NuevaValoracion(ValoracionEN valoracion)
        {
            ValoracionNH valoracionNH = new ValoracionNH(valoracion);

            try
            {
                SessionInitializeTransaction();
                if (valoracion.Usuario != null)
                {
                    valoracionNH.Usuario = valoracion.Usuario;
                }

                session.Save(valoracionNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return valoracionNH.IdValoracion;
        }

        public void Modificar(ValoracionEN valoracion)
        {
            try
            {
                SessionInitializeTransaction();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load(typeof(ValoracionNH), valoracion.IdValoracion);

                valoracionNH.Comentario = valoracion.Comentario;
                valoracionNH.Valoracion = valoracion.Valoracion;
                valoracionNH.TipoValoracion = valoracion.TipoValoracion;
                valoracionNH.IdDestinatario = valoracion.IdDestinatario;

                session.Update(valoracionNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }

        public void EliminarValoracion(int idValoracion)
        {
            try
            {
                SessionInitializeTransaction();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load(typeof(ValoracionNH), idValoracion);
                session.Delete(valoracionNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }

        public ValoracionEN ObtenValoracionId(int idValoracion)
        {
            ValoracionEN valoracionEN = null;

            try
            {
                SessionInitializeTransaction();
                valoracionEN = (ValoracionEN)session.Get(typeof(ValoracionNH), idValoracion);
                SessionCommit();
            }
            catch (Exception)
            {
            }
            finally
            {
                SessionClose();
            }

            return valoracionEN;
        }

        public System.Collections.Generic.IList<ValoracionEN> ObtenerValoraciones(int first, int size)
        {
            System.Collections.Generic.IList<ValoracionEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(ValoracionNH))
                             .SetFirstResult(first).SetMaxResults(size).List<ValoracionEN>();
                else
                    result = session.CreateCriteria(typeof(ValoracionNH)).List<ValoracionEN>();
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }

        public System.Collections.Generic.IList<ValoracionEN> ObtenerValoracionesCoche(int id)
        {
            System.Collections.Generic.IList<ValoracionEN> result = null;
            try
            {
                SessionInitializeTransaction();

                result = session.CreateCriteria(typeof(ValoracionNH))
                                .Add(Restrictions.Eq("IdDestinatario", id))
                                .Add(Restrictions.Eq("TipoValoracion", Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum.coche))
                                .List<ValoracionEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                    throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException("Error in ValoracionRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
