
using System;
// Definición clase NotificacionesEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class NotificacionesEN
{
/**
 *	Atributo idNotificacion
 */
private int idNotificacion;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuario;






public virtual int IdNotificacion {
        get { return idNotificacion; } set { idNotificacion = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public NotificacionesEN()
{
        usuario = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN>();
}



public NotificacionesEN(int idNotificacion, string mensaje, Nullable<DateTime> fecha, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuario
                        )
{
        this.init (IdNotificacion, mensaje, fecha, usuario);
}


public NotificacionesEN(NotificacionesEN notificaciones)
{
        this.init (notificaciones.IdNotificacion, notificaciones.Mensaje, notificaciones.Fecha, notificaciones.Usuario);
}

private void init (int idNotificacion
                   , string mensaje, Nullable<DateTime> fecha, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuario)
{
        this.IdNotificacion = idNotificacion;


        this.Mensaje = mensaje;

        this.Fecha = fecha;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionesEN t = obj as NotificacionesEN;
        if (t == null)
                return false;
        if (IdNotificacion.Equals (t.IdNotificacion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdNotificacion.GetHashCode ();
        return hash;
}
}
}
