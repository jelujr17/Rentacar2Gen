
using System;
// Definición clase MensajesEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class MensajesEN
{
/**
 *	Atributo idMensaje
 */
private int idMensaje;



/**
 *	Atributo usuario
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario;



/**
 *	Atributo usuarioReceptor
 */
private int usuarioReceptor;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int IdMensaje {
        get { return idMensaje; } set { idMensaje = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int UsuarioReceptor {
        get { return usuarioReceptor; } set { usuarioReceptor = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public MensajesEN()
{
}



public MensajesEN(int idMensaje, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, int usuarioReceptor, string mensaje, Nullable<DateTime> fecha
                  )
{
        this.init (IdMensaje, usuario, usuarioReceptor, mensaje, fecha);
}


public MensajesEN(MensajesEN mensajes)
{
        this.init (mensajes.IdMensaje, mensajes.Usuario, mensajes.UsuarioReceptor, mensajes.Mensaje, mensajes.Fecha);
}

private void init (int idMensaje
                   , Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, int usuarioReceptor, string mensaje, Nullable<DateTime> fecha)
{
        this.IdMensaje = idMensaje;


        this.Usuario = usuario;

        this.UsuarioReceptor = usuarioReceptor;

        this.Mensaje = mensaje;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajesEN t = obj as MensajesEN;
        if (t == null)
                return false;
        if (IdMensaje.Equals (t.IdMensaje))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdMensaje.GetHashCode ();
        return hash;
}
}
}
