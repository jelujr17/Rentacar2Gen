

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class ReservaCEN
 *
 */
public partial class ReservaCEN
{
private IReservaRepository _IReservaRepository;

public ReservaCEN(IReservaRepository _IReservaRepository)
{
        this._IReservaRepository = _IReservaRepository;
}

public IReservaRepository get_IReservaRepository ()
{
        return this._IReservaRepository;
}

public int NuevaReserva (int p_coche, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, int p_usuario, Nullable<DateTime> p_fechaPago)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();

        if (p_coche != -1) {
                // El argumento p_coche -> Property coche es oid = false
                // Lista de oids idReserva
                reservaEN.Coche = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN ();
                reservaEN.Coche.Id = p_coche;
        }

        reservaEN.FechaInicio = p_fechaInicio;

        reservaEN.FechaFin = p_fechaFin;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idReserva
                reservaEN.Usuario = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
                reservaEN.Usuario.IdUsuario = p_usuario;
        }

        reservaEN.FechaPago = p_fechaPago;



        oid = _IReservaRepository.NuevaReserva (reservaEN);
        return oid;
}

public void Modificar (int p_Reserva_OID, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, Nullable<DateTime> p_fechaPago)
{
        ReservaEN reservaEN = null;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();
        reservaEN.IdReserva = p_Reserva_OID;
        reservaEN.FechaInicio = p_fechaInicio;
        reservaEN.FechaFin = p_fechaFin;
        reservaEN.FechaPago = p_fechaPago;
        //Call to ReservaRepository

        _IReservaRepository.Modificar (reservaEN);
}

public void EliminarReserva (int idReserva
                             )
{
        _IReservaRepository.EliminarReserva (idReserva);
}

public ReservaEN ObtenReservaId (int idReserva
                                 )
{
        ReservaEN reservaEN = null;

        reservaEN = _IReservaRepository.ObtenReservaId (idReserva);
        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ObtenerReservas (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> list = null;

        list = _IReservaRepository.ObtenerReservas (first, size);
        return list;
}
}
}
