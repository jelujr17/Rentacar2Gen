

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoRepository _IPagoRepository;

public PagoCEN(IPagoRepository _IPagoRepository)
{
        this._IPagoRepository = _IPagoRepository;
}

public IPagoRepository get_IPagoRepository ()
{
        return this._IPagoRepository;
}

public int NuevoPago (int p_coche, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, int p_usuario, Nullable<DateTime> p_fechaPago)
{
        PagoEN pagoEN = null;
        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();

        if (p_coche != -1) {
                // El argumento p_coche -> Property coche es oid = false
                // Lista de oids idReserva
                pagoEN.Coche = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN ();
                pagoEN.Coche.Id = p_coche;
        }

        pagoEN.FechaInicio = p_fechaInicio;

        pagoEN.FechaFin = p_fechaFin;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idReserva
                pagoEN.Usuario = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
                pagoEN.Usuario.IdUsuario = p_usuario;
        }

        pagoEN.FechaPago = p_fechaPago;



        oid = _IPagoRepository.NuevoPago (pagoEN);
        return oid;
}

public void Modificar (int p_Pago_OID, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, Nullable<DateTime> p_fechaPago)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.IdReserva = p_Pago_OID;
        pagoEN.FechaInicio = p_fechaInicio;
        pagoEN.FechaFin = p_fechaFin;
        pagoEN.FechaPago = p_fechaPago;
        //Call to PagoRepository

        _IPagoRepository.Modificar (pagoEN);
}

public void EliminarPago (int idReserva
                          )
{
        _IPagoRepository.EliminarPago (idReserva);
}
}
}
