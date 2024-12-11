
using System;
// Definición clase MarcaEN
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public partial class MarcaEN
{
/**
 *	Atributo idMarca
 */
private int idMarca;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo coche
 */
private System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> coche;






public virtual int IdMarca {
        get { return idMarca; } set { idMarca = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> Coche {
        get { return coche; } set { coche = value;  }
}





public MarcaEN()
{
        coche = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
}



public MarcaEN(int idMarca, string nombre, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> coche
               )
{
        this.init (IdMarca, nombre, coche);
}


public MarcaEN(MarcaEN marca)
{
        this.init (marca.IdMarca, marca.Nombre, marca.Coche);
}

private void init (int idMarca
                   , string nombre, System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> coche)
{
        this.IdMarca = idMarca;


        this.Nombre = nombre;

        this.Coche = coche;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MarcaEN t = obj as MarcaEN;
        if (t == null)
                return false;
        if (IdMarca.Equals (t.IdMarca))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdMarca.GetHashCode ();
        return hash;
}
}
}
