
using System;
// Definición clase ValoracionEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class ValoracionEN
{
/**
 *	Atributo idValoracion
 */
private int idValoracion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo valoracion
 */
private int valoracion;



/**
 *	Atributo tipoValoracion
 */
private Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum tipoValoracion;



/**
 *	Atributo usuario
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario;



/**
 *	Atributo idDestinatario
 */
private int idDestinatario;






public virtual int IdValoracion {
        get { return idValoracion; } set { idValoracion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual int Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum TipoValoracion {
        get { return tipoValoracion; } set { tipoValoracion = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int IdDestinatario {
        get { return idDestinatario; } set { idDestinatario = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int idValoracion, string comentario, int valoracion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum tipoValoracion, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, int idDestinatario
                    )
{
        this.init (IdValoracion, comentario, valoracion, tipoValoracion, usuario, idDestinatario);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.IdValoracion, valoracion.Comentario, valoracion.Valoracion, valoracion.TipoValoracion, valoracion.Usuario, valoracion.IdDestinatario);
}

private void init (int idValoracion
                   , string comentario, int valoracion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum tipoValoracion, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN usuario, int idDestinatario)
{
        this.IdValoracion = idValoracion;


        this.Comentario = comentario;

        this.Valoracion = valoracion;

        this.TipoValoracion = tipoValoracion;

        this.Usuario = usuario;

        this.IdDestinatario = idDestinatario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (IdValoracion.Equals (t.IdValoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdValoracion.GetHashCode ();
        return hash;
}
}
}
