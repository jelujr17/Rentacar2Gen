
using System;
// Definición clase PagoEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class PagoEN                                                                 : Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN


{
/**
 *	Atributo fechaPago
 */
private Nullable<DateTime> fechaPago;






public virtual Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}





public PagoEN() : base ()
{
}



public PagoEN(int idReserva, Nullable<DateTime> fechaPago
              , Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN coche, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario
              )
{
        this.init (IdReserva, fechaPago, coche, fechaInicio, fechaFin, usuario);
}


public PagoEN(PagoEN pago)
{
        this.init (pago.IdReserva, pago.FechaPago, pago.Coche, pago.FechaInicio, pago.FechaFin, pago.Usuario);
}

private void init (int idReserva
                   , Nullable<DateTime> fechaPago, Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN coche, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario)
{
        this.IdReserva = idReserva;


        this.FechaPago = fechaPago;

        this.Coche = coche;

        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
        if (t == null)
                return false;
        if (IdReserva.Equals (t.IdReserva))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdReserva.GetHashCode ();
        return hash;
}
}
}
