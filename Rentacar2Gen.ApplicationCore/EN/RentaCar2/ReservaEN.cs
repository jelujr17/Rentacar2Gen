
using System;
// Definición clase ReservaEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class ReservaEN
{
/**
 *	Atributo idReserva
 */
private int idReserva;



/**
 *	Atributo coche
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN coche;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo usuario
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario;



/**
 *	Atributo fechaPago
 */
private Nullable<DateTime> fechaPago;






public virtual int IdReserva {
        get { return idReserva; } set { idReserva = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN Coche {
        get { return coche; } set { coche = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}





public ReservaEN()
{
}



public ReservaEN(int idReserva, Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN coche, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, Nullable<DateTime> fechaPago
                 )
{
        this.init (IdReserva, coche, fechaInicio, fechaFin, usuario, fechaPago);
}


public ReservaEN(ReservaEN reserva)
{
        this.init (reserva.IdReserva, reserva.Coche, reserva.FechaInicio, reserva.FechaFin, reserva.Usuario, reserva.FechaPago);
}

private void init (int idReserva
                   , Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN coche, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, Nullable<DateTime> fechaPago)
{
        this.IdReserva = idReserva;


        this.Coche = coche;

        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;

        this.Usuario = usuario;

        this.FechaPago = fechaPago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReservaEN t = obj as ReservaEN;
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
