
using System;
// Definición clase UsuarioEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class UsuarioEN
{
/**
 *	Atributo idUsuario
 */
private int idUsuario;



/**
 *	Atributo correo
 */
private string correo;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo fechaNacimiento
 */
private Nullable<DateTime> fechaNacimiento;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo favoritos
 */
private string favoritos;



/**
 *	Atributo cochePropiedad
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochePropiedad;



/**
 *	Atributo cochesFavoritos
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochesFavoritos;



/**
 *	Atributo reservas
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> reservas;



/**
 *	Atributo notificaciones
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.NotificacionesEN> notificaciones;



/**
 *	Atributo mensajes
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.MensajesEN> mensajes;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN> valoracion;






public virtual int IdUsuario {
        get { return idUsuario; } set { idUsuario = value;  }
}



public virtual string Correo {
        get { return correo; } set { correo = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Favoritos {
        get { return favoritos; } set { favoritos = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> CochePropiedad {
        get { return cochePropiedad; } set { cochePropiedad = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> CochesFavoritos {
        get { return cochesFavoritos; } set { cochesFavoritos = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> Reservas {
        get { return reservas; } set { reservas = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.NotificacionesEN> Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.MensajesEN> Mensajes {
        get { return mensajes; } set { mensajes = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}





public UsuarioEN()
{
        cochePropiedad = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
        cochesFavoritos = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
        reservas = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN>();
        notificaciones = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.NotificacionesEN>();
        mensajes = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.MensajesEN>();
        valoracion = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN>();
}



public UsuarioEN(int idUsuario, string correo, String pass, string foto, Nullable<DateTime> fechaNacimiento, int telefono, string direccion, string favoritos, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochePropiedad, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochesFavoritos, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> reservas, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.NotificacionesEN> notificaciones, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.MensajesEN> mensajes, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN> valoracion
                 )
{
        this.init (IdUsuario, correo, pass, foto, fechaNacimiento, telefono, direccion, favoritos, cochePropiedad, cochesFavoritos, reservas, notificaciones, mensajes, valoracion);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.IdUsuario, usuario.Correo, usuario.Pass, usuario.Foto, usuario.FechaNacimiento, usuario.Telefono, usuario.Direccion, usuario.Favoritos, usuario.CochePropiedad, usuario.CochesFavoritos, usuario.Reservas, usuario.Notificaciones, usuario.Mensajes, usuario.Valoracion);
}

private void init (int idUsuario
                   , string correo, String pass, string foto, Nullable<DateTime> fechaNacimiento, int telefono, string direccion, string favoritos, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochePropiedad, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> cochesFavoritos, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> reservas, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.NotificacionesEN> notificaciones, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.MensajesEN> mensajes, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN> valoracion)
{
        this.IdUsuario = idUsuario;


        this.Correo = correo;

        this.Pass = pass;

        this.Foto = foto;

        this.FechaNacimiento = fechaNacimiento;

        this.Telefono = telefono;

        this.Direccion = direccion;

        this.Favoritos = favoritos;

        this.CochePropiedad = cochePropiedad;

        this.CochesFavoritos = cochesFavoritos;

        this.Reservas = reservas;

        this.Notificaciones = notificaciones;

        this.Mensajes = mensajes;

        this.Valoracion = valoracion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (IdUsuario.Equals (t.IdUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdUsuario.GetHashCode ();
        return hash;
}
}
}
