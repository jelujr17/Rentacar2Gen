
using System;
// Definición clase CocheEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class CocheEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo matricula
 */
private string matricula;



/**
 *	Atributo imagenes
 */
private string imagenes;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo plazas
 */
private int plazas;



/**
 *	Atributo tipo
 */
private Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum tipo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo disponible
 */
private Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum disponible;



/**
 *	Atributo propietario
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN propietario;



/**
 *	Atributo usuarioFavorito
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuarioFavorito;



/**
 *	Atributo marca
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN marca;



/**
 *	Atributo reservaActiva
 */
private Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reservaActiva;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Matricula {
        get { return matricula; } set { matricula = value;  }
}



public virtual string Imagenes {
        get { return imagenes; } set { imagenes = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Plazas {
        get { return plazas; } set { plazas = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum Disponible {
        get { return disponible; } set { disponible = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN Propietario {
        get { return propietario; } set { propietario = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> UsuarioFavorito {
        get { return usuarioFavorito; } set { usuarioFavorito = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN Marca {
        get { return marca; } set { marca = value;  }
}



public virtual Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN ReservaActiva {
        get { return reservaActiva; } set { reservaActiva = value;  }
}





public CocheEN()
{
        usuarioFavorito = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN>();
}



public CocheEN(int id, string matricula, string imagenes, double precio, int plazas, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum tipo, string descripcion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum disponible, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN propietario, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuarioFavorito, Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN marca, Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reservaActiva
               )
{
        this.init (Id, matricula, imagenes, precio, plazas, tipo, descripcion, disponible, propietario, usuarioFavorito, marca, reservaActiva);
}


public CocheEN(CocheEN coche)
{
        this.init (coche.Id, coche.Matricula, coche.Imagenes, coche.Precio, coche.Plazas, coche.Tipo, coche.Descripcion, coche.Disponible, coche.Propietario, coche.UsuarioFavorito, coche.Marca, coche.ReservaActiva);
}

private void init (int id
                   , string matricula, string imagenes, double precio, int plazas, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum tipo, string descripcion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum disponible, Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN propietario, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN> usuarioFavorito, Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN marca, Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reservaActiva)
{
        this.Id = id;


        this.Matricula = matricula;

        this.Imagenes = imagenes;

        this.Precio = precio;

        this.Plazas = plazas;

        this.Tipo = tipo;

        this.Descripcion = descripcion;

        this.Disponible = disponible;

        this.Propietario = propietario;

        this.UsuarioFavorito = usuarioFavorito;

        this.Marca = marca;

        this.ReservaActiva = reservaActiva;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CocheEN t = obj as CocheEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
